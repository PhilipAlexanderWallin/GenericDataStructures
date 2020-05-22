#if NULLABLE_REFERENCE_TYPES_SUPPORTED
#nullable disable warnings
#endif
using System;
using JetBrains.Annotations;
using NotNullAttribute = JetBrains.Annotations.NotNullAttribute;

namespace GenericDataStructures
{
    public readonly struct Union<T1>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1>(T1 value) => new Union<T1>(value);

        public static bool operator ==(Union<T1> left, Union<T1> right) => Equals(left, right);

        public static bool operator !=(Union<T1> left, Union<T1> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
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

                    onT1Action((T1)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2>(T1 value) => new Union<T1, T2>(value);

        public static implicit operator Union<T1, T2>(T2 value) => new Union<T1, T2>(value);

        public static bool operator ==(Union<T1, T2> left, Union<T1, T2> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2> left, Union<T1, T2> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
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

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3>(T1 value) => new Union<T1, T2, T3>(value);

        public static implicit operator Union<T1, T2, T3>(T2 value) => new Union<T1, T2, T3>(value);

        public static implicit operator Union<T1, T2, T3>(T3 value) => new Union<T1, T2, T3>(value);

        public static bool operator ==(Union<T1, T2, T3> left, Union<T1, T2, T3> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3> left, Union<T1, T2, T3> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
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

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4>(T1 value) => new Union<T1, T2, T3, T4>(value);

        public static implicit operator Union<T1, T2, T3, T4>(T2 value) => new Union<T1, T2, T3, T4>(value);

        public static implicit operator Union<T1, T2, T3, T4>(T3 value) => new Union<T1, T2, T3, T4>(value);

        public static implicit operator Union<T1, T2, T3, T4>(T4 value) => new Union<T1, T2, T3, T4>(value);

        public static bool operator ==(Union<T1, T2, T3, T4> left, Union<T1, T2, T3, T4> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4> left, Union<T1, T2, T3, T4> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
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

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5>(T1 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T2 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T3 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T4 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5>(T5 value) => new Union<T1, T2, T3, T4, T5>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5> left, Union<T1, T2, T3, T4, T5> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5> left, Union<T1, T2, T3, T4, T5> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
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

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T1 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T2 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T3 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T4 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T5 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T6 value) => new Union<T1, T2, T3, T4, T5, T6>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6> left, Union<T1, T2, T3, T4, T5, T6> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6> left, Union<T1, T2, T3, T4, T5, T6> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
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

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7> left, Union<T1, T2, T3, T4, T5, T6, T7> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7> left, Union<T1, T2, T3, T4, T5, T6, T7> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
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

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8> left, Union<T1, T2, T3, T4, T5, T6, T7, T8> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8> left, Union<T1, T2, T3, T4, T5, T6, T7, T8> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
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

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        public Union(T10 value)
        {
            _value = value;
            _typeIndex = 9;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    case 9:
                        return _value ?? default(T10);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func, [InstantHandle][NotNull]Func<T10, TOutput> onT10Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                case 9:
                    if (onT10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T10).Name}");
                    }

                    return onT10Func((T10)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action, [InstantHandle][NotNull]Action<T10> onT10Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                case 9:
                    if (onT10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T10).Name}");
                    }

                    onT10Action((T10)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        public Union(T10 value)
        {
            _value = value;
            _typeIndex = 9;
        }

        public Union(T11 value)
        {
            _value = value;
            _typeIndex = 10;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    case 9:
                        return _value ?? default(T10);
                    case 10:
                        return _value ?? default(T11);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T10 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T11 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func, [InstantHandle][NotNull]Func<T10, TOutput> onT10Func, [InstantHandle][NotNull]Func<T11, TOutput> onT11Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                case 9:
                    if (onT10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T10).Name}");
                    }

                    return onT10Func((T10)Value);
                case 10:
                    if (onT11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T11).Name}");
                    }

                    return onT11Func((T11)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action, [InstantHandle][NotNull]Action<T10> onT10Action, [InstantHandle][NotNull]Action<T11> onT11Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                case 9:
                    if (onT10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T10).Name}");
                    }

