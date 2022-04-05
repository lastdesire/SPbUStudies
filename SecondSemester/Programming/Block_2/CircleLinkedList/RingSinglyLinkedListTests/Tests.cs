using System;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using RingSinglyLinkedList;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace RingSinglyLinkedListTests
{

    [TestFixture] // == [TestClass]
    public class RingSinglyLinkedListTests
    {
        [Test]
        //CircleList(IEnumerable<T> list)
        public void CircleList_WithNoEmptyList_CircleListWithElementsFromList()
        {
            var itemList = new List<int>();
            itemList.Add(10);
            itemList.Add(15);
            itemList.Add(19);

            var list = new CircleList<int>(itemList);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(true, list.Contains(10));
            Assert.AreEqual(true, list.Contains(15));
            Assert.AreEqual(true, list.Contains(19));
        }


        [Test]
        //AddAfter(CircleListNode<T> newNode, CircleListNode<T> current)
        public void AddAfterNode_WithEmptyList_ExceptionExpected()
        {
            var list = new CircleList<int>();
            var node = new CircleListNode<int>(5);
            try
            {
                list.AddAfter(node, list._head);
            }
            catch (Exception e)
            {
                var x = new ArgumentNullException();
                Assert.AreEqual(x.GetType(), e.GetType());
            }
        }

        [Test]
        //AddAfter(CircleListNode<T> newNode, CircleListNode<T> current)
        public void AddAfterNode_WithNoEmptyList_ListWithOneMoreElementAtTheEnd()
        {
            var list = new CircleList<int>();
            var node = new CircleListNode<int>(6);
            var node0 = new CircleListNode<int>(7);
            var node1 = new CircleListNode<int>(8);
            list.AddLast(5);

            list.AddAfter(node, list._head);
            list.AddAfter(node0, list._head.Next);
            list.AddAfter(node1, list._head.Next.Next);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(7, list._head.Next.Next.Data);
            Assert.AreEqual(8, list._head.Next.Next.Next.Data);
        }

        [Test]
        //AddAfter(CircleListNode<T> node, T value)
        public void AddAfterValue_WithEmptyList_ExceptionExpected()
        {
            var list = new CircleList<int>();
            try
            {
                list.AddAfter(list._head, 5);
            }
            catch (Exception e)
            {
                var x = new ArgumentNullException();
                Assert.AreEqual(x.GetType(), e.GetType());
            }
        }

        [Test]
        //AddAfter(CircleListNode<T> node, T value)
        public void AddAfterValue_WithNoEmptyList_ListWithOneMoreElementAtTheEnd()
        {
            var list = new CircleList<int>();
            list.AddLast(5);

            list.AddAfter(list._head, 6);
            list.AddAfter(list._head.Next, 7);
            list.AddAfter(list._head.Next.Next, 8);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(7, list._head.Next.Next.Data);
            Assert.AreEqual(8, list._head.Next.Next.Next.Data);

        }

        [Test]
        // AddBefore(CircleListNode<T> newNode, CircleListNode<T> current)
        public void AddBeforeNode_WithEmptyList_ExceptionExpected()
        {
            var list = new CircleList<int>();
            var node = new CircleListNode<int>(5);
            try
            {
                list.AddBefore(node, list._head);
            }
            catch (Exception e)
            {
                var x = new NullReferenceException();
                Assert.AreEqual(x.GetType(), e.GetType());
            }
        }

        [Test]
        // AddBefore(CircleListNode<T> newNode, CircleListNode<T> current)
        public void AddBeforeNode_WithOneElementList_TailIsNewNodeAndListWithOneMoreElement()
        {
            var list = new CircleList<int>();
            list.AddLast(5);
            var node = new CircleListNode<int>(6);
            list.AddBefore(node, list._head);
            Assert.AreEqual(node, list._tail);
            //Assert.AreEqual();
        }

        [Test]
        //AddBefore(CircleListNode<T> node, T value)
        public void AddBeforeValue_WithNoEmptyList_ListWithOneMoreElement()
        {
            var list = new CircleList<int>();
            list.AddLast(5);
            list.AddLast(6);

            list.AddBefore(list._head, 8);
            list.AddBefore(list._tail, 7);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(7, list._head.Next.Next.Data);
            Assert.AreEqual(8, list._tail.Data);
        }

        [Test]
        // AddFirst(CircleListNode<T> node)
        public void AddFirstNode_WithEmptyList_ListWithOneElement()
        {
            var list = new CircleList<char>();
            var node = new CircleListNode<char>('a');

            list.AddFirst(node);

            Assert.AreEqual('a', list._head.Data);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(list._head, list._head.Next);
        }

        [Test]
        public void AddFirstNode_WithNoEmptyList_ListWithOneMoreElement()
        {
            var list = new CircleList<int>();
            var node = new CircleListNode<int>(5);
            var newNode = new CircleListNode<int>(6);
            var newNode1 = new CircleListNode<int>(7);
            list.AddFirst(node);

            list.AddFirst(newNode);
            list.AddFirst(newNode1);

            Assert.AreEqual(7, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(5, list._tail.Data);
            Assert.AreEqual(list._tail, list._head.Next.Next);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void AddFirstValueThreeTimes_WithEmptyList_ListWithThreeMoreElements()
        {
            var list = new CircleList<int>();

            list.AddFirst(5);
            list.AddFirst(6);
            list.AddFirst(7);

            Assert.AreEqual(7, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(5, list._tail.Data);
            Assert.AreEqual(list._head, list._tail.Next);
            Assert.AreEqual(3, list.Count);
        }

        [Test] // == [TestMethod]
        public void Contains_WithEmptyList_FalseReturned()
        {
            // Arrange
            var list = new CircleList<int>();

            // Act
            var containsResult = list.Contains(1);

            // Assert
            Assert.AreEqual(false, containsResult);
        }

        [Test]
        public void Contains_With1CountList_TrueReturned() // ?
        {
            var list = new CircleList<int>();
            list.AddLast(1);

            var containsResult = list.Contains(1);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(true, containsResult);
        }

        [Test]
        public void Clear_WithNoEmptyList_ZeroCountReturned()
        {
            var list = new CircleList<string>();

            list.AddLast("o");
            list.AddLast("n");
            list.AddLast("e");
            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void AddLast_WithEmptyList_ListWithOneElement()
        {
            var list = new CircleList<char>();

            list.AddLast('q');
            var containsResult = list.Contains('q');

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(true, containsResult);
        }

        [Test]
        public void AddLast_WithOneSizeList_ListWithTwoElements()
        {
            var list = new CircleList<char>();
            list.AddLast('w');

            list.AddLast('q');
            var containsResult = list.Contains('q');

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(true, containsResult);
        }

        [Test]
        public void CopyTo_WithNoEmptyList_CopiedArray()
        {
            var list = new CircleList<int>();
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(8);
            var array = new int[10];
            array[0] = 5;
            list.CopyTo(array, 1);

            Assert.AreEqual(5, array[0]);
            Assert.AreEqual(6, array[1]);
            Assert.AreEqual(7, array[2]);
            Assert.AreEqual(8, array[3]);
            Assert.AreEqual(0, array[4]);
        }

        [Test]
        public void Equals_NoEmptyEqualLists_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);
            var newList = new CircleList<int>();
            newList.AddLast(5);

            var result = list.Equals(newList);

            Assert.AreEqual(true, result);

        }

        [Test]
        public void Equals_NoEmptyNoEqualLists_FalseReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);
            var newList = new CircleList<int>();
            newList.AddLast(6);

            var result = list.Equals(newList);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Equals_WithNoEmptyListAndNode_FalseReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);
            var node = new CircleListNode<int>(5);

            var result = list.Equals(node);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Find_WithEmptyList_NullReturned()
        {
            var list = new CircleList<char>();

            var result = list.Find('a');

            Assert.AreEqual(null, result);
        }

        [Test]
        public void Find_WithListWhichDoesntContainElement_NullReturned()
        {
            var list = new CircleList<char>();
            list.AddLast('b');

            var result = list.Find('a');

            Assert.AreEqual(null, result);
        }

        [Test]
        public void Find_WithListWhichContainElement_NodeReturned()
        {
            var list = new CircleList<char>();
            list.AddLast('a');
            list.AddLast('b');
            list.AddLast('b');

            var result = list.Find('b');

            Assert.AreEqual(list._head.Next, result);
        }

        [Test]
        public void Remove_WithEmptyList_FalseReturned()
        {
            var list = new CircleList<int>();

            var deleteResult = list.Remove(1);

            Assert.AreEqual(false, deleteResult);
        }

        [Test]
        public void RemoveHead_WithOneSizeList_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(1);

            var deleteResult = list.Remove(1);

            Assert.AreEqual(true, deleteResult);
        }

        [Test]
        public void RemoveNoHead_WithMoreThanOneSizeList_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(0);
            list.AddLast(-1);
            list.AddLast(1);

            var deleteResult = list.Remove(1);

            Assert.AreEqual(true, deleteResult);
        }

        [Test]
        public void RemoveHead_WithMoreThanOneSizeList_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(0);
            list.AddLast(-1);
            list.AddLast(1);

            var deleteResult = list.Remove(0);

            Assert.AreEqual(true, deleteResult);
        }

        [Test]
        public void RemoveNode_WithNoEmptyList_NodeDeleted()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var node = new CircleListNode<int>(9);
            list.AddLast(node);
            list.AddLast(10);

            list.RemoveNode(node);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(7, list._head.Next.Next.Data);
            Assert.AreEqual(8, list._head.Next.Next.Next.Data);
            Assert.AreEqual(list._tail, list._head.Next.Next.Next.Next);
            Assert.AreEqual(10, list._tail.Data);


        }

        [Test]
        public void RemoveFirst_WithEmptyList_NothingChanges()
        {
            var list = new CircleList<int>();

            list.RemoveFirst();

            Assert.AreEqual(null, list._head);
        }

        [Test]
        public void RemoveFirst_WithNoEmptyList_HeadDeleted()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            list.RemoveFirst();

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(6, list._head.Data);
            Assert.AreEqual(7, list._head.Next.Data);
            Assert.AreEqual(8, list._tail.Data);
        }

        [Test]
        public void RemoveLast_WithEmptyList_NothingChanges()
        {
            var list = new CircleList<int>();

            list.RemoveLast();

            Assert.AreEqual(null, list._tail);
        }

        [Test]
        public void RemoveLast_WithNoEmptyList_TailDeleted()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            list.RemoveLast();

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(7, list._tail.Data);
        }

        [Test]
        public void ToString_WithEmptyList_EmptyStrReturned()
        {
            var list = new CircleList<int>();

            var str = list.ToString();

            Assert.AreEqual("", str);
        }

        [Test]
        public void ToString_WithNoEmptyList_StrWithElementsReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var str = list.ToString();

            Assert.AreEqual("5 6 7 8", str);
        }

        [Test]
        public void FindLast_WithListWhichDoesntContainElement_NullReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var result = list.FindLast(9);

            Assert.AreEqual(null, result);
        }

        [Test]
        public void FindLast_WithListWhichContainsElement_NodeReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }

            list.AddLast(9);

            var result = list.FindLast(9);

            Assert.AreEqual(list._tail, result);
        }

        [Test]
        public void GetType_WithList_ListTypeReturned()
        {
            var list = new CircleList<int>();

            var result = list.ListGetType();
            var actual = "RingSinglyLinkedList.CircleList`1[System.Int32]";

            Assert.AreEqual(actual, result.ToString());
        }

        [Test]
        public void MyMemberwiseClone_WithNoEmptyList_CopiedListReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);

            var result = list.MyMemberwiseClone();

            Assert.AreEqual(5, result._head.Data);
            Assert.AreEqual(5, result._tail.Data);
            Assert.AreEqual(1, result.Count);
        }


        [Test]
        public void IEnumerator_WithNoEmptyList_ElementsReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(1);
            list.AddLast(0);
            list.AddLast(-1);

            var array = new int[] {1, 0, -1};
            var i = 0;

            foreach (var item in list)
            {
                Assert.AreEqual(array[i], item);
                i += 1;
            }
        }

        // Далее идут тесты для методов расширения.
        private static bool IsItemMoreThan4(int item)
        {
            return item > 4;
        }

        [Test]
        public static void MyAll_WithNoEmptyList_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);

            var result = list.All(IsItemMoreThan4);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MyAll_WithNoEmptyList_FalseReturned()
        {
            var list = new CircleList<int>();
            for (var i = 4; i < 8; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyAll(IsItemMoreThan4);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MyAny_WithEmptyList_FalseReturned()
        {
            var list = new CircleList<int>();

            var result = list.MyAny();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MyAny_WithNoEmptyList_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);

            var result = list.MyAny();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MyAnyWithCond_WithEmptyList_FalseReturned()
        {
            var list = new CircleList<int>();

            var result = list.MyAny(IsItemMoreThan4);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MynyWithCond_WithNoEmptyList_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(1);
            list.AddLast(10);

            var result = list.MyAny(IsItemMoreThan4);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MyAppend_WithEmptyList_ListWithOneElement()
        {
            var list = new CircleList<int>();

            var newList = (CircleList<int>) list.MyAppend(5);

            Assert.AreEqual(1, newList.Count);
            Assert.AreEqual(5, newList._head.Data);
            Assert.AreEqual(newList._tail, newList._head.Next);
        }

        [Test]
        public void MyConcat_WithTwoEmptyLists_EmptyListReturned()
        {
            var list = new CircleList<int>();
            var list0 = new CircleList<int>();
            var list1 = new CircleList<int>();

            list = (CircleList<int>) list0.MyConcat(list1);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list._head);
            Assert.AreEqual(null, list._tail);
        }

        [Test]
        public void MyConcat_WithFirstEmptyList_CopyOfSecondListReturned()
        {
            var list = new CircleList<int>();
            var list0 = new CircleList<int>();
            var list1 = new CircleList<int>();
            list1.AddLast(5);

            list = (CircleList<int>) list0.MyConcat(list1);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(5, list._tail.Data);
        }

        [Test]
        public void MyConcat_WithNoEmptyLists_ConcatedListsReturned()
        {
            var list = new CircleList<int>();
            var list0 = new CircleList<int>();
            var list1 = new CircleList<int>();
            list0.AddLast(4);
            for (var i = 5; i < 8; i++)
            {
                list1.AddLast(i);
            }

            list = (CircleList<int>) list0.MyConcat(list1);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(4, list._head.Data);
            Assert.AreEqual(5, list._head.Next.Data);
            Assert.AreEqual(6, list._head.Next.Next.Data);
            Assert.AreEqual(7, list._tail.Data);
        }

        [Test]
        public void MyContains_WithListWithNoElement_FalseReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);

            var result = list.MyContains(4);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MyContains_WithListWithElement_TrueReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);

            var result = list.MyContains(5);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MyCount_WithNoEmptyList_LenReturned()
        {
            var list = new CircleList<char>();
            for (var i = 0; i < 10; i++)
            {
                list.AddLast('a');
            }

            var result = list.MyCount();

            Assert.AreEqual(10, result);
        }

        [Test]
        public void MyCountWithCond_WithNoEmptyList_QuantityOfGoodItemsReturned()
        {
            var list = new CircleList<int>();
            for (var i = 0; i < 10; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyCount(IsItemMoreThan4);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void MyDistinct_WithEmptyList_EmptyListReturned()
        {
            var list = new CircleList<int>();

            var newList = (CircleList<int>) list.MyDistinct();

            Assert.AreEqual(0, newList.Count);
            Assert.AreEqual(null, newList._head);
            Assert.AreEqual(null, newList._tail);
        }

        [Test]
        public void MyDistinct_WithNoEmptyList_ListWithNoSimilarElementsReturned()
        {
            var list = new CircleList<int>();
            for (var i = 1; i <= 5; i++)
            {
                list.AddLast(i);
                list.AddLast(i);
                list.AddLast(i);
            }

            var newList = (CircleList<int>) list.MyDistinct();

            Assert.AreEqual(5, newList.Count);
            Assert.AreEqual(1, newList._head.Data);
            Assert.AreEqual(2, newList._head.Next.Data);
            Assert.AreEqual(3, newList._head.Next.Next.Data);
            Assert.AreEqual(4, newList._head.Next.Next.Next.Data);
            Assert.AreEqual(5, newList._tail.Data);
        }

        [Test]
        public void MyElementAt_WithEmptyList_ExceptionReturned()
        {
            var list = new CircleList<int>();

            try
            {
                list.MyElementAt(1);
            }
            catch (Exception e)
            {
                var x = new ArgumentOutOfRangeException();
                Assert.AreEqual(x.GetType(), e.GetType());
            }
        }

        [Test]
        public void MyElementAt_WithNoEmptyList_ElementReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyElementAt(3);

            Assert.AreEqual(8, result);
        }

        [Test]
        public void MyElementAtOrDefault_WithEmptyList_DefaultElementReturned()
        {
            var list = new CircleList<int>();

            var result = list.MyElementAtOrDefault(3);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void MyElementAtOrDefault_WithNoEmptyList_ElementReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyElementAt(3);

            Assert.AreEqual(8, result);
        }

        [Test]
        public void MyExcept_WithEmptyLists_EmptyListReturned()
        {
            var list0 = new CircleList<int>();
            var list1 = new CircleList<int>();

            var list = (CircleList<int>) list0.MyExcept(list1);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list._head);
            Assert.AreEqual(null, list._tail);
        }

        [Test]
        public void MyExcept_WithEmptySecondList_FirstListReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list0.AddLast(i);
            }

            var list1 = new CircleList<int>();

            var list = (CircleList<int>) list0.MyExcept(list1);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(6, list._head.Next.Data);
            Assert.AreEqual(7, list._head.Next.Next.Data);
            Assert.AreEqual(8, list._tail.Data);
        }

        [Test]
        public void MyExcept_WithEmptyFirstList_EmptyListReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list0.AddLast(i);
            }

            var list1 = new CircleList<int>();

            var list = (CircleList<int>) list1.MyExcept(list0);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list._head);
            Assert.AreEqual(null, list._tail);
        }

        [Test]
        public void MyExcept_WithNoEmptyLists_FirstListExceptSecondReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list0.AddLast(i);
            }

            var list1 = new CircleList<int>();
            for (var i = 6; i < 9; i++)
            {
                list1.AddLast(i);
            }

            var list = (CircleList<int>) list0.MyExcept(list1);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(5, list._tail.Data);
        }

        [Test]
        public void MyFirst_WithNoEmptyList_FirstElementReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyFirst();

            Assert.AreEqual(5, result);
        }

        [Test]
        public void MyFirstOrDefault_WithEmptyList_DefaultElementReturned()
        {
            var list = new CircleList<int>();

            var result = list.MyFirstOrDefault();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void MyIntersect_WithEmptyLists_EmptyListReturned()
        {
            var list0 = new CircleList<int>();
            var list1 = new CircleList<int>();

            var list = (CircleList<int>) list0.MyIntersect(list1);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list._head);
            Assert.AreEqual(null, list._tail);
        }

        [Test]
        public void MyIntersect_WithEmptySecondList_EmptyListReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list0.AddLast(i);
            }

            var list1 = new CircleList<int>();

            var list = (CircleList<int>) list0.MyIntersect(list1);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list._head);
            Assert.AreEqual(null, list._tail);
        }

        [Test]
        public void MyIntersect_WithNoEmptyLists_ListWithIntersectionReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list0.AddLast(i);
            }

            var list1 = new CircleList<int>();
            for (var i = 7; i < 15; i++)
            {
                list1.AddLast(i);
            }

            var list = (CircleList<int>) list0.MyIntersect(list1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(7, list._head.Data);
            Assert.AreEqual(8, list._head.Next.Data);
            Assert.AreEqual(9, list._tail.Data);
        }

        [Test]
        public void MyLast_WithNoEmptyList_LastReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyLast();

            Assert.AreEqual(9, result);
        }

        [Test]
        public void MyLastOrDefault_WithEmptyList_DefaultReturned()
        {
            var list = new CircleList<int>();

            var result = list.MyLastOrDefault();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void MyLastOrDefault_WithNoEmptyList_LastReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyLastOrDefault();

            Assert.AreEqual(9, result);
        }

        [Test]
        public void MyLongCount_WithNoEmptyList_LenReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyLongCount();

            Assert.AreEqual((typeof(long)), result.GetType());
        }

        [Test]
        public void MyMax_WithNoEmptyList_MaxElementReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }
            list.AddLast(4);

            var result = list.MyMax();

            Assert.AreEqual(9, result);
        }
        
        [Test]
        public void MyMin_WithNoEmptyList_MaxElementReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(10);
            for (var i = 5; i < 10; i++)
            {
                list.AddLast(i);
            }

            var result = list.MyMin();

            Assert.AreEqual(5, result);
        }

        [Test]
        public void MyPrepend_WithEmptyList_ListWithOneElementReturned()
        {
            var list0 = new CircleList<int>();

            var list = (CircleList<int>) list0.MyPrepend(5);
            
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list._head.Data);
            Assert.AreEqual(5,list._tail.Data);
        }
        
        [Test]
        public void MyPrepend_WithNoEmptyList_ListWithOneMoreElementReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list0.AddLast(i);
            }
            

            var list = (CircleList<int>) list0.MyPrepend(4);
            
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(4, list._head.Data);
            Assert.AreEqual(5, list._head.Next.Data);
            Assert.AreEqual(8,list._tail.Data);
        }

        [Test]
        public void MyReverse_WithNoEmptyList_ReverseListReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list0.AddLast(i);
            }


            var list = (CircleList<int>) list0.MyReverse();
            
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(8, list._head.Data);
            Assert.AreEqual(7, list._head.Next.Data);
            Assert.AreEqual(6, list._head.Next.Next.Data);
            Assert.AreEqual(5, list._tail.Data);
        }

        [Test]
        public void MySequenceEqual_WithNoEqualLists_FalseReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list0.AddLast(i);
            }

            var list1 = new CircleList<int>();
            for (var i = 6; i < 9; i++)
            {
                list1.AddLast(i);
            }
            list1.AddLast(5);

            var result = list0.MySequenceEqual(list1);
            
            Assert.AreEqual(false, result);
        }
        
        [Test]
        public void MySequenceEqual_WithEqualLists_TrueReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list0.AddLast(i);
            }

            var list1 = new CircleList<int>();
            for (var i = 6; i < 9; i++)
            {
                list1.AddLast(i);
            }
            list1.AddFirst(5);

            var result = list0.MySequenceEqual(list1);
            
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MySingle_WithListWithOneElement_ElementReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);

            var result = list.MySingle();
            
            Assert.AreEqual(5, result);
        }

        [Test]
        public void MySingle_WithListWithMoreThanOneElement_ArgumentNullExceptionReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            int result = 0;
            try
            {
                result = list.MySingle();
            }
            catch (Exception e)
            {
                var x = new ArgumentNullException();
                Assert.AreEqual(x.GetType(), e.GetType());
                return;
            }
            
            Assert.AreEqual(1, 0); 
        }

        [Test]
        public void MySingleOrDefault_WithEmptyList_DefaultReturned()
        {
            var list = new CircleList<int>();

            var result = list.MySingleOrDefault();
            
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void MySingleOrDefault_WithListWithOneElement_ElementReturned()
        {
            var list = new CircleList<int>();
            list.AddLast(5);

            var result = list.MySingleOrDefault();
            
            Assert.AreEqual(5, result);
        }

        [Test]
        public void MySingleOrDefault_WithListWithMoreThanOneElement_ArgumentNullExceptionReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            int result = 0;
            try
            {
                result = list.MySingleOrDefault();
            }
            catch (Exception e)
            {
                var x = new ArgumentNullException();
                Assert.AreEqual(x.GetType(), e.GetType());
                return;
            }
            
            Assert.AreEqual(1, 0); 
        }

        [Test]
        public void MyTake_WithNoEmptyList_PartOfListReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var result = (CircleList<int>) list.MyTake(3);
            
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result._head.Data);
            Assert.AreEqual(7, result._tail.Data);
        }
        
        [Test]
        public void MyTake_WithNoEmptyList_CopiedListReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var result = (CircleList<int>) list.MyTake(5);
            
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(5, result._head.Data);
            Assert.AreEqual(8, result._tail.Data);
        }

        [Test]
        public void MyTakeRange_WithNoEmptyList_PartOfListReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 15; i++)
            {
                list.AddLast(i);
            }

            var result = (CircleList<int>) list.MyTake(1, 4);
            
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(6, result._head.Data);
            Assert.AreEqual(9, result._tail.Data);
        }

        [Test]
        public void MyTakeLast_WithNoEmptyList_PartOfListReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var result = (CircleList<int>) list.MyTakeLast(3);
            
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(6, result._head.Data);
            Assert.AreEqual(8, result._tail.Data);
        }

        [Test]
        public void MyTakeLast_WithNoEmptyList_CopiedListReturned()
        {
            var list = new CircleList<int>();
            for (var i = 5; i < 9; i++)
            {
                list.AddLast(i);
            }

            var result = (CircleList<int>) list.MyTakeLast(10);
            
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(5, result._head.Data);
            Assert.AreEqual(8, result._tail.Data);
        }

        [Test]
        public void MyUnion_WithTwoEmptyLists_EmptyListReturned()
        {
            var list0 = new CircleList<int>();
            var list1 = new CircleList<int>();
            
            var list = (CircleList<int>) list0.MyUnion(list1);
            
            Assert.AreEqual(0,list.Count);
            Assert.AreEqual(null,list._head);
            Assert.AreEqual(null,list._tail);
        }
        
        [Test]
        public void MyUnion_WithEmptySecondList_FirstListReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list0.AddLast(i);
            }
            var list1 = new CircleList<int>();
            
            
            var list = (CircleList<int>) list0.MyUnion(list1);
            
            Assert.AreEqual(5,list.Count);
            Assert.AreEqual(5,list._head.Data);
            Assert.AreEqual(9,list._tail.Data);
        }
        
        [Test]
        public void MyUnion_NoEmptyLists_ListOfUnionReturned()
        {
            var list0 = new CircleList<int>();
            for (var i = 5; i < 10; i++)
            {
                list0.AddLast(i);
            }
            var list1 = new CircleList<int>();
            for (var i = 9; i < 28; i++)
            {
                list0.AddLast(i);
            }
            
            var list = (CircleList<int>) list0.MyUnion(list1);
            var counter = 0;
            foreach (var item in list)
            {
                if (item == 9)
                {
                    counter++;
                }
            }
            
            Assert.AreEqual(23,list.Count);
            Assert.AreEqual(5,list._head.Data);
            Assert.AreEqual(27,list._tail.Data);
            Assert.AreEqual(1, counter);
        }
    }

}