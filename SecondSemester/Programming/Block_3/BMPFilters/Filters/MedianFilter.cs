using System.Drawing;
using System.Drawing.Imaging;
using System;

namespace BMPFilters
{
    public static class MedianFilter
    {
        public static void ApplyFilter(Bitmap newBitmap) // Усредняющий фильтр 3х3.
        {

            for (var x = 1; x < newBitmap.Width - 1; x++)
            {
                for (var y = 1; y < newBitmap.Height - 1; y++)
                {
                    var pixels = new Color[9];
                    var pixelsR = new int[9];
                    var pixelsG = new int[9];
                    var pixelsB = new int[9];
                    var counter = 0;
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            pixels[counter] = newBitmap.GetPixel(x - 1 + i, y - 1 + j);
                            pixelsR[counter] = pixels[counter].R;
                            pixelsG[counter] = pixels[counter].G;
                            pixelsB[counter] = pixels[counter].B;
                            counter++;
                        }
                    }
                    Array.Sort(pixelsR);
                    Array.Sort(pixelsG);
                    Array.Sort(pixelsB);
                    var newColor = Color.FromArgb(pixelsR[4], pixelsG[4], pixelsB[4]);
                    newBitmap.SetPixel(x, y, newColor);
                }
            }
        }

    }
}