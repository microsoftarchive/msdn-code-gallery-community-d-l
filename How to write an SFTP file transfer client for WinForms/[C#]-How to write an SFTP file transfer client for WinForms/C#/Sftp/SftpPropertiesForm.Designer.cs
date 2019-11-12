namespace ClientSample.Sftp
{
    partial class SftpPropertiesForm
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
            this.grbUser = new System.Windows.Forms.GroupBox();
            this.chkSetUID = new System.Windows.Forms.CheckBox();
            this.chkOwnerExecute = new System.Windows.Forms.CheckBox();
            this.chkOwnerWrite = new System.Windows.Forms.CheckBox();
            this.chkOwnerRead = new System.Windows.Forms.CheckBox();
            this.txtPermissions = new System.Windows.Forms.TextBox();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.grbGroup = new System.Windows.Forms.GroupBox();
            this.chkSetGID = new System.Windows.Forms.CheckBox();
            this.chkGroupExecute = new System.Windows.Forms.CheckBox();
            this.chkGroupWrite = new System.Windows.Forms.CheckBox();
            this.chkGroupRead = new System.Windows.Forms.CheckBox();
            this.grbPublic = new System.Windows.Forms.GroupBox();
            this.chkStickly = new System.Windows.Forms.CheckBox();
            this.chkPublicExecute = new System.Windows.Forms.CheckBox();
            this.chkPublicWrite = new System.Windows.Forms.CheckBox();
            this.chkPublicRead = new System.Windows.Forms.CheckBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbUser.SuspendLayout();
            this.grbGroup.SuspendLayout();
            this.grbPublic.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbUser
            // 
            this.grbUser.Controls.Add(this.chkSetUID);
            this.grbUser.Controls.Add(this.chkOwnerExecute);
            this.grbUser.Controls.Add(this.chkOwnerWrite);
            this.grbUser.Controls.Add(this.chkOwnerRead);
            this.grbUser.Location = new System.Drawing.Point(8, 34);
            this.grbUser.Name = "grbUser";
            this.grbUser.Size = new System.Drawing.Size(103, 99);
            this.grbUser.TabIndex = 87;
            this.grbUser.TabStop = false;
            this.grbUser.Text = "User";
            // 
            // chkSetUID
            // 
            this.chkSetUID.AutoSize = true;
            this.chkSetUID.Location = new System.Drawing.Point(10, 74);
            this.chkSetUID.Name = "chkSetUID";
            this.chkSetUID.Size = new System.Drawing.Size(64, 17);
            this.chkSetUID.TabIndex = 4;
            this.chkSetUID.Text = "Set UID";
            this.chkSetUID.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkOwnerExecute
            // 
            this.chkOwnerExecute.AutoSize = true;
            this.chkOwnerExecute.Location = new System.Drawing.Point(10, 55);
            this.chkOwnerExecute.Name = "chkOwnerExecute";
            this.chkOwnerExecute.Size = new System.Drawing.Size(65, 17);
            this.chkOwnerExecute.TabIndex = 3;
            this.chkOwnerExecute.Text = "Execute";
            this.chkOwnerExecute.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkOwnerWrite
            // 
            this.chkOwnerWrite.AutoSize = true;
            this.chkOwnerWrite.Location = new System.Drawing.Point(10, 36);
            this.chkOwnerWrite.Name = "chkOwnerWrite";
            this.chkOwnerWrite.Size = new System.Drawing.Size(51, 17);
            this.chkOwnerWrite.TabIndex = 2;
            this.chkOwnerWrite.Text = "Write";
            this.chkOwnerWrite.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkOwnerRead
            // 
            this.chkOwnerRead.AutoSize = true;
            this.chkOwnerRead.Location = new System.Drawing.Point(10, 16);
            this.chkOwnerRead.Name = "chkOwnerRead";
            this.chkOwnerRead.Size = new System.Drawing.Size(52, 17);
            this.chkOwnerRead.TabIndex = 1;
            this.chkOwnerRead.Text = "Read";
            this.chkOwnerRead.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // txtPermissions
            // 
            this.txtPermissions.AcceptsReturn = true;
            this.txtPermissions.BackColor = System.Drawing.SystemColors.Window;
            this.txtPermissions.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPermissions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPermissions.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPermissions.Location = new System.Drawing.Point(79, 8);
            this.txtPermissions.MaxLength = 0;
            this.txtPermissions.Name = "txtPermissions";
            this.txtPermissions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPermissions.Size = new System.Drawing.Size(62, 20);
            this.txtPermissions.TabIndex = 0;
            this.txtPermissions.Text = "0";
            this.txtPermissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPermissions.TextChanged += new System.EventHandler(this.txtPermissions_TextChanged);
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.BackColor = System.Drawing.SystemColors.Control;
            this.lblPermissions.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPermissions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPermissions.Location = new System.Drawing.Point(5, 11);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPermissions.Size = new System.Drawing.Size(68, 14);
            this.lblPermissions.TabIndex = 88;
            this.lblPermissions.Text = "Permissions:";
            // 
            // grbGroup
            // 
            this.grbGroup.Controls.Add(this.chkSetGID);
            this.grbGroup.Controls.Add(this.chkGroupExecute);
            this.grbGroup.Controls.Add(this.chkGroupWrite);
            this.grbGroup.Controls.Add(this.chkGroupRead);
            this.grbGroup.Location = new System.Drawing.Point(117, 34);
            this.grbGroup.Name = "grbGroup";
            this.grbGroup.Size = new System.Drawing.Size(103, 99);
            this.grbGroup.TabIndex = 89;
            this.grbGroup.TabStop = false;
            this.grbGroup.Text = "Group";
            // 
            // chkSetGID
            // 
            this.chkSetGID.AutoSize = true;
            this.chkSetGID.Location = new System.Drawing.Point(10, 74);
            this.chkSetGID.Name = "chkSetGID";
            this.chkSetGID.Size = new System.Drawing.Size(64, 17);
            this.chkSetGID.TabIndex = 7;
            this.chkSetGID.Text = "Set GID";
            this.chkSetGID.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkGroupExecute
            // 
            this.chkGroupExecute.AutoSize = true;
            this.chkGroupExecute.Location = new System.Drawing.Point(10, 55);
            this.chkGroupExecute.Name = "chkGroupExecute";
            this.chkGroupExecute.Size = new System.Drawing.Size(65, 17);
            this.chkGroupExecute.TabIndex = 6;
            this.chkGroupExecute.Text = "Execute";
            this.chkGroupExecute.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkGroupWrite
            // 
            this.chkGroupWrite.AutoSize = true;
            this.chkGroupWrite.Location = new System.Drawing.Point(10, 36);
            this.chkGroupWrite.Name = "chkGroupWrite";
            this.chkGroupWrite.Size = new System.Drawing.Size(51, 17);
            this.chkGroupWrite.TabIndex = 5;
            this.chkGroupWrite.Text = "Write";
            this.chkGroupWrite.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkGroupRead
            // 
            this.chkGroupRead.AutoSize = true;
            this.chkGroupRead.Location = new System.Drawing.Point(10, 16);
            this.chkGroupRead.Name = "chkGroupRead";
            this.chkGroupRead.Size = new System.Drawing.Size(52, 17);
            this.chkGroupRead.TabIndex = 4;
            this.chkGroupRead.Text = "Read";
            this.chkGroupRead.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // grbPublic
            // 
            this.grbPublic.Controls.Add(this.chkStickly);
            this.grbPublic.Controls.Add(this.chkPublicExecute);
            this.grbPublic.Controls.Add(this.chkPublicWrite);
            this.grbPublic.Controls.Add(this.chkPublicRead);
            this.grbPublic.Location = new System.Drawing.Point(226, 34);
            this.grbPublic.Name = "grbPublic";
            this.grbPublic.Size = new System.Drawing.Size(103, 99);
            this.grbPublic.TabIndex = 90;
            this.grbPublic.TabStop = false;
            this.grbPublic.Text = "Public";
            // 
            // chkStickly
            // 
            this.chkStickly.AutoSize = true;
            this.chkStickly.Location = new System.Drawing.Point(10, 74);
            this.chkStickly.Name = "chkStickly";
            this.chkStickly.Size = new System.Drawing.Size(57, 17);
            this.chkStickly.TabIndex = 10;
            this.chkStickly.Text = "Stickly";
            this.chkStickly.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkPublicExecute
            // 
            this.chkPublicExecute.AutoSize = true;
            this.chkPublicExecute.Location = new System.Drawing.Point(10, 55);
            this.chkPublicExecute.Name = "chkPublicExecute";
            this.chkPublicExecute.Size = new System.Drawing.Size(65, 17);
            this.chkPublicExecute.TabIndex = 9;
            this.chkPublicExecute.Text = "Execute";
            this.chkPublicExecute.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkPublicWrite
            // 
            this.chkPublicWrite.AutoSize = true;
            this.chkPublicWrite.Location = new System.Drawing.Point(10, 36);
            this.chkPublicWrite.Name = "chkPublicWrite";
            this.chkPublicWrite.Size = new System.Drawing.Size(51, 17);
            this.chkPublicWrite.TabIndex = 8;
            this.chkPublicWrite.Text = "Write";
            this.chkPublicWrite.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkPublicRead
            // 
            this.chkPublicRead.AutoSize = true;
            this.chkPublicRead.Location = new System.Drawing.Point(10, 16);
            this.chkPublicRead.Name = "chkPublicRead";
            this.chkPublicRead.Size = new System.Drawing.Size(52, 17);
            this.chkPublicRead.TabIndex = 7;
            this.chkPublicRead.Text = "Read";
            this.chkPublicRead.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Location = new System.Drawing.Point(8, 139);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(252, 17);
            this.chkRecursive.TabIndex = 10;
            this.chkRecursive.Text = "Apply changes to this folder, subfolders and files";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 2);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(174, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(254, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            // 
            // PropertiesForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(335, 202);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.grbPublic);
            this.Controls.Add(this.grbGroup);
            this.Controls.Add(this.grbUser);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.txtPermissions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.grbUser.ResumeLayout(false);
            this.grbUser.PerformLayout();
            this.grbGroup.ResumeLayout(false);
            this.grbGroup.PerformLayout();
            this.grbPublic.ResumeLayout(false);
            this.grbPublic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUser;
        private System.Windows.Forms.CheckBox chkOwnerExecute;
        private System.Windows.Forms.CheckBox chkOwnerWrite;
        private System.Windows.Forms.CheckBox chkOwnerRead;
        public System.Windows.Forms.TextBox txtPermissions;
        public System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.GroupBox grbGroup;
        private System.Windows.Forms.CheckBox chkGroupExecute;
        private System.Windows.Forms.CheckBox chkGroupWrite;
        private System.Windows.Forms.CheckBox chkGroupRead;
        private System.Windows.Forms.GroupBox grbPublic;
        private System.Windows.Forms.CheckBox chkPublicExecute;
        private System.Windows.Forms.CheckBox chkPublicWrite;
        private System.Windows.Forms.CheckBox chkPublicRead;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkSetUID;
        private System.Windows.Forms.CheckBox chkSetGID;
        private System.Windows.Forms.CheckBox chkStickly;
    }
}