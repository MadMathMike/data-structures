using System;
using System.Collections.Generic;
using System.Linq;

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
                if (node.Left != null)
                    GetValuesInOrder(node.Left);

                values.Add(node.Val);

                if (node.Right != null)
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

                if (node.Left != null)
                    GetValuesInOrder(node.Left);

                if (node.Right != null)
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
                if (node.Left != null)
                    GetValuesInOrder(node.Left);

                if (node.Right != null)
                    GetValuesInOrder(node.Right);

                values.Add(node.Val);
            }

            GetValuesInOrder(this);

            return values;
        }

        public IEnumerable<T> ReadTopToBottom()
        {
            return
                from i in Enumerable.Range(1, this.CalculateDepth())
                let valuesAtLevel = ReadAtLevel(this, 1, i)
                from value in valuesAtLevel
                select value;
        }

        public IEnumerable<T> ReadAtLevel(int level)
        {
            return ReadAtLevel(this, 1, level, null);
        }

        private int CalculateDepth()
        {
            int GetDepth(Node<T> node, int level = 0)
                => node == null
                    ? level
                    : Math.Max(
                        GetDepth(node.Left, level), 
                        GetDepth(node.Right, level)
                    ) + 1;

            return GetDepth(this);
        }

        private static IEnumerable<T> ReadAtLevel(Node<T> node, int currentLevel, int targetLevel, List<T> values = null)
        {
            if (currentLevel > targetLevel)
                throw new Exception("wtf!?");

            values ??= new List<T>();

            if (node == null)
                return values;

            if (currentLevel == targetLevel)
                values.Add(node.Val);
            else
            {
                ReadAtLevel(node.Left, currentLevel + 1, targetLevel, values);
                ReadAtLevel(node.Right, currentLevel + 1, targetLevel, values);
            }

            return values;
        }
    }
}
