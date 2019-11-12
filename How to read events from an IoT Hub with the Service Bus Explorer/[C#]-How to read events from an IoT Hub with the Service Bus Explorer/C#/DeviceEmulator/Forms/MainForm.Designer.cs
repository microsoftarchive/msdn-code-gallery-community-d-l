namespace Microsoft.AzureCat.Samples.DeviceEmulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mainHeaderPanel = new Microsoft.AzureCat.Samples.DeviceEmulator.HeaderPanel();
            this.btnRemoveDevices = new System.Windows.Forms.Button();
            this.btnCreateDevices = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.grouperDevice = new Microsoft.AzureCat.Samples.DeviceEmulator.Grouper();
            this.lblSpikePercentage = new System.Windows.Forms.Label();
            this.trackbarSpikePercentage = new Microsoft.AzureCat.Samples.DeviceEmulator.CustomTrackBar();
            this.txtMinOffset = new Microsoft.AzureCat.Samples.DeviceEmulator.NumericTextBox();
            this.lblMaxOffset = new System.Windows.Forms.Label();
            this.txtMaxOffset = new Microsoft.AzureCat.Samples.DeviceEmulator.NumericTextBox();
            this.lblMinOffset = new System.Windows.Forms.Label();
            this.lblEventIntervalInMilliseconds = new System.Windows.Forms.Label();
            this.txtEventIntervalInMilliseconds = new Microsoft.AzureCat.Samples.DeviceEmulator.NumericTextBox();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.txtMaxValue = new Microsoft.AzureCat.Samples.DeviceEmulator.NumericTextBox();
            this.lblMinValue = new System.Windows.Forms.Label();
            this.txtMinValue = new Microsoft.AzureCat.Samples.DeviceEmulator.NumericTextBox();
            this.lblDeviceCount = new System.Windows.Forms.Label();
            this.txtDeviceCount = new Microsoft.AzureCat.Samples.DeviceEmulator.NumericTextBox();
            this.grouperIoTHub = new Microsoft.AzureCat.Samples.DeviceEmulator.Grouper();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.logHeaderPanel = new Microsoft.AzureCat.Samples.DeviceEmulator.HeaderPanel();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.mainHeaderPanel.SuspendLayout();
            this.grouperDevice.SuspendLayout();
            this.grouperIoTHub.SuspendLayout();
            this.logHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(848, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem,
            this.saveLogToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log As...";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // logWindowToolStripMenuItem
            // 
            this.logWindowToolStripMenuItem.Checked = true;
            this.logWindowToolStripMenuItem.CheckOnClick = true;
            this.logWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logWindowToolStripMenuItem.Name = "logWindowToolStripMenuItem";
            this.logWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.logWindowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.logWindowToolStripMenuItem.Text = "&Log Window";
            this.logWindowToolStripMenuItem.Click += new System.EventHandler(this.logWindowToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(848, 22);
            this.statusStrip.TabIndex = 20;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(16, 40);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.mainHeaderPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logHeaderPanel);
            this.splitContainer.Size = new System.Drawing.Size(816, 696);
            this.splitContainer.SplitterDistance = 335;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 21;
            // 
            // mainHeaderPanel
            // 
            this.mainHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mainHeaderPanel.Controls.Add(this.btnRemoveDevices);
            this.mainHeaderPanel.Controls.Add(this.btnCreateDevices);
            this.mainHeaderPanel.Controls.Add(this.btnClear);
            this.mainHeaderPanel.Controls.Add(this.btnStart);
            this.mainHeaderPanel.Controls.Add(this.grouperDevice);
            this.mainHeaderPanel.Controls.Add(this.grouperIoTHub);
            this.mainHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainHeaderPanel.ForeColor = System.Drawing.Color.White;
            this.mainHeaderPanel.HeaderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.mainHeaderPanel.HeaderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.mainHeaderPanel.HeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.mainHeaderPanel.HeaderHeight = 24;
            this.mainHeaderPanel.HeaderText = " Configuration";
            this.mainHeaderPanel.Icon = global::Microsoft.AzureCat.Samples.DeviceEmulator.Properties.Resources.SmallWorld;
            this.mainHeaderPanel.IconTransparentColor = System.Drawing.Color.White;
            this.mainHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.mainHeaderPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.mainHeaderPanel.Name = "mainHeaderPanel";
            this.mainHeaderPanel.Padding = new System.Windows.Forms.Padding(5, 28, 5, 4);
            this.mainHeaderPanel.Size = new System.Drawing.Size(816, 335);
            this.mainHeaderPanel.TabIndex = 0;
            // 
            // btnRemoveDevices
            // 
            this.btnRemoveDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnRemoveDevices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRemoveDevices.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRemoveDevices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRemoveDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDevices.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemoveDevices.Location = new System.Drawing.Point(128, 296);
            this.btnRemoveDevices.Name = "btnRemoveDevices";
            this.btnRemoveDevices.Size = new System.Drawing.Size(104, 24);
            this.btnRemoveDevices.TabIndex = 165;
            this.btnRemoveDevices.Text = "Remove Devices";
            this.btnRemoveDevices.UseVisualStyleBackColor = false;
            this.btnRemoveDevices.Click += new System.EventHandler(this.btnRemoveDevices_Click);
            // 
            // btnCreateDevices
            // 
            this.btnCreateDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnCreateDevices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDevices.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDevices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDevices.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreateDevices.Location = new System.Drawing.Point(16, 296);
            this.btnCreateDevices.Name = "btnCreateDevices";
            this.btnCreateDevices.Size = new System.Drawing.Size(104, 24);
            this.btnCreateDevices.TabIndex = 164;
            this.btnCreateDevices.Text = "Create Devices";
            this.btnCreateDevices.UseVisualStyleBackColor = false;
            this.btnCreateDevices.Click += new System.EventHandler(this.btnCreateDevices_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Location = new System.Drawing.Point(584, 295);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 24);
            this.btnClear.TabIndex = 163;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(696, 295);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 24);
            this.btnStart.TabIndex = 162;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // grouperDevice
            // 
            this.grouperDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperDevice.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperDevice.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperDevice.BackgroundGradientMode = Microsoft.AzureCat.Samples.DeviceEmulator.Grouper.GroupBoxGradientMode.None;
            this.grouperDevice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperDevice.BorderThickness = 1F;
            this.grouperDevice.Controls.Add(this.lblSpikePercentage);
            this.grouperDevice.Controls.Add(this.trackbarSpikePercentage);
            this.grouperDevice.Controls.Add(this.txtMinOffset);
            this.grouperDevice.Controls.Add(this.lblMaxOffset);
            this.grouperDevice.Controls.Add(this.txtMaxOffset);
            this.grouperDevice.Controls.Add(this.lblMinOffset);
            this.grouperDevice.Controls.Add(this.lblEventIntervalInMilliseconds);
            this.grouperDevice.Controls.Add(this.txtEventIntervalInMilliseconds);
            this.grouperDevice.Controls.Add(this.lblMaxValue);
            this.grouperDevice.Controls.Add(this.txtMaxValue);
            this.grouperDevice.Controls.Add(this.lblMinValue);
            this.grouperDevice.Controls.Add(this.txtMinValue);
            this.grouperDevice.Controls.Add(this.lblDeviceCount);
            this.grouperDevice.Controls.Add(this.txtDeviceCount);
            this.grouperDevice.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperDevice.GroupImage = null;
            this.grouperDevice.GroupTitle = "Device";
            this.grouperDevice.Location = new System.Drawing.Point(16, 136);
            this.grouperDevice.Name = "grouperDevice";
            this.grouperDevice.Padding = new System.Windows.Forms.Padding(20);
            this.grouperDevice.PaintGroupBox = true;
            this.grouperDevice.RoundCorners = 4;
            this.grouperDevice.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperDevice.ShadowControl = false;
            this.grouperDevice.ShadowThickness = 3;
            this.grouperDevice.Size = new System.Drawing.Size(784, 144);
            this.grouperDevice.TabIndex = 161;
            // 
            // lblSpikePercentage
            // 
            this.lblSpikePercentage.AutoSize = true;
            this.lblSpikePercentage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSpikePercentage.Location = new System.Drawing.Point(400, 80);
            this.lblSpikePercentage.Name = "lblSpikePercentage";
            this.lblSpikePercentage.Size = new System.Drawing.Size(95, 13);
            this.lblSpikePercentage.TabIndex = 162;
            this.lblSpikePercentage.Text = "Spike Percentage:";
            // 
            // trackbarSpikePercentage
            // 
            this.trackbarSpikePercentage.BackColor = System.Drawing.Color.Transparent;
            this.trackbarSpikePercentage.BorderColor = System.Drawing.Color.Black;
            this.trackbarSpikePercentage.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackbarSpikePercentage.ForeColor = System.Drawing.Color.Black;
            this.trackbarSpikePercentage.IndentHeight = 6;
            this.trackbarSpikePercentage.Location = new System.Drawing.Point(392, 88);
            this.trackbarSpikePercentage.Maximum = 100;
            this.trackbarSpikePercentage.Minimum = 0;
            this.trackbarSpikePercentage.Name = "trackbarSpikePercentage";
            this.trackbarSpikePercentage.Size = new System.Drawing.Size(376, 47);
            this.trackbarSpikePercentage.TabIndex = 161;
            this.trackbarSpikePercentage.TickColor = System.Drawing.Color.Gray;
            this.trackbarSpikePercentage.TickFrequency = 10;
            this.trackbarSpikePercentage.TickHeight = 4;
            this.trackbarSpikePercentage.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.trackbarSpikePercentage.TrackerSize = new System.Drawing.Size(16, 16);
            this.trackbarSpikePercentage.TrackLineBrushStyle = Microsoft.AzureCat.Samples.DeviceEmulator.BrushStyle.LinearGradient;
            this.trackbarSpikePercentage.TrackLineColor = System.Drawing.Color.Black;
            this.trackbarSpikePercentage.TrackLineHeight = 1;
            this.trackbarSpikePercentage.Value = 0;
            // 
            // txtMinOffset
            // 
            this.txtMinOffset.AllowSpace = false;
            this.txtMinOffset.Location = new System.Drawing.Point(400, 48);
            this.txtMinOffset.Name = "txtMinOffset";
            this.txtMinOffset.Size = new System.Drawing.Size(176, 20);
            this.txtMinOffset.TabIndex = 160;
            // 
            // lblMaxOffset
            // 
            this.lblMaxOffset.AutoSize = true;
            this.lblMaxOffset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxOffset.Location = new System.Drawing.Point(592, 32);
            this.lblMaxOffset.Name = "lblMaxOffset";
            this.lblMaxOffset.Size = new System.Drawing.Size(61, 13);
            this.lblMaxOffset.TabIndex = 159;
            this.lblMaxOffset.Text = "Max Offset:";
            // 
            // txtMaxOffset
            // 
            this.txtMaxOffset.AllowSpace = false;
            this.txtMaxOffset.Location = new System.Drawing.Point(592, 48);
            this.txtMaxOffset.Name = "txtMaxOffset";
            this.txtMaxOffset.Size = new System.Drawing.Size(176, 20);
            this.txtMaxOffset.TabIndex = 158;
            // 
            // lblMinOffset
            // 
            this.lblMinOffset.AutoSize = true;
            this.lblMinOffset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMinOffset.Location = new System.Drawing.Point(400, 32);
            this.lblMinOffset.Name = "lblMinOffset";
            this.lblMinOffset.Size = new System.Drawing.Size(58, 13);
            this.lblMinOffset.TabIndex = 157;
            this.lblMinOffset.Text = "Min Offset:";
            // 
            // lblEventIntervalInMilliseconds
            // 
            this.lblEventIntervalInMilliseconds.AutoSize = true;
            this.lblEventIntervalInMilliseconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEventIntervalInMilliseconds.Location = new System.Drawing.Point(208, 80);
            this.lblEventIntervalInMilliseconds.Name = "lblEventIntervalInMilliseconds";
            this.lblEventIntervalInMilliseconds.Size = new System.Drawing.Size(142, 13);
            this.lblEventIntervalInMilliseconds.TabIndex = 61;
            this.lblEventIntervalInMilliseconds.Text = "Event Interval In Millisconds:";
            // 
            // txtEventIntervalInMilliseconds
            // 
            this.txtEventIntervalInMilliseconds.AllowSpace = false;
            this.txtEventIntervalInMilliseconds.Location = new System.Drawing.Point(208, 96);
            this.txtEventIntervalInMilliseconds.Name = "txtEventIntervalInMilliseconds";
            this.txtEventIntervalInMilliseconds.Size = new System.Drawing.Size(176, 20);
            this.txtEventIntervalInMilliseconds.TabIndex = 55;
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxValue.Location = new System.Drawing.Point(208, 32);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(60, 13);
            this.lblMaxValue.TabIndex = 60;
            this.lblMaxValue.Text = "Max Value:";
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.AllowSpace = false;
            this.txtMaxValue.Location = new System.Drawing.Point(208, 48);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(176, 20);
            this.txtMaxValue.TabIndex = 57;
            // 
            // lblMinValue
            // 
            this.lblMinValue.AutoSize = true;
            this.lblMinValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMinValue.Location = new System.Drawing.Point(16, 32);
            this.lblMinValue.Name = "lblMinValue";
            this.lblMinValue.Size = new System.Drawing.Size(57, 13);
            this.lblMinValue.TabIndex = 59;
            this.lblMinValue.Text = "Min Value:";
            // 
            // txtMinValue
            // 
            this.txtMinValue.AllowSpace = false;
            this.txtMinValue.Location = new System.Drawing.Point(16, 48);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(176, 20);
            this.txtMinValue.TabIndex = 56;
            // 
            // lblDeviceCount
            // 
            this.lblDeviceCount.AutoSize = true;
            this.lblDeviceCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeviceCount.Location = new System.Drawing.Point(16, 80);
            this.lblDeviceCount.Name = "lblDeviceCount";
            this.lblDeviceCount.Size = new System.Drawing.Size(75, 13);
            this.lblDeviceCount.TabIndex = 58;
            this.lblDeviceCount.Text = "Device Count:";
            // 
            // txtDeviceCount
            // 
            this.txtDeviceCount.AllowSpace = false;
            this.txtDeviceCount.Location = new System.Drawing.Point(16, 96);
            this.txtDeviceCount.Name = "txtDeviceCount";
            this.txtDeviceCount.Size = new System.Drawing.Size(176, 20);
            this.txtDeviceCount.TabIndex = 54;
            // 
            // grouperIoTHub
            // 
            this.grouperIoTHub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperIoTHub.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperIoTHub.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperIoTHub.BackgroundGradientMode = Microsoft.AzureCat.Samples.DeviceEmulator.Grouper.GroupBoxGradientMode.None;
            this.grouperIoTHub.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperIoTHub.BorderThickness = 1F;
            this.grouperIoTHub.Controls.Add(this.lblConnectionString);
            this.grouperIoTHub.Controls.Add(this.txtConnectionString);
            this.grouperIoTHub.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperIoTHub.GroupImage = null;
            this.grouperIoTHub.GroupTitle = "IoT Hub";
            this.grouperIoTHub.Location = new System.Drawing.Point(16, 40);
            this.grouperIoTHub.Name = "grouperIoTHub";
            this.grouperIoTHub.Padding = new System.Windows.Forms.Padding(20);
            this.grouperIoTHub.PaintGroupBox = true;
            this.grouperIoTHub.RoundCorners = 4;
            this.grouperIoTHub.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperIoTHub.ShadowControl = false;
            this.grouperIoTHub.ShadowThickness = 3;
            this.grouperIoTHub.Size = new System.Drawing.Size(784, 88);
            this.grouperIoTHub.TabIndex = 158;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConnectionString.Location = new System.Drawing.Point(16, 30);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(91, 13);
            this.lblConnectionString.TabIndex = 46;
            this.lblConnectionString.Text = "ConnectionString:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(16, 48);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(752, 20);
            this.txtConnectionString.TabIndex = 40;
            // 
            // logHeaderPanel
            // 
            this.logHeaderPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.logHeaderPanel.Controls.Add(this.lstLog);
            this.logHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logHeaderPanel.ForeColor = System.Drawing.Color.White;
            this.logHeaderPanel.HeaderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.logHeaderPanel.HeaderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.logHeaderPanel.HeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.logHeaderPanel.HeaderHeight = 24;
            this.logHeaderPanel.HeaderText = "Log";
            this.logHeaderPanel.Icon = global::Microsoft.AzureCat.Samples.DeviceEmulator.Properties.Resources.SmallDocument;
            this.logHeaderPanel.IconTransparentColor = System.Drawing.Color.White;
            this.logHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.logHeaderPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.logHeaderPanel.Name = "logHeaderPanel";
            this.logHeaderPanel.Padding = new System.Windows.Forms.Padding(5, 28, 5, 4);
            this.logHeaderPanel.Size = new System.Drawing.Size(816, 353);
            this.logHeaderPanel.TabIndex = 0;
            // 
            // lstLog
            // 
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.Location = new System.Drawing.Point(5, 28);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(806, 321);
            this.lstLog.TabIndex = 0;
            this.lstLog.Leave += new System.EventHandler(this.lstLog_Leave);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(848, 761);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Emulator";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.mainHeaderPanel.ResumeLayout(false);
            this.grouperDevice.ResumeLayout(false);
            this.grouperDevice.PerformLayout();
            this.grouperIoTHub.ResumeLayout(false);
            this.grouperIoTHub.PerformLayout();
            this.logHeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private HeaderPanel logHeaderPanel;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private HeaderPanel mainHeaderPanel;
        private Grouper grouperDevice;
        private System.Windows.Forms.Label lblSpikePercentage;
        private CustomTrackBar trackbarSpikePercentage;
        private NumericTextBox txtMinOffset;
        private System.Windows.Forms.Label lblMaxOffset;
        private NumericTextBox txtMaxOffset;
        private System.Windows.Forms.Label lblMinOffset;
        private System.Windows.Forms.Label lblEventIntervalInMilliseconds;
        private NumericTextBox txtEventIntervalInMilliseconds;
        private System.Windows.Forms.Label lblMaxValue;
        private NumericTextBox txtMaxValue;
        private System.Windows.Forms.Label lblMinValue;
        private NumericTextBox txtMinValue;
        private System.Windows.Forms.Label lblDeviceCount;
        private NumericTextBox txtDeviceCount;
        private Grouper grouperIoTHub;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Button btnRemoveDevices;
        private System.Windows.Forms.Button btnCreateDevices;
    }
}