using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = bmp;
            }

            else
            {

                MessageBox.Show("No Image");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            Bitmap cloneImage = bmp.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
            pictureBox1.Image = cloneImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int x, y;
            for (x = 0; x < bmp.Width; x++)
            {

                for (y = 0; y < bmp.Height; y++)
                {
                    Color oldPixelColor = bmp.GetPixel(x, y);
                    Color newPixelColor = Color.FromArgb(oldPixelColor.R, 0, 0);
                    bmp.SetPixel(x, y, newPixelColor);
                }

            }
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int x, y;
            for (x = 0; x < bmp.Width; x++)
            {

                for (y = 0; y < bmp.Height; y++)
                {
                    Color oldPixelColor = bmp.GetPixel(x, y);
                    Color newPixelColor = Color.FromArgb(255 - oldPixelColor.R, 255 - oldPixelColor.G, 255 - oldPixelColor.B);
                    bmp.SetPixel(x, y, newPixelColor);
                }

            }
            pictureBox1.Image = bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            saveFD.FileName = "Save Image";
            saveFD.Filter = "JPEG|*.jpeg";
            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                string savePath = saveFD.FileName;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.Save(savePath, ImageFormat.Jpeg);
                MessageBox.Show("Image Saved");
            }
        }
    }
}
