namespace _02.Count
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hash_Table;

    public class CountSymbols
    {
        public static void Main()
        {
            Console.Write("Please, enter some text: ");
            string text = Console.ReadLine();
            var chars = text.AsEnumerable();

            var charCounts = new HashMap<char, int>();

            foreach (var character in chars)
            {
                if (charCounts.ContainsKey(character))
                {
                    charCounts[character]++;
                }
                else
                {
                    charCounts[character] = 1;
                }
            }

            var sortedChars = charCounts.Keys.OrderBy(k => k).ToList();
            foreach (var character in sortedChars)
            {
                Console.WriteLine("{0}: {1} time(s)", character, charCounts[character]);
            }
        }
    }
}
