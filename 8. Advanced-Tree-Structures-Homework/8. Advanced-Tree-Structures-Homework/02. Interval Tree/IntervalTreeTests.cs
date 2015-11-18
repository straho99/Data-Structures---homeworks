namespace _02.Interval_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntervalTreeTests
    {
        public static void Main()
        {
            var testIntervals = new IntervalTree<int>(new Interval<int>(1, 10));
            testIntervals.Add(new Interval<int>(5, 7));
            testIntervals.Add(new Interval<int>(11, 20));
            testIntervals.Add(new Interval<int>(2, 8));
            testIntervals.Add(new Interval<int>(-2, 5));
            testIntervals.Add(new Interval<int>(7, 123));
            testIntervals.Add(new Interval<int>(6, 12));
            testIntervals.Add(new Interval<int>(23, 45));

            var intersects = testIntervals.SearchIntersectingIntervals(new Interval<int>(6, 7));
            foreach (var item in intersects)
            {
                Console.WriteLine("{0} - {1}", item.Start, item.End);
            }
        }
    }
}