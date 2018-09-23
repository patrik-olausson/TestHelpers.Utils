using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestHelpers.Utils.Reflection
{
    public static class ReflectionExtensions
    {
        private static readonly Dictionary<Type, NumericTypeInfo> IntegerNumberTypes = new Dictionary<Type, NumericTypeInfo>()
        {
            { typeof(byte),  new NumericTypeInfo("byte") },
            { typeof(sbyte), new NumericTypeInfo("sbyte") },
            { typeof(short), new NumericTypeInfo("short") },
            { typeof(ushort), new NumericTypeInfo("ushort") },
            { typeof(int), new NumericTypeInfo("int") },
            { typeof(uint), new NumericTypeInfo("uint") },
            { typeof(long), new NumericTypeInfo("long") },
            { typeof(ulong), new NumericTypeInfo("ulong") },
            { typeof(byte?), new NumericTypeInfo("byte?") },
            { typeof(sbyte?), new NumericTypeInfo("sbyte?") },
            { typeof(short?), new NumericTypeInfo("short?") },
            { typeof(ushort?), new NumericTypeInfo("ushort?") },
            { typeof(int?), new NumericTypeInfo("int?") },
            { typeof(uint?), new NumericTypeInfo("uint?") },
            { typeof(long?), new NumericTypeInfo("long?") },
            { typeof(ulong?), new NumericTypeInfo("ulong?") }
        };

        private static readonly Dictionary<Type, NumericTypeInfo> DecimalNumberTypes = new Dictionary<Type, NumericTypeInfo>()
        {
            { typeof(float), new NumericTypeInfo("float", "F") },
            { typeof(double), new NumericTypeInfo("double") },
            { typeof(decimal), new NumericTypeInfo("decimal", "M") },
            { typeof(float?), new NumericTypeInfo("float?", "F") },
            { typeof(double?), new NumericTypeInfo("double?") },
            { typeof(decimal?), new NumericTypeInfo("decimal?", "M") }
        };

        public static NumericTypeInfo GetNumericTypeInfo(this Type type)
        {
            if (type == null) return null;
            if (IntegerNumberTypes.TryGetValue(type, out NumericTypeInfo integerTypeInfo)) return integerTypeInfo;
            if (DecimalNumberTypes.TryGetValue(type, out NumericTypeInfo decimalTypeInfo)) return decimalTypeInfo;

            return null;
        }

        public static bool IsDecimalNumberType(this Type type)
        {
            if (type == null) return false;

            return DecimalNumberTypes.ContainsKey(type);
        }

        public static bool IsIntegerNumberType(this Type type)
        {
            if (type == null) return false;

            return IntegerNumberTypes.ContainsKey(type);
        }

        public static bool IsEnumerable(this Type type)
        {
            return type.ImplementsInterface<IEnumerable>();
        }

        public static bool IsDictionary(this Type type)
        {
            if (type == null) return false;
            if (ImplementsInterface(type, typeof(IDictionary))) return true;
            if (type.Name.Contains("Dictionary")) return true;

            return false;
        }

        public static bool ImplementsInterface<T>(this Type type)
        {
            return ImplementsInterface(type, typeof(T));
        }

        public static bool ImplementsInterface(this Type type, Type interfaceType)
        {
            if (type == null) return false;

            return type.GetInterfaces().Contains(interfaceType);
        }

        public static bool IsSubclassOf<T>(this Type type)
        {
            return IsSubclassOf(type, typeof(T));
        }

        public static bool IsSubclassOf(this Type type, Type baseType)
        {
            if (type == null) return false;

            return type.IsSubclassOf(baseType);
        }

        public static IReadOnlyCollection<T> GetCustomAttributes<T>(this Type type, bool inherit = true)
        {
            if(type == null) return new List<T>();

            return type
                .GetTypeInfo()
                .GetCustomAttributes(typeof(T), true)
                .Cast<T>()
                .ToList();
        }

        public static bool HasAttribute<T>(this Type type)
        {
            if (type == null) return false;

            return type.GetCustomAttributes<T>().Any();
        }
    }
}