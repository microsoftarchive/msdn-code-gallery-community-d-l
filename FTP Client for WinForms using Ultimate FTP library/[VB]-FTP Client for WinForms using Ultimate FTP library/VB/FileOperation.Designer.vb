Namespace ClientSample
	Partial Public Class FileOperation
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
			Me.btnFollowLink = New System.Windows.Forms.Button()
			Me.btnSkipAll = New System.Windows.Forms.Button()
			Me.btnOverwriteDiffSize = New System.Windows.Forms.Button()
			Me.btnOverwriteOlder = New System.Windows.Forms.Button()
			Me.btnOverwriteAll = New System.Windows.Forms.Button()
			Me.btnOverwrite = New System.Windows.Forms.Button()
			Me.btnRetry = New System.Windows.Forms.Button()
			Me.btnRename = New System.Windows.Forms.Button()
			Me.btnSkip = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.lblMessage = New System.Windows.Forms.Label()
			Me.btnResume = New System.Windows.Forms.Button()
			Me.btnResumeAll = New System.Windows.Forms.Button()
			Me.btnFollowLinkAll = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' btnFollowLink
			' 
			Me.btnFollowLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnFollowLink.Location = New System.Drawing.Point(143, 203)
			Me.btnFollowLink.Name = "btnFollowLink"
			Me.btnFollowLink.Size = New System.Drawing.Size(128, 24)
			Me.btnFollowLink.TabIndex = 8
			Me.btnFollowLink.Text = "Follow &Link"
			Me.btnFollowLink.Visible = False
'			Me.btnFollowLink.Click += New System.EventHandler(Me.btnFollowLink_Click)
			' 
			' btnSkipAll
			' 
			Me.btnSkipAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnSkipAll.Location = New System.Drawing.Point(9, 203)
			Me.btnSkipAll.Name = "btnSkipAll"
			Me.btnSkipAll.Size = New System.Drawing.Size(128, 24)
			Me.btnSkipAll.TabIndex = 7
			Me.btnSkipAll.Text = "S&kip All"
			Me.btnSkipAll.Visible = False
'			Me.btnSkipAll.Click += New System.EventHandler(Me.btnSkipAll_Click)
			' 
			' btnOverwriteDiffSize
			' 
			Me.btnOverwriteDiffSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnOverwriteDiffSize.Location = New System.Drawing.Point(9, 173)
			Me.btnOverwriteDiffSize.Name = "btnOverwriteDiffSize"
			Me.btnOverwriteDiffSize.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwriteDiffSize.TabIndex = 4
			Me.btnOverwriteDiffSize.Text = "Overwrite &Different Files"
			Me.btnOverwriteDiffSize.Visible = False
'			Me.btnOverwriteDiffSize.Click += New System.EventHandler(Me.btnOverwriteDiffSize_Click)
			' 
			' btnOverwriteOlder
			' 
			Me.btnOverwriteOlder.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnOverwriteOlder.Location = New System.Drawing.Point(277, 143)
			Me.btnOverwriteOlder.Name = "btnOverwriteOlder"
			Me.btnOverwriteOlder.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwriteOlder.TabIndex = 3
			Me.btnOverwriteOlder.Text = "Overwrite &Older Files"
			Me.btnOverwriteOlder.Visible = False
'			Me.btnOverwriteOlder.Click += New System.EventHandler(Me.btnOverwriteOlder_Click)
			' 
			' btnOverwriteAll
			' 
			Me.btnOverwriteAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnOverwriteAll.Location = New System.Drawing.Point(143, 143)
			Me.btnOverwriteAll.Name = "btnOverwriteAll"
			Me.btnOverwriteAll.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwriteAll.TabIndex = 2
			Me.btnOverwriteAll.Text = "Overwrite &All"
			Me.btnOverwriteAll.Visible = False
'			Me.btnOverwriteAll.Click += New System.EventHandler(Me.btnOverwriteAll_Click)
			' 
			' btnOverwrite
			' 
			Me.btnOverwrite.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnOverwrite.Location = New System.Drawing.Point(9, 143)
			Me.btnOverwrite.Name = "btnOverwrite"
			Me.btnOverwrite.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwrite.TabIndex = 1
			Me.btnOverwrite.Text = "&Overwrite"
			Me.btnOverwrite.Visible = False
'			Me.btnOverwrite.Click += New System.EventHandler(Me.btnOverwrite_Click)
			' 
			' btnRetry
			' 
			Me.btnRetry.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnRetry.Location = New System.Drawing.Point(277, 203)
			Me.btnRetry.Name = "btnRetry"
			Me.btnRetry.Size = New System.Drawing.Size(128, 24)
			Me.btnRetry.TabIndex = 9
			Me.btnRetry.Text = "Re&try"
			Me.btnRetry.Visible = False
