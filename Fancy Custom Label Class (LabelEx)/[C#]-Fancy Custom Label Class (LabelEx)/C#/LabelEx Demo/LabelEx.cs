using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
//If you are using this code to build a Class Library Project instead of just adding it to a Form Project then you
//will need to add a reference to System.Drawing and System.Windows.Forms for the next three Imports. You can do
//that after you create the new Class Library by going to the VB menu and clicking (Project) and then selecting (Add Reference...).
//Then on the (.Net) tab you can find and select (System.Drawing) and (System.Windows.Forms) to add the references.
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LabelEx_Demo
{
    public class LabelEx : Control
    {

        //Add all of the Property Backing Feilds for the Properties added to the LabelEx class
        private Pen _OutLinePen = new Pen(Color.Black);
        private Pen _BorderPen = new Pen(Color.Black);
        private SolidBrush _CenterBrush = new SolidBrush(Color.White);
        private SolidBrush _BackgroundBrush = new SolidBrush(Color.Transparent);
        private BorderType _BorderStyle = BorderType.None;
        private Bitmap _Image = null;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        private Bitmap _TextPatternImage = null;
        private PatternLayout _TextPatternImageLayout = PatternLayout.Stretch;
        private SolidBrush _ShadowBrush = new SolidBrush(Color.FromArgb(128, Color.Black));
        private Pen _ShadowPen = new Pen(Color.FromArgb(128, Color.Black));
        private Color _ShadowColor = Color.Black;
        private bool _ShowTextShadow = false;
        private ShadowArea _ShadowPosition = ShadowArea.BottomRight;
        private int _ShadowDepth = 2;
        private int _ShadowTransparency = 128;
        private ShadowDrawingType _ShadowStyle = ShadowDrawingType.FillShadow;
        private int _ForeColorTransparency = 255;
        private int _OutlineThickness = 1;

        //Declare the Enums used for some of the special selections we want to use for some of the properties

        /// <summary>Enum of BorderTypes used for the Labels BorderStyle.</summary>
        public enum BorderType : int
        {
            None = 0,
            Squared = 1,
            Rounded = 2
        }

        /// <summary>Enum of layout styles used for the Labels TextPaternImage.</summary>
        public enum PatternLayout : int
        {
            Normal = 0,
            Center = 1,
            Stretch = 2,
            Tile = 3
        }

        /// <summary>Enum of areas used for the Labels ShadowPosition.</summary>
        public enum ShadowArea : int
        {
            TopLeft = 0,
            TopRight = 1,
            BottomLeft = 2,
            BottomRight = 3
        }

        /// <summary>Enum of drawing types used for the Labels ShadowStyle.</summary>
        public enum ShadowDrawingType : int
        {
            DrawShadow = 0,
            FillShadow = 1
        }

        //In the constructor we set all the styles we want the LabelEx control to have when it is created.
        //We also set a few properties that we want the control to have set by default when a new instance is created.
        public LabelEx()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.Font = new Font("Comic Sans MS", 18, FontStyle.Bold);
            this.Size = new Size(130, 38);
            this.ForeColor = Color.White;
            this.BackColor = Color.Transparent;
        }

        //Create all of the properties we want the control to have and Override the ones it already has if they need to be used for special reasons. 

        [Category("Appearance"), Description("The background color of the Label.")]
        [Browsable(true), DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                _BackgroundBrush.Color = value;
            }
        }

        [Category("Appearance"), Description("The center color of the text.")]
        [Browsable(true), DefaultValue(typeof(Color), "White")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                if (value == Color.Transparent)
                    _ForeColorTransparency = 0;
                _CenterBrush.Color = Color.FromArgb(_ForeColorTransparency, value);
            }
        }

        [Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the ForeColor.")]
        [Browsable(true), DefaultValue(255)]
        public int ForeColorTransparency
        {
            get { return _ForeColorTransparency; }
            set
            {
                if (value > 255)
                    value = 255;
                if (value < 0 | this.ForeColor == Color.Transparent)
                    value = 0;
                _ForeColorTransparency = value;
                _CenterBrush.Color = Color.FromArgb(value, this.ForeColor);
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Aligns the text to the left, right, top, or bottom of the Label.")]
        [Browsable(true), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The Image for the Label.")]
        [Browsable(true)]
        public Bitmap Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Aligns the Image to the left, right, top, or bottom.")]
        [Browsable(true), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The outline color of the text.")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        public Color OutlineColor
        {
            get { return _OutLinePen.Color; }
            set
            {
                _OutLinePen.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The thickness of the text outline. Limited to a number between 1 and 10.")]
        [Browsable(true), DefaultValue(1)]
        public int OutlineThickness
        {
            get { return _OutlineThickness; }
            set
            {
                if (value < 1)
                    value = 1;
                //Dont let the user set lower than 1
                if (value > 10)
                    value = 10;
                //Dont let the user set higher than 10
                _OutlineThickness = value;
                _OutLinePen.Width = value;
                _ShadowPen.Width = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The color of the Labels border.")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return _BorderPen.Color; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BorderPen.Color;
                    //Set it back to the prior color
                    //Alert the user that Color.Transparent is not supported for this property
                    throw new Exception("The border color does not support the Transparent color");
                }
                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The style of the border around the Label.")]
        [Browsable(true), DefaultValue(typeof(BorderType), "None")]
        public BorderType BorderStyle
        {
            get { return _BorderStyle; }
            set
            {
                _BorderStyle = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("An image used as a fill pattern for the center of the text.")]
        [Browsable(true)]
        public Bitmap TextPatternImage
        {
            get { return _TextPatternImage; }
            set
            {
                _TextPatternImage = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The layout of the pattern image inside the text.")]
        [Browsable(true), DefaultValue(typeof(PatternLayout), "Stretch")]
        public PatternLayout TextPatternImageLayout
        {
            get { return _TextPatternImageLayout; }
            set
            {
                _TextPatternImageLayout = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Show a shadow behind the text.")]
        [Browsable(true), DefaultValue(false)]
        public bool ShowTextShadow
        {
            get { return _ShowTextShadow; }
            set
            {
                _ShowTextShadow = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The color of the shadow behind the text.")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        public Color ShadowColor
        {
            get { return _ShadowColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ShadowBrush.Color;
                    //Set it back to the prior color
                    //Alert the user that Color.Transparent is not supported for this property
                    throw new Exception("The Shadow color does not support using Color.Transparent");
                }
                _ShadowColor = value;
                _ShadowBrush.Color = Color.FromArgb(_ShadowTransparency, value);
                _ShadowPen.Color = Color.FromArgb(_ShadowTransparency, value);
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The position of the shadow behind the text.")]
        [Browsable(true), DefaultValue(typeof(ShadowArea), "BottomRight")]
        public ShadowArea ShadowPosition
        {
            get { return _ShadowPosition; }
            set
            {
                _ShadowPosition = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("A value between 1-10 that controls the depth of the shadow behind the text.")]
        [Browsable(true), DefaultValue(2)]
        public int ShadowDepth
        {
            get { return _ShadowDepth; }
            set
            {
                if (value < 1)
                    value = 1;
                //Dont let user set this property lower than 1
                if (value > 10)
                    value = 10;
                //Dont let user set this property higher than 10
                _ShadowDepth = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the shadow.")]
        [Browsable(true), DefaultValue(128)]
        public int ShadowTransparency
        {
            get { return _ShadowTransparency; }
            set
            {
                if (value < 0)
                    value = 0;
                //Dont let user set this property lower than 0
                if (value > 255)
                    value = 255;
                //Dont let user set this property higher than 255
                _ShadowTransparency = value;
                _ShadowBrush.Color = Color.FromArgb(value, _ShadowColor);
                _ShadowPen.Color = Color.FromArgb(value, _ShadowColor);
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The style used to draw the shadow.")]
        [Browsable(true), DefaultValue(typeof(ShadowDrawingType), "FillShadow")]
        public ShadowDrawingType ShadowStyle
        {
            get { return _ShadowStyle; }
            set
            {
                _ShadowStyle = value;
                this.Refresh();
            }
        }


        //Use the OnPaint overrides sub to paint the control to match how all the properties settings have been set by the user
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var _with1 = e.Graphics;
            //Fill the background with the BackColor color
            _with1.FillRectangle(_BackgroundBrush, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            //If the BackgroundImage property has been set to an image then draw the BackgroundImage
            if (this.BackgroundImage != null)
            {
                DrawBackImage(e.Graphics);
            }

            //If the Image property has been set to an image then draw the image on the control
            if (_Image != null)
            {
                _with1.DrawImage(_Image, AlignImage(new Rectangle(0, 0, this.Width - 1, this.Height - 1)));
            }

            //If the Text property has bet assigned any text then draw the text on the control
            if (!string.IsNullOrEmpty(this.Text))
            {
                //Set the smothing mode of the graphics to make things look smother
                //_with1.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias;
                _with1.SmoothingMode = SmoothingMode.AntiAlias;

                //The Drawing2D.GraphicsPath used for drawing and/or filling the text
                using (GraphicsPath pth = new GraphicsPath())
                {

                    //The StringFormat used to align the text in the Label
                    using (StringFormat sf = new StringFormat())
                    {
                        //Use (ta) which is an integer value of the ContentAlignment integer enum to set the
                        //Alignment of the text that will be added to the Drawing2D.GraphicsPath
                        int ta = Convert.ToInt32(_TextAlign);
                        if (ta < 8)
                        {
                            sf.LineAlignment = StringAlignment.Near;
                        }
                        else if (ta < 128)
                        {
                            sf.LineAlignment = StringAlignment.Center;
                            ta = ta / 16;
                        }
                        else
                        {
                            sf.LineAlignment = StringAlignment.Far;
                            ta = ta / 256;
                        }
                        if (ta == Convert.ToInt32(ContentAlignment.TopLeft))
                        {
                            sf.Alignment = StringAlignment.Near;
                        }
                        else if (ta == Convert.ToInt32(ContentAlignment.TopCenter))
                        {
                            sf.Alignment = StringAlignment.Center;
                        }
                        else if (ta == Convert.ToInt32(ContentAlignment.TopRight))
                        {
                            sf.Alignment = StringAlignment.Far;
                        }
                        //Add the text to the Drawing2D.GraphicsPath using the StringFormat
                        pth.AddString(this.Text, this.Font.FontFamily, Convert.ToInt32(this.Font.Style), Convert.ToSingle((_with1.DpiY * this.Font.Size) / 72), new Rectangle(this.Padding.Left, this.Padding.Top, (this.ClientSize.Width - 1) - (this.Padding.Left + this.Padding.Right), (this.ClientSize.Height - 1) - (this.Padding.Top + this.Padding.Bottom)), sf);
                    }

                    //If the ShowTextShadow property is set to true then draw the shadow
                    if (_ShowTextShadow)
                    {
                        //Use the ShadowPosition property to set the Graphics.TranslateTransform to draw the
                        //shadow at the correct offset position.
                        if (_ShadowPosition == ShadowArea.TopLeft)
                        {
                            _with1.TranslateTransform(-_ShadowDepth, -_ShadowDepth);
                        }
                        else if (_ShadowPosition == ShadowArea.TopRight)
                        {
                            _with1.TranslateTransform(+_ShadowDepth, -_ShadowDepth);
                        }
                        else if (_ShadowPosition == ShadowArea.BottomLeft)
                        {
                            _with1.TranslateTransform(-_ShadowDepth, +_ShadowDepth);
                        }
                        else
                        {
                            _with1.TranslateTransform(+_ShadowDepth, +_ShadowDepth);
                        }

                        if (_ShadowStyle == ShadowDrawingType.DrawShadow)
                        {
                            //Draw the Drawing2D.GraphicsPath with the _ShadowPen that is set to the ShadowColor having the ShadowTransparency
                            _with1.DrawPath(_ShadowPen, pth);
                            //Draws the shadow
                        }
                        else
                        {
                            //Fill the Drawing2D.GraphicsPath with the _ShadowBrush that is set to the ShadowColor having the ShadowTransparency
                            _with1.FillPath(_ShadowBrush, pth);
                            //Draws the shadow
                        }


                        //Now use the Graphics.TranslateTransform to shift the graphics back in the opposite
                        //direction before Drawing and Filling the Drawing2D.GraphicsPath again with text colors
                        if (_ShadowPosition == ShadowArea.TopLeft)
                        {
                            _with1.TranslateTransform(+(_ShadowDepth * 2), +(_ShadowDepth * 2));
                        }
                        else if (_ShadowPosition == ShadowArea.TopRight)
                        {
                            _with1.TranslateTransform(-(_ShadowDepth * 2), +(_ShadowDepth * 2));
                        }
                        else if (_ShadowPosition == ShadowArea.BottomLeft)
                        {
                            _with1.TranslateTransform(+(_ShadowDepth * 2), -(_ShadowDepth * 2));
                        }
                        else
                        {
                            _with1.TranslateTransform(-(_ShadowDepth * 2), -(_ShadowDepth * 2));
                        }
                    }

                    //If the TextPatternImage property has been set to an image then fill the center of the text with the image
                    //else the center will be filled with a soloid color of the ForeColor property.
                    if (_TextPatternImage != null)
                    {
                        //Use the TextPatternImageLayout property to resize and/or position the TextPatternImage
                        Rectangle br = new Rectangle();
                        RectangleF r = pth.GetBounds();
                        if (_TextPatternImageLayout == PatternLayout.Normal | _TextPatternImageLayout == PatternLayout.Tile)
                        {
                            br = new Rectangle(Convert.ToInt32(r.X) + 1, Convert.ToInt32(r.Y + 1), _TextPatternImage.Width + 1, _TextPatternImage.Height + 1);
                        }
                        else if (_TextPatternImageLayout == PatternLayout.Center)
                        {
                            int xx = Convert.ToInt32((r.X + 1) + ((r.Width / 2) - (_TextPatternImage.Width / 2)));
                            int yy = Convert.ToInt32((r.Y + 1) + ((r.Height / 2) - (_TextPatternImage.Height / 2)));
                            br = new Rectangle(xx, yy, _TextPatternImage.Width + 1, _TextPatternImage.Height + 1);
                        }
                        else if (_TextPatternImageLayout == PatternLayout.Stretch)
                        {
                            br = new Rectangle(Convert.ToInt32(r.X) + 1, Convert.ToInt32(r.Y + 1), Convert.ToInt32(r.Width) + 1, Convert.ToInt32(r.Height) + 1);
                        }
                        using (Bitmap patBmp = new Bitmap(_TextPatternImage, br.Width, br.Height))
                        {
                            //Use a TextureBrush with the TextPatternImage assigned as the texture image
                            using (TextureBrush tb = new TextureBrush(patBmp))
                            {
                                //If the TextPatternImageLayout property is not set to Tile then set the set the
                                //TextureBrush`s WrapMode to Clamp to stop it from tiling the image.
                                if (!(_TextPatternImageLayout == PatternLayout.Tile))
                                    tb.WrapMode = WrapMode.Clamp;
                                tb.TranslateTransform(br.X, br.Y);
                                //Fill the GraphicsPath with the TextureBrush.
                                _with1.FillPath(tb, pth);
                            }
                        }
                    }
                    else
                    {
                        //Fill the GraphicsPath with a soloid color of the ForeColor property.
                        _with1.FillPath(_CenterBrush, pth);
                    }
                    //Draw the GraphicsPath with the OutlineColor.
                    _with1.DrawPath(_OutLinePen, pth);
                }
            }

            //If the BorderStyle property is other than None then call the DrawBorder sub to draw the border
            if (_BorderStyle != BorderType.None)
            {
                DrawLabelBorder(e.Graphics, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        //A private sub used to position, resize, and draw the BackgroundImage according to the BackgroundImageLayout
        private void DrawBackImage(Graphics g)
        {
            if (this.BackgroundImageLayout == ImageLayout.None)
            {
                g.DrawImage(this.BackgroundImage, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Tile)
            {
                int tc = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.Width / this.BackgroundImage.Width)));
                int tr = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.Height / this.BackgroundImage.Height)));
                for (int y = 0; y <= tr; y++)
                {
                    for (int x = 0; x <= tc; x++)
                    {
                        g.DrawImage(this.BackgroundImage, (x * this.BackgroundImage.Width), (y * this.BackgroundImage.Height), this.BackgroundImage.Width, this.BackgroundImage.Height);
                    }
                }
            }
            else if (this.BackgroundImageLayout == ImageLayout.Center)
            {
                int xx = Convert.ToInt32((this.Width / 2) - (this.BackgroundImage.Width / 2));
                int yy = Convert.ToInt32((this.Height / 2) - (this.BackgroundImage.Height / 2));
                g.DrawImage(this.BackgroundImage, xx, yy, this.BackgroundImage.Width, this.BackgroundImage.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Stretch)
            {
                g.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Zoom)
            {
                double meratio = this.Width / this.Height;
                double imgratio = this.BackgroundImage.Width / this.BackgroundImage.Height;
                Rectangle imgrect = new Rectangle(0, 0, this.Width, this.Height);
                if (imgratio > meratio)
                {
                    imgrect.Width = this.Width;
                    imgrect.Height = Convert.ToInt32(this.Width / imgratio);
                }
                else if (imgratio < meratio)
                {
                    imgrect.Height = this.Height;
                    imgrect.Width = Convert.ToInt32(this.Height * imgratio);
                }
                imgrect.X = Convert.ToInt32((this.Width / 2) - (imgrect.Width / 2));
                imgrect.Y = Convert.ToInt32((this.Height / 2) - (imgrect.Height / 2));
                g.DrawImage(this.BackgroundImage, imgrect);
            }
        }

        //A private sub used for drawing the Border part of the control
        private void DrawLabelBorder(Graphics g, Rectangle rec)
        {
            //If the ShowTextShadow property is true and the Text property is not an empty string then because of the
            //prior calls to the Graphics.TranslateTransform used for the shadow effect the Graphics must be shifted
            //back to its center position before drawing the border.
            if (_ShowTextShadow & !string.IsNullOrEmpty(this.Text))
            {
                if (_ShadowPosition == ShadowArea.TopLeft)
                {
                    g.TranslateTransform(-_ShadowDepth, -_ShadowDepth);
                }
                else if (_ShadowPosition == ShadowArea.TopRight)
                {
                    g.TranslateTransform(+_ShadowDepth, -_ShadowDepth);
                }
                else if (_ShadowPosition == ShadowArea.BottomLeft)
                {
                    g.TranslateTransform(-_ShadowDepth, +_ShadowDepth);
                }
                else
                {
                    g.TranslateTransform(+_ShadowDepth, +_ShadowDepth);
                }
            }

            //If the BorderStyle property is set to Rounded then draw the border with rounded corners
            //else just draw a Rectangle
            if (_BorderStyle == BorderType.Rounded)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    int rad = Convert.ToInt32(rec.Height / 3);
                    if (rec.Width < rec.Height)
                        rad = Convert.ToInt32(rec.Width / 3);
                    gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                    gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90);
                    gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90);
                    gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90);
                    gp.CloseFigure();
                    g.DrawPath(_BorderPen, gp);
                }
            }
            else
            {
                g.DrawRectangle(_BorderPen, rec.X, rec.Y, rec.Width, rec.Height);
            }
        }

        //A private function used for calculating the rectagle area of the Label to draw the Image in
        private Rectangle AlignImage(Rectangle Rect)
        {
            //Use the value of the ContentAlignment assigned to the ImageAlign property to set the X and Y
            //values of the returned rectangle for the image.
            int xp = 0;
            int yp = 0;
            int ia = Convert.ToInt32(_ImageAlign);
            if (ia < 8)
            {
                yp = 0 + this.Padding.Top;
            }
            else if (ia < 128)
            {
                yp = Convert.ToInt32(Rect.Height / 2) - Convert.ToInt32(_Image.Height / 2);
                ia = ia / 16;
            }
            else
            {
                yp = Rect.Height - _Image.Height - this.Padding.Bottom;
                ia = ia / 256;
            }
            if (ia == Convert.ToInt32(ContentAlignment.TopLeft))
            {
                xp = 0 + this.Padding.Left;
            }
            else if (ia == Convert.ToInt32(ContentAlignment.TopCenter))
            {
                xp = Convert.ToInt32(Rect.Width / 2) - Convert.ToInt32(_Image.Width / 2);
            }
            else if (ia == Convert.ToInt32(ContentAlignment.TopRight))
            {
                xp = Rect.Width - _Image.Width - this.Padding.Right;
            }
            return new Rectangle(xp, yp, _Image.Width, _Image.Height);
        }

        //Need to use the OnTextChanged overrides sub to make the Label repaint itself when the text is changed
        protected override void OnTextChanged(System.EventArgs e)
        {
            this.Refresh();
            base.OnTextChanged(e);
        }

        //Need to use the Dispose Overides sub to make sure all of the New brushes and pens created for the
        //property backing feilds are disposed.
        protected override void Dispose(bool disposing)
        {
            this._BackgroundBrush.Dispose();
            this._BorderPen.Dispose();
            this._CenterBrush.Dispose();
            this._OutLinePen.Dispose();
            this._ShadowBrush.Dispose();
            this._ShadowPen.Dispose();
            base.Dispose(disposing);
        }
    }
}
