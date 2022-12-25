namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = this.top;
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

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.top.Element;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var topNodeElement = this.top.Element;
            var newTop = this.top.Next;
            this.top.Next = null;
            this.top = newTop;
            this.Count--;

            return topNodeElement;
        }

        public void Push(T item)
        {
            this.top = new Node<T>(item, this.top);
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.top != null)
            {
                yield return this.top.Element;
                this.top = this.top.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}