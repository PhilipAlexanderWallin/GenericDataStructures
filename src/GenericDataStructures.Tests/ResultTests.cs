using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GenericDataStructures.Tests
{
    public class ResultTests
    {
        private const int NumberOfSupportedFailureTypes = 1;

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

        private static void ForEachResultTypeToTest(Action<Type> action)
        {
            for (var numberOfFailureTypes = 1; numberOfFailureTypes <= NumberOfSupportedFailureTypes; numberOfFailureTypes++)
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