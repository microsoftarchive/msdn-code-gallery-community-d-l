Namespace ClientSample.Ftp
	Partial Public Class FtpPropertiesForm
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
			Me.chkOwnerExecute = New System.Windows.Forms.CheckBox()
			Me.chkOwnerWrite = New System.Windows.Forms.CheckBox()
			Me.chkOwnerRead = New System.Windows.Forms.CheckBox()
			Me.grbGroup = New System.Windows.Forms.GroupBox()
			Me.chkGroupExecute = New System.Windows.Forms.CheckBox()
			Me.chkGroupWrite = New System.Windows.Forms.CheckBox()
			Me.chkGroupRead = New System.Windows.Forms.CheckBox()
			Me.grbPublic = New System.Windows.Forms.GroupBox()
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
			Me.grbUser.Controls.Add(Me.chkOwnerExecute)
			Me.grbUser.Controls.Add(Me.chkOwnerWrite)
			Me.grbUser.Controls.Add(Me.chkOwnerRead)
			Me.grbUser.Location = New System.Drawing.Point(8, 4)
			Me.grbUser.Name = "grbUser"
			Me.grbUser.Size = New System.Drawing.Size(103, 80)
			Me.grbUser.TabIndex = 87
			Me.grbUser.TabStop = False
			Me.grbUser.Text = "Owner"
			' 
			' chkOwnerExecute
			' 
			Me.chkOwnerExecute.Location = New System.Drawing.Point(10, 55)
			Me.chkOwnerExecute.Name = "chkOwnerExecute"
			Me.chkOwnerExecute.Size = New System.Drawing.Size(65, 20)
			Me.chkOwnerExecute.TabIndex = 3
			Me.chkOwnerExecute.Text = "Execute"
'			Me.chkOwnerExecute.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkOwnerWrite
			' 
			Me.chkOwnerWrite.Location = New System.Drawing.Point(10, 36)
			Me.chkOwnerWrite.Name = "chkOwnerWrite"
			Me.chkOwnerWrite.Size = New System.Drawing.Size(51, 20)
			Me.chkOwnerWrite.TabIndex = 2
			Me.chkOwnerWrite.Text = "Write"
'			Me.chkOwnerWrite.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkOwnerRead
			' 
			Me.chkOwnerRead.Location = New System.Drawing.Point(10, 16)
			Me.chkOwnerRead.Name = "chkOwnerRead"
			Me.chkOwnerRead.Size = New System.Drawing.Size(52, 20)
			Me.chkOwnerRead.TabIndex = 1
			Me.chkOwnerRead.Text = "Read"
'			Me.chkOwnerRead.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' grbGroup
			' 
			Me.grbGroup.Controls.Add(Me.chkGroupExecute)
			Me.grbGroup.Controls.Add(Me.chkGroupWrite)
			Me.grbGroup.Controls.Add(Me.chkGroupRead)
			Me.grbGroup.Location = New System.Drawing.Point(117, 4)
			Me.grbGroup.Name = "grbGroup"
			Me.grbGroup.Size = New System.Drawing.Size(103, 80)
			Me.grbGroup.TabIndex = 89
			Me.grbGroup.TabStop = False
			Me.grbGroup.Text = "Group"
			' 
			' chkGroupExecute
			' 
			Me.chkGroupExecute.Location = New System.Drawing.Point(10, 55)
			Me.chkGroupExecute.Name = "chkGroupExecute"
			Me.chkGroupExecute.Size = New System.Drawing.Size(65, 20)
			Me.chkGroupExecute.TabIndex = 6
			Me.chkGroupExecute.Text = "Execute"
'			Me.chkGroupExecute.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkGroupWrite
			' 
			Me.chkGroupWrite.Location = New System.Drawing.Point(10, 36)
			Me.chkGroupWrite.Name = "chkGroupWrite"
			Me.chkGroupWrite.Size = New System.Drawing.Size(51, 20)
			Me.chkGroupWrite.TabIndex = 5
			Me.chkGroupWrite.Text = "Write"
