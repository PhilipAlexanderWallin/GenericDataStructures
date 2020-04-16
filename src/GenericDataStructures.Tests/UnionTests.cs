using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GenericDataStructures.Tests
{
    public class UnionTests
    {
        private const int NumberOfTypesToTestWith = 8;

        [Test]
        public void OnlyFuncForTheSameIndexedParameterTypeIsCalledOnMatch()
        {
            foreach (var (union, value, valueType) in AllUnionsToTest())
            {
                var unionType = union.GetType();

                var delegateMonitor = new DelegateMonitor();

                var createStringDelegates = GetAllTypes(unionType)
                    .Select(genericType => DelegateCreator.CreateDelegate(
                        delegateMonitor,
                        nameof(DelegateMonitor.CreateString),
                        true,
                        typeof(Func<,>),
                        genericType,
                        typeof(string)))
                    .Cast<object>()
                    .ToArray();

                var genericMatchMethod = unionType.GetMethods().Single(method => method.Name == "Match" && method.IsGenericMethod);

                if (genericMatchMethod == null)
                {
                    throw new InvalidOperationException("Match method not found");
                }

                var matchMethod = genericMatchMethod.MakeGenericMethod(typeof(string));

                var matchResult = matchMethod.Invoke(union, createStringDelegates);

                Assert.AreEqual(matchResult, value?.ToString());

                Assert.AreEqual(1, delegateMonitor.TotalCalls);

                Assert.AreEqual(1, delegateMonitor.GetCalls(valueType));
            }
        }

        [Test]
        public void OnlyActionForTheSameIndexedParameterTypeIsCalledOnMatch()
        {
            foreach (var (union, value, valueType) in AllUnionsToTest())
            {
                var resultType = union.GetType();

                var delegateMonitor = new DelegateMonitor();

                var voidDelegates = GetAllTypes(resultType)
                    .Select(genericType => DelegateCreator.CreateDelegate(
                        delegateMonitor,
                        nameof(DelegateMonitor.NoOperation),
                        true,
                        typeof(Action<>),
                        genericType))
                    .Cast<object>()
                    .ToArray();

                var matchMethod = resultType.GetMethods().Single(method => method.Name == "Match" && !method.IsGenericMethod);

                if (matchMethod == null)
                {
                    throw new InvalidOperationException("Match method not found");
                }

                matchMethod.Invoke(union, voidDelegates);

                Assert.AreEqual(1, delegateMonitor.TotalCalls);

                Assert.AreEqual(1, delegateMonitor.GetCalls(valueType));
            }
        }

        private static IEnumerable<(object Union, object Value, Type ValueType)> AllUnionsToTest()
        {
            return
                from unionType in AllUnionTypesToTest()
                let unionTypeGenericTypes = GetAllTypes(unionType)
                from resultValueType in unionTypeGenericTypes
                from value in TestData.GetPossibleValues(resultValueType)
                select (CreateUnion(unionType, resultValueType, value), value, resultValueType);
        }

        private static IEnumerable<Type> AllUnionTypesToTest()
        {
            for (var numberOfTypes = 1; numberOfTypes <= NumberOfTypesToTestWith; numberOfTypes++)
            {
                foreach (var testTypeSet in TestData.GetTestTypeSets(numberOfTypes))
                {
                    yield return GetUnionType(testTypeSet.ToList());
                }
            }
        }

        private static Type GetUnionType(ICollection<Type> genericTypesToUse)
        {
            var typeName = $"{nameof(GenericDataStructures)}.Union`{genericTypesToUse.Count}, GenericDataStructures";
            var genericUnionType = Type.GetType(typeName);
            if (genericUnionType == null)
            {
                throw new InvalidOperationException("Union type not found");
            }

            return genericUnionType.MakeGenericType(genericTypesToUse.ToArray());
        }

        private static IEnumerable<Type> GetAllTypes(Type unionType)
        {
            return unionType.GetGenericArguments();
        }

        private static object CreateUnion(Type unionType, Type valueType, object? value)
        {
            var constructor = unionType.GetConstructor(new[] { valueType });

            if (constructor == null)
            {
                throw new InvalidOperationException("Constructor not found");
            }

            return constructor.Invoke(new[] { value });
        }
    }
}