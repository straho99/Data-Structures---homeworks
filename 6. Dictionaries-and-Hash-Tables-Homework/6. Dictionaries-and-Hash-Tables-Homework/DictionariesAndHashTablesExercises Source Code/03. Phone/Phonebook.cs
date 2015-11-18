namespace _03.Phone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hash_Table;

    public class Phonebook
    {
        public static void Main()
        {
            Console.WriteLine("Enter contacts (name - number) or search existing contacts (type 'search'):");
            HashMap<string, string> phonebook = new HashMap<string, string>();

            string entry = Console.ReadLine();

            while (entry != "search")
            {
                string[] contactInfo = entry
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToArray();
                if (!phonebook.ContainsKey(contactInfo[0]))
                {
                    phonebook.Add(contactInfo[0], contactInfo[1]);
                }

                entry = Console.ReadLine();
            }

            List<string> searchWords = new List<string>();
            string word = Console.ReadLine();
            while (word != string.Empty)
            {
                searchWords.Add(word);
                word = Console.ReadLine();
            }

            foreach (var searchWord in searchWords)
            {
                if (phonebook.ContainsKey(searchWord))
                {
                    Console.WriteLine("{0} -> {1}", searchWord, phonebook[searchWord]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", searchWord);
                }
            }
        }
    }
}
