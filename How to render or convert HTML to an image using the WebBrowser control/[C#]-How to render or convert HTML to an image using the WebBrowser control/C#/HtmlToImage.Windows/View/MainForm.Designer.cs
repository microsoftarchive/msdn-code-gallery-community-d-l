namespace HtmlToImage.Windows
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
			this.label1 = new System.Windows.Forms.Label();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.navigateLinkLabel = new System.Windows.Forms.LinkLabel();
			this.htmlTextBox = new System.Windows.Forms.TextBox();
			this.renderLinkLabel = new System.Windows.Forms.LinkLabel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Url";
			// 
			// urlTextBox
			// 
			this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.urlTextBox.Location = new System.Drawing.Point(12, 25);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.Size = new System.Drawing.Size(373, 20);
			this.urlTextBox.TabIndex = 1;
			this.urlTextBox.Text = "http://www.google.com";
			// 
			// navigateLinkLabel
			// 
			this.navigateLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.navigateLinkLabel.AutoSize = true;
			this.navigateLinkLabel.Location = new System.Drawing.Point(391, 28);
			this.navigateLinkLabel.Name = "navigateLinkLabel";
			this.navigateLinkLabel.Size = new System.Drawing.Size(21, 13);
			this.navigateLinkLabel.TabIndex = 2;
			this.navigateLinkLabel.TabStop = true;
			this.navigateLinkLabel.Text = "Go";
			this.navigateLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NavigateLinkLabelLinkClicked);
			// 
			// htmlTextBox
			// 
			this.htmlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.htmlTextBox.Location = new System.Drawing.Point(12, 60);
			this.htmlTextBox.Multiline = true;
			this.htmlTextBox.Name = "htmlTextBox";
			this.htmlTextBox.Size = new System.Drawing.Size(373, 113);
			this.htmlTextBox.TabIndex = 3;
			// 
			// renderLinkLabel
			// 
			this.renderLinkLabel.AutoSize = true;
			this.renderLinkLabel.Location = new System.Drawing.Point(12, 176);
			this.renderLinkLabel.Name = "renderLinkLabel";
			this.renderLinkLabel.Size = new System.Drawing.Size(42, 13);
			this.renderLinkLabel.TabIndex = 4;
			this.renderLinkLabel.TabStop = true;
			this.renderLinkLabel.Text = "Render";
			this.renderLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RenderHtmlToBitmapLinkClicked);
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox.Location = new System.Drawing.Point(12, 207);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(373, 202);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 5;
			this.pictureBox.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 421);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.renderLinkLabel);
			this.Controls.Add(this.htmlTextBox);
			this.Controls.Add(this.navigateLinkLabel);
			this.Controls.Add(this.urlTextBox);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Eye.Open - HtmlToImage converter";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.LinkLabel navigateLinkLabel;
		private System.Windows.Forms.TextBox htmlTextBox;
		private System.Windows.Forms.LinkLabel renderLinkLabel;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}

