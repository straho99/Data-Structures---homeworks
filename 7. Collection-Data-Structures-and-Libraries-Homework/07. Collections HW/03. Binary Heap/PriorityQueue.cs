namespace _03.Binary_Heap
{
    using System;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private BinaryMinHeap<T> elements;

        public PriorityQueue()
        {
            this.elements = new BinaryMinHeap<T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enqueue(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot add null to queue.");
            }
            this.elements.Add(value);
        }

        public T Dequeue()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            return this.elements.PopMin();
        }
    }
}
