Namespace ClientSample
	Partial Public Class MoveToRemoteFolder
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
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.txtRemoteDir = New System.Windows.Forms.TextBox()
			Me.lblHelp = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.txtMasks = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(282, 99)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(81, 22)
			Me.btnCancel.TabIndex = 11
			Me.btnCancel.Text = "Cancel"
			' 
			' btnOK
			' 
			Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOK.Location = New System.Drawing.Point(195, 99)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(81, 22)
			Me.btnOK.TabIndex = 10
			Me.btnOK.Text = "OK"
			' 
			' txtRemoteDir
			' 
			Me.txtRemoteDir.Location = New System.Drawing.Point(10, 25)
			Me.txtRemoteDir.Name = "txtRemoteDir"
			Me.txtRemoteDir.Size = New System.Drawing.Size(353, 20)
			Me.txtRemoteDir.TabIndex = 1
			' 
			' lblHelp
			' 
			Me.lblHelp.AutoSize = True
			Me.lblHelp.Location = New System.Drawing.Point(7, 7)
			Me.lblHelp.Name = "lblHelp"
			Me.lblHelp.Size = New System.Drawing.Size(82, 13)
			Me.lblHelp.TabIndex = 117
			Me.lblHelp.Text = "Move item(s) to:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(7, 53)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(255, 13)
			Me.label1.TabIndex = 121
			Me.label1.Text = "File Masks (leave blank to move the entire directory):"
			' 
			' txtMasks
			' 
			Me.txtMasks.Location = New System.Drawing.Point(10, 71)
			Me.txtMasks.Name = "txtMasks"
			Me.txtMasks.Size = New System.Drawing.Size(353, 20)
			Me.txtMasks.TabIndex = 2
			' 
			' MoveToRemoteFolder
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(375, 133)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.txtMasks)
			Me.Controls.Add(Me.lblHelp)
			Me.Controls.Add(Me.txtRemoteDir)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOK)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "MoveToRemoteFolder"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Move to folder"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private btnCancel As System.Windows.Forms.Button
		Private btnOK As System.Windows.Forms.Button
		Private txtRemoteDir As System.Windows.Forms.TextBox
		Private lblHelp As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private txtMasks As System.Windows.Forms.TextBox
	End Class
End Namespace