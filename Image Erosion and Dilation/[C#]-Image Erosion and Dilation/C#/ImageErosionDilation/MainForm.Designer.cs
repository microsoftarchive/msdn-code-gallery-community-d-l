namespace ImageErosionDilation
{
    partial class MainForm
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnOpenOriginal = new System.Windows.Forms.Button();
            this.btnSaveNewImage = new System.Windows.Forms.Button();
            this.cmbFilterSize = new System.Windows.Forms.ComboBox();
            this.chkR = new System.Windows.Forms.CheckBox();
            this.chkG = new System.Windows.Forms.CheckBox();
            this.chkB = new System.Windows.Forms.CheckBox();
            this.lblFilterSize = new System.Windows.Forms.Label();
            this.rdDilate = new System.Windows.Forms.RadioButton();
            this.rdErode = new System.Windows.Forms.RadioButton();
            this.rdOpen = new System.Windows.Forms.RadioButton();
            this.rdClosed = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.Silver;
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(12, 12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(600, 600);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 13;
            this.picPreview.TabStop = false;
            // 
            // btnOpenOriginal
            // 
            this.btnOpenOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenOriginal.Location = new System.Drawing.Point(12, 618);
            this.btnOpenOriginal.Name = "btnOpenOriginal";
            this.btnOpenOriginal.Size = new System.Drawing.Size(150, 46);
            this.btnOpenOriginal.TabIndex = 15;
            this.btnOpenOriginal.Text = "Load Image";
            this.btnOpenOriginal.UseVisualStyleBackColor = true;
            this.btnOpenOriginal.Click += new System.EventHandler(this.btnOpenOriginal_Click);
            // 
            // btnSaveNewImage
            // 
            this.btnSaveNewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewImage.Location = new System.Drawing.Point(462, 618);
            this.btnSaveNewImage.Name = "btnSaveNewImage";
            this.btnSaveNewImage.Size = new System.Drawing.Size(150, 46);
            this.btnSaveNewImage.TabIndex = 16;
            this.btnSaveNewImage.Text = "Save Image";
            this.btnSaveNewImage.UseVisualStyleBackColor = true;
            this.btnSaveNewImage.Click += new System.EventHandler(this.btnSaveNewImage_Click);
            // 
            // cmbFilterSize
            // 
            this.cmbFilterSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterSize.FormattingEnabled = true;
            this.cmbFilterSize.Items.AddRange(new object[] {
            "None",
            "3",
            "5",
            "7",
            "9",
            "11",
            "13",
            "15",
            "17"});
            this.cmbFilterSize.Location = new System.Drawing.Point(620, 372);
            this.cmbFilterSize.Name = "cmbFilterSize";
            this.cmbFilterSize.Size = new System.Drawing.Size(107, 32);
            this.cmbFilterSize.TabIndex = 20;
            this.cmbFilterSize.SelectedIndexChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // chkR
            // 
            this.chkR.AutoSize = true;
            this.chkR.Checked = true;
            this.chkR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkR.Location = new System.Drawing.Point(618, 12);
            this.chkR.Name = "chkR";
            this.chkR.Size = new System.Drawing.Size(73, 29);
            this.chkR.TabIndex = 21;
            this.chkR.Text = "Red";
            this.chkR.UseVisualStyleBackColor = true;
            this.chkR.CheckedChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // chkG
            // 
            this.chkG.AutoSize = true;
            this.chkG.Checked = true;
            this.chkG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkG.Location = new System.Drawing.Point(618, 50);
            this.chkG.Name = "chkG";
            this.chkG.Size = new System.Drawing.Size(95, 29);
            this.chkG.TabIndex = 22;
            this.chkG.Text = "Green";
            this.chkG.UseVisualStyleBackColor = true;
            this.chkG.CheckedChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // chkB
            // 
            this.chkB.AutoSize = true;
            this.chkB.Checked = true;
            this.chkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkB.Location = new System.Drawing.Point(618, 89);
            this.chkB.Name = "chkB";
            this.chkB.Size = new System.Drawing.Size(78, 29);
            this.chkB.TabIndex = 23;
            this.chkB.Text = "Blue";
            this.chkB.UseVisualStyleBackColor = true;
            this.chkB.CheckedChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // lblFilterSize
            // 
            this.lblFilterSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterSize.Location = new System.Drawing.Point(620, 328);
            this.lblFilterSize.Name = "lblFilterSize";
            this.lblFilterSize.Size = new System.Drawing.Size(107, 41);
            this.lblFilterSize.TabIndex = 26;
            this.lblFilterSize.Text = "Filter Size";
            this.lblFilterSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdDilate
            // 
            this.rdDilate.AutoSize = true;
            this.rdDilate.Checked = true;
            this.rdDilate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDilate.Location = new System.Drawing.Point(618, 133);
            this.rdDilate.Name = "rdDilate";
            this.rdDilate.Size = new System.Drawing.Size(91, 29);
            this.rdDilate.TabIndex = 27;
            this.rdDilate.TabStop = true;
            this.rdDilate.Text = "Dilate";
            this.rdDilate.UseVisualStyleBackColor = true;
            this.rdDilate.CheckedChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // rdErode
            // 
            this.rdErode.AutoSize = true;
            this.rdErode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdErode.Location = new System.Drawing.Point(618, 168);
            this.rdErode.Name = "rdErode";
            this.rdErode.Size = new System.Drawing.Size(92, 29);
            this.rdErode.TabIndex = 28;
            this.rdErode.Text = "Erode";
            this.rdErode.UseVisualStyleBackColor = true;
            this.rdErode.CheckedChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // rdOpen
            // 
            this.rdOpen.AutoSize = true;
            this.rdOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdOpen.Location = new System.Drawing.Point(618, 203);
            this.rdOpen.Name = "rdOpen";
            this.rdOpen.Size = new System.Drawing.Size(86, 29);
            this.rdOpen.TabIndex = 29;
            this.rdOpen.Text = "Open";
            this.rdOpen.UseVisualStyleBackColor = true;
            this.rdOpen.CheckedChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // rdClosed
            // 
            this.rdClosed.AutoSize = true;
            this.rdClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdClosed.Location = new System.Drawing.Point(618, 238);
            this.rdClosed.Name = "rdClosed";
            this.rdClosed.Size = new System.Drawing.Size(103, 29);
            this.rdClosed.TabIndex = 30;
            this.rdClosed.Text = "Closed";
            this.rdClosed.UseVisualStyleBackColor = true;
            this.rdClosed.CheckedChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(732, 675);
            this.Controls.Add(this.rdClosed);
            this.Controls.Add(this.rdOpen);
            this.Controls.Add(this.rdErode);
            this.Controls.Add(this.rdDilate);
            this.Controls.Add(this.lblFilterSize);
            this.Controls.Add(this.chkB);
            this.Controls.Add(this.chkG);
            this.Controls.Add(this.chkR);
            this.Controls.Add(this.cmbFilterSize);
            this.Controls.Add(this.btnSaveNewImage);
            this.Controls.Add(this.btnOpenOriginal);
            this.Controls.Add(this.picPreview);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Erosion and Dilation";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnOpenOriginal;
        private System.Windows.Forms.Button btnSaveNewImage;
        private System.Windows.Forms.ComboBox cmbFilterSize;
        private System.Windows.Forms.CheckBox chkR;
        private System.Windows.Forms.CheckBox chkG;
        private System.Windows.Forms.CheckBox chkB;
        private System.Windows.Forms.Label lblFilterSize;
        private System.Windows.Forms.RadioButton rdDilate;
        private System.Windows.Forms.RadioButton rdErode;
        private System.Windows.Forms.RadioButton rdOpen;
        private System.Windows.Forms.RadioButton rdClosed;
    }
}

