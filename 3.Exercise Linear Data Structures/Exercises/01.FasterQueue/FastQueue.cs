namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var elementToReturn = this.head.Item;
            var newHead = this.head.Next;
            this.head.Next = null;
            this.head = newHead;
            this.Count--;

            return elementToReturn;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.head != null)
            {
                yield return this.head.Item;
                this.head = this.head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}