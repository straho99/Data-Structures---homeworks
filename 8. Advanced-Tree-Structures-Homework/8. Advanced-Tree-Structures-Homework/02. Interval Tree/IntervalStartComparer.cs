namespace _02.Interval_Tree
{
    using System;
    using System.Collections.Generic;

    internal class IntervalStartComparer<T> : IComparer<Interval<T>> where T : IComparable
    {
        public int Compare(Interval<T> x, Interval<T> y)
        {
            return x.Start.CompareTo(y.Start);
        }
    }
}