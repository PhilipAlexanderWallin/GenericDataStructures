using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GenericDataStructures.Tests
{
    public class ResultTests
    {
        private const int NumberOfFailureTypesToTestWith = 8;

        [Test]
        public void WhenConstructedWithSuccessTypeResultIsSuccess()
        {
            foreach (var resultType in AllResultTypesToTest())
            {
                var successType = GetSuccessType(resultType);
                foreach (var value in TestData.GetPossibleValues(successType))
                {
                    dynamic result = CreateResult(resultType, successType, value);

                    Assert.IsTrue(result.IsSuccess);
                }
            }
        }

        [Test]
        public void WhenConstructedWithSuccessTypeOnSuccessProvidesTheValue()
        {
            foreach (var resultType in AllResultTypesToTest())
            {
                var successType = GetSuccessType(resultType);
                foreach (var value in TestData.GetPossibleValues(successType))
                {
                    var result = CreateResult(resultType, successType, value);

                    var actionValueReader = new ActionValueReader();

                    var onSuccessMethod = resultType.GetMethod("OnSuccess");

                    if (onSuccessMethod == null)
                    {
                        throw new MissingMethodException("OnSuccess method is expected to be implemented");
                    }

                    var delegateType = typeof(Action<>).MakeGenericType(successType);
                    var genericExtractValueMethod = typeof(ActionValueReader).GetMethods()
                        .Single(method => method.Name == nameof(ActionValueReader.ExtractValue) && method.IsGenericMethod);
                    if (genericExtractValueMethod == null)
                    {
                        throw new InvalidOperationException("Extract value method not found");
                    }

                    var typedExtractValueMethod = genericExtractValueMethod.MakeGenericMethod(successType);

                    var extractValueDelegate = Delegate.CreateDelegate(delegateType, actionValueReader, typedExtractValueMethod);

                    onSuccessMethod.Invoke(result, new object[] { extractValueDelegate });

                    Assert.AreEqual(value, actionValueReader.ExtractedValue);
                }
            }
        }

        [Test]
        public void WhenConstructedWithFailureTypeResultIsNotSuccess()
        {
            foreach (var resultType in AllResultTypesToTest())
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
            }
        }

        [Test]
        public void OnlyFuncForTheSameIndexedParameterTypeIsCalledOnMatch()
        {
            foreach (var (result, value, valueType) in AllResultsToTest())
            {
                var resultType = result.GetType();

                var delegateMonitor = new DelegateMonitor();

                var createStringDelegates = GetAllTypes(resultType)
                    .Select(genericType =>
                    {
                        var delegateType = typeof(Func<,>).MakeGenericType(genericType, typeof(string));
                        var genericCreateStringMethod = typeof(DelegateMonitor).GetMethods().Single(method => method.Name == nameof(DelegateMonitor.CreateString) && method.IsGenericMethod);
                        if (genericCreateStringMethod == null)
                        {
                            throw new InvalidOperationException("Create string method not found");
                        }

                        var createStringMethod = genericCreateStringMethod.MakeGenericMethod(genericType);
                        return Delegate.CreateDelegate(delegateType, delegateMonitor, createStringMethod);
                    })
                    .Cast<object>()
                    .ToArray();

                var genericMatchMethod = resultType.GetMethods().Single(method => method.Name == "Match" && method.IsGenericMethod);

                if (genericMatchMethod == null)
                {
                    throw new InvalidOperationException("Match method not found");
                }

                var matchMethod = genericMatchMethod.MakeGenericMethod(typeof(string));

                var matchResult = matchMethod.Invoke(result, createStringDelegates);

                Assert.AreEqual(matchResult, value?.ToString());

                Assert.AreEqual(1, delegateMonitor.TotalCalls);

                Assert.AreEqual(1, delegateMonitor.GetCalls(valueType));
            }
        }

        [Test]
        public void OnlyActionForTheSameIndexedParameterTypeIsCalledOnMatch()
        {
            foreach (var (result, value, valueType) in AllResultsToTest())
            {
                var resultType = result.GetType();

                var delegateMonitor = new DelegateMonitor();

                var voidDelegates = GetAllTypes(resultType)
                    .Select(genericType =>
                    {
                        var delegateType = typeof(Action<>).MakeGenericType(genericType);
                        var genericNoOperationMethod = typeof(DelegateMonitor).GetMethods().Single(method => method.Name == nameof(DelegateMonitor.NoOperation) && method.IsGenericMethod);
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

                Assert.AreEqual(1, delegateMonitor.GetCalls(valueType));
            }
        }

        private static IEnumerable<(object Result, object Value, Type ValueType)> AllResultsToTest()
        {
            return
                from resultType in AllResultTypesToTest()
                let resultTypeGenericTypes = GetAllTypes(resultType)
                from resultValueType in resultTypeGenericTypes
                from value in TestData.GetPossibleValues(resultValueType)
                select (CreateResult(resultType, resultValueType, value), value, resultValueType);
        }

        private static IEnumerable<Type> AllResultTypesToTest()
        {
            for (var numberOfFailureTypes = 1; numberOfFailureTypes <= NumberOfFailureTypesToTestWith; numberOfFailureTypes++)
            {
                foreach (var testTypeSet in TestData.GetTestTypeSets(numberOfFailureTypes + 1))
                {
                    yield return GetResultType(testTypeSet.ToList());
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
            var constructor = resultType.GetConstructor(new[] { valueType });

            if (constructor == null)
            {
                throw new InvalidOperationException("Constructor not found");
            }

            return constructor.Invoke(new[] { value });
        }
    }
}