Namespace ClientSample.Sftp
	Partial Public Class SftpPropertiesForm
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
			Me.grbUser = New System.Windows.Forms.GroupBox()
			Me.chkSetUID = New System.Windows.Forms.CheckBox()
			Me.chkOwnerExecute = New System.Windows.Forms.CheckBox()
			Me.chkOwnerWrite = New System.Windows.Forms.CheckBox()
			Me.chkOwnerRead = New System.Windows.Forms.CheckBox()
			Me.txtPermissions = New System.Windows.Forms.TextBox()
			Me.lblPermissions = New System.Windows.Forms.Label()
			Me.grbGroup = New System.Windows.Forms.GroupBox()
			Me.chkSetGID = New System.Windows.Forms.CheckBox()
			Me.chkGroupExecute = New System.Windows.Forms.CheckBox()
			Me.chkGroupWrite = New System.Windows.Forms.CheckBox()
			Me.chkGroupRead = New System.Windows.Forms.CheckBox()
			Me.grbPublic = New System.Windows.Forms.GroupBox()
			Me.chkStickly = New System.Windows.Forms.CheckBox()
			Me.chkPublicExecute = New System.Windows.Forms.CheckBox()
			Me.chkPublicWrite = New System.Windows.Forms.CheckBox()
			Me.chkPublicRead = New System.Windows.Forms.CheckBox()
			Me.chkRecursive = New System.Windows.Forms.CheckBox()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.grbUser.SuspendLayout()
			Me.grbGroup.SuspendLayout()
			Me.grbPublic.SuspendLayout()
			Me.SuspendLayout()
			' 
			' grbUser
			' 
			Me.grbUser.Controls.Add(Me.chkSetUID)
			Me.grbUser.Controls.Add(Me.chkOwnerExecute)
			Me.grbUser.Controls.Add(Me.chkOwnerWrite)
			Me.grbUser.Controls.Add(Me.chkOwnerRead)
			Me.grbUser.Location = New System.Drawing.Point(8, 34)
			Me.grbUser.Name = "grbUser"
			Me.grbUser.Size = New System.Drawing.Size(103, 99)
			Me.grbUser.TabIndex = 87
			Me.grbUser.TabStop = False
			Me.grbUser.Text = "User"
			' 
			' chkSetUID
			' 
			Me.chkSetUID.AutoSize = True
			Me.chkSetUID.Location = New System.Drawing.Point(10, 74)
			Me.chkSetUID.Name = "chkSetUID"
			Me.chkSetUID.Size = New System.Drawing.Size(64, 17)
			Me.chkSetUID.TabIndex = 4
			Me.chkSetUID.Text = "Set UID"
'			Me.chkSetUID.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkOwnerExecute
			' 
			Me.chkOwnerExecute.AutoSize = True
			Me.chkOwnerExecute.Location = New System.Drawing.Point(10, 55)
			Me.chkOwnerExecute.Name = "chkOwnerExecute"
			Me.chkOwnerExecute.Size = New System.Drawing.Size(65, 17)
			Me.chkOwnerExecute.TabIndex = 3
			Me.chkOwnerExecute.Text = "Execute"
'			Me.chkOwnerExecute.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkOwnerWrite
			' 
			Me.chkOwnerWrite.AutoSize = True
			Me.chkOwnerWrite.Location = New System.Drawing.Point(10, 36)
			Me.chkOwnerWrite.Name = "chkOwnerWrite"
			Me.chkOwnerWrite.Size = New System.Drawing.Size(51, 17)
			Me.chkOwnerWrite.TabIndex = 2
			Me.chkOwnerWrite.Text = "Write"
'			Me.chkOwnerWrite.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkOwnerRead
			' 
			Me.chkOwnerRead.AutoSize = True
			Me.chkOwnerRead.Location = New System.Drawing.Point(10, 16)
			Me.chkOwnerRead.Name = "chkOwnerRead"
			Me.chkOwnerRead.Size = New System.Drawing.Size(52, 17)
			Me.chkOwnerRead.TabIndex = 1
			Me.chkOwnerRead.Text = "Read"
