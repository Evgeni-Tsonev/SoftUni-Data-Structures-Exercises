namespace Demo
{
    using System;
    using System.Text;
    using _01.BinaryTree;
    using _02.BinarySearchTree;

    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(1);

            Console.WriteLine();
        }
    }
}