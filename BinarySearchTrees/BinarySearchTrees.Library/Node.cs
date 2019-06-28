using System;

namespace BinarySearchTrees.Library
{
    public class Node<T> : ICloneable where T : IComparable
    {
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        internal Node(T value)
        {
            Value = value;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
