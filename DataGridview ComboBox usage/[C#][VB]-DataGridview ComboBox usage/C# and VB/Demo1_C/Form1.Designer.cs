namespace Demo1_C
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
            this.cmdQuickAdd = new System.Windows.Forms.Button();
            this.cmdDemo = new System.Windows.Forms.Button();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.cmdPeekAtAllRows = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmdQuickAdd);
            this.Panel1.Controls.Add(this.cmdDemo);
            this.Panel1.Controls.Add(this.CheckBox1);
            this.Panel1.Controls.Add(this.cmdPeekAtAllRows);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 367);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(435, 84);
            this.Panel1.TabIndex = 3;
            // 
            // cmdQuickAdd
            // 
            this.cmdQuickAdd.Location = new System.Drawing.Point(13, 52);
            this.cmdQuickAdd.Name = "cmdQuickAdd";
            this.cmdQuickAdd.Size = new System.Drawing.Size(100, 28);
            this.cmdQuickAdd.TabIndex = 3;
            this.cmdQuickAdd.Text = "Quick Add";
            this.cmdQuickAdd.UseVisualStyleBackColor = true;
            // 
            // cmdDemo
            // 
            this.cmdDemo.Location = new System.Drawing.Point(308, 12);
            this.cmdDemo.Name = "cmdDemo";
            this.cmdDemo.Size = new System.Drawing.Size(65, 47);
            this.cmdDemo.TabIndex = 2;
            this.cmdDemo.Text = "Demo";
            this.cmdDemo.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(120, 21);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(178, 21);
            this.CheckBox1.TabIndex = 1;
            this.CheckBox1.Text = "Show only MessageBox";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // cmdPeekAtAllRows
            // 
            this.cmdPeekAtAllRows.Location = new System.Drawing.Point(13, 16);
            this.cmdPeekAtAllRows.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPeekAtAllRows.Name = "cmdPeekAtAllRows";
            this.cmdPeekAtAllRows.Size = new System.Drawing.Size(100, 28);
            this.cmdPeekAtAllRows.TabIndex = 0;
            this.cmdPeekAtAllRows.Text = "All";
            this.cmdPeekAtAllRows.UseVisualStyleBackColor = true;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(435, 451);
            this.DataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 451);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.DataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdQuickAdd;
        internal System.Windows.Forms.Button cmdDemo;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.Button cmdPeekAtAllRows;
        internal System.Windows.Forms.DataGridView DataGridView1;
    }
}

