namespace _01.Sum_and_Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a sequence of integer numbers, separated by comma:");
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 0)
            {
                return;
            }
            List<int> numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i]));
            }
            Console.WriteLine("Sum={0}; Average={1}", numbers.Sum(), numbers.Average());
        }
    }
}
