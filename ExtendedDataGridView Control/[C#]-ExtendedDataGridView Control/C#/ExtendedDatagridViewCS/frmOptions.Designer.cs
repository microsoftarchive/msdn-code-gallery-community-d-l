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

	partial class frmOptions : System.Windows.Forms.Form
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
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
			this.CheckBox2 = new System.Windows.Forms.CheckBox();
			this.CheckBox3 = new System.Windows.Forms.CheckBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			//CheckBox1
			//
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new System.Drawing.Point(23, 26);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new System.Drawing.Size(142, 17);
			this.CheckBox1.TabIndex = 0;
			this.CheckBox1.Text = "&Include Column Headers";
			this.CheckBox1.UseVisualStyleBackColor = true;
			//
			//CheckBox2
			//
			this.CheckBox2.AutoSize = true;
			this.CheckBox2.Location = new System.Drawing.Point(23, 49);
			this.CheckBox2.Name = "CheckBox2";
			this.CheckBox2.Size = new System.Drawing.Size(129, 17);
			this.CheckBox2.TabIndex = 1;
			this.CheckBox2.Text = "Include &Row Headers";
			this.CheckBox2.UseVisualStyleBackColor = true;
			//
			//CheckBox3
			//
			this.CheckBox3.AutoSize = true;
			this.CheckBox3.Location = new System.Drawing.Point(23, 72);
			this.CheckBox3.Name = "CheckBox3";
			this.CheckBox3.Size = new System.Drawing.Size(141, 17);
			this.CheckBox3.TabIndex = 2;
			this.CheckBox3.Text = "Include &Hidden Columns";
			this.CheckBox3.UseVisualStyleBackColor = true;
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(23, 109);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 3;
			this.Button1.Text = "Save";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(104, 109);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 4;
			this.Button2.Text = "&Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//frmOptions
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 151);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.CheckBox3);
			this.Controls.Add(this.CheckBox2);
			this.Controls.Add(this.CheckBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save Options";
			this.ResumeLayout(false);
			this.PerformLayout();

            Button1.Click += Button1_Click;
            Button2.Click += Button2_Click;

        }

        private CheckBox CheckBox1;
        private CheckBox CheckBox2;
        private CheckBox CheckBox3;
        private Button Button1;
        private Button Button2;
	}
}
