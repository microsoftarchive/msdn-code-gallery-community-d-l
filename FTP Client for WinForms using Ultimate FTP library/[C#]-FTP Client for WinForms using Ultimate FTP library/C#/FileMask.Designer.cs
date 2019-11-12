namespace ClientSample
{
    partial class FileMask
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
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lbl = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFileType
            // 
            this.txtFileType.Location = new System.Drawing.Point(101, 22);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(238, 20);
            this.txtFileType.TabIndex = 13;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lbl);
            this.groupBox.Location = new System.Drawing.Point(7, 4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(342, 53);
            this.groupBox.TabIndex = 12;
            this.groupBox.TabStop = false;
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(7, 21);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(88, 16);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Specify file type:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(194, 63);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(274, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            // 
            // FileMask
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(355, 94);
            this.Controls.Add(this.txtFileType);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileMask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileType;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}