                    onT10Action((T10)Value);
                    break;
                case 10:
                    if (onT11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T11).Name}");
                    }

                    onT11Action((T11)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        public Union(T10 value)
        {
            _value = value;
            _typeIndex = 9;
        }

        public Union(T11 value)
        {
            _value = value;
            _typeIndex = 10;
        }

        public Union(T12 value)
        {
            _value = value;
            _typeIndex = 11;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    case 9:
                        return _value ?? default(T10);
                    case 10:
                        return _value ?? default(T11);
                    case 11:
                        return _value ?? default(T12);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T10 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T11 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T12 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func, [InstantHandle][NotNull]Func<T10, TOutput> onT10Func, [InstantHandle][NotNull]Func<T11, TOutput> onT11Func, [InstantHandle][NotNull]Func<T12, TOutput> onT12Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                case 9:
                    if (onT10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T10).Name}");
                    }

                    return onT10Func((T10)Value);
                case 10:
                    if (onT11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T11).Name}");
                    }

                    return onT11Func((T11)Value);
                case 11:
                    if (onT12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T12).Name}");
                    }

                    return onT12Func((T12)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action, [InstantHandle][NotNull]Action<T10> onT10Action, [InstantHandle][NotNull]Action<T11> onT11Action, [InstantHandle][NotNull]Action<T12> onT12Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                case 9:
                    if (onT10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T10).Name}");
                    }

                    onT10Action((T10)Value);
                    break;
                case 10:
                    if (onT11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T11).Name}");
                    }

                    onT11Action((T11)Value);
                    break;
                case 11:
                    if (onT12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T12).Name}");
                    }

                    onT12Action((T12)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        public Union(T10 value)
        {
            _value = value;
            _typeIndex = 9;
        }

        public Union(T11 value)
        {
            _value = value;
            _typeIndex = 10;
        }

        public Union(T12 value)
        {
            _value = value;
            _typeIndex = 11;
        }

        public Union(T13 value)
        {
            _value = value;
            _typeIndex = 12;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    case 9:
                        return _value ?? default(T10);
                    case 10:
                        return _value ?? default(T11);
                    case 11:
                        return _value ?? default(T12);
                    case 12:
                        return _value ?? default(T13);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T10 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T11 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T12 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T13 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func, [InstantHandle][NotNull]Func<T10, TOutput> onT10Func, [InstantHandle][NotNull]Func<T11, TOutput> onT11Func, [InstantHandle][NotNull]Func<T12, TOutput> onT12Func, [InstantHandle][NotNull]Func<T13, TOutput> onT13Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                case 9:
                    if (onT10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T10).Name}");
                    }

                    return onT10Func((T10)Value);
                case 10:
                    if (onT11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T11).Name}");
                    }

                    return onT11Func((T11)Value);
                case 11:
                    if (onT12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T12).Name}");
                    }

                    return onT12Func((T12)Value);
                case 12:
                    if (onT13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T13).Name}");
                    }

                    return onT13Func((T13)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action, [InstantHandle][NotNull]Action<T10> onT10Action, [InstantHandle][NotNull]Action<T11> onT11Action, [InstantHandle][NotNull]Action<T12> onT12Action, [InstantHandle][NotNull]Action<T13> onT13Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                case 9:
                    if (onT10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T10).Name}");
                    }

                    onT10Action((T10)Value);
                    break;
                case 10:
                    if (onT11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T11).Name}");
                    }

                    onT11Action((T11)Value);
                    break;
                case 11:
                    if (onT12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T12).Name}");
                    }

                    onT12Action((T12)Value);
                    break;
                case 12:
                    if (onT13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T13).Name}");
                    }

                    onT13Action((T13)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        public Union(T10 value)
        {
            _value = value;
            _typeIndex = 9;
        }

        public Union(T11 value)
        {
            _value = value;
            _typeIndex = 10;
        }

        public Union(T12 value)
        {
            _value = value;
            _typeIndex = 11;
        }

        public Union(T13 value)
        {
            _value = value;
            _typeIndex = 12;
        }

        public Union(T14 value)
        {
            _value = value;
            _typeIndex = 13;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    case 9:
                        return _value ?? default(T10);
                    case 10:
                        return _value ?? default(T11);
                    case 11:
                        return _value ?? default(T12);
                    case 12:
                        return _value ?? default(T13);
                    case 13:
                        return _value ?? default(T14);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T10 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T11 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T12 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T13 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T14 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func, [InstantHandle][NotNull]Func<T10, TOutput> onT10Func, [InstantHandle][NotNull]Func<T11, TOutput> onT11Func, [InstantHandle][NotNull]Func<T12, TOutput> onT12Func, [InstantHandle][NotNull]Func<T13, TOutput> onT13Func, [InstantHandle][NotNull]Func<T14, TOutput> onT14Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                case 9:
                    if (onT10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T10).Name}");
                    }

                    return onT10Func((T10)Value);
                case 10:
                    if (onT11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T11).Name}");
                    }

                    return onT11Func((T11)Value);
                case 11:
                    if (onT12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T12).Name}");
                    }

                    return onT12Func((T12)Value);
                case 12:
                    if (onT13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T13).Name}");
                    }

                    return onT13Func((T13)Value);
                case 13:
                    if (onT14Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T14).Name}");
                    }

                    return onT14Func((T14)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action, [InstantHandle][NotNull]Action<T10> onT10Action, [InstantHandle][NotNull]Action<T11> onT11Action, [InstantHandle][NotNull]Action<T12> onT12Action, [InstantHandle][NotNull]Action<T13> onT13Action, [InstantHandle][NotNull]Action<T14> onT14Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                case 9:
                    if (onT10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T10).Name}");
                    }

                    onT10Action((T10)Value);
                    break;
                case 10:
                    if (onT11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T11).Name}");
                    }

                    onT11Action((T11)Value);
                    break;
                case 11:
                    if (onT12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T12).Name}");
                    }

                    onT12Action((T12)Value);
                    break;
                case 12:
                    if (onT13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T13).Name}");
                    }

                    onT13Action((T13)Value);
                    break;
                case 13:
                    if (onT14Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T14).Name}");
                    }

                    onT14Action((T14)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        public Union(T10 value)
        {
            _value = value;
            _typeIndex = 9;
        }

        public Union(T11 value)
        {
            _value = value;
            _typeIndex = 10;
        }

        public Union(T12 value)
        {
            _value = value;
            _typeIndex = 11;
        }

        public Union(T13 value)
        {
            _value = value;
            _typeIndex = 12;
        }

        public Union(T14 value)
        {
            _value = value;
            _typeIndex = 13;
        }

        public Union(T15 value)
        {
            _value = value;
            _typeIndex = 14;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    case 9:
                        return _value ?? default(T10);
                    case 10:
                        return _value ?? default(T11);
                    case 11:
                        return _value ?? default(T12);
                    case 12:
                        return _value ?? default(T13);
                    case 13:
                        return _value ?? default(T14);
                    case 14:
                        return _value ?? default(T15);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T10 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T11 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T12 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T13 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T14 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T15 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func, [InstantHandle][NotNull]Func<T10, TOutput> onT10Func, [InstantHandle][NotNull]Func<T11, TOutput> onT11Func, [InstantHandle][NotNull]Func<T12, TOutput> onT12Func, [InstantHandle][NotNull]Func<T13, TOutput> onT13Func, [InstantHandle][NotNull]Func<T14, TOutput> onT14Func, [InstantHandle][NotNull]Func<T15, TOutput> onT15Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                case 9:
                    if (onT10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T10).Name}");
                    }

                    return onT10Func((T10)Value);
                case 10:
                    if (onT11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T11).Name}");
                    }

                    return onT11Func((T11)Value);
                case 11:
                    if (onT12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T12).Name}");
                    }

                    return onT12Func((T12)Value);
                case 12:
                    if (onT13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T13).Name}");
                    }

                    return onT13Func((T13)Value);
                case 13:
                    if (onT14Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T14).Name}");
                    }

                    return onT14Func((T14)Value);
                case 14:
                    if (onT15Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T15).Name}");
                    }

                    return onT15Func((T15)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action, [InstantHandle][NotNull]Action<T10> onT10Action, [InstantHandle][NotNull]Action<T11> onT11Action, [InstantHandle][NotNull]Action<T12> onT12Action, [InstantHandle][NotNull]Action<T13> onT13Action, [InstantHandle][NotNull]Action<T14> onT14Action, [InstantHandle][NotNull]Action<T15> onT15Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                case 9:
                    if (onT10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T10).Name}");
                    }

                    onT10Action((T10)Value);
                    break;
                case 10:
                    if (onT11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T11).Name}");
                    }

                    onT11Action((T11)Value);
                    break;
                case 11:
                    if (onT12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T12).Name}");
                    }

                    onT12Action((T12)Value);
                    break;
                case 12:
                    if (onT13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T13).Name}");
                    }

                    onT13Action((T13)Value);
                    break;
                case 13:
                    if (onT14Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T14).Name}");
                    }

                    onT14Action((T14)Value);
                    break;
                case 14:
                    if (onT15Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T15).Name}");
                    }

                    onT15Action((T15)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }

    public readonly struct Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
