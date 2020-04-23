using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GenericDataStructures.Tests
{
    public class VoidResultTests
    {
        private const int NumberOfFailureTypesToTestWith = 8;

        [Test]
        public void WhenConstructedWithSuccessVoidResultIsSuccess()
        {
            foreach (var voidResultType in AllVoidResultTypeToTest())
            {
                dynamic voidResult = CreateSuccessVoidResult(voidResultType);

                Assert.IsTrue(voidResult.IsSuccess);
            }
        }

        [Test]
        public void WhenConstructedWithFailureTypeResultIsNotSuccess()
        {
            foreach (var voidResultType in AllVoidResultTypeToTest())
            {
                var failureTypes = GetFailureTypes(voidResultType);
                foreach (var failureType in failureTypes)
                {
                    foreach (var failureValue in TestData.GetPossibleValues(failureType))
                    {
                        dynamic result = CreateFailureVoidResult(voidResultType, failureType, failureValue);

                        Assert.IsFalse(result.IsSuccess);
                    }
                }
            }
        }

        [Test]
        public void OnlyFuncForTheSameIndexedParameterTypeIsCalledOnMap()
        {
            foreach (var (voidResult, isSuccess, value, valueType) in AllVoidResultsToTest())
            {
                var voidResultType = voidResult.GetType();

                var delegateMonitor = new DelegateMonitor();

                var failureCreateStringDelegates = GetFailureTypes(voidResultType)
                    .Select(genericType =>
                        DelegateCreator.CreateDelegate(
                            delegateMonitor,
                            nameof(DelegateMonitor.CreateString),
                            true,
                            typeof(Func<,>),
                            genericType,
                            typeof(string)));

                var successCreateStringDelegate = DelegateCreator.CreateDelegate(
                    delegateMonitor,
                    nameof(DelegateMonitor.CreateString),
                    false,
                    typeof(Func<>),
                    typeof(string));

                var createStringDelegates = failureCreateStringDelegates
                    .Prepend(successCreateStringDelegate)
                    .Cast<object>()
                    .ToArray();

                var genericMapMethod = voidResultType.GetMethods().Single(method => method.Name == "Map" && method.IsGenericMethod);

                if (genericMapMethod == null)
                {
                    throw new InvalidOperationException("Map method not found");
                }

                var mapMethod = genericMapMethod.MakeGenericMethod(typeof(string));

                var mapResult = mapMethod.Invoke(voidResult, createStringDelegates);

                Assert.AreEqual(isSuccess ? "void" : value?.ToString(), mapResult);

                Assert.AreEqual(1, delegateMonitor.TotalCalls);

                Assert.AreEqual(1, isSuccess ? delegateMonitor.GetCalls() : delegateMonitor.GetCalls(valueType!));
            }
        }

        [Test]
        public void OnlyActionForTheSameIndexedParameterTypeIsCalledOnSwitch()
        {
            foreach (var (voidResult, isSuccess, value, valueType) in AllVoidResultsToTest())
            {
                var voidResultType = voidResult.GetType();

                var delegateMonitor = new DelegateMonitor();

                var failureVoidDelegates = GetFailureTypes(voidResultType)
                    .Select(genericType => DelegateCreator.CreateDelegate(
                        delegateMonitor,
                        nameof(DelegateMonitor.NoOperation),
                        true,
                        typeof(Action<>),
                        genericType));

                var successNoOperationDelegate = DelegateCreator.CreateDelegate(
                    delegateMonitor,
                    nameof(DelegateMonitor.NoOperation),
                    false,
                    typeof(Action));

                var voidDelegates = failureVoidDelegates
                    .Prepend(successNoOperationDelegate)
                    .Cast<object>()
                    .ToArray();

                var switchMethod = voidResultType.GetMethods().Single(method => method.Name == "Switch" && !method.IsGenericMethod);

                if (switchMethod == null)
                {
                    throw new InvalidOperationException("Switch method not found");
                }

                switchMethod.Invoke(voidResult, voidDelegates);

                Assert.AreEqual(1, delegateMonitor.TotalCalls);

                Assert.AreEqual(1, isSuccess ? delegateMonitor.GetCalls() : delegateMonitor.GetCalls(valueType!));
            }
        }

        [Test]
        public void SuccessVoidResultsAreEqualForSameType()
        {
            foreach (var voidResultType in AllVoidResultTypeToTest())
            {
                var firstVoidResult = CreateSuccessVoidResult(voidResultType);
                var secondVoidResult = CreateSuccessVoidResult(voidResultType);

                Assert.IsTrue(firstVoidResult.Equals(secondVoidResult));
                Assert.IsTrue(secondVoidResult.Equals(firstVoidResult));
            }
        }

        [Test]
        public void SuccessVoidResultsAreNotEqualForDifferentTypes()
        {
            foreach (var firstVoidResultType in AllVoidResultTypeToTest())
            {
                var firstVoidResult = CreateSuccessVoidResult(firstVoidResultType);

                foreach (var secondVoidResultType in AllVoidResultTypeToTest().Where(voidResultTypeCandidate => voidResultTypeCandidate != firstVoidResultType))
                {
                    var secondVoidResult = CreateSuccessVoidResult(secondVoidResultType);

                    Assert.IsFalse(firstVoidResult.Equals(secondVoidResult));
                    Assert.IsFalse(secondVoidResult.Equals(firstVoidResult));
                }
            }
        }

        [Test]
        public void SuccessVoidResultsAreNotEqualFailureVoidResults()
        {
            foreach (var voidResultType in AllVoidResultTypeToTest())
            {
                var successVoidResult = CreateSuccessVoidResult(voidResultType);

                foreach (var valueType in GetFailureTypes(voidResultType))
                {
                    foreach (var value in TestData.GetPossibleValues(valueType))
                    {
                        var failureVoidResult = CreateFailureVoidResult(voidResultType, valueType, value);

                        Assert.IsFalse(successVoidResult.Equals(failureVoidResult));
                        Assert.IsFalse(failureVoidResult.Equals(successVoidResult));
                    }
                }
            }
        }

        [Test]
        public void InstancesCreatedWithTheSameFailureInputAreEqual()
        {
            foreach (var voidResultType in AllVoidResultTypeToTest())
            {
                foreach (var valueType in GetFailureTypes(voidResultType))
                {
                    foreach (var value in TestData.GetPossibleValues(valueType))
                    {
                        var firstVoidResult = CreateFailureVoidResult(voidResultType, valueType, value);
                        var secondVoidResult = CreateFailureVoidResult(voidResultType, valueType, value);

                        Assert.IsTrue(firstVoidResult.Equals(secondVoidResult));
                        Assert.IsTrue(secondVoidResult.Equals(firstVoidResult));
                    }
                }
            }
        }

        [Test]
        public void InstancesCreatedWithDifferentFailureInputAreNotEqual()
        {
            foreach (var voidResultType in AllVoidResultTypeToTest())
            {
                foreach (var firstValueType in GetFailureTypes(voidResultType))
                {
                    foreach (var firstValue in TestData.GetPossibleValues(firstValueType))
                    {
                        var firstVoidResult = CreateFailureVoidResult(voidResultType, firstValueType, firstValue);
                        foreach (var secondValueType in GetFailureTypes(voidResultType))
                        {
                            foreach (var secondValue in TestData.GetPossibleValues(secondValueType))
                            {
                                if (firstValueType == secondValueType && Equals(firstValue, secondValue))
                                {
                                    continue;
                                }

                                var secondVoidResult = CreateFailureVoidResult(voidResultType, secondValueType, secondValue);

                                Assert.IsFalse(firstVoidResult.Equals(secondVoidResult));
                                Assert.IsFalse(secondVoidResult.Equals(firstVoidResult));
                            }
                        }
                    }
                }
            }
        }

        [Test]
        public void ToStringUsesUnderlyingValuesToStringMethod()
        {
            foreach (var (voidResult, _, value, _) in AllVoidResultsToTest())
            {
                Assert.AreEqual(value?.ToString() ?? string.Empty, voidResult.ToString());
            }
        }

        private static IEnumerable<(object VoidResult, bool IsSuccess, object? Value, Type? ValueType)> AllVoidResultsToTest()
        {
            foreach (var voidResultType in AllVoidResultTypeToTest())
            {
                var failureTypes = GetFailureTypes(voidResultType);

                foreach (var failureType in failureTypes)
                {
                    foreach (var failureValue in TestData.GetPossibleValues(failureType))
                    {
                        yield return (CreateFailureVoidResult(voidResultType, failureType, failureValue), false, failureValue, failureType);
                    }
                }

                yield return (CreateSuccessVoidResult(voidResultType), true, VoidResult.Success, typeof(VoidResult));
            }
        }

        private static IEnumerable<Type> AllVoidResultTypeToTest()
        {
            for (var numberOfFailureTypes = 1; numberOfFailureTypes <= NumberOfFailureTypesToTestWith; numberOfFailureTypes++)
            {
                foreach (var testTypeSet in TestData.GetTestTypeSets(numberOfFailureTypes))
                {
                    yield return GetVoidResultType(testTypeSet.ToList());
                }
            }
        }

        private static Type GetVoidResultType(ICollection<Type> genericTypesToUse)
        {
            var typeName = $"{nameof(GenericDataStructures)}.VoidResult`{genericTypesToUse.Count}, GenericDataStructures";
            var genericResultType = Type.GetType(typeName);
            if (genericResultType == null)
            {
                throw new InvalidOperationException("VoidResult type not found");
            }

            return genericResultType.MakeGenericType(genericTypesToUse.ToArray());
        }

        private static IEnumerable<Type> GetFailureTypes(Type resultType)
        {
            return resultType.GetGenericArguments();
        }

        private static object CreateSuccessVoidResult(Type resultType)
        {
            var implicitConstructor = resultType.GetMethods()
                .Where(method =>
                {
                    if (method.Name != "op_Implicit")
                    {
                        return false;
                    }

                    var parameters = method.GetParameters();
                    if (parameters.Length != 1)
                    {
                        return false;
                    }

                    return parameters.Single().ParameterType == typeof(VoidResult);
                })
                .SingleOrDefault();

            if (implicitConstructor == null)
            {
                throw new MissingMethodException("An implicit constructor is expected but was not found");
            }

            var voidResult = implicitConstructor.Invoke(null, new object?[] { VoidResult.Success });
            if (voidResult == null)
            {
                throw new InvalidOperationException("The implicit constructor should always construct an object");
            }

            return voidResult;
        }

        private static object CreateFailureVoidResult(Type resultType, Type failureValueType, object? failureValue)
        {
            var constructor = resultType.GetConstructor(new[] { failureValueType });

            if (constructor == null)
            {
                throw new InvalidOperationException("Constructor not found");
            }

            return constructor.Invoke(new[] { failureValue });
        }
    }
}