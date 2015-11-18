namespace _06.LinkedStack_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LinkedQueue;
    using System.Linq;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void Enqueue1Element()
        {
            LinkedQueue<int> test = new LinkedQueue<int>();
            test.Enqueue(1);
            Assert.AreEqual(1, test.Dequeue());
        }

        [TestMethod]
        public void Enqueue100Elements_ShouldGiveCorrectCount()
        {
            LinkedQueue<int> test = new LinkedQueue<int>();
            for (int i = 0; i < 100; i++)
            {
                test.Enqueue(i);
            }
            Assert.AreEqual(100, test.Count);
        }

        [TestMethod]
        public void EnqueDeque10Elements_ShouldGiveCorrectValues()
        {
            LinkedQueue<int> test = new LinkedQueue<int>();
            for (int i = 1; i <= 10; i++)
            {
                test.Enqueue(i);
            }

            for (int i = 1; i <= 10; i++)
            {
                int actual = test.Dequeue();
                Assert.AreEqual(i, actual);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequesEmptyQueue_ShouldThrowException()
        {
            LinkedQueue<int> test = new LinkedQueue<int>();
            test.Dequeue();
        }

        [TestMethod]
        public void Enque77Elements_ShouldGiveCorrectDeque()
        {
            LinkedQueue<int> test = new LinkedQueue<int>();
            for (int i = 1; i <= 77; i++)
            {
                test.Enqueue(i);
            }

            int actual = test.Dequeue();
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Enqueue500Elements_ToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var array = Enumerable.Range(1, 500).ToArray();
            var queue = new LinkedQueue<int>();

            // Act
            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }
            var arrayFromQueue = queue.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromQueue);
        }
    }
}