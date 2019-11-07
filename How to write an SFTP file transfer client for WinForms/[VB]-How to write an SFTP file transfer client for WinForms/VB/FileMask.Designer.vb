Namespace ClientSample
	Partial Public Class FileMask
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
			Me.txtFileType = New System.Windows.Forms.TextBox()
			Me.groupBox = New System.Windows.Forms.GroupBox()
			Me.lbl = New System.Windows.Forms.Label()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.groupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' txtFileType
			' 
			Me.txtFileType.Location = New System.Drawing.Point(101, 22)
			Me.txtFileType.Name = "txtFileType"
			Me.txtFileType.Size = New System.Drawing.Size(238, 20)
			Me.txtFileType.TabIndex = 13
			' 
			' groupBox
			' 
			Me.groupBox.Controls.Add(Me.lbl)
			Me.groupBox.Location = New System.Drawing.Point(7, 4)
			Me.groupBox.Name = "groupBox"
			Me.groupBox.Size = New System.Drawing.Size(342, 53)
			Me.groupBox.TabIndex = 12
			Me.groupBox.TabStop = False
			' 
			' lbl
			' 
			Me.lbl.Location = New System.Drawing.Point(7, 21)
			Me.lbl.Name = "lbl"
			Me.lbl.Size = New System.Drawing.Size(88, 16)
			Me.lbl.TabIndex = 0
			Me.lbl.Text = "Specify file type:"
			' 
			' btnOk
			' 
			Me.btnOk.Location = New System.Drawing.Point(194, 63)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 14
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(274, 63)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 15
			Me.btnCancel.Text = "&Cancel"
			' 
			' FileMask
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(355, 94)
			Me.Controls.Add(Me.txtFileType)
			Me.Controls.Add(Me.groupBox)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "FileMask"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.groupBox.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private txtFileType As System.Windows.Forms.TextBox
		Private groupBox As System.Windows.Forms.GroupBox
		Private lbl As System.Windows.Forms.Label
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
	End Class
End Namespace