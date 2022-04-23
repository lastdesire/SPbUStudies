using System.Drawing;
using System.Drawing.Imaging;

namespace BMPFilters
{
    public static class GaussFilter
    {
        private static readonly double[,] GaussMatrix =
       {
            {0.0625, 0.125, 0.0625},
            {0.125,  0.25,  0.125},
            {0.0625,  0.125,  0.0625}
        };

        public static void ApplyFilter(Bitmap newBitmap) // Усредняющий фильтр Гаусса 3х3.
        {
            var currentBitmap = new Bitmap(newBitmap);

            for (var x = 1; x < currentBitmap.Width - 1; x++)
            {
                for (var y = 1; y < currentBitmap.Height - 1; y++)
                {
                    var pixels = new Color[9];
                    var counter = 0;
                    double resultR = 0;
                    double resultG = 0;
                    double resultB = 0;
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            pixels[counter] = currentBitmap.GetPixel(x - 1 + i, y - 1 + j);
                            resultR += pixels[counter].R * GaussMatrix[i, j];
                            resultG += pixels[counter].G * GaussMatrix[i, j];
                            resultB += pixels[counter].B * GaussMatrix[i, j];
                            counter++;
                        }
                    }  
                    var newColor = Color.FromArgb((byte) resultR, (byte) resultG, (byte)resultB);
                    newBitmap.SetPixel(x, y, newColor);

                }
            }
        }
    }
}