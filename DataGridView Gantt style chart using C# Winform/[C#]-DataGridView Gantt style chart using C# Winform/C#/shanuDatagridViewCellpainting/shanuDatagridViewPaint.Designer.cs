namespace shanuDatagridViewCellpainting
{
	partial class shanuDatagridViewPaint
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shanuDatagridViewPaint));
			this.pnlGrid = new System.Windows.Forms.Panel();
			this.pnlFormHeader = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtProjectID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlFormHeader.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlGrid
			// 
			this.pnlGrid.BackColor = System.Drawing.Color.Black;
			this.pnlGrid.BackgroundImage = global::shanuDatagridViewCellpainting.Properties.Resources.form_bg;
			this.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGrid.Location = new System.Drawing.Point(0, 166);
			this.pnlGrid.Name = "pnlGrid";
			this.pnlGrid.Size = new System.Drawing.Size(1586, 661);
			this.pnlGrid.TabIndex = 9;
			// 
			// pnlFormHeader
			// 
			this.pnlFormHeader.BackColor = System.Drawing.Color.Black;
			this.pnlFormHeader.BackgroundImage = global::shanuDatagridViewCellpainting.Properties.Resources.header_bg;
			this.pnlFormHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pnlFormHeader.Controls.Add(this.groupBox1);
			this.pnlFormHeader.Controls.Add(this.label1);
			this.pnlFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFormHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlFormHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlFormHeader.Name = "pnlFormHeader";
			this.pnlFormHeader.Size = new System.Drawing.Size(1586, 166);
			this.pnlFormHeader.TabIndex = 8;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.btnSearch);
			this.groupBox1.Controls.Add(this.txtProjectID);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(285, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(708, 74);
			this.groupBox1.TabIndex = 329;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			// 
			// btnSearch
			// 
			this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
			this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Font = new System.Drawing.Font("Tahoma", 18F);
			this.btnSearch.ForeColor = System.Drawing.Color.White;
			this.btnSearch.Location = new System.Drawing.Point(524, 21);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(170, 40);
			this.btnSearch.TabIndex = 330;
			this.btnSearch.Text = "Search";
			this.btnSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtProjectID
			// 
			this.txtProjectID.Location = new System.Drawing.Point(180, 25);
			this.txtProjectID.Name = "txtProjectID";
			this.txtProjectID.Size = new System.Drawing.Size(326, 32);
			this.txtProjectID.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 25);
			this.label2.TabIndex = 0;
			this.label2.Text = "Project Name : ";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(127, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(989, 50);
			this.label1.TabIndex = 328;
			this.label1.Text = "DatagridView Project Scheduling to Display GANTT Style Chart ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// shanuDatagridViewPaint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImage = global::shanuDatagridViewCellpainting.Properties.Resources.form_bg;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1586, 827);
			this.Controls.Add(this.pnlGrid);
			this.Controls.Add(this.pnlFormHeader);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "shanuDatagridViewPaint";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shanu DatagridView Project Scheduling to Display GANTT Style Chart ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.shanuDatagridViewPaint_Load);
			this.pnlFormHeader.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlGrid;
		private System.Windows.Forms.Panel pnlFormHeader;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtProjectID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

