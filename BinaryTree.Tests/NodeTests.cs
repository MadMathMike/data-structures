using System;
using System.Collections.Generic;
using Xunit;

namespace BinaryTree.Tests
{
    public class NodeTests
    {
        readonly Node<string> TestTree;

        public NodeTests()
        {
            var root = new Node<string>("j"); 
            // left sub-tree
            root.Left = new Node<string>("f");
            root.Left.Left = new Node<string>("a");
            root.Left.Right = new Node<string>("h");
            // right sub-tree
            root.Right = new Node<string>("k");
            root.Right.Right = new Node<string>("z");

            TestTree = root;
        }

        [Fact]
        public void CanTraverseInOrder()
        {
            // act
            IEnumerable<string> values = TestTree.ReadInOrder();

            // assert
            Assert.Equal(new []{"a", "f", "h", "j", "k", "z"}, values);
        }

        [Fact]
        public void CanTraversePreOrder()
        {
            // act
            IEnumerable<string> values = TestTree.ReadPreOrder();

            // assert
            Assert.Equal(new []{"j", "f", "a", "h", "k", "z"}, values);
        }

        [Fact]
        public void CanTraversePostOrder()
        {
            // act
            IEnumerable<string> values = TestTree.ReadPostOrder();

            // assert
            Assert.Equal(new []{"a", "h", "f", "z", "k", "j"}, values);
        }

        [Fact]
        public void CanTraverseTopToBottom()
        {
            // act
            IEnumerable<string> values = TestTree.ReadTopToBottom();

            // assert
            Assert.Equal(new []{"j", "f", "k", "a", "h", "z"}, values);
        }
    }
}
