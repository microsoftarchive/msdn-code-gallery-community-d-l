using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Drawing.Text;
using System.Reflection;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using System.Data.SqlClient;
/// <summary>
/// Author      : Shanu
/// Create date : 2014-09-26
/// Description : User can create there own Form Design at Runtime
/// Latest
/// Modifier    : 
/// Modify date : 
/// </summary>
namespace ShanuEasyFormDesign
{
    public partial class frmMaindesign : Form
    {

        #region Attribute
        //////////////////////////////////
        /// <summary>
        /// Attributes
        /// </summary>
        /// <returns></returns>
        const int DRAG_HANDLE_SIZE = 7;
        int mouseX, mouseY;
        Control SelectedControl;
        Control copiedControl;
        Direction direction;
        Point newLocation;
        Size newSize;
        string[] gParam = null;
        Bitmap MemoryImage;
        String xmlFileName = "";
        String xmlFileName_Query = "";
        bool cutCheck = false;
        bool copyCheck = false;
        private ToolTip tt;
        // Adding a private font (Win2000 and later)
        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern IntPtr AddFontMemResourceEx(byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);

        // Cleanup of a private font (Win2000 and later)
        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern bool RemoveFontMemResourceEx(IntPtr fh);

        // Some private holders of font information we are loading
        static private IntPtr m_fh = IntPtr.Zero;
        static private PrivateFontCollection m_pfc = null;
        string[] gParamPop = null;
        // To set the SQL parameter.
        List<String> ControlNames = new List<String>();
        enum Direction
        {
            NW,
            N,
            NE,
            W,
            E,
            SW,
            S,
            SE,
            None
        }

        #endregion

        #region Form Load
        public frmMaindesign()
        {
            InitializeComponent();
        }
        private void frmMaindesign_Load(object sender, EventArgs e)
        {
            ShanuEasyFormDesign.Class.ControlList.objDGVBind.Clear();
        }
        #endregion
        #region Functions
        //////////////////////////////////
        /// <summary>
        /// Convert Font to String
        /// </summary>
        /// <returns></returns>
        private string FontToString(Font font)
        {
            return font.FontFamily.Name + ":" + font.Size + ":" + (int)font.Style;
        }

        //////////////////////////////////
        /// <summary>
        /// Convert String to Font
        /// </summary>
        /// <returns></returns>
        private Font StringToFont(string font)
        {
            string[] parts = font.Split(':');
            if (parts.Length != 3)
                throw new ArgumentException("Not a valid font string", "font");

            Font loadedFont = new Font(parts[0], float.Parse(parts[1]), (FontStyle)int.Parse(parts[2]));
            return loadedFont;
        }
       
        //////////////////////////////////
        /// <summary>
        /// RUN time Control Events
        /// </summary>
        /// <returns></returns>
        /// 
     
