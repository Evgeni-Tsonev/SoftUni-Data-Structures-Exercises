namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        public bool Contains(T element)
        {
            return this.BfsContains(this.root, element);
        }

        public void EachInOrder(Action<T> action)
        {
            var list = new List<Node>();

            var elements = this.DfsInOrder(this.root, list);

            foreach (var node in elements)
            {
                action.Invoke(node.Value);
            }
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private IEnumerable<Node> DfsInOrder(Node node, List<Node> listForResults)
        {

            if (node.Left != null)
            {
                this.DfsInOrder(node.Left, listForResults);
            }

            listForResults.Add(node);

            if (node.Right != null)
            {
                this.DfsInOrder(node.Right, listForResults);
            }

            return listForResults;
        }

        private bool BfsContains(Node node, T searchedElement)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var curentNode = queue.Dequeue();

                if (curentNode.Value.Equals(searchedElement))
                {
                    return true;
                }

                if (curentNode.Left != null)
                {
                    queue.Enqueue(curentNode.Left);
                }

                if (curentNode.Right != null)
                {
                    queue.Enqueue(curentNode.Right);
                }
            }

            return false;
        }

        private Node FindNode(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }
    }
}
