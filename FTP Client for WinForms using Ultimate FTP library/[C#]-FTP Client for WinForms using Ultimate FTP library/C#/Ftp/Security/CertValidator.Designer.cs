namespace ClientSample.Ftp.Security
{
    partial class CertValidator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertValidator));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnTrusted = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbIssuer = new System.Windows.Forms.GroupBox();
            this.lblCommonNameText = new System.Windows.Forms.Label();
            this.lblCommonName = new System.Windows.Forms.Label();
            this.lblLocationText = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblUnitText = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblIssuerText = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            this.grbSubject = new System.Windows.Forms.GroupBox();
            this.lblCommonNameSubText = new System.Windows.Forms.Label();
            this.lblCommonNameSub = new System.Windows.Forms.Label();
            this.lblLocationSubText = new System.Windows.Forms.Label();
            this.lblLocationSub = new System.Windows.Forms.Label();
            this.lblUnitSubText = new System.Windows.Forms.Label();
            this.lblUnitSub = new System.Windows.Forms.Label();
            this.lblOrganizationSubText = new System.Windows.Forms.Label();
            this.lblOrganizationSub = new System.Windows.Forms.Label();
            this.grbValid = new System.Windows.Forms.GroupBox();
            this.lblToText = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFromText = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtIssues = new System.Windows.Forms.TextBox();
            this.lblIssues = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbIssuer.SuspendLayout();
            this.grbSubject.SuspendLayout();
            this.grbValid.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Location = new System.Drawing.Point(337, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Reject";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Location = new System.Drawing.Point(257, 375);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Accept";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnTrusted
            // 
            this.btnTrusted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrusted.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnTrusted.Location = new System.Drawing.Point(74, 375);
            this.btnTrusted.Name = "btnTrusted";
            this.btnTrusted.Size = new System.Drawing.Size(177, 23);
            this.btnTrusted.TabIndex = 1;
            this.btnTrusted.Text = "Accept and add to Trusted List";
            this.btnTrusted.Click += new System.EventHandler(this.btnTrusted_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(380, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 26);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // grbIssuer
            // 
            this.grbIssuer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbIssuer.Controls.Add(this.lblCommonNameText);
            this.grbIssuer.Controls.Add(this.lblCommonName);
            this.grbIssuer.Controls.Add(this.lblLocationText);
            this.grbIssuer.Controls.Add(this.lblCountry);
            this.grbIssuer.Controls.Add(this.lblUnitText);
            this.grbIssuer.Controls.Add(this.lblUnit);
            this.grbIssuer.Controls.Add(this.lblIssuerText);
            this.grbIssuer.Controls.Add(this.lblOrg);
            this.grbIssuer.Location = new System.Drawing.Point(12, 105);
            this.grbIssuer.Name = "grbIssuer";
            this.grbIssuer.Size = new System.Drawing.Size(400, 96);
            this.grbIssuer.TabIndex = 4;
            this.grbIssuer.TabStop = false;
            this.grbIssuer.Text = "Issuer";
            // 
            // lblCommonNameText
            // 
            this.lblCommonNameText.Location = new System.Drawing.Point(97, 74);
            this.lblCommonNameText.Name = "lblCommonNameText";
            this.lblCommonNameText.Size = new System.Drawing.Size(297, 13);
            this.lblCommonNameText.TabIndex = 7;
            this.lblCommonNameText.Text = "Common Name";
            // 
            // lblCommonName
            // 
            this.lblCommonName.Location = new System.Drawing.Point(8, 74);
            this.lblCommonName.Name = "lblCommonName";
            this.lblCommonName.Size = new System.Drawing.Size(82, 13);
            this.lblCommonName.TabIndex = 6;
            this.lblCommonName.Text = "Common Name:";
            // 
            // lblLocationText
            // 
            this.lblLocationText.Location = new System.Drawing.Point(97, 55);
            this.lblLocationText.Name = "lblLocationText";
            this.lblLocationText.Size = new System.Drawing.Size(297, 13);
            this.lblLocationText.TabIndex = 5;
            this.lblLocationText.Text = "Country";
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(8, 55);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(51, 13);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "Location:";
            // 
            // lblUnitText
            // 
            this.lblUnitText.Location = new System.Drawing.Point(97, 36);
            this.lblUnitText.Name = "lblUnitText";
            this.lblUnitText.Size = new System.Drawing.Size(297, 13);
            this.lblUnitText.TabIndex = 3;
            this.lblUnitText.Text = "Unit";
            // 
            // lblUnit
            // 
            this.lblUnit.Location = new System.Drawing.Point(8, 36);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 13);
            this.lblUnit.TabIndex = 2;
            this.lblUnit.Text = "Unit:";
            // 
            // lblIssuerText
            // 
            this.lblIssuerText.Location = new System.Drawing.Point(97, 17);
            this.lblIssuerText.Name = "lblIssuerText";
            this.lblIssuerText.Size = new System.Drawing.Size(297, 13);
            this.lblIssuerText.TabIndex = 1;
            this.lblIssuerText.Text = "Organization:";
            // 
            // lblOrg
            // 
            this.lblOrg.Location = new System.Drawing.Point(8, 17);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(69, 13);
            this.lblOrg.TabIndex = 0;
            this.lblOrg.Text = "Organization:";
            // 
            // grbSubject
            // 
            this.grbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbSubject.Controls.Add(this.lblCommonNameSubText);
            this.grbSubject.Controls.Add(this.lblCommonNameSub);
            this.grbSubject.Controls.Add(this.lblLocationSubText);
            this.grbSubject.Controls.Add(this.lblLocationSub);
            this.grbSubject.Controls.Add(this.lblUnitSubText);
            this.grbSubject.Controls.Add(this.lblUnitSub);
            this.grbSubject.Controls.Add(this.lblOrganizationSubText);
            this.grbSubject.Controls.Add(this.lblOrganizationSub);
            this.grbSubject.Location = new System.Drawing.Point(12, 203);
            this.grbSubject.Name = "grbSubject";
            this.grbSubject.Size = new System.Drawing.Size(400, 96);
            this.grbSubject.TabIndex = 5;
            this.grbSubject.TabStop = false;
            this.grbSubject.Text = "Subject";
            // 
            // lblCommonNameSubText
            // 
            this.lblCommonNameSubText.Location = new System.Drawing.Point(97, 74);
            this.lblCommonNameSubText.Name = "lblCommonNameSubText";
            this.lblCommonNameSubText.Size = new System.Drawing.Size(297, 13);
            this.lblCommonNameSubText.TabIndex = 7;
            this.lblCommonNameSubText.Text = "Common Name";
            // 
            // lblCommonNameSub
            // 
            this.lblCommonNameSub.Location = new System.Drawing.Point(8, 74);
            this.lblCommonNameSub.Name = "lblCommonNameSub";
            this.lblCommonNameSub.Size = new System.Drawing.Size(82, 13);
            this.lblCommonNameSub.TabIndex = 6;
            this.lblCommonNameSub.Text = "Common Name:";
            // 
            // lblLocationSubText
            // 
            this.lblLocationSubText.Location = new System.Drawing.Point(97, 55);
            this.lblLocationSubText.Name = "lblLocationSubText";
            this.lblLocationSubText.Size = new System.Drawing.Size(297, 13);
            this.lblLocationSubText.TabIndex = 5;
            this.lblLocationSubText.Text = "Country";
            // 
            // lblLocationSub
            // 
            this.lblLocationSub.Location = new System.Drawing.Point(8, 55);
            this.lblLocationSub.Name = "lblLocationSub";
            this.lblLocationSub.Size = new System.Drawing.Size(51, 13);
            this.lblLocationSub.TabIndex = 4;
            this.lblLocationSub.Text = "Location:";
            // 
            // lblUnitSubText
            // 
            this.lblUnitSubText.Location = new System.Drawing.Point(97, 36);
            this.lblUnitSubText.Name = "lblUnitSubText";
            this.lblUnitSubText.Size = new System.Drawing.Size(297, 13);
            this.lblUnitSubText.TabIndex = 3;
            this.lblUnitSubText.Text = "Unit";
            // 
            // lblUnitSub
            // 
            this.lblUnitSub.Location = new System.Drawing.Point(8, 36);
            this.lblUnitSub.Name = "lblUnitSub";
            this.lblUnitSub.Size = new System.Drawing.Size(29, 13);
            this.lblUnitSub.TabIndex = 2;
            this.lblUnitSub.Text = "Unit:";
            // 
            // lblOrganizationSubText
            // 
            this.lblOrganizationSubText.Location = new System.Drawing.Point(97, 17);
            this.lblOrganizationSubText.Name = "lblOrganizationSubText";
            this.lblOrganizationSubText.Size = new System.Drawing.Size(297, 13);
            this.lblOrganizationSubText.TabIndex = 1;
            this.lblOrganizationSubText.Text = "Organization:";
            // 
            // lblOrganizationSub
            // 
            this.lblOrganizationSub.Location = new System.Drawing.Point(8, 17);
            this.lblOrganizationSub.Name = "lblOrganizationSub";
            this.lblOrganizationSub.Size = new System.Drawing.Size(69, 13);
            this.lblOrganizationSub.TabIndex = 0;
            this.lblOrganizationSub.Text = "Organization:";
            // 
            // grbValid
            // 
            this.grbValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbValid.Controls.Add(this.lblToText);
            this.grbValid.Controls.Add(this.lblTo);
            this.grbValid.Controls.Add(this.lblFromText);
            this.grbValid.Controls.Add(this.lblFrom);
            this.grbValid.Location = new System.Drawing.Point(12, 305);
            this.grbValid.Name = "grbValid";
            this.grbValid.Size = new System.Drawing.Size(400, 61);
            this.grbValid.TabIndex = 8;
            this.grbValid.TabStop = false;
            this.grbValid.Text = "Valid";
            // 
            // lblToText
            // 
            this.lblToText.Location = new System.Drawing.Point(97, 36);
            this.lblToText.Name = "lblToText";
            this.lblToText.Size = new System.Drawing.Size(297, 13);
            this.lblToText.TabIndex = 3;
            this.lblToText.Text = "To";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(8, 36);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // lblFromText
            // 
            this.lblFromText.Location = new System.Drawing.Point(97, 17);
            this.lblFromText.Name = "lblFromText";
            this.lblFromText.Size = new System.Drawing.Size(297, 13);
            this.lblFromText.TabIndex = 1;
            this.lblFromText.Text = "From";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(8, 17);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // txtIssues
            // 
            this.txtIssues.BackColor = System.Drawing.Color.White;
            this.txtIssues.Location = new System.Drawing.Point(12, 42);
            this.txtIssues.Multiline = true;
            this.txtIssues.Name = "txtIssues";
            this.txtIssues.ReadOnly = true;
            this.txtIssues.Size = new System.Drawing.Size(400, 57);
            this.txtIssues.TabIndex = 0;
            // 
            // lblIssues
            // 
            this.lblIssues.Location = new System.Drawing.Point(9, 17);
            this.lblIssues.Name = "lblIssues";
            this.lblIssues.Size = new System.Drawing.Size(90, 13);
            this.lblIssues.TabIndex = 10;
            this.lblIssues.Text = "Certificate Issues:";
            // 
            // CertValidator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 407);
            this.ControlBox = false;
            this.Controls.Add(this.lblIssues);
            this.Controls.Add(this.txtIssues);
            this.Controls.Add(this.grbValid);
            this.Controls.Add(this.grbSubject);
            this.Controls.Add(this.grbIssuer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTrusted);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CertValidator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificate Validation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbIssuer.ResumeLayout(false);
            this.grbSubject.ResumeLayout(false);
            this.grbValid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrusted;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grbIssuer;
        private System.Windows.Forms.Label lblCommonNameText;
        private System.Windows.Forms.Label lblCommonName;
        private System.Windows.Forms.Label lblLocationText;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblUnitText;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblIssuerText;
        private System.Windows.Forms.Label lblOrg;
        private System.Windows.Forms.GroupBox grbSubject;
        private System.Windows.Forms.Label lblCommonNameSubText;
        private System.Windows.Forms.Label lblCommonNameSub;
        private System.Windows.Forms.Label lblLocationSubText;
        private System.Windows.Forms.Label lblLocationSub;
        private System.Windows.Forms.Label lblUnitSubText;
        private System.Windows.Forms.Label lblUnitSub;
        private System.Windows.Forms.Label lblOrganizationSubText;
        private System.Windows.Forms.Label lblOrganizationSub;
        private System.Windows.Forms.GroupBox grbValid;
        private System.Windows.Forms.Label lblToText;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFromText;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtIssues;
        private System.Windows.Forms.Label lblIssues;
    }
}