namespace OrderedSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderedSetExamples
    {
        public static void Main()
        {
            var testSet = new OrderedSet<int>();

            testSet.Add(7);
            testSet.Add(1);
            testSet.Add(72);
            testSet.Add(-27);
            testSet.Add(0);
            testSet.Add(15);

            Console.WriteLine(string.Join(", ", testSet));

            testSet.Remove(0);
            Console.WriteLine(string.Join(", ", testSet));
        }
    }
}
