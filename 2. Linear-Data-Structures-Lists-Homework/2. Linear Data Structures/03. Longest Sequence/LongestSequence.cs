namespace _03.Longest_Sequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSequence
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

            Console.WriteLine(string.Join(" ", FindLongestSequence(numbers)));
        }

        public static List<int> FindLongestSequence(List<int> numbers)
        {
            List<int> result = new List<int>();
            List<int> currentSequence = new List<int>();

            if (numbers.Count == 1)
            {
                return numbers;
            }

            int i = 0;
            while (i < numbers.Count - 1)
            {
                int j = i;
                currentSequence.Add(numbers[j]);
                while (j < numbers.Count-1 && numbers[j] == numbers[j + 1])
                {
                    currentSequence.Add(numbers[j + 1]);
                    j++;
                }
                if (currentSequence.Count > result.Count)
                {
                    result.Clear();
                    result.AddRange(currentSequence);
                    currentSequence.Clear();
                }
                else
                {
                    currentSequence.Clear();
                }
                i = j + 1;
            }

            return result;
        }
    }
}
