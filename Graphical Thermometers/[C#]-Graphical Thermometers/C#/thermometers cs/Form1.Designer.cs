namespace thermometers_cs
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
            this.NumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDown3
            // 
            this.NumericUpDown3.Location = new System.Drawing.Point(222, 330);
            this.NumericUpDown3.Maximum = new decimal(new int[] {
            220,
            0,
            0,
            0});
            this.NumericUpDown3.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NumericUpDown3.Name = "NumericUpDown3";
            this.NumericUpDown3.Size = new System.Drawing.Size(53, 20);
            this.NumericUpDown3.TabIndex = 11;
            this.NumericUpDown3.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NumericUpDown3.ValueChanged += new System.EventHandler(this.NumericUpDowns_ValueChanged);
            // 
            // NumericUpDown2
            // 
            this.NumericUpDown2.Location = new System.Drawing.Point(130, 330);
            this.NumericUpDown2.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.NumericUpDown2.Name = "NumericUpDown2";
            this.NumericUpDown2.Size = new System.Drawing.Size(53, 20);
            this.NumericUpDown2.TabIndex = 10;
            this.NumericUpDown2.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.NumericUpDown2.ValueChanged += new System.EventHandler(this.NumericUpDowns_ValueChanged);
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.Location = new System.Drawing.Point(46, 330);
            this.NumericUpDown1.Maximum = new decimal(new int[] {
            380,
            0,
            0,
            0});
            this.NumericUpDown1.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.NumericUpDown1.TabIndex = 9;
            this.NumericUpDown1.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NumericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDowns_ValueChanged);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(400, 303);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 8;
            this.PictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 369);
            this.Controls.Add(this.NumericUpDown3);
            this.Controls.Add(this.NumericUpDown2);
            this.Controls.Add(this.NumericUpDown1);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thermometers cs";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown NumericUpDown3;
        internal System.Windows.Forms.NumericUpDown NumericUpDown2;
        internal System.Windows.Forms.NumericUpDown NumericUpDown1;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}

