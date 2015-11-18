namespace LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> lastNode;

        public LinkedStack()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.lastNode = new Node<T>(element);
            }
            else
            {
                this.lastNode = new Node<T>(element, this.lastNode);
            }
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            var result = this.lastNode.Value;
            this.lastNode = this.lastNode.PreviousNode;
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            if (this.Count == 0)
            {
                return new T[0];
            }
            T[] result = new T[this.Count];
            var currentNode = this.lastNode;
            int index = 0;
            while (currentNode != null)
            {
                result[index] = currentNode.Value;
                currentNode = currentNode.PreviousNode;
                index++;
            }
            return result;
        }

        private class Node<T>
        {
            private T value;

            public Node<T> PreviousNode { get; set; }

            public Node(T value, Node<T> previousNode = null)
            {
                this.value = value;
                this.PreviousNode = previousNode;
            }

            public T Value
            {
                get
                {
                    return this.value;
                }
                set
                {
                    this.value = value;
                }
            }
        }
    }
}