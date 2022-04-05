using System;
using System.IO;
using NUnit.Framework;


namespace ExceptionsTests
{
    using Exceptions;
    
    [TestFixture]
    public class ExceptionsTests
    {
        [Test]
        public void DivideByZeroException_WithNoZeroDivisor_GoodResultReturned()
        {
            var exceptions = new Exceptions();
            
            var result = exceptions.DivideByZeroException(25, 5);
            
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void DivideByZeroException_WithZeroDivisor_ZeroReturned()
        {
            var exceptions = new Exceptions();
            
            var result = exceptions.DivideByZeroException(25, 0);
            
            Assert.AreEqual(0, result);
        }

        [Test]
        public void OverflowException_WithNotEnoughForOverflowValue_GoodResultReturned()
        {
            var exceptions = new Exceptions();
            
            var result = exceptions.OverflowException(10);
            
            Assert.AreEqual(3628800, result); // 10! = 3628800;
        }
        
        [Test]
        public void OverflowException_WithEnoughForOverflowValue_MinusOneReturned()
        {
            var exceptions = new Exceptions();
            
            var result = exceptions.OverflowException(30);
            
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void FormatException_WithCorrectString_GoodIntResultReturned()
        {
            var exceptions = new Exceptions();

            var result = exceptions.FormatException("111");
            
            Assert.AreEqual(111,result);
        }
        
        [Test]
        public void FormatException_WithNoCorrectString_MinusOneReturned()
        {
            var exceptions = new Exceptions();

            var result = exceptions.FormatException("abc");
            
            Assert.AreEqual(-1,result);
        }

        [Test]
        public void InvalidCastException_WithNothing_OneReturned()
        {
            var exceptions = new Exceptions();

            var result = exceptions.InvalidCastException();
            
            Assert.AreEqual(1,result);
        }

        [Test]
        public void IndexOutOfRangeException_WithGoodIndex_GoodArrayReturned()
        {
            var exceptions = new Exceptions();
            var array = new int[10];
            var index = 5;

            array = exceptions.IndexOutOfRangeException(array, index);

            for (var i = 0; i < 10; i++)
            {
                Assert.AreEqual(i,array[i]);
            }
        }
        
        [Test]
        public void IndexOutOfRangeException_WithBadIndex_ArrayWithIndexSizeReturned()
        {
            var exceptions = new Exceptions();
            var array = new int[10];
            var index = 15;

            array = exceptions.IndexOutOfRangeException(array, index);

            for (var i = 0; i < 10; i++)
            {
                Assert.AreEqual(i,array[i]);
            }
            Assert.AreEqual(15, array[15]);
        }

        [Test]
        public void ArgumentException_WithBadPath_NewFileReturned()
        {
            var exceptions = new Exceptions();

            var result = exceptions.ArgumentException("");

            Assert.AreEqual(0, result.Length);
            result.Close();
        }

        [Test]
        public void NotSupportedException_WithWritableFile_TrueReturned()
        {
            var exceptions = new Exceptions();
            var text = File.Open(Path.GetTempFileName(), FileMode.Create, FileAccess.Write, FileShare.None);

            var result = exceptions.NotSupportedException(text);

            Assert.AreEqual(true, result);
            text.Close();
        }
        
        [Test]
        public void NotSupportedException_WithNoWritableFile_FalseReturned()
        {
            var exceptions = new Exceptions();
            var text = File.Open(Path.GetTempFileName(), FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);

            var result = exceptions.NotSupportedException(text);

            Assert.AreEqual(false, result);
            text.Close();
        }

        [Test]
        public void ArrayTypeMismatchException_WithEqualElementType_TrueReturned()
        {
            var exceptions = new Exceptions();
            string[] arrayStr = {"A", "B", "C"};
            var arrayObj  = (Object[]) arrayStr;
            var obj = (Object) "19";

            var result = exceptions.ArrayTypeMismatchException(arrayObj, obj);

            Assert.AreEqual(true, result);

        }
        
        [Test]
        public void ArrayTypeMismatchException_WithDifferentElementType_FalseReturned()
        {
            var exceptions = new Exceptions();
            string[] arrayStr = {"A", "B", "C"};
            var arrayObj  = (Object[]) arrayStr;
            var obj = (Object) 19;

            var result = exceptions.ArrayTypeMismatchException(arrayObj, obj);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void NullReferenceException_WithNullObject_InitializedObjectReturned()
        {
            var exceptions = new Exceptions();
            Hero hero = null;

            var result = exceptions.NullReferenceException(hero);
            
            Assert.AreEqual(5, result.Number);
        }
    }
}