using System;

namespace BinarySearchTree
{
    public class Tree<T> where T : IComparable<T>, IEquatable<T>
    {
        readonly Node<T> _root;
        public Tree(T value)
        {
            _root = new Node<T>(value);
        }

        public void Add(T value)
        {
            _root.AddChild(value);
        }

        public T GetMax()
        {
            var node = _root;

            while(node.Right != null)
            {
                node = node.Right;
            }

            return node.Val;
        }

        public T GetMin()
        {
            var node = _root;

            while(node.Left != null)
            {
                node = node.Left;
            }

            return node.Val;
        }
    }
}
