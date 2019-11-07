namespace ClientSample
{
    partial class MirrorFolders
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSearchPattern = new System.Windows.Forms.TextBox();
            this.lblPattern = new System.Windows.Forms.Label();
            this.cbxComparisonType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtLocalMaster = new System.Windows.Forms.RadioButton();
            this.rbtRemoteMaster = new System.Windows.Forms.RadioButton();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.chkSyncDateTime = new System.Windows.Forms.CheckBox();
            this.chkResumability = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(194, 173);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "&OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(275, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "&Cancel";
            // 
            // txtSearchPattern
            // 
            this.txtSearchPattern.Location = new System.Drawing.Point(75, 60);
            this.txtSearchPattern.Name = "txtSearchPattern";
            this.txtSearchPattern.Size = new System.Drawing.Size(176, 20);
            this.txtSearchPattern.TabIndex = 2;
            // 
            // lblPattern
            // 
            this.lblPattern.Location = new System.Drawing.Point(11, 63);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(55, 13);
            this.lblPattern.TabIndex = 73;
            this.lblPattern.Text = "File Mask:";
            // 
            // cbxComparisonType
            // 
            this.cbxComparisonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComparisonType.FormattingEnabled = true;
            this.cbxComparisonType.Items.AddRange(new object[] {
            "Date Time",
            "File Content",
            "Name Only"});
            this.cbxComparisonType.Location = new System.Drawing.Point(75, 141);
            this.cbxComparisonType.Name = "cbxComparisonType";
            this.cbxComparisonType.Size = new System.Drawing.Size(176, 21);
            this.cbxComparisonType.TabIndex = 5;
            this.cbxComparisonType.SelectedIndexChanged += new System.EventHandler(this.cbxComparisonType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Compare by:";
            // 
            // rbtLocalMaster
            // 
            this.rbtLocalMaster.Location = new System.Drawing.Point(11, 33);
            this.rbtLocalMaster.Name = "rbtLocalMaster";
            this.rbtLocalMaster.Size = new System.Drawing.Size(148, 21);
            this.rbtLocalMaster.TabIndex = 1;
            this.rbtLocalMaster.Text = "Local Folder is master ";
            // 
            // rbtRemoteMaster
            // 
            this.rbtRemoteMaster.Location = new System.Drawing.Point(11, 8);
            this.rbtRemoteMaster.Name = "rbtRemoteMaster";
            this.rbtRemoteMaster.Size = new System.Drawing.Size(159, 26);
            this.rbtRemoteMaster.TabIndex = 0;
            this.rbtRemoteMaster.Text = "Remote Folder is master ";
            // 
            // chkRecursive
            // 
            this.chkRecursive.Location = new System.Drawing.Point(78, 86);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(74, 26);
            this.chkRecursive.TabIndex = 3;
            this.chkRecursive.Text = "Recursive";
            // 
            // chkSyncDateTime
            // 
            this.chkSyncDateTime.Location = new System.Drawing.Point(78, 105);
            this.chkSyncDateTime.Name = "chkSyncDateTime";
            this.chkSyncDateTime.Size = new System.Drawing.Size(272, 30);
            this.chkSyncDateTime.TabIndex = 4;
            this.chkSyncDateTime.Text = "Synchronize file date time (make sure your PC\'s time zone and Server\'s Time Zone " +
                "are the same)";
            // 
            // chkResumability
            // 
            this.chkResumability.Location = new System.Drawing.Point(11, 169);
            this.chkResumability.Name = "chkResumability";
            this.chkResumability.Size = new System.Drawing.Size(139, 26);
            this.chkResumability.TabIndex = 6;
            this.chkResumability.Text = "Check for resumability";
            // 
            // SynchronizeFolders
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(357, 205);
            this.Controls.Add(this.chkResumability);
            this.Controls.Add(this.chkSyncDateTime);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.txtSearchPattern);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.cbxComparisonType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtLocalMaster);
            this.Controls.Add(this.rbtRemoteMaster);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MirrorFolders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Synchonize files and directories";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSearchPattern;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.ComboBox cbxComparisonType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtLocalMaster;
        private System.Windows.Forms.RadioButton rbtRemoteMaster;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.CheckBox chkSyncDateTime;
        private System.Windows.Forms.CheckBox chkResumability;
    }
}