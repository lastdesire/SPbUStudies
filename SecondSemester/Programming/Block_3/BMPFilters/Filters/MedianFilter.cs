using System.Drawing;
using System.Drawing.Imaging;

namespace BMPFilters
{
    public static class MedianFilter
    {
     
        /*
        public static Bitmap qApplyFilter(Bitmap bitmap)
        {
            var newBitmap = new Bitmap(bitmap);

            for (var x = 0; x < newBitmap.Width; x++)
            {
                for (var y = 0; y < newBitmap.Height; y++)
                {
                    var pixel = newBitmap.GetPixel(x, y);
                    var color = (int)(pixel.B * BCoefficient + pixel.G * GCoefficient + pixel.R * RCoefficient);
                    var newColor = Color.FromArgb(color, color, color);
                    newBitmap.SetPixel(x, y, newColor);
                }
            }

            return newBitmap;
        }

        public unsafe static Bitmap ApplyFilter(Bitmap bitmap)
        {
            Bitmap b = new Bitmap(bitmap);//note this has several overloads, including a path to an image

            BitmapData bData = b.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, b.PixelFormat);


            byte bitsPerPixel = (byte)Image.GetPixelFormatSize(bData.PixelFormat);


            
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    byte* data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;

                    //data is a pointer to the first byte of the 3-byte color data
                    var color = (byte)(data[0] * BCoefficient + data[1] * GCoefficient + data[2] * RCoefficient);
                    data[0] = color;
                    data[1] = color;
                    data[2] = color;
                }
            }

            b.UnlockBits(bData);

            return b;
        }*/

    }
}