namespace WindowsApplication_cs
{
    partial class SelectImageForm
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
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmdFinished = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new WindowsApplication_cs.Classes.CueTextBox();
            this.SuspendLayout();
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // cmdFinished
            // 
            this.cmdFinished.Location = new System.Drawing.Point(12, 77);
            this.cmdFinished.Name = "cmdFinished";
            this.cmdFinished.Size = new System.Drawing.Size(75, 23);
            this.cmdFinished.TabIndex = 0;
            this.cmdFinished.Text = "Select";
            this.cmdFinished.UseVisualStyleBackColor = true;
            this.cmdFinished.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(220, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File name";
            // 
            // txtDescription
            // 
            this.txtDescription.Cue = "Enter image description";
            this.txtDescription.Location = new System.Drawing.Point(12, 51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(283, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.WaterMarkOption = WindowsApplication_cs.Classes.WaterMark.Hide;
            this.txtDescription.TextChanged += new System.EventHandler(this.cueTextBox1_TextChanged);
            // 
            // SelectImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 121);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmdFinished);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Image";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.Button cmdFinished;
        private Classes.CueTextBox txtDescription;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}