namespace SyncApplication
{
    partial class NewSqlPeerCreationWizard
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
            this.serverNameLbl = new System.Windows.Forms.Label();
            this.serverNameTxtBox = new System.Windows.Forms.TextBox();
            this.dbNameTxtBox = new System.Windows.Forms.TextBox();
            this.dbNamelbl = new System.Windows.Forms.Label();
            this.userNameTxtBox = new System.Windows.Forms.TextBox();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.testConnBtn = new System.Windows.Forms.Button();
            this.trustedConnChkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // serverNameLbl
            // 
            this.serverNameLbl.AutoSize = true;
            this.serverNameLbl.Location = new System.Drawing.Point(41, 21);
            this.serverNameLbl.Name = "serverNameLbl";
            this.serverNameLbl.Size = new System.Drawing.Size(72, 13);
            this.serverNameLbl.TabIndex = 0;
            this.serverNameLbl.Text = "Server Name:";
            // 
            // serverNameTxtBox
            // 
            this.serverNameTxtBox.Location = new System.Drawing.Point(135, 17);
            this.serverNameTxtBox.Name = "serverNameTxtBox";
            this.serverNameTxtBox.Size = new System.Drawing.Size(189, 20);
            this.serverNameTxtBox.TabIndex = 1;
            // 
            // dbNameTxtBox
            // 
            this.dbNameTxtBox.Location = new System.Drawing.Point(135, 54);
            this.dbNameTxtBox.Name = "dbNameTxtBox";
            this.dbNameTxtBox.Size = new System.Drawing.Size(189, 20);
            this.dbNameTxtBox.TabIndex = 3;
            // 
            // dbNamelbl
            // 
            this.dbNamelbl.AutoSize = true;
            this.dbNamelbl.Location = new System.Drawing.Point(41, 58);
            this.dbNamelbl.Name = "dbNamelbl";
            this.dbNamelbl.Size = new System.Drawing.Size(87, 13);
            this.dbNamelbl.TabIndex = 2;
            this.dbNamelbl.Text = "Database Name:";
            // 
            // userNameTxtBox
            // 
            this.userNameTxtBox.Enabled = false;
            this.userNameTxtBox.Location = new System.Drawing.Point(135, 125);
            this.userNameTxtBox.Name = "userNameTxtBox";
            this.userNameTxtBox.Size = new System.Drawing.Size(189, 20);
            this.userNameTxtBox.TabIndex = 6;
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Enabled = false;
            this.userNameLbl.Location = new System.Drawing.Point(41, 128);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(63, 13);
            this.userNameLbl.TabIndex = 5;
            this.userNameLbl.Text = "User Name:";
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.Enabled = false;
            this.passwordTxtBox.Location = new System.Drawing.Point(135, 163);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.Size = new System.Drawing.Size(189, 20);
            this.passwordTxtBox.TabIndex = 8;
            this.passwordTxtBox.UseSystemPasswordChar = true;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Enabled = false;
            this.passwordLbl.Location = new System.Drawing.Point(41, 167);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(56, 13);
            this.passwordLbl.TabIndex = 7;
            this.passwordLbl.Text = "Password:";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(250, 213);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(74, 26);
            this.okBtn.TabIndex = 9;
            this.okBtn.Text = "&OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(170, 213);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(74, 26);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // testConnBtn
            // 
            this.testConnBtn.Location = new System.Drawing.Point(44, 213);
            this.testConnBtn.Name = "testConnBtn";
            this.testConnBtn.Size = new System.Drawing.Size(120, 26);
            this.testConnBtn.TabIndex = 11;
            this.testConnBtn.Text = "&Test Connection";
            this.testConnBtn.UseVisualStyleBackColor = true;
            this.testConnBtn.Click += new System.EventHandler(this.testConnBtn_Click);
            // 
            // trustedConnChkBox
            // 
            this.trustedConnChkBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.trustedConnChkBox.AutoSize = true;
            this.trustedConnChkBox.Checked = true;
            this.trustedConnChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trustedConnChkBox.Location = new System.Drawing.Point(44, 91);
            this.trustedConnChkBox.Name = "trustedConnChkBox";
            this.trustedConnChkBox.Size = new System.Drawing.Size(202, 17);
            this.trustedConnChkBox.TabIndex = 12;
            this.trustedConnChkBox.Text = "Use Windows NT Integrated Security";
            this.trustedConnChkBox.UseVisualStyleBackColor = true;
            this.trustedConnChkBox.CheckedChanged += new System.EventHandler(this.trustedConnChkBox_CheckedChanged);
            // 
            // NewSqlPeerCreationWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 264);
            this.Controls.Add(this.trustedConnChkBox);
            this.Controls.Add(this.testConnBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.passwordTxtBox);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.userNameTxtBox);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.dbNameTxtBox);
            this.Controls.Add(this.dbNamelbl);
            this.Controls.Add(this.serverNameTxtBox);
            this.Controls.Add(this.serverNameLbl);
            this.Name = "NewSqlPeerCreationWizard";
            this.Text = "New Peer Creation Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serverNameLbl;
        private System.Windows.Forms.TextBox serverNameTxtBox;
        private System.Windows.Forms.TextBox dbNameTxtBox;
        private System.Windows.Forms.Label dbNamelbl;
        private System.Windows.Forms.TextBox userNameTxtBox;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button testConnBtn;
        private System.Windows.Forms.CheckBox trustedConnChkBox;
    }
}