'			Me.btnRetry.Click += New System.EventHandler(Me.btnRetry_Click)
			' 
			' btnRename
			' 
			Me.btnRename.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnRename.Location = New System.Drawing.Point(143, 173)
			Me.btnRename.Name = "btnRename"
			Me.btnRename.Size = New System.Drawing.Size(128, 24)
			Me.btnRename.TabIndex = 5
			Me.btnRename.Text = "&Rename..."
			Me.btnRename.Visible = False
'			Me.btnRename.Click += New System.EventHandler(Me.btnRename_Click)
			' 
			' btnSkip
			' 
			Me.btnSkip.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnSkip.Location = New System.Drawing.Point(277, 173)
			Me.btnSkip.Name = "btnSkip"
			Me.btnSkip.Size = New System.Drawing.Size(128, 24)
			Me.btnSkip.TabIndex = 6
			Me.btnSkip.Text = "&Skip"
			Me.btnSkip.Visible = False
'			Me.btnSkip.Click += New System.EventHandler(Me.btnSkip_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnCancel.Location = New System.Drawing.Point(343, 143)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(128, 24)
			Me.btnCancel.TabIndex = 10
			Me.btnCancel.Text = "&Cancel"
			Me.btnCancel.Visible = False
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' lblMessage
			' 
			Me.lblMessage.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblMessage.BackColor = System.Drawing.Color.Transparent
			Me.lblMessage.Location = New System.Drawing.Point(8, 8)
			Me.lblMessage.Name = "lblMessage"
			Me.lblMessage.Size = New System.Drawing.Size(463, 123)
			Me.lblMessage.TabIndex = 11
			' 
			' btnResume
			' 
			Me.btnResume.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnResume.Location = New System.Drawing.Point(343, 203)
			Me.btnResume.Name = "btnResume"
			Me.btnResume.Size = New System.Drawing.Size(128, 24)
			Me.btnResume.TabIndex = 12
			Me.btnResume.Text = "R&esume Transfer"
			Me.btnResume.Visible = False
'			Me.btnResume.Click += New System.EventHandler(Me.btnResume_Click)
			' 
			' btnResumeAll
			' 
			Me.btnResumeAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnResumeAll.Location = New System.Drawing.Point(176, 109)
			Me.btnResumeAll.Name = "btnResumeAll"
			Me.btnResumeAll.Size = New System.Drawing.Size(128, 24)
			Me.btnResumeAll.TabIndex = 13
			Me.btnResumeAll.Text = "Resume Trans&fer All"
			Me.btnResumeAll.Visible = False
'			Me.btnResumeAll.Click += New System.EventHandler(Me.btnResumeAll_Click)
			' 
			' btnFollowLinkAll
			' 
			Me.btnFollowLinkAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnFollowLinkAll.Location = New System.Drawing.Point(9, 113)
			Me.btnFollowLinkAll.Name = "btnFollowLinkAll"
			Me.btnFollowLinkAll.Size = New System.Drawing.Size(128, 24)
			Me.btnFollowLinkAll.TabIndex = 14
			Me.btnFollowLinkAll.Text = "Follow &All Links"
			Me.btnFollowLinkAll.Visible = False
'			Me.btnFollowLinkAll.Click += New System.EventHandler(Me.btnFollowLinkAll_Click)
			' 
			' FileOperation
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(480, 243)
			Me.Controls.Add(Me.btnFollowLinkAll)
			Me.Controls.Add(Me.btnResumeAll)
			Me.Controls.Add(Me.btnResume)
			Me.Controls.Add(Me.lblMessage)
			Me.Controls.Add(Me.btnFollowLink)
			Me.Controls.Add(Me.btnSkipAll)
			Me.Controls.Add(Me.btnOverwriteDiffSize)
			Me.Controls.Add(Me.btnOverwriteOlder)
			Me.Controls.Add(Me.btnOverwriteAll)
			Me.Controls.Add(Me.btnOverwrite)
			Me.Controls.Add(Me.btnRetry)
			Me.Controls.Add(Me.btnRename)
			Me.Controls.Add(Me.btnSkip)
			Me.Controls.Add(Me.btnCancel)
			Me.MinimumSize = New System.Drawing.Size(488, 270)
			Me.Name = "FileOperation"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "File Operation"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btnFollowLink As System.Windows.Forms.Button
		Private WithEvents btnSkipAll As System.Windows.Forms.Button
		Private WithEvents btnOverwriteDiffSize As System.Windows.Forms.Button
		Private WithEvents btnOverwriteOlder As System.Windows.Forms.Button
		Private WithEvents btnOverwriteAll As System.Windows.Forms.Button
		Private WithEvents btnOverwrite As System.Windows.Forms.Button
		Private WithEvents btnRetry As System.Windows.Forms.Button
		Private WithEvents btnRename As System.Windows.Forms.Button
		Private WithEvents btnSkip As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private lblMessage As System.Windows.Forms.Label
		Private WithEvents btnResume As System.Windows.Forms.Button
		Private WithEvents btnResumeAll As System.Windows.Forms.Button
		Private WithEvents btnFollowLinkAll As System.Windows.Forms.Button
	End Class
End Namespace