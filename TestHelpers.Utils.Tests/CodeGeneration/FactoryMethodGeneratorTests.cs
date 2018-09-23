using System;
using System.Collections.Generic;
using TestHelpers.Utils.CodeGeneration;
using Xunit;
using Xunit.Abstractions;

namespace TestHelpers.Utils.Tests.CodeGeneration
{
    public class FactoryMethodGeneratorTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public FactoryMethodGeneratorTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact] //A very special test, it fails if any changes are made, only to have you verify the generated code in the test output...
        public void WhenCreatingFactoryMethodForKnownType_ItCreatesTheExpectedParameterListWithDefaultValuesAndAssignments()
        {
            var result = FactoryMethodGenerator.CreateFor<ClassToCreateFactoryMethodFor>(_testOutputHelper.WriteLine);

            Assert.Equal(1972, result.Length);
        }
    }

    internal class ClassToCreateFactoryMethodFor
    {
        public bool BoolProp { get; set; }
        public string StringProp { get; set; }
        public char CharProp { get; set; }
        public int IntProp { get; set; }
        public short ShortProp { get; set; }
        public long LongProp { get; set; }
        public byte ByteProp { get; set; }
        public DateTime DateTimeProp { get; set; }
        public DateTimeOffset DateTimeOffsetProp { get; set; }
        public decimal DecimalProp { get; set; }
        public double DoubleProp { get; set; }
        public float FloatProp { get; set; }
        public NestedFactoryMethodClass ObjectProp { get; set; }
        public INestedFactoryMethodInterface InterfaceProp { get; set; }
        public NestedFactoryMethodStruct StructProp { get; set; }
        public FactoryMethodEnum EnumProp { get; set; }
        public string[] ArrayProp { get; set; }

        public int? NullableIntProp { get; set; }
        public IReadOnlyCollection<string> ReadOnlyCollectionProp { get; set; }
        public List<string> ListProp { get; set; }
        public IEnumerable<string> IEnumerableProp { get; set; }
        public Dictionary<int, string> DictionaryProp { get; set; }
        public IDictionary<int, string> IDictionaryProp { get; set; }
    }

    internal class NestedFactoryMethodClass
    {

    }

    internal interface INestedFactoryMethodInterface
    {

    }

    internal struct NestedFactoryMethodStruct
    {

    }

    internal enum FactoryMethodEnum { First, Second }
}