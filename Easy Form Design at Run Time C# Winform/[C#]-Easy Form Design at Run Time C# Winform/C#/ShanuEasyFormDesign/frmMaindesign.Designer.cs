namespace ShanuEasyFormDesign
{
    partial class frmMaindesign
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaindesign));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNewAdd = new System.Windows.Forms.ToolStripButton();
            this.toolSaves = new System.Windows.Forms.ToolStripButton();
            this.toolOpens = new System.Windows.Forms.ToolStripButton();
            this.toolCuts = new System.Windows.Forms.ToolStripButton();
            this.toolCopys = new System.Windows.Forms.ToolStripButton();
            this.toolPastes = new System.Windows.Forms.ToolStripButton();
            this.toolBringtoFront = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.DeleteATool = new System.Windows.Forms.ToolStripButton();
            this.DeleteSTool = new System.Windows.Forms.ToolStripButton();
            this.frmbackColor = new System.Windows.Forms.ToolStripButton();
            this.lblTool1 = new System.Windows.Forms.ToolStripButton();
            this.CheckboxTool = new System.Windows.Forms.ToolStripButton();
            this.btnTool = new System.Windows.Forms.ToolStripButton();
            this.ComboBoxTool = new System.Windows.Forms.ToolStripButton();
            this.GridTool = new System.Windows.Forms.ToolStripButton();
            this.DateTimeTool = new System.Windows.Forms.ToolStripButton();
            this.PanelTool = new System.Windows.Forms.ToolStripButton();
            this.PicTool = new System.Windows.Forms.ToolStripButton();
            this.RadioTool = new System.Windows.Forms.ToolStripButton();
            this.txtTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.pnControls = new System.Windows.Forms.Panel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtControltoBind = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTextBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParameterName1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewAdd,
            this.toolSaves,
            this.toolOpens,
            this.toolCuts,
            this.toolCopys,
            this.toolPastes,
            this.toolBringtoFront,
            this.toolStripButton2,
            this.DeleteATool,
            this.DeleteSTool,
            this.frmbackColor,
            this.lblTool1,
            this.CheckboxTool,
            this.btnTool,
            this.ComboBoxTool,
            this.GridTool,
            this.DateTimeTool,
            this.PanelTool,
            this.PicTool,
            this.RadioTool,
            this.txtTool,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(113, 738);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNewAdd
            // 
            this.toolNewAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolNewAdd.Image")));
            this.toolNewAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolNewAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolNewAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewAdd.Name = "toolNewAdd";
            this.toolNewAdd.Size = new System.Drawing.Size(110, 28);
            this.toolNewAdd.Text = "New";
            this.toolNewAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolNewAdd.ToolTipText = "New";
            this.toolNewAdd.Click += new System.EventHandler(this.toolNewAdd_Click);
            // 
            // toolSaves
            // 
            this.toolSaves.Image = ((System.Drawing.Image)(resources.GetObject("toolSaves.Image")));
            this.toolSaves.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolSaves.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSaves.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaves.Name = "toolSaves";
            this.toolSaves.Size = new System.Drawing.Size(110, 28);
            this.toolSaves.Text = "Save";
            this.toolSaves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolSaves.ToolTipText = "Save";
            this.toolSaves.Click += new System.EventHandler(this.toolSaves_Click);
            // 
            // toolOpens
            // 
            this.toolOpens.Image = ((System.Drawing.Image)(resources.GetObject("toolOpens.Image")));
            this.toolOpens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolOpens.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolOpens.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpens.Name = "toolOpens";
            this.toolOpens.Size = new System.Drawing.Size(110, 28);
            this.toolOpens.Text = "Open";
            this.toolOpens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolOpens.ToolTipText = "Open";
            this.toolOpens.Click += new System.EventHandler(this.toolOpens_Click);
            // 
            // toolCuts
            // 
            this.toolCuts.Image = ((System.Drawing.Image)(resources.GetObject("toolCuts.Image")));
            this.toolCuts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCuts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCuts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCuts.Name = "toolCuts";
            this.toolCuts.Size = new System.Drawing.Size(110, 28);
            this.toolCuts.Text = "Cut";
            this.toolCuts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCuts.ToolTipText = "Cut";
            this.toolCuts.Click += new System.EventHandler(this.toolCuts_Click);
            // 
            // toolCopys
            // 
            this.toolCopys.Image = ((System.Drawing.Image)(resources.GetObject("toolCopys.Image")));
            this.toolCopys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCopys.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCopys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopys.Name = "toolCopys";
            this.toolCopys.Size = new System.Drawing.Size(110, 28);
            this.toolCopys.Text = "Copy";
            this.toolCopys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCopys.ToolTipText = "Copy";
            this.toolCopys.Click += new System.EventHandler(this.toolCopys_Click);
            // 
            // toolPastes
            // 
            this.toolPastes.Enabled = false;
            this.toolPastes.Image = ((System.Drawing.Image)(resources.GetObject("toolPastes.Image")));
            this.toolPastes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolPastes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolPastes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPastes.Name = "toolPastes";
            this.toolPastes.Size = new System.Drawing.Size(110, 26);
            this.toolPastes.Text = "Paste";
            this.toolPastes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolPastes.ToolTipText = "Paste";
            this.toolPastes.Click += new System.EventHandler(this.toolPastes_Click);
            // 
            // toolBringtoFront
            // 
            this.toolBringtoFront.Image = ((System.Drawing.Image)(resources.GetObject("toolBringtoFront.Image")));
            this.toolBringtoFront.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolBringtoFront.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBringtoFront.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBringtoFront.Name = "toolBringtoFront";
            this.toolBringtoFront.Size = new System.Drawing.Size(110, 36);
            this.toolBringtoFront.Text = "BringToFront";
            this.toolBringtoFront.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolBringtoFront.Click += new System.EventHandler(this.toolBringtoFront_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(110, 36);
            this.toolStripButton2.Text = "SendtoBack";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // DeleteATool
            // 
            this.DeleteATool.Image = ((System.Drawing.Image)(resources.GetObject("DeleteATool.Image")));
            this.DeleteATool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteATool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteATool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteATool.Name = "DeleteATool";
            this.DeleteATool.Size = new System.Drawing.Size(110, 36);
            this.DeleteATool.Text = "Delete All";
            this.DeleteATool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteATool.ToolTipText = "Add your TextBox";
            this.DeleteATool.Click += new System.EventHandler(this.DeleteATool_Click);
            // 
            // DeleteSTool
            // 
            this.DeleteSTool.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSTool.Image")));
            this.DeleteSTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteSTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteSTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteSTool.Name = "DeleteSTool";
            this.DeleteSTool.Size = new System.Drawing.Size(110, 20);
            this.DeleteSTool.Text = "Delete Selected";
            this.DeleteSTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteSTool.ToolTipText = "Add your TextBox";
            this.DeleteSTool.Click += new System.EventHandler(this.DeleteSTool_Click);
            // 
            // frmbackColor
            // 
            this.frmbackColor.Image = ((System.Drawing.Image)(resources.GetObject("frmbackColor.Image")));
            this.frmbackColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmbackColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.frmbackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frmbackColor.Name = "frmbackColor";
            this.frmbackColor.Size = new System.Drawing.Size(110, 20);
            this.frmbackColor.Text = "FormColor";
            this.frmbackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmbackColor.ToolTipText = "About Me";
            this.frmbackColor.Click += new System.EventHandler(this.frmbackColor_Click);
            // 
            // lblTool1
            // 
            this.lblTool1.Image = ((System.Drawing.Image)(resources.GetObject("lblTool1.Image")));
            this.lblTool1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTool1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblTool1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblTool1.Name = "lblTool1";
            this.lblTool1.Size = new System.Drawing.Size(110, 20);
            this.lblTool1.Text = "label";
            this.lblTool1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTool1.ToolTipText = "About Me";
            this.lblTool1.Click += new System.EventHandler(this.lblTool1_Click);
            // 
            // CheckboxTool
            // 
            this.CheckboxTool.Image = ((System.Drawing.Image)(resources.GetObject("CheckboxTool.Image")));
            this.CheckboxTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckboxTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CheckboxTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckboxTool.Name = "CheckboxTool";
            this.CheckboxTool.Size = new System.Drawing.Size(110, 20);
            this.CheckboxTool.Text = "CheckBox";
            this.CheckboxTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckboxTool.ToolTipText = "Add your Button";
            this.CheckboxTool.Click += new System.EventHandler(this.CheckboxTool_Click);
            // 
            // btnTool
            // 
            this.btnTool.Image = ((System.Drawing.Image)(resources.GetObject("btnTool.Image")));
            this.btnTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTool.Name = "btnTool";
            this.btnTool.Size = new System.Drawing.Size(110, 20);
            this.btnTool.Text = "Button";
            this.btnTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTool.ToolTipText = "Add your Button";
            this.btnTool.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // ComboBoxTool
            // 
            this.ComboBoxTool.Image = ((System.Drawing.Image)(resources.GetObject("ComboBoxTool.Image")));
            this.ComboBoxTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ComboBoxTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ComboBoxTool.Name = "ComboBoxTool";
            this.ComboBoxTool.Size = new System.Drawing.Size(110, 20);
            this.ComboBoxTool.Text = "ComboBox";
            this.ComboBoxTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxTool.ToolTipText = "Add your Button";
            this.ComboBoxTool.Click += new System.EventHandler(this.ComboBoxTool_Click);
            // 
            // GridTool
            // 
            this.GridTool.Image = ((System.Drawing.Image)(resources.GetObject("GridTool.Image")));
            this.GridTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GridTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GridTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GridTool.Name = "GridTool";
            this.GridTool.Size = new System.Drawing.Size(110, 20);
            this.GridTool.Text = "DatagridView";
            this.GridTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GridTool.ToolTipText = "Add your Button";
            this.GridTool.Click += new System.EventHandler(this.GridTool_Click);
            // 
            // DateTimeTool
            // 
            this.DateTimeTool.Image = ((System.Drawing.Image)(resources.GetObject("DateTimeTool.Image")));
            this.DateTimeTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateTimeTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DateTimeTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DateTimeTool.Name = "DateTimeTool";
            this.DateTimeTool.Size = new System.Drawing.Size(110, 20);
            this.DateTimeTool.Text = "DateTimePicker";
            this.DateTimeTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateTimeTool.ToolTipText = "Add your Button";
            this.DateTimeTool.Click += new System.EventHandler(this.DateTimeTool_Click);
            // 
            // PanelTool
            // 
            this.PanelTool.Image = ((System.Drawing.Image)(resources.GetObject("PanelTool.Image")));
            this.PanelTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PanelTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PanelTool.Name = "PanelTool";
            this.PanelTool.Size = new System.Drawing.Size(110, 20);
            this.PanelTool.Text = "Panel";
            this.PanelTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelTool.ToolTipText = "Add your Button";
            this.PanelTool.Click += new System.EventHandler(this.PanelTool_Click);
            // 
            // PicTool
            // 
            this.PicTool.Image = ((System.Drawing.Image)(resources.GetObject("PicTool.Image")));
            this.PicTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PicTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PicTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PicTool.Name = "PicTool";
            this.PicTool.Size = new System.Drawing.Size(110, 20);
            this.PicTool.Text = "PictureBox";
            this.PicTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PicTool.ToolTipText = "Add your Button";
            this.PicTool.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // RadioTool
            // 
            this.RadioTool.Image = ((System.Drawing.Image)(resources.GetObject("RadioTool.Image")));
            this.RadioTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RadioTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RadioTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RadioTool.Name = "RadioTool";
            this.RadioTool.Size = new System.Drawing.Size(110, 20);
            this.RadioTool.Text = "Radio";
            this.RadioTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RadioTool.ToolTipText = "Add your Button";
            this.RadioTool.Click += new System.EventHandler(this.RadioTool_Click);
            // 
            // txtTool
            // 
            this.txtTool.Image = ((System.Drawing.Image)(resources.GetObject("txtTool.Image")));
            this.txtTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.txtTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtTool.Name = "txtTool";
            this.txtTool.Size = new System.Drawing.Size(110, 20);
            this.txtTool.Text = "TextBox";
            this.txtTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTool.ToolTipText = "Add your TextBox";
            this.txtTool.Click += new System.EventHandler(this.txtTool_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(110, 36);
            this.toolStripButton1.Text = "SQL Settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(932, 24);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(240, 738);
            this.propertyGrid1.TabIndex = 25;
            this.propertyGrid1.UseCompatibleTextRendering = true;
            // 
            // pnControls
            // 
            this.pnControls.BackColor = System.Drawing.Color.White;
            this.pnControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnControls.Location = new System.Drawing.Point(113, 24);
            this.pnControls.Name = "pnControls";
            this.pnControls.Size = new System.Drawing.Size(819, 738);
            this.pnControls.TabIndex = 26;
            this.pnControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnControls_MouseDown);
            this.pnControls.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnControls_MouseMove);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNew,
            this.MenuSave,
            this.MenuOpen});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MenuNew
            // 
            this.MenuNew.Image = ((System.Drawing.Image)(resources.GetObject("MenuNew.Image")));
            this.MenuNew.Name = "MenuNew";
            this.MenuNew.Size = new System.Drawing.Size(103, 22);
            this.MenuNew.Text = "New";
            // 
            // MenuSave
            // 
            this.MenuSave.Image = ((System.Drawing.Image)(resources.GetObject("MenuSave.Image")));
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(103, 22);
            this.MenuSave.Text = "Save";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Image = ((System.Drawing.Image)(resources.GetObject("MenuOpen.Image")));
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(103, 22);
            this.MenuOpen.Text = "Open";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCut,
            this.MenuCopy,
            this.MenuPaste});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // MenuCut
            // 
            this.MenuCut.Image = ((System.Drawing.Image)(resources.GetObject("MenuCut.Image")));
            this.MenuCut.Name = "MenuCut";
            this.MenuCut.Size = new System.Drawing.Size(102, 22);
            this.MenuCut.Text = "Cut";
            // 
            // MenuCopy
            // 
            this.MenuCopy.Image = ((System.Drawing.Image)(resources.GetObject("MenuCopy.Image")));
            this.MenuCopy.Name = "MenuCopy";
            this.MenuCopy.Size = new System.Drawing.Size(102, 22);
            this.MenuCopy.Text = "Copy";
            // 
            // MenuPaste
            // 
            this.MenuPaste.Enabled = false;
            this.MenuPaste.Image = ((System.Drawing.Image)(resources.GetObject("MenuPaste.Image")));
            this.MenuPaste.Name = "MenuPaste";
            this.MenuPaste.Size = new System.Drawing.Size(102, 22);
            this.MenuPaste.Text = "Paste";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.aboutToolStripMenuItem.Text = "About ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1172, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(113, 648);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 114);
            this.panel1.TabIndex = 27;
            this.panel1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtControltoBind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTextBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtParameterName1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQuery);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Your SQL Select Query Here with your Search Conditions";
            // 
            // txtControltoBind
            // 
            this.txtControltoBind.Location = new System.Drawing.Point(632, 16);
            this.txtControltoBind.Name = "txtControltoBind";
            this.txtControltoBind.Size = new System.Drawing.Size(112, 21);
            this.txtControltoBind.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Control to Bind";
            // 
            // txtTextBox1
            // 
            this.txtTextBox1.Location = new System.Drawing.Point(392, 16);
            this.txtTextBox1.Name = "txtTextBox1";
            this.txtTextBox1.Size = new System.Drawing.Size(112, 21);
            this.txtTextBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parameter Condition Name";
            // 
            // txtParameterName1
            // 
            this.txtParameterName1.Location = new System.Drawing.Point(168, 16);
            this.txtParameterName1.Name = "txtParameterName1";
            this.txtParameterName1.Size = new System.Drawing.Size(112, 21);
            this.txtParameterName1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "TextBox Name";
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtQuery.Location = new System.Drawing.Point(3, 48);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(813, 63);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.Text = "";
            // 
            // frmMaindesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 762);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnControls);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMaindesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Design  Your Form";
            this.Load += new System.EventHandler(this.frmMaindesign_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolNewAdd;
        private System.Windows.Forms.ToolStripButton toolSaves;
        private System.Windows.Forms.ToolStripButton toolOpens;
        private System.Windows.Forms.ToolStripButton toolCuts;
        private System.Windows.Forms.ToolStripButton toolCopys;
        private System.Windows.Forms.ToolStripButton toolPastes;
        private System.Windows.Forms.ToolStripButton DeleteATool;
        private System.Windows.Forms.ToolStripButton DeleteSTool;
        private System.Windows.Forms.ToolStripButton frmbackColor;
        private System.Windows.Forms.ToolStripButton lblTool1;
        private System.Windows.Forms.ToolStripButton CheckboxTool;
        private System.Windows.Forms.ToolStripButton btnTool;
        private System.Windows.Forms.ToolStripButton ComboBoxTool;
        private System.Windows.Forms.ToolStripButton GridTool;
        private System.Windows.Forms.ToolStripButton DateTimeTool;
        private System.Windows.Forms.ToolStripButton PanelTool;
        private System.Windows.Forms.ToolStripButton PicTool;
        private System.Windows.Forms.ToolStripButton RadioTool;
        private System.Windows.Forms.ToolStripButton txtTool;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.ToolStripButton toolBringtoFront;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuNew;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuCut;
        private System.Windows.Forms.ToolStripMenuItem MenuCopy;
        private System.Windows.Forms.ToolStripMenuItem MenuPaste;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtControltoBind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParameterName1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

