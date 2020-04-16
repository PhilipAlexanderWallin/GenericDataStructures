using System;
using System.Linq;

namespace GenericDataStructures.Tests
{
    public static class DelegateCreator
    {
        public static Delegate CreateDelegate<TDelegateMethodProvider>(TDelegateMethodProvider delegateMethodProvider, string methodName, bool isGenericMethod, Type genericDelegateType, params Type[] genericTypes)
        {
            var delegateType = genericTypes.Any() ? genericDelegateType.MakeGenericType(genericTypes) : genericDelegateType;
            var possiblyGenericMethod = typeof(TDelegateMethodProvider).GetMethods()
                .SingleOrDefault(method => method.Name == methodName && method.IsGenericMethod == isGenericMethod);
            if (possiblyGenericMethod == null)
            {
                throw new InvalidOperationException($"{methodName} method not found");
            }

            var typesForMethod = genericDelegateType.Name.StartsWith("Func") ? genericTypes.SkipLast(1) : genericTypes;

            var typedMethod = isGenericMethod ? possiblyGenericMethod.MakeGenericMethod(typesForMethod.ToArray()) : possiblyGenericMethod;

            return Delegate.CreateDelegate(delegateType, delegateMethodProvider, typedMethod);
        }
    }
}
