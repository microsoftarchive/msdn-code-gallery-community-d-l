namespace RemoveBlankPageInWord
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOpenWord = new System.Windows.Forms.Button();
            this.txbWordPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(15, 67);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(130, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnOpenWord
            // 
            this.btnOpenWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWord.Location = new System.Drawing.Point(331, 18);
            this.btnOpenWord.Name = "btnOpenWord";
            this.btnOpenWord.Size = new System.Drawing.Size(75, 23);
            this.btnOpenWord.TabIndex = 6;
            this.btnOpenWord.Text = "Open";
            this.btnOpenWord.UseVisualStyleBackColor = true;
            this.btnOpenWord.Click += new System.EventHandler(this.btnOpenWord_Click);
            // 
            // txbWordPath
            // 
            this.txbWordPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbWordPath.Location = new System.Drawing.Point(106, 20);
            this.txbWordPath.Name = "txbWordPath";
            this.txbWordPath.Size = new System.Drawing.Size(219, 20);
            this.txbWordPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Word Document:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 143);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnOpenWord);
            this.Controls.Add(this.txbWordPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Remove Blank Page In Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnOpenWord;
        private System.Windows.Forms.TextBox txbWordPath;
        private System.Windows.Forms.Label label1;
    }
}

