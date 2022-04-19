using System.Drawing;
using System.Drawing.Imaging;

namespace BMPFilters
{
    public static class GrayFilter
    {
        private const double RCoefficient = 0.3;
        private const double GCoefficient = 0.59;
        private const double BCoefficient = 0.11;

        public static void ApplyFilter(Bitmap newBitmap)
        {

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
        }
    }
}