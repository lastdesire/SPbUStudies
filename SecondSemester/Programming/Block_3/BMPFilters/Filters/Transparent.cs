using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BMPFilters
{
    public static class Transparent
    {
        public static Bitmap ApplyFilter(Bitmap bitmap, int procent)
        {
            var newBitmap = new Bitmap(bitmap);
            var transparent = (int) (0.01 * procent * 255);
            for (var x = 0; x < newBitmap.Width; x++)
            {
                for (var y = 0; y < newBitmap.Height; y++)
                {
                    var pixel = newBitmap.GetPixel(x, y);
                    var newColor = Color.FromArgb(transparent, pixel.R, pixel.G, pixel.B);

                    newBitmap.SetPixel(x, y, newColor);
                }
            }

            return newBitmap;
            //
        }
    }
}
