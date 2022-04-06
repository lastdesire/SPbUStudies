using System;
using NUnit.Framework;
using QSort;

namespace QSortTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SortWithDefaultQSortAndPartition_WithDoubleArray_SortedArrayReturned()
        {
            var qSort = new QuickSort();
            double[] array = {5.7, 10.5, 24.6, 10.56, 68.9, 444};
            
            qSort.Sort(array, 0, array.Length - 1, false, qSort.DefaultQSort);
            
            Assert.AreEqual(5.7, array[0]);
            Assert.AreEqual(10.5, array[1]);
            Assert.AreEqual(10.56, array[2]);
            Assert.AreEqual(24.6, array[3]);
            Assert.AreEqual(68.9, array[4]);
            Assert.AreEqual(444, array[5]);
        }
        
        [Test]
        public void SortWithDefaultQSortAndPartition_WithDoubleArrayAndReverse_SortedReverseArrayReturned()
        {
            var qSort = new QuickSort();
            double[] array = {444, 10.56, 5.7, 24.6, 68.9, 10.5};
            
            qSort.Sort(array, 0, array.Length - 1, true, qSort.DefaultQSort);
            
            Assert.AreEqual(5.7, array[5]);
            Assert.AreEqual(10.5, array[4]);
            Assert.AreEqual(10.56, array[3]);
            Assert.AreEqual(24.6, array[2]);
            Assert.AreEqual(68.9, array[1]);
            Assert.AreEqual(444, array[0]);
        }
        
        [Test]
        public void SortWithDefaultQSortAndPartition_WithIntArray_SortedArrayReturned()
        {
            var qSort = new QuickSort();
            int[] array = {5, 10, 24, 19, 68, 4};
            
            qSort.Sort(array, 0, array.Length - 1, false, qSort.DefaultQSort);
            
            Assert.AreEqual(4, array[0]);
            Assert.AreEqual(5, array[1]);
            Assert.AreEqual(10, array[2]);
            Assert.AreEqual(19, array[3]);
            Assert.AreEqual(24, array[4]);
            Assert.AreEqual(68, array[5]);
        }
        
        [Test]
        public void SortWithDefaultQSortAndPartition_WithCharArray_SortedArrayReturned()
        {
            var qSort = new QuickSort();
            char[] array = {'1', 'a', 'c', 'b', '5', '9'};
            
            qSort.Sort(array, 0, array.Length - 1, false, qSort.DefaultQSort);
            
            Assert.AreEqual('1', array[0]);
            Assert.AreEqual('5', array[1]);
            Assert.AreEqual('9', array[2]);
            Assert.AreEqual('a', array[3]);
            Assert.AreEqual('b', array[4]);
            Assert.AreEqual('c', array[5]);
        }
        
        [Test]
        public void SortWithDefaultQSortAndPartition_WithStrArray_SortedArrayReturned()
        {
            var qSort = new QuickSort();
            string[] array = {"c", "aaa", "aaaa", "bbb", "bbbb", "aaaab"};
            
            qSort.Sort(array, 0, array.Length - 1, false, qSort.DefaultQSort);
            
            Assert.AreEqual("aaa", array[0]);
            Assert.AreEqual("aaaa", array[1]);
            Assert.AreEqual("aaaab", array[2]);
            Assert.AreEqual("bbb", array[3]);
            Assert.AreEqual("bbbb", array[4]);
            Assert.AreEqual("c", array[5]);
        }
        
        [Test]
        public void SortWithDefaultQSortAndPartition_WithIntArrayAndReverse_SortedReverseArrayReturned()
        {
            var qSort = new QuickSort();
            int[] array = {10, 5, 19, 24, 4, 68};
            
            qSort.Sort(array, 0, array.Length - 1, true, qSort.DefaultQSort);
            
            Assert.AreEqual(4, array[5]);
            Assert.AreEqual(5, array[4]);
            Assert.AreEqual(10, array[3]);
            Assert.AreEqual(19, array[2]);
            Assert.AreEqual(24, array[1]);
            Assert.AreEqual(68, array[0]);
        }
        
        [Test]
        public void SortWithDefaultQSortAndPartition_WithCharArrayAndReverse_SortedReverseArrayReturned()
        {
            var qSort = new QuickSort();
            char[] array = {'1', 'a', 'c', 'b', '5', '9'};
            
            qSort.Sort(array, 0, array.Length - 1, true, qSort.DefaultQSort);
            
            Assert.AreEqual('1', array[5]);
            Assert.AreEqual('5', array[4]);
            Assert.AreEqual('9', array[3]);
            Assert.AreEqual('a', array[2]);
            Assert.AreEqual('b', array[1]);
            Assert.AreEqual('c', array[0]);
        }
        
        [Test]
        public void SortWithDefaultQSortAndPartition_WithStrArrayAndReverse_SortedReverseArrayReturned()
        {
            var qSort = new QuickSort();
            string[] array = {"c", "aaa", "aaaa", "bbb", "bbbb", "aaaab"};
            
            qSort.Sort(array, 0, array.Length - 1, true, qSort.DefaultQSort);
            
            Assert.AreEqual("aaa", array[5]);
            Assert.AreEqual("aaaa", array[4]);
            Assert.AreEqual("aaaab", array[3]);
            Assert.AreEqual("bbb", array[2]);
            Assert.AreEqual("bbbb", array[1]);
            Assert.AreEqual("c", array[0]);
        }

        [Test]
        public void SortWithDictionarySort_WithStrArray_SortedArrayReturned()
        {
            var qSort = new QuickSort();
            string[] array = {"aaaab", "c", "aaa", "aaaa", "bbb", "bbbb"};
            
            qSort.Sort(array, 0, array.Length - 1, false, qSort.DictionarySort);
            
            Assert.AreEqual("c", array[0]);
            Assert.AreEqual("aaa", array[1]);
            Assert.AreEqual("bbb", array[2]);
            Assert.AreEqual("aaaa", array[3]);
            Assert.AreEqual("bbbb", array[4]);
            Assert.AreEqual("aaaab", array[5]);
        }
        
        [Test]
        public void SortWithDictionarySort_WithStrArrayAndReverse_SortedReverseArrayReturned()
        {
            var qSort = new QuickSort();
            string[] array = {"bbb", "aaa", "aaaa", "c", "bbbb", "aaaab"};
            
            qSort.Sort(array, 0, array.Length - 1, true, qSort.DictionarySort);
            
            Assert.AreEqual("c", array[5]);
            Assert.AreEqual("aaa", array[4]);
            Assert.AreEqual("bbb", array[3]);
            Assert.AreEqual("aaaa", array[2]);
            Assert.AreEqual("bbbb", array[1]);
            Assert.AreEqual("aaaab", array[0]);
            
        }
    }
}