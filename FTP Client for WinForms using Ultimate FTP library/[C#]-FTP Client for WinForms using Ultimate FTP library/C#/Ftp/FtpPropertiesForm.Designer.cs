namespace ClientSample.Ftp
{
    partial class FtpPropertiesForm
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
            this.chkOwnerExecute = new System.Windows.Forms.CheckBox();
            this.chkOwnerWrite = new System.Windows.Forms.CheckBox();
            this.chkOwnerRead = new System.Windows.Forms.CheckBox();
            this.grbGroup = new System.Windows.Forms.GroupBox();
            this.chkGroupExecute = new System.Windows.Forms.CheckBox();
            this.chkGroupWrite = new System.Windows.Forms.CheckBox();
            this.chkGroupRead = new System.Windows.Forms.CheckBox();
            this.grbPublic = new System.Windows.Forms.GroupBox();
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
            this.grbUser.Controls.Add(this.chkOwnerExecute);
            this.grbUser.Controls.Add(this.chkOwnerWrite);
            this.grbUser.Controls.Add(this.chkOwnerRead);
            this.grbUser.Location = new System.Drawing.Point(8, 4);
            this.grbUser.Name = "grbUser";
            this.grbUser.Size = new System.Drawing.Size(103, 80);
            this.grbUser.TabIndex = 87;
            this.grbUser.TabStop = false;
            this.grbUser.Text = "Owner";
            // 
            // chkOwnerExecute
            // 
            this.chkOwnerExecute.Location = new System.Drawing.Point(10, 55);
            this.chkOwnerExecute.Name = "chkOwnerExecute";
            this.chkOwnerExecute.Size = new System.Drawing.Size(65, 20);
            this.chkOwnerExecute.TabIndex = 3;
            this.chkOwnerExecute.Text = "Execute";
            this.chkOwnerExecute.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkOwnerWrite
            // 
            this.chkOwnerWrite.Location = new System.Drawing.Point(10, 36);
            this.chkOwnerWrite.Name = "chkOwnerWrite";
            this.chkOwnerWrite.Size = new System.Drawing.Size(51, 20);
            this.chkOwnerWrite.TabIndex = 2;
            this.chkOwnerWrite.Text = "Write";
            this.chkOwnerWrite.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkOwnerRead
            // 
            this.chkOwnerRead.Location = new System.Drawing.Point(10, 16);
            this.chkOwnerRead.Name = "chkOwnerRead";
            this.chkOwnerRead.Size = new System.Drawing.Size(52, 20);
            this.chkOwnerRead.TabIndex = 1;
            this.chkOwnerRead.Text = "Read";
            this.chkOwnerRead.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // grbGroup
            // 
            this.grbGroup.Controls.Add(this.chkGroupExecute);
            this.grbGroup.Controls.Add(this.chkGroupWrite);
            this.grbGroup.Controls.Add(this.chkGroupRead);
            this.grbGroup.Location = new System.Drawing.Point(117, 4);
            this.grbGroup.Name = "grbGroup";
            this.grbGroup.Size = new System.Drawing.Size(103, 80);
            this.grbGroup.TabIndex = 89;
            this.grbGroup.TabStop = false;
            this.grbGroup.Text = "Group";
            // 
            // chkGroupExecute
            // 
            this.chkGroupExecute.Location = new System.Drawing.Point(10, 55);
            this.chkGroupExecute.Name = "chkGroupExecute";
            this.chkGroupExecute.Size = new System.Drawing.Size(65, 20);
            this.chkGroupExecute.TabIndex = 6;
            this.chkGroupExecute.Text = "Execute";
            this.chkGroupExecute.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkGroupWrite
            // 
            this.chkGroupWrite.Location = new System.Drawing.Point(10, 36);
            this.chkGroupWrite.Name = "chkGroupWrite";
            this.chkGroupWrite.Size = new System.Drawing.Size(51, 20);
            this.chkGroupWrite.TabIndex = 5;
            this.chkGroupWrite.Text = "Write";
            this.chkGroupWrite.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkGroupRead
            // 
            this.chkGroupRead.Location = new System.Drawing.Point(10, 16);
            this.chkGroupRead.Name = "chkGroupRead";
            this.chkGroupRead.Size = new System.Drawing.Size(52, 20);
            this.chkGroupRead.TabIndex = 4;
            this.chkGroupRead.Text = "Read";
            this.chkGroupRead.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // grbPublic
            // 
            this.grbPublic.Controls.Add(this.chkPublicExecute);
            this.grbPublic.Controls.Add(this.chkPublicWrite);
            this.grbPublic.Controls.Add(this.chkPublicRead);
            this.grbPublic.Location = new System.Drawing.Point(226, 4);
            this.grbPublic.Name = "grbPublic";
            this.grbPublic.Size = new System.Drawing.Size(103, 80);
            this.grbPublic.TabIndex = 90;
            this.grbPublic.TabStop = false;
            this.grbPublic.Text = "Public";
            // 
            // chkPublicExecute
            // 
            this.chkPublicExecute.Location = new System.Drawing.Point(10, 55);
            this.chkPublicExecute.Name = "chkPublicExecute";
            this.chkPublicExecute.Size = new System.Drawing.Size(65, 20);
            this.chkPublicExecute.TabIndex = 9;
            this.chkPublicExecute.Text = "Execute";
            this.chkPublicExecute.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkPublicWrite
            // 
            this.chkPublicWrite.Location = new System.Drawing.Point(10, 36);
            this.chkPublicWrite.Name = "chkPublicWrite";
            this.chkPublicWrite.Size = new System.Drawing.Size(51, 20);
            this.chkPublicWrite.TabIndex = 8;
            this.chkPublicWrite.Text = "Write";
            this.chkPublicWrite.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkPublicRead
            // 
            this.chkPublicRead.Location = new System.Drawing.Point(10, 16);
            this.chkPublicRead.Name = "chkPublicRead";
            this.chkPublicRead.Size = new System.Drawing.Size(52, 20);
            this.chkPublicRead.TabIndex = 7;
            this.chkPublicRead.Text = "Read";
            this.chkPublicRead.CheckedChanged += new System.EventHandler(this.checkBoxes_CheckedChanged);
            // 
            // chkRecursive
            // 
            this.chkRecursive.Location = new System.Drawing.Point(9, 88);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(252, 20);
            this.chkRecursive.TabIndex = 10;
            this.chkRecursive.Text = "Apply changes to this folder, subfolders and files";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 2);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(174, 121);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(254, 121);
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
            this.ClientSize = new System.Drawing.Size(335, 152);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.grbPublic);
            this.Controls.Add(this.grbGroup);
            this.Controls.Add(this.grbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.grbUser.ResumeLayout(false);
            this.grbGroup.ResumeLayout(false);
            this.grbPublic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUser;
        private System.Windows.Forms.CheckBox chkOwnerExecute;
        private System.Windows.Forms.CheckBox chkOwnerWrite;
        private System.Windows.Forms.CheckBox chkOwnerRead;
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
    }
}