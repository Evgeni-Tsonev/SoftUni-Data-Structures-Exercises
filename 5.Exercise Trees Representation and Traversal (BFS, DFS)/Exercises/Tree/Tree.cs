namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key)
        {
            this.children = new List<Tree<T>>();
            this.Key = key;
        }

        public Tree(T key, params Tree<T>[] children)
            : this(key)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DfsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent);
            sb.Append(tree.Key);
            sb.AppendLine();

            foreach (var child in tree.children)
            {
                this.DfsString(sb, child, indent + 2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            var internalNodes = new List<T>();

            this.DfsInternalKeys(internalNodes, this);

            return internalNodes;
        }

        private void DfsInternalKeys(List<T> internalNodes, Tree<T> tree)
        {
            foreach (var child in tree.children)
            {
                if (child.children.Count > 0 && child.Parent != null)
                {
                    internalNodes.Add(child.Key);
                }

                this.DfsInternalKeys(internalNodes, child);
            }
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var list = new List<Tree<T>>();

            var leafs = this.DfsLeafKeys(list, this);

            return leafs.Select(x => x.Key);
        }

        private IEnumerable<Tree<T>> DfsLeafKeys(List<Tree<T>> leafs, Tree<T> tree)
        {
            foreach (var child in tree.children)
            {
                if (child.children.Count == 0)
                {
                    leafs.Add(child);
                }

                this.DfsLeafKeys(leafs, child);
            }

            return leafs;
        }

        public T GetDeepestKey()
        {
            Tree<T> deepestNode = null;
            var list = new List<Tree<T>>();

            var leafs = this.DfsLeafKeys(list, this);

            var maxDepth = 0;

            foreach (var leaf in leafs)
            {
                var currentLeafDepth = this.GetDepth(leaf);

                if (currentLeafDepth > maxDepth)
                {
                    deepestNode = leaf;
                    maxDepth = currentLeafDepth;
                }
            }

            return deepestNode.Key;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}
