namespace DatagridViewCRUD
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.pnlGrid = new System.Windows.Forms.Panel();
			this.pnlmain = new System.Windows.Forms.Panel();
			this.pnlSearchHeader = new System.Windows.Forms.Panel();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSearch = new System.Windows.Forms.Button();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.btnStaffAdd = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnlmain.SuspendLayout();
			this.pnlSearchHeader.SuspendLayout();
			this.pnlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlGrid
			// 
			this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGrid.Location = new System.Drawing.Point(0, 140);
			this.pnlGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlGrid.Name = "pnlGrid";
			this.pnlGrid.Size = new System.Drawing.Size(1148, 542);
			this.pnlGrid.TabIndex = 16;
			// 
			// pnlmain
			// 
			this.pnlmain.Controls.Add(this.pnlGrid);
			this.pnlmain.Controls.Add(this.pnlSearchHeader);
			this.pnlmain.Controls.Add(this.pnlTop);
			this.pnlmain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlmain.Location = new System.Drawing.Point(0, 0);
			this.pnlmain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlmain.Name = "pnlmain";
			this.pnlmain.Size = new System.Drawing.Size(1148, 682);
			this.pnlmain.TabIndex = 17;
			// 
			// pnlSearchHeader
			// 
			this.pnlSearchHeader.Controls.Add(this.btnStaffAdd);
			this.pnlSearchHeader.Controls.Add(this.txtName);
			this.pnlSearchHeader.Controls.Add(this.label3);
			this.pnlSearchHeader.Controls.Add(this.btnSearch);
			this.pnlSearchHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlSearchHeader.Location = new System.Drawing.Point(0, 60);
			this.pnlSearchHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlSearchHeader.Name = "pnlSearchHeader";
			this.pnlSearchHeader.Size = new System.Drawing.Size(1148, 80);
			this.pnlSearchHeader.TabIndex = 15;
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.txtName.Location = new System.Drawing.Point(110, 30);
			this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtName.MaxLength = 100;
			this.txtName.Multiline = true;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(274, 25);
			this.txtName.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(32, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Name";
			// 
			// btnSearch
			// 
			this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(176)))), ((int)(((byte)(30)))));
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnSearch.ForeColor = System.Drawing.Color.White;
			this.btnSearch.Location = new System.Drawing.Point(402, 16);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(128, 50);
			this.btnSearch.TabIndex = 4;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(158)))), ((int)(((byte)(204)))));
			this.pnlTop.Controls.Add(this.label4);
			this.pnlTop.Controls.Add(this.pictureBox1);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(1148, 60);
			this.pnlTop.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(82, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(181, 24);
			this.label4.TabIndex = 20;
			this.label4.Text = "Student Details";
			// 
			// btnStaffAdd
			// 
			this.btnStaffAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(176)))), ((int)(((byte)(30)))));
			this.btnStaffAdd.FlatAppearance.BorderSize = 0;
			this.btnStaffAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStaffAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnStaffAdd.ForeColor = System.Drawing.Color.White;
			this.btnStaffAdd.Image = global::DatagridViewCRUD.Properties.Resources.Student_3_64;
			this.btnStaffAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStaffAdd.Location = new System.Drawing.Point(576, 18);
			this.btnStaffAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnStaffAdd.Name = "btnStaffAdd";
			this.btnStaffAdd.Size = new System.Drawing.Size(186, 50);
			this.btnStaffAdd.TabIndex = 7;
			this.btnStaffAdd.Text = "Add Student";
			this.btnStaffAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnStaffAdd.UseVisualStyleBackColor = false;
			this.btnStaffAdd.Click += new System.EventHandler(this.btnStaffAdd_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::DatagridViewCRUD.Properties.Resources.Student_3_64;
			this.pictureBox1.Location = new System.Drawing.Point(18, 10);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(41, 45);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1148, 682);
			this.Controls.Add(this.pnlmain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "SHANU Student Info CRUD Sample";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnlmain.ResumeLayout(false);
			this.pnlSearchHeader.ResumeLayout(false);
			this.pnlSearchHeader.PerformLayout();
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlGrid;
		private System.Windows.Forms.Button btnStaffAdd;
		private System.Windows.Forms.Panel pnlmain;
		private System.Windows.Forms.Panel pnlSearchHeader;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

