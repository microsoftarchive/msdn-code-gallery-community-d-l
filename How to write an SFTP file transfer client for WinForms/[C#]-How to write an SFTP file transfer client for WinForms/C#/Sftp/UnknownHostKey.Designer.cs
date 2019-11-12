namespace ClientSample.Sftp
{
    partial class UnknownHostKey
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grbSep = new System.Windows.Forms.GroupBox();
            this.lblHostLeft = new System.Windows.Forms.Label();
            this.lblPortTitle = new System.Windows.Forms.Label();
            this.lblFingerprintTitle = new System.Windows.Forms.Label();
            this.lblFingerprint = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnAlwaysAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Location = new System.Drawing.Point(6, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(412, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "The server\'s host key is unknown. You have no guarantee that the server is the co" +
                "mputer you think it is.\r\nDo you want to trust this host and carry on connecting?" +
                "";
            // 
            // grbSep
            // 
            this.grbSep.Location = new System.Drawing.Point(11, 52);
            this.grbSep.Name = "grbSep";
            this.grbSep.Size = new System.Drawing.Size(407, 2);
            this.grbSep.TabIndex = 1;
            this.grbSep.TabStop = false;
            // 
            // lblHostLeft
            // 
            this.lblHostLeft.Location = new System.Drawing.Point(7, 61);
            this.lblHostLeft.Name = "lblHostLeft";
            this.lblHostLeft.Size = new System.Drawing.Size(32, 13);
            this.lblHostLeft.TabIndex = 2;
            this.lblHostLeft.Text = "Host:";
            // 
            // lblPortTitle
            // 
            this.lblPortTitle.Location = new System.Drawing.Point(7, 80);
            this.lblPortTitle.Name = "lblPortTitle";
            this.lblPortTitle.Size = new System.Drawing.Size(29, 13);
            this.lblPortTitle.TabIndex = 3;
            this.lblPortTitle.Text = "Port:";
            // 
            // lblFingerprintTitle
            // 
            this.lblFingerprintTitle.Location = new System.Drawing.Point(7, 99);
            this.lblFingerprintTitle.Name = "lblFingerprintTitle";
            this.lblFingerprintTitle.Size = new System.Drawing.Size(59, 13);
            this.lblFingerprintTitle.TabIndex = 4;
            this.lblFingerprintTitle.Text = "Fingerprint:";
            // 
            // lblFingerprint
            // 
            this.lblFingerprint.AutoSize = true;
            this.lblFingerprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFingerprint.Location = new System.Drawing.Point(70, 99);
            this.lblFingerprint.Name = "lblFingerprint";
            this.lblFingerprint.Size = new System.Drawing.Size(71, 13);
            this.lblFingerprint.TabIndex = 7;
            this.lblFingerprint.Text = "Fingerprint:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(70, 80);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 13);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port:";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(70, 61);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(37, 13);
            this.lblHost.TabIndex = 5;
            this.lblHost.Text = "Host:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(9, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 2);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnReject
            // 
            this.btnReject.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReject.Location = new System.Drawing.Point(344, 133);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "&Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(263, 133);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnAlwaysAccept
            // 
            this.btnAlwaysAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAlwaysAccept.Location = new System.Drawing.Point(157, 133);
            this.btnAlwaysAccept.Name = "btnAlwaysAccept";
            this.btnAlwaysAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAlwaysAccept.TabIndex = 2;
            this.btnAlwaysAccept.Text = "Always Accep&t";
            this.btnAlwaysAccept.Click += new System.EventHandler(this.btnAlwaysAccept_Click);
            // 
            // UnknownHostKey
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReject;
            this.ClientSize = new System.Drawing.Size(427, 165);
            this.Controls.Add(this.btnAlwaysAccept);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFingerprint);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lblFingerprintTitle);
            this.Controls.Add(this.lblPortTitle);
            this.Controls.Add(this.lblHostLeft);
            this.Controls.Add(this.grbSep);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnknownHostKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unknown Host Key";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grbSep;
        private System.Windows.Forms.Label lblHostLeft;
        private System.Windows.Forms.Label lblPortTitle;
        private System.Windows.Forms.Label lblFingerprintTitle;
        private System.Windows.Forms.Label lblFingerprint;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnAlwaysAccept;
    }
}