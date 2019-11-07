namespace ImageBlurFilter
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
            this.cmbBlurFilter = new System.Windows.Forms.ComboBox();
            this.lblBlurFilter = new System.Windows.Forms.Label();
            this.pnlBlur = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.pnlBlur.SuspendLayout();
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
            this.btnOpenOriginal.Location = new System.Drawing.Point(618, 514);
            this.btnOpenOriginal.Name = "btnOpenOriginal";
            this.btnOpenOriginal.Size = new System.Drawing.Size(228, 46);
            this.btnOpenOriginal.TabIndex = 15;
            this.btnOpenOriginal.Text = "Load Image";
            this.btnOpenOriginal.UseVisualStyleBackColor = true;
            this.btnOpenOriginal.Click += new System.EventHandler(this.btnOpenOriginal_Click);
            // 
            // btnSaveNewImage
            // 
            this.btnSaveNewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewImage.Location = new System.Drawing.Point(618, 566);
            this.btnSaveNewImage.Name = "btnSaveNewImage";
            this.btnSaveNewImage.Size = new System.Drawing.Size(228, 46);
            this.btnSaveNewImage.TabIndex = 16;
            this.btnSaveNewImage.Text = "Save Image";
            this.btnSaveNewImage.UseVisualStyleBackColor = true;
            this.btnSaveNewImage.Click += new System.EventHandler(this.btnSaveNewImage_Click);
            // 
            // cmbBlurFilter
            // 
            this.cmbBlurFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlurFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBlurFilter.FormattingEnabled = true;
            this.cmbBlurFilter.Location = new System.Drawing.Point(7, 36);
            this.cmbBlurFilter.Name = "cmbBlurFilter";
            this.cmbBlurFilter.Size = new System.Drawing.Size(213, 32);
            this.cmbBlurFilter.TabIndex = 20;
            this.cmbBlurFilter.SelectedIndexChanged += new System.EventHandler(this.FilterValueChangedEventHandler);
            // 
            // lblBlurFilter
            // 
            this.lblBlurFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlurFilter.Location = new System.Drawing.Point(3, 3);
            this.lblBlurFilter.Name = "lblBlurFilter";
            this.lblBlurFilter.Size = new System.Drawing.Size(217, 30);
            this.lblBlurFilter.TabIndex = 26;
            this.lblBlurFilter.Text = "Blur Filter";
            this.lblBlurFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBlur
            // 
            this.pnlBlur.BackColor = System.Drawing.Color.Silver;
            this.pnlBlur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBlur.Controls.Add(this.lblBlurFilter);
            this.pnlBlur.Controls.Add(this.cmbBlurFilter);
            this.pnlBlur.Location = new System.Drawing.Point(618, 12);
            this.pnlBlur.Name = "pnlBlur";
            this.pnlBlur.Size = new System.Drawing.Size(228, 76);
            this.pnlBlur.TabIndex = 34;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(853, 622);
            this.Controls.Add(this.pnlBlur);
            this.Controls.Add(this.btnSaveNewImage);
            this.Controls.Add(this.btnOpenOriginal);
            this.Controls.Add(this.picPreview);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Blur Filter";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.pnlBlur.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnOpenOriginal;
        private System.Windows.Forms.Button btnSaveNewImage;
        private System.Windows.Forms.ComboBox cmbBlurFilter;
        private System.Windows.Forms.Label lblBlurFilter;
        private System.Windows.Forms.Panel pnlBlur;
    }
}