'			Me.chkGroupWrite.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkGroupRead
			' 
			Me.chkGroupRead.Location = New System.Drawing.Point(10, 16)
			Me.chkGroupRead.Name = "chkGroupRead"
			Me.chkGroupRead.Size = New System.Drawing.Size(52, 20)
			Me.chkGroupRead.TabIndex = 4
			Me.chkGroupRead.Text = "Read"
'			Me.chkGroupRead.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' grbPublic
			' 
			Me.grbPublic.Controls.Add(Me.chkPublicExecute)
			Me.grbPublic.Controls.Add(Me.chkPublicWrite)
			Me.grbPublic.Controls.Add(Me.chkPublicRead)
			Me.grbPublic.Location = New System.Drawing.Point(226, 4)
			Me.grbPublic.Name = "grbPublic"
			Me.grbPublic.Size = New System.Drawing.Size(103, 80)
			Me.grbPublic.TabIndex = 90
			Me.grbPublic.TabStop = False
			Me.grbPublic.Text = "Public"
			' 
			' chkPublicExecute
			' 
			Me.chkPublicExecute.Location = New System.Drawing.Point(10, 55)
			Me.chkPublicExecute.Name = "chkPublicExecute"
			Me.chkPublicExecute.Size = New System.Drawing.Size(65, 20)
			Me.chkPublicExecute.TabIndex = 9
			Me.chkPublicExecute.Text = "Execute"
'			Me.chkPublicExecute.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkPublicWrite
			' 
			Me.chkPublicWrite.Location = New System.Drawing.Point(10, 36)
			Me.chkPublicWrite.Name = "chkPublicWrite"
			Me.chkPublicWrite.Size = New System.Drawing.Size(51, 20)
			Me.chkPublicWrite.TabIndex = 8
			Me.chkPublicWrite.Text = "Write"
'			Me.chkPublicWrite.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkPublicRead
			' 
			Me.chkPublicRead.Location = New System.Drawing.Point(10, 16)
			Me.chkPublicRead.Name = "chkPublicRead"
			Me.chkPublicRead.Size = New System.Drawing.Size(52, 20)
			Me.chkPublicRead.TabIndex = 7
			Me.chkPublicRead.Text = "Read"
'			Me.chkPublicRead.CheckedChanged += New System.EventHandler(Me.checkBoxes_CheckedChanged)
			' 
			' chkRecursive
			' 
			Me.chkRecursive.Location = New System.Drawing.Point(9, 88)
			Me.chkRecursive.Name = "chkRecursive"
			Me.chkRecursive.Size = New System.Drawing.Size(252, 20)
			Me.chkRecursive.TabIndex = 10
			Me.chkRecursive.Text = "Apply changes to this folder, subfolders and files"
			' 
			' groupBox1
			' 
			Me.groupBox1.Location = New System.Drawing.Point(8, 113)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(321, 2)
			Me.groupBox1.TabIndex = 92
			Me.groupBox1.TabStop = False
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.Location = New System.Drawing.Point(174, 121)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 11
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(254, 121)
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
			Me.ClientSize = New System.Drawing.Size(335, 152)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.chkRecursive)
			Me.Controls.Add(Me.grbPublic)
			Me.Controls.Add(Me.grbGroup)
			Me.Controls.Add(Me.grbUser)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "PropertiesForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Properties"
			Me.grbUser.ResumeLayout(False)
			Me.grbGroup.ResumeLayout(False)
			Me.grbPublic.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private grbUser As System.Windows.Forms.GroupBox
		Private WithEvents chkOwnerExecute As System.Windows.Forms.CheckBox
		Private WithEvents chkOwnerWrite As System.Windows.Forms.CheckBox
		Private WithEvents chkOwnerRead As System.Windows.Forms.CheckBox
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
	End Class
End Namespace