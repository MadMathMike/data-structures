using System;

namespace BinarySearchTree
{
    class Node<T> where T : IComparable<T>
    {
        public Node(T val)
        {
            Val = val;
        }

        public T Val { get; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        public void AddChild(T val)
        {
            void AddChild(Node<T> node)
            {
                int comparison = val.CompareTo(node.Val);
                if(comparison == -1)
                {
                    if(node.Left == null)
                        node.Left = new Node<T>(val);
                    else
                        AddChild(node.Left);
                }
                if(comparison == 1)
                {
                    if(node.Right == null)
                        node.Right = new Node<T>(val);
                    else
                        AddChild(node.Right);
                }

                // TODO: consider throwing exception if the value already exists?
            }

            AddChild(this);
        }
    }
}
