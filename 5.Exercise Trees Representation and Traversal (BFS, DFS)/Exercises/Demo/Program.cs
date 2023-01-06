namespace Demo
{
    using System;
    using TreeFactory;

    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73" };
            var treeFactory = new IntegerTreeFactory();
            var tree = treeFactory.CreateTreeFromStrings(input);

            var root = treeFactory.GetRoot();
            Console.WriteLine(root.Key);
        }
    }
}
