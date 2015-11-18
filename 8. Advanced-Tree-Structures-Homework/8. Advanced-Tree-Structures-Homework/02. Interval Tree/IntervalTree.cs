namespace _02.Interval_Tree
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    using Advanced_Tree_Structures_Homework;

    public class IntervalTree<T> where T : IComparable
    {
        private OrderedBag<Interval<T>> starts;
        private OrderedBag<Interval<T>> ends;

        public IntervalTree(Interval<T> interval)
        {
            this.starts = new OrderedBag<Interval<T>>(new IntervalStartComparer<T>());
            this.ends = new OrderedBag<Interval<T>>(new IntervalEndComparer<T>());
            this.starts.Add(interval);
            this.ends.Add(interval);
        }

        public void Add(Interval<T> interval)
        {
            this.starts.Add(interval);
            this.ends.Add(interval);
        }

        public HashSet<Interval<T>> SearchIntersectingIntervals(Interval<T> interval) 
        {
            var startStart = this.starts.RangeTo(interval, true);
            var startEnd = this.ends.RangeFrom(interval, true);

            var biggerRange = startStart.Count > startEnd.Count ? startStart : startEnd;
            var smallerRange = startStart.Count <= startEnd.Count ? startStart : startEnd;

            var result = new HashSet<Interval<T>>();
            foreach (var item in biggerRange)
            {
                if (smallerRange.Contains(item))
                {
                    result.Add(item);
                }
            }

            var endStart = this.starts.RangeTo(new Interval<T>(interval.End, interval.End), true);
            var endEnd = this.ends.RangeFrom(new Interval<T>(interval.End, interval.End), true);

            biggerRange = endStart.Count > endEnd.Count ? endStart : endEnd;
            smallerRange = endStart.Count <= endEnd.Count ? endStart : endEnd;

            foreach (var item in biggerRange)
            {
                if (smallerRange.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
