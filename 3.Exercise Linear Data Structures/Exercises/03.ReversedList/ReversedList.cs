namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.items = DoubleArraySize(this.items);
            }

            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            foreach (var currentItem in this.items)
            {
                if (currentItem.Equals(item))
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
                var currentItem = this.items[i];
                if (currentItem.Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            var reversedIndex = this.Count - index;
            this.ValidateIndex(index);
            if (this.Count == this.items.Length)
            {
                this.items = DoubleArraySize(this.items);
            }

            for (int i = this.Count; i > reversedIndex; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[reversedIndex] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                var currentItem = this.items[i];
                if (currentItem.Equals(item))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        this.items[j] = this.items[j + 1];
                    }

                    this.items[this.Count - 1] = default;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            var reversedIndex = this.Count - index;
            this.ValidateIndex(index);
            for (int i = reversedIndex; i < Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i > 0; i--)
            {
                yield return items[i];
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
                throw new IndexOutOfRangeException();
            }
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}