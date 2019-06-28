using System;
using Newtonsoft.Json;

namespace BinarySearchTrees.Library.Abstractions
{
    public abstract class TreeBase<T> : ITree<T> where T : IComparable
    {
        protected Node<T> _root;
        protected int _count;
        private int _subtreeCount;

        public virtual void Insert(T value)
        {
            if (_root == null)
            {
                _root = new Node<T>(value);
                _count++;
            }
            else
            {
                var node = _root;

                while (node != null)
                {
                    if (value.CompareTo(node.Value) == 0)
                    {
                        throw new ArgumentException("Value already exists in the tree");
                    }
                    else if (value.CompareTo(node.Value) > 0)
                    {
                        if (node.RightChild == null)
                        {
                            node.RightChild = new Node<T>(value);
                            _count++;
                            break;
                        }

                        node = node.RightChild;
                    }
                    else if (value.CompareTo(node.Value) < 0)
                    {
                        if (node.LeftChild == null)
                        {
                            node.LeftChild = new Node<T>(value);
                            _count++;
                            break;
                        }

                        node = node.LeftChild;
                    }
                }
            }
        }

        public virtual bool TryInsert(T value, out Node<T> bst)
        {
            try
            {
                Insert(value);
                bst = _root;

                return true;
            }
            catch (Exception e)
            {
                bst = _root;

                return false;
            }
        }

        public bool Search(T value)
        {
            if (_root == null)
            {
                return false;
            }

            var node = _root;

            while (node != null)
            {
                if (value.CompareTo(node.Value) == 0)
                {
                    return true;
                }
                else if (value.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
            }

            return false;
        }

        public virtual bool Remove(T value)
        {
            Validate(value, out bool? statement);

            if (statement != null)
            {
                return (bool) statement;
            }

            var node = _root;

            while (node != null)
            {
                if (value.CompareTo(node.Value) < 0)
                {
                    if (node.LeftChild == null)
                    {
                        return false;
                    }
                    else if (value.CompareTo(node.LeftChild.Value) == 0)
                    {
                        if (node.LeftChild.LeftChild == null && node.LeftChild.RightChild == null)
                        {
                            _count--;
                            node.LeftChild = null;
                            
                            return true;
                        }
                        else if (node.LeftChild.LeftChild != null && node.LeftChild.RightChild != null)
                        {
                            var parent = node.LeftChild;
                            var startNode = node.LeftChild.RightChild;

                            while (startNode.LeftChild != null)
                            {
                                parent = startNode;
                                startNode = startNode.LeftChild;
                            }                                                  

                            if (parent.LeftChild == startNode)
                            {
                                parent.LeftChild = null;
                            }
                            else
                            {
                                parent.RightChild = null;
                            }

                            node.LeftChild.Value = startNode.Value;
                            _count--;

                            return true;
                        }
                        else 
                        {
                            if (node.LeftChild.LeftChild != null)
                            {
                                node.LeftChild = node.LeftChild.LeftChild;
                                _count--;

                                return true;
                            }
                            else
                            {
                                node.LeftChild = node.LeftChild.RightChild;
                                _count--;
                                
                                return true;
                            }
                        }
                    }

                    node = node.LeftChild;
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    if (node.RightChild == null)
                    {
                        return false;
                    }
                    if (value.CompareTo(node.RightChild.Value) == 0)
                    {
                        if (node.RightChild.LeftChild == null && node.RightChild.RightChild == null)
                        {
                            node.RightChild = null;
                            _count--;                       

                            return true;
                        }
                        else if (node.RightChild.LeftChild != null && node.RightChild.RightChild != null)
                        {
                            var parent = node.RightChild;
                            var startNode = node.RightChild.RightChild;

                            while (startNode.LeftChild != null)
                            {
                                parent = startNode;
                                startNode = startNode.LeftChild;
                            }

                            if (parent.LeftChild == startNode)
                            {
                                parent.LeftChild = null;
                            }
                            else
                            {
                                parent.RightChild = null;
                            }

                            node.RightChild.Value = startNode.Value;
                            _count--;

                            return true;
                        }
                        else
                        {
                            if (node.RightChild.LeftChild != null)
                            {
                                node.RightChild = node.RightChild.LeftChild;
                                _count--;

                                return true;
                            }
                            else
                            {
                                node.RightChild = node.RightChild.RightChild;
                                _count--;

                                return true;
                            }
                        }
                    }

                    node = node.RightChild;
                }
            }

            return false;
        }

        public virtual bool RemoveSubtree(T value)
        {
            Validate(value, out bool? statement);

            if (statement != null)
            {
                return (bool) statement;
            }

            var node = _root;

            while (node != null)
            {
                if (value.CompareTo(node.Value) == 0)
                {
                    _root = null;
                    _count = 0;

                    return true;
                }
                else if (value.CompareTo(node.Value) < 0)
                {
                    if (node.LeftChild == null)
                    {
                        return false;
                    }
                    else if (value.CompareTo(node.LeftChild.Value) == 0)
                    {
                        CountNodes(node.LeftChild);
                        _count = _count - _subtreeCount;
                        node.LeftChild = null;
                        _subtreeCount = 0;

                        return true;
                    }

                    node = node.LeftChild;
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    if (node.RightChild == null)
                    {
                        return false;
                    }
                    if (value.CompareTo(node.RightChild.Value) == 0)
                    {
                        CountNodes(node.RightChild);
                        _count = _count - _subtreeCount;
                        node.RightChild = null;
                        _subtreeCount = 0;

                        return true;
                    }

                    node = node.RightChild;
                }
            }

            return false;

        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(_root);
        }

        private void CountNodes(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            _subtreeCount++;
            CountNodes(root.LeftChild);
            CountNodes(root.RightChild);
        }

        private void Validate(T value, out bool? statement)
        {
            statement = null;

            if (_root == null)
            {
                statement = false;
                return;
            }
            else if (_count == 1)
            {
                if (value.CompareTo(_root.Value) == 0)
                {
                    _count--;
                    _root = null;

                    statement = true;
                    return;
                }

                statement = false;
                return;
            }
        }
    }
}
