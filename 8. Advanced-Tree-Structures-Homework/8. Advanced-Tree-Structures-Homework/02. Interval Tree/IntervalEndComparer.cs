namespace _02.Interval_Tree
{
    using System;
    using System.Collections.Generic;

    internal class IntervalEndComparer<T> : IComparer<Interval<T>> where T : IComparable
    {
        public int Compare(Interval<T> x, Interval<T> y)
        {
            return x.End.CompareTo(y.End);
        }
    }
}