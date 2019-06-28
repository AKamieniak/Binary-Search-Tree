using System;
using BinarySearchTrees.Library.Abstractions;

namespace BinarySearchTrees.Library
{
    public class DSWBalancedBinarySearchTree<T> : TreeBase<T> where T : IComparable
    {
        private Node<T> _backbone;

        public override void Insert(T value)
        {
            base.Insert(value);

            if (_count >= 3)
            {
                _root = DSW();
                _backbone = null;
            }
        }

        public override bool Remove(T value)
        {
            if (base.Remove(value))
            {
                if (_count >= 3)
                {
                    _root = DSW();
                    _backbone = null;
                }

                return true;
            }
            
            return false;
        }

        public override bool TryInsert(T value, out Node<T> bst)
        {
            if (base.TryInsert(value, out bst))
            {
                if (_count >= 3)
                {
                    _root = DSW();
                    _backbone = null;
                }

                return true;
            }

            return false;
        }

        public override bool RemoveSubtree(T value)
        {
            if (base.RemoveSubtree(value))
            {
                if (_count >= 3)
                {
                    _root = DSW();
                    _backbone = null;
                }

                return true;
            }

            return false;
        }

        private Node<T> DSW()
        {
            CreateBackbone();
            return CreateBalancedTree();
        }

        private void CreateBackbone()
        {
            var tmp = (Node<T>) _root.Clone();
            var node = _backbone;

            while (tmp.LeftChild != null || tmp.RightChild != null)
            {
                if (tmp.LeftChild != null)
                {
                    tmp = RightRotate(tmp);
                }
                else
                {
                    if (_backbone == null)
                    {
                        _backbone = new Node<T>(tmp.Value);
                        node = _backbone;
                    }
                    else
                    {                       
                        node.RightChild = new Node<T>(tmp.Value);
                        node = node.RightChild;
                    }

                    tmp = tmp.RightChild;
                }
            }

            node.RightChild = new Node<T>(tmp.Value);
        }

        private Node<T> CreateBalancedTree()
        {
            var m = Math.Pow(2, Math.Floor(Math.Log(_count + 1, 2) - 0.0001)) - 1;
            var firstPhase = (Node<T>) _backbone.Clone();

            for (var i = 0; i < _count - m; i++)
            {
                if (i == 0)
                {
                    firstPhase = LeftRotate(firstPhase);
                    continue;
                }

                firstPhase.RightChild = LeftRotate(firstPhase.RightChild);
                firstPhase = firstPhase.RightChild;
            }

            var balancedTree = (Node<T>) _backbone.RightChild.Clone();

            while (m > 1)
            {
                m = Math.Floor(m / 2.0 - 0.0001);

                for (var i = 0; i < m; i++)
                {
                    if (i == 0)
                    {
                        balancedTree = LeftRotate(balancedTree);
                        continue;
                    }

                    balancedTree.RightChild = LeftRotate(balancedTree.RightChild);
                    balancedTree = balancedTree.RightChild;
                }

                balancedTree = (Node<T>) _backbone.RightChild.RightChild.Clone();
                _backbone = _backbone.RightChild;
            }

            return balancedTree;
        }

        private static Node<T> LeftRotate(Node<T> parent)
        {
            if (parent.RightChild == null)
            {
                return parent;
            }

            var child = parent.RightChild;
            parent.RightChild = child.LeftChild;
            child.LeftChild = parent;

            return child;
        }

        private static Node<T> RightRotate(Node<T> parent)
        {
            var child = parent.LeftChild;
            parent.LeftChild = child.RightChild;
            child.RightChild = parent;

            return child;
        }
    }
}
