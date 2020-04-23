#if NULLABLE_REFERENCE_TYPES_SUPPORTED
#nullable disable warnings
#endif
using System;
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
using System.Diagnostics.CodeAnalysis;
#endif
using JetBrains.Annotations;
using NotNullAttribute = JetBrains.Annotations.NotNullAttribute;

namespace GenericDataStructures
{
    public sealed class Result<TSuccess, TFailure1>
    {
        private readonly object _value;
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

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Result<TSuccess, TFailure1, TFailure2>
    {
        private readonly object _value;
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

        public Result(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1, TFailure2>(TSuccess value) => new Result<TSuccess, TFailure1, TFailure2>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2>(TFailure1 value) => new Result<TSuccess, TFailure1, TFailure2>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2>(TFailure2 value) => new Result<TSuccess, TFailure1, TFailure2>(value);

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                case 1: return onFailure2Func((TFailure2)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                case 1: onFailure2Action((TFailure2)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1, TFailure2> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Result<TSuccess, TFailure1, TFailure2, TFailure3>
    {
        private readonly object _value;
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

        public Result(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public Result(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3>(TSuccess value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3>(TFailure1 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3>(TFailure2 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3>(TFailure3 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3>(value);

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                case 1: return onFailure2Func((TFailure2)_value);
                case 2: return onFailure3Func((TFailure3)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                case 1: onFailure2Action((TFailure2)_value); break;
                case 2: onFailure3Action((TFailure3)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1, TFailure2, TFailure3> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>
    {
        private readonly object _value;
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

        public Result(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public Result(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public Result(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(TSuccess value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(TFailure1 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(TFailure2 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(TFailure3 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(TFailure4 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4>(value);

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                case 1: return onFailure2Func((TFailure2)_value);
                case 2: return onFailure3Func((TFailure3)_value);
                case 3: return onFailure4Func((TFailure4)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                case 1: onFailure2Action((TFailure2)_value); break;
                case 2: onFailure3Action((TFailure3)_value); break;
                case 3: onFailure4Action((TFailure4)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>
    {
        private readonly object _value;
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

        public Result(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public Result(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public Result(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public Result(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TSuccess value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure1 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure2 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure3 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure4 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure5 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                case 1: return onFailure2Func((TFailure2)_value);
                case 2: return onFailure3Func((TFailure3)_value);
                case 3: return onFailure4Func((TFailure4)_value);
                case 4: return onFailure5Func((TFailure5)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                case 1: onFailure2Action((TFailure2)_value); break;
                case 2: onFailure3Action((TFailure3)_value); break;
                case 3: onFailure4Action((TFailure4)_value); break;
                case 4: onFailure5Action((TFailure5)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>
    {
        private readonly object _value;
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

        public Result(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public Result(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public Result(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public Result(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        public Result(TFailure6 value)
        {
            _value = value;
            _failureTypeIndex = 5;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TSuccess value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure1 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure2 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure3 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure4 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure5 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure6 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                case 1: return onFailure2Func((TFailure2)_value);
                case 2: return onFailure3Func((TFailure3)_value);
                case 3: return onFailure4Func((TFailure4)_value);
                case 4: return onFailure5Func((TFailure5)_value);
                case 5: return onFailure6Func((TFailure6)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                case 1: onFailure2Action((TFailure2)_value); break;
                case 2: onFailure3Action((TFailure3)_value); break;
                case 3: onFailure4Action((TFailure4)_value); break;
                case 4: onFailure5Action((TFailure5)_value); break;
                case 5: onFailure6Action((TFailure6)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>
    {
        private readonly object _value;
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

        public Result(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public Result(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public Result(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public Result(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        public Result(TFailure6 value)
        {
            _value = value;
            _failureTypeIndex = 5;
        }

        public Result(TFailure7 value)
        {
            _value = value;
            _failureTypeIndex = 6;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TSuccess value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure1 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure2 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure3 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure4 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure5 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure6 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure7 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                case 1: return onFailure2Func((TFailure2)_value);
                case 2: return onFailure3Func((TFailure3)_value);
                case 3: return onFailure4Func((TFailure4)_value);
                case 4: return onFailure5Func((TFailure5)_value);
                case 5: return onFailure6Func((TFailure6)_value);
                case 6: return onFailure7Func((TFailure7)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                case 1: onFailure2Action((TFailure2)_value); break;
                case 2: onFailure3Action((TFailure3)_value); break;
                case 3: onFailure4Action((TFailure4)_value); break;
                case 4: onFailure5Action((TFailure5)_value); break;
                case 5: onFailure6Action((TFailure6)_value); break;
                case 6: onFailure7Action((TFailure7)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>
    {
        private readonly object _value;
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

        public Result(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public Result(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public Result(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public Result(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        public Result(TFailure6 value)
        {
            _value = value;
            _failureTypeIndex = 5;
        }

        public Result(TFailure7 value)
        {
            _value = value;
            _failureTypeIndex = 6;
        }

        public Result(TFailure8 value)
        {
            _value = value;
            _failureTypeIndex = 7;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TSuccess value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure1 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure2 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure3 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure4 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure5 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure6 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure7 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure8 value) => new Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryGetSuccessValue([MaybeNullWhen(false)] out TSuccess successValue)
#else
        public bool TryGetSuccessValue(out TSuccess successValue)
#endif
        {
            if (IsSuccess)
            {
                successValue = (TSuccess)_value;
                return true;
            }

            successValue = default(TSuccess);
            return false;
        }

#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [MaybeNullWhen(false)] out TOutput mappedValue)
#else
        public bool TryMap<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, out TOutput mappedValue)
#endif
        {
            if (IsSuccess)
            {
                mappedValue = onSuccessFunc((TSuccess)_value);
                return true;
            }

            mappedValue = default(TOutput);
            return false;
        }

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TSuccess, TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func)
        {
            switch (_failureTypeIndex)
            {
                case 0: return onFailure1Func((TFailure1)_value);
                case 1: return onFailure2Func((TFailure2)_value);
                case 2: return onFailure3Func((TFailure3)_value);
                case 3: return onFailure4Func((TFailure4)_value);
                case 4: return onFailure5Func((TFailure5)_value);
                case 5: return onFailure6Func((TFailure6)_value);
                case 6: return onFailure7Func((TFailure7)_value);
                case 7: return onFailure8Func((TFailure8)_value);
                default: return onSuccessFunc((TSuccess)_value);
            }
        }

        public void Switch([InstantHandle][NotNull]Action<TSuccess> onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action)
        {
            switch (_failureTypeIndex)
            {
                case 0: onFailure1Action((TFailure1)_value); break;
                case 1: onFailure2Action((TFailure2)_value); break;
                case 2: onFailure3Action((TFailure3)_value); break;
                case 3: onFailure4Action((TFailure4)_value); break;
                case 4: onFailure5Action((TFailure5)_value); break;
                case 5: onFailure6Action((TFailure6)_value); break;
                case 6: onFailure7Action((TFailure7)_value); break;
                case 7: onFailure8Action((TFailure8)_value); break;
                default: onSuccessAction((TSuccess)_value); break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Result<TSuccess, TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _failureTypeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }
}
