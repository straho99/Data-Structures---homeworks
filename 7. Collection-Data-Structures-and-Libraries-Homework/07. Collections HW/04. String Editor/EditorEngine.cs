namespace _04.String_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;  
    using System.Text;
    using System.Threading.Tasks;

    using Wintellect.PowerCollections;

    public class EditorEngine
    {
        private BigList<char> content;

        public EditorEngine()
        {
            this.content = new BigList<char>();
        }

        public void Append(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Cannot add empty string or null.");
            }
            this.content.AddRange(text.AsEnumerable());
        }

        public void Insert(string text, int index)
        {
            if (index >= this.content.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of text content.");
            }

            this.content.InsertRange(index, text.AsEnumerable());
        }

        public void Delete(int startIndex, int count)
        {
            if (startIndex >= this.content.Count || startIndex < 0)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of text content.");
            }

            int adjustedCount = startIndex + count < this.content.Count ?
                count : (this.content.Count - startIndex);

            this.content.RemoveRange(startIndex, adjustedCount);
        }

        public void Replace(int startIndex, int count, string replacement)
        {
            if (startIndex >= this.content.Count || startIndex < 0)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of text content.");
            }

            int adjustedCount = startIndex + count < this.content.Count ?
                count : (this.content.Count - startIndex);

            this.Insert(replacement, startIndex);
            this.Delete(startIndex + replacement.Length, adjustedCount);
        }

        public string Print()
        {
            return string.Join("", this.content.ToList());
        }
    }
}
