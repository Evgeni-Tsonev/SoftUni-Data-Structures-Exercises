namespace Tree
{
    using System;
    using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var leafs = new List<T>();

            this.DfsLeafKeys(leafs, this);

            return leafs;
        }

        private void DfsLeafKeys(List<T> leafs, Tree<T> tree)
        {
            foreach (var child in tree.children)
            {
                if (child.children.Count == 0)
                {
                    leafs.Add(child.Key);
                }

                this.DfsLeafKeys(leafs, child);
            }
        }

            public T GetDeepestKey()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}
