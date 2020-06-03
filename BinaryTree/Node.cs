using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Node<T>
    {
        public Node(T val)
        {
            Val = val;
        }

        public T Val { get; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public IEnumerable<T> ReadInOrder()
        {
            var values = new List<T>();

            void GetValuesInOrder(Node<T> node)
            {
                if(node.Left != null)
                    GetValuesInOrder(node.Left);

                values.Add(node.Val);

                if(node.Right != null)
                    GetValuesInOrder(node.Right);
            }

            GetValuesInOrder(this);

            return values;
        }
    }
}
