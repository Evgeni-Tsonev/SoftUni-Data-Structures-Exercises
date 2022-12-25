namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _items[index];
            }
            set
            {
                ValidateIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == _items.Length)
            {
                _items = DoubleArraySize(_items);
            }

            _items[Count++] = item;
        }

        public bool Contains(T item)
        {
            foreach (var element in _items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                var currentItem = _items[i];
                if (currentItem.Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            if (Count == _items.Length)
            {
                _items = DoubleArraySize(_items);
            }

            for (int i = Count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                var currentItem = _items[i];
                if (currentItem.Equals(item))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        _items[j] = _items[j + 1];
                    }

                    _items[Count - 1] = default;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private T[] DoubleArraySize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}