using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }
    }

    private ListNode<T> firstElement;
    private ListNode<T> lastElement;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.firstElement == null)
        {
            this.firstElement = new ListNode<T>(element);
            this.lastElement = this.firstElement;
        }
        else
        {
            var newFirst = new ListNode<T>(element);
            newFirst.NextNode = this.firstElement;
            this.firstElement = newFirst;
        }
        this.Count++;
    }

    public void Add(T element)
    {
        this.AddLast(element);
    }

    public void AddLast(T element)
    {
        if (this.lastElement == null)
        {
            this.firstElement = new ListNode<T>(element);
            this.lastElement = this.firstElement;
        }
        else
        {
            var newLast = new ListNode<T>(element);
            this.lastElement.NextNode = newLast;
            this.lastElement = newLast;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove first element from an empty list.");
        }

        if (this.Count == 1)
        {
            T result = this.firstElement.Value;
            this.firstElement = this.lastElement = null;
            this.Count--;
            return result;
        }
        else
        {
            T result = this.firstElement.Value;
            this.firstElement = this.firstElement.NextNode;
            this.Count--;
            return result;
        }
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove element from an empty list.");
        }

        if (this.Count == 1)
        {
            T result = this.lastElement.Value;
            this.firstElement = this.lastElement = null;
            this.Count--;
            return result;
        }
        else
        {
            T result = this.lastElement.Value;
            this.lastElement.NextNode = null;
            this.Count--;
            return result;
        }
    }

    public T Remove(int index)
    {
        if (index >= this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid index: " + index);
        }

        // Find the element at the specified index 
        int currentIndex = 0;
        ListNode<T> currentNode = this.firstElement;
        ListNode<T> prevNode = null;

        while (currentIndex < index)
        {
            prevNode = currentNode;
            currentNode = currentNode.NextNode;
            currentIndex++;
        }
        // Remove the element 
        this.Count--;
        if (this.Count == 0)
        {
            this.firstElement = null;
        }
        else if (prevNode == null)
        {
            this.firstElement = currentNode.NextNode;
        }
        else
        {
            prevNode.NextNode = currentNode.NextNode;
        }

        // Find last element 
        ListNode<T> lastElement = null;
        if (this.firstElement != null)
        {
            lastElement = this.firstElement;
            while (lastElement.NextNode != null)
            {
                lastElement = lastElement.NextNode;
            }
        }

        this.lastElement = lastElement;

        return currentNode.Value;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.firstElement;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.firstElement;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        var currentNode = this.firstElement;
        int i = 0;

        while (currentNode != null)
        {
            result[i] = currentNode.Value;
            i++;
            currentNode = currentNode.NextNode;
        }

        return result;
    }

    public int FirstIndexOf(T item)
    {
        int index = 0;
        var currentNode = this.firstElement;

        while (currentNode != null)
        {
            if (currentNode.Value.Equals(item))
            {
                return index;
            }
            currentNode = currentNode.NextNode;
            index++;
        }
        return -1;
    }

    public int LastIndexOf(T item)
    {
        int currentIndex = 0;
        int lastIndex = -1;
        var currentNode = this.firstElement;

        while (currentNode != null)
        {
            if (currentNode.Value.Equals(item))
            {
                lastIndex = currentIndex;
            }
            currentNode = currentNode.NextNode;
            currentIndex++;
        }
        return lastIndex;
    }
}