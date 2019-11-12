namespace OperationsFrontEnd_cs
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
            this.countriesCombox = new System.Windows.Forms.ComboBox();
            this.selectByCountryButton = new System.Windows.Forms.Button();
            this.CreateNewExcelFileCheckBox = new System.Windows.Forms.CheckBox();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // countriesCombox
            // 
            this.countriesCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countriesCombox.FormattingEnabled = true;
            this.countriesCombox.Location = new System.Drawing.Point(177, 56);
            this.countriesCombox.Name = "countriesCombox";
            this.countriesCombox.Size = new System.Drawing.Size(175, 21);
            this.countriesCombox.TabIndex = 2;
            // 
            // selectByCountryButton
            // 
            this.selectByCountryButton.Location = new System.Drawing.Point(25, 54);
            this.selectByCountryButton.Name = "selectByCountryButton";
            this.selectByCountryButton.Size = new System.Drawing.Size(135, 23);
            this.selectByCountryButton.TabIndex = 1;
            this.selectByCountryButton.Text = "Export by Country";
            this.selectByCountryButton.UseVisualStyleBackColor = true;
            this.selectByCountryButton.Click += new System.EventHandler(this.selectByCountryButton_Click);
            // 
            // CreateNewExcelFileCheckBox
            // 
            this.CreateNewExcelFileCheckBox.AutoSize = true;
            this.CreateNewExcelFileCheckBox.Checked = true;
            this.CreateNewExcelFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CreateNewExcelFileCheckBox.Location = new System.Drawing.Point(25, 112);
            this.CreateNewExcelFileCheckBox.Name = "CreateNewExcelFileCheckBox";
            this.CreateNewExcelFileCheckBox.Size = new System.Drawing.Size(161, 17);
            this.CreateNewExcelFileCheckBox.TabIndex = 3;
            this.CreateNewExcelFileCheckBox.Text = "If checked, create a new file";
            this.CreateNewExcelFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(25, 12);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(135, 23);
            this.selectAllButton.TabIndex = 0;
            this.selectAllButton.Text = "Export All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 177);
            this.Controls.Add(this.countriesCombox);
            this.Controls.Add(this.selectByCountryButton);
            this.Controls.Add(this.CreateNewExcelFileCheckBox);
            this.Controls.Add(this.selectAllButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox countriesCombox;
        internal System.Windows.Forms.Button selectByCountryButton;
        internal System.Windows.Forms.CheckBox CreateNewExcelFileCheckBox;
        internal System.Windows.Forms.Button selectAllButton;
    }
}

