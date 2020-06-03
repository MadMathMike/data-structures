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

        // TODO: Since the nodes allow for arbitrary construction, there is a risk that an object cycle can be created
        // Consider altering the setters to prevent an object cycle from being created in the first place

        // NOTE: These read methods are all depth-first traversals
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

        public IEnumerable<T> ReadPreOrder()
        {
            var values = new List<T>();

            void GetValuesInOrder(Node<T> node)
            {
                values.Add(node.Val);

                if(node.Left != null)
                    GetValuesInOrder(node.Left);

                if(node.Right != null)
                    GetValuesInOrder(node.Right);
            }

            GetValuesInOrder(this);

            return values;
        }

        public IEnumerable<T> ReadPostOrder()
        {
            var values = new List<T>();

            void GetValuesInOrder(Node<T> node)
            {
                if(node.Left != null)
                    GetValuesInOrder(node.Left);

                if(node.Right != null)
                    GetValuesInOrder(node.Right);
                    
                values.Add(node.Val);
            }

            GetValuesInOrder(this);

            return values;
        }
    }
}