'			Me.chkOwnerRead.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' txtPermissions
			' 
			Me.txtPermissions.AcceptsReturn = True
			Me.txtPermissions.BackColor = System.Drawing.SystemColors.Window
			Me.txtPermissions.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.txtPermissions.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.txtPermissions.ForeColor = System.Drawing.SystemColors.WindowText
			Me.txtPermissions.Location = New System.Drawing.Point(79, 8)
			Me.txtPermissions.MaxLength = 0
			Me.txtPermissions.Name = "txtPermissions"
			Me.txtPermissions.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.txtPermissions.Size = New System.Drawing.Size(62, 20)
			Me.txtPermissions.TabIndex = 0
			Me.txtPermissions.Text = "0"
			Me.txtPermissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'			Me.txtPermissions.TextChanged += New System.EventHandler(Me.txtPermissions_TextChanged)
			' 
			' lblPermissions
			' 
			Me.lblPermissions.AutoSize = True
			Me.lblPermissions.BackColor = System.Drawing.SystemColors.Control
			Me.lblPermissions.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblPermissions.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblPermissions.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblPermissions.Location = New System.Drawing.Point(5, 11)
			Me.lblPermissions.Name = "lblPermissions"
			Me.lblPermissions.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblPermissions.Size = New System.Drawing.Size(68, 14)
			Me.lblPermissions.TabIndex = 88
			Me.lblPermissions.Text = "Permissions:"
			' 
			' grbGroup
			' 
			Me.grbGroup.Controls.Add(Me.chkSetGID)
			Me.grbGroup.Controls.Add(Me.chkGroupExecute)
			Me.grbGroup.Controls.Add(Me.chkGroupWrite)
			Me.grbGroup.Controls.Add(Me.chkGroupRead)
			Me.grbGroup.Location = New System.Drawing.Point(117, 34)
			Me.grbGroup.Name = "grbGroup"
			Me.grbGroup.Size = New System.Drawing.Size(103, 99)
			Me.grbGroup.TabIndex = 89
			Me.grbGroup.TabStop = False
			Me.grbGroup.Text = "Group"
			' 
			' chkSetGID
			' 
			Me.chkSetGID.AutoSize = True
			Me.chkSetGID.Location = New System.Drawing.Point(10, 74)
			Me.chkSetGID.Name = "chkSetGID"
			Me.chkSetGID.Size = New System.Drawing.Size(64, 17)
			Me.chkSetGID.TabIndex = 7
			Me.chkSetGID.Text = "Set GID"
'			Me.chkSetGID.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkGroupExecute
			' 
			Me.chkGroupExecute.AutoSize = True
			Me.chkGroupExecute.Location = New System.Drawing.Point(10, 55)
			Me.chkGroupExecute.Name = "chkGroupExecute"
			Me.chkGroupExecute.Size = New System.Drawing.Size(65, 17)
			Me.chkGroupExecute.TabIndex = 6
			Me.chkGroupExecute.Text = "Execute"
'			Me.chkGroupExecute.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkGroupWrite
			' 
			Me.chkGroupWrite.AutoSize = True
			Me.chkGroupWrite.Location = New System.Drawing.Point(10, 36)
			Me.chkGroupWrite.Name = "chkGroupWrite"
			Me.chkGroupWrite.Size = New System.Drawing.Size(51, 17)
			Me.chkGroupWrite.TabIndex = 5
			Me.chkGroupWrite.Text = "Write"
'			Me.chkGroupWrite.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkGroupRead
			' 
			Me.chkGroupRead.AutoSize = True
			Me.chkGroupRead.Location = New System.Drawing.Point(10, 16)
			Me.chkGroupRead.Name = "chkGroupRead"
			Me.chkGroupRead.Size = New System.Drawing.Size(52, 17)
			Me.chkGroupRead.TabIndex = 4
			Me.chkGroupRead.Text = "Read"
'			Me.chkGroupRead.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' grbPublic
			' 
			Me.grbPublic.Controls.Add(Me.chkStickly)
			Me.grbPublic.Controls.Add(Me.chkPublicExecute)
			Me.grbPublic.Controls.Add(Me.chkPublicWrite)
			Me.grbPublic.Controls.Add(Me.chkPublicRead)
			Me.grbPublic.Location = New System.Drawing.Point(226, 34)
			Me.grbPublic.Name = "grbPublic"
			Me.grbPublic.Size = New System.Drawing.Size(103, 99)
			Me.grbPublic.TabIndex = 90
			Me.grbPublic.TabStop = False
			Me.grbPublic.Text = "Public"
			' 
			' chkStickly
			' 
			Me.chkStickly.AutoSize = True
			Me.chkStickly.Location = New System.Drawing.Point(10, 74)
			Me.chkStickly.Name = "chkStickly"
			Me.chkStickly.Size = New System.Drawing.Size(57, 17)
			Me.chkStickly.TabIndex = 10
			Me.chkStickly.Text = "Stickly"
