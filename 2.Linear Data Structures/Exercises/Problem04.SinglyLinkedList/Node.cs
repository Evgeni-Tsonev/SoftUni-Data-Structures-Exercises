namespace Problem04.SinglyLinkedList
{
    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T element, Node<T> next, Node<T> previous)
        {
            this.Element = element;
            this.Next = next;
            this.Previous = previous;
        }

        public T Element { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}