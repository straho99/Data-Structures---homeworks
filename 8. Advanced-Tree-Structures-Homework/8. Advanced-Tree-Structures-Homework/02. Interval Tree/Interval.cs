namespace _02.Interval_Tree
{
    using System;

    public class Interval<T> where T : IComparable
    {
        private T start;
        private T end;
        private T center;

        public Interval(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start
        {
            get
            {
                return this.start;
            }

            set
            {
                this.start = value;
            }
        }

        public T End
        {
            get
            {
                return this.end;
            }

            set
            {
                if (this.start.CompareTo(value) > 0)
                {
                    throw new ArgumentException("Invalid range. End must be greater than, or equal, to start.");
                }
                this.end = value;
            }
        }

        public override bool Equals(object other)
        {
            try
            {
                var otherInterval = (Interval<T>)other;
                if (this.Start.Equals(otherInterval.Start) && this.End.Equals(otherInterval.End))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
