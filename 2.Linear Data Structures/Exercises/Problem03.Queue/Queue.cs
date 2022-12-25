namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Element.Equals(item))
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

            var elementToReturn = this.head.Element;
            var newHead = this.head.Next;
            this.head.Next = null;
            this.head = newHead;
            this.Count--;

            return elementToReturn;
        }

        public void Enqueue(T item)
        {
            if (this.Count == 0)
            {
                var newNode = new Node<T>(item, null);
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                var newTail = new Node<T>(item, null);
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.head.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.head != null)
            {
                yield return this.head.Element;
                this.head = this.head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}