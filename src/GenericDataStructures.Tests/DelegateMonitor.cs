using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericDataStructures.Tests
{
    public class DelegateMonitor
    {
        private readonly Dictionary<Type, int> _delegateTypeCalls = new Dictionary<Type, int>();

        private int _untypedCalls = 0;

        public int TotalCalls => _delegateTypeCalls.Values.Sum() + _untypedCalls;

        public int GetCalls(Type type)
        {
            if (_delegateTypeCalls.TryGetValue(type, out var calls))
            {
                return calls;
            }
            else
            {
                return 0;
            }
        }

        public int GetCalls()
        {
            return _untypedCalls;
        }

        public string? CreateString<T>(T @object)
        {
            AddTypeCall<T>();
            return @object?.ToString();
        }

        public string? CreateString()
        {
            _untypedCalls++;
            return "void";
        }

        public void NoOperation<T>(T @object)
        {
            AddTypeCall<T>();
        }

        public void NoOperation()
        {
            _untypedCalls++;
        }

        private void AddTypeCall<T>()
        {
            var typeToAdd = typeof(T);
            if (!_delegateTypeCalls.ContainsKey(typeToAdd))
            {
                _delegateTypeCalls.Add(typeToAdd, 0);
            }

            _delegateTypeCalls[typeToAdd]++;
        }
    }
}