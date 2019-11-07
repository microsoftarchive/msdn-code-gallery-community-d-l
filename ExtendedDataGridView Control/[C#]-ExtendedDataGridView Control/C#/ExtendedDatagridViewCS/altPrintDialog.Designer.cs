using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading.Tasks;
namespace ExtendedDataGridView
{
	public partial class altPrintDialog : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(altPrintDialog));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.NumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.NumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.RadioButton2 = new System.Windows.Forms.RadioButton();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.RadioButton4 = new System.Windows.Forms.RadioButton();
            this.RadioButton3 = new System.Windows.Forms.RadioButton();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.NumericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.Label12 = new System.Windows.Forms.Label();
            this.NumericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.Label13 = new System.Windows.Forms.Label();
            this.NumericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.Label11 = new System.Windows.Forms.Label();
            this.NumericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CheckBox1);
            this.GroupBox1.Controls.Add(this.PictureBox1);
            this.GroupBox1.Controls.Add(this.NumericUpDown1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(330, 209);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(226, 109);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Copies";
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Enabled = false;
            this.CheckBox1.Location = new System.Drawing.Point(147, 60);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(58, 17);
            this.CheckBox1.TabIndex = 3;
            this.CheckBox1.Text = "Collate";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(20, 50);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(101, 35);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 2;
            this.PictureBox1.TabStop = false;
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.Location = new System.Drawing.Point(142, 19);
            this.NumericUpDown1.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.Size = new System.Drawing.Size(63, 20);
            this.NumericUpDown1.TabIndex = 1;
            this.NumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            this.NumericUpDown1.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(93, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Number of copies:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.NumericUpDown3);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.NumericUpDown2);
            this.GroupBox2.Controls.Add(this.RadioButton2);
            this.GroupBox2.Controls.Add(this.RadioButton1);
            this.GroupBox2.Location = new System.Drawing.Point(21, 209);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(290, 109);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Print range";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(194, 65);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(16, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "to";
            // 
            // NumericUpDown3
            // 
            this.NumericUpDown3.Location = new System.Drawing.Point(216, 63);
            this.NumericUpDown3.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown3.Name = "NumericUpDown3";
            this.NumericUpDown3.Size = new System.Drawing.Size(50, 20);
            this.NumericUpDown3.TabIndex = 4;
            this.NumericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown3.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            this.NumericUpDown3.ValueChanged += new System.EventHandler(this.NumericUpDown3_ValueChanged);
            this.NumericUpDown3.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(94, 65);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(27, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "from";
            // 
            // NumericUpDown2
            // 
            this.NumericUpDown2.Location = new System.Drawing.Point(127, 63);
            this.NumericUpDown2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown2.Name = "NumericUpDown2";
            this.NumericUpDown2.Size = new System.Drawing.Size(50, 20);
            this.NumericUpDown2.TabIndex = 2;
            this.NumericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown2.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            this.NumericUpDown2.ValueChanged += new System.EventHandler(this.NumericUpDown2_ValueChanged);
            this.NumericUpDown2.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            // 
            // RadioButton2
            // 
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new System.Drawing.Point(21, 63);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new System.Drawing.Size(55, 17);
            this.RadioButton2.TabIndex = 1;
            this.RadioButton2.Text = "Pages";
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.RadioButton2.CheckedChanged += new System.EventHandler(this.RadioButtonsPageSelection_CheckedChanged);
            // 
            // RadioButton1
            // 
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            this.RadioButton1.Location = new System.Drawing.Point(21, 35);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(36, 17);
            this.RadioButton1.TabIndex = 0;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "All";
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton1.CheckedChanged += new System.EventHandler(this.RadioButtonsPageSelection_CheckedChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.RadioButton4);
            this.GroupBox3.Controls.Add(this.RadioButton3);
            this.GroupBox3.Controls.Add(this.PictureBox2);
            this.GroupBox3.Location = new System.Drawing.Point(330, 12);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(226, 87);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Orientation";
            // 
            // RadioButton4
            // 
            this.RadioButton4.AutoSize = true;
            this.RadioButton4.Location = new System.Drawing.Point(73, 57);
            this.RadioButton4.Name = "RadioButton4";
            this.RadioButton4.Size = new System.Drawing.Size(78, 17);
            this.RadioButton4.TabIndex = 2;
            this.RadioButton4.Text = "Landscape";
            this.RadioButton4.UseVisualStyleBackColor = true;
            this.RadioButton4.CheckedChanged += new System.EventHandler(this.RadioButtonsOrientation_CheckedChanged);
            // 
            // RadioButton3
            // 
            this.RadioButton3.AutoSize = true;
            this.RadioButton3.Checked = true;
            this.RadioButton3.Location = new System.Drawing.Point(73, 30);
            this.RadioButton3.Name = "RadioButton3";
            this.RadioButton3.Size = new System.Drawing.Size(58, 17);
            this.RadioButton3.TabIndex = 1;
            this.RadioButton3.TabStop = true;
            this.RadioButton3.Text = "Portrait";
            this.RadioButton3.UseVisualStyleBackColor = true;
            this.RadioButton3.CheckedChanged += new System.EventHandler(this.RadioButtonsOrientation_CheckedChanged);
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(21, 21);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(37, 57);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox2.TabIndex = 0;
            this.PictureBox2.TabStop = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Label14);
            this.GroupBox4.Controls.Add(this.Label9);
            this.GroupBox4.Controls.Add(this.Label8);
            this.GroupBox4.Controls.Add(this.Label7);
            this.GroupBox4.Controls.Add(this.Label6);
            this.GroupBox4.Controls.Add(this.Label5);
            this.GroupBox4.Controls.Add(this.Label4);
            this.GroupBox4.Controls.Add(this.ComboBox1);
            this.GroupBox4.Location = new System.Drawing.Point(21, 12);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(290, 191);
            this.GroupBox4.TabIndex = 4;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Printer";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(18, 132);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(54, 13);
            this.Label14.TabIndex = 11;
            this.Label14.Text = "Comment:";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(81, 110);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(0, 13);
            this.Label9.TabIndex = 10;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(81, 87);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(0, 13);
            this.Label8.TabIndex = 9;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(81, 64);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(0, 13);
            this.Label7.TabIndex = 8;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(18, 110);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 13);
            this.Label6.TabIndex = 7;
            this.Label6.Text = "Where:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(18, 87);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(34, 13);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "Type:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(18, 64);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(40, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Status:";
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(21, 29);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(245, 21);
            this.ComboBox1.TabIndex = 4;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Button1
            // 
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button1.Location = new System.Drawing.Point(397, 341);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "&OK";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button2.Location = new System.Drawing.Point(481, 341);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 6;
            this.Button2.Text = "&Cancel";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.NumericUpDown7);
            this.GroupBox5.Controls.Add(this.Label12);
            this.GroupBox5.Controls.Add(this.NumericUpDown6);
            this.GroupBox5.Controls.Add(this.Label13);
            this.GroupBox5.Controls.Add(this.NumericUpDown5);
            this.GroupBox5.Controls.Add(this.Label11);
            this.GroupBox5.Controls.Add(this.NumericUpDown4);
            this.GroupBox5.Controls.Add(this.Label10);
            this.GroupBox5.Location = new System.Drawing.Point(330, 105);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(226, 98);
            this.GroupBox5.TabIndex = 7;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Margins";
            // 
            // NumericUpDown7
            // 
            this.NumericUpDown7.Location = new System.Drawing.Point(154, 53);
            this.NumericUpDown7.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NumericUpDown7.Name = "NumericUpDown7";
            this.NumericUpDown7.Size = new System.Drawing.Size(51, 20);
            this.NumericUpDown7.TabIndex = 7;
            this.NumericUpDown7.ValueChanged += new System.EventHandler(this.NumericUpDown7_ValueChanged);
            this.NumericUpDown7.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(116, 55);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(40, 13);
            this.Label12.TabIndex = 6;
            this.Label12.Text = "Bottom";
            // 
            // NumericUpDown6
            // 
            this.NumericUpDown6.Location = new System.Drawing.Point(154, 27);
            this.NumericUpDown6.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NumericUpDown6.Name = "NumericUpDown6";
            this.NumericUpDown6.Size = new System.Drawing.Size(51, 20);
            this.NumericUpDown6.TabIndex = 5;
            this.NumericUpDown6.ValueChanged += new System.EventHandler(this.NumericUpDown6_ValueChanged);
            this.NumericUpDown6.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(116, 29);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(26, 13);
            this.Label13.TabIndex = 4;
            this.Label13.Text = "Top";
            // 
            // NumericUpDown5
            // 
            this.NumericUpDown5.Location = new System.Drawing.Point(56, 53);
            this.NumericUpDown5.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NumericUpDown5.Name = "NumericUpDown5";
            this.NumericUpDown5.Size = new System.Drawing.Size(51, 20);
            this.NumericUpDown5.TabIndex = 3;
            this.NumericUpDown5.ValueChanged += new System.EventHandler(this.NumericUpDown5_ValueChanged);
            this.NumericUpDown5.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(18, 55);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(32, 13);
            this.Label11.TabIndex = 2;
            this.Label11.Text = "Right";
            // 
            // NumericUpDown4
            // 
            this.NumericUpDown4.Location = new System.Drawing.Point(56, 27);
            this.NumericUpDown4.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NumericUpDown4.Name = "NumericUpDown4";
            this.NumericUpDown4.Size = new System.Drawing.Size(51, 20);
            this.NumericUpDown4.TabIndex = 1;
            this.NumericUpDown4.ValueChanged += new System.EventHandler(this.NumericUpDown4_ValueChanged);
            this.NumericUpDown4.TextChanged += new System.EventHandler(this.NumericUpDowns_TextChanged);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(18, 29);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(25, 13);
            this.Label10.TabIndex = 0;
            this.Label10.Text = "Left";
            // 
            // altPrintDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 376);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "altPrintDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown4)).EndInit();
            this.ResumeLayout(false);

        }

        private GroupBox GroupBox1;
		private NumericUpDown NumericUpDown1;
        private Label Label1;
        private PictureBox PictureBox1;
        private CheckBox CheckBox1;
        private GroupBox GroupBox2;
        private Label Label3;
        private NumericUpDown NumericUpDown3;
        private Label Label2;
        private NumericUpDown NumericUpDown2;
        private RadioButton RadioButton2;
        private RadioButton RadioButton1;
        private GroupBox GroupBox3;
        private RadioButton RadioButton4;
		private RadioButton RadioButton3;
        private PictureBox PictureBox2;
        private GroupBox GroupBox4;
        private Label Label6;
        private Label Label5;
        private Label Label4;
        private ComboBox ComboBox1;
        private Button Button1;
        private Button Button2;
        private Label Label9;
        private Label Label8;
        private Label Label7;
        private GroupBox GroupBox5;
        private Label Label12;
        private NumericUpDown NumericUpDown6;
        private Label Label13;
        private NumericUpDown NumericUpDown5;
        private Label Label11;
        private NumericUpDown NumericUpDown4;
        private Label Label10;
		private NumericUpDown NumericUpDown7;
        private Label Label14;
	}
}
