using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomBinarySearchTree
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        private IComparer<T> comparer;
        private Node<T> firstNode;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryTree()
        {
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparer"></param>
        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Count autoproperty
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// IsEmpty property
        /// </summary>
        public bool IsEmpty
        {
            get { return this.Count == 0; }
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(T obj)
        {
            if (this.firstNode == null)
            {
                this.firstNode = new Node<T>(obj);
            }
            else
            {
                Node<T> newNode = this.firstNode;
                while (newNode != null)
                {
                    if (comparer.Compare(obj, newNode.Value) < 0)
                    {
                        if (newNode.Left == null)
                        {
                            newNode.Left = new Node<T>(obj);
                            break;
                        }

                        newNode = newNode.Left;
                    }
                    else if (comparer.Compare(obj, newNode.Value) > 0)
                    {
                        if (newNode.Right == null)
                        {
                            newNode.Right = new Node<T>(obj);
                            break;
                        }

                        newNode = newNode.Right;
                    }
                    else
                    {
                        throw new Exception("This element is already exist");
                    }
                }
            }

            this.Count++;
        }

        /// <summary>
        /// Check for item existence in tree
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True or false</returns>
        public bool Contains(T obj)
        {
            Node<T> newNode = this.Search(obj).Item2;
            if (newNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Delete of item
        /// </summary>
        /// <param name="obj"></param>
        public void Delete(T obj)
        {
            if (this.Count == 0)
            {
                throw new Exception("Tree is empty");
            }

            Node<T> nodeToDelete = this.Search(obj).Item2;
            Node<T> parent = this.Search(obj).Item1;

            if (nodeToDelete == null)
            {
                throw new Exception("Element is not found");
            }

            if (parent == null)
            {
                this.firstNode = nodeToDelete.Right;
                if (nodeToDelete.Left != null)
                {
                    Node<T> node = this.firstNode;
                    while (true)
                    {
                        if (node.Left != null)
                        {
                            node = node.Left;
                        }
                        else
                        {
                            break;
                        }
                    }

                    node.Left = nodeToDelete.Left;
                }

                this.Count--;
                return;
            }

            if (nodeToDelete.Right == null && nodeToDelete.Left == null)
            {
                if (parent.Left == nodeToDelete)
                {
                    parent.Left = null;
                }
                else if (parent.Right == nodeToDelete)
                {
                    parent.Right = null;
                }
            }
            else if (nodeToDelete.Left != null && nodeToDelete.Right == null)
            {
                parent.Right = nodeToDelete.Left;
            }
            else if (nodeToDelete.Left == null && nodeToDelete.Right != null)
            {
                parent.Right = nodeToDelete.Right;
            }
            else if (nodeToDelete.Left != null && nodeToDelete.Right != null)
            {
                T smallestValOfR = default(T);
                Node<T> smallestOfRight = nodeToDelete.Right;
                while (smallestOfRight != null)
                {
                    if (smallestOfRight.Left != null)
                    {
                        smallestOfRight = smallestOfRight.Left;
                    }
                    else
                    {
                        break;
                    }
                }

                if (parent.Left == nodeToDelete)
                {
                    smallestValOfR = smallestOfRight.Value;
                    this.Delete(smallestOfRight.Value);
                    parent.Left.Value = smallestValOfR;
                }
                else if (parent.Right == nodeToDelete)
                {
                    smallestValOfR = smallestOfRight.Value;
                    this.Delete(smallestOfRight.Value);
                    parent.Right.Value = smallestValOfR;
                }

                this.Count++;
            }

            this.Count--;
        }

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            this.firstNode = null;
            this.Count = 0;
        }

        /// <summary>
        /// Post-order Enumerator
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable PostOrder()
        {
            return PostOrder(firstNode);
        }

        /// <summary>
        /// In-Order Enumerator
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable InOrder()
        {
            return InOrder(firstNode);
        }

        /// <summary>
        /// Get Enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator GetEnumerator()
        {
            return PreOrder(firstNode).GetEnumerator();
        }

        /// <summary>
        /// IEnumerable<T> i,plementation
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        /// <summary>
        /// Search item in tree
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Node with parent</returns>
        private (Node<T>, Node<T>) Search(T obj)
        {
            if (this.Count == 0)
            {
                return (null, null);
            }

            Node<T> parent = null;
            Node<T> nodeToDelete = this.firstNode;
            while (nodeToDelete != null)
            {
                if (comparer.Compare(obj, nodeToDelete.Value) == 0)
                {
                    break;
                }

                parent = nodeToDelete;

                if (comparer.Compare(obj, nodeToDelete.Value) < 0)
                {
                    if (nodeToDelete.Left != null)
                    {
                        nodeToDelete = nodeToDelete.Left;
                    }
                    else
                    {
                        nodeToDelete = null;
                    }
                }
                else if (comparer.Compare(obj, nodeToDelete.Value) > 0)
                {
                    if (nodeToDelete.Right != null)
                    {
                        nodeToDelete = nodeToDelete.Right;
                    }
                    else
                    {
                        nodeToDelete = null;
                    }
                }
            }

            return (parent, nodeToDelete);
        }

        private IEnumerable InOrder(Node<T> node)
        {
            if (this.Count == 0)
            {
                throw new Exception("Tree is empty");
            }

            if (node.Left != null)
            {
                foreach (var n in InOrder(node.Left))
                {
                    yield return n;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var n in InOrder(node.Right))
                {
                    yield return n;
                }
            }
        }

        private IEnumerable PostOrder(Node<T> node)
        {
            if (this.Count == 0)
            {
                throw new Exception("Tree is empty");
            }

            if (node.Left != null)
            {
                foreach (var n in PostOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PostOrder(node.Right))
                {
                    yield return n;
                }
            }

            yield return node.Value;
        }

        private IEnumerable PreOrder(Node<T> node)
        {
            if (this.Count == 0)
            {
                throw new Exception("Tree is empty");
            }

            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var n in PreOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PreOrder(node.Right))
                {
                    yield return n;
                }
            }
        }
    }
}
