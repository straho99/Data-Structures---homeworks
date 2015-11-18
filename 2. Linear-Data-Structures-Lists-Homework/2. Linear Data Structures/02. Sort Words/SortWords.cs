namespace _02.Sort_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        static void Main()
        {
            Console.WriteLine("Please enter a sequence of words, separated by comma:");
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 0)
            {
                return;
            }

            List<string> words = new List<string>(input);
            words.Sort();
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
