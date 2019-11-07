namespace ClientSample
{
    partial class FileOperation
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
            this.btnFollowLink = new System.Windows.Forms.Button();
            this.btnSkipAll = new System.Windows.Forms.Button();
            this.btnOverwriteDiffSize = new System.Windows.Forms.Button();
            this.btnOverwriteOlder = new System.Windows.Forms.Button();
            this.btnOverwriteAll = new System.Windows.Forms.Button();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnResumeAll = new System.Windows.Forms.Button();
            this.btnFollowLinkAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFollowLink
            // 
            this.btnFollowLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFollowLink.Location = new System.Drawing.Point(143, 203);
            this.btnFollowLink.Name = "btnFollowLink";
            this.btnFollowLink.Size = new System.Drawing.Size(128, 24);
            this.btnFollowLink.TabIndex = 8;
            this.btnFollowLink.Text = "Follow &Link";
            this.btnFollowLink.Visible = false;
            this.btnFollowLink.Click += new System.EventHandler(this.btnFollowLink_Click);
            // 
            // btnSkipAll
            // 
            this.btnSkipAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSkipAll.Location = new System.Drawing.Point(9, 203);
            this.btnSkipAll.Name = "btnSkipAll";
            this.btnSkipAll.Size = new System.Drawing.Size(128, 24);
            this.btnSkipAll.TabIndex = 7;
            this.btnSkipAll.Text = "S&kip All";
            this.btnSkipAll.Visible = false;
            this.btnSkipAll.Click += new System.EventHandler(this.btnSkipAll_Click);
            // 
            // btnOverwriteDiffSize
            // 
            this.btnOverwriteDiffSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOverwriteDiffSize.Location = new System.Drawing.Point(9, 173);
            this.btnOverwriteDiffSize.Name = "btnOverwriteDiffSize";
            this.btnOverwriteDiffSize.Size = new System.Drawing.Size(128, 24);
            this.btnOverwriteDiffSize.TabIndex = 4;
            this.btnOverwriteDiffSize.Text = "Overwrite &Different Files";
            this.btnOverwriteDiffSize.Visible = false;
            this.btnOverwriteDiffSize.Click += new System.EventHandler(this.btnOverwriteDiffSize_Click);
            // 
            // btnOverwriteOlder
            // 
            this.btnOverwriteOlder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOverwriteOlder.Location = new System.Drawing.Point(277, 143);
            this.btnOverwriteOlder.Name = "btnOverwriteOlder";
            this.btnOverwriteOlder.Size = new System.Drawing.Size(128, 24);
            this.btnOverwriteOlder.TabIndex = 3;
            this.btnOverwriteOlder.Text = "Overwrite &Older Files";
            this.btnOverwriteOlder.Visible = false;
            this.btnOverwriteOlder.Click += new System.EventHandler(this.btnOverwriteOlder_Click);
            // 
            // btnOverwriteAll
            // 
            this.btnOverwriteAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOverwriteAll.Location = new System.Drawing.Point(143, 143);
            this.btnOverwriteAll.Name = "btnOverwriteAll";
            this.btnOverwriteAll.Size = new System.Drawing.Size(128, 24);
            this.btnOverwriteAll.TabIndex = 2;
            this.btnOverwriteAll.Text = "Overwrite &All";
            this.btnOverwriteAll.Visible = false;
            this.btnOverwriteAll.Click += new System.EventHandler(this.btnOverwriteAll_Click);
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOverwrite.Location = new System.Drawing.Point(9, 143);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(128, 24);
            this.btnOverwrite.TabIndex = 1;
            this.btnOverwrite.Text = "&Overwrite";
            this.btnOverwrite.Visible = false;
            this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRetry.Location = new System.Drawing.Point(277, 203);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(128, 24);
            this.btnRetry.TabIndex = 9;
            this.btnRetry.Text = "Re&try";
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRename.Location = new System.Drawing.Point(143, 173);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(128, 24);
            this.btnRename.TabIndex = 5;
            this.btnRename.Text = "&Rename...";
            this.btnRename.Visible = false;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSkip.Location = new System.Drawing.Point(277, 173);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(128, 24);
            this.btnSkip.TabIndex = 6;
            this.btnSkip.Text = "&Skip";
            this.btnSkip.Visible = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(343, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(8, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(463, 123);
            this.lblMessage.TabIndex = 11;
            // 
            // btnResume
            // 
            this.btnResume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnResume.Location = new System.Drawing.Point(343, 203);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(128, 24);
            this.btnResume.TabIndex = 12;
            this.btnResume.Text = "R&esume Transfer";
            this.btnResume.Visible = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnResumeAll
            // 
            this.btnResumeAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnResumeAll.Location = new System.Drawing.Point(176, 109);
            this.btnResumeAll.Name = "btnResumeAll";
            this.btnResumeAll.Size = new System.Drawing.Size(128, 24);
            this.btnResumeAll.TabIndex = 13;
            this.btnResumeAll.Text = "Resume Trans&fer All";
            this.btnResumeAll.Visible = false;
            this.btnResumeAll.Click += new System.EventHandler(this.btnResumeAll_Click);
            // 
            // btnFollowLinkAll
            // 
            this.btnFollowLinkAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFollowLinkAll.Location = new System.Drawing.Point(9, 113);
            this.btnFollowLinkAll.Name = "btnFollowLinkAll";
            this.btnFollowLinkAll.Size = new System.Drawing.Size(128, 24);
            this.btnFollowLinkAll.TabIndex = 14;
            this.btnFollowLinkAll.Text = "Follow &All Links";
            this.btnFollowLinkAll.Visible = false;
            this.btnFollowLinkAll.Click += new System.EventHandler(this.btnFollowLinkAll_Click);
            // 
            // FileOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 243);
            this.Controls.Add(this.btnFollowLinkAll);
            this.Controls.Add(this.btnResumeAll);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnFollowLink);
            this.Controls.Add(this.btnSkipAll);
            this.Controls.Add(this.btnOverwriteDiffSize);
            this.Controls.Add(this.btnOverwriteOlder);
            this.Controls.Add(this.btnOverwriteAll);
            this.Controls.Add(this.btnOverwrite);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnCancel);
            this.MinimumSize = new System.Drawing.Size(488, 270);
            this.Name = "FileOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Operation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFollowLink;
        private System.Windows.Forms.Button btnSkipAll;
        private System.Windows.Forms.Button btnOverwriteDiffSize;
        private System.Windows.Forms.Button btnOverwriteOlder;
        private System.Windows.Forms.Button btnOverwriteAll;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnResumeAll;
        private System.Windows.Forms.Button btnFollowLinkAll;
    }
}