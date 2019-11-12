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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdCompanyName = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboFilterOptionsForString = new System.Windows.Forms.ComboBox();
            this.txtCompanyNameFilter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerIdentifier = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.cmdRemoveFilter = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 273);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 218);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdRemoveFilter);
            this.groupBox1.Controls.Add(this.txtCompanyNameFilter);
            this.groupBox1.Controls.Add(this.cboFilterOptionsForString);
            this.groupBox1.Controls.Add(this.cmdCompanyName);
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(341, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company name filter";
            // 
            // cmdCompanyName
            // 
            this.cmdCompanyName.Location = new System.Drawing.Point(210, 31);
            this.cmdCompanyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCompanyName.Name = "cmdCompanyName";
            this.cmdCompanyName.Size = new System.Drawing.Size(123, 28);
            this.cmdCompanyName.TabIndex = 1;
            this.cmdCompanyName.Text = "ApplyFilter";
            this.cmdCompanyName.UseVisualStyleBackColor = true;
            this.cmdCompanyName.Click += new System.EventHandler(this.cmdFilterByColumn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1029, 273);
            this.dataGridView1.TabIndex = 0;
            // 
            // cboFilterOptionsForString
            // 
            this.cboFilterOptionsForString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterOptionsForString.FormattingEnabled = true;
            this.cboFilterOptionsForString.Location = new System.Drawing.Point(7, 59);
            this.cboFilterOptionsForString.Name = "cboFilterOptionsForString";
            this.cboFilterOptionsForString.Size = new System.Drawing.Size(196, 24);
            this.cboFilterOptionsForString.TabIndex = 2;
            // 
            // txtCompanyNameFilter
            // 
            this.txtCompanyNameFilter.Location = new System.Drawing.Point(7, 31);
            this.txtCompanyNameFilter.Name = "txtCompanyNameFilter";
            this.txtCompanyNameFilter.Size = new System.Drawing.Size(196, 22);
            this.txtCompanyNameFilter.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCompanyName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCustomerIdentifier);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(364, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Binding on current row";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identifier";
            // 
            // lblCustomerIdentifier
            // 
            this.lblCustomerIdentifier.AutoSize = true;
            this.lblCustomerIdentifier.Location = new System.Drawing.Point(74, 31);
            this.lblCustomerIdentifier.Name = "lblCustomerIdentifier";
            this.lblCustomerIdentifier.Size = new System.Drawing.Size(40, 17);
            this.lblCustomerIdentifier.TabIndex = 1;
            this.lblCustomerIdentifier.Text = "0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(74, 50);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(54, 17);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "ABCDE";
            // 
            // cmdRemoveFilter
            // 
            this.cmdRemoveFilter.Location = new System.Drawing.Point(210, 59);
            this.cmdRemoveFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRemoveFilter.Name = "cmdRemoveFilter";
            this.cmdRemoveFilter.Size = new System.Drawing.Size(123, 28);
            this.cmdRemoveFilter.TabIndex = 3;
            this.cmdRemoveFilter.Text = "Remove Filter";
            this.cmdRemoveFilter.UseVisualStyleBackColor = true;
            this.cmdRemoveFilter.Click += new System.EventHandler(this.cmdRemoveFilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 491);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Part 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

