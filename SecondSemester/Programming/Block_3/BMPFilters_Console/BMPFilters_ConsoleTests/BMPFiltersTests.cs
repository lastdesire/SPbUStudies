using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using BMPFilters;

namespace BMPFilters_ConsoleTests
{
    [TestClass]
    public class BMPFiltersTests
    {
        private FileStream fileInput = null;
        private FileStream fileOutput = null;
        private static bool IsBitmapsAreEqual(Bitmap bitmap0, Bitmap bitmap)
        {
            if (bitmap0.Width != bitmap.Width || bitmap0.Height != bitmap.Height)
            {
                return false;
            }

            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    if (bitmap0.GetPixel(x, y) != bitmap.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [TestMethod]
        public void GrayFilterTest()
        {
            fileInput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/original.jpg", FileMode.Open, FileAccess.ReadWrite);
            fileOutput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/gray.jpg", FileMode.Open, FileAccess.ReadWrite);
            var bitmap = new Bitmap(fileInput);
            var bitmapOutput = new Bitmap(fileOutput);

            GrayFilter.ApplyFilter(bitmap);

            Assert.IsTrue(IsBitmapsAreEqual(bitmap, bitmapOutput));
        }

        [TestMethod]
        public void MedianFilterTest()
        {
            fileInput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/original.jpg", FileMode.Open, FileAccess.ReadWrite);
            fileOutput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/median.jpg", FileMode.Open, FileAccess.ReadWrite);
            var bitmap = new Bitmap(fileInput);
            var bitmapOutput = new Bitmap(fileOutput);

            MedianFilter.ApplyFilter(bitmap);

            Assert.IsTrue(IsBitmapsAreEqual(bitmap, bitmapOutput));
        }

        [TestMethod]
        public void GaussFilterTest()
        {
            fileInput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/original.jpg", FileMode.Open, FileAccess.ReadWrite);
            fileOutput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/gauss.jpg", FileMode.Open, FileAccess.ReadWrite);
            var bitmap = new Bitmap(fileInput);
            var bitmapOutput = new Bitmap(fileOutput);

            GaussFilter.ApplyFilter(bitmap);

            Assert.IsTrue(IsBitmapsAreEqual(bitmap, bitmapOutput));
        }

       
        [TestMethod]
        public void SobelXFilterTest()
        {
            fileInput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/original.jpg", FileMode.Open, FileAccess.ReadWrite);
            fileOutput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/sobelx.jpg", FileMode.Open, FileAccess.ReadWrite);
            var bitmap = new Bitmap(fileInput);
            var bitmapOutput = new Bitmap(fileOutput);

            SobelFilter.ApplyFilter(bitmap, SobelFilterType.SobelX);

            Assert.IsTrue(IsBitmapsAreEqual(bitmap, bitmapOutput));
        }

        [TestMethod]
        public void SobelYFilterTest()
        {
            fileInput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/original.jpg", FileMode.Open, FileAccess.ReadWrite);
            fileOutput = new FileStream("../../../BMPFilters_ConsoleTests/testsPictures/sobely.jpg", FileMode.Open, FileAccess.ReadWrite);
            var bitmap = new Bitmap(fileInput);
            var bitmapOutput = new Bitmap(fileOutput);

            SobelFilter.ApplyFilter(bitmap, SobelFilterType.SobelY);

            Assert.IsTrue(IsBitmapsAreEqual(bitmap, bitmapOutput));
        }
    }
}
