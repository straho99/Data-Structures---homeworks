namespace _09.Sequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestSequence
    {
        public static void Main()
        {
            int n = 10;
            int m = 30;

            Queue<Item<int>> sequence = new Queue<Item<int>>();

            sequence.Enqueue(new Item<int>(n, null));

            while (sequence.Count > 0)
            {
                Item<int> currentElement = sequence.Dequeue();
                if (currentElement.Value < m)
                {
                    sequence.Enqueue(new Item<int>(currentElement.Value + 1, currentElement));
                    sequence.Enqueue(new Item<int>(currentElement.Value + 2, currentElement));
                    sequence.Enqueue(new Item<int>(currentElement.Value * 2, currentElement));                    
                }
                if (currentElement.Value == m)
                {
                    PrintSolution(currentElement);
                    break;
                }
            }
        }

        private static void PrintSolution<T>(Item<T> item)
        {
            Stack<Item<T>> reversed =new Stack<Item<T>>();
            string result = "";
            var currentItem = item;
            reversed.Push(item);
            while (currentItem.PreviousItem != null)
            {
                currentItem = currentItem.PreviousItem;
                reversed.Push(currentItem);
            }
            while (reversed.Count > 0)
            {
                result += string.Format("{0} -> ", reversed.Pop().Value);
            }
            Console.WriteLine(result.Substring(0, result.Length - 4));
        }
    }
}
