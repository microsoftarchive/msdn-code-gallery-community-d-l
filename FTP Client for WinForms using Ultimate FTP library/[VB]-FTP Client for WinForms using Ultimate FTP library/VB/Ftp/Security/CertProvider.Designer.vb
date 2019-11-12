Namespace ClientSample.Ftp.Security
	Partial Public Class CertProvider
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Private btnCancel As System.Windows.Forms.Button
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private WithEvents cbCertList As System.Windows.Forms.ComboBox

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.cbCertList = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.grbValid = New System.Windows.Forms.GroupBox()
			Me.lblToText = New System.Windows.Forms.Label()
			Me.lblTo = New System.Windows.Forms.Label()
			Me.lblFromText = New System.Windows.Forms.Label()
			Me.lblFrom = New System.Windows.Forms.Label()
			Me.grbSubject = New System.Windows.Forms.GroupBox()
			Me.lblCommonNameSubText = New System.Windows.Forms.Label()
			Me.lblCommonNameSub = New System.Windows.Forms.Label()
			Me.lblLocationSubText = New System.Windows.Forms.Label()
			Me.lblCountrySub = New System.Windows.Forms.Label()
			Me.lblUnitSubText = New System.Windows.Forms.Label()
			Me.lblUnitSub = New System.Windows.Forms.Label()
			Me.lblOrganizationSubText = New System.Windows.Forms.Label()
			Me.lblOrganizationSub = New System.Windows.Forms.Label()
			Me.grbIssuer = New System.Windows.Forms.GroupBox()
			Me.lblCommonNameText = New System.Windows.Forms.Label()
			Me.lblCommonName = New System.Windows.Forms.Label()
			Me.lblLocationText = New System.Windows.Forms.Label()
			Me.lblCountry = New System.Windows.Forms.Label()
			Me.lblUnitText = New System.Windows.Forms.Label()
			Me.lblUnit = New System.Windows.Forms.Label()
			Me.lblOrganizationText = New System.Windows.Forms.Label()
			Me.lblOrg = New System.Windows.Forms.Label()
			Me.grbValid.SuspendLayout()
			Me.grbSubject.SuspendLayout()
			Me.grbIssuer.SuspendLayout()
			Me.SuspendLayout()
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(334, 300)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 1
			Me.btnCancel.Text = "&Cancel"
			' 
			' btnOk
			' 
			Me.btnOk.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOk.Location = New System.Drawing.Point(254, 300)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 0
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' cbCertList
			' 
			Me.cbCertList.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbCertList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbCertList.Location = New System.Drawing.Point(104, 8)
			Me.cbCertList.Name = "cbCertList"
			Me.cbCertList.Size = New System.Drawing.Size(305, 21)
			Me.cbCertList.TabIndex = 2
