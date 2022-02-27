using LinkedLists.classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListTests
{
    [TestClass]
    public class ListTest
    {
        [TestMethod]
        public void AddToFront_AddObjectToFrontOfList_ObjectInsertedAtFront()
        {
            // Arrange
            var list = new LinkedList();

            // Act
            list.AddToFront("5");
            list.AddToFront("2");
            list.AddToFront("3");
            list.AddToFront("4");

            // Assert
            Assert.IsFalse(list.Empty);
        }

        [TestMethod]
        public void AddToEnd_AddObjectToEndOfList_ObjectInsertedAtEnd()
        {
            // Arrange
            var list = new LinkedList();

            // Act
            list.AddToEnd("5");
            list.AddToEnd("2");
            list.AddToEnd("3");
            list.AddToEnd("4");

            // Assert
            Assert.IsFalse(list.Empty);
        }

        [TestMethod]
        public void Add_ObjectInsertedAtIndex_ObjectInserted()
        {
            // Arrange
            var list = new LinkedList();
            int testIndex = 2;

            // Act
            list.AddToFront("2");
            list.AddToFront("7");
            list.AddToFront("8");
            list.AddToFront("9");
            var result = list.Add(2, "5");
            var isInList = list.Get(testIndex);

            // Assert
            Assert.AreEqual(isInList, result);
        }

        [TestMethod]
        public void Remove_ObjectRemovedFromList_ObjectRemoved()
        {
            // Arrange
            var list = new LinkedList();
            int testIndex = 2;

            // Act
            list.AddToFront("2");
            list.AddToFront("7");
            list.AddToFront("8");
            list.AddToFront("9");
            var nodeDate = list.Get(testIndex);
            list.Remove(testIndex);
            var result = list.IndexOf(nodeDate);

            // Assert
            Assert.AreNotEqual(nodeDate, result);
        }
    }
}