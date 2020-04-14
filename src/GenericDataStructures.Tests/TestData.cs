using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericDataStructures.Tests
{
    public static class TestData
    {
        private static readonly Dictionary<Type, object?[]> TestDataDefinitions = new Dictionary<Type, object?[]>
        {
            {
                typeof(int),
                new object?[]
                {
                    -123,
                    123,
                }
            },
            {
                typeof(bool),
                new object?[]
                {
                    true,
                    false,
                }
            },
            {
                typeof(string),
                new object?[]
                {
                    null,
                    string.Empty,
                    "abc123",
                }
            },
            {
                typeof(float),
                new object?[]
                {
                    -1.23f,
                    1.23f,
                }
            },
            {
                typeof(SimpleClass),
                new object?[]
                {
                    null,
                    new SimpleClass
                    {
                        Number = 123,
                        Child = new SimpleClass(),
                    },
                }
            },
            {
                typeof(SimpleStruct),
                new object?[]
                {
                    default(SimpleStruct),
                }
            },
            {
                typeof(SimpleStruct?),
                new object?[]
                {
                    null,
                    new SimpleStruct
                    {
                        Number = 123,
                    },
                }
            },
            {
                typeof(byte),
                new object?[]
                {
                    (byte)123,
                    (byte)0,
                }
            },
            {
                typeof(long),
                new object?[]
                {
                    long.MaxValue,
                    123456789L,
                }
            },
        };

        public static IEnumerable<object?> GetPossibleValues(Type testType)
        {
            return TestDataDefinitions[testType];
        }

        public static IEnumerable<IEnumerable<Type>> GetTestTypeSets(int numberOfTypes)
        {
            for (var startIndex = 0; startIndex < TestDataDefinitions.Count; startIndex++)
            {
                yield return GetTestTypeSet(startIndex, numberOfTypes);
            }
        }

        private static IEnumerable<Type> GetTestTypeSet(int startTypeIndex, int numberOfTypes)
        {
            for (var i = 0; i < numberOfTypes; i++)
            {
                yield return GetTestDataType(startTypeIndex, i);
            }
        }

        private static Type GetTestDataType(int startIndex, int offset)
        {
            var testDataTypes = TestDataDefinitions.Keys.ToList();
            return testDataTypes[(startIndex + offset) % TestDataDefinitions.Count];
        }

        public struct SimpleStruct
        {
            public int Number { get; set; }
        }

        public class SimpleClass
        {
            public int Number { get; set; }

            public SimpleClass? Child { get; set; }
        }
    }
}
