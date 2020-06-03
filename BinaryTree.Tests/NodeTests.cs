using System;
using System.Collections.Generic;
using Xunit;

namespace BinaryTree.Tests
{
    public class NodeTests
    {
        [Fact]
        public void CanTraverseInOrder()
        {
            // arrange 
            var root = new Node<string>("j"); 
            // left sub-tree
            root.Left = new Node<string>("f");
            root.Left.Left = new Node<string>("a");
            root.Left.Right = new Node<string>("h");
            // right sub-tree
            root.Right = new Node<string>("k");
            root.Right.Right = new Node<string>("z");

            // act
            IEnumerable<string> values = root.ReadInOrder();

            // assert
            Assert.Equal(new []{"a", "f", "h", "j", "k", "z"}, values);
        }
    }
}