'			Me.cbCertList.SelectedIndexChanged += New System.EventHandler(Me.cbCertList_SelectedIndexChanged)
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 11)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(57, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Certificate:"
			' 
			' grbValid
			' 
			Me.grbValid.Controls.Add(Me.lblToText)
			Me.grbValid.Controls.Add(Me.lblTo)
			Me.grbValid.Controls.Add(Me.lblFromText)
			Me.grbValid.Controls.Add(Me.lblFrom)
			Me.grbValid.Location = New System.Drawing.Point(9, 235)
			Me.grbValid.Name = "grbValid"
			Me.grbValid.Size = New System.Drawing.Size(400, 61)
			Me.grbValid.TabIndex = 11
			Me.grbValid.TabStop = False
			Me.grbValid.Text = "Valid"
			' 
			' lblToText
			' 
			Me.lblToText.Location = New System.Drawing.Point(93, 36)
			Me.lblToText.Name = "lblToText"
			Me.lblToText.Size = New System.Drawing.Size(301, 13)
			Me.lblToText.TabIndex = 3
			Me.lblToText.Text = "To"
			' 
			' lblTo
			' 
			Me.lblTo.Location = New System.Drawing.Point(8, 36)
			Me.lblTo.Name = "lblTo"
			Me.lblTo.Size = New System.Drawing.Size(23, 13)
			Me.lblTo.TabIndex = 2
			Me.lblTo.Text = "To:"
			' 
			' lblFromText
			' 
			Me.lblFromText.Location = New System.Drawing.Point(93, 17)
			Me.lblFromText.Name = "lblFromText"
			Me.lblFromText.Size = New System.Drawing.Size(301, 13)
			Me.lblFromText.TabIndex = 1
			Me.lblFromText.Text = "From"
			' 
			' lblFrom
			' 
			Me.lblFrom.Location = New System.Drawing.Point(8, 17)
			Me.lblFrom.Name = "lblFrom"
			Me.lblFrom.Size = New System.Drawing.Size(33, 13)
			Me.lblFrom.TabIndex = 0
			Me.lblFrom.Text = "From:"
			' 
			' grbSubject
			' 
			Me.grbSubject.Controls.Add(Me.lblCommonNameSubText)
			Me.grbSubject.Controls.Add(Me.lblCommonNameSub)
			Me.grbSubject.Controls.Add(Me.lblLocationSubText)
			Me.grbSubject.Controls.Add(Me.lblCountrySub)
			Me.grbSubject.Controls.Add(Me.lblUnitSubText)
			Me.grbSubject.Controls.Add(Me.lblUnitSub)
			Me.grbSubject.Controls.Add(Me.lblOrganizationSubText)
			Me.grbSubject.Controls.Add(Me.lblOrganizationSub)
			Me.grbSubject.Location = New System.Drawing.Point(9, 133)
			Me.grbSubject.Name = "grbSubject"
			Me.grbSubject.Size = New System.Drawing.Size(400, 96)
			Me.grbSubject.TabIndex = 10
			Me.grbSubject.TabStop = False
			Me.grbSubject.Text = "Subject"
			' 
			' lblCommonNameSubText
			' 
			Me.lblCommonNameSubText.Location = New System.Drawing.Point(93, 74)
			Me.lblCommonNameSubText.Name = "lblCommonNameSubText"
			Me.lblCommonNameSubText.Size = New System.Drawing.Size(301, 13)
			Me.lblCommonNameSubText.TabIndex = 7
			Me.lblCommonNameSubText.Text = "Common Name"
			' 
			' lblCommonNameSub
			' 
			Me.lblCommonNameSub.Location = New System.Drawing.Point(8, 74)
			Me.lblCommonNameSub.Name = "lblCommonNameSub"
			Me.lblCommonNameSub.Size = New System.Drawing.Size(82, 13)
			Me.lblCommonNameSub.TabIndex = 6
			Me.lblCommonNameSub.Text = "Common Name:"
			' 
			' lblLocationSubText
			' 
			Me.lblLocationSubText.Location = New System.Drawing.Point(93, 55)
			Me.lblLocationSubText.Name = "lblLocationSubText"
			Me.lblLocationSubText.Size = New System.Drawing.Size(301, 13)
			Me.lblLocationSubText.TabIndex = 5
			Me.lblLocationSubText.Text = "Country"
			' 
			' lblCountrySub
			' 
			Me.lblCountrySub.Location = New System.Drawing.Point(8, 55)
			Me.lblCountrySub.Name = "lblCountrySub"
			Me.lblCountrySub.Size = New System.Drawing.Size(46, 13)
			Me.lblCountrySub.TabIndex = 4
			Me.lblCountrySub.Text = "Country:"
			' 
			' lblUnitSubText
			' 
			Me.lblUnitSubText.Location = New System.Drawing.Point(93, 36)
			Me.lblUnitSubText.Name = "lblUnitSubText"
			Me.lblUnitSubText.Size = New System.Drawing.Size(301, 13)
			Me.lblUnitSubText.TabIndex = 3
			Me.lblUnitSubText.Text = "Unit"
			' 
			' lblUnitSub
			' 
			Me.lblUnitSub.Location = New System.Drawing.Point(8, 36)
			Me.lblUnitSub.Name = "lblUnitSub"
			Me.lblUnitSub.Size = New System.Drawing.Size(29, 13)
			Me.lblUnitSub.TabIndex = 2
			Me.lblUnitSub.Text = "Unit:"
			' 
			' lblOrganizationSubText
			' 
			Me.lblOrganizationSubText.Location = New System.Drawing.Point(93, 17)
			Me.lblOrganizationSubText.Name = "lblOrganizationSubText"
			Me.lblOrganizationSubText.Size = New System.Drawing.Size(301, 13)
			Me.lblOrganizationSubText.TabIndex = 1
			Me.lblOrganizationSubText.Text = "Organization:"
			' 
			' lblOrganizationSub
			' 
			Me.lblOrganizationSub.Location = New System.Drawing.Point(8, 17)
			Me.lblOrganizationSub.Name = "lblOrganizationSub"
			Me.lblOrganizationSub.Size = New System.Drawing.Size(69, 13)
			Me.lblOrganizationSub.TabIndex = 0
			Me.lblOrganizationSub.Text = "Organization:"
			' 
			' grbIssuer
			' 
			Me.grbIssuer.Controls.Add(Me.lblCommonNameText)
			Me.grbIssuer.Controls.Add(Me.lblCommonName)
			Me.grbIssuer.Controls.Add(Me.lblLocationText)
			Me.grbIssuer.Controls.Add(Me.lblCountry)
			Me.grbIssuer.Controls.Add(Me.lblUnitText)
			Me.grbIssuer.Controls.Add(Me.lblUnit)
			Me.grbIssuer.Controls.Add(Me.lblOrganizationText)
			Me.grbIssuer.Controls.Add(Me.lblOrg)
			Me.grbIssuer.Location = New System.Drawing.Point(9, 35)
			Me.grbIssuer.Name = "grbIssuer"
			Me.grbIssuer.Size = New System.Drawing.Size(400, 96)
			Me.grbIssuer.TabIndex = 9
			Me.grbIssuer.TabStop = False
			Me.grbIssuer.Text = "Issuer"
			' 
			' lblCommonNameText
			' 
			Me.lblCommonNameText.Location = New System.Drawing.Point(93, 74)
			Me.lblCommonNameText.Name = "lblCommonNameText"
			Me.lblCommonNameText.Size = New System.Drawing.Size(301, 13)
			Me.lblCommonNameText.TabIndex = 7
			Me.lblCommonNameText.Text = "Common Name"
			' 
			' lblCommonName
			' 
			Me.lblCommonName.Location = New System.Drawing.Point(8, 74)
			Me.lblCommonName.Name = "lblCommonName"
			Me.lblCommonName.Size = New System.Drawing.Size(82, 13)
			Me.lblCommonName.TabIndex = 6
			Me.lblCommonName.Text = "Common Name:"
			' 
			' lblLocationText
			' 
			Me.lblLocationText.Location = New System.Drawing.Point(93, 55)
			Me.lblLocationText.Name = "lblLocationText"
			Me.lblLocationText.Size = New System.Drawing.Size(301, 13)
			Me.lblLocationText.TabIndex = 5
			Me.lblLocationText.Text = "Country"
			' 
			' lblCountry
			' 
			Me.lblCountry.Location = New System.Drawing.Point(8, 55)
			Me.lblCountry.Name = "lblCountry"
			Me.lblCountry.Size = New System.Drawing.Size(46, 13)
			Me.lblCountry.TabIndex = 4
			Me.lblCountry.Text = "Country:"
			' 
			' lblUnitText
			' 
			Me.lblUnitText.Location = New System.Drawing.Point(93, 36)
			Me.lblUnitText.Name = "lblUnitText"
			Me.lblUnitText.Size = New System.Drawing.Size(301, 13)
			Me.lblUnitText.TabIndex = 3
			Me.lblUnitText.Text = "Unit"
			' 
			' lblUnit
			' 
			Me.lblUnit.Location = New System.Drawing.Point(8, 36)
			Me.lblUnit.Name = "lblUnit"
			Me.lblUnit.Size = New System.Drawing.Size(29, 13)
			Me.lblUnit.TabIndex = 2
			Me.lblUnit.Text = "Unit:"
			' 
			' lblOrganizationText
			' 
			Me.lblOrganizationText.Location = New System.Drawing.Point(93, 17)
			Me.lblOrganizationText.Name = "lblOrganizationText"
			Me.lblOrganizationText.Size = New System.Drawing.Size(301, 13)
			Me.lblOrganizationText.TabIndex = 1
			Me.lblOrganizationText.Text = "Organization:"
			' 
			' lblOrg
			' 
			Me.lblOrg.Location = New System.Drawing.Point(8, 17)
			Me.lblOrg.Name = "lblOrg"
			Me.lblOrg.Size = New System.Drawing.Size(69, 13)
			Me.lblOrg.TabIndex = 0
			Me.lblOrg.Text = "Organization:"
			' 
			' CertProvider
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(418, 332)
			Me.ControlBox = False
			Me.Controls.Add(Me.grbValid)
			Me.Controls.Add(Me.grbSubject)
			Me.Controls.Add(Me.grbIssuer)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.cbCertList)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "CertProvider"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Select Certificate"
			Me.grbValid.ResumeLayout(False)
			Me.grbSubject.ResumeLayout(False)
			Me.grbIssuer.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private grbValid As System.Windows.Forms.GroupBox
		Private lblToText As System.Windows.Forms.Label
		Private lblTo As System.Windows.Forms.Label
		Private lblFromText As System.Windows.Forms.Label
		Private lblFrom As System.Windows.Forms.Label
		Private grbSubject As System.Windows.Forms.GroupBox
		Private lblCommonNameSubText As System.Windows.Forms.Label
		Private lblCommonNameSub As System.Windows.Forms.Label
		Private lblLocationSubText As System.Windows.Forms.Label
		Private lblCountrySub As System.Windows.Forms.Label
		Private lblUnitSubText As System.Windows.Forms.Label
		Private lblUnitSub As System.Windows.Forms.Label
		Private lblOrganizationSubText As System.Windows.Forms.Label
		Private lblOrganizationSub As System.Windows.Forms.Label
		Private grbIssuer As System.Windows.Forms.GroupBox
		Private lblCommonNameText As System.Windows.Forms.Label
		Private lblCommonName As System.Windows.Forms.Label
		Private lblLocationText As System.Windows.Forms.Label
		Private lblCountry As System.Windows.Forms.Label
		Private lblUnitText As System.Windows.Forms.Label
		Private lblUnit As System.Windows.Forms.Label
		Private lblOrganizationText As System.Windows.Forms.Label
		Private lblOrg As System.Windows.Forms.Label
	End Class
End Namespace