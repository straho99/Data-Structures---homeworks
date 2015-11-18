namespace _05.Count_Occurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountOccurences
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

            var frequencies = CountFrequencies(numbers);
            foreach (var number in frequencies.Keys)
            {
                Console.WriteLine("{0} -> {1} times", number, frequencies[number]);
            }
        }

        public static Dictionary<int, int> CountFrequencies(List<int> numbers)
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (occurences.ContainsKey(numbers[i]))
                {
                    occurences[numbers[i]]++;
                }
                else
                {
                    occurences[numbers[i]] = 1;
                }
            }
            return occurences;
        }
    }
}
