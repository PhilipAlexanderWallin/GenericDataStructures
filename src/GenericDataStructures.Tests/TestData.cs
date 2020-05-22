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
                typeof(double),
                new object?[]
                {
                    -1.23d,
                    1.23d,
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
            {
                typeof(SimpleEnum),
                new object?[]
                {
                    SimpleEnum.Value1,
                    SimpleEnum.Value3,
                }
            },
            {
                typeof(Tuple<int, string>),
                new object?[]
                {
                    Tuple.Create(1, "one"),
                    Tuple.Create(3, "three"),
                }
            },
            {
                typeof(ValueTuple<string, int>),
                new object?[]
                {
                    ("one", 1),
                    ("three", 3),
                }
            },
            {
                typeof(ushort),
                new object?[]
                {
                    (ushort)12345,
                    (ushort)0,
                }
            },
            {
                typeof(bool?),
                new object?[]
                {
                    true,
                    false,
                    null,
                }
            },
            {
                typeof(SimpleEnum?),
                new object?[]
                {
                    SimpleEnum.Value2,
                    SimpleEnum.Value3,
                    null,
                }
            },
        };

        public enum SimpleEnum
        {
            Value1 = 1,
            Value2 = 2,
            Value3 = 3,
        }

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
