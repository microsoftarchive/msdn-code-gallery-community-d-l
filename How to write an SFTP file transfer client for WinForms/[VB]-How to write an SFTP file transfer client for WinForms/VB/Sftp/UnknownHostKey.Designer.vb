Namespace ClientSample.Sftp
	Partial Public Class UnknownHostKey
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.lblTitle = New System.Windows.Forms.Label()
			Me.grbSep = New System.Windows.Forms.GroupBox()
			Me.lblHostLeft = New System.Windows.Forms.Label()
			Me.lblPortTitle = New System.Windows.Forms.Label()
			Me.lblFingerprintTitle = New System.Windows.Forms.Label()
			Me.lblFingerprint = New System.Windows.Forms.Label()
			Me.lblPort = New System.Windows.Forms.Label()
			Me.lblHost = New System.Windows.Forms.Label()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.btnReject = New System.Windows.Forms.Button()
			Me.btnAccept = New System.Windows.Forms.Button()
			Me.btnAlwaysAccept = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' lblTitle
			' 
			Me.lblTitle.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblTitle.Location = New System.Drawing.Point(6, 6)
			Me.lblTitle.Name = "lblTitle"
			Me.lblTitle.Size = New System.Drawing.Size(412, 42)
			Me.lblTitle.TabIndex = 0
			Me.lblTitle.Text = "The server's host key is unknown. You have no guarantee that the server is the co" & "mputer you think it is." & vbCrLf & "Do you want to trust this host and carry on connecting?" & ""
			' 
			' grbSep
			' 
			Me.grbSep.Location = New System.Drawing.Point(11, 52)
			Me.grbSep.Name = "grbSep"
			Me.grbSep.Size = New System.Drawing.Size(407, 2)
			Me.grbSep.TabIndex = 1
			Me.grbSep.TabStop = False
			' 
			' lblHostLeft
			' 
			Me.lblHostLeft.Location = New System.Drawing.Point(7, 61)
			Me.lblHostLeft.Name = "lblHostLeft"
			Me.lblHostLeft.Size = New System.Drawing.Size(32, 13)
			Me.lblHostLeft.TabIndex = 2
			Me.lblHostLeft.Text = "Host:"
			' 
			' lblPortTitle
			' 
			Me.lblPortTitle.Location = New System.Drawing.Point(7, 80)
			Me.lblPortTitle.Name = "lblPortTitle"
			Me.lblPortTitle.Size = New System.Drawing.Size(29, 13)
			Me.lblPortTitle.TabIndex = 3
			Me.lblPortTitle.Text = "Port:"
			' 
			' lblFingerprintTitle
			' 
			Me.lblFingerprintTitle.Location = New System.Drawing.Point(7, 99)
			Me.lblFingerprintTitle.Name = "lblFingerprintTitle"
			Me.lblFingerprintTitle.Size = New System.Drawing.Size(59, 13)
			Me.lblFingerprintTitle.TabIndex = 4
			Me.lblFingerprintTitle.Text = "Fingerprint:"
			' 
			' lblFingerprint
			' 
			Me.lblFingerprint.AutoSize = True
			Me.lblFingerprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblFingerprint.Location = New System.Drawing.Point(70, 99)
			Me.lblFingerprint.Name = "lblFingerprint"
			Me.lblFingerprint.Size = New System.Drawing.Size(71, 13)
			Me.lblFingerprint.TabIndex = 7
			Me.lblFingerprint.Text = "Fingerprint:"
			' 
			' lblPort
			' 
			Me.lblPort.AutoSize = True
			Me.lblPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblPort.Location = New System.Drawing.Point(70, 80)
			Me.lblPort.Name = "lblPort"
			Me.lblPort.Size = New System.Drawing.Size(34, 13)
			Me.lblPort.TabIndex = 6
			Me.lblPort.Text = "Port:"
			' 
			' lblHost
			' 
			Me.lblHost.AutoSize = True
			Me.lblHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblHost.Location = New System.Drawing.Point(70, 61)
			Me.lblHost.Name = "lblHost"
			Me.lblHost.Size = New System.Drawing.Size(37, 13)
			Me.lblHost.TabIndex = 5
			Me.lblHost.Text = "Host:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Location = New System.Drawing.Point(9, 120)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(408, 2)
			Me.groupBox1.TabIndex = 8
			Me.groupBox1.TabStop = False
			' 
			' btnReject
			' 
			Me.btnReject.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnReject.Location = New System.Drawing.Point(344, 133)
			Me.btnReject.Name = "btnReject"
			Me.btnReject.Size = New System.Drawing.Size(75, 23)
			Me.btnReject.TabIndex = 1
			Me.btnReject.Text = "&Reject"
'			Me.btnReject.Click += New System.EventHandler(Me.btnReject_Click)
			' 
			' btnAccept
			' 
			Me.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnAccept.Location = New System.Drawing.Point(263, 133)
			Me.btnAccept.Name = "btnAccept"
			Me.btnAccept.Size = New System.Drawing.Size(75, 23)
			Me.btnAccept.TabIndex = 0
			Me.btnAccept.Text = "&Accept"
'			Me.btnAccept.Click += New System.EventHandler(Me.btnAccept_Click)
			' 
			' btnAlwaysAccept
			' 
			Me.btnAlwaysAccept.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnAlwaysAccept.Location = New System.Drawing.Point(157, 133)
			Me.btnAlwaysAccept.Name = "btnAlwaysAccept"
			Me.btnAlwaysAccept.Size = New System.Drawing.Size(100, 23)
			Me.btnAlwaysAccept.TabIndex = 2
			Me.btnAlwaysAccept.Text = "Always Accep&t"
'			Me.btnAlwaysAccept.Click += New System.EventHandler(Me.btnAlwaysAccept_Click)
			' 
			' UnknownHostKey
			' 
			Me.AcceptButton = Me.btnAccept
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnReject
			Me.ClientSize = New System.Drawing.Size(427, 165)
			Me.Controls.Add(Me.btnAlwaysAccept)
			Me.Controls.Add(Me.btnAccept)
			Me.Controls.Add(Me.btnReject)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.lblFingerprint)
			Me.Controls.Add(Me.lblPort)
			Me.Controls.Add(Me.lblHost)
			Me.Controls.Add(Me.lblFingerprintTitle)
			Me.Controls.Add(Me.lblPortTitle)
			Me.Controls.Add(Me.lblHostLeft)
			Me.Controls.Add(Me.grbSep)
			Me.Controls.Add(Me.lblTitle)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "UnknownHostKey"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Unknown Host Key"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private lblTitle As System.Windows.Forms.Label
		Private grbSep As System.Windows.Forms.GroupBox
		Private lblHostLeft As System.Windows.Forms.Label
		Private lblPortTitle As System.Windows.Forms.Label
		Private lblFingerprintTitle As System.Windows.Forms.Label
		Private lblFingerprint As System.Windows.Forms.Label
		Private lblPort As System.Windows.Forms.Label
		Private lblHost As System.Windows.Forms.Label
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private WithEvents btnReject As System.Windows.Forms.Button
		Private WithEvents btnAccept As System.Windows.Forms.Button
		Private WithEvents btnAlwaysAccept As System.Windows.Forms.Button
	End Class
End Namespace