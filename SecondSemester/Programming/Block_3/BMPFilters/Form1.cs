using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPFilters
{
    enum Filters
    {
        NoFilter,
        GrayFilter,
        MedianFilter,
        ETC
    }

    public partial class Form1 : Form
    {
        private Filters _currentFilter;
        private Bitmap _currentBitmap;
        private Bitmap _originalBitmap;
        //private List<Bitmap> _bitmaps = new List<Bitmap>(101); // No Filter.


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            var bitmap = new Bitmap(_currentBitmap);
            Transparent.ApplyFilter(bitmap, trackBar1.Value);
            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            /*
             switch(_currentFilter)
             {
                 case Filters.NoFilter:
                     pictureBox1.Image = _bitmaps[trackBar1.Value - 1];
                     _currentBitmap = new Bitmap(pictureBox1.Image);
                     break;

                 case Filters.GrayFilter:

                     pictureBox1.Image = GrayFilter.ApplyFilter(_currentBitmap);
                     _currentBitmap = new Bitmap(pictureBox1.Image);

                     break;
             }
            /*
             //pictureBox1.Image = _bitmaps[trackBar1.Value - 1]



             //
             /*
             var bitmap = (Bitmap)pictureBox1.Image;
             Transparent.ApplyFilter(bitmap, trackBar1.Value);
             pictureBox1.Image = bitmap;
             */
            //

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }




        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            pictureBox1.Image = null;
            //_bitmaps.Clear();
            _currentFilter = Filters.NoFilter;
            
            
            var bitmap = new Bitmap(openFileDialog1.FileName);

            //StartProcessing(bitmap);
            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
        }


        private void StartProcessing(Bitmap bitmap)
        {
            // NoFilter
            //Transparent.ApplyFilter(bitmap, _bitmaps, trackBar1.Maximum);

           

            /*
            for (int i = 1; i <= trackBar1.Maximum; i++)
            {
                var newBitmap = Transparent.ApplyFilter(bitmap, i);
                _bitmaps.Add(newBitmap);

            }
            _bitmaps.Add((Bitmap)(pictureBox1.Image));


            // GrayFilter
            for (int i = 1; i <= trackBar1.Maximum; i++)
            {
                var newBitmap = Transparent.ApplyFilter(bitmap, i);
                _bitmaps.Add(newBitmap);

            }
            */
            //_bitmaps.Add((Bitmap)(pictureBox1.Image));
        }
        
        
        private List<Pixel> GetPixelsList(Bitmap bitmap)
        {
            var pixels = new List<Pixel>(bitmap.Height * bitmap.Width);
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    pixels.Add(new Pixel() 
                    {
                        Color = bitmap.GetPixel(x, y),
                        Point = new Point(x, y) 
                    });

                }
            }
            return pixels;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            var bitmap = new Bitmap(pictureBox1.Image);
            Transparent.ApplyFilter(bitmap, 50);
            pictureBox1.Image = bitmap;
            */
        }
        private void gray_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(_currentBitmap);
            GrayFilter.ApplyFilter(bitmap);
            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _currentFilter = Filters.GrayFilter;
        }

 
      

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            pictureBox1.Image.Save(filename);

        }
    }
}
