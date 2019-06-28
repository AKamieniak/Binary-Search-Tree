using System;

namespace BinarySearchTrees.Library.Abstractions
{
    public interface ITree<T> where T : IComparable
    {
        void Insert(T value);
        bool TryInsert(T value, out Node<T> bst);
        bool Search(T value);
        bool Remove(T value);
    }
}
