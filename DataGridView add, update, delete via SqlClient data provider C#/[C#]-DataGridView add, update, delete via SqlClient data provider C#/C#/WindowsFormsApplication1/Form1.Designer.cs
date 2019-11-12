namespace WindowsFormsApplication1
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmdEditCurrentRow = new System.Windows.Forms.Button();
            this.cmdDeleteCurrentRow = new System.Windows.Forms.Button();
            this.cmdAddNewRow = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmdEditCurrentRow);
            this.Panel1.Controls.Add(this.cmdDeleteCurrentRow);
            this.Panel1.Controls.Add(this.cmdAddNewRow);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 279);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(558, 49);
            this.Panel1.TabIndex = 3;
            // 
            // cmdEditCurrentRow
            // 
            this.cmdEditCurrentRow.Location = new System.Drawing.Point(397, 7);
            this.cmdEditCurrentRow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdEditCurrentRow.Name = "cmdEditCurrentRow";
            this.cmdEditCurrentRow.Size = new System.Drawing.Size(150, 33);
            this.cmdEditCurrentRow.TabIndex = 2;
            this.cmdEditCurrentRow.Text = "Save current";
            this.cmdEditCurrentRow.UseVisualStyleBackColor = true;
            this.cmdEditCurrentRow.Click += new System.EventHandler(this.cmdEditCurrentRow_Click);
            // 
            // cmdDeleteCurrentRow
            // 
            this.cmdDeleteCurrentRow.Location = new System.Drawing.Point(201, 7);
            this.cmdDeleteCurrentRow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdDeleteCurrentRow.Name = "cmdDeleteCurrentRow";
            this.cmdDeleteCurrentRow.Size = new System.Drawing.Size(150, 33);
            this.cmdDeleteCurrentRow.TabIndex = 1;
            this.cmdDeleteCurrentRow.Text = "Remove current";
            this.cmdDeleteCurrentRow.UseVisualStyleBackColor = true;
            this.cmdDeleteCurrentRow.Click += new System.EventHandler(this.cmdDeleteCurrentRow_Click);
            // 
            // cmdAddNewRow
            // 
            this.cmdAddNewRow.Location = new System.Drawing.Point(11, 7);
            this.cmdAddNewRow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdAddNewRow.Name = "cmdAddNewRow";
            this.cmdAddNewRow.Size = new System.Drawing.Size(150, 33);
            this.cmdAddNewRow.TabIndex = 0;
            this.cmdAddNewRow.Text = "Add new row(s)";
            this.cmdAddNewRow.UseVisualStyleBackColor = true;
            this.cmdAddNewRow.Click += new System.EventHandler(this.cmdAddNewRow_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(558, 328);
            this.DataGridView1.TabIndex = 2;
            this.DataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_RowEnter);
            this.DataGridView1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView1_RowValidating);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 328);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.DataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdEditCurrentRow;
        internal System.Windows.Forms.Button cmdDeleteCurrentRow;
        internal System.Windows.Forms.Button cmdAddNewRow;
        internal System.Windows.Forms.DataGridView DataGridView1;
    }
}

