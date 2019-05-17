using System;

namespace Collections
{
    /// <summary>
    /// Represents a node 
    /// </summary>
    /// <typeparam name="T"></typeparam> Generic data.
    public class Node <T>
    {
        public T data;
        public Node<T> next;
        public Node<T> previous;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Node()
        {
            this.data = default(T);
            this.next = null;
            this.previous = null;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data"></param> The data.
        /// <param name="next"></param> The next node.
        /// <param name="previous"></param> The previous node.
        public Node(T data, Node<T> next, Node<T> previous)
        {
            this.data     = data;
            this.next     = next;
            this.previous = previous;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data"></param> The data.
        public Node(T data)
        {
            this.data = data;
            this.next = null;
            this.previous = null;
        }

        /// <summary>
        /// Creates a string of the node.
        /// </summary>
        /// <returns></returns> The string.
        public override String ToString()
        {
            return data.ToString();
        }

        /// <summary>
        /// Checks if the node is equal to another one.
        /// </summary>
        /// <param name="node"></param> The node to check against.
        /// <returns></returns>
        public bool Equals(Node<T> node)
        {
            return node.data.Equals(this.data);
        }

        /// <summary>
        /// Clones the node.
        /// </summary>
        /// <returns></returns> The cloned node.
        public Node<T> Clone()
        {
            return new Node<T>(this.data, this.next, this.previous);
        }
        
        /// <summary>
        /// Finalizes the node.
        /// </summary>
        public void Finalize()
        {
            data = default(T);
            next = null;
            previous = null;
        }
    }
}