        //////////////////////////////////
        /// <summary>
        /// When Runtime Control Clicks this event triger here we can write our code for runtime control click.
        /// Here in this click event i have Called RunTimeCodeGenerate method this mehtod will create class at runtime and run your code.
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_Click(object sender, EventArgs e)
        {
            //if (rdoMessage.Checked == true)
            //{
            //    RunTimeCodeGenerate(txtCode.Text.Trim());
            //}
            //else if (rdoDataTable.Checked == true)
            //{
            //    RunTimeCodeGenerate_ReturnTypeDataTable(txtCode.Text.Trim());
            //}
            //else if (rdoXML.Checked == true)
            //{
            //    RunTimeCodeGenerate_ReturnTypeDataTable(txtCode.Text.Trim());
            //}
            //else if (rdoDatabase.Checked == true)
            //{
            //    RunTimeCodeGenerate_ReturnTypeDataTable(txtCode.Text.Trim());
            //}
         }
        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Enter Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            Cursor = Cursors.SizeAll;
            Control control = (Control)sender;
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.IsBalloon = true;
            tt.Show(control.Name.ToString(), control);
           

        }
        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Leave Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            tt.Dispose();
            timer1.Start();
        }
        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Down Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pnControls.Invalidate();  //unselect other control
                SelectedControl = (Control)sender;
                Control control = (Control)sender;
                mouseX = -e.X;
                mouseY = -e.Y;
                control.Invalidate();
                DrawControlBorder(sender);
                propertyGrid1.SelectedObject = SelectedControl;
                if (control is DataGridView)
                {
                    txtControltoBind.Text = control.Name.ToString();
                }
                else if (control is TextBox)
                {
                    txtTextBox1.Text = control.Name.ToString();
                }
            }
        }
        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Move Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Point nextPosition = new Point();
                nextPosition = pnControls.PointToClient(MousePosition);
                nextPosition.Offset(mouseX, mouseY);
                control.Location = nextPosition;
                Invalidate();
            }
        }
        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Up Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Cursor.Clip = System.Drawing.Rectangle.Empty;
                control.Invalidate();
                DrawControlBorder(control);
            }
        }

        /// <summary>
        /// Draw a border and drag handles around the control, on mouse down and up.
        /// </summary>
        /// <param name="sender"></param>
        private void DrawControlBorder(object sender)
        {
            Control control = (Control)sender;
            //define the border to be drawn, it will be offset by DRAG_HANDLE_SIZE / 2
            //around the control, so when the drag handles are drawn they will be seem
            //connected in the middle.
            Rectangle Border = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE / 2),
                new Size(control.Size.Width + DRAG_HANDLE_SIZE,
                    control.Size.Height + DRAG_HANDLE_SIZE));
            //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
            Rectangle NW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle N = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle NE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle W = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle E = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle S = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

            //get the form graphic
            Graphics g = pnControls.CreateGraphics();
            //draw the border and drag handles
            ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
            ControlPaint.DrawGrabHandle(g, NW, true, true);
            ControlPaint.DrawGrabHandle(g, N, true, true);
            ControlPaint.DrawGrabHandle(g, NE, true, true);
            ControlPaint.DrawGrabHandle(g, W, true, true);
            ControlPaint.DrawGrabHandle(g, E, true, true);
            ControlPaint.DrawGrabHandle(g, SW, true, true);
            ControlPaint.DrawGrabHandle(g, S, true, true);
            ControlPaint.DrawGrabHandle(g, SE, true, true);
            g.Dispose();
        }


        //////////////////////////////////
        /// <summary>
        /// Get The Print area from panel
        /// </summary>
        /// <returns></returns>
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
            pnl.Invalidate();
        }
        //////////////////////////////////
        /// <summary>
        /// To PrintPaint
        /// </summary>
        /// <returns></returns>
        ////protected override void OnPaint(PaintEventArgs e)
        ////{
        ////    //if (MemoryImage != null)
        ////    //{
        ////    //    e.Graphics.DrawImage(MemoryImage, 0, 0);
        ////    //    base.OnPaint(e);
        ////    //}
        ////}
        #endregion
        #region Timer event
        //////////////////////////////////
        /// <summary>
        /// Get the direction and display correct cursor
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Get the direction and display correct cursor
            if (SelectedControl != null)
            {
                Point pos = pnControls.PointToClient(MousePosition);
                //check if the mouse cursor is within the drag handle
                if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X) &&
                    (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NW;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SE;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                    pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y)
                {
                    direction = Direction.N;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE)
                {
                    direction = Direction.S;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.W;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.E;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE) &&
                    (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NE;
                    Cursor = Cursors.SizeNESW;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X + DRAG_HANDLE_SIZE) &&
                    (pos.Y >= SelectedControl.Location.Y + SelectedControl.Height - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SW;
                    Cursor = Cursors.SizeNESW;
                }
                else
                {
                    Cursor = Cursors.Default;
                    direction = Direction.None;
                }
            }
            else
            {
                direction = Direction.None;
                Cursor = Cursors.Default;
            }
            #endregion
        }

        #endregion

        //////////////////////////////////
        /// <summary>
        /// Panel Mouse Down and Mouse Move Events to move the selected Controls added to the panel
        /// </summary>
        #region Panel Mouse Contrls
       
       
        //////////////////////////////////
        /// <summary>
        /// main Panel(here this Panel will work as a Form for deisng) Mouse Down Control to Resize the Control.
        /// </summary>
        private void pnControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null)
                DrawControlBorder(SelectedControl);
            timer1.Start();
        }
        //////////////////////////////////
        /// <summary>
        /// main Panel(here this Panel will work as a Form for deisng) Mouse Move Control to Move the selected runtime  Control.
        /// </summary>

        private void pnControls_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null && e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                Invalidate();

                if (SelectedControl.Height < 20)
                {
                    SelectedControl.Height = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }
                else if (SelectedControl.Width < 20)
                {
                    SelectedControl.Width = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }

                //get the current mouse position relative the the app
                Point pos = pnControls.PointToClient(MousePosition);

                #region resize the control in 8 directions
                if (direction == Direction.NW)
                {
                    //north west, location and width, height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width - (newLocation.X - SelectedControl.Location.X),
                        SelectedControl.Size.Height - (newLocation.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SE)
                {
                    //south east, width and height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width + (newLocation.X - SelectedControl.Size.Width - SelectedControl.Location.X),
                        SelectedControl.Height + (newLocation.Y - SelectedControl.Height - SelectedControl.Location.Y));
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.N)
                {
                    //north, location and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.S)
                {
                    //south, only the height changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.W)
                {
                    //west, location and width will change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        SelectedControl.Height);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.E)
                {
                    //east, only width changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SW)
                {
                    //south west, location, width and height change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.NE)
                {
                    //north east, location, width and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                #endregion
            }
        }

         #endregion

        //////////////////////////////////
        /// <summary>
        /// All Tool Bax Button Control events.
        /// </summary>

        #region ToolBox Events
        //////////////////////////////////
        /// <summary>
        /// To Delete a Selected Control from mainPanel(OurForm).
        /// </summary>
        private void DeleteSTool_Click(object sender, EventArgs e)
        {
            if (SelectedControl != null)
            {
              //  ComboControlNames.Items.Remove(SelectedControl.Name);
                pnControls.Controls.Remove(SelectedControl);
                propertyGrid1.SelectedObject = null;
                pnControls.Invalidate();
            }
        }
        //////////////////////////////////
        /// <summary>
        /// To Delete All Controls placed in mainPanel(OurForm).
        /// </summary>
        private void DeleteATool_Click(object sender, EventArgs e)
        {
           // ComboControlNames.Items.Clear();
            pnControls.Controls.Clear();
            propertyGrid1.SelectedObject = null;
            pnControls.Invalidate();
        }

        //////////////////////////////////
        /// <summary>
        /// To Add/change the panel (Here i have used the panel as form to design) Background Color.
        /// </summary>

       private void frmbackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                if (pnControls.BackgroundImage != null)
                {

                    pnControls.BackgroundImage.Dispose();
                    pnControls.BackgroundImage = null;
                }
                pnControls.BackColor = colorDlg.Color;
            }
        }
        //////////////////////////////////
        /// <summary>
        /// To Add/Change the panel Background Image.
        /// </summary>
        private void frmBackGround_Click(object sender, EventArgs e)
        {

        }
        //////////////////////////////////
        /// <summary>
        ///To Add Label Control to Panel(Form).
        /// </summary>
        private void lblTool1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String LableName = "Lbl_" + randNumber;
            Label ctrl = new Label();
            ctrl.Location = new Point(30, 130);
            ctrl.Name = LableName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "Shanu";
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            ctrl.BringToFront();
            pnControls.Controls.Add(ctrl);
         //   ComboControlNames.Items.Add(LableName);
            //if (toolStripButton10.Enabled == false)
            //{
            //    toolStripButton10.Enabled = true;
            //}

            //if (toolStripButton11.Enabled == false)
            //{
            //    toolStripButton11.Enabled = true;
            //}
        }

        //////////////////////////////////
        /// <summary>
        ///To Add Panel  Control to Panel(Form).
        /// </summary>
        private void PanelTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String pannelName = "pnl_" + randNumber;

            Panel ctrl = new Panel();
            ctrl.Location = new Point(80, 130);          
            ctrl.Name = pannelName;
            ctrl.BackColor = Color.LightGray;
            ctrl.SendToBack();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }
       
        
        //////////////////////////////////
        /// <summary>
        ///To Add Button  Control to Panel(Form).
        /// </summary>
        private void btnTool_Click(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String btnName = "btn_" + randNumber;

            Button ctrl = new Button();
            ctrl.Location = new Point(50, 150);
            ctrl.Name = btnName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "Button";
            ctrl.BringToFront();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
         //   ComboControlNames.Items.Add(btnName);
            //if (toolStripButton10.Enabled == false)
            //{
            //    toolStripButton10.Enabled = true;
            //}

            //if (toolStripButton11.Enabled == false)
            //{
            //    toolStripButton11.Enabled = true;
            //}
        }

        //////////////////////////////////
        /// <summary>
        ///To Add CheckBox Control to Panel(Form).
        /// </summary>
        private void CheckboxTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String chkName = "chk_" + randNumber;

            CheckBox ctrl = new CheckBox();
            ctrl.Location = new Point(120, 140);
            ctrl.Name = chkName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "YourCheckBox";
            ctrl.BringToFront();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
           // ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
           // ComboControlNames.Items.Add(chkName);
        }

        //////////////////////////////////
        /// <summary>
        ///To Add ConboBox Control to Panel(Form).
        /// </summary>
        private void ComboBoxTool_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String ComboName = "cbo_" + randNumber;

            ComboBox ctrl = new ComboBox();
            ctrl.Location = new Point(160, 180);
            ctrl.Name = ComboName;
            ctrl.BringToFront();
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "Select";
           
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            // ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
          //  ComboControlNames.Items.Add(ComboName);
        }
    

     //////////////////////////////////
     /// <summary>
     ///To Add DataGridview Control to Panel(Form).
     /// </summary>
      
        private void GridTool_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String GridName = "grd_" +randNumber;
            DataGridView ctrl = new DataGridView();
            ctrl = new DataGridView();

            //-- New code added by shanu on 2015.04.17
            ctrl.BackgroundColor = Color.LightSteelBlue;

            //Grid Back Color
            ctrl.RowsDefaultCellStyle.BackColor = Color.AliceBlue;

            //GridColumnStylesCollection Alternate Rows Backcolr
            ctrl.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

            // Auto generated here set to tru or false.
            ctrl.AutoGenerateColumns = false;
            //  ShanuDGV.DefaultCellStyle.Font = new Font("Verdana", 10.25f, FontStyle.Regular);
            // ShanuDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            //Column Header back Color
            ctrl.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            ctrl.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ctrl.ColumnHeadersHeight = 40;
            //header Visisble
            ctrl.EnableHeadersVisualStyles = false;

            // Enable the row header
            ctrl.RowHeadersVisible = false;

            // to Hide the Last Empty row here we use false.
            ctrl.AllowUserToAddRows = false;

            // -- End new code added
            ctrl.Location = new Point(160, 300);
            ctrl.Name = GridName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "YourGrid";
            ctrl.BringToFront();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            // ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
          //  ComboControlNames.Items.Add(GridName);
        }
        //////////////////////////////////
        /// <summary>
        ///To Add DateTimePicker Control to Panel(Form).
        /// </summary>
        private void DateTimeTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String DatetimeName = "dte_" + randNumber;

            DateTimePicker ctrl = new DateTimePicker();
            ctrl.Location = new Point(70, 130);
            ctrl.Name = DatetimeName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = DateTime.Now.ToString();
            ctrl.BringToFront();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            // ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
           // ComboControlNames.Items.Add(DatetimeName);
        }

        //////////////////////////////////
        /// <summary>
        ///To Add ListBox Control to Panel(Form).
        /// </summary>
        private void ListBoxTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String listName = "list_" + randNumber;

            ListBox ctrl = new ListBox();
            ctrl.Location = new Point(170, 130);
            ctrl.Name = listName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = DateTime.Now.ToString();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            // ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
           // ComboControlNames.Items.Add(listName);
        }

        //////////////////////////////////
        /// <summary>
        ///To Add NumericUpDown Control to Panel(Form).
        /// </summary>
        private void NumeriUpTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String NumericUpName = "No_" + randNumber;

            NumericUpDown ctrl = new NumericUpDown();
            ctrl.Location = new Point(70, 190);
            ctrl.Name = NumericUpName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Value = 1;
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            // ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
           // ComboControlNames.Items.Add(NumericUpName);
        }
        //////////////////////////////////
        /// <summary>
        ///To Add ListView Control to Panel(Form).
        /// </summary>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String ListViewName = "ListV_" + randNumber;

            ListView ctrl = new ListView();
            ctrl.Location = new Point(70, 230);
            ctrl.Name = ListViewName;
            ctrl.View = View.Details;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            // ctrl.Click += new EventHandler(control_Click);

            pnControls.Controls.Add(ctrl);
           // ComboControlNames.Items.Add(ListViewName);
        }
        //////////////////////////////////
        /// <summary>
        ///To Add PictureBox Control to Panel(Form).
        /// </summary>
        private void PicTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String picName = "Pic_" + randNumber;

            PictureBox ctrl = new PictureBox();
            ctrl.Location = new Point(200, 170);
            ctrl.Name = picName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.BackColor = Color.Blue;
            ctrl.BringToFront();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            // ctrl.Click += new EventHandler(control_Click);
            pnControls.Controls.Add(ctrl);
         //   ComboControlNames.Items.Add(picName);
        }

        //////////////////////////////////
        /// <summary>
        ///To Add TextBox Control to Panel(Form).
        /// </summary>
        private void txtTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "txt_" + randNumber;

            TextBox ctrl = new TextBox();
            ctrl.Location = new Point(20, 190);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text ="Shanu";
            
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
          //  ComboControlNames.Items.Add(textName);
        }


        //////////////////////////////////
        /// <summary>
        ///To Add TreeView Control to Panel(Form).
        /// </summary>

        private void treeviewTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String treeName = "tree_" + randNumber;

            TreeView ctrl = new TreeView();
            ctrl.Location = new Point(320, 220);
            ctrl.Name = treeName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "Shanu";
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
         //   ComboControlNames.Items.Add(treeName);
        }
        //////////////////////////////////
        /// <summary>
        ///To Add RadioButton Control to Panel(Form).
        /// </summary>
        private void RadioTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String radioName = "rdo_" + randNumber;

            RadioButton ctrl = new RadioButton();
            ctrl.Location = new Point(200, 260);
            ctrl.Name = radioName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "Radio";
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
          //  ComboControlNames.Items.Add(radioName);
        }

               
        #endregion
  

        //////////////////////////////////
        /// <summary>
        /// Tool Click New,Save ,Open,Copy,Cut,Paste,Bring to Front and Send to back.
        /// </summary>
          #region Tool New,Save ,Open,Copy,Cut,Paste,Bring to Front and Send to back Function
        private byte[] imageToByteArray(Bitmap bmp)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }

        // Funtcion to save Form as XML File to reuse
        private void SavetoXML(String FileName)
        {
            XmlDocument xmlDoc = new XmlDocument();

            // Write down the XML declaration
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create the root element
            XmlElement rootNode = xmlDoc.CreateElement("ShanuFormSave");
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
            xmlDoc.AppendChild(rootNode);


            foreach (Control p in pnControls.Controls)
            {
                string ControlNames = p.Name;
                string types = p.GetType().ToString();
                string locX = p.Location.X.ToString();
                string locY = p.Location.Y.ToString();
                string sizeWidth = p.Width.ToString();
                string sizeHegiht = p.Height.ToString();
                string Texts = p.Text.ToString();

                var backColors = p.BackColor.Name;
                var forecolors = p.ForeColor.Name;

                PictureBox pic = p as PictureBox; //cast control into PictureBox
                byte[] bytes = null;
                string PicBitMapImages = "";
                if (pic != null) //if it is pictureBox, then it will not be null.
                {
                    if (pic.Image != null)
                    {
                        Bitmap img = new Bitmap(pic.Image);
                        bytes = imageToByteArray(img);
                        PicBitMapImages = Convert.ToBase64String(bytes);
                    }
                }

                //Font f = p.Font;

                string fonts = FontToString(p.Font);


                // Create a new <Category> element and add it to the root node
                XmlElement parentNode = xmlDoc.CreateElement("Controls");

                // Set attribute name and value!
                parentNode.SetAttribute("ID", p.GetType().ToString());

                xmlDoc.DocumentElement.PrependChild(parentNode);

                // Create the required nodes
                XmlElement CntrlType = xmlDoc.CreateElement("ControlsType");
                XmlElement locNodeX = xmlDoc.CreateElement("LocationX");
                XmlElement locNodeY = xmlDoc.CreateElement("LocationY");
                XmlElement SizeWidth = xmlDoc.CreateElement("SizeWidth");
                XmlElement SizeHegith = xmlDoc.CreateElement("SizeHeight");
                XmlElement cntText = xmlDoc.CreateElement("Text");
                XmlElement cntFonts = xmlDoc.CreateElement("Fonts");
                XmlElement CntrlPictureImage = xmlDoc.CreateElement("picImage");
                XmlElement CntrlBackColor = xmlDoc.CreateElement("BackColor");
                XmlElement CntrlForeColor = xmlDoc.CreateElement("ForeColor");
                XmlElement nodeCntrlName = xmlDoc.CreateElement("CntrlsName");
                XmlElement nodeCntrlSendTO = xmlDoc.CreateElement("CntrlssendtoType");
                //For Grid
                XmlElement gridrowsBackColor = xmlDoc.CreateElement("gridsrowsBackColor");

                XmlElement gridAlternaterowsBackColor = xmlDoc.CreateElement("gridsAlternaterowsBackColor");
                XmlElement gridheaderColor = xmlDoc.CreateElement("gridsheaderColor");
                // For Grid
                //XmlElement nodePanelWidth = xmlDoc.CreateElement("panelWidth");
                //XmlElement nodePanelHeight = xmlDoc.CreateElement("panelHeight");
                // retrieve the text 

                DataGridView dgvs = p as DataGridView; //cast control into PictureBox

                if (dgvs != null) //if it is pictureBox, then it will not be null.
                {
                     backColors = dgvs.BackgroundColor.Name;
                     forecolors = dgvs.ForeColor.Name;
                }

                XmlText cntrlKind = xmlDoc.CreateTextNode(p.GetType().ToString());

                XmlText cntrlLocX = xmlDoc.CreateTextNode(locX);
                XmlText cntrlLocY = xmlDoc.CreateTextNode(locY);

                XmlText cntrlWidth = xmlDoc.CreateTextNode(sizeWidth);
                XmlText cntrlHeight = xmlDoc.CreateTextNode(sizeHegiht);

                XmlText cntrlText = xmlDoc.CreateTextNode(Texts);
                XmlText cntrlFont = xmlDoc.CreateTextNode(fonts);
                XmlText cntrlPicImg = xmlDoc.CreateTextNode(PicBitMapImages);
                XmlText cntrlBckColor = xmlDoc.CreateTextNode(backColors);
                XmlText cntrlFrColor = xmlDoc.CreateTextNode(forecolors);
                XmlText txtCntrlsNames = xmlDoc.CreateTextNode(ControlNames);

                XmlText txtnodeCntrlSendTO = xmlDoc.CreateTextNode("Front");
                //Grid
                XmlText ctlGridrowsBackColor = xmlDoc.CreateTextNode("");
                XmlText ctlGridAlternaterowsBackColor = xmlDoc.CreateTextNode("");
                XmlText ctlGridheaderColor = xmlDoc.CreateTextNode("");
                
               
                if (dgvs != null) //if it is pictureBox, then it will not be null.
                {
                    ctlGridrowsBackColor = xmlDoc.CreateTextNode(dgvs.BackgroundColor.Name);
                     ctlGridAlternaterowsBackColor = xmlDoc.CreateTextNode(dgvs.AlternatingRowsDefaultCellStyle.BackColor.Name);
                     ctlGridheaderColor = xmlDoc.CreateTextNode(dgvs.ColumnHeadersDefaultCellStyle.BackColor.Name);
                }
                

                //GRid
                pnControls.Controls.GetChildIndex(p);
                //if (p.SendToBack() == true)
                //{
                //     txtnodeCntrlSendTO = xmlDoc.CreateTextNode("Back");
                //}
                             

                XmlText txtPanelWidth = xmlDoc.CreateTextNode(pnControls.Width.ToString());
                XmlText txtPanelHeight = xmlDoc.CreateTextNode(pnControls.Height.ToString());
                // append the nodes to the parentNode without the value
                parentNode.AppendChild(CntrlType);
                parentNode.AppendChild(locNodeX);
                parentNode.AppendChild(locNodeY);
                parentNode.AppendChild(SizeWidth);
                parentNode.AppendChild(SizeHegith);
                parentNode.AppendChild(cntText);
                parentNode.AppendChild(cntFonts);
                parentNode.AppendChild(CntrlPictureImage);
                parentNode.AppendChild(CntrlBackColor);
                parentNode.AppendChild(CntrlForeColor);
                parentNode.AppendChild(nodeCntrlName);
                parentNode.AppendChild(nodeCntrlSendTO);
                //for Grid
                parentNode.AppendChild(gridrowsBackColor);
                parentNode.AppendChild(gridAlternaterowsBackColor);
                parentNode.AppendChild(gridheaderColor);
                //grid
                // save the value of the fields into the nodes
                CntrlType.AppendChild(cntrlKind);
                locNodeX.AppendChild(cntrlLocX);
                locNodeY.AppendChild(cntrlLocY);

                SizeWidth.AppendChild(cntrlWidth);
                SizeHegith.AppendChild(cntrlHeight);

                cntText.AppendChild(cntrlText);
                cntFonts.AppendChild(cntrlFont);
                CntrlPictureImage.AppendChild(cntrlPicImg);
                CntrlBackColor.AppendChild(cntrlBckColor);
                CntrlForeColor.AppendChild(cntrlFrColor);
                nodeCntrlName.AppendChild(txtCntrlsNames);
                nodeCntrlSendTO.AppendChild(txtnodeCntrlSendTO);
                //for Grid
                gridrowsBackColor.AppendChild(ctlGridrowsBackColor);
                gridAlternaterowsBackColor.AppendChild(ctlGridAlternaterowsBackColor);
                gridheaderColor.AppendChild(ctlGridheaderColor);
                //grid
                //nodePanelHeight.AppendChild(txtPanelHeight);
            }

            // For Dynamic Query
                      
            //-------------
            XmlDocument xmlDocQuery = new XmlDocument();
            // Write down the XML declaration
            XmlDeclaration xmlDeclarationQuery = xmlDocQuery.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create the root element
            XmlElement rootNodeQuery = xmlDocQuery.CreateElement("ShanuQuerySave");
            xmlDocQuery.InsertBefore(xmlDeclarationQuery, xmlDocQuery.DocumentElement);
            xmlDocQuery.AppendChild(rootNodeQuery);
            // Create a new <Category> element and add it to the root node

            foreach (var item in ShanuEasyFormDesign.Class.ControlList.objDGVBind)
            {
                XmlElement parentNodeQuery = xmlDocQuery.CreateElement("SQLQuery");

                // Set attribute name and value!
                //parentNodeQuery.SetAttribute("ID", p.GetType().ToString());

                xmlDocQuery.DocumentElement.PrependChild(parentNodeQuery);
                XmlElement cntrlTextBox1 = xmlDocQuery.CreateElement("ParameterName");

                XmlElement cntrlParameter1 = xmlDocQuery.CreateElement("cntrlName");
                XmlElement cntrltoBind = xmlDocQuery.CreateElement("cntrltoBind");
                XmlElement cntrlQuery = xmlDocQuery.CreateElement("ProcedureName");

                XmlText ctlcntrlTextBox1 = xmlDocQuery.CreateTextNode(item.ParameterName);
                XmlText ctlcntrlParameter1 = xmlDocQuery.CreateTextNode(item.ControlName);
                XmlText ctlcntrltoBind = xmlDocQuery.CreateTextNode(txtControltoBind.Text.Trim());
                XmlText ctlcntrlQuery = xmlDocQuery.CreateTextNode(item.procedureName);

                parentNodeQuery.AppendChild(cntrlTextBox1);
                parentNodeQuery.AppendChild(cntrlParameter1);
                parentNodeQuery.AppendChild(cntrltoBind);
                parentNodeQuery.AppendChild(cntrlQuery);

                cntrlTextBox1.AppendChild(ctlcntrlTextBox1);
                cntrlParameter1.AppendChild(ctlcntrlParameter1);
                cntrltoBind.AppendChild(ctlcntrltoBind);
                cntrlQuery.AppendChild(ctlcntrlQuery);
            }
            //            
            string path =Application.StartupPath + @"XMLForms";
                if(!Directory.Exists(path))
                {
                Directory.CreateDirectory(path);
                }
                String NewFileName = Application.StartupPath + @"\XMLForms\" + FileName + ".XML";
                String NewFileName_Query = Application.StartupPath + @"\XMLForms\" + FileName + "_Query.XML";

        xmlDoc.Save(NewFileName);
        xmlDocQuery.Save(NewFileName_Query);
        ShanuEasyFormDesign.Class.ControlList.objDGVBind.Clear();

        }

        // To Open a Exisitng Form from XML file.
        private void loadXMLFILE()
        {
           
            ////if (xmlFileName_Query != "")
            ////{
            ////    XmlDocument xmlQuery = new XmlDocument();
            ////    xmlQuery.Load(xmlFileName_Query);
            ////    XmlNode xnQueryList = xmlQuery.SelectSingleNode("ShanuQuerySave");

            ////    int i = 0;

            ////    //XmlNode xnListQuery = xnList.SelectSingleNode("SQLQuery");

            ////    foreach (XmlNode xn in xnQueryList)
            ////    {

            ////        txtTextBox1.Text = xn["cntrlTextBox1"].InnerText;
            ////        txtParameterName1.Text = xn["ParameterName"].InnerText;
            ////        txtControltoBind.Text = xn["cntrltoBind"].InnerText;
            ////       txtQuery.Text = xn["cntrlQuery"].InnerText;
            ////    }
            ////}
            if (xmlFileName == "")
            {
                return;
            }

            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFileName);
            XmlNode xnList = xml.SelectSingleNode("ShanuFormSave");

            foreach (XmlNode xn in xnList)
            {

            

                string CntrlType = xn["ControlsType"].InnerText;
                string LOCX = xn["LocationX"].InnerText;
                string LOCY = xn["LocationY"].InnerText;

                string CNTLWidth = xn["SizeWidth"].InnerText;
                string CNTLHeight = xn["SizeHeight"].InnerText;

                string CntrlText = xn["Text"].InnerText;

                string fonts = xn["Fonts"].InnerText;
                string PictuerImg = xn["picImage"].InnerText;

                string bckColor = xn["BackColor"].InnerText;
                string foreColor = xn["ForeColor"].InnerText;
                string CntrlsName = xn["CntrlsName"].InnerText;
                string CntrlssendtoType = xn["CntrlssendtoType"].InnerText;
                //For grid
                string gridsrowsBackColor = xn["gridsrowsBackColor"].InnerText;
                string gridsAlternaterowsBackColor = xn["gridsAlternaterowsBackColor"].InnerText;
                string gridsheaderColor = xn["gridsheaderColor"].InnerText;
                // For Grid
                if (CntrlType != "System.Windows.Forms.Panel")
                {
                    gParam = new string[] { CntrlType, 
                                                LOCX, 
                                                LOCY, 
                                                CNTLWidth,
                                                CNTLHeight, 
                                                CntrlText,
                                                fonts,
                                                PictuerImg,
                                                 bckColor,
                                                foreColor,
                                                CntrlsName,
                                                CntrlssendtoType,
                                                gridsrowsBackColor,
                                                gridsAlternaterowsBackColor,
                                                gridsheaderColor
                                              };
                    loadShanuLabelDesign();
                }
            }
            foreach (XmlNode xn in xnList)
            {
                string CntrlType = xn["ControlsType"].InnerText;
                string LOCX = xn["LocationX"].InnerText;
                string LOCY = xn["LocationY"].InnerText;

                string CNTLWidth = xn["SizeWidth"].InnerText;
                string CNTLHeight = xn["SizeHeight"].InnerText;

                string CntrlText = xn["Text"].InnerText;

                string fonts = xn["Fonts"].InnerText;
                string PictuerImg = xn["picImage"].InnerText;

                string bckColor = xn["BackColor"].InnerText;
                string foreColor = xn["ForeColor"].InnerText;
                string CntrlsName = xn["CntrlsName"].InnerText;
                string CntrlssendtoType = xn["CntrlssendtoType"].InnerText;
                if (CntrlType == "System.Windows.Forms.Panel")
                {
                    gParam = new string[] { CntrlType, 
                                                LOCX, 
                                                LOCY, 
                                                CNTLWidth,
                                                CNTLHeight, 
                                                CntrlText,
                                                fonts,
                                                PictuerImg,
                                                 bckColor,
                                                foreColor,
                                                CntrlsName,
                                                CntrlssendtoType
                                              };
                    loadShanuLabelDesign();
                }
            }

        }
              private void loadShanuLabelDesign()
        {
            try
            {

                switch (gParam[0])
                {
                    case "System.Windows.Forms.PictureBox": //현재화면 사용가능여부 조회
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                             PictureBox ctrl = new PictureBox();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));

                            if (gParam[7] != "")
                            {
                                Bitmap bmp1 = new Bitmap(new MemoryStream(Convert.FromBase64String(gParam[7])));
                                ctrl.Image = bmp1;
                            }
                            ctrl.SendToBack();
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            pnControls.Controls.Add(ctrl);
                          //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.DataGridView": //현재화면 사용가능여부 조회
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);

                            System.Drawing.Color RowsBackColor = new System.Drawing.Color();
                            RowsBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[12]);

                            System.Drawing.Color AlternatebackColor = new System.Drawing.Color();
                            AlternatebackColor = System.Drawing.ColorTranslator.FromHtml(gParam[13]);

                            System.Drawing.Color HeaderColor = new System.Drawing.Color();
                            HeaderColor = System.Drawing.ColorTranslator.FromHtml(gParam[14]);


                            DataGridView ctrl = new DataGridView();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.BackgroundColor = myBackColor;

                            ctrl.RowsDefaultCellStyle.BackColor = Color.White;
                          
                            //GridColumnStylesCollection Alternate Rows Backcolr
                            ctrl.AlternatingRowsDefaultCellStyle.BackColor = AlternatebackColor;
                           
                            //Column Header back Color
                            ctrl.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;
                            ctrl.ColumnHeadersHeight = 40;

                            ctrl.AutoGenerateColumns = false;
                            ctrl.EnableHeadersVisualStyles = false;

                            // Enable the row header
                            ctrl.RowHeadersVisible = false;

                            // to Hide the Last Empty row here we use false.
                            ctrl.AllowUserToAddRows = false;

                             ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            pnControls.Controls.Add(ctrl);
                          //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Label": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);
                            Label ctrl = new Label();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                        //   ctrl.Click += new EventHandler(control_Click);
                            pnControls.Controls.Add(ctrl);
                          //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Button":
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            Button ctrl = new Button();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            ctrl.Click += new EventHandler(control_Click);
                            pnControls.Controls.Add(ctrl);
                          //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.ComboBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            ComboBox ctrl = new ComboBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                          //  ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                           // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.ListBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            ListBox ctrl = new ListBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                       //     ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                           // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Panel": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            Panel ctrl = new Panel();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                        //   ctrl.Click += new EventHandler(control_Click);
                            ctrl.SendToBack();
                            pnControls.Controls.Add(ctrl);
                        //    ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.NumericUpDown": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            NumericUpDown ctrl = new NumericUpDown();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                         //  ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                           // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.TreeView": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            TreeView ctrl = new TreeView();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                          //  ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                          //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.DateTimePicker": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            DateTimePicker ctrl = new DateTimePicker();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                           // ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                          //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.TextBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            TextBox ctrl = new TextBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                        //    ctrl.Click += new EventHandler(control_Click);
                            pnControls.Controls.Add(ctrl);
                           // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.RadioButton": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            RadioButton ctrl = new RadioButton();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                        //    ctrl.Click += new EventHandler(control_Click);
                            pnControls.Controls.Add(ctrl);
                           // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.CheckBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            CheckBox ctrl = new CheckBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                           // ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                           // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

              //////////////////////////////////
              /// <summary>
              /// TO Paste New Control to Panel
              /// </summary>
              /// <returns></returns>
              private void PasteNewControl()
              {
                  try
                  {

                      Random rnd = new Random();
                      int randNumber = rnd.Next(1, 1000);
                      String newControlsName = copiedControl.Name + "_" + randNumber;

                      switch (copiedControl.GetType().ToString())
                      {
                          case "System.Windows.Forms.PictureBox": //현재화면 사용가능여부 조회
                              try
                              {
                                  PictureBox pic = copiedControl as PictureBox;
                                  PictureBox ctrl = new PictureBox();
                                  ctrl.Name = newControlsName;
                                  ctrl.SendToBack();
                                  //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Image = pic.Image;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);//new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                                  ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
                                  ctrl.Size = copiedControl.Size;//new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  pnControls.Controls.Add(ctrl);
                               //   ComboControlNames.Items.Add(gParam[10]);
                              }
                              catch (Exception ex)
                              {
                              }

                              break;
                          case "System.Windows.Forms.DataGridView": //현재화면 사용가능여부 조회
                              {
                                  DataGridView ctrl = new DataGridView();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);//new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                                  ctrl.Text = copiedControl.Text; 
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;

                                
                                  ctrl.Size = copiedControl.Size; //new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  pnControls.Controls.Add(ctrl);
                              //    ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.Label": //현재화면 사용가능여부 조회
                              {
                                  Label ctrl = new Label();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);

                                  pnControls.Controls.Add(ctrl);
                                //  ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.Button":
                              {
                                  System.Drawing.Color myBackColor = new System.Drawing.Color();
                                  myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                                  Button ctrl = new Button();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                 // ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.ComboBox": //현재화면 사용가능여부 조회
                              {
                                  ComboBox ctrl = new ComboBox();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                               //   ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.ListBox": //현재화면 사용가능여부 조회
                              {
                                  ListBox ctrl = new ListBox();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                 // ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.Panel": //현재화면 사용가능여부 조회
                              {
                                  Panel ctrl = new Panel();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  ctrl.SendToBack();
                                  pnControls.Controls.Add(ctrl);
                               //   ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.NumericUpDown": //현재화면 사용가능여부 조회
                              {
                                  NumericUpDown ctrl = new NumericUpDown();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                //  ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.TreeView": //현재화면 사용가능여부 조회
                              {
                                  TreeView ctrl = new TreeView();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                 // ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.DateTimePicker": //현재화면 사용가능여부 조회
                              {
                                  DateTimePicker ctrl = new DateTimePicker();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                //  ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.TextBox": //현재화면 사용가능여부 조회
                              {
                                  TextBox ctrl = new TextBox();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                //  ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.RadioButton": //현재화면 사용가능여부 조회
                              {
                                  RadioButton ctrl = new RadioButton();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                //  ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                          case "System.Windows.Forms.CheckBox": //현재화면 사용가능여부 조회
                              {
                                  CheckBox ctrl = new CheckBox();
                                  ctrl.Name = newControlsName;
                                  ctrl.Location = new Point(copiedControl.Location.X + 10, copiedControl.Location.Y + 10);
                                  ctrl.Text = copiedControl.Text; ;
                                  ctrl.Font = copiedControl.Font;
                                  ctrl.BackColor = copiedControl.BackColor;
                                  ctrl.ForeColor = copiedControl.ForeColor;
                                  ctrl.Size = copiedControl.Size;
                                  ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                                  ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                                  ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                                  ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                                  ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                                  // ctrl.Click += new EventHandler(control_Click);
                                  pnControls.Controls.Add(ctrl);
                                 // ComboControlNames.Items.Add(newControlsName);
                              }
                              break;
                      }
                  }
                  catch (Exception ex)
                  {
                  }
              }
          #endregion

            
        #region Tool New,Save ,Open,Copy,Cut,Paste,Bring to Front and Send to back
        // To create New Form
              private void toolNewAdd_Click(object sender, EventArgs e)
              {                 
                 // ComboControlNames.Items.Clear();
                  pnControls.Controls.Clear();
                  propertyGrid1.SelectedObject = null;
                  pnControls.Invalidate();
              }
              // To create New Form
              private void MenuNew_Click(object sender, EventArgs e)
              {                
                 // ComboControlNames.Items.Clear();
                  pnControls.Controls.Clear();
                  propertyGrid1.SelectedObject = null;
                  pnControls.Invalidate();
              }
            
              // To Save as XML FIle
              private void toolSaves_Click(object sender, EventArgs e)
              {
                  if (pnControls.Controls.Count > 0)
                  {                      
                       frmSave obj = new frmSave();
                     //  obj.ShowDialog();
                       if (obj.ShowDialog() == DialogResult.OK)
                      {
                          if (obj.SaveFileName == "")
                          {
                          }
                          else
                          {
                              String NewFileName_Query = Application.StartupPath + @"\XMLForms\" + obj.SaveFileName + "_Query.XML";
                              if(!File.Exists(NewFileName_Query))
                              {
                              if (ShanuEasyFormDesign.Class.ControlList.objDGVBind.Count <= 0)
                              {
                                  MessageBox.Show("procedure and parameter need to be set before save");
                              }
                              }
                              SavetoXML(obj.SaveFileName);
                          }
                      
                       }
                  }
              }

              private void toolStripButton1_Click_1(object sender, EventArgs e)
              {
                  ControlNames.Clear();
                  if (pnControls.Controls.Count > 0)
                  {
                      foreach (TextBox tb in pnControls.Controls.OfType<TextBox>())
                      {
                          ControlNames.Add(tb.Name.ToString());
                      }

                      FrmParameterSetting obj = new FrmParameterSetting(ControlNames);
                      //  obj.ShowDialog();
                      if (obj.ShowDialog() == DialogResult.OK)
                      { 
                        
                      }
                  }
              }

              String OpendFileName = "";
             // to Open XML file as Form
              private void toolOpens_Click(object sender, EventArgs e)
              {
                   try
                  {

                      frmOpen obj = new frmOpen();
                     //  obj.ShowDialog();
                       if (obj.ShowDialog() == DialogResult.OK)
                      {
                          if (obj.OpenFileName == "")
                          {
                          }
                          else
                          {
                              xmlFileName = Application.StartupPath + @"\XMLForms\" + obj.OpenFileName + ".XML";
                              xmlFileName_Query = Application.StartupPath + @"\XMLForms\" + obj.OpenFileName + "_Query.XML"; 
                              pnControls.Controls.Clear();
                              loadXMLFILE();
                          }
                       }
                          // MessageBox.Show();
                     
                  }
                   catch (Exception ex)
                   {
                   }
              }
             
        // To Cut the Exisitng Cuntrol to 
              private void toolCuts_Click(object sender, EventArgs e)
              {
                  if (SelectedControl != null)
                  {
                      copiedControl = SelectedControl;
                      cutCheck = true;
                      toolPastes.Enabled = true;
                      MenuPaste.Enabled = true;
                  }

                  if (SelectedControl != null)
                  {
                      pnControls.Controls.Remove(SelectedControl);
                      propertyGrid1.SelectedObject = null;
                      pnControls.Invalidate();
                  }
              }
             
        // To Copy the Controls
              private void toolCopys_Click(object sender, EventArgs e)
              {

               if (SelectedControl != null)
                  {
                      copiedControl = SelectedControl;
                      if (copiedControl != null)
                      {
                          cutCheck = false;
                          copyCheck = true;
                          toolPastes.Enabled = true;
                          MenuPaste.Enabled = true;
                      }
                  }
              }
              private void MenuCopy_Click(object sender, EventArgs e)
              {
                  if (SelectedControl != null)
                  {
                      copiedControl = SelectedControl;
                      if (copiedControl != null)
                      {
                          cutCheck = false;
                          copyCheck = true;
                          toolPastes.Enabled = true;
                          MenuPaste.Enabled = true;
                      }
                  }
              }
        // To paste the Cut and Copied Controls
              private void toolPastes_Click(object sender, EventArgs e)
              {
                  if (copiedControl != null)
                  {
                      PasteNewControl();
                      //control.Invalidate();
                      if (copyCheck == true)
                      {
                          toolPastes.Enabled = true;
                          MenuPaste.Enabled = true;
                      }
                      if (cutCheck == true)
                      {
                          toolPastes.Enabled = false;
                          MenuPaste.Enabled = false;
                          cutCheck = false;
                      }

                  }
              }

              private void MenuPaste_Click(object sender, EventArgs e)
              {
                  if (copiedControl != null)
                  {

                      PasteNewControl();
                      //control.Invalidate();
                      if (copyCheck == true)
                      {
                          toolPastes.Enabled = true;
                          MenuPaste.Enabled = true;
                      }
                      if (cutCheck == true)
                      {
                          toolPastes.Enabled = false;
                          MenuPaste.Enabled = false;
                          cutCheck = false;
                      }

                  }
              }
           

              private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
              {
                 // MessageBox.Show("This Application was Created By  Syed Shanu -> you can reach him @ syedshanumcain@gmail.com", "About Me");
              }
            
        #endregion

              private void toolBringtoFront_Click(object sender, EventArgs e)
              {
                  if (SelectedControl != null)
                  {
                      SelectedControl.BringToFront();
                  }
              }

              private void toolStripButton2_Click(object sender, EventArgs e)
              {
                  if (SelectedControl != null)
                  {
                      SelectedControl.SendToBack();
                  }
              }

         

             

             
            
           
      
      

             
                  
    }
}
