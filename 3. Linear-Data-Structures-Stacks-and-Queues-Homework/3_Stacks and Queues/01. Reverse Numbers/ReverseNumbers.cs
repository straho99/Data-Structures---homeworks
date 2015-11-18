namespace _01.Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Please, enter a sequence of comma-separated numbers:");
            List<int> numbers = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(num => int.Parse(num))
                                    .ToList();
            Stack<int> container = new Stack<int>();
            numbers.ForEach(num => container.Push(num));
            while (container.Count > 0)
            {
                Console.WriteLine(container.Pop());
            }
        }
    }
}
