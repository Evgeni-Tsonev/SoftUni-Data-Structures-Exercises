namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            this.heap = new List<T>();
        }

        public int Size => this.heap.Count;

        public void Add(T element)
        {
            this.heap.Add(element);

            this.HeapifyUp(this.Size - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.heap[index];
            this.heap[index] = this.heap[parentIndex];
            this.heap[parentIndex] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            if (this.heap[index].CompareTo(this.heap[parentIndex]) > 0)
            {
                return true;
            }

            return false;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public T ExtractMax()
        {
            this.ValidateNotEmpty();
            var elementoToReturn = this.heap[0];
            this.Swap(0, this.Size - 1);
            this.heap.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return elementoToReturn;
        }

        private void ValidateNotEmpty()
        {
            if (this.heap.Count == 0)
                throw new InvalidOperationException();
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var maxChildIndex = leftChildIndex;

            if (leftChildIndex >= this.Size)
            {
                return;
            }

            if (rightChildIndex <= this.Size - 1 &&
                this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (this.heap[maxChildIndex].CompareTo(this.heap[index]) > 0)
            {
                this.Swap(index, maxChildIndex);

                this.HeapifyDown(maxChildIndex);
            }
        }

        public T Peek()
        {
            this.ValidateNotEmpty();
            return this.heap[0];
        }
    }
}
