namespace _06.Reversed_List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable
    {
        private readonly int DefaultCapacity = 16;

        private int count = 0;
        private T[] container;

        public ReversedList()
        {
            this.container = new T[DefaultCapacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T item)
        {
            if (this.count == this.container.Length)
            {
                T[] newContainer = new T[this.container.Length * 2];
                for (int i = 0; i < this.container.Length; i++)
                {
                    newContainer[i] = container[i];
                }
                this.container = newContainer;
            }

            this.container[count] = item;
            this.count++;
        }

        public int Capacity
        {
            get
            {
                return this.container.Length;
            }
        }

        public void Remove(int index)
        {
            if (index >= this.count)
            {
                throw new ArgumentException("Index out of range.");
            }
            int reversedIndex = this.count - index - 1;
            for (int i = reversedIndex; i < this.container.Length - 1; i++)
            {
                this.container[i] = this.container[i + 1];
            }
            this.count--;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count)
                {
                    throw new ArgumentException("Index out of range.");
                }
                int reversedIndex = this.count - index - 1;
                return this.container[reversedIndex];
            }
            set
            {
                if (index >= this.count)
                {
                    throw new ArgumentException("Index out of range.");
                }
                int reversedIndex = this.count - index - 1;
                this.container[reversedIndex] = value;
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.container[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
