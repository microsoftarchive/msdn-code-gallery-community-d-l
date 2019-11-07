namespace TestDB2Demo
{
    partial class frmDB2Demo
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
            this.tabDemoControl = new System.Windows.Forms.TabControl();
            this.tabPublishData = new System.Windows.Forms.TabPage();
            this.btnPublishData = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSQLConnection = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDB2Connection = new System.Windows.Forms.Button();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPortNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabDemoControl.SuspendLayout();
            this.tabPublishData.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDemoControl
            // 
            this.tabDemoControl.Controls.Add(this.tabPublishData);
            this.tabDemoControl.Controls.Add(this.tabConfiguration);
            this.tabDemoControl.Location = new System.Drawing.Point(12, 12);
            this.tabDemoControl.Name = "tabDemoControl";
            this.tabDemoControl.SelectedIndex = 0;
            this.tabDemoControl.Size = new System.Drawing.Size(536, 356);
            this.tabDemoControl.TabIndex = 0;
            // 
            // tabPublishData
            // 
            this.tabPublishData.Controls.Add(this.btnPublishData);
            this.tabPublishData.Controls.Add(this.label12);
            this.tabPublishData.Controls.Add(this.cmbTransactionType);
            this.tabPublishData.Location = new System.Drawing.Point(4, 22);
            this.tabPublishData.Name = "tabPublishData";
            this.tabPublishData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPublishData.Size = new System.Drawing.Size(528, 330);
            this.tabPublishData.TabIndex = 0;
            this.tabPublishData.Text = "Import Data";
            this.tabPublishData.UseVisualStyleBackColor = true;
            // 
            // btnPublishData
            // 
            this.btnPublishData.Location = new System.Drawing.Point(253, 96);
            this.btnPublishData.Name = "btnPublishData";
            this.btnPublishData.Size = new System.Drawing.Size(101, 23);
            this.btnPublishData.TabIndex = 2;
            this.btnPublishData.Text = "Import Data";
            this.btnPublishData.UseVisualStyleBackColor = true;
            this.btnPublishData.Click += new System.EventHandler(this.btnPublishData_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(7, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Select Transaction Type:";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Items.AddRange(new object[] {
            "Deposits",
            "Loans"});
            this.cmbTransactionType.Location = new System.Drawing.Point(154, 21);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(200, 21);
            this.cmbTransactionType.TabIndex = 1;
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.label2);
            this.tabConfiguration.Controls.Add(this.label1);
            this.tabConfiguration.Controls.Add(this.groupBox2);
            this.tabConfiguration.Controls.Add(this.groupBox1);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(528, 330);
            this.tabConfiguration.TabIndex = 1;
            this.tabConfiguration.Text = "Configure Application";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(515, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Configure application here so that it will communicate with SQL Server Database";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(515, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configure application here so that it will communicate with IBM DB2 Database";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSQLConnection);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtUId);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDBName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDataSource);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 112);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL Server Configuration";
            // 
            // btnSQLConnection
            // 
            this.btnSQLConnection.Location = new System.Drawing.Point(368, 80);
            this.btnSQLConnection.Name = "btnSQLConnection";
            this.btnSQLConnection.Size = new System.Drawing.Size(142, 23);
            this.btnSQLConnection.TabIndex = 8;
            this.btnSQLConnection.Text = "Test Connection";
            this.btnSQLConnection.UseVisualStyleBackColor = true;
            this.btnSQLConnection.Click += new System.EventHandler(this.btnSQLConnection_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(368, 54);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(142, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(273, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Password:";
            // 
            // txtUId
            // 
            this.txtUId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUId.Location = new System.Drawing.Point(101, 54);
            this.txtUId.MaxLength = 20;
            this.txtUId.Name = "txtUId";
            this.txtUId.Size = new System.Drawing.Size(154, 20);
            this.txtUId.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "User Id:";
            // 
            // txtDBName
            // 
            this.txtDBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDBName.Location = new System.Drawing.Point(368, 19);
            this.txtDBName.MaxLength = 20;
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(142, 20);
            this.txtDBName.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(273, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Database Name:";
            // 
            // txtDataSource
            // 
            this.txtDataSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataSource.Location = new System.Drawing.Point(101, 19);
            this.txtDataSource.MaxLength = 20;
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(154, 20);
            this.txtDataSource.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Data Source:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDB2Connection);
            this.groupBox1.Controls.Add(this.txtDatabaseName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPortNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHostName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 141);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IBM DB2 Configuration";
            // 
            // btnDB2Connection
            // 
            this.btnDB2Connection.Location = new System.Drawing.Point(362, 112);
            this.btnDB2Connection.Name = "btnDB2Connection";
            this.btnDB2Connection.Size = new System.Drawing.Size(148, 23);
            this.btnDB2Connection.TabIndex = 10;
            this.btnDB2Connection.Text = "Test Connection";
            this.btnDB2Connection.UseVisualStyleBackColor = true;
            this.btnDB2Connection.Click += new System.EventHandler(this.btnDB2Connection_Click);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabaseName.Location = new System.Drawing.Point(113, 88);
            this.txtDatabaseName.MaxLength = 20;
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(154, 20);
            this.txtDatabaseName.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Database Name:";
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Location = new System.Drawing.Point(362, 52);
            this.txtPwd.MaxLength = 20;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(148, 20);
            this.txtPwd.TabIndex = 7;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(285, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password:";
            // 
            // txtUserId
            // 
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserId.Location = new System.Drawing.Point(113, 52);
            this.txtUserId.MaxLength = 20;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(154, 20);
            this.txtUserId.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "User Id:";
            // 
            // txtPortNumber
            // 
            this.txtPortNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPortNumber.Location = new System.Drawing.Point(362, 18);
            this.txtPortNumber.MaxLength = 5;
            this.txtPortNumber.Name = "txtPortNumber";
            this.txtPortNumber.Size = new System.Drawing.Size(148, 20);
            this.txtPortNumber.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(285, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Port Number:";
            // 
            // txtHostName
            // 
            this.txtHostName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHostName.Location = new System.Drawing.Point(113, 17);
            this.txtHostName.MaxLength = 20;
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(154, 20);
            this.txtHostName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Host Name:";
            // 
            // frmDB2Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 374);
            this.Controls.Add(this.tabDemoControl);
            this.MaximizeBox = false;
            this.Name = "frmDB2Demo";
            this.Text = "Import from DB2 Utility";
            this.Load += new System.EventHandler(this.frmDB2Demo_Load);
            this.tabDemoControl.ResumeLayout(false);
            this.tabPublishData.ResumeLayout(false);
            this.tabPublishData.PerformLayout();
            this.tabConfiguration.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDemoControl;
        private System.Windows.Forms.TabPage tabPublishData;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPortNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Button btnPublishData;
        private System.Windows.Forms.Button btnSQLConnection;
        private System.Windows.Forms.Button btnDB2Connection;
    }
}