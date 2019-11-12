// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace SyncApplication
{
    partial class ProgressForm
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
            this.listSyncProgress = new System.Windows.Forms.ListBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listSyncProgress
            // 
            this.listSyncProgress.FormattingEnabled = true;
            this.listSyncProgress.Location = new System.Drawing.Point(22, 39);
            this.listSyncProgress.Name = "listSyncProgress";
            this.listSyncProgress.Size = new System.Drawing.Size(440, 381);
            this.listSyncProgress.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Enabled = false;
            this.buttonClose.Location = new System.Drawing.Point(337, 447);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(125, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 489);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listSyncProgress);
            this.Name = "ProgressForm";
            this.Text = "Synchronization Progress";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        public System.Windows.Forms.ListBox listSyncProgress;
    }
}