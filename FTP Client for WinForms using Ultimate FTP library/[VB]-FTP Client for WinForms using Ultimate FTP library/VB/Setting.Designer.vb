Namespace ClientSample
	Partial Public Class Setting
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
			Me.chkSmartPath = New System.Windows.Forms.CheckBox()
			Me.chkChDirBeforeTransfer = New System.Windows.Forms.CheckBox()
			Me.chkChDirBeforeListing = New System.Windows.Forms.CheckBox()
			Me.chkSendABOR = New System.Windows.Forms.CheckBox()
			Me.chkSendSignals = New System.Windows.Forms.CheckBox()
			Me.lblKAS = New System.Windows.Forms.Label()
			Me.lblKeepAlive = New System.Windows.Forms.Label()
			Me.txtKeepAliveInterval = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.lblTimeout = New System.Windows.Forms.Label()
			Me.txtTimeout = New System.Windows.Forms.TextBox()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.chkCompress = New System.Windows.Forms.CheckBox()
			Me.rbtBinary = New System.Windows.Forms.RadioButton()
			Me.rbtAscii = New System.Windows.Forms.RadioButton()
			Me.tabControlExt = New System.Windows.Forms.TabControl()
			Me.generalPage = New System.Windows.Forms.TabPage()
			Me.lblProgressSlow = New System.Windows.Forms.Label()
			Me.lblThrottle = New System.Windows.Forms.Label()
			Me.lblProgressFast = New System.Windows.Forms.Label()
			Me.txtThrottle = New System.Windows.Forms.TextBox()
			Me.tbProgress = New System.Windows.Forms.TrackBar()
			Me.lblKBPS = New System.Windows.Forms.Label()
			Me.lblProgressUpdate = New System.Windows.Forms.Label()
			Me.ftpPage = New System.Windows.Forms.TabPage()
			Me.sftpPage = New System.Windows.Forms.TabPage()
			Me.lblServer = New System.Windows.Forms.Label()
			Me.cbxServerOs = New System.Windows.Forms.ComboBox()
			Me.chkRestoreProperties = New System.Windows.Forms.CheckBox()
			Me.chkShowProgressWhileTransferring = New System.Windows.Forms.CheckBox()
			Me.chkShowProgress = New System.Windows.Forms.CheckBox()
			Me.tabControlExt.SuspendLayout()
			Me.generalPage.SuspendLayout()
			CType(Me.tbProgress, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.ftpPage.SuspendLayout()
			Me.sftpPage.SuspendLayout()
			Me.SuspendLayout()
			' 
			' chkSmartPath
			' 
			Me.chkSmartPath.BackColor = System.Drawing.SystemColors.Control
			Me.chkSmartPath.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkSmartPath.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkSmartPath.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkSmartPath.Location = New System.Drawing.Point(11, 67)
			Me.chkSmartPath.Name = "chkSmartPath"
			Me.chkSmartPath.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkSmartPath.Size = New System.Drawing.Size(129, 22)
			Me.chkSmartPath.TabIndex = 4
			Me.chkSmartPath.Text = "Smart Path Resolving"
			Me.chkSmartPath.UseVisualStyleBackColor = False
			' 
			' chkChDirBeforeTransfer
			' 
			Me.chkChDirBeforeTransfer.BackColor = System.Drawing.SystemColors.Control
			Me.chkChDirBeforeTransfer.Checked = True
			Me.chkChDirBeforeTransfer.CheckState = System.Windows.Forms.CheckState.Checked
			Me.chkChDirBeforeTransfer.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkChDirBeforeTransfer.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkChDirBeforeTransfer.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkChDirBeforeTransfer.Location = New System.Drawing.Point(11, 117)
			Me.chkChDirBeforeTransfer.Name = "chkChDirBeforeTransfer"
			Me.chkChDirBeforeTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkChDirBeforeTransfer.Size = New System.Drawing.Size(287, 22)
			Me.chkChDirBeforeTransfer.TabIndex = 7
			Me.chkChDirBeforeTransfer.Text = "Change Dir before transferring files (slow but reliable)"
			Me.chkChDirBeforeTransfer.UseVisualStyleBackColor = False
			' 
			' chkChDirBeforeListing
			' 
			Me.chkChDirBeforeListing.BackColor = System.Drawing.SystemColors.Control
			Me.chkChDirBeforeListing.Checked = True
			Me.chkChDirBeforeListing.CheckState = System.Windows.Forms.CheckState.Checked
			Me.chkChDirBeforeListing.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkChDirBeforeListing.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkChDirBeforeListing.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkChDirBeforeListing.Location = New System.Drawing.Point(11, 95)
			Me.chkChDirBeforeListing.Name = "chkChDirBeforeListing"
			Me.chkChDirBeforeListing.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkChDirBeforeListing.Size = New System.Drawing.Size(234, 22)
			Me.chkChDirBeforeListing.TabIndex = 6
			Me.chkChDirBeforeListing.Text = "Change Dir before listing (slow but reliable)"
			Me.chkChDirBeforeListing.UseVisualStyleBackColor = False
			' 
			' chkSendABOR
			' 
			Me.chkSendABOR.BackColor = System.Drawing.SystemColors.Control
			Me.chkSendABOR.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkSendABOR.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkSendABOR.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkSendABOR.Location = New System.Drawing.Point(11, 31)
			Me.chkSendABOR.Name = "chkSendABOR"
			Me.chkSendABOR.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkSendABOR.Size = New System.Drawing.Size(257, 18)
			Me.chkSendABOR.TabIndex = 2
			Me.chkSendABOR.Text = "Send ABOR command when aborting download"
			Me.chkSendABOR.ThreeState = True
			Me.chkSendABOR.UseVisualStyleBackColor = False
			' 
			' chkSendSignals
			' 
			Me.chkSendSignals.BackColor = System.Drawing.SystemColors.Control
			Me.chkSendSignals.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkSendSignals.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkSendSignals.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkSendSignals.Location = New System.Drawing.Point(11, 49)
			Me.chkSendSignals.Name = "chkSendSignals"
			Me.chkSendSignals.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkSendSignals.Size = New System.Drawing.Size(212, 20)
			Me.chkSendSignals.TabIndex = 3
			Me.chkSendSignals.Text = "Send signals when aborting download"
			Me.chkSendSignals.UseVisualStyleBackColor = False
			' 
			' lblKAS
			' 
			Me.lblKAS.BackColor = System.Drawing.SystemColors.Control
			Me.lblKAS.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblKAS.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblKAS.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblKAS.Location = New System.Drawing.Point(156, 18)
			Me.lblKAS.Name = "lblKAS"
			Me.lblKAS.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblKAS.Size = New System.Drawing.Size(10, 14)
			Me.lblKAS.TabIndex = 87
			Me.lblKAS.Text = "s"
			' 
			' lblKeepAlive
			' 
			Me.lblKeepAlive.BackColor = System.Drawing.SystemColors.Control
			Me.lblKeepAlive.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblKeepAlive.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblKeepAlive.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblKeepAlive.Location = New System.Drawing.Point(11, 12)
			Me.lblKeepAlive.Name = "lblKeepAlive"
			Me.lblKeepAlive.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblKeepAlive.Size = New System.Drawing.Size(70, 28)
			Me.lblKeepAlive.TabIndex = 86
			Me.lblKeepAlive.Text = "Keep Alive Interval:"
			' 
			' txtKeepAliveInterval
			' 
			Me.txtKeepAliveInterval.AcceptsReturn = True
			Me.txtKeepAliveInterval.BackColor = System.Drawing.SystemColors.Window
			Me.txtKeepAliveInterval.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.txtKeepAliveInterval.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.txtKeepAliveInterval.Location = New System.Drawing.Point(85, 14)
			Me.txtKeepAliveInterval.MaxLength = 3
			Me.txtKeepAliveInterval.Name = "txtKeepAliveInterval"
			Me.txtKeepAliveInterval.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.txtKeepAliveInterval.Size = New System.Drawing.Size(62, 20)
			Me.txtKeepAliveInterval.TabIndex = 1
			Me.txtKeepAliveInterval.Text = "60"
			Me.txtKeepAliveInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' label3
			' 
			Me.label3.BackColor = System.Drawing.SystemColors.Control
			Me.label3.Cursor = System.Windows.Forms.Cursors.Default
			Me.label3.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
			Me.label3.Location = New System.Drawing.Point(326, 17)
			Me.label3.Name = "label3"
			Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.label3.Size = New System.Drawing.Size(10, 14)
			Me.label3.TabIndex = 83
			Me.label3.Text = "s"
			' 
			' lblTimeout
			' 
			Me.lblTimeout.BackColor = System.Drawing.SystemColors.Control
			Me.lblTimeout.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblTimeout.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblTimeout.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblTimeout.Location = New System.Drawing.Point(211, 17)
			Me.lblTimeout.Name = "lblTimeout"
			Me.lblTimeout.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblTimeout.Size = New System.Drawing.Size(48, 14)
			Me.lblTimeout.TabIndex = 82
			Me.lblTimeout.Text = "Timeout:"
			' 
			' txtTimeout
			' 
			Me.txtTimeout.AcceptsReturn = True
			Me.txtTimeout.BackColor = System.Drawing.SystemColors.Window
			Me.txtTimeout.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.txtTimeout.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.txtTimeout.Location = New System.Drawing.Point(286, 14)
			Me.txtTimeout.MaxLength = 3
			Me.txtTimeout.Name = "txtTimeout"
			Me.txtTimeout.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.txtTimeout.Size = New System.Drawing.Size(36, 20)
			Me.txtTimeout.TabIndex = 2
			Me.txtTimeout.Text = "30"
			Me.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' btnOK
			' 
			Me.btnOK.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOK.Location = New System.Drawing.Point(240, 281)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(75, 23)
			Me.btnOK.TabIndex = 40
			Me.btnOK.Text = "OK"
'			Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(321, 281)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 41
			Me.btnCancel.Text = "Cancel"
			' 
			' chkCompress
			' 
			Me.chkCompress.BackColor = System.Drawing.SystemColors.Control
			Me.chkCompress.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkCompress.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkCompress.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkCompress.Location = New System.Drawing.Point(11, 10)
			Me.chkCompress.Name = "chkCompress"
			Me.chkCompress.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkCompress.Size = New System.Drawing.Size(180, 17)
			Me.chkCompress.TabIndex = 1
			Me.chkCompress.Text = "Enable Compression (MODE Z)"
			Me.chkCompress.UseVisualStyleBackColor = False
			' 
			' rbtBinary
			' 
			Me.rbtBinary.Location = New System.Drawing.Point(15, 207)
			Me.rbtBinary.Name = "rbtBinary"
			Me.rbtBinary.Size = New System.Drawing.Size(96, 26)
			Me.rbtBinary.TabIndex = 7
			Me.rbtBinary.Text = "Binary Transfer"
			' 
			' rbtAscii
			' 
			Me.rbtAscii.Location = New System.Drawing.Point(15, 189)
			Me.rbtAscii.Name = "rbtAscii"
			Me.rbtAscii.Size = New System.Drawing.Size(94, 20)
			Me.rbtAscii.TabIndex = 6
			Me.rbtAscii.Text = "ASCII Transfer"
			' 
			' tabControlExt
			' 
			Me.tabControlExt.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tabControlExt.Controls.Add(Me.generalPage)
			Me.tabControlExt.Controls.Add(Me.ftpPage)
			Me.tabControlExt.Controls.Add(Me.sftpPage)
			Me.tabControlExt.Location = New System.Drawing.Point(7, 6)
			Me.tabControlExt.Name = "tabControlExt"
			Me.tabControlExt.SelectedIndex = 0
			Me.tabControlExt.Size = New System.Drawing.Size(390, 268)
			Me.tabControlExt.TabIndex = 114
			' 
			' generalPage
			' 
			Me.generalPage.Controls.Add(Me.chkRestoreProperties)
			Me.generalPage.Controls.Add(Me.chkShowProgressWhileTransferring)
			Me.generalPage.Controls.Add(Me.chkShowProgress)
			Me.generalPage.Controls.Add(Me.lblProgressSlow)
			Me.generalPage.Controls.Add(Me.lblThrottle)
			Me.generalPage.Controls.Add(Me.lblProgressFast)
			Me.generalPage.Controls.Add(Me.rbtAscii)
			Me.generalPage.Controls.Add(Me.rbtBinary)
			Me.generalPage.Controls.Add(Me.txtThrottle)
			Me.generalPage.Controls.Add(Me.tbProgress)
			Me.generalPage.Controls.Add(Me.lblKBPS)
			Me.generalPage.Controls.Add(Me.lblKAS)
			Me.generalPage.Controls.Add(Me.lblProgressUpdate)
			Me.generalPage.Controls.Add(Me.lblKeepAlive)
			Me.generalPage.Controls.Add(Me.txtKeepAliveInterval)
			Me.generalPage.Controls.Add(Me.txtTimeout)
			Me.generalPage.Controls.Add(Me.label3)
			Me.generalPage.Controls.Add(Me.lblTimeout)
			Me.generalPage.Location = New System.Drawing.Point(4, 22)
			Me.generalPage.Name = "generalPage"
			Me.generalPage.Padding = New System.Windows.Forms.Padding(3)
			Me.generalPage.Size = New System.Drawing.Size(382, 242)
			Me.generalPage.TabIndex = 0
			Me.generalPage.Text = "General Settings"
			Me.generalPage.UseVisualStyleBackColor = True
			' 
			' lblProgressSlow
			' 
			Me.lblProgressSlow.BackColor = System.Drawing.SystemColors.Control
			Me.lblProgressSlow.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblProgressSlow.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblProgressSlow.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblProgressSlow.Location = New System.Drawing.Point(303, 152)
			Me.lblProgressSlow.Name = "lblProgressSlow"
			Me.lblProgressSlow.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblProgressSlow.Size = New System.Drawing.Size(35, 14)
			Me.lblProgressSlow.TabIndex = 95
			Me.lblProgressSlow.Text = "Slow"
			' 
			' lblThrottle
			' 
			Me.lblThrottle.BackColor = System.Drawing.SystemColors.Control
			Me.lblThrottle.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblThrottle.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblThrottle.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblThrottle.Location = New System.Drawing.Point(10, 45)
			Me.lblThrottle.Name = "lblThrottle"
			Me.lblThrottle.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblThrottle.Size = New System.Drawing.Size(46, 14)
			Me.lblThrottle.TabIndex = 90
			Me.lblThrottle.Text = "Throttle:"
			' 
			' lblProgressFast
			' 
			Me.lblProgressFast.BackColor = System.Drawing.SystemColors.Control
			Me.lblProgressFast.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblProgressFast.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblProgressFast.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblProgressFast.Location = New System.Drawing.Point(75, 153)
			Me.lblProgressFast.Name = "lblProgressFast"
			Me.lblProgressFast.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblProgressFast.Size = New System.Drawing.Size(28, 14)
			Me.lblProgressFast.TabIndex = 94
			Me.lblProgressFast.Text = "Fast"
			' 
			' txtThrottle
			' 
			Me.txtThrottle.AcceptsReturn = True
			Me.txtThrottle.BackColor = System.Drawing.SystemColors.Window
			Me.txtThrottle.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.txtThrottle.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.txtThrottle.Location = New System.Drawing.Point(85, 42)
			Me.txtThrottle.MaxLength = 0
			Me.txtThrottle.Name = "txtThrottle"
			Me.txtThrottle.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.txtThrottle.Size = New System.Drawing.Size(62, 20)
			Me.txtThrottle.TabIndex = 3
			Me.txtThrottle.Text = "0"
			Me.txtThrottle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' tbProgress
			' 
			Me.tbProgress.Location = New System.Drawing.Point(103, 147)
			Me.tbProgress.Maximum = 20
			Me.tbProgress.Minimum = 1
			Me.tbProgress.Name = "tbProgress"
			Me.tbProgress.Size = New System.Drawing.Size(200, 42)
			Me.tbProgress.TabIndex = 5
			Me.tbProgress.Value = 10
			' 
			' lblKBPS
			' 
			Me.lblKBPS.BackColor = System.Drawing.SystemColors.Control
			Me.lblKBPS.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblKBPS.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblKBPS.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblKBPS.Location = New System.Drawing.Point(150, 45)
			Me.lblKBPS.Name = "lblKBPS"
			Me.lblKBPS.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblKBPS.Size = New System.Drawing.Size(22, 14)
			Me.lblKBPS.TabIndex = 91
			Me.lblKBPS.Text = "Kb/s"
			' 
			' lblProgressUpdate
			' 
			Me.lblProgressUpdate.BackColor = System.Drawing.SystemColors.Control
			Me.lblProgressUpdate.Cursor = System.Windows.Forms.Cursors.Default
			Me.lblProgressUpdate.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblProgressUpdate.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblProgressUpdate.Location = New System.Drawing.Point(13, 146)
			Me.lblProgressUpdate.Name = "lblProgressUpdate"
			Me.lblProgressUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.lblProgressUpdate.Size = New System.Drawing.Size(60, 32)
			Me.lblProgressUpdate.TabIndex = 92
			Me.lblProgressUpdate.Text = "Progress Update:"
			' 
			' ftpPage
			' 
			Me.ftpPage.Controls.Add(Me.chkSmartPath)
			Me.ftpPage.Controls.Add(Me.chkCompress)
			Me.ftpPage.Controls.Add(Me.chkChDirBeforeTransfer)
			Me.ftpPage.Controls.Add(Me.chkChDirBeforeListing)
			Me.ftpPage.Controls.Add(Me.chkSendABOR)
			Me.ftpPage.Controls.Add(Me.chkSendSignals)
			Me.ftpPage.Location = New System.Drawing.Point(4, 22)
			Me.ftpPage.Name = "ftpPage"
			Me.ftpPage.Padding = New System.Windows.Forms.Padding(3)
			Me.ftpPage.Size = New System.Drawing.Size(355, 197)
			Me.ftpPage.TabIndex = 1
			Me.ftpPage.Text = "FTP Settings"
			Me.ftpPage.UseVisualStyleBackColor = True
			' 
			' sftpPage
			' 
			Me.sftpPage.Controls.Add(Me.lblServer)
			Me.sftpPage.Controls.Add(Me.cbxServerOs)
			Me.sftpPage.Location = New System.Drawing.Point(4, 22)
			Me.sftpPage.Name = "sftpPage"
			Me.sftpPage.Size = New System.Drawing.Size(355, 197)
			Me.sftpPage.TabIndex = 2
			Me.sftpPage.Text = "SFTP Settings"
			Me.sftpPage.UseVisualStyleBackColor = True
			' 
			' lblServer
			' 
			Me.lblServer.Location = New System.Drawing.Point(10, 9)
			Me.lblServer.Name = "lblServer"
			Me.lblServer.Size = New System.Drawing.Size(59, 13)
			Me.lblServer.TabIndex = 45
			Me.lblServer.Text = "Server OS:"
			' 
			' cbxServerOs
			' 
			Me.cbxServerOs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxServerOs.FormattingEnabled = True
			Me.cbxServerOs.Items.AddRange(New Object() { "Auto Detect (Default)", "Unknown", "Windows", "Linux"})
			Me.cbxServerOs.Location = New System.Drawing.Point(74, 5)
			Me.cbxServerOs.Name = "cbxServerOs"
			Me.cbxServerOs.Size = New System.Drawing.Size(144, 21)
			Me.cbxServerOs.TabIndex = 4
			' 
			' chkRestoreProperties
			' 
			Me.chkRestoreProperties.BackColor = System.Drawing.SystemColors.Control
			Me.chkRestoreProperties.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkRestoreProperties.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkRestoreProperties.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkRestoreProperties.Location = New System.Drawing.Point(16, 69)
			Me.chkRestoreProperties.Name = "chkRestoreProperties"
			Me.chkRestoreProperties.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkRestoreProperties.Size = New System.Drawing.Size(200, 20)
			Me.chkRestoreProperties.TabIndex = 117
			Me.chkRestoreProperties.Text = "Restore file datetime after transfer"
			Me.chkRestoreProperties.UseVisualStyleBackColor = False
			' 
			' chkShowProgressWhileTransferring
			' 
			Me.chkShowProgressWhileTransferring.BackColor = System.Drawing.SystemColors.Control
			Me.chkShowProgressWhileTransferring.Checked = True
			Me.chkShowProgressWhileTransferring.CheckState = System.Windows.Forms.CheckState.Checked
			Me.chkShowProgressWhileTransferring.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkShowProgressWhileTransferring.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkShowProgressWhileTransferring.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkShowProgressWhileTransferring.Location = New System.Drawing.Point(16, 116)
			Me.chkShowProgressWhileTransferring.Name = "chkShowProgressWhileTransferring"
			Me.chkShowProgressWhileTransferring.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkShowProgressWhileTransferring.Size = New System.Drawing.Size(362, 20)
			Me.chkShowProgressWhileTransferring.TabIndex = 116
			Me.chkShowProgressWhileTransferring.Text = "Show progress when transferring multiple files or directories"
			Me.chkShowProgressWhileTransferring.UseVisualStyleBackColor = False
			' 
			' chkShowProgress
			' 
			Me.chkShowProgress.BackColor = System.Drawing.SystemColors.Control
			Me.chkShowProgress.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkShowProgress.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkShowProgress.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkShowProgress.Location = New System.Drawing.Point(16, 92)
			Me.chkShowProgress.Name = "chkShowProgress"
			Me.chkShowProgress.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkShowProgress.Size = New System.Drawing.Size(362, 20)
			Me.chkShowProgress.TabIndex = 115
			Me.chkShowProgress.Text = "Show progress when deleting files or setting files attributes"
			Me.chkShowProgress.UseVisualStyleBackColor = False
			' 
			' Setting
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(404, 312)
			Me.Controls.Add(Me.tabControlExt)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOK)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Setting"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Settings"
			Me.tabControlExt.ResumeLayout(False)
			Me.generalPage.ResumeLayout(False)
			Me.generalPage.PerformLayout()
			CType(Me.tbProgress, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ftpPage.ResumeLayout(False)
			Me.sftpPage.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public lblKAS As System.Windows.Forms.Label
		Public lblKeepAlive As System.Windows.Forms.Label
		Public txtKeepAliveInterval As System.Windows.Forms.TextBox
		Public label3 As System.Windows.Forms.Label
		Public lblTimeout As System.Windows.Forms.Label
		Public txtTimeout As System.Windows.Forms.TextBox
		Private WithEvents btnOK As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private rbtBinary As System.Windows.Forms.RadioButton
		Private rbtAscii As System.Windows.Forms.RadioButton
		Public chkSendABOR As System.Windows.Forms.CheckBox
		Public chkSendSignals As System.Windows.Forms.CheckBox
		Public chkChDirBeforeTransfer As System.Windows.Forms.CheckBox
		Public chkChDirBeforeListing As System.Windows.Forms.CheckBox
		Public chkCompress As System.Windows.Forms.CheckBox
		Public chkSmartPath As System.Windows.Forms.CheckBox
		Private tabControlExt As System.Windows.Forms.TabControl
		Private generalPage As System.Windows.Forms.TabPage
		Private ftpPage As System.Windows.Forms.TabPage
		Private sftpPage As System.Windows.Forms.TabPage
		Public lblProgressSlow As System.Windows.Forms.Label
		Public lblThrottle As System.Windows.Forms.Label
		Public lblProgressFast As System.Windows.Forms.Label
		Public txtThrottle As System.Windows.Forms.TextBox
		Private tbProgress As System.Windows.Forms.TrackBar
		Public lblKBPS As System.Windows.Forms.Label
		Public lblProgressUpdate As System.Windows.Forms.Label
		Private cbxServerOs As System.Windows.Forms.ComboBox
		Private lblServer As System.Windows.Forms.Label
		Public chkRestoreProperties As System.Windows.Forms.CheckBox
		Public chkShowProgressWhileTransferring As System.Windows.Forms.CheckBox
		Public chkShowProgress As System.Windows.Forms.CheckBox
	End Class
End Namespace