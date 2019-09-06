namespace CustomBinarySearchTree
{
    internal class Node<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Left property
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right property
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Value property
        /// </summary>
        public T Value { get; set; }
    }
}
