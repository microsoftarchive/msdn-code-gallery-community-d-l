using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        private double xMinimum, xMaximum;
        private double yMinimum, yMaximum;
        private int iterations, pixels;
        private Brush brush;
        private Complex bottomLeft;

        public MandelbrotForm()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xMinimum = Convert.ToDouble(textBox1.Text);
            xMaximum = Convert.ToDouble(textBox2.Text);
            yMinimum = Convert.ToDouble(textBox3.Text);
            yMaximum = Convert.ToDouble(textBox4.Text);
            iterations = Convert.ToInt32(textBox5.Text);
            pixels = Convert.ToInt32(textBox6.Text);

            if (pixels > 220)
            {
                pixels = 220;
                textBox6.Text = Convert.ToString(pixels);
                System.Windows.Forms.MessageBox.Show(
                    "pixels being set to maximum of 220",
                    "Number Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            bottomLeft = new Complex(xMinimum, yMinimum);
            brush = new SolidBrush(SystemColors.WindowText);
            panel1.Invalidate();
        }

        bool PrintPixel(double c1, double c2)
        {
            bool testValue = false;
            int count = 0;
            Complex c = new Complex(c1, c2), z = new Complex();

            while (count < iterations)
            {
                count++;
                z = z * z + c;
                testValue = Complex.abs(z) < 2.0;

                if (!testValue)
                    break;
            }

            return testValue;
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            double scale = 100.0 * (xMaximum - xMinimum) / pixels;
            int width = panel1.Width - 1;
            int height = panel1.Height - 1;
            Graphics g = e.Graphics;

            for (int ct1 = -2 * pixels; ct1 < 2 * pixels; ct1++)
            {
                for (int ct2 = -2 * pixels; ct2 < 2 * pixels; ct2++)
                {
                    double x = ct1 * scale + bottomLeft.Real;
                    double y = ct2 * scale + bottomLeft.Imag;

                    if (PrintPixel(x, y))
                        g.FillEllipse(brush,
                            ct1 + width / 2 + 128,
                            ct2 + height / 2,
                            2,
                            2);
                }
            }
        }
    }
}
