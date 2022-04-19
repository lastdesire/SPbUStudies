using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BMPFilters
{

    public enum SobelFilterType
    {
        SobelX,
        SobelY
    }

    public static class SobelFilter
    {
        
        private static readonly int[,] SobelYMatrix =
        {
            {-1, -2, -1},
            {0,  0,  0},
            {1,  2,  1}
        };

        private static readonly int[,] SobelXMatrix =
        {
            {-1, 0, 1},
            {-2, 0, 2},
            {-1, 0, 1}
        };
        
        private const int SobelEdgeLimit = 73;
       
        public static void ApplyFilter(Bitmap newBitmap, SobelFilterType type) // Фильтр Собеля по X и по Y.
        {
            var matrix = SobelXMatrix;
            if (type == SobelFilterType.SobelY)
            {
                matrix = SobelYMatrix;
            }

            GrayFilter.ApplyFilter(newBitmap);
            var currentBitmap = new Bitmap(newBitmap);

            for (var x = 1; x < currentBitmap.Width - 1; x++)
            {
                for (var y = 1; y < currentBitmap.Height - 1; y++)
                { 
                    var pixels = new Color[9];
                    var counter = 0;
                    var result = 0;
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            pixels[counter] = currentBitmap.GetPixel(x - 1 + i, y - 1 + j);
                            result += pixels[counter].R * matrix[i, j];
                            counter++;
                        }
                    }
                    byte answer = Math.Abs(result) < SobelEdgeLimit ? (byte)0 : (byte)255;
                    var newColor = Color.FromArgb(answer, answer, answer);
                    newBitmap.SetPixel(x, y, newColor);

                }
            }
        }
    }

}

