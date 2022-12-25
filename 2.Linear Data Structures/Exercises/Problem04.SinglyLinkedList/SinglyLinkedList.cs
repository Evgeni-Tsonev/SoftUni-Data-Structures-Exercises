namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.Count == 0)
            {
                var newNode = new Node<T>(item, null, null);
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                var newHead = new Node<T>(item, this.head, null);
                this.head.Previous = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.Count == 0)
            {
                var newNode = new Node<T>(item, null, null);
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                var newTail = new Node<T>(item, null, this.tail);
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            ValidateCount();

            return this.head.Element;
        }

        public T GetLast()
        {
            ValidateCount();

            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            ValidateCount();

            var elementToReturn = this.head.Element;
            var newHead = this.head.Next;
            this.head.Next = null;
            this.head = newHead;
            this.Count--;

            return elementToReturn;
        }

        public T RemoveLast()
        {
            ValidateCount();

            var elementToReturn = this.tail.Element;
            var newTail = this.tail.Previous;
            this.tail.Previous = null;
            if (newTail != null)
            {
                newTail.Next = null;
            }

            this.tail = newTail;
            this.Count--;

            return elementToReturn;
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
            => this.GetEnumerator();

        private void ValidateCount()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}