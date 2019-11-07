namespace Example1_cs
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdRemoveCurrent = new System.Windows.Forms.Button();
            this.cmdAddNew = new System.Windows.Forms.Button();
            this.cmdEditCurrent = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerIdentifier = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdRemoveFilter = new System.Windows.Forms.Button();
            this.txtCompanyNameFilter = new System.Windows.Forms.TextBox();
            this.cboFilterOptionsForString = new System.Windows.Forms.ComboBox();
            this.cmdCompanyName = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdRemoveCurrent);
            this.panel1.Controls.Add(this.cmdAddNew);
            this.panel1.Controls.Add(this.cmdEditCurrent);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 268);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 127);
            this.panel1.TabIndex = 1;
            // 
            // cmdRemoveCurrent
            // 
            this.cmdRemoveCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoveCurrent.Location = new System.Drawing.Point(621, 83);
            this.cmdRemoveCurrent.Name = "cmdRemoveCurrent";
            this.cmdRemoveCurrent.Size = new System.Drawing.Size(139, 23);
            this.cmdRemoveCurrent.TabIndex = 4;
            this.cmdRemoveCurrent.Text = "Remove current";
            this.cmdRemoveCurrent.UseVisualStyleBackColor = true;
            this.cmdRemoveCurrent.Click += new System.EventHandler(this.cmdRemoveCurrent_Click);
            // 
            // cmdAddNew
            // 
            this.cmdAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddNew.Location = new System.Drawing.Point(621, 47);
            this.cmdAddNew.Name = "cmdAddNew";
            this.cmdAddNew.Size = new System.Drawing.Size(139, 23);
            this.cmdAddNew.TabIndex = 3;
            this.cmdAddNew.Text = "Add new";
            this.cmdAddNew.UseVisualStyleBackColor = true;
            this.cmdAddNew.Click += new System.EventHandler(this.cmdAddNew_Click);
            // 
            // cmdEditCurrent
            // 
            this.cmdEditCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditCurrent.Location = new System.Drawing.Point(621, 11);
            this.cmdEditCurrent.Name = "cmdEditCurrent";
            this.cmdEditCurrent.Size = new System.Drawing.Size(139, 23);
            this.cmdEditCurrent.TabIndex = 2;
            this.cmdEditCurrent.Text = "Edit current";
            this.cmdEditCurrent.UseVisualStyleBackColor = true;
            this.cmdEditCurrent.Click += new System.EventHandler(this.cmdEditCurrent_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCompanyName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCustomerIdentifier);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(273, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(206, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Binding on current row";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(56, 41);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(43, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "ABCDE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // lblCustomerIdentifier
            // 
            this.lblCustomerIdentifier.AutoSize = true;
            this.lblCustomerIdentifier.Location = new System.Drawing.Point(56, 25);
            this.lblCustomerIdentifier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerIdentifier.Name = "lblCustomerIdentifier";
            this.lblCustomerIdentifier.Size = new System.Drawing.Size(31, 13);
            this.lblCustomerIdentifier.TabIndex = 1;
            this.lblCustomerIdentifier.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identifier";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdRemoveFilter);
            this.groupBox1.Controls.Add(this.txtCompanyNameFilter);
            this.groupBox1.Controls.Add(this.cboFilterOptionsForString);
            this.groupBox1.Controls.Add(this.cmdCompanyName);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company name filter";
            // 
            // cmdRemoveFilter
            // 
            this.cmdRemoveFilter.Location = new System.Drawing.Point(158, 48);
            this.cmdRemoveFilter.Name = "cmdRemoveFilter";
            this.cmdRemoveFilter.Size = new System.Drawing.Size(92, 23);
            this.cmdRemoveFilter.TabIndex = 3;
            this.cmdRemoveFilter.Text = "Remove Filter";
            this.cmdRemoveFilter.UseVisualStyleBackColor = true;
            this.cmdRemoveFilter.Click += new System.EventHandler(this.cmdRemoveFilter_Click);
            // 
            // txtCompanyNameFilter
            // 
            this.txtCompanyNameFilter.Location = new System.Drawing.Point(5, 25);
            this.txtCompanyNameFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompanyNameFilter.Name = "txtCompanyNameFilter";
            this.txtCompanyNameFilter.Size = new System.Drawing.Size(148, 20);
            this.txtCompanyNameFilter.TabIndex = 0;
            // 
            // cboFilterOptionsForString
            // 
            this.cboFilterOptionsForString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterOptionsForString.FormattingEnabled = true;
            this.cboFilterOptionsForString.Location = new System.Drawing.Point(5, 48);
            this.cboFilterOptionsForString.Margin = new System.Windows.Forms.Padding(2);
            this.cboFilterOptionsForString.Name = "cboFilterOptionsForString";
            this.cboFilterOptionsForString.Size = new System.Drawing.Size(148, 21);
            this.cboFilterOptionsForString.TabIndex = 2;
            // 
            // cmdCompanyName
            // 
            this.cmdCompanyName.Location = new System.Drawing.Point(158, 25);
            this.cmdCompanyName.Name = "cmdCompanyName";
            this.cmdCompanyName.Size = new System.Drawing.Size(92, 23);
            this.cmdCompanyName.TabIndex = 1;
            this.cmdCompanyName.Text = "ApplyFilter";
            this.cmdCompanyName.UseVisualStyleBackColor = true;
            this.cmdCompanyName.Click += new System.EventHandler(this.cmdFilterByColumn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(772, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 395);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Part 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdCompanyName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboFilterOptionsForString;
        private System.Windows.Forms.TextBox txtCompanyNameFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCustomerIdentifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdRemoveFilter;
        private System.Windows.Forms.Button cmdEditCurrent;
        private System.Windows.Forms.Button cmdAddNew;
        private System.Windows.Forms.Button cmdRemoveCurrent;
    }
}