'			Me.chkStickly.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkPublicExecute
			' 
			Me.chkPublicExecute.AutoSize = True
			Me.chkPublicExecute.Location = New System.Drawing.Point(10, 55)
			Me.chkPublicExecute.Name = "chkPublicExecute"
			Me.chkPublicExecute.Size = New System.Drawing.Size(65, 17)
			Me.chkPublicExecute.TabIndex = 9
			Me.chkPublicExecute.Text = "Execute"
'			Me.chkPublicExecute.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkPublicWrite
			' 
			Me.chkPublicWrite.AutoSize = True
			Me.chkPublicWrite.Location = New System.Drawing.Point(10, 36)
			Me.chkPublicWrite.Name = "chkPublicWrite"
			Me.chkPublicWrite.Size = New System.Drawing.Size(51, 17)
			Me.chkPublicWrite.TabIndex = 8
			Me.chkPublicWrite.Text = "Write"
'			Me.chkPublicWrite.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkPublicRead
			' 
			Me.chkPublicRead.AutoSize = True
			Me.chkPublicRead.Location = New System.Drawing.Point(10, 16)
			Me.chkPublicRead.Name = "chkPublicRead"
			Me.chkPublicRead.Size = New System.Drawing.Size(52, 17)
			Me.chkPublicRead.TabIndex = 7
			Me.chkPublicRead.Text = "Read"
'			Me.chkPublicRead.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkRecursive
			' 
			Me.chkRecursive.AutoSize = True
			Me.chkRecursive.Location = New System.Drawing.Point(8, 139)
			Me.chkRecursive.Name = "chkRecursive"
			Me.chkRecursive.Size = New System.Drawing.Size(252, 17)
			Me.chkRecursive.TabIndex = 10
			Me.chkRecursive.Text = "Apply changes to this folder, subfolders and files"
			' 
			' groupBox1
			' 
			Me.groupBox1.Location = New System.Drawing.Point(8, 162)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(321, 2)
			Me.groupBox1.TabIndex = 92
			Me.groupBox1.TabStop = False
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.Location = New System.Drawing.Point(174, 170)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 11
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(254, 170)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 12
			Me.btnCancel.Text = "&Cancel"
			' 
			' PropertiesForm
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(335, 202)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.chkRecursive)
			Me.Controls.Add(Me.grbPublic)
			Me.Controls.Add(Me.grbGroup)
			Me.Controls.Add(Me.grbUser)
			Me.Controls.Add(Me.lblPermissions)
			Me.Controls.Add(Me.txtPermissions)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "PropertiesForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Properties"
			Me.grbUser.ResumeLayout(False)
			Me.grbUser.PerformLayout()
			Me.grbGroup.ResumeLayout(False)
			Me.grbGroup.PerformLayout()
			Me.grbPublic.ResumeLayout(False)
			Me.grbPublic.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private grbUser As System.Windows.Forms.GroupBox
		Private WithEvents chkOwnerExecute As System.Windows.Forms.CheckBox
		Private WithEvents chkOwnerWrite As System.Windows.Forms.CheckBox
		Private WithEvents chkOwnerRead As System.Windows.Forms.CheckBox
		Public WithEvents txtPermissions As System.Windows.Forms.TextBox
		Public lblPermissions As System.Windows.Forms.Label
		Private grbGroup As System.Windows.Forms.GroupBox
		Private WithEvents chkGroupExecute As System.Windows.Forms.CheckBox
		Private WithEvents chkGroupWrite As System.Windows.Forms.CheckBox
		Private WithEvents chkGroupRead As System.Windows.Forms.CheckBox
		Private grbPublic As System.Windows.Forms.GroupBox
		Private WithEvents chkPublicExecute As System.Windows.Forms.CheckBox
		Private WithEvents chkPublicWrite As System.Windows.Forms.CheckBox
		Private WithEvents chkPublicRead As System.Windows.Forms.CheckBox
		Private chkRecursive As System.Windows.Forms.CheckBox
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private WithEvents chkSetUID As System.Windows.Forms.CheckBox
		Private WithEvents chkSetGID As System.Windows.Forms.CheckBox
		Private WithEvents chkStickly As System.Windows.Forms.CheckBox
	End Class
End Namespace