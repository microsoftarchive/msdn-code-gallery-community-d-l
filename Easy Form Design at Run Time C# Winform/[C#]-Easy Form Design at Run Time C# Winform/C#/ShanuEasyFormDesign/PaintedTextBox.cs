using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShanuEasyFormDesign
{
    class PaintedTextBox : System.Windows.Forms.TextBox
    {
        public PaintedTextBox() : base() { SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true); this.Multiline = true; }

        public System.Drawing.Bitmap BitmapImage
        {
            set;
            get;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            System.Drawing.Image img = BitmapImage as System.Drawing.Image;
            e.Graphics.DrawImage(img, new System.Drawing.Point(this.Width - (img.Width), 0));

        }

    }
}
