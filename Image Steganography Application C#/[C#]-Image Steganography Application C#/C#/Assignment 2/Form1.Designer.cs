namespace Assignment_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxSimple = new System.Windows.Forms.PictureBox();
            this.pictureBoxSecret = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.groupBoxEncryption = new System.Windows.Forms.GroupBox();
            this.buttonSaveAsGrey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonBrowseSimple = new System.Windows.Forms.Button();
            this.buttonBrowseSecret = new System.Windows.Forms.Button();
            this.buttonGenerateResult = new System.Windows.Forms.Button();
            this.groupBoxDecryption = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSaveAsFinal = new System.Windows.Forms.Button();
            this.textBoxDekey = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBoxEncryptedImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxExtractedImage = new System.Windows.Forms.PictureBox();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDecryption = new System.Windows.Forms.Button();
            this.buttonEncryption = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecret)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.groupBoxEncryption.SuspendLayout();
            this.groupBoxDecryption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEncryptedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtractedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSimple
            // 
            this.pictureBoxSimple.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxSimple.Location = new System.Drawing.Point(15, 19);
            this.pictureBoxSimple.Name = "pictureBoxSimple";
            this.pictureBoxSimple.Size = new System.Drawing.Size(169, 159);
            this.pictureBoxSimple.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSimple.TabIndex = 1;
            this.pictureBoxSimple.TabStop = false;
            // 
            // pictureBoxSecret
            // 
            this.pictureBoxSecret.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxSecret.Location = new System.Drawing.Point(192, 19);
            this.pictureBoxSecret.Name = "pictureBoxSecret";
            this.pictureBoxSecret.Size = new System.Drawing.Size(169, 159);
            this.pictureBoxSecret.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSecret.TabIndex = 2;
            this.pictureBoxSecret.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxResult.Location = new System.Drawing.Point(370, 19);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(169, 159);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 5;
            this.pictureBoxResult.TabStop = false;
            // 
            // groupBoxEncryption
            // 
            this.groupBoxEncryption.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxEncryption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxEncryption.Controls.Add(this.buttonSaveAsGrey);
            this.groupBoxEncryption.Controls.Add(this.label1);
            this.groupBoxEncryption.Controls.Add(this.buttonSaveAs);
            this.groupBoxEncryption.Controls.Add(this.textBoxKey);
            this.groupBoxEncryption.Controls.Add(this.buttonBrowseSimple);
            this.groupBoxEncryption.Controls.Add(this.pictureBoxSimple);
            this.groupBoxEncryption.Controls.Add(this.buttonBrowseSecret);
            this.groupBoxEncryption.Controls.Add(this.pictureBoxResult);
            this.groupBoxEncryption.Controls.Add(this.buttonGenerateResult);
            this.groupBoxEncryption.Controls.Add(this.pictureBoxSecret);
            this.groupBoxEncryption.ForeColor = System.Drawing.Color.White;
            this.groupBoxEncryption.Location = new System.Drawing.Point(120, 12);
            this.groupBoxEncryption.Name = "groupBoxEncryption";
            this.groupBoxEncryption.Size = new System.Drawing.Size(553, 291);
            this.groupBoxEncryption.TabIndex = 1;
            this.groupBoxEncryption.TabStop = false;
            this.groupBoxEncryption.Text = "Image Steganography";
            // 
            // buttonSaveAsGrey
            // 
            this.buttonSaveAsGrey.Enabled = false;
            this.buttonSaveAsGrey.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveAsGrey.Location = new System.Drawing.Point(205, 184);
            this.buttonSaveAsGrey.Name = "buttonSaveAsGrey";
            this.buttonSaveAsGrey.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAsGrey.TabIndex = 9;
            this.buttonSaveAsGrey.Text = "Save As";
            this.buttonSaveAsGrey.UseVisualStyleBackColor = true;
            this.buttonSaveAsGrey.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Encryption Key";
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Enabled = false;
            this.buttonSaveAs.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveAs.Location = new System.Drawing.Point(464, 184);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAs.TabIndex = 4;
            this.buttonSaveAs.Text = "Save As";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(15, 231);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.PasswordChar = '*';
            this.textBoxKey.Size = new System.Drawing.Size(169, 20);
            this.textBoxKey.TabIndex = 7;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonBrowseSimple
            // 
            this.buttonBrowseSimple.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseSimple.Location = new System.Drawing.Point(109, 184);
            this.buttonBrowseSimple.Name = "buttonBrowseSimple";
            this.buttonBrowseSimple.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseSimple.TabIndex = 1;
            this.buttonBrowseSimple.Text = "Browse";
            this.buttonBrowseSimple.UseVisualStyleBackColor = true;
            this.buttonBrowseSimple.Click += new System.EventHandler(this.buttonBrowseSimple_Click);
            // 
            // buttonBrowseSecret
            // 
            this.buttonBrowseSecret.Enabled = false;
            this.buttonBrowseSecret.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseSecret.Location = new System.Drawing.Point(286, 184);
            this.buttonBrowseSecret.Name = "buttonBrowseSecret";
            this.buttonBrowseSecret.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseSecret.TabIndex = 2;
            this.buttonBrowseSecret.Text = "Browse";
            this.buttonBrowseSecret.UseVisualStyleBackColor = true;
            this.buttonBrowseSecret.Click += new System.EventHandler(this.buttonBrowseSecret_Click);
            // 
            // buttonGenerateResult
            // 
            this.buttonGenerateResult.Enabled = false;
            this.buttonGenerateResult.ForeColor = System.Drawing.Color.Black;
            this.buttonGenerateResult.Location = new System.Drawing.Point(205, 229);
            this.buttonGenerateResult.Name = "buttonGenerateResult";
            this.buttonGenerateResult.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerateResult.TabIndex = 3;
            this.buttonGenerateResult.Text = "Generate";
            this.buttonGenerateResult.UseVisualStyleBackColor = true;
            this.buttonGenerateResult.Click += new System.EventHandler(this.buttonGenerateResult_Click);
            // 
            // groupBoxDecryption
            // 
            this.groupBoxDecryption.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDecryption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxDecryption.Controls.Add(this.label2);
            this.groupBoxDecryption.Controls.Add(this.buttonSaveAsFinal);
            this.groupBoxDecryption.Controls.Add(this.textBoxDekey);
            this.groupBoxDecryption.Controls.Add(this.button2);
            this.groupBoxDecryption.Controls.Add(this.pictureBoxEncryptedImage);
            this.groupBoxDecryption.Controls.Add(this.pictureBoxExtractedImage);
            this.groupBoxDecryption.Controls.Add(this.buttonDecrypt);
            this.groupBoxDecryption.ForeColor = System.Drawing.Color.White;
            this.groupBoxDecryption.Location = new System.Drawing.Point(120, 12);
            this.groupBoxDecryption.Name = "groupBoxDecryption";
            this.groupBoxDecryption.Size = new System.Drawing.Size(554, 266);
            this.groupBoxDecryption.TabIndex = 10;
            this.groupBoxDecryption.TabStop = false;
            this.groupBoxDecryption.Text = "Image Steganography";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Decryption Key";
            // 
            // buttonSaveAsFinal
            // 
            this.buttonSaveAsFinal.Enabled = false;
            this.buttonSaveAsFinal.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveAsFinal.Location = new System.Drawing.Point(286, 184);
            this.buttonSaveAsFinal.Name = "buttonSaveAsFinal";
            this.buttonSaveAsFinal.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAsFinal.TabIndex = 4;
            this.buttonSaveAsFinal.Text = "Save As";
            this.buttonSaveAsFinal.UseVisualStyleBackColor = true;
            this.buttonSaveAsFinal.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDekey
            // 
            this.textBoxDekey.Location = new System.Drawing.Point(15, 231);
            this.textBoxDekey.Name = "textBoxDekey";
            this.textBoxDekey.PasswordChar = '*';
            this.textBoxDekey.Size = new System.Drawing.Size(169, 20);
            this.textBoxDekey.TabIndex = 7;
            this.textBoxDekey.TextChanged += new System.EventHandler(this.textBoxDekey_TextChanged);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(109, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBoxEncryptedImage
            // 
            this.pictureBoxEncryptedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxEncryptedImage.Location = new System.Drawing.Point(15, 19);
            this.pictureBoxEncryptedImage.Name = "pictureBoxEncryptedImage";
            this.pictureBoxEncryptedImage.Size = new System.Drawing.Size(169, 159);
            this.pictureBoxEncryptedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEncryptedImage.TabIndex = 1;
            this.pictureBoxEncryptedImage.TabStop = false;
            // 
            // pictureBoxExtractedImage
            // 
            this.pictureBoxExtractedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxExtractedImage.Location = new System.Drawing.Point(192, 19);
            this.pictureBoxExtractedImage.Name = "pictureBoxExtractedImage";
            this.pictureBoxExtractedImage.Size = new System.Drawing.Size(169, 159);
            this.pictureBoxExtractedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExtractedImage.TabIndex = 5;
            this.pictureBoxExtractedImage.TabStop = false;
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Enabled = false;
            this.buttonDecrypt.ForeColor = System.Drawing.Color.Black;
            this.buttonDecrypt.Location = new System.Drawing.Point(208, 229);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrypt.TabIndex = 3;
            this.buttonDecrypt.Text = "Generate";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.ForeColor = System.Drawing.Color.Black;
            this.buttonExit.Location = new System.Drawing.Point(12, 99);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(102, 28);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDecryption
            // 
            this.buttonDecryption.ForeColor = System.Drawing.Color.Black;
            this.buttonDecryption.Location = new System.Drawing.Point(12, 65);
            this.buttonDecryption.Name = "buttonDecryption";
            this.buttonDecryption.Size = new System.Drawing.Size(102, 28);
            this.buttonDecryption.TabIndex = 7;
            this.buttonDecryption.Text = "Decryption";
            this.buttonDecryption.UseVisualStyleBackColor = true;
            this.buttonDecryption.Click += new System.EventHandler(this.buttonDecryption_Click);
            // 
            // buttonEncryption
            // 
            this.buttonEncryption.ForeColor = System.Drawing.Color.Black;
            this.buttonEncryption.Location = new System.Drawing.Point(12, 31);
            this.buttonEncryption.Name = "buttonEncryption";
            this.buttonEncryption.Size = new System.Drawing.Size(102, 28);
            this.buttonEncryption.TabIndex = 8;
            this.buttonEncryption.Text = "Encryption";
            this.buttonEncryption.UseVisualStyleBackColor = true;
            this.buttonEncryption.Click += new System.EventHandler(this.buttonEncryption_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(595, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ninja Coding Club";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(690, 323);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBoxEncryption);
            this.Controls.Add(this.buttonEncryption);
            this.Controls.Add(this.buttonDecryption);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBoxDecryption);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Image Steganography   -NCC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecret)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.groupBoxEncryption.ResumeLayout(false);
            this.groupBoxEncryption.PerformLayout();
            this.groupBoxDecryption.ResumeLayout(false);
            this.groupBoxDecryption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEncryptedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtractedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSimple;
        private System.Windows.Forms.PictureBox pictureBoxSecret;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.GroupBox groupBoxEncryption;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonBrowseSimple;
        private System.Windows.Forms.Button buttonBrowseSecret;
        private System.Windows.Forms.Button buttonGenerateResult;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDecryption;
        private System.Windows.Forms.Button buttonEncryption;
        private System.Windows.Forms.GroupBox groupBoxDecryption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSaveAsFinal;
        private System.Windows.Forms.TextBox textBoxDekey;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBoxEncryptedImage;
        private System.Windows.Forms.PictureBox pictureBoxExtractedImage;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Button buttonSaveAsGrey;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label3;
    }
}

