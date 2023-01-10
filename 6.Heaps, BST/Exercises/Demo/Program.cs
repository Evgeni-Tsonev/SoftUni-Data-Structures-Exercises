namespace Demo
{
    using System;
    using _01.BinaryTree;

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>(
                          17,
                          new BinaryTree<int>(
                              9,
                              new BinaryTree<int>(3, null, null),
                              new BinaryTree<int>(11, null, null)
                          ),
                          new BinaryTree<int>(
                              25,
                              new BinaryTree<int>(20, null, null),
                              new BinaryTree<int>(31, null, null)));

            var result = tree.InOrder();

            foreach (var item in result)
            {
                Console.WriteLine(item.Value);

            }
        }
    }
}