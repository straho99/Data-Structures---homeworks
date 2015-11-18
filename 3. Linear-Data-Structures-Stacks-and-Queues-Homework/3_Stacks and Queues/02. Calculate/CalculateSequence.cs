namespace _02.Calculate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalculateSequence
    {
        public static void Main()
        {
            Console.WriteLine("Please, enter an integer number:");
            int currentNumber = int.Parse(Console.ReadLine());

            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(currentNumber);
            int index = 1;

            while (index <= 50)
            {
                sequence.Enqueue(sequence.Peek() + 1);
                sequence.Enqueue(2 * sequence.Peek() + 1);
                sequence.Enqueue(sequence.Peek() + 2);
                Console.WriteLine("{0}: {1}", index, sequence.Dequeue());
                index++;
            }
        }
    }
}
