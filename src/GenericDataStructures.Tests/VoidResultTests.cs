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

                Assert.AreEqual(mapResult, isSuccess ? "void" : value?.ToString());

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

                yield return (CreateSuccessVoidResult(voidResultType), true, null, null);
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