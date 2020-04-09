using System;

namespace GenericDataStructures
{
    public class Result<TSuccess, TFailure1>
    {
        private readonly object? _value;
        private readonly byte? _failureTypeIndex;

        public Result(TSuccess value)
        {
            _value = value;
        }

        public Result(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1>(TSuccess value) => new Result<TSuccess, TFailure1>(value);

        public static implicit operator Result<TSuccess, TFailure1>(TFailure1 value) => new Result<TSuccess, TFailure1>(value);

        public void OnSuccess(Action<TSuccess> action)
        {
            if (IsSuccess)
            {
                action((TSuccess)_value!);
            }
        }

        public TOutput Match<TOutput>(
            Func<TSuccess, TOutput> onSuccessFunc,
            Func<TFailure1, TOutput> onFailure1Func)
        {
            return _failureTypeIndex switch
            {
                0 => onFailure1Func((TFailure1)_value!),
                _ => onSuccessFunc((TSuccess)_value!)
            };
        }
    }
}