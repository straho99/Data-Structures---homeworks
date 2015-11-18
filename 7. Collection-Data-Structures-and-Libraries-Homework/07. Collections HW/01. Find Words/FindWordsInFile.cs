namespace _01.Find_Words
{
    using System;
    using System.Collections.Generic;

    public class FindWordsInFile
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, int> wordsFrequencies = new Dictionary<string, int>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] words = ExtractWords(Console.ReadLine());
                foreach (var word in words)
                {
                    if (wordsFrequencies.ContainsKey(word))
                    {
                        wordsFrequencies[word]++;
                    }
                    else
                    {
                        wordsFrequencies[word] = 1;
                    }
                }
            }

            int numberOfWordsToSearch = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfWordsToSearch; i++)
            {
                string word = Console.ReadLine();
                if (wordsFrequencies.ContainsKey(word))
                {
                    Console.WriteLine("{0} -> {1}", word, wordsFrequencies[word]);
 
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", word, 0);

                }
            }
        }

        public static string[] ExtractWords(string text)
        {
            string[] result = text.Split(new char[] {' ', '.', ',', ';', '\'', '"', '-', '!', '?', ':'}, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }
    }
}
