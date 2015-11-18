namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinarySearchTree<T> elements;

        public OrderedSet()
        {
            this.elements = new BinarySearchTree<T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T item)
        {
            this.elements.Add(item);
        }

        public bool Contains(T item)
        {
            return this.elements.Find(item) == null ? false : true;
        }

        public void Remove(T item)
        {
            this.elements.Delete(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
