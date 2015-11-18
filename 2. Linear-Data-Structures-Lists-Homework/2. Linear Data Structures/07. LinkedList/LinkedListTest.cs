namespace _07.LinkedList
{
    using System;

    public class LinkedListTest
    {
        public static void Main()
        {
            LinkedList<int> testList = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                testList.Add(i);
            }

            foreach (var number in testList)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine("Count={0}", testList.Count);

            testList.Remove(9);
            foreach (var number in testList)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine("Count={0}", testList.Count);

            testList.Add(1);
            foreach (var number in testList)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine("Count={0}", testList.Count);

            Console.WriteLine("First index of 1={0}", testList.FirstIndexOf(1));
            Console.WriteLine("Last index of 1={0}", testList.LastIndexOf(1));
        }
    }
}
