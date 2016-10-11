using System;
using NUnit.Framework;

namespace TreeTraversal
{
    [TestFixture]
    public class NodeTests
    {
        public void Node_ShouldCallConstructor()
        {
            // Arrange
            var node = new Node<Int32>(10);
            var node2 = new Node<Int32>(node.Value + 1);


            // Act

            // Assert
        }

        [Test]
        public void SumTest()
        {
            var node = new Node<Int32>(23, new []
            {
                new Node<Int32>(10), 
                new Node<Int32>(10), 
            });
            //var result = NodeExtensions.Sum(node, false);
            var result = node.Sum();

            Assert.That(result, Is.EqualTo(43));
        }

        [Test]
        public void SumAsStringTest()
        {
            var node = new Node<String>("Hello", new[]
            {
                new Node<String>(" World"),
                new Node<String>("!"),
            });
            //var result = NodeExtensions.Sum(node, false);
            var result = node.Sum((sum, child) => sum + child.Value);

            Assert.That(result, Is.EqualTo("Hello World!"));
        }

    }
}