using System;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using RingSinglyLinkedList;

namespace RingSinglyLinkedListTests
{
    [TestFixture] // == [TestClass]
    public class RingSinglyLinkedListTests
    {
        [Test] // == [TestMethod]
        public void Contains_WithEmptyList_FalseReturned()
        {
            // Arrange
            var list = new RingSinglyLinkedList<int>();

            // Act
            var containsResult = list.Contains(1);
            
            // Assert
            Assert.AreEqual(false, containsResult);
        }
        
        [Test]
        public void Contains_With1CountList_TrueReturned() // ?
        {
            var list = new RingSinglyLinkedList<int>();
            list.Add(1);
            
            var containsResult = list.Contains(1);
            
            Assert.AreEqual(1,list.Count);
            Assert.AreEqual(true, containsResult);
        }

        [Test]
        public void Clear_WithNoEmptyList_ZeroCountReturned()
        {
            var list = new RingSinglyLinkedList<string>();
            
            list.Add("o");
            list.Add("n");
            list.Add("e");
            list.Clear();
            
            Assert.AreEqual(0,list.Count);
        }

        [Test]
        public void Add_WithEmptyList_ListWithOneElement()
        {
            var list = new RingSinglyLinkedList<char>();
            
            list.Add('q');
            var containsResult = list.Contains('q');
            
            Assert.AreEqual(1,list.Count);
            Assert.AreEqual(true, containsResult);
        }
        
        [Test]
        public void Add_WithOneSizeList_ListWithTwoElements()
        {
            var list = new RingSinglyLinkedList<char>();
            list.Add('w');
            
            list.Add('q');
            var containsResult = list.Contains('q');
            
            Assert.AreEqual(2,list.Count);
            Assert.AreEqual(true, containsResult);
        }

        [Test]
        public void Delete_WithEmptyList_FalseReturned()
        {
            var list = new RingSinglyLinkedList<int>();

            var deleteResult = list.Delete(1);
            
            Assert.AreEqual(false, deleteResult);
        }

        [Test]
        public void DeleteHead_WithOneSizeList_TrueReturned()
        {
            var list = new RingSinglyLinkedList<int>();
            list.Add(1);

            var deleteResult = list.Delete(1);
            
            Assert.AreEqual(true, deleteResult);
        }
        
        [Test]
        public void DeleteNoHead_WithMoreThanOneSizeList_TrueReturned()
        {
            var list = new RingSinglyLinkedList<int>();
            list.Add(0);
            list.Add(-1);
            list.Add(1);

            var deleteResult = list.Delete(1);
            
            Assert.AreEqual(true, deleteResult);
        }

        [Test]
        public void DeleteHead_WithMoreThanOneSizeList_TrueReturned()
        {
            var list = new RingSinglyLinkedList<int>();
            list.Add(0);
            list.Add(-1);
            list.Add(1);

            var deleteResult = list.Delete(0);
            
            Assert.AreEqual(true, deleteResult);
        }
        
        [Test]
        public void IEnumerator_WithNoEmptyList_ElementsReturned()
        {
            var list = new RingSinglyLinkedList<int>();
            list.Add(1);
            list.Add(0);
            list.Add(-1);
            
            var array = new int[] {1, 0, -1};
            var i = 0;
            
            foreach (var item in list)
            {
                Assert.AreEqual(array[i], item);
                i += 1;
            }
        }
    }
    
}