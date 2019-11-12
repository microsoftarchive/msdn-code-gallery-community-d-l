using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thermometers_cs
{
    public partial class Form1 : Form
    {

        //class level bitmaps
        Bitmap img;
        Bitmap bar;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize class level bitmaps
            img = Properties.Resources.tempscalessmall;
            bar = Properties.Resources.bar;
            //make Color.White transparent in bar image
            bar.MakeTransparent(Color.White);
            //trigger NumericUpDowns.ValueChanged
            NumericUpDown1.Value += 1;
            NumericUpDown1.Value -= 1;
        }

        private void NumericUpDowns_ValueChanged(object sender, EventArgs e)
        {
            //if still loading exit sub
            if (NumericUpDown1.Value == null | NumericUpDown2.Value == null | NumericUpDown3.Value == null | img == null | bar == null)
                return;

            //create new background image for thermometers
            Bitmap newImg = new Bitmap(img);
            Graphics gr = Graphics.FromImage(newImg);

            //calculate height of bar1
            int barTop = (NumericUpDown1.Value > 290 ? 2 : 0) + Convert.ToInt32(255 - (((250 - NumericUpDown1.Value) / 10) * -20));
            //create a new bitmap for this thermometer bar
            Bitmap bar1 = new Bitmap(12, 264 - barTop);
            Graphics gr1 = Graphics.FromImage(bar1);
            //draw part of original bar image into new bitmap
            gr1.DrawImage(bar, new Rectangle(Point.Empty, bar1.Size), new Rectangle(0, Properties.Resources.bar.Height - bar1.Height, 12, bar1.Height), GraphicsUnit.Pixel);
            //draw new bar image onto new background image
            gr.DrawImage(bar1, new Point(61, barTop));

            //calculate height of bar2
            barTop = (NumericUpDown2.Value > 0 ? 9 : 7) + Convert.ToInt32(((100 - NumericUpDown2.Value) / 10) * 20);
            //create a new bitmap for this thermometer bar
            Bitmap bar2 = new Bitmap(12, 264 - barTop);
            Graphics gr2 = Graphics.FromImage(bar2);
            //draw part of original bar image into new bitmap
            gr2.DrawImage(bar, new Rectangle(Point.Empty, bar2.Size), new Rectangle(0, Properties.Resources.bar.Height - bar2.Height, 12, bar2.Height), GraphicsUnit.Pixel);
            //draw new bar image onto new background image
            gr.DrawImage(bar2, new Point(162, barTop));

            //calculate height of bar3
            barTop = 15 + Convert.ToInt32(((210 - NumericUpDown3.Value) / 10) * 11);
            //create a new bitmap for this thermometer bar
            Bitmap bar3 = new Bitmap(12, 264 - barTop);
            Graphics gr3 = Graphics.FromImage(bar3);
            //draw part of original bar image into new bitmap
            gr3.DrawImage(bar, new Rectangle(Point.Empty, bar3.Size), new Rectangle(0, Properties.Resources.bar.Height - bar3.Height, 12, bar3.Height), GraphicsUnit.Pixel);
            //draw new bar image onto new background image
            gr.DrawImage(bar3, new Point(266, barTop));

            //set PictureBox1.Image = new background image
            PictureBox1.Image = newImg;
        }
    }
}
