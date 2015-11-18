namespace Advanced_Tree_Structures_Homework
{
    using System;

    internal class AATreeNode<T>
    {
        internal int level;
        internal AATreeNode<T> left;
        internal AATreeNode<T> right;

        internal T value;

        // Constuctor for the sentinel node
        internal AATreeNode()
        {
            this.level = 0;
            this.left = this;
            this.right = this;
        }

        // Constuctor for regular nodes (that all start life as leaf nodes)
        internal AATreeNode(T value)
        {
            this.level = 1;
            this.left = null;
            this.right = null;
            this.value = value;
        }

        internal bool IsLeaf
        {
            get
            {
                return this.left == null && this.right == null;
            }
        }
    }
}