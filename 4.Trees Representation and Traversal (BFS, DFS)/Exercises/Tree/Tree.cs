namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private Tree<T> parent;
        private T value;

        public Tree(T value)
        {
            this.children = new List<Tree<T>>();
            this.value = value;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = this.FindBfs(parentKey);

            this.CheckEmptyNode(searchedNode);

            searchedNode.children.Add(child);
        }

        public IEnumerable<T> OrderBfs()
        {
            var list = new List<T>();

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();
                list.Add(currentElement.value);

                foreach (var child in currentElement.children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        public IEnumerable<T> OrderDfs()
        {
            var list = new List<T>();

            this.Dfs(this, list);

            return list;
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindBfs(nodeKey);

            this.CheckEmptyNode(searchedNode);

            var searchedParent = searchedNode.parent;
            if (searchedParent == null)
            {
                throw new ArgumentException();
            }

            foreach (var child in searchedNode.children)
            {
                child.parent = null;
            }

            searchedNode.children.Clear();

            searchedParent.children.Remove(searchedNode);

            searchedNode.value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);

            this.CheckEmptyNode(firstNode);
            this.CheckEmptyNode(secondNode);

            var firstNodeParent = firstNode.parent;
            var secondNodeParent = secondNode.parent;

            if (firstNodeParent == null || secondNodeParent == null)
            {
                throw new ArgumentException();
            }

            var indexOfFirstNode = firstNodeParent.children.IndexOf(firstNode);
            var indexOfSecondNode = secondNodeParent.children.IndexOf(secondNode);

            firstNodeParent.children[indexOfFirstNode] = secondNode;
            secondNode.parent = firstNodeParent;

            secondNodeParent.children[indexOfSecondNode] = firstNode;
            firstNode.parent = secondNodeParent;
        }

        private void Dfs(Tree<T> tree, List<T> list)
        {
            foreach (var child in tree.children)
            {
                this.Dfs(child, list);
            }

            list.Add(tree.value);
        }

        private IEnumerable<T> DfsWithStack()
        {
            var result = new Stack<T>();
            var stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                foreach (var child in node.children)
                {
                    stack.Push(child);
                }

                result.Push(node.value);
            }

            return result;
        }

        private void CheckEmptyNode(Tree<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> FindBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement.value.Equals(parentKey))
                {
                    return currentElement;
                }

                foreach (var child in currentElement.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
