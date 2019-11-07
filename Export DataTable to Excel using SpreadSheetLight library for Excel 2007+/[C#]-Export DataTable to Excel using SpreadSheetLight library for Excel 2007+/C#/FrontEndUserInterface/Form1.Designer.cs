namespace FrontEndUserInterface
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.basicFormattingWithATwistButton2 = new System.Windows.Forms.Button();
            this.basicFormattingWithATwistButton = new System.Windows.Forms.Button();
            this.basicImportFormattedButton = new System.Windows.Forms.Button();
            this.basicImportBirthDayNoFormatButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.basicFormattingWithATwistButton2);
            this.panel1.Controls.Add(this.basicFormattingWithATwistButton);
            this.panel1.Controls.Add(this.basicImportFormattedButton);
            this.panel1.Controls.Add(this.basicImportBirthDayNoFormatButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1293, 95);
            this.panel1.TabIndex = 1;
            // 
            // basicFormattingWithATwistButton2
            // 
            this.basicFormattingWithATwistButton2.Location = new System.Drawing.Point(229, 48);
            this.basicFormattingWithATwistButton2.Name = "basicFormattingWithATwistButton2";
            this.basicFormattingWithATwistButton2.Size = new System.Drawing.Size(196, 23);
            this.basicFormattingWithATwistButton2.TabIndex = 3;
            this.basicFormattingWithATwistButton2.Text = "Basic import with a twist 2";
            this.toolTip1.SetToolTip(this.basicFormattingWithATwistButton2, "Import DataTable with no formatting on BirthDay field");
            this.basicFormattingWithATwistButton2.UseVisualStyleBackColor = true;
            this.basicFormattingWithATwistButton2.Click += new System.EventHandler(this.basicFormattingWithATwistButton2_Click);
            // 
            // basicFormattingWithATwistButton
            // 
            this.basicFormattingWithATwistButton.Location = new System.Drawing.Point(229, 19);
            this.basicFormattingWithATwistButton.Name = "basicFormattingWithATwistButton";
            this.basicFormattingWithATwistButton.Size = new System.Drawing.Size(196, 23);
            this.basicFormattingWithATwistButton.TabIndex = 1;
            this.basicFormattingWithATwistButton.Text = "Basic import with a twist 1";
            this.toolTip1.SetToolTip(this.basicFormattingWithATwistButton, "Import DataTable with no formatting on BirthDay field");
            this.basicFormattingWithATwistButton.UseVisualStyleBackColor = true;
            this.basicFormattingWithATwistButton.Click += new System.EventHandler(this.basicFormattingWithATwistButton_Click);
            // 
            // basicImportFormattedButton
            // 
            this.basicImportFormattedButton.Location = new System.Drawing.Point(12, 48);
            this.basicImportFormattedButton.Name = "basicImportFormattedButton";
            this.basicImportFormattedButton.Size = new System.Drawing.Size(196, 23);
            this.basicImportFormattedButton.TabIndex = 2;
            this.basicImportFormattedButton.Text = "Basic import with standard formatting";
            this.toolTip1.SetToolTip(this.basicImportFormattedButton, "Import DataTable with formatting on BirthDay field");
            this.basicImportFormattedButton.UseVisualStyleBackColor = true;
            this.basicImportFormattedButton.Click += new System.EventHandler(this.basicImportFormattedButton_Click);
            // 
            // basicImportBirthDayNoFormatButton
            // 
            this.basicImportBirthDayNoFormatButton.Location = new System.Drawing.Point(12, 19);
            this.basicImportBirthDayNoFormatButton.Name = "basicImportBirthDayNoFormatButton";
            this.basicImportBirthDayNoFormatButton.Size = new System.Drawing.Size(196, 23);
            this.basicImportBirthDayNoFormatButton.TabIndex = 0;
            this.basicImportBirthDayNoFormatButton.Text = "Basic import no date formatting";
            this.toolTip1.SetToolTip(this.basicImportBirthDayNoFormatButton, "Import DataTable with no formatting on BirthDay field");
            this.basicImportBirthDayNoFormatButton.UseVisualStyleBackColor = true;
            this.basicImportBirthDayNoFormatButton.Click += new System.EventHandler(this.basicImportBirthDayNoFormatButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1293, 290);
            this.dataGridView1.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(1206, 48);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Exit";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 385);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpreadSheetLight import DataTable code sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button basicImportBirthDayNoFormatButton;
        private System.Windows.Forms.Button basicImportFormattedButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button basicFormattingWithATwistButton;
        private System.Windows.Forms.Button basicFormattingWithATwistButton2;
        private System.Windows.Forms.Button closeButton;
    }
}

