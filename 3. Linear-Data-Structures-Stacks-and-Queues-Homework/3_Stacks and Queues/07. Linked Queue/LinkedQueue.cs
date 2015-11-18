namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private Node<T> firstNode;
        private Node<T> lastNode;

        public LinkedQueue()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
                this.firstNode.NextNode = this.lastNode = null;
            }
            else if(this.Count == 1)
            {
                var node = new Node<T>(element);
                this.firstNode.NextNode = node;
                this.lastNode = node;
            }
            else
            {
                var node = new Node<T>(element);
                this.lastNode.NextNode = node;
                this.lastNode = node;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var result = this.firstNode.Value;

            if (this.Count == 1)
            {
                this.firstNode = null;
                this.lastNode = null;
            }
            else
            {
                this.firstNode = this.firstNode.NextNode;
            }

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
            var currentNode = this.firstNode;
            int index = 0;
            while (currentNode != null)
            {
                result[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }
            return result;
        }

        private class Node<T>
        {
            private T value;

            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.value = value;
                this.NextNode = nextNode;
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