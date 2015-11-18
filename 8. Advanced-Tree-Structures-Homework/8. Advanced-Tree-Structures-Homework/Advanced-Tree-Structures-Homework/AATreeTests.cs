namespace Advanced_Tree_Structures_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AATreeTests
    {
        public static void Main()
        {
            var testTree = new AATree<int>(10);
            testTree.Add(1);
            testTree.Add(7);
            testTree.Add(11);
            testTree.Add(-12);

            foreach (var item in testTree)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            testTree.Remove(7);
            foreach (var item in testTree)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            testTree.Remove(11);
            foreach (var item in testTree)
            {
                Console.WriteLine(item);
            }

            testTree.Remove(122);
        }
    }
}