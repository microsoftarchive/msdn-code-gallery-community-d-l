namespace ClientSample.Ftp.Security
{
    partial class CertProvider
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCertList;

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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbCertList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbValid = new System.Windows.Forms.GroupBox();
            this.lblToText = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFromText = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.grbSubject = new System.Windows.Forms.GroupBox();
            this.lblCommonNameSubText = new System.Windows.Forms.Label();
            this.lblCommonNameSub = new System.Windows.Forms.Label();
            this.lblLocationSubText = new System.Windows.Forms.Label();
            this.lblCountrySub = new System.Windows.Forms.Label();
            this.lblUnitSubText = new System.Windows.Forms.Label();
            this.lblUnitSub = new System.Windows.Forms.Label();
            this.lblOrganizationSubText = new System.Windows.Forms.Label();
            this.lblOrganizationSub = new System.Windows.Forms.Label();
            this.grbIssuer = new System.Windows.Forms.GroupBox();
            this.lblCommonNameText = new System.Windows.Forms.Label();
            this.lblCommonName = new System.Windows.Forms.Label();
            this.lblLocationText = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblUnitText = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblOrganizationText = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            this.grbValid.SuspendLayout();
            this.grbSubject.SuspendLayout();
            this.grbIssuer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(334, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(254, 300);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbCertList
            // 
            this.cbCertList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCertList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCertList.Location = new System.Drawing.Point(104, 8);
            this.cbCertList.Name = "cbCertList";
            this.cbCertList.Size = new System.Drawing.Size(305, 21);
            this.cbCertList.TabIndex = 2;
            this.cbCertList.SelectedIndexChanged += new System.EventHandler(this.cbCertList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Certificate:";
            // 
            // grbValid
            // 
            this.grbValid.Controls.Add(this.lblToText);
            this.grbValid.Controls.Add(this.lblTo);
            this.grbValid.Controls.Add(this.lblFromText);
            this.grbValid.Controls.Add(this.lblFrom);
            this.grbValid.Location = new System.Drawing.Point(9, 235);
            this.grbValid.Name = "grbValid";
            this.grbValid.Size = new System.Drawing.Size(400, 61);
            this.grbValid.TabIndex = 11;
            this.grbValid.TabStop = false;
            this.grbValid.Text = "Valid";
            // 
            // lblToText
            // 
            this.lblToText.Location = new System.Drawing.Point(93, 36);
            this.lblToText.Name = "lblToText";
            this.lblToText.Size = new System.Drawing.Size(301, 13);
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
            this.lblFromText.Location = new System.Drawing.Point(93, 17);
            this.lblFromText.Name = "lblFromText";
            this.lblFromText.Size = new System.Drawing.Size(301, 13);
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
            // grbSubject
            // 
            this.grbSubject.Controls.Add(this.lblCommonNameSubText);
            this.grbSubject.Controls.Add(this.lblCommonNameSub);
            this.grbSubject.Controls.Add(this.lblLocationSubText);
            this.grbSubject.Controls.Add(this.lblCountrySub);
            this.grbSubject.Controls.Add(this.lblUnitSubText);
            this.grbSubject.Controls.Add(this.lblUnitSub);
            this.grbSubject.Controls.Add(this.lblOrganizationSubText);
            this.grbSubject.Controls.Add(this.lblOrganizationSub);
            this.grbSubject.Location = new System.Drawing.Point(9, 133);
            this.grbSubject.Name = "grbSubject";
            this.grbSubject.Size = new System.Drawing.Size(400, 96);
            this.grbSubject.TabIndex = 10;
            this.grbSubject.TabStop = false;
            this.grbSubject.Text = "Subject";
            // 
            // lblCommonNameSubText
            // 
            this.lblCommonNameSubText.Location = new System.Drawing.Point(93, 74);
            this.lblCommonNameSubText.Name = "lblCommonNameSubText";
            this.lblCommonNameSubText.Size = new System.Drawing.Size(301, 13);
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
            this.lblLocationSubText.Location = new System.Drawing.Point(93, 55);
            this.lblLocationSubText.Name = "lblLocationSubText";
            this.lblLocationSubText.Size = new System.Drawing.Size(301, 13);
            this.lblLocationSubText.TabIndex = 5;
            this.lblLocationSubText.Text = "Country";
            // 
            // lblCountrySub
            // 
            this.lblCountrySub.Location = new System.Drawing.Point(8, 55);
            this.lblCountrySub.Name = "lblCountrySub";
            this.lblCountrySub.Size = new System.Drawing.Size(46, 13);
            this.lblCountrySub.TabIndex = 4;
            this.lblCountrySub.Text = "Country:";
            // 
            // lblUnitSubText
            // 
            this.lblUnitSubText.Location = new System.Drawing.Point(93, 36);
            this.lblUnitSubText.Name = "lblUnitSubText";
            this.lblUnitSubText.Size = new System.Drawing.Size(301, 13);
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
            this.lblOrganizationSubText.Location = new System.Drawing.Point(93, 17);
            this.lblOrganizationSubText.Name = "lblOrganizationSubText";
            this.lblOrganizationSubText.Size = new System.Drawing.Size(301, 13);
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
            // grbIssuer
            // 
            this.grbIssuer.Controls.Add(this.lblCommonNameText);
            this.grbIssuer.Controls.Add(this.lblCommonName);
            this.grbIssuer.Controls.Add(this.lblLocationText);
            this.grbIssuer.Controls.Add(this.lblCountry);
            this.grbIssuer.Controls.Add(this.lblUnitText);
            this.grbIssuer.Controls.Add(this.lblUnit);
            this.grbIssuer.Controls.Add(this.lblOrganizationText);
            this.grbIssuer.Controls.Add(this.lblOrg);
            this.grbIssuer.Location = new System.Drawing.Point(9, 35);
            this.grbIssuer.Name = "grbIssuer";
            this.grbIssuer.Size = new System.Drawing.Size(400, 96);
            this.grbIssuer.TabIndex = 9;
            this.grbIssuer.TabStop = false;
            this.grbIssuer.Text = "Issuer";
            // 
            // lblCommonNameText
            // 
            this.lblCommonNameText.Location = new System.Drawing.Point(93, 74);
            this.lblCommonNameText.Name = "lblCommonNameText";
            this.lblCommonNameText.Size = new System.Drawing.Size(301, 13);
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
            this.lblLocationText.Location = new System.Drawing.Point(93, 55);
            this.lblLocationText.Name = "lblLocationText";
            this.lblLocationText.Size = new System.Drawing.Size(301, 13);
            this.lblLocationText.TabIndex = 5;
            this.lblLocationText.Text = "Country";
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(8, 55);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(46, 13);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "Country:";
            // 
            // lblUnitText
            // 
            this.lblUnitText.Location = new System.Drawing.Point(93, 36);
            this.lblUnitText.Name = "lblUnitText";
            this.lblUnitText.Size = new System.Drawing.Size(301, 13);
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
            // lblOrganizationText
            // 
            this.lblOrganizationText.Location = new System.Drawing.Point(93, 17);
            this.lblOrganizationText.Name = "lblOrganizationText";
            this.lblOrganizationText.Size = new System.Drawing.Size(301, 13);
            this.lblOrganizationText.TabIndex = 1;
            this.lblOrganizationText.Text = "Organization:";
            // 
            // lblOrg
            // 
            this.lblOrg.Location = new System.Drawing.Point(8, 17);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(69, 13);
            this.lblOrg.TabIndex = 0;
            this.lblOrg.Text = "Organization:";
            // 
            // CertProvider
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(418, 332);
            this.ControlBox = false;
            this.Controls.Add(this.grbValid);
            this.Controls.Add(this.grbSubject);
            this.Controls.Add(this.grbIssuer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCertList);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CertProvider";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Certificate";
            this.grbValid.ResumeLayout(false);
            this.grbSubject.ResumeLayout(false);
            this.grbIssuer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbValid;
        private System.Windows.Forms.Label lblToText;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFromText;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox grbSubject;
        private System.Windows.Forms.Label lblCommonNameSubText;
        private System.Windows.Forms.Label lblCommonNameSub;
        private System.Windows.Forms.Label lblLocationSubText;
        private System.Windows.Forms.Label lblCountrySub;
        private System.Windows.Forms.Label lblUnitSubText;
        private System.Windows.Forms.Label lblUnitSub;
        private System.Windows.Forms.Label lblOrganizationSubText;
        private System.Windows.Forms.Label lblOrganizationSub;
        private System.Windows.Forms.GroupBox grbIssuer;
        private System.Windows.Forms.Label lblCommonNameText;
        private System.Windows.Forms.Label lblCommonName;
        private System.Windows.Forms.Label lblLocationText;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblUnitText;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblOrganizationText;
        private System.Windows.Forms.Label lblOrg;
    }
}