using System;

namespace GenericDataStructures
{
    public class Union<T1>
    {
        private readonly object? _value;
        private readonly byte? _typeIndex;

        public Union(T1 value)
        {
            _value = value;
            _typeIndex = 0;
        }

        public static implicit operator Union<T1>(T1 value) => new Union<T1>(value);

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }

    public class Union<T1, T2>
    {
        private readonly object? _value;
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

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func, Func<T2, TOutput> onT2Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                1 => onT2Func((T2)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action, Action<T2> onT2Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                case 1: onT2Action((T2)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }

    public class Union<T1, T2, T3>
    {
        private readonly object? _value;
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

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func, Func<T2, TOutput> onT2Func, Func<T3, TOutput> onT3Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                1 => onT2Func((T2)_value!),
                2 => onT3Func((T3)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action, Action<T2> onT2Action, Action<T3> onT3Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                case 1: onT2Action((T2)_value!); break;
                case 2: onT3Action((T3)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }

    public class Union<T1, T2, T3, T4>
    {
        private readonly object? _value;
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

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func, Func<T2, TOutput> onT2Func, Func<T3, TOutput> onT3Func, Func<T4, TOutput> onT4Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                1 => onT2Func((T2)_value!),
                2 => onT3Func((T3)_value!),
                3 => onT4Func((T4)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action, Action<T2> onT2Action, Action<T3> onT3Action, Action<T4> onT4Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                case 1: onT2Action((T2)_value!); break;
                case 2: onT3Action((T3)_value!); break;
                case 3: onT4Action((T4)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }

    public class Union<T1, T2, T3, T4, T5>
    {
        private readonly object? _value;
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

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func, Func<T2, TOutput> onT2Func, Func<T3, TOutput> onT3Func, Func<T4, TOutput> onT4Func, Func<T5, TOutput> onT5Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                1 => onT2Func((T2)_value!),
                2 => onT3Func((T3)_value!),
                3 => onT4Func((T4)_value!),
                4 => onT5Func((T5)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action, Action<T2> onT2Action, Action<T3> onT3Action, Action<T4> onT4Action, Action<T5> onT5Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                case 1: onT2Action((T2)_value!); break;
                case 2: onT3Action((T3)_value!); break;
                case 3: onT4Action((T4)_value!); break;
                case 4: onT5Action((T5)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }

    public class Union<T1, T2, T3, T4, T5, T6>
    {
        private readonly object? _value;
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

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func, Func<T2, TOutput> onT2Func, Func<T3, TOutput> onT3Func, Func<T4, TOutput> onT4Func, Func<T5, TOutput> onT5Func, Func<T6, TOutput> onT6Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                1 => onT2Func((T2)_value!),
                2 => onT3Func((T3)_value!),
                3 => onT4Func((T4)_value!),
                4 => onT5Func((T5)_value!),
                5 => onT6Func((T6)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action, Action<T2> onT2Action, Action<T3> onT3Action, Action<T4> onT4Action, Action<T5> onT5Action, Action<T6> onT6Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                case 1: onT2Action((T2)_value!); break;
                case 2: onT3Action((T3)_value!); break;
                case 3: onT4Action((T4)_value!); break;
                case 4: onT5Action((T5)_value!); break;
                case 5: onT6Action((T6)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }

    public class Union<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly object? _value;
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

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func, Func<T2, TOutput> onT2Func, Func<T3, TOutput> onT3Func, Func<T4, TOutput> onT4Func, Func<T5, TOutput> onT5Func, Func<T6, TOutput> onT6Func, Func<T7, TOutput> onT7Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                1 => onT2Func((T2)_value!),
                2 => onT3Func((T3)_value!),
                3 => onT4Func((T4)_value!),
                4 => onT5Func((T5)_value!),
                5 => onT6Func((T6)_value!),
                6 => onT7Func((T7)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action, Action<T2> onT2Action, Action<T3> onT3Action, Action<T4> onT4Action, Action<T5> onT5Action, Action<T6> onT6Action, Action<T7> onT7Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                case 1: onT2Action((T2)_value!); break;
                case 2: onT3Action((T3)_value!); break;
                case 3: onT4Action((T4)_value!); break;
                case 4: onT5Action((T5)_value!); break;
                case 5: onT6Action((T6)_value!); break;
                case 6: onT7Action((T7)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }

    public class Union<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly object? _value;
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

        public TOutput Match<TOutput>(Func<T1, TOutput> onT1Func, Func<T2, TOutput> onT2Func, Func<T3, TOutput> onT3Func, Func<T4, TOutput> onT4Func, Func<T5, TOutput> onT5Func, Func<T6, TOutput> onT6Func, Func<T7, TOutput> onT7Func, Func<T8, TOutput> onT8Func)
        {
            return _typeIndex switch
            {
                0 => onT1Func((T1)_value!),
                1 => onT2Func((T2)_value!),
                2 => onT3Func((T3)_value!),
                3 => onT4Func((T4)_value!),
                4 => onT5Func((T5)_value!),
                5 => onT6Func((T6)_value!),
                6 => onT7Func((T7)_value!),
                7 => onT8Func((T8)_value!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Match(Action<T1> onT1Action, Action<T2> onT2Action, Action<T3> onT3Action, Action<T4> onT4Action, Action<T5> onT5Action, Action<T6> onT6Action, Action<T7> onT7Action, Action<T8> onT8Action)
        {
            switch (_typeIndex)
            {
                case 0: onT1Action((T1)_value!); break;
                case 1: onT2Action((T2)_value!); break;
                case 2: onT3Action((T3)_value!); break;
                case 3: onT4Action((T4)_value!); break;
                case 4: onT5Action((T5)_value!); break;
                case 5: onT6Action((T6)_value!); break;
                case 6: onT7Action((T7)_value!); break;
                case 7: onT8Action((T8)_value!); break;
                default: throw new InvalidOperationException();
            }
        }
    }
}
