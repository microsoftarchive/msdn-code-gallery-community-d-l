#region Copyright
//=======================================================================================
// Microsoft Business Platform Division Customer Advisory Team (CAT)  
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://www.windowsazurecat.com/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
#endregion

#region Using References

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace Microsoft.AzureCat.Samples.DeviceEmulator
{
    public partial class HeaderPanel : Panel
    {
        #region Private Fields
        private int headerHeight = 24;
        private string headerText = "header title";
        private Font headerFont = new Font("Arial", 10F, FontStyle.Bold);
        private Color headerColor1 = SystemColors.InactiveCaption;
        private Color headerColor2 = SystemColors.ActiveCaption;
        private Color iconTransparentColor = Color.White;
        private Image icon = null;
        #endregion

        #region Public Properties
        [Browsable(true), Category("Custom")]
        public string HeaderText
        {
            get { return headerText; }
            set
            {
                headerText = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Custom")]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set
            {
                headerHeight = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Custom")]
        public Font HeaderFont
        {
            get { return headerFont; }
            set
            {
                headerFont = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Custom")]
        public Color HeaderColor1
        {
            get { return headerColor1; }
            set
            {
                headerColor1 = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Custom")]
        public Color HeaderColor2
        {
            get { return headerColor2; }
            set
            {
                headerColor2 = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Custom")]
        public Image Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Custom")]
        public Color IconTransparentColor
        {
            get { return iconTransparentColor; }
            set
            {
                iconTransparentColor = value;
                Invalidate();
            }
        }
        #endregion

        #region Public Constructors
        public HeaderPanel()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            Padding = new Padding(5, headerHeight + 4, 5, 4);
        }
        #endregion

        #region Private Methods
        private void OutlookPanelEx_Paint(object sender, PaintEventArgs e)
        {
            if (headerHeight > 1)
            {
                // Draw border;
                DrawBorder(e.Graphics);

                // Draw heaeder
                DrawHeader(e.Graphics);

                // Draw text
                DrawText(e.Graphics);

                // Draw Icon
                DrawIcon(e.Graphics);
            }
        }

        private void DrawBorder(Graphics graphics)
        {
            using (Pen pen = new Pen(this.headerColor2))
            {
                graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void DrawHeader(Graphics graphics)
        {
            Rectangle headerRect = new Rectangle(1, 1, this.Width - 2, this.headerHeight);
            using (Brush brush = new LinearGradientBrush(headerRect, headerColor1, headerColor2, LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, headerRect);
            }
        }

        private void DrawText(Graphics graphics)
        {
            if (!string.IsNullOrEmpty(this.headerText))
            {
                SizeF size = graphics.MeasureString(this.headerText, this.headerFont);
                using (Brush brush = new SolidBrush(ForeColor))
                {
                    float x;
                    if (this.icon != null)
                    {
                        x = this.icon.Width + 6;
                    }
                    else
                    {
                        x = 4;
                    }
                    graphics.DrawString(this.headerText, this.headerFont, brush, x, (headerHeight - size.Height) / 2);
                }
            }
        }

        private void DrawIcon(Graphics graphics)
        {
            if (this.icon != null)
            {
                Point point = new Point(4, (headerHeight - icon.Height) / 2);
                Bitmap bitmap = new Bitmap(icon);
                bitmap.MakeTransparent(iconTransparentColor);
                graphics.DrawImage(bitmap, point);
            }
        }
        #endregion
    }
}