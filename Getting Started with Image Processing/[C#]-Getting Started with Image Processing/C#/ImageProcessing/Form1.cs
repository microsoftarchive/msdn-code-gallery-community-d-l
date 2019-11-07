using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog(this);
            if (res == DialogResult.Cancel)
                return;

            LoadImage(openFileDialog1.FileName);

            Globals.Reset();
        }

        private void LoadImage(string p)
        {
            pictureBox1.Image = Image.FromFile(p);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;

            SyncTitle(p);
        }

        private void SyncTitle(string p)
        {
            System.IO.FileInfo finfo = new System.IO.FileInfo(p);
            this.Text = finfo.Name + " - Image Processing";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog(this);
            if (res == DialogResult.Cancel)
                return;

            SaveImage(saveFileDialog1.FileName);
        }

        private void SaveImage(string p)
        {
            Bitmap imageBmp = new Bitmap(pictureBox1.Image);
            imageBmp.Save(p);

            SyncTitle(p);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InvertImage(pictureBox1.Image);
        }

        private void InvertImage(Image img)
        {
            Bitmap image = new Bitmap(img);

            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int nOffset = stride - image.Width * 3;
                int nWidth = image.Width * 3;
                for (int y = 0; y < image.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }

            image.UnlockBits(bmData);

            pictureBox1.Image = image;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GrayscaleImage(pictureBox1.Image);
        }

        private void GrayscaleImage(Image img)
        {
            Bitmap image = new Bitmap(img);

            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - image.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < image.Height; ++y)
                {
                    for (int x = 0; x < image.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        p[0] = p[1] = p[2] = (byte)(.299 * red
                            + .587 * green
                            + .114 * blue);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            image.UnlockBits(bmData);

            pictureBox1.Image = image;
        }

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brightness(pictureBox1.Image, 10);
        }

        private void Brightness(Image img, int n)
        {
            Bitmap image = new Bitmap(img);

            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - image.Width * 3;
                int nWidth = image.Width * 3;
                int nVal = 0;

                for (int y = 0; y < image.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nVal = (int)(p[0] + n);

                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;

                        p[0] = (byte)nVal;

                        ++p;
                    }
                    p += nOffset;
                }

            }
            image.UnlockBits(bmData);

            pictureBox1.Image = image;
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brightness(pictureBox1.Image, -10);
        }

        private void increaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Contrast(pictureBox1.Image, 10);
        }

        private void decreaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Contrast(pictureBox1.Image, -10);
        }

        private void Contrast(Image img, int n)
        {
            Bitmap image = new Bitmap(img);

            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            
            double pixel = 0, contrast = (100.0 + n) / 100.0;
            contrast *= contrast;
            
            int red, green, blue;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - image.Width * 3;

                for (int y = 0; y < image.Height; ++y)
                {
                    for (int x = 0; x < image.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        pixel = red / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[2] = (byte)pixel;

                        pixel = green / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[1] = (byte)pixel;

                        pixel = blue / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[0] = (byte)pixel;

                        p += 3;
                    }
                    p += nOffset;
                }
            }
            image.UnlockBits(bmData);

            pictureBox1.Image = image;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Color dlg = new Color();

            if (DialogResult.OK == dlg.ShowDialog())
                ColorImage(pictureBox1.Image, Globals.red, Globals.green, Globals.blue);
        }

        private void ColorImage(Image img, int r, int g, int b)
        {
            if (!Globals.isValid)
                return;

            Bitmap image = new Bitmap(img);

            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - image.Width * 3;
                int nPixel;

                for (int y = 0; y < image.Height; ++y)
                {
                    for (int x = 0; x < image.Width; ++x)
                    {
                        nPixel = p[2] + r;
                        nPixel = Math.Max(nPixel, 0);
                        p[2] = (byte)Math.Min(255, nPixel);

                        nPixel = p[1] + g;
                        nPixel = Math.Max(nPixel, 0);
                        p[1] = (byte)Math.Min(255, nPixel);

                        nPixel = p[0] + b;
                        nPixel = Math.Max(nPixel, 0);
                        p[0] = (byte)Math.Min(255, nPixel);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            image.UnlockBits(bmData);
            pictureBox1.Image = image;
        }
    }

    public static class Globals
    {
        public static int red, green, blue;
        public static bool isValid;

        internal static void Reset()
        {
            red = green = blue = 0;
        }
    }
}