#if NULLABLE_REFERENCE_TYPES_SUPPORTED
#nullable disable warnings
#endif
using System;
using JetBrains.Annotations;
using NotNullAttribute = JetBrains.Annotations.NotNullAttribute;

namespace GenericDataStructures
{
    public sealed class VoidResult
    {
        public static readonly VoidResult Success = new VoidResult();

        private VoidResult()
        {
        }

        public override string ToString()
        {
            return "GenericDataStructures.VoidResult.Success";
        }
    }

    public class VoidResult<TFailure1>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1>(VoidResult value) => new VoidResult<TFailure1>(value);

        public static implicit operator VoidResult<TFailure1>(TFailure1 value) => new VoidResult<TFailure1>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }

    public class VoidResult<TFailure1, TFailure2>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public VoidResult(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2>(VoidResult value) => new VoidResult<TFailure1, TFailure2>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2>(TFailure1 value) => new VoidResult<TFailure1, TFailure2>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2>(TFailure2 value) => new VoidResult<TFailure1, TFailure2>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                case 1:
                    if (onFailure2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure2).Name}");
                    }

                    return onFailure2Func((TFailure2)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                case 1:
                    if (onFailure2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure2).Name}");
                    }

                    onFailure2Action((TFailure2)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1, TFailure2> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }

    public class VoidResult<TFailure1, TFailure2, TFailure3>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public VoidResult(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public VoidResult(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(VoidResult value) => new VoidResult<TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                case 1:
                    if (onFailure2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure2).Name}");
                    }

                    return onFailure2Func((TFailure2)_value);
                case 2:
                    if (onFailure3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure3).Name}");
                    }

                    return onFailure3Func((TFailure3)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                case 1:
                    if (onFailure2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure2).Name}");
                    }

                    onFailure2Action((TFailure2)_value);
                    break;
                case 2:
                    if (onFailure3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure3).Name}");
                    }

                    onFailure3Action((TFailure3)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1, TFailure2, TFailure3> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }

    public class VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public VoidResult(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public VoidResult(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public VoidResult(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(VoidResult value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                case 1:
                    if (onFailure2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure2).Name}");
                    }

                    return onFailure2Func((TFailure2)_value);
                case 2:
                    if (onFailure3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure3).Name}");
                    }

                    return onFailure3Func((TFailure3)_value);
                case 3:
                    if (onFailure4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure4).Name}");
                    }

                    return onFailure4Func((TFailure4)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                case 1:
                    if (onFailure2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure2).Name}");
                    }

                    onFailure2Action((TFailure2)_value);
                    break;
                case 2:
                    if (onFailure3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure3).Name}");
                    }

                    onFailure3Action((TFailure3)_value);
                    break;
                case 3:
                    if (onFailure4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure4).Name}");
                    }

                    onFailure4Action((TFailure4)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }

    public class VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public VoidResult(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public VoidResult(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public VoidResult(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public VoidResult(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(VoidResult value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                case 1:
                    if (onFailure2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure2).Name}");
                    }

                    return onFailure2Func((TFailure2)_value);
                case 2:
                    if (onFailure3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure3).Name}");
                    }

                    return onFailure3Func((TFailure3)_value);
                case 3:
                    if (onFailure4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure4).Name}");
                    }

                    return onFailure4Func((TFailure4)_value);
                case 4:
                    if (onFailure5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure5).Name}");
                    }

                    return onFailure5Func((TFailure5)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                case 1:
                    if (onFailure2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure2).Name}");
                    }

                    onFailure2Action((TFailure2)_value);
                    break;
                case 2:
                    if (onFailure3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure3).Name}");
                    }

                    onFailure3Action((TFailure3)_value);
                    break;
                case 3:
                    if (onFailure4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure4).Name}");
                    }

                    onFailure4Action((TFailure4)_value);
                    break;
                case 4:
                    if (onFailure5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure5).Name}");
                    }

                    onFailure5Action((TFailure5)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }

    public class VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public VoidResult(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public VoidResult(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public VoidResult(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public VoidResult(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        public VoidResult(TFailure6 value)
        {
            _value = value;
            _failureTypeIndex = 5;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(VoidResult value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                case 1:
                    if (onFailure2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure2).Name}");
                    }

                    return onFailure2Func((TFailure2)_value);
                case 2:
                    if (onFailure3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure3).Name}");
                    }

                    return onFailure3Func((TFailure3)_value);
                case 3:
                    if (onFailure4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure4).Name}");
                    }

                    return onFailure4Func((TFailure4)_value);
                case 4:
                    if (onFailure5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure5).Name}");
                    }

                    return onFailure5Func((TFailure5)_value);
                case 5:
                    if (onFailure6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure6).Name}");
                    }

                    return onFailure6Func((TFailure6)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                case 1:
                    if (onFailure2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure2).Name}");
                    }

                    onFailure2Action((TFailure2)_value);
                    break;
                case 2:
                    if (onFailure3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure3).Name}");
                    }

                    onFailure3Action((TFailure3)_value);
                    break;
                case 3:
                    if (onFailure4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure4).Name}");
                    }

                    onFailure4Action((TFailure4)_value);
                    break;
                case 4:
                    if (onFailure5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure5).Name}");
                    }

                    onFailure5Action((TFailure5)_value);
                    break;
                case 5:
                    if (onFailure6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure6).Name}");
                    }

                    onFailure6Action((TFailure6)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }

    public class VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public VoidResult(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public VoidResult(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public VoidResult(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public VoidResult(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        public VoidResult(TFailure6 value)
        {
            _value = value;
            _failureTypeIndex = 5;
        }

        public VoidResult(TFailure7 value)
        {
            _value = value;
            _failureTypeIndex = 6;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(VoidResult value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                case 1:
                    if (onFailure2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure2).Name}");
                    }

                    return onFailure2Func((TFailure2)_value);
                case 2:
                    if (onFailure3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure3).Name}");
                    }

                    return onFailure3Func((TFailure3)_value);
                case 3:
                    if (onFailure4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure4).Name}");
                    }

                    return onFailure4Func((TFailure4)_value);
                case 4:
                    if (onFailure5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure5).Name}");
                    }

                    return onFailure5Func((TFailure5)_value);
                case 5:
                    if (onFailure6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure6).Name}");
                    }

                    return onFailure6Func((TFailure6)_value);
                case 6:
                    if (onFailure7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure7).Name}");
                    }

                    return onFailure7Func((TFailure7)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                case 1:
                    if (onFailure2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure2).Name}");
                    }

                    onFailure2Action((TFailure2)_value);
                    break;
                case 2:
                    if (onFailure3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure3).Name}");
                    }

                    onFailure3Action((TFailure3)_value);
                    break;
                case 3:
                    if (onFailure4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure4).Name}");
                    }

                    onFailure4Action((TFailure4)_value);
                    break;
                case 4:
                    if (onFailure5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure5).Name}");
                    }

                    onFailure5Action((TFailure5)_value);
                    break;
                case 5:
                    if (onFailure6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure6).Name}");
                    }

                    onFailure6Action((TFailure6)_value);
                    break;
                case 6:
                    if (onFailure7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure7).Name}");
                    }

                    onFailure7Action((TFailure7)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }

    public class VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>
    {
        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public VoidResult(TFailure2 value)
        {
            _value = value;
            _failureTypeIndex = 1;
        }

        public VoidResult(TFailure3 value)
        {
            _value = value;
            _failureTypeIndex = 2;
        }

        public VoidResult(TFailure4 value)
        {
            _value = value;
            _failureTypeIndex = 3;
        }

        public VoidResult(TFailure5 value)
        {
            _value = value;
            _failureTypeIndex = 4;
        }

        public VoidResult(TFailure6 value)
        {
            _value = value;
            _failureTypeIndex = 5;
        }

        public VoidResult(TFailure7 value)
        {
            _value = value;
            _failureTypeIndex = 6;
        }

        public VoidResult(TFailure8 value)
        {
            _value = value;
            _failureTypeIndex = 7;
        }

        private VoidResult(VoidResult value)
        {
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(VoidResult value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure1).Name}");
                    }

                    return onFailure1Func((TFailure1)_value);
                case 1:
                    if (onFailure2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure2).Name}");
                    }

                    return onFailure2Func((TFailure2)_value);
                case 2:
                    if (onFailure3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure3).Name}");
                    }

                    return onFailure3Func((TFailure3)_value);
                case 3:
                    if (onFailure4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure4).Name}");
                    }

                    return onFailure4Func((TFailure4)_value);
                case 4:
                    if (onFailure5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure5).Name}");
                    }

                    return onFailure5Func((TFailure5)_value);
                case 5:
                    if (onFailure6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure6).Name}");
                    }

                    return onFailure6Func((TFailure6)_value);
                case 6:
                    if (onFailure7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure7).Name}");
                    }

                    return onFailure7Func((TFailure7)_value);
                case 7:
                    if (onFailure8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure8).Name}");
                    }

                    return onFailure8Func((TFailure8)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action)
        {
            switch (_failureTypeIndex)
            {
                case 0:
                    if (onFailure1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure1).Name}");
                    }

                    onFailure1Action((TFailure1)_value);
                    break;
                case 1:
                    if (onFailure2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure2).Name}");
                    }

                    onFailure2Action((TFailure2)_value);
                    break;
                case 2:
                    if (onFailure3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure3).Name}");
                    }

                    onFailure3Action((TFailure3)_value);
                    break;
                case 3:
                    if (onFailure4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure4).Name}");
                    }

                    onFailure4Action((TFailure4)_value);
                    break;
                case 4:
                    if (onFailure5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure5).Name}");
                    }

                    onFailure5Action((TFailure5)_value);
                    break;
                case 5:
                    if (onFailure6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure6).Name}");
                    }

                    onFailure6Action((TFailure6)_value);
                    break;
                case 6:
                    if (onFailure7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure7).Name}");
                    }

                    onFailure7Action((TFailure7)_value);
                    break;
                case 7:
                    if (onFailure8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure8).Name}");
                    }

                    onFailure8Action((TFailure8)_value);
                    break;
                default:
                    if (onSuccessAction == null)
                    {
                        throw new ArgumentException($"No switch action provided for success result");
                    }

                    onSuccessAction();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex);
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
            return _failureTypeIndex != null ? (_value != null ? _value.ToString() : string.Empty) : VoidResult.Success.ToString();
        }
    }
}
