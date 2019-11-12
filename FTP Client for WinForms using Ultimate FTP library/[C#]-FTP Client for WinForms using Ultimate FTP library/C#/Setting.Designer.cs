namespace ClientSample
{
    partial class Setting
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
            this.chkSmartPath = new System.Windows.Forms.CheckBox();
            this.chkChDirBeforeTransfer = new System.Windows.Forms.CheckBox();
            this.chkChDirBeforeListing = new System.Windows.Forms.CheckBox();
            this.chkSendABOR = new System.Windows.Forms.CheckBox();
            this.chkSendSignals = new System.Windows.Forms.CheckBox();
            this.lblKAS = new System.Windows.Forms.Label();
            this.lblKeepAlive = new System.Windows.Forms.Label();
            this.txtKeepAliveInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkCompress = new System.Windows.Forms.CheckBox();
            this.rbtBinary = new System.Windows.Forms.RadioButton();
            this.rbtAscii = new System.Windows.Forms.RadioButton();
            this.tabControlExt = new System.Windows.Forms.TabControl();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.lblProgressSlow = new System.Windows.Forms.Label();
            this.lblThrottle = new System.Windows.Forms.Label();
            this.lblProgressFast = new System.Windows.Forms.Label();
            this.txtThrottle = new System.Windows.Forms.TextBox();
            this.tbProgress = new System.Windows.Forms.TrackBar();
            this.lblKBPS = new System.Windows.Forms.Label();
            this.lblProgressUpdate = new System.Windows.Forms.Label();
            this.ftpPage = new System.Windows.Forms.TabPage();
            this.sftpPage = new System.Windows.Forms.TabPage();
            this.lblServer = new System.Windows.Forms.Label();
            this.cbxServerOs = new System.Windows.Forms.ComboBox();
            this.chkRestoreProperties = new System.Windows.Forms.CheckBox();
            this.chkShowProgressWhileTransferring = new System.Windows.Forms.CheckBox();
            this.chkShowProgress = new System.Windows.Forms.CheckBox();
            this.tabControlExt.SuspendLayout();
            this.generalPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).BeginInit();
            this.ftpPage.SuspendLayout();
            this.sftpPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSmartPath
            // 
            this.chkSmartPath.BackColor = System.Drawing.SystemColors.Control;
            this.chkSmartPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSmartPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSmartPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSmartPath.Location = new System.Drawing.Point(11, 67);
            this.chkSmartPath.Name = "chkSmartPath";
            this.chkSmartPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSmartPath.Size = new System.Drawing.Size(129, 22);
            this.chkSmartPath.TabIndex = 4;
            this.chkSmartPath.Text = "Smart Path Resolving";
            this.chkSmartPath.UseVisualStyleBackColor = false;
            // 
            // chkChDirBeforeTransfer
            // 
            this.chkChDirBeforeTransfer.BackColor = System.Drawing.SystemColors.Control;
            this.chkChDirBeforeTransfer.Checked = true;
            this.chkChDirBeforeTransfer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChDirBeforeTransfer.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkChDirBeforeTransfer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChDirBeforeTransfer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkChDirBeforeTransfer.Location = new System.Drawing.Point(11, 117);
            this.chkChDirBeforeTransfer.Name = "chkChDirBeforeTransfer";
            this.chkChDirBeforeTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkChDirBeforeTransfer.Size = new System.Drawing.Size(287, 22);
            this.chkChDirBeforeTransfer.TabIndex = 7;
            this.chkChDirBeforeTransfer.Text = "Change Dir before transferring files (slow but reliable)";
            this.chkChDirBeforeTransfer.UseVisualStyleBackColor = false;
            // 
            // chkChDirBeforeListing
            // 
            this.chkChDirBeforeListing.BackColor = System.Drawing.SystemColors.Control;
            this.chkChDirBeforeListing.Checked = true;
            this.chkChDirBeforeListing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChDirBeforeListing.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkChDirBeforeListing.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChDirBeforeListing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkChDirBeforeListing.Location = new System.Drawing.Point(11, 95);
            this.chkChDirBeforeListing.Name = "chkChDirBeforeListing";
            this.chkChDirBeforeListing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkChDirBeforeListing.Size = new System.Drawing.Size(234, 22);
            this.chkChDirBeforeListing.TabIndex = 6;
            this.chkChDirBeforeListing.Text = "Change Dir before listing (slow but reliable)";
            this.chkChDirBeforeListing.UseVisualStyleBackColor = false;
            // 
            // chkSendABOR
            // 
            this.chkSendABOR.BackColor = System.Drawing.SystemColors.Control;
            this.chkSendABOR.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSendABOR.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendABOR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSendABOR.Location = new System.Drawing.Point(11, 31);
            this.chkSendABOR.Name = "chkSendABOR";
            this.chkSendABOR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSendABOR.Size = new System.Drawing.Size(257, 18);
            this.chkSendABOR.TabIndex = 2;
            this.chkSendABOR.Text = "Send ABOR command when aborting download";
            this.chkSendABOR.ThreeState = true;
            this.chkSendABOR.UseVisualStyleBackColor = false;
            // 
            // chkSendSignals
            // 
            this.chkSendSignals.BackColor = System.Drawing.SystemColors.Control;
            this.chkSendSignals.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSendSignals.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendSignals.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSendSignals.Location = new System.Drawing.Point(11, 49);
            this.chkSendSignals.Name = "chkSendSignals";
            this.chkSendSignals.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSendSignals.Size = new System.Drawing.Size(212, 20);
            this.chkSendSignals.TabIndex = 3;
            this.chkSendSignals.Text = "Send signals when aborting download";
            this.chkSendSignals.UseVisualStyleBackColor = false;
            // 
            // lblKAS
            // 
            this.lblKAS.BackColor = System.Drawing.SystemColors.Control;
            this.lblKAS.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblKAS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKAS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKAS.Location = new System.Drawing.Point(156, 18);
            this.lblKAS.Name = "lblKAS";
            this.lblKAS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKAS.Size = new System.Drawing.Size(10, 14);
            this.lblKAS.TabIndex = 87;
            this.lblKAS.Text = "s";
            // 
            // lblKeepAlive
            // 
            this.lblKeepAlive.BackColor = System.Drawing.SystemColors.Control;
            this.lblKeepAlive.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblKeepAlive.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeepAlive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKeepAlive.Location = new System.Drawing.Point(11, 12);
            this.lblKeepAlive.Name = "lblKeepAlive";
            this.lblKeepAlive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKeepAlive.Size = new System.Drawing.Size(70, 28);
            this.lblKeepAlive.TabIndex = 86;
            this.lblKeepAlive.Text = "Keep Alive Interval:";
            // 
            // txtKeepAliveInterval
            // 
            this.txtKeepAliveInterval.AcceptsReturn = true;
            this.txtKeepAliveInterval.BackColor = System.Drawing.SystemColors.Window;
            this.txtKeepAliveInterval.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeepAliveInterval.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeepAliveInterval.Location = new System.Drawing.Point(85, 14);
            this.txtKeepAliveInterval.MaxLength = 3;
            this.txtKeepAliveInterval.Name = "txtKeepAliveInterval";
            this.txtKeepAliveInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtKeepAliveInterval.Size = new System.Drawing.Size(62, 20);
            this.txtKeepAliveInterval.TabIndex = 1;
            this.txtKeepAliveInterval.Text = "60";
            this.txtKeepAliveInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(326, 17);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(10, 14);
            this.label3.TabIndex = 83;
            this.label3.Text = "s";
            // 
            // lblTimeout
            // 
            this.lblTimeout.BackColor = System.Drawing.SystemColors.Control;
            this.lblTimeout.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTimeout.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimeout.Location = new System.Drawing.Point(211, 17);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTimeout.Size = new System.Drawing.Size(48, 14);
            this.lblTimeout.TabIndex = 82;
            this.lblTimeout.Text = "Timeout:";
            // 
            // txtTimeout
            // 
            this.txtTimeout.AcceptsReturn = true;
            this.txtTimeout.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimeout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimeout.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeout.Location = new System.Drawing.Point(286, 14);
            this.txtTimeout.MaxLength = 3;
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTimeout.Size = new System.Drawing.Size(36, 20);
            this.txtTimeout.TabIndex = 2;
            this.txtTimeout.Text = "30";
            this.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(240, 281);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 40;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(321, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancel";
            // 
            // chkCompress
            // 
            this.chkCompress.BackColor = System.Drawing.SystemColors.Control;
            this.chkCompress.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkCompress.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCompress.Location = new System.Drawing.Point(11, 10);
            this.chkCompress.Name = "chkCompress";
            this.chkCompress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCompress.Size = new System.Drawing.Size(180, 17);
            this.chkCompress.TabIndex = 1;
            this.chkCompress.Text = "Enable Compression (MODE Z)";
            this.chkCompress.UseVisualStyleBackColor = false;
            // 
            // rbtBinary
            // 
            this.rbtBinary.Location = new System.Drawing.Point(15, 207);
            this.rbtBinary.Name = "rbtBinary";
            this.rbtBinary.Size = new System.Drawing.Size(96, 26);
            this.rbtBinary.TabIndex = 7;
            this.rbtBinary.Text = "Binary Transfer";
            // 
            // rbtAscii
            // 
            this.rbtAscii.Location = new System.Drawing.Point(15, 189);
            this.rbtAscii.Name = "rbtAscii";
            this.rbtAscii.Size = new System.Drawing.Size(94, 20);
            this.rbtAscii.TabIndex = 6;
            this.rbtAscii.Text = "ASCII Transfer";
            // 
            // tabControlExt
            // 
            this.tabControlExt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlExt.Controls.Add(this.generalPage);
            this.tabControlExt.Controls.Add(this.ftpPage);
            this.tabControlExt.Controls.Add(this.sftpPage);
            this.tabControlExt.Location = new System.Drawing.Point(7, 6);
            this.tabControlExt.Name = "tabControlExt";
            this.tabControlExt.SelectedIndex = 0;
            this.tabControlExt.Size = new System.Drawing.Size(390, 268);
            this.tabControlExt.TabIndex = 114;
            // 
            // generalPage
            // 
            this.generalPage.Controls.Add(this.chkRestoreProperties);
            this.generalPage.Controls.Add(this.chkShowProgressWhileTransferring);
            this.generalPage.Controls.Add(this.chkShowProgress);
            this.generalPage.Controls.Add(this.lblProgressSlow);
            this.generalPage.Controls.Add(this.lblThrottle);
            this.generalPage.Controls.Add(this.lblProgressFast);
            this.generalPage.Controls.Add(this.rbtAscii);
            this.generalPage.Controls.Add(this.rbtBinary);
            this.generalPage.Controls.Add(this.txtThrottle);
            this.generalPage.Controls.Add(this.tbProgress);
            this.generalPage.Controls.Add(this.lblKBPS);
            this.generalPage.Controls.Add(this.lblKAS);
            this.generalPage.Controls.Add(this.lblProgressUpdate);
            this.generalPage.Controls.Add(this.lblKeepAlive);
            this.generalPage.Controls.Add(this.txtKeepAliveInterval);
            this.generalPage.Controls.Add(this.txtTimeout);
            this.generalPage.Controls.Add(this.label3);
            this.generalPage.Controls.Add(this.lblTimeout);
            this.generalPage.Location = new System.Drawing.Point(4, 22);
            this.generalPage.Name = "generalPage";
            this.generalPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalPage.Size = new System.Drawing.Size(382, 242);
            this.generalPage.TabIndex = 0;
            this.generalPage.Text = "General Settings";
            this.generalPage.UseVisualStyleBackColor = true;
            // 
            // lblProgressSlow
            // 
            this.lblProgressSlow.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgressSlow.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblProgressSlow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressSlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgressSlow.Location = new System.Drawing.Point(303, 152);
            this.lblProgressSlow.Name = "lblProgressSlow";
            this.lblProgressSlow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProgressSlow.Size = new System.Drawing.Size(35, 14);
            this.lblProgressSlow.TabIndex = 95;
            this.lblProgressSlow.Text = "Slow";
            // 
            // lblThrottle
            // 
            this.lblThrottle.BackColor = System.Drawing.SystemColors.Control;
            this.lblThrottle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblThrottle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThrottle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThrottle.Location = new System.Drawing.Point(10, 45);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblThrottle.Size = new System.Drawing.Size(46, 14);
            this.lblThrottle.TabIndex = 90;
            this.lblThrottle.Text = "Throttle:";
            // 
            // lblProgressFast
            // 
            this.lblProgressFast.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgressFast.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblProgressFast.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressFast.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgressFast.Location = new System.Drawing.Point(75, 153);
            this.lblProgressFast.Name = "lblProgressFast";
            this.lblProgressFast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProgressFast.Size = new System.Drawing.Size(28, 14);
            this.lblProgressFast.TabIndex = 94;
            this.lblProgressFast.Text = "Fast";
            // 
            // txtThrottle
            // 
            this.txtThrottle.AcceptsReturn = true;
            this.txtThrottle.BackColor = System.Drawing.SystemColors.Window;
            this.txtThrottle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThrottle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThrottle.Location = new System.Drawing.Point(85, 42);
            this.txtThrottle.MaxLength = 0;
            this.txtThrottle.Name = "txtThrottle";
            this.txtThrottle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtThrottle.Size = new System.Drawing.Size(62, 20);
            this.txtThrottle.TabIndex = 3;
            this.txtThrottle.Text = "0";
            this.txtThrottle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbProgress
            // 
            this.tbProgress.Location = new System.Drawing.Point(103, 147);
            this.tbProgress.Maximum = 20;
            this.tbProgress.Minimum = 1;
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Size = new System.Drawing.Size(200, 42);
            this.tbProgress.TabIndex = 5;
            this.tbProgress.Value = 10;
            // 
            // lblKBPS
            // 
            this.lblKBPS.BackColor = System.Drawing.SystemColors.Control;
            this.lblKBPS.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblKBPS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKBPS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKBPS.Location = new System.Drawing.Point(150, 45);
            this.lblKBPS.Name = "lblKBPS";
            this.lblKBPS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKBPS.Size = new System.Drawing.Size(22, 14);
            this.lblKBPS.TabIndex = 91;
            this.lblKBPS.Text = "Kb/s";
            // 
            // lblProgressUpdate
            // 
            this.lblProgressUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgressUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblProgressUpdate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgressUpdate.Location = new System.Drawing.Point(13, 146);
            this.lblProgressUpdate.Name = "lblProgressUpdate";
            this.lblProgressUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProgressUpdate.Size = new System.Drawing.Size(60, 32);
            this.lblProgressUpdate.TabIndex = 92;
            this.lblProgressUpdate.Text = "Progress Update:";
            // 
            // ftpPage
            // 
            this.ftpPage.Controls.Add(this.chkSmartPath);
            this.ftpPage.Controls.Add(this.chkCompress);
            this.ftpPage.Controls.Add(this.chkChDirBeforeTransfer);
            this.ftpPage.Controls.Add(this.chkChDirBeforeListing);
            this.ftpPage.Controls.Add(this.chkSendABOR);
            this.ftpPage.Controls.Add(this.chkSendSignals);
            this.ftpPage.Location = new System.Drawing.Point(4, 22);
            this.ftpPage.Name = "ftpPage";
            this.ftpPage.Padding = new System.Windows.Forms.Padding(3);
            this.ftpPage.Size = new System.Drawing.Size(355, 197);
            this.ftpPage.TabIndex = 1;
            this.ftpPage.Text = "FTP Settings";
            this.ftpPage.UseVisualStyleBackColor = true;
            // 
            // sftpPage
            // 
            this.sftpPage.Controls.Add(this.lblServer);
            this.sftpPage.Controls.Add(this.cbxServerOs);
            this.sftpPage.Location = new System.Drawing.Point(4, 22);
            this.sftpPage.Name = "sftpPage";
            this.sftpPage.Size = new System.Drawing.Size(355, 197);
            this.sftpPage.TabIndex = 2;
            this.sftpPage.Text = "SFTP Settings";
            this.sftpPage.UseVisualStyleBackColor = true;
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(10, 9);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(59, 13);
            this.lblServer.TabIndex = 45;
            this.lblServer.Text = "Server OS:";
            // 
            // cbxServerOs
            // 
            this.cbxServerOs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerOs.FormattingEnabled = true;
            this.cbxServerOs.Items.AddRange(new object[] {
            "Auto Detect (Default)",
            "Unknown",
            "Windows",
            "Linux"});
            this.cbxServerOs.Location = new System.Drawing.Point(74, 5);
            this.cbxServerOs.Name = "cbxServerOs";
            this.cbxServerOs.Size = new System.Drawing.Size(144, 21);
            this.cbxServerOs.TabIndex = 4;
            // 
            // chkRestoreProperties
            // 
            this.chkRestoreProperties.BackColor = System.Drawing.SystemColors.Control;
            this.chkRestoreProperties.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkRestoreProperties.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRestoreProperties.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkRestoreProperties.Location = new System.Drawing.Point(16, 69);
            this.chkRestoreProperties.Name = "chkRestoreProperties";
            this.chkRestoreProperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkRestoreProperties.Size = new System.Drawing.Size(200, 20);
            this.chkRestoreProperties.TabIndex = 117;
            this.chkRestoreProperties.Text = "Restore file datetime after transfer";
            this.chkRestoreProperties.UseVisualStyleBackColor = false;
            // 
            // chkShowProgressWhileTransferring
            // 
            this.chkShowProgressWhileTransferring.BackColor = System.Drawing.SystemColors.Control;
            this.chkShowProgressWhileTransferring.Checked = true;
            this.chkShowProgressWhileTransferring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowProgressWhileTransferring.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkShowProgressWhileTransferring.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowProgressWhileTransferring.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShowProgressWhileTransferring.Location = new System.Drawing.Point(16, 116);
            this.chkShowProgressWhileTransferring.Name = "chkShowProgressWhileTransferring";
            this.chkShowProgressWhileTransferring.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShowProgressWhileTransferring.Size = new System.Drawing.Size(362, 20);
            this.chkShowProgressWhileTransferring.TabIndex = 116;
            this.chkShowProgressWhileTransferring.Text = "Show progress when transferring multiple files or directories";
            this.chkShowProgressWhileTransferring.UseVisualStyleBackColor = false;
            // 
            // chkShowProgress
            // 
            this.chkShowProgress.BackColor = System.Drawing.SystemColors.Control;
            this.chkShowProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkShowProgress.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShowProgress.Location = new System.Drawing.Point(16, 92);
            this.chkShowProgress.Name = "chkShowProgress";
            this.chkShowProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShowProgress.Size = new System.Drawing.Size(362, 20);
            this.chkShowProgress.TabIndex = 115;
            this.chkShowProgress.Text = "Show progress when deleting files or setting files attributes";
            this.chkShowProgress.UseVisualStyleBackColor = false;
            // 
            // Setting
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 312);
            this.Controls.Add(this.tabControlExt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControlExt.ResumeLayout(false);
            this.generalPage.ResumeLayout(false);
            this.generalPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).EndInit();
            this.ftpPage.ResumeLayout(false);
            this.sftpPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblKAS;
        public System.Windows.Forms.Label lblKeepAlive;
        public System.Windows.Forms.TextBox txtKeepAliveInterval;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblTimeout;
        public System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbtBinary;
        private System.Windows.Forms.RadioButton rbtAscii;
        public System.Windows.Forms.CheckBox chkSendABOR;
        public System.Windows.Forms.CheckBox chkSendSignals;
        public System.Windows.Forms.CheckBox chkChDirBeforeTransfer;
        public System.Windows.Forms.CheckBox chkChDirBeforeListing;
        public System.Windows.Forms.CheckBox chkCompress;
        public System.Windows.Forms.CheckBox chkSmartPath;
        private System.Windows.Forms.TabControl tabControlExt;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.TabPage ftpPage;
        private System.Windows.Forms.TabPage sftpPage;
        public System.Windows.Forms.Label lblProgressSlow;
        public System.Windows.Forms.Label lblThrottle;
        public System.Windows.Forms.Label lblProgressFast;
        public System.Windows.Forms.TextBox txtThrottle;
        private System.Windows.Forms.TrackBar tbProgress;
        public System.Windows.Forms.Label lblKBPS;
        public System.Windows.Forms.Label lblProgressUpdate;
        private System.Windows.Forms.ComboBox cbxServerOs;
        private System.Windows.Forms.Label lblServer;
        public System.Windows.Forms.CheckBox chkRestoreProperties;
        public System.Windows.Forms.CheckBox chkShowProgressWhileTransferring;
        public System.Windows.Forms.CheckBox chkShowProgress;
    }
}