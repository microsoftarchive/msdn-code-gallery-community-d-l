Namespace ClientSample
	Partial Public Class MirrorFolders
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
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.txtSearchPattern = New System.Windows.Forms.TextBox()
			Me.lblPattern = New System.Windows.Forms.Label()
			Me.cbxComparisonType = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.rbtLocalMaster = New System.Windows.Forms.RadioButton()
			Me.rbtRemoteMaster = New System.Windows.Forms.RadioButton()
			Me.chkRecursive = New System.Windows.Forms.CheckBox()
			Me.chkSyncDateTime = New System.Windows.Forms.CheckBox()
			Me.chkResumability = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.Location = New System.Drawing.Point(194, 173)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 20
			Me.btnOk.Text = "&OK"
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(275, 173)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 21
			Me.btnCancel.Text = "&Cancel"
			' 
			' txtSearchPattern
			' 
			Me.txtSearchPattern.Location = New System.Drawing.Point(75, 60)
			Me.txtSearchPattern.Name = "txtSearchPattern"
			Me.txtSearchPattern.Size = New System.Drawing.Size(176, 20)
			Me.txtSearchPattern.TabIndex = 2
			' 
			' lblPattern
			' 
			Me.lblPattern.Location = New System.Drawing.Point(11, 63)
			Me.lblPattern.Name = "lblPattern"
			Me.lblPattern.Size = New System.Drawing.Size(55, 13)
			Me.lblPattern.TabIndex = 73
			Me.lblPattern.Text = "File Mask:"
			' 
			' cbxComparisonType
			' 
			Me.cbxComparisonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxComparisonType.FormattingEnabled = True
			Me.cbxComparisonType.Items.AddRange(New Object() { "Date Time", "File Content", "Name Only"})
			Me.cbxComparisonType.Location = New System.Drawing.Point(75, 141)
			Me.cbxComparisonType.Name = "cbxComparisonType"
			Me.cbxComparisonType.Size = New System.Drawing.Size(176, 21)
			Me.cbxComparisonType.TabIndex = 5
'			Me.cbxComparisonType.SelectedIndexChanged += New System.EventHandler(Me.cbxComparisonType_SelectedIndexChanged)
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 145)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(66, 13)
			Me.label1.TabIndex = 70
			Me.label1.Text = "Compare by:"
			' 
			' rbtLocalMaster
			' 
			Me.rbtLocalMaster.Location = New System.Drawing.Point(11, 33)
			Me.rbtLocalMaster.Name = "rbtLocalMaster"
			Me.rbtLocalMaster.Size = New System.Drawing.Size(148, 21)
			Me.rbtLocalMaster.TabIndex = 1
			Me.rbtLocalMaster.Text = "Local Folder is master "
			' 
			' rbtRemoteMaster
			' 
			Me.rbtRemoteMaster.Location = New System.Drawing.Point(11, 8)
			Me.rbtRemoteMaster.Name = "rbtRemoteMaster"
			Me.rbtRemoteMaster.Size = New System.Drawing.Size(159, 26)
			Me.rbtRemoteMaster.TabIndex = 0
			Me.rbtRemoteMaster.Text = "Remote Folder is master "
			' 
			' chkRecursive
			' 
			Me.chkRecursive.Location = New System.Drawing.Point(78, 86)
			Me.chkRecursive.Name = "chkRecursive"
			Me.chkRecursive.Size = New System.Drawing.Size(74, 26)
			Me.chkRecursive.TabIndex = 3
			Me.chkRecursive.Text = "Recursive"
			' 
			' chkSyncDateTime
			' 
			Me.chkSyncDateTime.Location = New System.Drawing.Point(78, 105)
			Me.chkSyncDateTime.Name = "chkSyncDateTime"
			Me.chkSyncDateTime.Size = New System.Drawing.Size(272, 30)
			Me.chkSyncDateTime.TabIndex = 4
			Me.chkSyncDateTime.Text = "Synchronize file date time (make sure your PC's time zone and Server's Time Zone " & "are the same)"
			' 
			' chkResumability
			' 
			Me.chkResumability.Location = New System.Drawing.Point(11, 169)
			Me.chkResumability.Name = "chkResumability"
			Me.chkResumability.Size = New System.Drawing.Size(139, 26)
			Me.chkResumability.TabIndex = 6
			Me.chkResumability.Text = "Check for resumability"
			' 
			' SynchronizeFolders
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(357, 205)
			Me.Controls.Add(Me.chkResumability)
			Me.Controls.Add(Me.chkSyncDateTime)
			Me.Controls.Add(Me.chkRecursive)
			Me.Controls.Add(Me.txtSearchPattern)
			Me.Controls.Add(Me.lblPattern)
			Me.Controls.Add(Me.cbxComparisonType)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.rbtLocalMaster)
			Me.Controls.Add(Me.rbtRemoteMaster)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "MirrorFolders"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Synchonize files and directories"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private txtSearchPattern As System.Windows.Forms.TextBox
		Private lblPattern As System.Windows.Forms.Label
		Private WithEvents cbxComparisonType As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private rbtLocalMaster As System.Windows.Forms.RadioButton
		Private rbtRemoteMaster As System.Windows.Forms.RadioButton
		Private chkRecursive As System.Windows.Forms.CheckBox
		Private chkSyncDateTime As System.Windows.Forms.CheckBox
		Private chkResumability As System.Windows.Forms.CheckBox
	End Class
End Namespace