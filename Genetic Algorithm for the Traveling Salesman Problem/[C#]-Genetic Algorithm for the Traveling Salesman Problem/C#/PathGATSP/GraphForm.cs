using System;
using System.Drawing;
using System.Windows.Forms;

namespace PathGATSP
{
    public partial class GraphForm : Form
    {
        double[] x;
        double[] y;

        int[] city;

        public GraphForm(double[] x, double[] y, int[] city)
        {
            InitializeComponent();

            this.x = y;
            this.y = x;
            this.city = city;
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            base.OnPaint(pea);

            Graphics grfx = pea.Graphics;
            RectangleF clipRect = grfx.VisibleClipBounds;

            grfx.Clear(Color.White);

            double xMax = double.MinValue;
            double xMin = double.MaxValue;
            double yMax = double.MinValue;
            double yMin = double.MaxValue;

            float dx = clipRect.Width - 16f;
            float dy = clipRect.Height - 16f;
            int number = x.Length;

            Text = "GraphForm " + (number - 1).ToString() + " City Tour";

            for (int n = 0; n < number; n++)
            {
                if (x[n] < xMin)
                    xMin = x[n];

                if (x[n] > xMax)
                    xMax = x[n];

                if (y[n] < yMin)
                    yMin = y[n];

                if (y[n] > yMax)
                    yMax = y[n];
            }

            double chiSlope = dx / (xMax - xMin);
            double chiInter = clipRect.Left + 8 - chiSlope * xMin;
            double etaSlope = dy / (yMin - yMax);
            double etaInter = clipRect.Top + 8 - etaSlope * yMax;

            Pen blackPen = new Pen(Color.Black);
            Pen redPen = new Pen(Color.Red, 2f);

            for (int n = 0; n < number - 1; n++)
            {
                float chi1 = (float)(chiSlope * x[n] + chiInter);
                float eta1 = (float)(etaSlope * y[n] + etaInter);
                float chi2 = (float)(chiSlope * x[n + 1] + chiInter);
                float eta2 = (float)(etaSlope * y[n + 1] + etaInter);

                grfx.DrawLine(redPen, chi1 - 1, eta1 - 1, chi1 + 1, eta1 + 1);
                grfx.DrawLine(redPen, chi2 - 1, eta2 - 1, chi2 + 1, eta2 + 1);
                grfx.DrawLine(blackPen, chi1, eta1, chi2, eta2);
            }
        }
    }
}
