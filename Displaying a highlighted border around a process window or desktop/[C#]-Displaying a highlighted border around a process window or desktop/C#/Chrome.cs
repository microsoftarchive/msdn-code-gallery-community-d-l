using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ChromeSample
{
    public partial class Chrome : Form
    {
        private Rectangle innerRectangle;
        private Rectangle outerRectangle;
        private int BorderWidth;
        private Color fillColor = Color.Yellow; //Change the color of the chrome fill
        private Color borderColor = Color.Yellow; //Change the color of the border
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cX, int cY, uint uFlags);

        public Chrome()
        {
            InitializeComponent();
            BackColor = fillColor;
            ForeColor = borderColor;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            base.Text = "";

        }

        public void Highlight(Rectangle rectangle, bool desktop, int borderWidth)
        {
            BorderWidth = borderWidth;
            SetLocation(rectangle, desktop);
            if (desktop)
            {
                SetWindowPos(this.Handle, new IntPtr(-1), 0, 0, 0, 0, 0x43);
            }
            else
            {
                SetWindowPos(this.Handle, new IntPtr(0), 0, 0, 0, 0, 0x43);
            }

            Show();
        }

        public void SetLocation(Rectangle rectangle, bool desktop)
        {

            int width = BorderWidth;
            if (desktop)
            {
                this.TopMost = true;
                outerRectangle = new Rectangle(new Point(0, 0), rectangle.Size);
                //have to offset to make sure the border inside the bounds of desktop
                innerRectangle = new Rectangle(new Point(BorderWidth, BorderWidth), rectangle.Size - new Size(BorderWidth * 2, BorderWidth * 2));
                Region region = new Region(outerRectangle);
                region.Exclude(innerRectangle);
                base.Location = rectangle.Location;
                base.Size = outerRectangle.Size;
                base.Region = region;
            }
            else
            {
                this.TopMost = false;
                //have to offset to make sure the border is outside the application window
                outerRectangle = new Rectangle(new Point(0, 0), rectangle.Size + new Size(width * 2, width * 2));
                innerRectangle = new Rectangle(new Point(BorderWidth, BorderWidth), rectangle.Size);
                Region region = new Region(outerRectangle);
                region.Exclude(innerRectangle);
                base.Location = rectangle.Location - new Size(width, width);
                base.Size = outerRectangle.Size;
                base.Region = region;
            }


        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Rectangle rect = new Rectangle(outerRectangle.Left, outerRectangle.Top, outerRectangle.Width, outerRectangle.Height);
            Rectangle rectangle2 = new Rectangle(innerRectangle.Left, innerRectangle.Top, innerRectangle.Width, innerRectangle.Height);
            e.Graphics.DrawRectangle(new Pen(ForeColor), rectangle2);
            e.Graphics.DrawRectangle(new Pen(ForeColor), rect);
        }

        public void Show()
        {
            SetWindowPos(base.Handle, IntPtr.Zero, 0, 0, 0, 0, 0x53);
        }

    }
}