#if NULLABLE_REFERENCE_TYPES_SUPPORTED
        private readonly object? _value;
#else
        private readonly object _value;
#endif
        private readonly byte _typeIndex;

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

        public Union(T9 value)
        {
            _value = value;
            _typeIndex = 8;
        }

        public Union(T10 value)
        {
            _value = value;
            _typeIndex = 9;
        }

        public Union(T11 value)
        {
            _value = value;
            _typeIndex = 10;
        }

        public Union(T12 value)
        {
            _value = value;
            _typeIndex = 11;
        }

        public Union(T13 value)
        {
            _value = value;
            _typeIndex = 12;
        }

        public Union(T14 value)
        {
            _value = value;
            _typeIndex = 13;
        }

        public Union(T15 value)
        {
            _value = value;
            _typeIndex = 14;
        }

        public Union(T16 value)
        {
            _value = value;
            _typeIndex = 15;
        }

        private object Value
        {
            get
            {
                switch (_typeIndex)
                {
                    case 0:
                        return _value ?? default(T1);
                    case 1:
                        return _value ?? default(T2);
                    case 2:
                        return _value ?? default(T3);
                    case 3:
                        return _value ?? default(T4);
                    case 4:
                        return _value ?? default(T5);
                    case 5:
                        return _value ?? default(T6);
                    case 6:
                        return _value ?? default(T7);
                    case 7:
                        return _value ?? default(T8);
                    case 8:
                        return _value ?? default(T9);
                    case 9:
                        return _value ?? default(T10);
                    case 10:
                        return _value ?? default(T11);
                    case 11:
                        return _value ?? default(T12);
                    case 12:
                        return _value ?? default(T13);
                    case 13:
                        return _value ?? default(T14);
                    case 14:
                        return _value ?? default(T15);
                    case 15:
                        return _value ?? default(T16);
                    default: throw new InvalidOperationException();
                }
            }
        }

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T2 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T3 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T4 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T5 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T6 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T7 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T8 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T9 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T10 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T11 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T12 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T13 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T14 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T15 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T16 value) => new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(value);

        public static bool operator ==(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> right) => Equals(left, right);

        public static bool operator !=(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> right) => !Equals(left, right);

        public TOutput Map<TOutput>([InstantHandle][NotNull]Func<T1, TOutput> onT1Func, [InstantHandle][NotNull]Func<T2, TOutput> onT2Func, [InstantHandle][NotNull]Func<T3, TOutput> onT3Func, [InstantHandle][NotNull]Func<T4, TOutput> onT4Func, [InstantHandle][NotNull]Func<T5, TOutput> onT5Func, [InstantHandle][NotNull]Func<T6, TOutput> onT6Func, [InstantHandle][NotNull]Func<T7, TOutput> onT7Func, [InstantHandle][NotNull]Func<T8, TOutput> onT8Func, [InstantHandle][NotNull]Func<T9, TOutput> onT9Func, [InstantHandle][NotNull]Func<T10, TOutput> onT10Func, [InstantHandle][NotNull]Func<T11, TOutput> onT11Func, [InstantHandle][NotNull]Func<T12, TOutput> onT12Func, [InstantHandle][NotNull]Func<T13, TOutput> onT13Func, [InstantHandle][NotNull]Func<T14, TOutput> onT14Func, [InstantHandle][NotNull]Func<T15, TOutput> onT15Func, [InstantHandle][NotNull]Func<T16, TOutput> onT16Func)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T1).Name}");
                    }

                    return onT1Func((T1)Value);
                case 1:
                    if (onT2Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T2).Name}");
                    }

                    return onT2Func((T2)Value);
                case 2:
                    if (onT3Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T3).Name}");
                    }

                    return onT3Func((T3)Value);
                case 3:
                    if (onT4Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T4).Name}");
                    }

                    return onT4Func((T4)Value);
                case 4:
                    if (onT5Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T5).Name}");
                    }

                    return onT5Func((T5)Value);
                case 5:
                    if (onT6Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T6).Name}");
                    }

                    return onT6Func((T6)Value);
                case 6:
                    if (onT7Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T7).Name}");
                    }

                    return onT7Func((T7)Value);
                case 7:
                    if (onT8Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T8).Name}");
                    }

                    return onT8Func((T8)Value);
                case 8:
                    if (onT9Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T9).Name}");
                    }

                    return onT9Func((T9)Value);
                case 9:
                    if (onT10Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T10).Name}");
                    }

                    return onT10Func((T10)Value);
                case 10:
                    if (onT11Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T11).Name}");
                    }

                    return onT11Func((T11)Value);
                case 11:
                    if (onT12Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T12).Name}");
                    }

                    return onT12Func((T12)Value);
                case 12:
                    if (onT13Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T13).Name}");
                    }

                    return onT13Func((T13)Value);
                case 13:
                    if (onT14Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T14).Name}");
                    }

                    return onT14Func((T14)Value);
                case 14:
                    if (onT15Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T15).Name}");
                    }

                    return onT15Func((T15)Value);
                case 15:
                    if (onT16Func == null)
                    {
                        throw new ArgumentException($"No map function provided for {typeof(T16).Name}");
                    }

                    return onT16Func((T16)Value);
                default: throw new InvalidOperationException();
            }
        }

        public void Switch([InstantHandle][NotNull]Action<T1> onT1Action, [InstantHandle][NotNull]Action<T2> onT2Action, [InstantHandle][NotNull]Action<T3> onT3Action, [InstantHandle][NotNull]Action<T4> onT4Action, [InstantHandle][NotNull]Action<T5> onT5Action, [InstantHandle][NotNull]Action<T6> onT6Action, [InstantHandle][NotNull]Action<T7> onT7Action, [InstantHandle][NotNull]Action<T8> onT8Action, [InstantHandle][NotNull]Action<T9> onT9Action, [InstantHandle][NotNull]Action<T10> onT10Action, [InstantHandle][NotNull]Action<T11> onT11Action, [InstantHandle][NotNull]Action<T12> onT12Action, [InstantHandle][NotNull]Action<T13> onT13Action, [InstantHandle][NotNull]Action<T14> onT14Action, [InstantHandle][NotNull]Action<T15> onT15Action, [InstantHandle][NotNull]Action<T16> onT16Action)
        {
            switch (_typeIndex)
            {
                case 0:
                    if (onT1Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T1).Name}");
                    }

                    onT1Action((T1)Value);
                    break;
                case 1:
                    if (onT2Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T2).Name}");
                    }

                    onT2Action((T2)Value);
                    break;
                case 2:
                    if (onT3Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T3).Name}");
                    }

                    onT3Action((T3)Value);
                    break;
                case 3:
                    if (onT4Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T4).Name}");
                    }

                    onT4Action((T4)Value);
                    break;
                case 4:
                    if (onT5Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T5).Name}");
                    }

                    onT5Action((T5)Value);
                    break;
                case 5:
                    if (onT6Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T6).Name}");
                    }

                    onT6Action((T6)Value);
                    break;
                case 6:
                    if (onT7Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T7).Name}");
                    }

                    onT7Action((T7)Value);
                    break;
                case 7:
                    if (onT8Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T8).Name}");
                    }

                    onT8Action((T8)Value);
                    break;
                case 8:
                    if (onT9Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T9).Name}");
                    }

                    onT9Action((T9)Value);
                    break;
                case 9:
                    if (onT10Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T10).Name}");
                    }

                    onT10Action((T10)Value);
                    break;
                case 10:
                    if (onT11Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T11).Name}");
                    }

                    onT11Action((T11)Value);
                    break;
                case 11:
                    if (onT12Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T12).Name}");
                    }

                    onT12Action((T12)Value);
                    break;
                case 12:
                    if (onT13Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T13).Name}");
                    }

                    onT13Action((T13)Value);
                    break;
                case 13:
                    if (onT14Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T14).Name}");
                    }

                    onT14Action((T14)Value);
                    break;
                case 14:
                    if (onT15Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T15).Name}");
                    }

                    onT15Action((T15)Value);
                    break;
                case 15:
                    if (onT16Action == null)
                    {
                        throw new ArgumentException($"No switch action provided for {typeof(T16).Name}");
                    }

                    onT16Action((T16)Value);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other && Equals(Value, other.Value) && _typeIndex == other._typeIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ _typeIndex.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : string.Empty;
        }
    }
}
