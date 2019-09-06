using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        private Node<T> lastNode;
        private Node<T> firstNode;

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
        /// Enqueue
        /// </summary>
        /// <param name="obj"></param>
        public void Enqueue(T obj)
        {
            Node<T> element = new Node<T>(obj);

            if (this.firstNode == null)
            {
                this.firstNode = element;
            }
            else
            {
                element.Prev = this.lastNode;
                this.lastNode.Next = element;
            }

            this.lastNode = element;
            this.Count++;
        }

        /// <summary>
        /// Dequeue
        /// </summary>
        /// <returns>first element</returns>
        public T Dequeue()
        {
            Node<T> element = this.firstNode;

            if (this.IsEmpty)
            {
                throw new Exception("Queue is empty");
            }

            if (this.Count == 1)
            {
                this.firstNode = null;
            }
            else
            {
                this.firstNode = this.firstNode.Next;
            }

            this.Count--;
            return element.Value;
        }

        /// <summary>
        /// Peek
        /// </summary>
        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new Exception("Queue is empty");
            }

            return this.firstNode.Value;
        }

        public bool Contains(T obj)
        {
            if (this.IsEmpty)
            {
                return false;
            }

            Node<T> element = this.firstNode;
            while (element != null)
            {
                if (element.Value.Equals(obj))
                {
                    return true;
                }

                element = element.Next;
            }

            return false;
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
        /// IEnumerable<T> implementation
        /// </summary>
        /// <returns>IEnumerator<T></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(firstNode);
        }
        /// <summary>
        /// IEnumerable implementation
        /// </summary>
        ///  <returns>IEnumerator<</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
