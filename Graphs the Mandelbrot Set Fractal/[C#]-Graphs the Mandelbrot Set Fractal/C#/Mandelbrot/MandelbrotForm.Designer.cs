namespace Mandelbrot
{
    partial class MandelbrotForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 408);
            this.panel1.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(604, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "pixels";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Draw";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(700, 218);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(56, 20);
            this.textBox6.TabIndex = 19;
            this.textBox6.Text = "220";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(700, 178);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(56, 20);
            this.textBox5.TabIndex = 18;
            this.textBox5.Text = "100";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(700, 138);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(56, 20);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "0.01";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(700, 98);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(56, 20);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "0.00";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(700, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "0.27";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(700, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "0.26";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(604, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "x maximum";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(604, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "y minimum";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(604, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "iterations";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(604, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "x minimum";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(604, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 24;
            this.label11.Text = "y maximum";
            // 
            // MandelbrotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MandelbrotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mandelbrot Set James Pate Williams, Jr. (c) 2008";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

