namespace _06.LinkedStack_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LinkedStack;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void Push1Element()
        {
            LinkedStack<int> test = new LinkedStack<int>();
            test.Push(1);
            Assert.AreEqual(1, test.Pop());
        }

        [TestMethod]
        public void Push100Elements_ShouldGiveCorrectCount()
        {
            LinkedStack<int> test = new LinkedStack<int>();
            for (int i = 0; i < 100; i++)
            {
                test.Push(i);
            }
            Assert.AreEqual(100, test.Count);
        }

        [TestMethod]
        public void PushPop10Elements_ShouldGiveCorrectValues()
        {
            LinkedStack<int> test = new LinkedStack<int>();
            for (int i = 1; i <= 10; i++)
            {
                test.Push(i);
            }

            for (int i = 10; i >= 1; i--)
            {
                int actual = test.Pop();
                Assert.AreEqual(i, actual);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopEmptyStack_ShouldThrowException()
        {
            LinkedStack<int> test = new LinkedStack<int>();
            test.Pop();
        }

        [TestMethod]
        public void Push77Elements_ShouldGiveCorrectPop()
        {
            LinkedStack<int> test = new LinkedStack<int>();
            for (int i = 1; i <= 77; i++)
            {
                test.Push(i);
            }

            int actual = test.Pop();
            Assert.AreEqual(77, actual);
        }
    }
}
