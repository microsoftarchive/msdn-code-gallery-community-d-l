namespace SMO_UserInterfaceDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxServerNames = new System.Windows.Forms.ListBox();
            this.listBoxDatabaseNames = new System.Windows.Forms.ListBox();
            this.listBoxTableNames = new System.Windows.Forms.ListBox();
            this.lblInstalledPath = new System.Windows.Forms.Label();
            this.cmdColumnsForTable = new System.Windows.Forms.Button();
            this.cmdDatabaseNames = new System.Windows.Forms.Button();
            this.cmdAvailableServers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxServerNames
            // 
            this.listBoxServerNames.FormattingEnabled = true;
            this.listBoxServerNames.Location = new System.Drawing.Point(13, 37);
            this.listBoxServerNames.Name = "listBoxServerNames";
            this.listBoxServerNames.Size = new System.Drawing.Size(260, 82);
            this.listBoxServerNames.TabIndex = 1;
            // 
            // listBoxDatabaseNames
            // 
            this.listBoxDatabaseNames.FormattingEnabled = true;
            this.listBoxDatabaseNames.Location = new System.Drawing.Point(13, 154);
            this.listBoxDatabaseNames.Name = "listBoxDatabaseNames";
            this.listBoxDatabaseNames.Size = new System.Drawing.Size(260, 82);
            this.listBoxDatabaseNames.TabIndex = 2;
            // 
            // listBoxTableNames
            // 
            this.listBoxTableNames.FormattingEnabled = true;
            this.listBoxTableNames.Location = new System.Drawing.Point(279, 154);
            this.listBoxTableNames.Name = "listBoxTableNames";
            this.listBoxTableNames.Size = new System.Drawing.Size(260, 82);
            this.listBoxTableNames.TabIndex = 4;
            // 
            // lblInstalledPath
            // 
            this.lblInstalledPath.AutoSize = true;
            this.lblInstalledPath.Location = new System.Drawing.Point(12, 9);
            this.lblInstalledPath.Name = "lblInstalledPath";
            this.lblInstalledPath.Size = new System.Drawing.Size(57, 13);
            this.lblInstalledPath.TabIndex = 5;
            this.lblInstalledPath.Text = "install path";
            // 
            // cmdColumnsForTable
            // 
            this.cmdColumnsForTable.Image = global::SMO_UserInterfaceDemo.Properties.Resources.Column_16x;
            this.cmdColumnsForTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdColumnsForTable.Location = new System.Drawing.Point(279, 242);
            this.cmdColumnsForTable.Name = "cmdColumnsForTable";
            this.cmdColumnsForTable.Size = new System.Drawing.Size(260, 23);
            this.cmdColumnsForTable.TabIndex = 6;
            this.cmdColumnsForTable.Text = "Columns";
            this.cmdColumnsForTable.UseVisualStyleBackColor = true;
            this.cmdColumnsForTable.Click += new System.EventHandler(this.cmdColumnsForTable_Click);
            // 
            // cmdDatabaseNames
            // 
            this.cmdDatabaseNames.Image = global::SMO_UserInterfaceDemo.Properties.Resources.SQLDatabase_16x;
            this.cmdDatabaseNames.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDatabaseNames.Location = new System.Drawing.Point(13, 242);
            this.cmdDatabaseNames.Name = "cmdDatabaseNames";
            this.cmdDatabaseNames.Size = new System.Drawing.Size(260, 23);
            this.cmdDatabaseNames.TabIndex = 3;
            this.cmdDatabaseNames.Text = "Database names";
            this.cmdDatabaseNames.UseVisualStyleBackColor = true;
            this.cmdDatabaseNames.Click += new System.EventHandler(this.cmdDatabaseNames_Click);
            // 
            // cmdAvailableServers
            // 
            this.cmdAvailableServers.Image = global::SMO_UserInterfaceDemo.Properties.Resources.ServerProject_16x;
            this.cmdAvailableServers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAvailableServers.Location = new System.Drawing.Point(13, 125);
            this.cmdAvailableServers.Name = "cmdAvailableServers";
            this.cmdAvailableServers.Size = new System.Drawing.Size(260, 23);
            this.cmdAvailableServers.TabIndex = 0;
            this.cmdAvailableServers.Text = "Available Servers";
            this.cmdAvailableServers.UseVisualStyleBackColor = true;
            this.cmdAvailableServers.Click += new System.EventHandler(this.cmdAvailableServers_ClickAsync);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(285, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 108);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This area is empty :-)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 307);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdColumnsForTable);
            this.Controls.Add(this.lblInstalledPath);
            this.Controls.Add(this.listBoxTableNames);
            this.Controls.Add(this.cmdDatabaseNames);
            this.Controls.Add(this.listBoxDatabaseNames);
            this.Controls.Add(this.listBoxServerNames);
            this.Controls.Add(this.cmdAvailableServers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL-Server Management Objects";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAvailableServers;
        private System.Windows.Forms.ListBox listBoxServerNames;
        private System.Windows.Forms.ListBox listBoxDatabaseNames;
        private System.Windows.Forms.Button cmdDatabaseNames;
        private System.Windows.Forms.ListBox listBoxTableNames;
        private System.Windows.Forms.Label lblInstalledPath;
        private System.Windows.Forms.Button cmdColumnsForTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

