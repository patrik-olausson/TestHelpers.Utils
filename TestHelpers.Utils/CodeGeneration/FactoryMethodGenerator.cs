using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestHelpers.Utils.Reflection;

namespace TestHelpers.Utils.CodeGeneration
{
    public static class FactoryMethodGenerator
    {
        /// <summary>
        /// Method that creates a factory method for a type. 
        /// It is designed to work for DTO type classes that you want to 
        /// create in your tests using an Object Builder Pattern.
        /// </summary>
        public static string CreateFor<T>(Action<string> outputAction = null)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            var builder = new FactoryMethodCodeBuilder(type.Name);
            foreach (var property in properties)
            {
                builder.HandleProperty(property);
            }

            var code = builder.ToString();
            outputAction?.Invoke(code);

            return code;
        }
    }

    internal class FactoryMethodCodeBuilder
    {
        private readonly StringBuilder _code;
        private readonly List<string> _params = new List<string>();
        private readonly List<string> _assignments = new List<string>();
        private readonly List<string> _localVaraiables = new List<string>();
        private string _charSeed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private int _charIndex;
        private int _numberSeed = 1;
        private int NextNumber => _numberSeed++;
        private char NextChar => _charSeed[NextCharIndex];

        private int NextCharIndex
        {
            get
            {
                if (_charIndex >= _charSeed.Length)
                {
                    _charIndex = 0;
                }

                return _charIndex++;
            }
        }
        
        public FactoryMethodCodeBuilder(string typeName)
        {
            _code = new StringBuilder();
            _code.AppendLine($"public static {typeName} Create{typeName}(");
            _code.AppendLine("PARAMS)");
            _code.AppendLine("{");
            _code.AppendLine("LOCALVARS");
            _code.AppendLine($"\treturn new {typeName}");
            _code.AppendLine("\t{");
            _code.AppendLine("ASSIGNMENTS");
            _code.AppendLine("\t};");
            _code.AppendLine("}");
        }

        public void HandleProperty(PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            if (propertyType == typeof(bool))
                HandleProperty(property, "bool", "false"); 
            else if (propertyType == typeof(string))
                HandleProperty(property, "string", $"\"Default{property.Name}\"");
            else if (propertyType == typeof(char))
                HandleProperty(property, "char", $"'{NextChar}'");
            else if (propertyType == typeof(DateTime))
                HandleProperty(property, "DateTime?", "null", " ?? now", "var now = DateTime.Now;");
            else if (propertyType == typeof(DateTimeOffset))
                HandleProperty(property, "DateTimeOffset?", "null", " ?? nowWithOffset", "var nowWithOffset = DateTimeOffset.Now;");
            else if (propertyType.IsIntegerNumberType())
            {
                var numericTypeInfo = propertyType.GetNumericTypeInfo();
                HandleProperty(property, numericTypeInfo.Alias, NextNumber.ToString());
            }
            else if (propertyType.IsDecimalNumberType())
            {
                var numericTypeInfo = propertyType.GetNumericTypeInfo();
                HandleProperty(property, numericTypeInfo.Alias, GetNextDecimalNumber(numericTypeInfo.Suffix));
            }
            else if (propertyType.IsGenericType)
            {
                HandleGenericProperty(property, propertyType);
            }
            else if (propertyType.IsArray)
            {
                var arrayType = propertyType.GetElementType()?.Name;
                HandleProperty(property, $"{arrayType}[]", "null", $" ?? new {arrayType}[0]");
            }
            //Important to check for these last because all types are either class, interface or value type...
            else if(propertyType.IsClass || propertyType.IsInterface)
                HandleProperty(property, propertyType.Name, "null");
            else if(propertyType.IsValueType) //An enum is a value type so Enums are handled here as well...
                HandleProperty(property, $"{propertyType.Name}?", "null", $" ?? default({propertyType.Name})");
        }

        private void HandleGenericProperty(PropertyInfo property, Type propertyType)
        {
            var genericArgs = propertyType.GetGenericArguments();
            var wierdGenricNameSuffix = $"`{genericArgs.Length}";
            var genericArgumentList = $"<{string.Join(", ", genericArgs.Select(x => x.Name))}>";
            var genericType = propertyType.Name.Replace(wierdGenricNameSuffix, genericArgumentList);

            if (propertyType.IsDictionary())
            {
                HandleProperty(property, genericType, "null", $" ?? new Dictionary{genericArgumentList}()");
            }
            else if (propertyType.IsEnumerable())
            {
                HandleProperty(property, genericType, "null", $" ?? new List{genericArgumentList}()");
            }
            else
            {
                HandleProperty(property, genericType, "null");
            }
        }

        private void HandleProperty(
            PropertyInfo property, 
            string type,
            string defaultValue,
            string extraAssignment = "",
            string localVariable = "")
        {
            var parameterName = GetParameterName(property);
            AddParam(type, parameterName, defaultValue);
            AddAssignment(property.Name, parameterName, extraAssignment);

            if (localVariable.HasValue())
            {
                AddLocalVariable(localVariable);
            }
        }

        /// <summary>
        /// Creates a numeric value with one decimal, not specifically for the Decimal type but for all
        /// floating point numbers.
        /// </summary>
        /// <param name="typeIdentifier">M for decimal, F for float, etc</param>
        /// <returns>A string with with a number like: 2.2M</returns>
        private string GetNextDecimalNumber(string typeIdentifier = "")
        {
            var numberSeed = NextNumber;
            return $"{numberSeed}.{numberSeed}{typeIdentifier}";
        }

        private void AddLocalVariable(string localVariable)
        {
            var valueToAdd = $"\t{localVariable}";
            if (!_localVaraiables.Contains(valueToAdd))
            {
                _localVaraiables.Add(valueToAdd);
            }
        }

        private void AddParam(string type, string parameterName, string defaultValue)
        {
            _params.Add($"\t{type} {parameterName} = {defaultValue}");
        }

        private void AddAssignment(string propertyName, string parameterName, string extraAssignment = "")
        {
            _assignments.Add($"\t\t{propertyName} = {parameterName}{extraAssignment}");
        }

        private string GetParameterName(PropertyInfo property)
        {
            var propertyName = property.Name;

            return $"{propertyName.Substring(0, 1).ToLower()}{propertyName.Substring(1, propertyName.Length - 1)}";
        }

        public override string ToString()
        {
            var localVariables = string.Join(Environment.NewLine, _localVaraiables);
            var parameters = string.Join($",{Environment.NewLine}", _params);
            var assignments = string.Join($",{Environment.NewLine}", _assignments);

            return _code
                .ToString()
                .Replace("LOCALVARS", localVariables)
                .Replace("PARAMS", parameters)
                .Replace("ASSIGNMENTS", assignments);
        }
    }
}