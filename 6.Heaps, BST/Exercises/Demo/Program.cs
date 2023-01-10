namespace Demo
{
    using System;
    using System.Text;
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

            StringBuilder builder = new StringBuilder();

            tree.ForEachInOrder(key => builder.Append(key).Append(", "));
            string actual = builder.ToString();

            Console.WriteLine(actual);
        }
    }
}