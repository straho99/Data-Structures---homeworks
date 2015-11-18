namespace _03.Binary_Heap
{
    using System;

    public class BinaryHeapTest
    {
        public static void Main()
        {
            var testHeap = new PriorityQueue<int>();

            testHeap.Enqueue(5);
            testHeap.Enqueue(23);
            testHeap.Enqueue(3);
            testHeap.Enqueue(42);
            testHeap.Enqueue(-1);
            testHeap.Enqueue(-23);

            while (testHeap.Count > 0)
            {
                Console.WriteLine(testHeap.Dequeue());
            }
        }
    }
}
