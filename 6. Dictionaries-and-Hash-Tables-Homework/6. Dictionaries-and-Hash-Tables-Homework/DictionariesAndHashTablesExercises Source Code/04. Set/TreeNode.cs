namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class TreeNode<T> : IEnumerable<T>, IComparable<TreeNode<T>>
        where T : IComparable<T>
    {
        private T value;
        private TreeNode<T> leftNode;
        private TreeNode<T> rightNode;
        private TreeNode<T> parrent;

        public TreeNode(T value)
        {
            this.value = value;
            this.parrent = null;
            this.leftNode = null;
            this.rightNode = null;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.Value = value;
            }
        }

        public TreeNode<T> LeftNode
        {
            get
            {
                return this.leftNode;
            }
            set
            {
                this.leftNode = value;
            }
        }

        public TreeNode<T> RightNode
        {
            get
            {
                return this.rightNode;
            }
            set
            {
                this.rightNode = value;
            }
        }

        public TreeNode<T> Parrent
        {
            get
            {
                return this.parrent;
            }
            set
            {
                this.parrent = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftNode != null)
            {
                foreach (var v in this.leftNode)
                {
                    yield return v;
                }
            }

            yield return Value;

            if (this.rightNode != null)
            {
                foreach (var v in this.rightNode)
                {
                    yield return v;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(TreeNode<T> other)
        {
            return this.value.CompareTo(other.value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> other = (TreeNode<T>)obj;
            if (other == null)
            {
                return false;
            }
            return this.CompareTo(other) == 0;
        }
    }
}
