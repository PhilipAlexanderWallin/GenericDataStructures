using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace GenericDataStructures.Tests
{
    public class ResultTests
    {
        private const int NumberOfFailureTypesToTestWith = 8;

        [Test]
        public void WhenConstructedWithSuccessTypeResultIsSuccess()
        {
            ForEachResultTypeToTest(resultType =>
            {
                var successType = GetSuccessType(resultType);
                foreach (var value in TestData.GetPossibleValues(successType))
                {
                    dynamic result = CreateResult(resultType, successType, value);

                    Assert.IsTrue(result.IsSuccess);
                }
            });
        }

        [Test]
        public void WhenConstructedWithFailureTypeResultIsNotSuccess()
        {
            ForEachResultTypeToTest(resultType =>
            {
                var failureTypes = GetFailureTypes(resultType);
                foreach (var failureType in failureTypes)
                {
                    foreach (var value in TestData.GetPossibleValues(failureType))
                    {
                        dynamic result = CreateResult(resultType, failureType, value);

                        Assert.IsFalse(result.IsSuccess);
                    }
                }
            });
        }

        [Test]
        public void OnlyFuncForTheSameIndexedParameterTypeIsCalledOnMatch()
        {
            ForEachResultTypeToTest(resultType =>
            {
                var resultTypeGenericTypes = GetAllTypes(resultType).ToList();
                foreach (var resultValueType in resultTypeGenericTypes)
                {
                    foreach (var value in TestData.GetPossibleValues(resultValueType))
                    {
                        var delegateMonitor = new DelegateMonitor();

                        var result = CreateResult(resultType, resultValueType, value);

                        var convertToStringDelegates = resultTypeGenericTypes
                            .Select(genericType =>
                            {
                                var delegateType = typeof(Func<,>).MakeGenericType(genericType, typeof(string));
                                var genericConvertToStringMethod = typeof(DelegateMonitor).GetMethod(nameof(DelegateMonitor.ConvertToString), BindingFlags.Public | BindingFlags.Instance);
                                if (genericConvertToStringMethod == null)
                                {
                                    throw new InvalidOperationException("Convert method not found");
                                }

                                var convertToStringMethod = genericConvertToStringMethod.MakeGenericMethod(genericType);
                                return Delegate.CreateDelegate(delegateType, delegateMonitor, convertToStringMethod);
                            })
                            .Cast<object>()
                            .ToArray();

                        var genericMatchMethod = resultType.GetMethods().Single(method => method.Name == "Match" && method.IsGenericMethod);

                        if (genericMatchMethod == null)
                        {
                            throw new InvalidOperationException("Match method not found");
                        }

                        var matchMethod = genericMatchMethod.MakeGenericMethod(typeof(string));

                        var matchResult = matchMethod.Invoke(result, convertToStringDelegates);

                        Assert.AreEqual(matchResult, value?.ToString());

                        Assert.AreEqual(1, delegateMonitor.TotalCalls);

                        Assert.AreEqual(1, delegateMonitor.GetCalls(resultValueType));
                    }
                }
            });
        }

        [Test]
        public void OnlyActionForTheSameIndexedParameterTypeIsCalledOnMatch()
        {
            ForEachResultTypeToTest(resultType =>
            {
                var resultTypeGenericTypes = GetAllTypes(resultType).ToList();
                foreach (var resultValueType in resultTypeGenericTypes)
                {
                    foreach (var value in TestData.GetPossibleValues(resultValueType))
                    {
                        var delegateMonitor = new DelegateMonitor();

                        var result = CreateResult(resultType, resultValueType, value);

                        var voidDelegates = resultTypeGenericTypes
                            .Select(genericType =>
                            {
                                var delegateType = typeof(Action<>).MakeGenericType(genericType);
                                var genericNoOperationMethod = typeof(DelegateMonitor).GetMethod(nameof(DelegateMonitor.NoOperation), BindingFlags.Public | BindingFlags.Instance);
                                if (genericNoOperationMethod == null)
                                {
                                    throw new InvalidOperationException("No operation method not found");
                                }

                                var noOperationMethod = genericNoOperationMethod.MakeGenericMethod(genericType);
                                return Delegate.CreateDelegate(delegateType, delegateMonitor, noOperationMethod);
                            })
                            .Cast<object>()
                            .ToArray();

                        var matchMethod = resultType.GetMethods().Single(method => method.Name == "Match" && !method.IsGenericMethod);

                        if (matchMethod == null)
                        {
                            throw new InvalidOperationException("Match method not found");
                        }

                        matchMethod.Invoke(result, voidDelegates);

                        Assert.AreEqual(1, delegateMonitor.TotalCalls);

                        Assert.AreEqual(1, delegateMonitor.GetCalls(resultValueType));
                    }
                }
            });
        }

        private static void ForEachResultTypeToTest(Action<Type> action)
        {
            for (var numberOfFailureTypes = 1; numberOfFailureTypes <= NumberOfFailureTypesToTestWith; numberOfFailureTypes++)
            {
                foreach (var testTypeSet in TestData.GetTestTypeSets(numberOfFailureTypes + 1))
                {
                    var resultType = GetResultType(testTypeSet.ToList());
                    action(resultType);
                }
            }
        }

        private static Type GetResultType(ICollection<Type> genericTypesToUse)
        {
            var typeName = $"{nameof(GenericDataStructures)}.Result`{genericTypesToUse.Count}, GenericDataStructures";
            var nonGenericResultType = Type.GetType(typeName);
            if (nonGenericResultType == null)
            {
                throw new InvalidOperationException("Result type not found");
            }

            var resultType = nonGenericResultType.MakeGenericType(genericTypesToUse.ToArray());
            return resultType;
        }

        private static IEnumerable<Type> GetAllTypes(Type resultType)
        {
            return resultType.GetGenericArguments();
        }

        private static Type GetSuccessType(Type resultType)
        {
            return resultType.GetGenericArguments()[0];
        }

        private static IEnumerable<Type> GetFailureTypes(Type resultType)
        {
            return resultType.GetGenericArguments().Skip(1);
        }

        private static object CreateResult(Type resultType, Type valueType, object? value)
        {
            var successConstructor = resultType.GetConstructor(new[] { valueType });

            if (successConstructor == null)
            {
                throw new InvalidOperationException("Constructor not found");
            }

            return successConstructor.Invoke(new[] { value });
        }
    }
}