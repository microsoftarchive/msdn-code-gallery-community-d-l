namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.CheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtWorkSheetName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CheckedListBox1
            // 
            this.CheckedListBox1.FormattingEnabled = true;
            this.CheckedListBox1.Location = new System.Drawing.Point(12, 125);
            this.CheckedListBox1.Name = "CheckedListBox1";
            this.CheckedListBox1.Size = new System.Drawing.Size(274, 259);
            this.CheckedListBox1.TabIndex = 2;
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(12, 12);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(274, 108);
            this.ListBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(292, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 397);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "WorkSheet name";
            // 
            // txtWorkSheetName
            // 
            this.txtWorkSheetName.Location = new System.Drawing.Point(15, 413);
            this.txtWorkSheetName.Name = "txtWorkSheetName";
            this.txtWorkSheetName.Size = new System.Drawing.Size(274, 20);
            this.txtWorkSheetName.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 479);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtWorkSheetName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckedListBox1);
            this.Controls.Add(this.ListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckedListBox CheckedListBox1;
        internal System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtWorkSheetName;
    }
}

