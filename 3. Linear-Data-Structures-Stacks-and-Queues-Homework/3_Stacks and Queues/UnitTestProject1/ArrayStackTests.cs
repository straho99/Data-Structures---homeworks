using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayStack;

[TestClass]
public class ArrayStackTests
{
    [TestMethod]
    public void Push_ShouldAddElement()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act
        stack.Push(5);

        // Assert
        Assert.AreEqual(1, stack.Count);
    }

    [TestMethod]
    public void PushPop_ShouldWorkCorrectly()
    {
        // Arrange
        var stack = new ArrayStack<string>();
        var element = "some value";

        // Act
        stack.Push(element);
        var elementFromStack = stack.Pop();

        // Assert
        Assert.AreEqual(0, stack.Count);
        Assert.AreEqual(element, elementFromStack);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Pop_EmptyStack_ThrowsException()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act
        stack.Pop();

        // Assert: expect and exception
    }

    [TestMethod]
    public void PushPop1000Elements_ShouldWorkCorrectly()
    {
        // Arrange
        var stack = new ArrayStack<int>();
        int numberOfElements = 1000;

        // Act
        for (int i = 1; i <= numberOfElements; i++)
        {
            stack.Push(i);
        }

        // Assert
        for (int i = numberOfElements; i > 0; i--)
        {
            Assert.AreEqual(numberOfElements, stack.Count);
            var element = stack.Pop();
            Assert.AreEqual(i, element);
            Assert.AreEqual(numberOfElements - (numberOfElements - i) - 1, stack.Count);
            numberOfElements--;
        }
    }

    [TestMethod]
    public void Push500Elements_ToArray_ShouldWorkCorrectly()
    {
        // Arrange
        var array = Enumerable.Range(1, 500).ToArray();
        var stack = new ArrayStack<int>();

        // Act
        for (int i = 0; i < array.Length; i++)
        {
            stack.Push(array[i]);
        }
        var arrayFromStack = stack.ToArray();

        // Assert
        CollectionAssert.AreEqual(array, arrayFromStack);
    }

    [TestMethod]
    public void InitialCapacity1_PushPop20Elements_ShouldWorkCorrectly()
    {
        // Arrange
        int elementsCount = 20;
        int initialCapacity = 1;

        // Act
        var stack = new ArrayStack<int>(initialCapacity);
        for (int i = 0; i < elementsCount; i++)
        {
            stack.Push(i);
        }

        // Assert
        Assert.AreEqual(elementsCount, stack.Count);
        for (int i = elementsCount - 1; i >= 0; i--)
        {
            var elementFromStack = stack.Pop();
            Assert.AreEqual(i, elementFromStack);
        }
        Assert.AreEqual(0, stack.Count);
    }
}
