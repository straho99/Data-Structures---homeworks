namespace _03.Binary_Heap
{
    using System;
    using System.Collections.Generic;

    public class BinaryMinHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public BinaryMinHeap()
        {
            this.elements = new List<T>();
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.elements.Add(item);
            this.Count++;
            this.Heapify();
        }

        public void Delete(T item)
        {
            int i = this.elements.IndexOf(item);

            if (i < 0)
            {
                return;
            }

            int last = this.elements.Count - 1;

            this.elements[i] = elements[last];
            this.elements.RemoveAt(last);
            this.Heapify();

            this.Count--;
        }

        public T PopMin()
        {
            if (this.elements.Count > 0)
            {
                T item = this.elements[0];
                this.Delete(item);
                return item;
            }

            throw new InvalidOperationException("The heap is empty.");
        }

        private void Heapify()
        {
            for (int i = this.elements.Count - 1; i > 0; i--)
            {
                int parentPosition = (i + 1) / 2 - 1;
                parentPosition = parentPosition >= 0 ? parentPosition : 0;

                if (this.elements[parentPosition].CompareTo(this.elements[i]) > 0)
                {
                    SwapElements(parentPosition, i);
                }
            }
        }

        private void SwapElements(int firstIndex, int secondIndex)
        {
            T tmp = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = tmp;
        }
    }
}