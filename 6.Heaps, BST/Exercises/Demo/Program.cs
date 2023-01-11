namespace Demo
{
    using System;
    using System.Text;
    using _01.BinaryTree;
    using _02.BinarySearchTree;
    using _03.MaxHeap;

    class Program
    {
        static void Main(string[] args)
        {
            var heap = new MaxHeap<int>();

            heap.Add(5);
            heap.Add(3);
            heap.Add(1);

            Console.WriteLine(heap.ExtractMax());
            Console.WriteLine(heap.ExtractMax());
            Console.WriteLine(heap.ExtractMax());
            Console.WriteLine(heap.Size);
        }
    }
}