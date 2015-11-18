namespace ArrayStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        public int Count { get; private set; }

        public ArrayStack()
        {
            this.elements = new T[DefaultCapacity];
            this.Count = 0;
        }

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T result = this.elements[this.Count - 1];
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.elements[i];
            }

            return result;
        }

        private void Grow()
        {
            T[] newContainer = new T[this.elements.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newContainer[i] = this.elements[i];
            }

            this.elements = newContainer;
        }
    }
}