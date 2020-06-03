using Xunit;

namespace BinarySearchTree.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void CanFindMaximumValue()
        {
            // arrange
            var tree = new Tree<string>("j");
            tree.Add("f");
            tree.Add("a");
            tree.Add("h");
            tree.Add("k");
            tree.Add("z");

            // act
            string maxValue = tree.GetMax();

            // assert
            Assert.Equal("z", maxValue);
        }

        [Fact]
        public void CanFindMinValue()
        {
            // arrange
            var tree = new Tree<string>("j");
            tree.Add("f");
            tree.Add("a");
            tree.Add("h");
            tree.Add("k");
            tree.Add("z");

            // act
            string maxValue = tree.GetMin();

            // assert
            Assert.Equal("a", maxValue);
        }
    }
}
