namespace _06.Reversed_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedListTest
    {
        public static void Main(string[] args)
        {
            ReversedList<int> testList = new ReversedList<int>();
            for (int i = 0; i < 100; i++)
            {
                testList.Add(i);
            }

            Console.WriteLine(testList[99]);
            Console.WriteLine(testList[0]);

            testList.Add(100);
            foreach (var number in testList)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine();

            Console.WriteLine(testList.Count);

            testList.Remove(0);

            Console.WriteLine(testList.Count);
        }
    }
}
