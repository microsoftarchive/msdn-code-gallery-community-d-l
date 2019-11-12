using System;
namespace SyncApplication
{
    partial class CESharingForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.peerTabsControl = new System.Windows.Forms.TabControl();
            this.serverTab = new System.Windows.Forms.TabPage();
            this.synchronizeBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.syncStats = new System.Windows.Forms.TextBox();
            this.addCEBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.srcProviderComboBox = new System.Windows.Forms.ComboBox();
            this.destProviderComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.batchSizeTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.batchSpoolLocation = new System.Windows.Forms.TextBox();
            this.batchSizeTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.changeBatchLocationBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.batchLocationTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.TablesViewCtrl = new SyncApplication.TablesViewControl();
            this.peerTabsControl.SuspendLayout();
            this.serverTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Oracle to Sql CE Data Synchronization";
            // 
            // peerTabsControl
            // 
            this.peerTabsControl.Controls.Add(this.serverTab);
            this.peerTabsControl.Location = new System.Drawing.Point(2, 98);
            this.peerTabsControl.Name = "peerTabsControl";
            this.peerTabsControl.SelectedIndex = 0;
            this.peerTabsControl.Size = new System.Drawing.Size(727, 335);
            this.peerTabsControl.TabIndex = 16;
            this.peerTabsControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.peerTabsControl_Selected);
            // 
            // serverTab
            // 
            this.serverTab.Controls.Add(this.TablesViewCtrl);
            this.serverTab.Location = new System.Drawing.Point(4, 22);
            this.serverTab.Name = "serverTab";
            this.serverTab.Padding = new System.Windows.Forms.Padding(3);
            this.serverTab.Size = new System.Drawing.Size(719, 309);
            this.serverTab.TabIndex = 0;
            this.serverTab.Text = "Server";
            this.serverTab.UseVisualStyleBackColor = true;
            // 
            // synchronizeBtn
            // 
            this.synchronizeBtn.Location = new System.Drawing.Point(7, 439);
            this.synchronizeBtn.Name = "synchronizeBtn";
            this.synchronizeBtn.Size = new System.Drawing.Size(75, 23);
            this.synchronizeBtn.TabIndex = 17;
            this.synchronizeBtn.Text = "&Synchronize";
            this.synchronizeBtn.UseVisualStyleBackColor = true;
            this.synchronizeBtn.Click += new System.EventHandler(this.synchronizeBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Sync Stats:";
            // 
            // syncStats
            // 
            this.syncStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.syncStats.Location = new System.Drawing.Point(104, 473);
            this.syncStats.Name = "syncStats";
            this.syncStats.ReadOnly = true;
            this.syncStats.Size = new System.Drawing.Size(489, 13);
            this.syncStats.TabIndex = 19;
            // 
            // addCEBtn
            // 
            this.addCEBtn.Location = new System.Drawing.Point(596, 32);
            this.addCEBtn.Name = "addCEBtn";
            this.addCEBtn.Size = new System.Drawing.Size(81, 23);
            this.addCEBtn.TabIndex = 20;
            this.addCEBtn.Text = "&Add CE Client";
            this.addCEBtn.UseVisualStyleBackColor = true;
            this.addCEBtn.Click += new System.EventHandler(this.addCEBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Source Provider:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Destination Provider:";
            // 
            // srcProviderComboBox
            // 
            this.srcProviderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.srcProviderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.srcProviderComboBox.FormattingEnabled = true;
            this.srcProviderComboBox.Items.AddRange(new object[] {
            "Server"});
            this.srcProviderComboBox.Location = new System.Drawing.Point(203, 441);
            this.srcProviderComboBox.Name = "srcProviderComboBox";
            this.srcProviderComboBox.Size = new System.Drawing.Size(127, 21);
            this.srcProviderComboBox.TabIndex = 23;
            this.srcProviderComboBox.Text = "Server";
            this.srcProviderComboBox.SelectedIndexChanged += new System.EventHandler(this.srcProviderComboBox_SelectedIndexChanged);
            // 
            // destProviderComboBox
            // 
            this.destProviderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.destProviderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.destProviderComboBox.FormattingEnabled = true;
            this.destProviderComboBox.Items.AddRange(new object[] {
            "Server"});
            this.destProviderComboBox.Location = new System.Drawing.Point(487, 441);
            this.destProviderComboBox.Name = "destProviderComboBox";
            this.destProviderComboBox.Size = new System.Drawing.Size(127, 21);
            this.destProviderComboBox.TabIndex = 24;
            this.destProviderComboBox.Text = "Server";
            this.destProviderComboBox.SelectedIndexChanged += new System.EventHandler(this.destProviderComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Batch Size (KB)";
            // 
            // batchSizeTxtBox
            // 
            this.batchSizeTxtBox.Location = new System.Drawing.Point(158, 35);
            this.batchSizeTxtBox.Name = "batchSizeTxtBox";
            this.batchSizeTxtBox.Size = new System.Drawing.Size(74, 20);
            this.batchSizeTxtBox.TabIndex = 26;
            this.batchSizeTxtBox.Text = "0";
            this.batchSizeTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.batchSizeTxtBox.Leave += new System.EventHandler(this.batchSizeTxtBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Batch Spooling Directory";
            // 
            // batchSpoolLocation
            // 
            this.batchSpoolLocation.Location = new System.Drawing.Point(158, 66);
            this.batchSpoolLocation.Name = "batchSpoolLocation";
            this.batchSpoolLocation.Size = new System.Drawing.Size(420, 20);
            this.batchSpoolLocation.TabIndex = 1;
            this.batchSpoolLocation.Leave += new System.EventHandler(this.batchSpoolLocation_Leave);
            // 
            // batchSizeTooltip
            // 
            this.batchSizeTooltip.AutoPopDelay = 5000;
            this.batchSizeTooltip.InitialDelay = 100;
            this.batchSizeTooltip.IsBalloon = true;
            this.batchSizeTooltip.ReshowDelay = 100;
            // 
            // changeBatchLocationBtn
            // 
            this.changeBatchLocationBtn.Location = new System.Drawing.Point(596, 64);
            this.changeBatchLocationBtn.Name = "changeBatchLocationBtn";
            this.changeBatchLocationBtn.Size = new System.Drawing.Size(81, 23);
            this.changeBatchLocationBtn.TabIndex = 28;
            this.changeBatchLocationBtn.Text = "&Change";
            this.changeBatchLocationBtn.UseVisualStyleBackColor = true;
            this.changeBatchLocationBtn.Click += new System.EventHandler(this.changeBatchLocationBtn_Click);
            // 
            // batchLocationTooltip
            // 
            this.batchLocationTooltip.AutoPopDelay = 5000;
            this.batchLocationTooltip.InitialDelay = 100;
            this.batchLocationTooltip.IsBalloon = true;
            this.batchLocationTooltip.ReshowDelay = 100;
            // 
            // TablesViewCtrl
            // 
            this.TablesViewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablesViewCtrl.Location = new System.Drawing.Point(3, 3);
            this.TablesViewCtrl.Name = "TablesViewCtrl";
            this.TablesViewCtrl.Size = new System.Drawing.Size(713, 303);
            this.TablesViewCtrl.TabIndex = 0;
            // 
            // CESharingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 497);
            this.Controls.Add(this.changeBatchLocationBtn);
            this.Controls.Add(this.batchSpoolLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.batchSizeTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.destProviderComboBox);
            this.Controls.Add(this.srcProviderComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addCEBtn);
            this.Controls.Add(this.syncStats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.synchronizeBtn);
            this.Controls.Add(this.peerTabsControl);
            this.Controls.Add(this.label4);
            this.Name = "CESharingForm";
            this.Text = "Share\'em - Oracle to Sql CE Data Synchronization Demo Application";
            this.Shown += new System.EventHandler(this.CESharingForm_Shown);
            this.peerTabsControl.ResumeLayout(false);
            this.serverTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl peerTabsControl;
        private System.Windows.Forms.TabPage serverTab;
        private System.Windows.Forms.Button synchronizeBtn;
        private System.Windows.Forms.Label label2;
        private TablesViewControl TablesViewCtrl;
        private System.Windows.Forms.TextBox syncStats;
        private System.Windows.Forms.Button addCEBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox srcProviderComboBox;
        private System.Windows.Forms.ComboBox destProviderComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox batchSizeTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox batchSpoolLocation;
        private System.Windows.Forms.ToolTip batchSizeTooltip;
        private System.Windows.Forms.Button changeBatchLocationBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolTip batchLocationTooltip;
    }
}