namespace _04.Remove_Odd_Ocurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOdd
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a sequence of integer numbers, separated by comma:");
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 0)
            {
                return;
            }
            List<int> numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i]));
            }

            Console.WriteLine(string.Join(" ", RemoveOddOccurences(numbers)));
        }

        public static List<int> RemoveOddOccurences(List<int> numbers)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int occurences = numbers.Where(n => n == numbers[i]).Count();
                if (occurences % 2 == 0)
                {
                    result.Add(numbers[i]);
                }
            }
            return result;
        }
    }
}
