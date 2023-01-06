namespace Tree
{
    using System;
    using System.Collections.Generic;

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
            child.Parent = this;
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLeafKeys()
        {
            throw new NotImplementedException();
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
