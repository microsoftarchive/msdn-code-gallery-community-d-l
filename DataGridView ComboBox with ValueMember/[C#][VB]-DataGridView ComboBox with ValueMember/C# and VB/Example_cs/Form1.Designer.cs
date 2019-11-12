namespace Example_cs
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.PersonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorsColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonId,
            this.Column3,
            this.ColorsColumn});
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(354, 178);
            this.DataGridView1.TabIndex = 0;
            // 
            // PersonId
            // 
            this.PersonId.DataPropertyName = "ID";
            this.PersonId.HeaderText = "ID";
            this.PersonId.Name = "PersonId";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FirstName";
            this.Column3.HeaderText = "First Name";
            this.Column3.Name = "Column3";
            // 
            // ColorsColumn
            // 
            this.ColorsColumn.DataPropertyName = "ColorId";
            this.ColorsColumn.HeaderText = "Color";
            this.ColorsColumn.Name = "ColorsColumn";
            this.ColorsColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 178);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(354, 70);
            this.Panel1.TabIndex = 1;
            // 
            // Panel2
            // 
            this.Panel2.Location = new System.Drawing.Point(277, 16);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(65, 42);
            this.Panel2.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(39, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Label2";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 19);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 248);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PersonId;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewComboBoxColumn ColorsColumn;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

