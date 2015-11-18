﻿namespace _09.Sequence
{
    using System;

    public class Item<T>
    {
        public Item(T value, Item<T> previousItem)
        {
            this.Value = value;
            this.PreviousItem = previousItem;
        }
        public T Value { get; set; }

        public Item<T> PreviousItem { get; set; }
    }
}
