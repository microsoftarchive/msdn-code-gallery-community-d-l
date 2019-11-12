using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class FormZoom : Form
    {
        private Size Multiplier;
        private bool draw = false;
        private int s = 3;
        private Color color = Color.Black ;
        Image Second = null;
        Image Original = null;


        public FormZoom()
        {
            InitializeComponent();
        }

        public void ZoomIn()
        {
            Multiplier = new Size(2,2);

            Image MyImage = pictureBox1.Image;

            Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(MyImage.Width * Multiplier.Width),
                Convert.ToInt32(MyImage.Height * Multiplier.Height));

            Graphics Graphic = Graphics.FromImage(MyBitMap);

            Graphic.InterpolationMode = InterpolationMode.High ;

            pictureBox1.Image = MyBitMap;

        }

        public void ZoomOut()
        {
            Multiplier = new Size(2, 2);

            Image MyImage = pictureBox1.Image;

            Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(MyImage.Width / Multiplier.Width),
                Convert.ToInt32(MyImage.Height / Multiplier.Height));

            Graphics Graphic = Graphics.FromImage(MyBitMap);

            Graphic.InterpolationMode = InterpolationMode.High ;

            pictureBox1.Image = MyBitMap;

        }

        public void ZoomTick()
        {
            if (trackBar1.Value > 0)
            {
                Multiplier = new Size(trackBar1.Value, trackBar1.Value);

                Image MyImage = pictureBox1.Image;

                Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(MyImage.Width * Multiplier.Width),
                    Convert.ToInt32(MyImage.Height * Multiplier.Height));

                Graphics Graphic = Graphics.FromImage(MyBitMap);

                Graphic.InterpolationMode = InterpolationMode.High;

                pictureBox1.Image = MyBitMap;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.Rotate90FlipNone );
            pictureBox1.Image = im;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.Rotate270FlipNone );
            pictureBox1.Image = im;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = im;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = im;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString() ;
        }

      
        private void btn_up_Click(object sender, EventArgs e)
        {            
            Point startPoint = new Point(pictureBox1.Location.X,
                pictureBox1.Location.Y-10);
            pictureBox1.Location = startPoint;            
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            Point startPoint = new Point(pictureBox1.Location.X,
                pictureBox1.Location.Y + 10);
            pictureBox1.Location = startPoint;
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            Point startPoint = new Point(pictureBox1.Location.X+10,
                pictureBox1.Location.Y);
            pictureBox1.Location = startPoint;
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            Point startPoint = new Point(pictureBox1.Location.X-10,
                pictureBox1.Location.Y);
            pictureBox1.Location = startPoint;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Image MyImage = pictureBox1.Image;

            Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(textBox1.Text),
                Convert.ToInt32(textBox2.Text));

            Graphics Graphic = Graphics.FromImage(MyBitMap);

            Graphic.InterpolationMode = InterpolationMode.High;

            pictureBox1.Image = MyBitMap;
        }

       
      
        private void button9_Click(object sender, EventArgs e)
        {
            ZoomTick();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Original = pictureBox1.Image;
            Second = pictureBox1.Image;
            draw = true;
            Graphics g = Graphics.FromImage(Second);
            Pen pen1 = new Pen(color, 4);
            g.DrawRectangle(pen1, e.X, e.Y, 2, 2);
            g.Save();
            pictureBox1.Image = Second;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics g = Graphics.FromImage(Second);
                SolidBrush brush = new SolidBrush(color);
                g.FillRectangle(brush, e.X, e.Y, s, s);
                g.Save();
                pictureBox1.Image = Second;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            Color newcolor = cd.Color;
            color = newcolor;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text)&&!textBox3.Text.Equals("Name mandatory"))
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                fd.ShowDialog();
                if (fd.SelectedPath != null)
                {
                    string path = fd.SelectedPath;
                    Bitmap mp = new Bitmap(pictureBox1.Image);
                    mp.Save(path + @"\" + textBox3.Text + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            else
            {
                textBox3.Text = "Name mandatory";
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox3.ResetText();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.ShowDialog();
            string PathToImage = OpenDialog.FileName;
            Bitmap BitMapImage = new Bitmap(Image.FromFile(PathToImage));
            Image DisplayImage = BitMapImage;
            pictureBox1.Image = DisplayImage;
        }          

    
      



     
        
    }
}
