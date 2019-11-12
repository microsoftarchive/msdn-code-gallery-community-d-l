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
	partial class showColumns : System.Windows.Forms.UserControl
	{

		//UserControl overrides dispose to clean up the component list.
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
            this.ListBox1 = new System.Windows.Forms.ListBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			//ListBox1
			//
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.Location = new System.Drawing.Point(0, 6);
			this.ListBox1.Name = "ListBox1";
			this.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.ListBox1.Size = new System.Drawing.Size(137, 121);
			this.ListBox1.TabIndex = 0;
			//
			//Button1
			//
			this.Button1.Enabled = false;
			this.Button1.Location = new System.Drawing.Point(0, 133);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(137, 23);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Show Selected";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//showColumns
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.ListBox1);
			this.MaximumSize = new System.Drawing.Size(137, 162);
			this.MinimumSize = new System.Drawing.Size(137, 162);
			this.Name = "showColumns";
			this.Size = new System.Drawing.Size(137, 162);
			this.ResumeLayout(false);

            ListBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            Button1.Click += Button1_Click;

        }

        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Button Button1;
	}
}
