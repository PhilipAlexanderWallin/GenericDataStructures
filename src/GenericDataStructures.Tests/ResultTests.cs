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
        public void WhenConstructedWithSuccessTypeTryGetSuccessValueProvidesTheValue()
        {
            foreach (var resultType in AllResultTypesToTest())
            {
                var successType = GetSuccessType(resultType);
                foreach (var value in TestData.GetPossibleValues(successType))
                {
                    var result = CreateResult(resultType, successType, value);

                    var tryGetSuccessValueMethod = resultType.GetMethod("TryGetSuccessValue");

                    if (tryGetSuccessValueMethod == null)
                    {
                        throw new MissingMethodException("TryGetSuccessValue method is expected to be implemented");
                    }

                    var parameters = new object?[] { null };
                    var isSuccessful = tryGetSuccessValueMethod.Invoke(result, parameters);

                    if (isSuccessful == null)
                    {
                        throw new InvalidOperationException("TryGetSuccessValue should only return true or false");
                    }

                    Assert.IsTrue((bool)isSuccessful);

                    var outResult = parameters.Single();
                    Assert.AreEqual(value, outResult);
                }
            }
        }

        [Test]
        public void WhenConstructedWithFailureTypeTryGetSuccessValueReturnsFalseAndProvidesDefaultValue()
        {
            foreach (var resultType in AllResultTypesToTest())
            {
                var successType = GetSuccessType(resultType);
                foreach (var failureType in GetFailureTypes(resultType))
                {
                    foreach (var value in TestData.GetPossibleValues(failureType))
                    {
                        var result = CreateResult(resultType, failureType, value);

                        var tryGetSuccessValueMethod = resultType.GetMethod("TryGetSuccessValue");

                        if (tryGetSuccessValueMethod == null)
                        {
                            throw new MissingMethodException("TryGetSuccessValue method is expected to be implemented");
                        }

                        var parameters = new object?[] { null };
                        var isSuccessful = tryGetSuccessValueMethod.Invoke(result, parameters);

                        if (isSuccessful == null)
                        {
                            throw new InvalidOperationException("TryGetSuccessValue should only return true or false");
                        }

                        Assert.IsFalse((bool)isSuccessful);

                        var outResult = parameters.Single();
                        var expectedValue = GetDefaultValue(successType);
                        Assert.AreEqual(expectedValue, outResult);
                    }
                }
            }
        }

        [Test]
        public void WhenConstructedWithSuccessTypeTryMapWillMapTheValue()
        {
            foreach (var resultType in AllResultTypesToTest())
            {
                var successType = GetSuccessType(resultType);
                foreach (var value in TestData.GetPossibleValues(successType))
                {
                    var result = CreateResult(resultType, successType, value);

                    var delegateMonitor = new DelegateMonitor();

                    var genericTryMapMethod = resultType.GetMethod("TryMap");

                    if (genericTryMapMethod == null)
                    {
                        throw new MissingMethodException("TryMap method is expected to be implemented");
                    }

                    var tryMapMethod = genericTryMapMethod.MakeGenericMethod(typeof(string));

                    var createStringDelegate =
                        DelegateCreator.CreateDelegate(
                            delegateMonitor,
                            nameof(DelegateMonitor.CreateString),
                            true,
                            typeof(Func<,>),
                            successType,
                            typeof(string));

                    var parameters = new object?[] { createStringDelegate, null };
                    var isSuccessful = tryMapMethod.Invoke(result, parameters);

                    if (isSuccessful == null)
                    {
                        throw new InvalidOperationException("TryMap should only return true or false");
                    }

                    Assert.IsTrue((bool)isSuccessful);

                    var mapResult = parameters[1];

                    Assert.AreEqual(value?.ToString(), mapResult);

                    Assert.AreEqual(1, delegateMonitor.TotalCalls);

                    Assert.AreEqual(1, delegateMonitor.GetCalls(successType));
                }
            }
        }

        [Test]
        public void WhenConstructedWithFailureTypeTryMapWillReturnFalseAndProvideDefaultValue()
        {
            foreach (var resultType in AllResultTypesToTest())
            {
                var successType = GetSuccessType(resultType);
                foreach (var failureType in GetFailureTypes(resultType))
                {
                    foreach (var value in TestData.GetPossibleValues(failureType))
                    {
                        var result = CreateResult(resultType, failureType, value);

                        var delegateMonitor = new DelegateMonitor();

                        var genericTryMapMethod = resultType.GetMethod("TryMap");

                        if (genericTryMapMethod == null)
                        {
                            throw new MissingMethodException("TryMap method is expected to be implemented");
                        }

                        var tryMapMethod = genericTryMapMethod.MakeGenericMethod(typeof(string));

                        var createStringDelegate =
                            DelegateCreator.CreateDelegate(
                                delegateMonitor,
                                nameof(DelegateMonitor.CreateString),
                                true,
                                typeof(Func<,>),
                                successType,
                                typeof(string));

                        var parameters = new object?[] { createStringDelegate, null };
                        var isSuccessful = tryMapMethod.Invoke(result, parameters);

                        if (isSuccessful == null)
                        {
                            throw new InvalidOperationException("TryMap should only return true or false");
                        }

                        Assert.IsFalse((bool)isSuccessful);

                        var mapResult = parameters[1];

                        Assert.IsNull(mapResult);

                        Assert.AreEqual(0, delegateMonitor.TotalCalls);
                    }
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
        public void OnlyFuncForTheSameIndexedParameterTypeIsCalledOnMap()
        {
            foreach (var (result, value, valueType) in AllResultsToTest())
            {
                var resultType = result.GetType();

                var delegateMonitor = new DelegateMonitor();

                var createStringDelegates = GetAllTypes(resultType)
                    .Select(genericType => DelegateCreator.CreateDelegate(
                        delegateMonitor,
                        nameof(DelegateMonitor.CreateString),
                        true,
                        typeof(Func<,>),
                        genericType,
                        typeof(string)))
                    .Cast<object>()
                    .ToArray();

                var genericMapMethod = resultType.GetMethods().Single(method => method.Name == "Map" && method.IsGenericMethod);

                if (genericMapMethod == null)
                {
                    throw new InvalidOperationException("Map method not found");
                }

                var mapMethod = genericMapMethod.MakeGenericMethod(typeof(string));

                var mapResult = mapMethod.Invoke(result, createStringDelegates);

                Assert.AreEqual(value?.ToString(), mapResult);

                Assert.AreEqual(1, delegateMonitor.TotalCalls);

                Assert.AreEqual(1, delegateMonitor.GetCalls(valueType));
            }
        }

        [Test]
        public void OnlyActionForTheSameIndexedParameterTypeIsCalledOnSwitch()
        {
            foreach (var (result, value, valueType) in AllResultsToTest())
            {
                var resultType = result.GetType();

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

                var switchMethod = resultType.GetMethods().Single(method => method.Name == "Switch" && !method.IsGenericMethod);

                if (switchMethod == null)
                {
                    throw new InvalidOperationException("Switch method not found");
                }

                switchMethod.Invoke(result, voidDelegates);

                Assert.AreEqual(1, delegateMonitor.TotalCalls);

                Assert.AreEqual(1, delegateMonitor.GetCalls(valueType));
            }
        }

        private static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
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
            var genericResultType = Type.GetType(typeName);
            if (genericResultType == null)
            {
                throw new InvalidOperationException("Result type not found");
            }

            return genericResultType.MakeGenericType(genericTypesToUse.ToArray());
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