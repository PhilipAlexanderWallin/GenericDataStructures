#if NULLABLE_REFERENCE_TYPES_SUPPORTED
#nullable disable warnings
#endif
using System;
using JetBrains.Annotations;
using NotNullAttribute = JetBrains.Annotations.NotNullAttribute;

namespace GenericDataStructures
{
    public sealed class Union<T1>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public static implicit operator Union<T1>(T1 value) => new Union<T1>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Union<T1, T2>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public Union(T2 value)
        {
            _value = value;
            _typeIndex = 1;
        }

        public static implicit operator Union<T1, T2>(T1 value) => new Union<T1, T2>(value);

        public static implicit operator Union<T1, T2>(T2 value) => new Union<T1, T2>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1, T2> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Union<T1, T2, T3>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public Union(T2 value)
        {
            _value = value;
            _typeIndex = 1;
        }

        public Union(T3 value)
        {
            _value = value;
            _typeIndex = 2;
        }

        public static implicit operator Union<T1, T2, T3>(T1 value) => new Union<T1, T2, T3>(value);

        public static implicit operator Union<T1, T2, T3>(T2 value) => new Union<T1, T2, T3>(value);

        public static implicit operator Union<T1, T2, T3>(T3 value) => new Union<T1, T2, T3>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)_value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)_value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1, T2, T3> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Union<T1, T2, T3, T4>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public Union(T2 value)
        {
            _value = value;
            _typeIndex = 1;
        }

        public Union(T3 value)
        {
            _value = value;
            _typeIndex = 2;
        }

        public Union(T4 value)
        {
            _value = value;
            _typeIndex = 3;
        }

        public static implicit operator Union<T1, T2, T3, T4>(T1 value) => new Union<T1, T2, T3, T4>(value);

        public static implicit operator Union<T1, T2, T3, T4>(T2 value) => new Union<T1, T2, T3, T4>(value);

        public static implicit operator Union<T1, T2, T3, T4>(T3 value) => new Union<T1, T2, T3, T4>(value);

        public static implicit operator Union<T1, T2, T3, T4>(T4 value) => new Union<T1, T2, T3, T4>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)_value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)_value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)_value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)_value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1, T2, T3, T4> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Union<T1, T2, T3, T4, T5>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public Union(T2 value)
        {
            _value = value;
            _typeIndex = 1;
        }

        public Union(T3 value)
        {
            _value = value;
            _typeIndex = 2;
        }

        public Union(T4 value)
        {
            _value = value;
            _typeIndex = 3;
        }

        public Union(T5 value)
        {
            _value = value;
            _typeIndex = 4;
        }

        public static implicit operator Union<T1, T2, T3, T4, T5>(T1 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T2 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T3 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T4 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T5 value) => new Union<T1, T2, T3, T4, T5>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)_value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)_value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)_value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)_value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)_value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)_value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1, T2, T3, T4, T5> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Union<T1, T2, T3, T4, T5, T6>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public Union(T2 value)
        {
            _value = value;
            _typeIndex = 1;
        }

        public Union(T3 value)
        {
            _value = value;
            _typeIndex = 2;
        }

        public Union(T4 value)
        {
            _value = value;
            _typeIndex = 3;
        }

        public Union(T5 value)
        {
            _value = value;
            _typeIndex = 4;
        }

        public Union(T6 value)
        {
            _value = value;
            _typeIndex = 5;
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T1 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T2 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T3 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T4 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T5 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T6 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)_value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)_value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)_value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)_value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)_value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)_value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)_value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)_value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1, T2, T3, T4, T5, T6> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Union<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public Union(T2 value)
        {
            _value = value;
            _typeIndex = 1;
        }

        public Union(T3 value)
        {
            _value = value;
            _typeIndex = 2;
        }

        public Union(T4 value)
        {
            _value = value;
            _typeIndex = 3;
        }

        public Union(T5 value)
        {
            _value = value;
            _typeIndex = 4;
        }

        public Union(T6 value)
        {
            _value = value;
            _typeIndex = 5;
        }

        public Union(T7 value)
        {
            _value = value;
            _typeIndex = 6;
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)_value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)_value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)_value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)_value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)_value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)_value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)_value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)_value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)_value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)_value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1, T2, T3, T4, T5, T6, T7> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }

    public sealed class Union<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly object _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public Union(T2 value)
        {
            _value = value;
            _typeIndex = 1;
        }

        public Union(T3 value)
        {
            _value = value;
            _typeIndex = 2;
        }

        public Union(T4 value)
        {
            _value = value;
            _typeIndex = 3;
        }

        public Union(T5 value)
        {
            _value = value;
            _typeIndex = 4;
        }

        public Union(T6 value)
        {
            _value = value;
            _typeIndex = 5;
        }

        public Union(T7 value)
        {
            _value = value;
            _typeIndex = 6;
        }

        public Union(T8 value)
        {
            _value = value;
            _typeIndex = 7;
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)_value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)_value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)_value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)_value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)_value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)_value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)_value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)_value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)_value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)_value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)_value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)_value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)_value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)_value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)_value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)_value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Union<T1, T2, T3, T4, T5, T6, T7, T8> other && Equals(_value, other._value) && _typeIndex == other._typeIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }
}
