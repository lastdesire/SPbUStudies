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
        SobelXFilter,
        SobelYFilter,
        GaussFilter
    }

    public partial class Form1 : Form
    {
        private Filters _currentFilter;
        private Bitmap _currentBitmap;
        private Bitmap _originalBitmap;

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

        private void TrackBar1_Scroll(object sender, EventArgs e) // Метод, отвечающий за корректную работу скролл-бара (прозрачность картинки).
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            var bitmap = new Bitmap(_currentBitmap);
            Transparent.ApplyFilter(bitmap, trackBar1.Value);
            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) // Метод, отвечающий за корректное открытие файла.
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            pictureBox1.Image = null;
            _currentFilter = Filters.NoFilter;

            var bitmap = new Bitmap(openFileDialog1.FileName);

            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _originalBitmap = new Bitmap(bitmap);
        }
        private void Gray_Click(object sender, EventArgs e) // Метод, реализующийся при нажатии кнопки "Gray" (Применение фильтра).
        {
            if (pictureBox1.Image == null)
            {
                return;
            }

            var bitmap = new Bitmap(pictureBox1.Image);

            GrayFilter.ApplyFilter(bitmap);
            Transparent.ApplyFilter(bitmap, trackBar1.Value);

            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _currentFilter = Filters.GrayFilter;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) // Метод, отвечающий за корректное сохранение файла.
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            pictureBox1.Image.Save(filename);

        }
        private void Original_Click(object sender, EventArgs e) // Метод, реализующийся при нажатии кнопки "Original" (Возвращение оригинальной картинки).
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            pictureBox1.Image = _originalBitmap;
            Transparent.ApplyFilter((Bitmap)pictureBox1.Image, trackBar1.Value);
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _currentFilter = Filters.NoFilter;
        }

        private void Median_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }

            var bitmap = new Bitmap(pictureBox1.Image);

            MedianFilter.ApplyFilter(bitmap);
            Transparent.ApplyFilter(bitmap, trackBar1.Value);

            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _currentFilter = Filters.MedianFilter;
        }

        private void SobelY_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }

            var bitmap = new Bitmap(pictureBox1.Image);


            SobelFilter.ApplyFilter(bitmap, SobelFilterType.SobelY);
            Transparent.ApplyFilter(bitmap, trackBar1.Value);

            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _currentFilter = Filters.SobelYFilter;
        }

        private void SobelX_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }

            var bitmap = new Bitmap(pictureBox1.Image);


            SobelFilter.ApplyFilter(bitmap, SobelFilterType.SobelX);
            Transparent.ApplyFilter(bitmap, trackBar1.Value);

            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _currentFilter = Filters.SobelXFilter;
        }

        private void Gauss_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }

            var bitmap = new Bitmap(pictureBox1.Image);


            GaussFilter.ApplyFilter(bitmap);
            Transparent.ApplyFilter(bitmap, trackBar1.Value);

            pictureBox1.Image = bitmap;
            _currentBitmap = (Bitmap)pictureBox1.Image;
            _currentFilter = Filters.GaussFilter;
        }
    }
}