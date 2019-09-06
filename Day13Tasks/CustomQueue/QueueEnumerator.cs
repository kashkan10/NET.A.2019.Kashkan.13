using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
    internal class QueueEnumerator<T> : IEnumerator<T>
    {
        private Node<T> firstnode;
        private Node<T> node;
        private bool isFirst;

        public QueueEnumerator(Node<T> node)
        {
            firstnode = node;
            this.node = node;
            isFirst = true;
        }

        public T Current
        {
            get
            {
                return node.Prev.Value;
            }
        }

        T IEnumerator<T>.Current => node.Value;

        object IEnumerator.Current => node;

        public bool MoveNext()
        {
            if (isFirst)
            {
                isFirst = false;
                return true;
            }

            if (node.Next != null)
            {
                node = node.Next;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            node = firstnode;
            isFirst = true;
        }

        public void Dispose()
        {
            firstnode = node = null;
        }
    }
}
