namespace CustomQueue
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
        /// Prev property
        /// </summary>
        public Node<T> Prev { get; set; }

        /// <summary>
        /// Next property
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Value property
        /// </summary>
        public T Value { get; set; }
    }
}
