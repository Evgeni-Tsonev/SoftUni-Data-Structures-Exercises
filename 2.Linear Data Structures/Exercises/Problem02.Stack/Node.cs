namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T element, Node<T> next)
        {
            this.Element = element;
            this.Next = next;
        }

        public T Element { get; set; }

        public Node<T> Next { get; set; }
    }
}