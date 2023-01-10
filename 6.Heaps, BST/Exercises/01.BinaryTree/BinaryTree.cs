namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public IAbstractBinaryTree<T> LeftChild { get; set; }

        public IAbstractBinaryTree<T> RightChild { get; set; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();

            var result = this.Dfs(this, sb, indent);

            return result;
        }

        private string Dfs(IAbstractBinaryTree<T> tree, StringBuilder sb, int indent)
        {
            sb.Append(new string(' ', indent));
            sb.AppendLine(tree.Value.ToString());

            if (tree.LeftChild != null)
            {
                this.Dfs(tree.LeftChild, sb, indent + 2);
            }

            if (tree.RightChild != null)
            {
                this.Dfs(tree.RightChild, sb, indent + 2);
            }

            return sb.ToString().TrimEnd();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            throw new NotImplementedException();
        }
    }
}
