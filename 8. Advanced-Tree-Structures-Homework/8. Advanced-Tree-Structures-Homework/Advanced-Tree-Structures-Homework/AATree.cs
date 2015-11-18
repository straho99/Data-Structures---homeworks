namespace Advanced_Tree_Structures_Homework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class AATree<T> : IEnumerable<T> where T : IComparable
    {
        internal AATreeNode<T> root;

        public AATree(T value)
        {
            this.root = new AATreeNode<T>(value);
        }

        public void Add(T value)
        {
            this.root = this.Insert(value, this.root);
        }

        public bool Remove(T value)
        {
            return this.Delete(value, ref this.root);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return GetInOrderEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private AATreeNode<T> Skew(AATreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.left == null)
            {
                return node;
            }
            else if (node.left.level == node.level)
            {
                var tempNode = node.left;
                node.left = tempNode.right;
                tempNode.right = node;
                return tempNode;
            }
            else
            {
                return node;
            }
        }

        private AATreeNode<T> Split(AATreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.right == null || (node.right.right == null))
            {
                return node;
            }
            else if (node.level == node.right.right.level)
            {
                var tempNode = node.right;
                node.right = tempNode.left;
                tempNode.left = node;
                tempNode.level++;
                return tempNode;
            }
            else
            {
                return node;
            }
        }

        private AATreeNode<T> Insert(T value, AATreeNode<T> rootNode)
        {
            if (rootNode == null)
            {
                return new AATreeNode<T>(value);
            }
            else if (value.CompareTo(rootNode.value) < 0)
            {
                rootNode.left = Insert(value, rootNode.left);
            }
            else if (value.CompareTo(rootNode.value) > 0)
            {
                rootNode.right = Insert(value, rootNode.right);
            }

            rootNode = this.Skew(rootNode);
            rootNode = this.Split(rootNode);

            return rootNode;
        }

        private AATreeNode<T> Successor(AATreeNode<T> node)
        {
            var currentNode = node.right;
            while (currentNode.left != null)
            {
                currentNode = currentNode.left;
            }
            return currentNode;
        }

        private AATreeNode<T> Predecessor(AATreeNode<T> node)
        {
            var currentNode = node.left;
            while (currentNode.right != null)
            {
                currentNode = currentNode.right;
            }
            return currentNode;
        }

        private bool Delete(T value, ref AATreeNode<T> rootNode)
        {
            if (rootNode == null)
            {
                return true;
            }
            else if (value.CompareTo(rootNode.value) > 0)
            {
                Delete(value, ref rootNode.right);
            }
            else if (value.CompareTo(rootNode.value) < 0)
            {
                Delete(value, ref rootNode.left);
            }
            else
            {
                if (rootNode.IsLeaf)
                {
                    rootNode.left = null;
                    rootNode.right = null;
                    rootNode = null;
                    return true;
                }
                else if (rootNode.left == null)
                {
                    var tempNode = this.Successor(rootNode);
                    Delete(tempNode.value, ref rootNode.right);
                    rootNode.value = tempNode.value;
                }
                else
                {
                    var tempNode = this.Predecessor(rootNode);
                    Delete(tempNode.value, ref rootNode.left);
                    rootNode.value = tempNode.value;
                }
            }

            rootNode = this.DecreaseLevel(rootNode);
            rootNode = this.Skew(rootNode);
            rootNode.right = this.Skew(rootNode.right);

            if (rootNode.right != null)
            {
                rootNode.right.right = this.Skew(rootNode.right.right);
            }

            rootNode = this.Split(rootNode);
            rootNode.right = this.Split(rootNode.right);

            return true;
        }

        private AATreeNode<T> DecreaseLevel(AATreeNode<T> node)
        {
            int leftLevel = node.left == null ? 0 : 1;
            int rightLevel = node.right == null ? 0 : 1;
            int shouldBeLevel = Math.Min(leftLevel, rightLevel) + 1;
            if (shouldBeLevel < node.level)
            {
                node.level = shouldBeLevel;
                if (shouldBeLevel < node.right.level)
                {
                    node.right.level = shouldBeLevel;
                }
            }

            return node;
        }

        private IEnumerator<T> GetInOrderEnumerator()
        {
            return new AATreeInOrderEnumerator<T>(this);
        }
    }

    internal class AATreeInOrderEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private AATreeNode<T> current;
        private AATree<T> tree;
        internal Queue<AATreeNode<T>> traverseQueue;

        public AATreeInOrderEnumerator(AATree<T> tree)
        {
            this.tree = tree;

            //Build queue
            traverseQueue = new Queue<AATreeNode<T>>();
            visitNode(this.tree.root);
        }

        private void visitNode(AATreeNode<T> node)
        {
            if (node == null)
                return;
            else
            {
                visitNode(node.left);
                traverseQueue.Enqueue(node);
                visitNode(node.right);
            }
        }

        public T Current
        {
            get { return current.value; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            current = null;
            tree = null;
        }

        public void Reset()
        {
            current = null;
        }

        public bool MoveNext()
        {
            if (traverseQueue.Count > 0)
                current = traverseQueue.Dequeue();
            else
                current = null;

            return (current != null);
        }
    }
}
