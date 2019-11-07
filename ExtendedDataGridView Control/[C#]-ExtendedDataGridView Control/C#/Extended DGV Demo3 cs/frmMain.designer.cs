using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace Extended_DGV_Demo3
{
	partial class frmMain : System.Windows.Forms.Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ExtendedDataGridView1 = new ExtendedDataGridView.ExtendedDataGridViewControl();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new ExtendedDataGridView.altDataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ExtendedDataGridView2 = new ExtendedDataGridView.ExtendedDataGridViewControl();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new ExtendedDataGridView.altDataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.ExtendedDataGridView3 = new ExtendedDataGridView.ExtendedDataGridViewControl();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.ExtendedDataGridView4 = new ExtendedDataGridView.ExtendedDataGridViewControl();
            this.TableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView1)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView2)).BeginInit();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView3)).BeginInit();
            this.TabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.TabControl1, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(657, 511);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 7;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.TableLayoutPanel2.Controls.Add(this.Button4, 2, 1);
            this.TableLayoutPanel2.Controls.Add(this.Button3, 3, 1);
            this.TableLayoutPanel2.Controls.Add(this.Button2, 4, 1);
            this.TableLayoutPanel2.Controls.Add(this.Button1, 5, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label1, 1, 1);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 468);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 3;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(651, 40);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // Button4
            // 
            this.Button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button4.Location = new System.Drawing.Point(308, 9);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(94, 22);
            this.Button4.TabIndex = 3;
            this.Button4.Text = "&Check Answers";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button3
            // 
            this.Button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button3.Location = new System.Drawing.Point(408, 9);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(74, 22);
            this.Button3.TabIndex = 2;
            this.Button3.Text = "&SaveAsCSV";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button2
            // 
            this.Button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button2.Location = new System.Drawing.Point(488, 9);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(74, 22);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "&Print";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button1.Location = new System.Drawing.Point(568, 9);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(74, 22);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "P&review";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(9, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(293, 28);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Right-click grid for options...";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Controls.Add(this.TabPage4);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(3, 3);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(651, 459);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += this.TabControl1_SelectedIndexChanged;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ExtendedDataGridView1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage1.Size = new System.Drawing.Size(643, 433);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Example 1";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // ExtendedDataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtendedDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ExtendedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExtendedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.ExtendedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtendedDataGridView1.Location = new System.Drawing.Point(4, 4);
            this.ExtendedDataGridView1.Name = "ExtendedDataGridView1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtendedDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ExtendedDataGridView1.Size = new System.Drawing.Size(635, 425);
            this.ExtendedDataGridView1.TabIndex = 0;
            this.ExtendedDataGridView1.cellCheckedChanged += this.ExtendedDataGridView1_cellCheckedChanged;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Solve";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "x = ?";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderStyle = ExtendedDataGridView.enumerations.style2.CheckAll;
            this.Column3.HeaderText = "Submit";
            this.Column3.Name = "Column3";
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 25;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.ExtendedDataGridView2);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage2.Size = new System.Drawing.Size(643, 433);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Example 2";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // ExtendedDataGridView2
            // 
            this.ExtendedDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExtendedDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7});
            this.ExtendedDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtendedDataGridView2.Location = new System.Drawing.Point(4, 4);
            this.ExtendedDataGridView2.Name = "ExtendedDataGridView2";
            this.ExtendedDataGridView2.Size = new System.Drawing.Size(635, 425);
            this.ExtendedDataGridView2.TabIndex = 1;
            this.ExtendedDataGridView2.CellContentClick += this.ExtendedDataGridView2_CellContentClick;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Value";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 275;
            // 
            // Column6
            // 
            this.Column6.HeaderStyle = ExtendedDataGridView.enumerations.style1.HideColumn;
            this.Column6.HeaderText = "Sum";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Calculate";
            this.Column7.Name = "Column7";
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.ExtendedDataGridView3);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage3.Size = new System.Drawing.Size(643, 433);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Example 3";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // ExtendedDataGridView3
            // 
            this.ExtendedDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExtendedDataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            this.ExtendedDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtendedDataGridView3.Location = new System.Drawing.Point(4, 4);
            this.ExtendedDataGridView3.Name = "ExtendedDataGridView3";
            this.ExtendedDataGridView3.Size = new System.Drawing.Size(635, 425);
            this.ExtendedDataGridView3.TabIndex = 1;
            this.ExtendedDataGridView3.CellContentClick += this.ExtendedDataGridView3_CellContentClick;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Search Engine";
            this.Column8.Name = "Column8";
            this.Column8.Width = 200;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Url";
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 350;
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.ExtendedDataGridView4);
            this.TabPage4.Location = new System.Drawing.Point(4, 22);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage4.Size = new System.Drawing.Size(643, 433);
            this.TabPage4.TabIndex = 3;
            this.TabPage4.Text = "Example 4";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // ExtendedDataGridView4
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ExtendedDataGridView4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ExtendedDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExtendedDataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtendedDataGridView4.Location = new System.Drawing.Point(4, 4);
            this.ExtendedDataGridView4.Name = "ExtendedDataGridView4";
            this.ExtendedDataGridView4.Size = new System.Drawing.Size(635, 425);
            this.ExtendedDataGridView4.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 511);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extended DGV Demo";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView2)).EndInit();
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView3)).EndInit();
            this.TabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExtendedDataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        private TableLayoutPanel TableLayoutPanel1;
        private TableLayoutPanel TableLayoutPanel2;
        private Button Button4;
        private Button Button3;
        private Button Button2;
        private Button Button1;
        private Label Label1;
		private TabControl TabControl1;
        private TabPage TabPage1;
		private ExtendedDataGridView.ExtendedDataGridViewControl ExtendedDataGridView1;
        private TabPage TabPage2;
        private ExtendedDataGridView.ExtendedDataGridViewControl ExtendedDataGridView2;
        private TabPage TabPage3;
        private ExtendedDataGridView.ExtendedDataGridViewControl ExtendedDataGridView3;
        private TabPage TabPage4;
        private ExtendedDataGridView.ExtendedDataGridViewControl ExtendedDataGridView4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewComboBoxColumn Column2;
        private ExtendedDataGridView.altDataGridViewCheckBoxColumn Column3;
        private DataGridViewImageColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private ExtendedDataGridView.altDataGridViewTextBoxColumn Column6;
        private DataGridViewButtonColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewLinkColumn Column9;
	}
}
