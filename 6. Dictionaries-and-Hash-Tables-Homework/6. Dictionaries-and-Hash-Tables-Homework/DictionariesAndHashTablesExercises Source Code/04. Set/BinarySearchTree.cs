namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot add null value.");
            }

            this.root = Add(value, this.root, null);
            this.Count++;
        }

        public TreeNode<T> Find(T value)
        {
            TreeNode<T> currentNode = this.root;

            while (currentNode != null)
            {
                int comparison = value.CompareTo(currentNode.Value);
                if (comparison < 0)
                {
                    currentNode = currentNode.LeftNode;
                }
                else if (comparison > 0)
                {
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }

        public void Delete(T value)
        {
            TreeNode<T> nodeToDelete = Find(value);
            if (nodeToDelete == null)
            {
                return;
            }
            Delete(nodeToDelete);
            this.Count--;
        }

        private TreeNode<T> Add(T value, TreeNode<T> currentNode, TreeNode<T> parrentNode)
        {
            if (currentNode == null)
            {
                currentNode = new TreeNode<T>(value);
                currentNode.Parrent = parrentNode;
            }
            else
            {
                int comparison = value.CompareTo(currentNode.Value);
                if (comparison < 0)
                {
                    currentNode.LeftNode = Add(value, currentNode.LeftNode, currentNode);
                }
                else
                {
                    currentNode.RightNode = Add(value, currentNode.RightNode, currentNode);
                }
            }

            return currentNode;
        }

        private void Delete(TreeNode<T> node)
        {
            if (node.LeftNode != null && node.RightNode != null)
            {
                TreeNode<T> replacement = node.RightNode;
                while (replacement.LeftNode != null)
                {
                    replacement = replacement.LeftNode;
                }
                node.Value = replacement.Value;
                node = replacement;
            }

            TreeNode<T> theChild = node.LeftNode != null ? node.LeftNode : node.RightNode;
            if (theChild != null)
            {
                theChild.Parrent = node.Parrent;

                if (node.Parrent == null)
                {
                    this.root = theChild;
                }
                else
                {
                    if (node.Parrent.LeftNode == node)
                    {
                        node.Parrent.LeftNode = theChild;
                    }
                    else
                    {
                        node.Parrent.RightNode = theChild;
                    }
                }
            }
            else
            {
                if (node.Parrent == null)
                {
                    this.root = null;
                }
                else
                {
                    if (node.Parrent.LeftNode == node)
                    {
                        node.Parrent.LeftNode = null;
                    }
                    else
                    {
                        node.Parrent.RightNode = null;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
