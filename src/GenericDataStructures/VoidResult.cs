#if NULLABLE_REFERENCE_TYPES_SUPPORTED
#nullable disable warnings
#endif
using System;
using JetBrains.Annotations;
using NotNullAttribute = JetBrains.Annotations.NotNullAttribute;

namespace GenericDataStructures
{
    public readonly struct VoidResult<TFailure1>
    {
        public static readonly VoidResult<TFailure1> Success = default(VoidResult<TFailure1>);

        private readonly object _value;
        private readonly byte? _failureTypeIndex;

        public VoidResult(TFailure1 value)
        {
            _value = value;
            _failureTypeIndex = 0;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1>(VoidResult value) => default(VoidResult<TFailure1>);

        public static implicit operator VoidResult<TFailure1>(TFailure1 value) => new VoidResult<TFailure1>(value);

        public static bool operator ==(VoidResult<TFailure1> left, VoidResult<TFailure1> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1> left, VoidResult<TFailure1> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2>
    {
        public static readonly VoidResult<TFailure1, TFailure2> Success = default(VoidResult<TFailure1, TFailure2>);

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

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2>(VoidResult value) => default(VoidResult<TFailure1, TFailure2>);

        public static implicit operator VoidResult<TFailure1, TFailure2>(TFailure1 value) => new VoidResult<TFailure1, TFailure2>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2>(TFailure2 value) => new VoidResult<TFailure1, TFailure2>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2> left, VoidResult<TFailure1, TFailure2> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2> left, VoidResult<TFailure1, TFailure2> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1, TFailure2> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3> Success = default(VoidResult<TFailure1, TFailure2, TFailure3>);

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

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3> left, VoidResult<TFailure1, TFailure2, TFailure3> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3> left, VoidResult<TFailure1, TFailure2, TFailure3> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>);

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

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>);

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

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>);

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

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>);

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

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>);

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

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> right) => !Equals(left, right);

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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public VoidResult(TFailure10 value)
        {
            _value = value;
            _failureTypeIndex = 9;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(TFailure10 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func, [InstantHandle][NotNull]Func<TFailure10, TOutput> onFailure10Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                case 9:
                    if (onFailure10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure10).Name}");
                    }

                    return onFailure10Func((TFailure10)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action, [InstantHandle][NotNull]Action<TFailure10> onFailure10Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
                    break;
                case 9:
                    if (onFailure10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure10).Name}");
                    }

                    onFailure10Action((TFailure10)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public VoidResult(TFailure10 value)
        {
            _value = value;
            _failureTypeIndex = 9;
        }

        public VoidResult(TFailure11 value)
        {
            _value = value;
            _failureTypeIndex = 10;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure10 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(TFailure11 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func, [InstantHandle][NotNull]Func<TFailure10, TOutput> onFailure10Func, [InstantHandle][NotNull]Func<TFailure11, TOutput> onFailure11Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                case 9:
                    if (onFailure10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure10).Name}");
                    }

                    return onFailure10Func((TFailure10)_value);
                case 10:
                    if (onFailure11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure11).Name}");
                    }

                    return onFailure11Func((TFailure11)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action, [InstantHandle][NotNull]Action<TFailure10> onFailure10Action, [InstantHandle][NotNull]Action<TFailure11> onFailure11Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
                    break;
                case 9:
                    if (onFailure10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure10).Name}");
                    }

                    onFailure10Action((TFailure10)_value);
                    break;
                case 10:
                    if (onFailure11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure11).Name}");
                    }

                    onFailure11Action((TFailure11)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public VoidResult(TFailure10 value)
        {
            _value = value;
            _failureTypeIndex = 9;
        }

        public VoidResult(TFailure11 value)
        {
            _value = value;
            _failureTypeIndex = 10;
        }

        public VoidResult(TFailure12 value)
        {
            _value = value;
            _failureTypeIndex = 11;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure10 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure11 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(TFailure12 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func, [InstantHandle][NotNull]Func<TFailure10, TOutput> onFailure10Func, [InstantHandle][NotNull]Func<TFailure11, TOutput> onFailure11Func, [InstantHandle][NotNull]Func<TFailure12, TOutput> onFailure12Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                case 9:
                    if (onFailure10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure10).Name}");
                    }

                    return onFailure10Func((TFailure10)_value);
                case 10:
                    if (onFailure11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure11).Name}");
                    }

                    return onFailure11Func((TFailure11)_value);
                case 11:
                    if (onFailure12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure12).Name}");
                    }

                    return onFailure12Func((TFailure12)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action, [InstantHandle][NotNull]Action<TFailure10> onFailure10Action, [InstantHandle][NotNull]Action<TFailure11> onFailure11Action, [InstantHandle][NotNull]Action<TFailure12> onFailure12Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
                    break;
                case 9:
                    if (onFailure10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure10).Name}");
                    }

                    onFailure10Action((TFailure10)_value);
                    break;
                case 10:
                    if (onFailure11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure11).Name}");
                    }

                    onFailure11Action((TFailure11)_value);
                    break;
                case 11:
                    if (onFailure12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure12).Name}");
                    }

                    onFailure12Action((TFailure12)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public VoidResult(TFailure10 value)
        {
            _value = value;
            _failureTypeIndex = 9;
        }

        public VoidResult(TFailure11 value)
        {
            _value = value;
            _failureTypeIndex = 10;
        }

        public VoidResult(TFailure12 value)
        {
            _value = value;
            _failureTypeIndex = 11;
        }

        public VoidResult(TFailure13 value)
        {
            _value = value;
            _failureTypeIndex = 12;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure10 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure11 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure12 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(TFailure13 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func, [InstantHandle][NotNull]Func<TFailure10, TOutput> onFailure10Func, [InstantHandle][NotNull]Func<TFailure11, TOutput> onFailure11Func, [InstantHandle][NotNull]Func<TFailure12, TOutput> onFailure12Func, [InstantHandle][NotNull]Func<TFailure13, TOutput> onFailure13Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                case 9:
                    if (onFailure10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure10).Name}");
                    }

                    return onFailure10Func((TFailure10)_value);
                case 10:
                    if (onFailure11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure11).Name}");
                    }

                    return onFailure11Func((TFailure11)_value);
                case 11:
                    if (onFailure12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure12).Name}");
                    }

                    return onFailure12Func((TFailure12)_value);
                case 12:
                    if (onFailure13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure13).Name}");
                    }

                    return onFailure13Func((TFailure13)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action, [InstantHandle][NotNull]Action<TFailure10> onFailure10Action, [InstantHandle][NotNull]Action<TFailure11> onFailure11Action, [InstantHandle][NotNull]Action<TFailure12> onFailure12Action, [InstantHandle][NotNull]Action<TFailure13> onFailure13Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
                    break;
                case 9:
                    if (onFailure10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure10).Name}");
                    }

                    onFailure10Action((TFailure10)_value);
                    break;
                case 10:
                    if (onFailure11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure11).Name}");
                    }

                    onFailure11Action((TFailure11)_value);
                    break;
                case 11:
                    if (onFailure12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure12).Name}");
                    }

                    onFailure12Action((TFailure12)_value);
                    break;
                case 12:
                    if (onFailure13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure13).Name}");
                    }

                    onFailure13Action((TFailure13)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public VoidResult(TFailure10 value)
        {
            _value = value;
            _failureTypeIndex = 9;
        }

        public VoidResult(TFailure11 value)
        {
            _value = value;
            _failureTypeIndex = 10;
        }

        public VoidResult(TFailure12 value)
        {
            _value = value;
            _failureTypeIndex = 11;
        }

        public VoidResult(TFailure13 value)
        {
            _value = value;
            _failureTypeIndex = 12;
        }

        public VoidResult(TFailure14 value)
        {
            _value = value;
            _failureTypeIndex = 13;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure10 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure11 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure12 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure13 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(TFailure14 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func, [InstantHandle][NotNull]Func<TFailure10, TOutput> onFailure10Func, [InstantHandle][NotNull]Func<TFailure11, TOutput> onFailure11Func, [InstantHandle][NotNull]Func<TFailure12, TOutput> onFailure12Func, [InstantHandle][NotNull]Func<TFailure13, TOutput> onFailure13Func, [InstantHandle][NotNull]Func<TFailure14, TOutput> onFailure14Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                case 9:
                    if (onFailure10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure10).Name}");
                    }

                    return onFailure10Func((TFailure10)_value);
                case 10:
                    if (onFailure11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure11).Name}");
                    }

                    return onFailure11Func((TFailure11)_value);
                case 11:
                    if (onFailure12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure12).Name}");
                    }

                    return onFailure12Func((TFailure12)_value);
                case 12:
                    if (onFailure13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure13).Name}");
                    }

                    return onFailure13Func((TFailure13)_value);
                case 13:
                    if (onFailure14Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure14).Name}");
                    }

                    return onFailure14Func((TFailure14)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action, [InstantHandle][NotNull]Action<TFailure10> onFailure10Action, [InstantHandle][NotNull]Action<TFailure11> onFailure11Action, [InstantHandle][NotNull]Action<TFailure12> onFailure12Action, [InstantHandle][NotNull]Action<TFailure13> onFailure13Action, [InstantHandle][NotNull]Action<TFailure14> onFailure14Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
                    break;
                case 9:
                    if (onFailure10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure10).Name}");
                    }

                    onFailure10Action((TFailure10)_value);
                    break;
                case 10:
                    if (onFailure11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure11).Name}");
                    }

                    onFailure11Action((TFailure11)_value);
                    break;
                case 11:
                    if (onFailure12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure12).Name}");
                    }

                    onFailure12Action((TFailure12)_value);
                    break;
                case 12:
                    if (onFailure13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure13).Name}");
                    }

                    onFailure13Action((TFailure13)_value);
                    break;
                case 13:
                    if (onFailure14Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure14).Name}");
                    }

                    onFailure14Action((TFailure14)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public VoidResult(TFailure10 value)
        {
            _value = value;
            _failureTypeIndex = 9;
        }

        public VoidResult(TFailure11 value)
        {
            _value = value;
            _failureTypeIndex = 10;
        }

        public VoidResult(TFailure12 value)
        {
            _value = value;
            _failureTypeIndex = 11;
        }

        public VoidResult(TFailure13 value)
        {
            _value = value;
            _failureTypeIndex = 12;
        }

        public VoidResult(TFailure14 value)
        {
            _value = value;
            _failureTypeIndex = 13;
        }

        public VoidResult(TFailure15 value)
        {
            _value = value;
            _failureTypeIndex = 14;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure10 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure11 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure12 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure13 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure14 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(TFailure15 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func, [InstantHandle][NotNull]Func<TFailure10, TOutput> onFailure10Func, [InstantHandle][NotNull]Func<TFailure11, TOutput> onFailure11Func, [InstantHandle][NotNull]Func<TFailure12, TOutput> onFailure12Func, [InstantHandle][NotNull]Func<TFailure13, TOutput> onFailure13Func, [InstantHandle][NotNull]Func<TFailure14, TOutput> onFailure14Func, [InstantHandle][NotNull]Func<TFailure15, TOutput> onFailure15Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                case 9:
                    if (onFailure10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure10).Name}");
                    }

                    return onFailure10Func((TFailure10)_value);
                case 10:
                    if (onFailure11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure11).Name}");
                    }

                    return onFailure11Func((TFailure11)_value);
                case 11:
                    if (onFailure12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure12).Name}");
                    }

                    return onFailure12Func((TFailure12)_value);
                case 12:
                    if (onFailure13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure13).Name}");
                    }

                    return onFailure13Func((TFailure13)_value);
                case 13:
                    if (onFailure14Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure14).Name}");
                    }

                    return onFailure14Func((TFailure14)_value);
                case 14:
                    if (onFailure15Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure15).Name}");
                    }

                    return onFailure15Func((TFailure15)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action, [InstantHandle][NotNull]Action<TFailure10> onFailure10Action, [InstantHandle][NotNull]Action<TFailure11> onFailure11Action, [InstantHandle][NotNull]Action<TFailure12> onFailure12Action, [InstantHandle][NotNull]Action<TFailure13> onFailure13Action, [InstantHandle][NotNull]Action<TFailure14> onFailure14Action, [InstantHandle][NotNull]Action<TFailure15> onFailure15Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
                    break;
                case 9:
                    if (onFailure10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure10).Name}");
                    }

                    onFailure10Action((TFailure10)_value);
                    break;
                case 10:
                    if (onFailure11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure11).Name}");
                    }

                    onFailure11Action((TFailure11)_value);
                    break;
                case 11:
                    if (onFailure12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure12).Name}");
                    }

                    onFailure12Action((TFailure12)_value);
                    break;
                case 12:
                    if (onFailure13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure13).Name}");
                    }

                    onFailure13Action((TFailure13)_value);
                    break;
                case 13:
                    if (onFailure14Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure14).Name}");
                    }

                    onFailure14Action((TFailure14)_value);
                    break;
                case 14:
                    if (onFailure15Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure15).Name}");
                    }

                    onFailure15Action((TFailure15)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public readonly struct VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>
    {
        public static readonly VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16> Success = default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>);

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

        public VoidResult(TFailure9 value)
        {
            _value = value;
            _failureTypeIndex = 8;
        }

        public VoidResult(TFailure10 value)
        {
            _value = value;
            _failureTypeIndex = 9;
        }

        public VoidResult(TFailure11 value)
        {
            _value = value;
            _failureTypeIndex = 10;
        }

        public VoidResult(TFailure12 value)
        {
            _value = value;
            _failureTypeIndex = 11;
        }

        public VoidResult(TFailure13 value)
        {
            _value = value;
            _failureTypeIndex = 12;
        }

        public VoidResult(TFailure14 value)
        {
            _value = value;
            _failureTypeIndex = 13;
        }

        public VoidResult(TFailure15 value)
        {
            _value = value;
            _failureTypeIndex = 14;
        }

        public VoidResult(TFailure16 value)
        {
            _value = value;
            _failureTypeIndex = 15;
        }

        public bool IsSuccess => !_failureTypeIndex.HasValue;

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(VoidResult value) => default(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure1 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure2 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure3 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure4 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure5 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure6 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure7 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure8 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure9 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure10 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure11 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure12 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure13 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure14 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure15 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static implicit operator VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(TFailure16 value) => new VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16>(value);

        public static bool operator ==(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16> right) => Equals(left, right);

        public static bool operator !=(VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16> left, VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<TOutput> onSuccessFunc, [InstantHandle][NotNull]Func<TFailure1, TOutput> onFailure1Func, [InstantHandle][NotNull]Func<TFailure2, TOutput> onFailure2Func, [InstantHandle][NotNull]Func<TFailure3, TOutput> onFailure3Func, [InstantHandle][NotNull]Func<TFailure4, TOutput> onFailure4Func, [InstantHandle][NotNull]Func<TFailure5, TOutput> onFailure5Func, [InstantHandle][NotNull]Func<TFailure6, TOutput> onFailure6Func, [InstantHandle][NotNull]Func<TFailure7, TOutput> onFailure7Func, [InstantHandle][NotNull]Func<TFailure8, TOutput> onFailure8Func, [InstantHandle][NotNull]Func<TFailure9, TOutput> onFailure9Func, [InstantHandle][NotNull]Func<TFailure10, TOutput> onFailure10Func, [InstantHandle][NotNull]Func<TFailure11, TOutput> onFailure11Func, [InstantHandle][NotNull]Func<TFailure12, TOutput> onFailure12Func, [InstantHandle][NotNull]Func<TFailure13, TOutput> onFailure13Func, [InstantHandle][NotNull]Func<TFailure14, TOutput> onFailure14Func, [InstantHandle][NotNull]Func<TFailure15, TOutput> onFailure15Func, [InstantHandle][NotNull]Func<TFailure16, TOutput> onFailure16Func)
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
                case 8:
                    if (onFailure9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure9).Name}");
                    }

                    return onFailure9Func((TFailure9)_value);
                case 9:
                    if (onFailure10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure10).Name}");
                    }

                    return onFailure10Func((TFailure10)_value);
                case 10:
                    if (onFailure11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure11).Name}");
                    }

                    return onFailure11Func((TFailure11)_value);
                case 11:
                    if (onFailure12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure12).Name}");
                    }

                    return onFailure12Func((TFailure12)_value);
                case 12:
                    if (onFailure13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure13).Name}");
                    }

                    return onFailure13Func((TFailure13)_value);
                case 13:
                    if (onFailure14Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure14).Name}");
                    }

                    return onFailure14Func((TFailure14)_value);
                case 14:
                    if (onFailure15Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure15).Name}");
                    }

                    return onFailure15Func((TFailure15)_value);
                case 15:
                    if (onFailure16Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(TFailure16).Name}");
                    }

                    return onFailure16Func((TFailure16)_value);
                default:
                    if (onSuccessFunc == null)
                    {
                        throw new ArgumentException($"No map function provided for success result");
                    }

                    return onSuccessFunc();
            }
        }

        public void Switch([InstantHandle][NotNull]Action onSuccessAction, [InstantHandle][NotNull]Action<TFailure1> onFailure1Action, [InstantHandle][NotNull]Action<TFailure2> onFailure2Action, [InstantHandle][NotNull]Action<TFailure3> onFailure3Action, [InstantHandle][NotNull]Action<TFailure4> onFailure4Action, [InstantHandle][NotNull]Action<TFailure5> onFailure5Action, [InstantHandle][NotNull]Action<TFailure6> onFailure6Action, [InstantHandle][NotNull]Action<TFailure7> onFailure7Action, [InstantHandle][NotNull]Action<TFailure8> onFailure8Action, [InstantHandle][NotNull]Action<TFailure9> onFailure9Action, [InstantHandle][NotNull]Action<TFailure10> onFailure10Action, [InstantHandle][NotNull]Action<TFailure11> onFailure11Action, [InstantHandle][NotNull]Action<TFailure12> onFailure12Action, [InstantHandle][NotNull]Action<TFailure13> onFailure13Action, [InstantHandle][NotNull]Action<TFailure14> onFailure14Action, [InstantHandle][NotNull]Action<TFailure15> onFailure15Action, [InstantHandle][NotNull]Action<TFailure16> onFailure16Action)
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
                case 8:
                    if (onFailure9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure9).Name}");
                    }

                    onFailure9Action((TFailure9)_value);
                    break;
                case 9:
                    if (onFailure10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure10).Name}");
                    }

                    onFailure10Action((TFailure10)_value);
                    break;
                case 10:
                    if (onFailure11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure11).Name}");
                    }

                    onFailure11Action((TFailure11)_value);
                    break;
                case 11:
                    if (onFailure12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure12).Name}");
                    }

                    onFailure12Action((TFailure12)_value);
                    break;
                case 12:
                    if (onFailure13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure13).Name}");
                    }

                    onFailure13Action((TFailure13)_value);
                    break;
                case 13:
                    if (onFailure14Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure14).Name}");
                    }

                    onFailure14Action((TFailure14)_value);
                    break;
                case 14:
                    if (onFailure15Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure15).Name}");
                    }

                    onFailure15Action((TFailure15)_value);
                    break;
                case 15:
                    if (onFailure16Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(TFailure16).Name}");
                    }

                    onFailure16Action((TFailure16)_value);
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
            return obj is VoidResult<TFailure1, TFailure2, TFailure3, TFailure4, TFailure5, TFailure6, TFailure7, TFailure8, TFailure9, TFailure10, TFailure11, TFailure12, TFailure13, TFailure14, TFailure15, TFailure16> other && Equals(_value, other._value) && _failureTypeIndex == other._failureTypeIndex;
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

    public class VoidResult
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
}
