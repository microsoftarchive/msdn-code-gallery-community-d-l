Namespace ClientSample
	Partial Public Class Main
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
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Main))
			Me.localContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
			Me.lcmMakeDir = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmSynchronize = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem10 = New System.Windows.Forms.ToolStripSeparator()
			Me.lcmSelectGroup = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmUnselectGroup = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem6 = New System.Windows.Forms.ToolStripSeparator()
			Me.lcmRename = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmDelete = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmMove = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem7 = New System.Windows.Forms.ToolStripSeparator()
			Me.lcmView = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmUpload = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmResumeUpload = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmUploadUnique = New System.Windows.Forms.ToolStripMenuItem()
			Me.lcmProperties = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem8 = New System.Windows.Forms.ToolStripSeparator()
			Me.lcmRefresh = New System.Windows.Forms.ToolStripMenuItem()
			Me.imglist = New System.Windows.Forms.ImageList(Me.components)
			Me.remoteContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
			Me.mnuPopMkdir = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopSynchronize = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopExecuteCommand = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopGetTimeDiff = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem9 = New System.Windows.Forms.ToolStripSeparator()
			Me.mnuPopSelectGroup = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopUnselectGroup = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem3 = New System.Windows.Forms.ToolStripSeparator()
			Me.mnuPopRename = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopDelete = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopDeleteMultipleFiles = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopMove = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem1 = New System.Windows.Forms.ToolStripSeparator()
			Me.mnuPopView = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopRetrieve = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopResumeDownload = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopCalcTotalSize = New System.Windows.Forms.ToolStripMenuItem()
			Me.mnuPopProperties = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuItem4 = New System.Windows.Forms.ToolStripSeparator()
			Me.mnuPopRefresh = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuStrip = New System.Windows.Forms.MenuStrip()
			Me.fileMenu = New System.Windows.Forms.ToolStripMenuItem()
			Me.loginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
			Me.makeDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.synchronizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.executeCommandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.getTimeDifferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.renameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.deleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.deleteMultipleFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.moveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.downloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.uploadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.uploadUniqueFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.resumeDownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.resumeUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.calculateTotalSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.propertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.refreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.settingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
			Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
			Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
			Me.progressBar = New System.Windows.Forms.ProgressBar()
			Me.splitContainerUpDown = New System.Windows.Forms.SplitContainer()
			Me.splitContainerLeftRight = New System.Windows.Forms.SplitContainer()
			Me.btnLocalDirBrowse = New System.Windows.Forms.Button()
			Me.txtLocalDir = New System.Windows.Forms.TextBox()
			Me.lblLocalDir = New System.Windows.Forms.Label()
			Me.lvwLocal = New ClientSample.DragAndDropListView()
			Me.chFileName = New System.Windows.Forms.ColumnHeader()
			Me.chSize = New System.Windows.Forms.ColumnHeader()
			Me.chDateTime = New System.Windows.Forms.ColumnHeader()
			Me.txtRemoteDir = New System.Windows.Forms.TextBox()
			Me.lblRemoteDir = New System.Windows.Forms.Label()
			Me.lvwRemote = New ClientSample.DragAndDropListView()
			Me.colFileName = New System.Windows.Forms.ColumnHeader()
			Me.colSize = New System.Windows.Forms.ColumnHeader()
			Me.colDate = New System.Windows.Forms.ColumnHeader()
			Me.colPermissions = New System.Windows.Forms.ColumnHeader()
			Me.txtLog = New System.Windows.Forms.RichTextBox()
			Me.progressBarTotal = New System.Windows.Forms.ProgressBar()
			Me.btnAbort = New System.Windows.Forms.ToolStripButton()
			Me.keepAliveTimer = New System.Windows.Forms.Timer(Me.components)
			Me.tsbLogin = New System.Windows.Forms.ToolStripButton()
			Me.tsbLogout = New System.Windows.Forms.ToolStripButton()
			Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
			Me.tsbSettings = New System.Windows.Forms.ToolStripButton()
			Me.tsbCreateDir = New System.Windows.Forms.ToolStripButton()
			Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
			Me.tsbMove = New System.Windows.Forms.ToolStripButton()
			Me.tsbDownload = New System.Windows.Forms.ToolStripButton()
			Me.tsbUpload = New System.Windows.Forms.ToolStripButton()
			Me.tsbView = New System.Windows.Forms.ToolStripButton()
			Me.tsbSynchronize = New System.Windows.Forms.ToolStripButton()
			Me.toolbarMain = New System.Windows.Forms.ToolStrip()
			Me.statusStrip = New System.Windows.Forms.StatusStrip()
			Me.status = New System.Windows.Forms.ToolStripStatusLabel()
			Me.localContextMenu.SuspendLayout()
			Me.remoteContextMenu.SuspendLayout()
			Me.menuStrip.SuspendLayout()
			Me.splitContainerUpDown.Panel1.SuspendLayout()
			Me.splitContainerUpDown.Panel2.SuspendLayout()
			Me.splitContainerUpDown.SuspendLayout()
			Me.splitContainerLeftRight.Panel1.SuspendLayout()
			Me.splitContainerLeftRight.Panel2.SuspendLayout()
			Me.splitContainerLeftRight.SuspendLayout()
			Me.toolbarMain.SuspendLayout()
			Me.statusStrip.SuspendLayout()
			Me.SuspendLayout()
			' 
			' localContextMenu
			' 
			Me.localContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.lcmMakeDir, Me.lcmSynchronize, Me.menuItem10, Me.lcmSelectGroup, Me.lcmUnselectGroup, Me.menuItem6, Me.lcmRename, Me.lcmDelete, Me.lcmMove, Me.menuItem7, Me.lcmView, Me.lcmUpload, Me.lcmResumeUpload, Me.lcmUploadUnique, Me.lcmProperties, Me.menuItem8, Me.lcmRefresh})
			Me.localContextMenu.Name = "localContextMenu"
			Me.localContextMenu.Size = New System.Drawing.Size(160, 314)
'			Me.localContextMenu.Opening += New System.ComponentModel.CancelEventHandler(Me.localContextMenu_Popup)
			' 
			' lcmMakeDir
			' 
			Me.lcmMakeDir.Image = (CType(resources.GetObject("lcmMakeDir.Image"), System.Drawing.Image))
			Me.lcmMakeDir.Name = "lcmMakeDir"
			Me.lcmMakeDir.Size = New System.Drawing.Size(159, 22)
			Me.lcmMakeDir.Text = "&Make Directory"
'			Me.lcmMakeDir.Click += New System.EventHandler(Me.lcmMakeDir_Click)
			' 
			' lcmSynchronize
			' 
			Me.lcmSynchronize.Image = (CType(resources.GetObject("lcmSynchronize.Image"), System.Drawing.Image))
			Me.lcmSynchronize.Name = "lcmSynchronize"
			Me.lcmSynchronize.Size = New System.Drawing.Size(159, 22)
			Me.lcmSynchronize.Text = "&Synchronize..."
'			Me.lcmSynchronize.Click += New System.EventHandler(Me.lcmSynchronize_Click)
			' 
			' menuItem10
			' 
			Me.menuItem10.Name = "menuItem10"
			Me.menuItem10.Size = New System.Drawing.Size(156, 6)
			' 
			' lcmSelectGroup
			' 
			Me.lcmSelectGroup.Name = "lcmSelectGroup"
			Me.lcmSelectGroup.Size = New System.Drawing.Size(159, 22)
			Me.lcmSelectGroup.Text = "Select Group..."
'			Me.lcmSelectGroup.Click += New System.EventHandler(Me.lcmSelectGroup_Click)
			' 
			' lcmUnselectGroup
			' 
			Me.lcmUnselectGroup.Name = "lcmUnselectGroup"
			Me.lcmUnselectGroup.Size = New System.Drawing.Size(159, 22)
			Me.lcmUnselectGroup.Text = "Unselect Group..."
'			Me.lcmUnselectGroup.Click += New System.EventHandler(Me.lcmUnselectGroup_Click)
			' 
			' menuItem6
			' 
			Me.menuItem6.Name = "menuItem6"
			Me.menuItem6.Size = New System.Drawing.Size(156, 6)
			' 
			' lcmRename
			' 
			Me.lcmRename.Name = "lcmRename"
			Me.lcmRename.Size = New System.Drawing.Size(159, 22)
			Me.lcmRename.Text = "&Rename"
'			Me.lcmRename.Click += New System.EventHandler(Me.lcmRename_Click)
			' 
			' lcmDelete
			' 
			Me.lcmDelete.Image = (CType(resources.GetObject("lcmDelete.Image"), System.Drawing.Image))
			Me.lcmDelete.Name = "lcmDelete"
			Me.lcmDelete.Size = New System.Drawing.Size(159, 22)
			Me.lcmDelete.Text = "&Delete"
'			Me.lcmDelete.Click += New System.EventHandler(Me.lcmDelete_Click)
			' 
			' lcmMove
			' 
			Me.lcmMove.Name = "lcmMove"
			Me.lcmMove.Size = New System.Drawing.Size(159, 22)
			Me.lcmMove.Text = "M&ove..."
'			Me.lcmMove.Click += New System.EventHandler(Me.lcmMove_Click)
			' 
			' menuItem7
			' 
			Me.menuItem7.Name = "menuItem7"
			Me.menuItem7.Size = New System.Drawing.Size(156, 6)
			' 
			' lcmView
			' 
			Me.lcmView.Image = (CType(resources.GetObject("lcmView.Image"), System.Drawing.Image))
			Me.lcmView.Name = "lcmView"
			Me.lcmView.Size = New System.Drawing.Size(159, 22)
			Me.lcmView.Text = "&View..."
'			Me.lcmView.Click += New System.EventHandler(Me.lcmView_Click)
			' 
			' lcmUpload
			' 
			Me.lcmUpload.Image = (CType(resources.GetObject("lcmUpload.Image"), System.Drawing.Image))
			Me.lcmUpload.Name = "lcmUpload"
			Me.lcmUpload.Size = New System.Drawing.Size(159, 22)
			Me.lcmUpload.Text = "&Upload"
'			Me.lcmUpload.Click += New System.EventHandler(Me.lcmUpload_Click)
			' 
			' lcmResumeUpload
			' 
			Me.lcmResumeUpload.Image = (CType(resources.GetObject("lcmResumeUpload.Image"), System.Drawing.Image))
			Me.lcmResumeUpload.Name = "lcmResumeUpload"
			Me.lcmResumeUpload.Size = New System.Drawing.Size(159, 22)
			Me.lcmResumeUpload.Text = "Resume Upload"
'			Me.lcmResumeUpload.Click += New System.EventHandler(Me.lcmResumeUpload_Click)
			' 
			' lcmUploadUnique
			' 
			Me.lcmUploadUnique.Image = (CType(resources.GetObject("lcmUploadUnique.Image"), System.Drawing.Image))
			Me.lcmUploadUnique.Name = "lcmUploadUnique"
			Me.lcmUploadUnique.Size = New System.Drawing.Size(159, 22)
			Me.lcmUploadUnique.Text = "U&pload Unique"
'			Me.lcmUploadUnique.Click += New System.EventHandler(Me.lcmUploadUnique_Click)
			' 
			' lcmProperties
			' 
			Me.lcmProperties.Name = "lcmProperties"
			Me.lcmProperties.Size = New System.Drawing.Size(159, 22)
			Me.lcmProperties.Text = "Properties..."
'			Me.lcmProperties.Click += New System.EventHandler(Me.lcmProperties_Click)
			' 
			' menuItem8
			' 
			Me.menuItem8.Name = "menuItem8"
			Me.menuItem8.Size = New System.Drawing.Size(156, 6)
			' 
			' lcmRefresh
			' 
			Me.lcmRefresh.Image = (CType(resources.GetObject("lcmRefresh.Image"), System.Drawing.Image))
			Me.lcmRefresh.Name = "lcmRefresh"
			Me.lcmRefresh.Size = New System.Drawing.Size(159, 22)
			Me.lcmRefresh.Text = "&Refresh"
'			Me.lcmRefresh.Click += New System.EventHandler(Me.lcmRefresh_Click)
			' 
			' imglist
			' 
			Me.imglist.ImageStream = (CType(resources.GetObject("imglist.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imglist.TransparentColor = System.Drawing.Color.Transparent
			Me.imglist.Images.SetKeyName(0, "UpFolder.gif")
			Me.imglist.Images.SetKeyName(1, "")
			Me.imglist.Images.SetKeyName(2, "")
			' 
			' remoteContextMenu
			' 
			Me.remoteContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.mnuPopMkdir, Me.mnuPopSynchronize, Me.mnuPopExecuteCommand, Me.mnuPopGetTimeDiff, Me.menuItem9, Me.mnuPopSelectGroup, Me.mnuPopUnselectGroup, Me.menuItem3, Me.mnuPopRename, Me.mnuPopDelete, Me.mnuPopDeleteMultipleFiles, Me.mnuPopMove, Me.menuItem1, Me.mnuPopView, Me.mnuPopRetrieve, Me.mnuPopResumeDownload, Me.mnuPopCalcTotalSize, Me.mnuPopProperties, Me.menuItem4, Me.mnuPopRefresh})
			Me.remoteContextMenu.Name = "remoteContextMenu"
			Me.remoteContextMenu.Size = New System.Drawing.Size(183, 380)
'			Me.remoteContextMenu.Opening += New System.ComponentModel.CancelEventHandler(Me.remoteContextMenu_Popup)
			' 
			' mnuPopMkdir
			' 
			Me.mnuPopMkdir.Image = (CType(resources.GetObject("mnuPopMkdir.Image"), System.Drawing.Image))
			Me.mnuPopMkdir.Name = "mnuPopMkdir"
			Me.mnuPopMkdir.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopMkdir.Text = "&Make Directory"
'			Me.mnuPopMkdir.Click += New System.EventHandler(Me.mnuPopMkdir_Click)
			' 
			' mnuPopSynchronize
			' 
			Me.mnuPopSynchronize.Image = (CType(resources.GetObject("mnuPopSynchronize.Image"), System.Drawing.Image))
			Me.mnuPopSynchronize.Name = "mnuPopSynchronize"
			Me.mnuPopSynchronize.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopSynchronize.Text = "&Synchronize..."
'			Me.mnuPopSynchronize.Click += New System.EventHandler(Me.mnuSynchronize_Click)
			' 
			' mnuPopExecuteCommand
			' 
			Me.mnuPopExecuteCommand.Name = "mnuPopExecuteCommand"
			Me.mnuPopExecuteCommand.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopExecuteCommand.Text = "Execute Command..."
'			Me.mnuPopExecuteCommand.Click += New System.EventHandler(Me.mnuPopExecuteCommand_Click)
			' 
			' mnuPopGetTimeDiff
			' 
			Me.mnuPopGetTimeDiff.Name = "mnuPopGetTimeDiff"
			Me.mnuPopGetTimeDiff.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopGetTimeDiff.Text = "Get Time Difference"
'			Me.mnuPopGetTimeDiff.Click += New System.EventHandler(Me.mnuPopGetTimeDiff_Click)
			' 
			' menuItem9
			' 
			Me.menuItem9.Name = "menuItem9"
			Me.menuItem9.Size = New System.Drawing.Size(179, 6)
			' 
			' mnuPopSelectGroup
			' 
			Me.mnuPopSelectGroup.Name = "mnuPopSelectGroup"
			Me.mnuPopSelectGroup.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopSelectGroup.Text = "Select Group..."
'			Me.mnuPopSelectGroup.Click += New System.EventHandler(Me.mnuPopSelectGroup_Click)
			' 
			' mnuPopUnselectGroup
			' 
			Me.mnuPopUnselectGroup.Name = "mnuPopUnselectGroup"
			Me.mnuPopUnselectGroup.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopUnselectGroup.Text = "Unselect Group..."
'			Me.mnuPopUnselectGroup.Click += New System.EventHandler(Me.mnuPopUnselectGroup_Click)
			' 
			' menuItem3
			' 
			Me.menuItem3.Name = "menuItem3"
			Me.menuItem3.Size = New System.Drawing.Size(179, 6)
			' 
			' mnuPopRename
			' 
			Me.mnuPopRename.Name = "mnuPopRename"
			Me.mnuPopRename.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopRename.Text = "&Rename"
'			Me.mnuPopRename.Click += New System.EventHandler(Me.mnuPopRename_Click)
			' 
			' mnuPopDelete
			' 
			Me.mnuPopDelete.Image = (CType(resources.GetObject("mnuPopDelete.Image"), System.Drawing.Image))
			Me.mnuPopDelete.Name = "mnuPopDelete"
			Me.mnuPopDelete.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopDelete.Text = "&Delete"
'			Me.mnuPopDelete.Click += New System.EventHandler(Me.mnuPopDelete_Click)
			' 
			' mnuPopDeleteMultipleFiles
			' 
			Me.mnuPopDeleteMultipleFiles.Image = (CType(resources.GetObject("mnuPopDeleteMultipleFiles.Image"), System.Drawing.Image))
			Me.mnuPopDeleteMultipleFiles.Name = "mnuPopDeleteMultipleFiles"
			Me.mnuPopDeleteMultipleFiles.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopDeleteMultipleFiles.Text = "Delete Multiple Files..."
'			Me.mnuPopDeleteMultipleFiles.Click += New System.EventHandler(Me.mnuPopDeleteMultipleFiles_Click)
			' 
			' mnuPopMove
			' 
			Me.mnuPopMove.Name = "mnuPopMove"
			Me.mnuPopMove.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopMove.Text = "M&ove..."
'			Me.mnuPopMove.Click += New System.EventHandler(Me.mnuPopMove_Click)
			' 
			' menuItem1
			' 
			Me.menuItem1.Name = "menuItem1"
			Me.menuItem1.Size = New System.Drawing.Size(179, 6)
			' 
			' mnuPopView
			' 
			Me.mnuPopView.Image = (CType(resources.GetObject("mnuPopView.Image"), System.Drawing.Image))
			Me.mnuPopView.Name = "mnuPopView"
			Me.mnuPopView.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopView.Text = "&View..."
'			Me.mnuPopView.Click += New System.EventHandler(Me.mnuPopView_Click)
			' 
			' mnuPopRetrieve
			' 
			Me.mnuPopRetrieve.Image = (CType(resources.GetObject("mnuPopRetrieve.Image"), System.Drawing.Image))
			Me.mnuPopRetrieve.Name = "mnuPopRetrieve"
			Me.mnuPopRetrieve.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopRetrieve.Text = "Download"
'			Me.mnuPopRetrieve.Click += New System.EventHandler(Me.mnuPopRetrieve_Click)
			' 
			' mnuPopResumeDownload
			' 
			Me.mnuPopResumeDownload.Image = (CType(resources.GetObject("mnuPopResumeDownload.Image"), System.Drawing.Image))
			Me.mnuPopResumeDownload.Name = "mnuPopResumeDownload"
			Me.mnuPopResumeDownload.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopResumeDownload.Text = "Resume Download"
'			Me.mnuPopResumeDownload.Click += New System.EventHandler(Me.mnuPopResumeDownload_Click)
			' 
			' mnuPopCalcTotalSize
			' 
			Me.mnuPopCalcTotalSize.Name = "mnuPopCalcTotalSize"
			Me.mnuPopCalcTotalSize.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopCalcTotalSize.Text = "Calculate Total Size..."
'			Me.mnuPopCalcTotalSize.Click += New System.EventHandler(Me.mnuPopCalcTotalSize_Click)
			' 
			' mnuPopProperties
			' 
			Me.mnuPopProperties.Name = "mnuPopProperties"
			Me.mnuPopProperties.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopProperties.Text = "Proper&ties / CHMOD..."
'			Me.mnuPopProperties.Click += New System.EventHandler(Me.mnuPopProperties_Click)
			' 
			' menuItem4
			' 
			Me.menuItem4.Name = "menuItem4"
			Me.menuItem4.Size = New System.Drawing.Size(179, 6)
			' 
			' mnuPopRefresh
			' 
			Me.mnuPopRefresh.Image = (CType(resources.GetObject("mnuPopRefresh.Image"), System.Drawing.Image))
			Me.mnuPopRefresh.Name = "mnuPopRefresh"
			Me.mnuPopRefresh.Size = New System.Drawing.Size(182, 22)
			Me.mnuPopRefresh.Text = "&Refresh"
'			Me.mnuPopRefresh.Click += New System.EventHandler(Me.mnuPopRefresh_Click)
			' 
			' menuStrip
			' 
			Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileMenu, Me.settingsToolStripMenuItem})
			Me.menuStrip.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip.Name = "menuStrip"
			Me.menuStrip.Size = New System.Drawing.Size(726, 24)
			Me.menuStrip.TabIndex = 138
			' 
			' fileMenu
			' 
			Me.fileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.loginToolStripMenuItem, Me.toolStripSeparator6, Me.makeDirectoryToolStripMenuItem, Me.synchronizeToolStripMenuItem, Me.executeCommandToolStripMenuItem, Me.getTimeDifferenceToolStripMenuItem, Me.renameToolStripMenuItem, Me.deleteToolStripMenuItem, Me.deleteMultipleFilesToolStripMenuItem, Me.moveToolStripMenuItem, Me.viewToolStripMenuItem, Me.downloadToolStripMenuItem, Me.uploadFileToolStripMenuItem, Me.uploadUniqueFileToolStripMenuItem, Me.resumeDownloadToolStripMenuItem, Me.resumeUploadToolStripMenuItem, Me.calculateTotalSizeToolStripMenuItem, Me.propertiesToolStripMenuItem, Me.refreshToolStripMenuItem, Me.toolStripSeparator8, Me.exitToolStripMenuItem})
			Me.fileMenu.Name = "fileMenu"
			Me.fileMenu.Size = New System.Drawing.Size(35, 20)
			Me.fileMenu.Text = "&File"
			' 
			' loginToolStripMenuItem
			' 
			Me.loginToolStripMenuItem.Name = "loginToolStripMenuItem"
			Me.loginToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.loginToolStripMenuItem.Text = "&Connect..."
'			Me.loginToolStripMenuItem.Click += New System.EventHandler(Me.loginToolStripMenuItem_Click)
			' 
			' toolStripSeparator6
			' 
			Me.toolStripSeparator6.Name = "toolStripSeparator6"
			Me.toolStripSeparator6.Size = New System.Drawing.Size(177, 6)
			' 
			' makeDirectoryToolStripMenuItem
			' 
			Me.makeDirectoryToolStripMenuItem.Image = (CType(resources.GetObject("makeDirectoryToolStripMenuItem.Image"), System.Drawing.Image))
			Me.makeDirectoryToolStripMenuItem.Name = "makeDirectoryToolStripMenuItem"
			Me.makeDirectoryToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.makeDirectoryToolStripMenuItem.Text = "&Make Directory"
'			Me.makeDirectoryToolStripMenuItem.Click += New System.EventHandler(Me.makeDirectoryToolStripMenuItem_Click)
			' 
			' synchronizeToolStripMenuItem
			' 
			Me.synchronizeToolStripMenuItem.Image = (CType(resources.GetObject("synchronizeToolStripMenuItem.Image"), System.Drawing.Image))
			Me.synchronizeToolStripMenuItem.Name = "synchronizeToolStripMenuItem"
			Me.synchronizeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.synchronizeToolStripMenuItem.Text = "&Synchronize..."
'			Me.synchronizeToolStripMenuItem.Click += New System.EventHandler(Me.synchronizeToolStripMenuItem_Click)
			' 
			' executeCommandToolStripMenuItem
			' 
			Me.executeCommandToolStripMenuItem.Name = "executeCommandToolStripMenuItem"
			Me.executeCommandToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.executeCommandToolStripMenuItem.Text = "Execute Command"
'			Me.executeCommandToolStripMenuItem.Click += New System.EventHandler(Me.executeCommandToolStripMenuItem_Click)
			' 
			' getTimeDifferenceToolStripMenuItem
			' 
			Me.getTimeDifferenceToolStripMenuItem.Name = "getTimeDifferenceToolStripMenuItem"
			Me.getTimeDifferenceToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.getTimeDifferenceToolStripMenuItem.Text = "Get Time Difference"
'			Me.getTimeDifferenceToolStripMenuItem.Click += New System.EventHandler(Me.getTimeDifferenceToolStripMenuItem_Click)
			' 
			' renameToolStripMenuItem
			' 
			Me.renameToolStripMenuItem.Name = "renameToolStripMenuItem"
			Me.renameToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.renameToolStripMenuItem.Text = "&Rename"
'			Me.renameToolStripMenuItem.Click += New System.EventHandler(Me.renameToolStripMenuItem_Click)
			' 
			' deleteToolStripMenuItem
			' 
			Me.deleteToolStripMenuItem.Image = (CType(resources.GetObject("deleteToolStripMenuItem.Image"), System.Drawing.Image))
			Me.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem"
			Me.deleteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.deleteToolStripMenuItem.Text = "&Delete"
'			Me.deleteToolStripMenuItem.Click += New System.EventHandler(Me.deleteToolStripMenuItem_Click)
			' 
			' deleteMultipleFilesToolStripMenuItem
			' 
			Me.deleteMultipleFilesToolStripMenuItem.Name = "deleteMultipleFilesToolStripMenuItem"
			Me.deleteMultipleFilesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.deleteMultipleFilesToolStripMenuItem.Text = "Delete Multiple Files..."
'			Me.deleteMultipleFilesToolStripMenuItem.Click += New System.EventHandler(Me.deleteMultipleFilesToolStripMenuItem_Click)
			' 
			' moveToolStripMenuItem
			' 
			Me.moveToolStripMenuItem.Name = "moveToolStripMenuItem"
			Me.moveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.moveToolStripMenuItem.Text = "M&ove..."
'			Me.moveToolStripMenuItem.Click += New System.EventHandler(Me.moveToolStripMenuItem_Click)
			' 
			' viewToolStripMenuItem
			' 
			Me.viewToolStripMenuItem.Image = (CType(resources.GetObject("viewToolStripMenuItem.Image"), System.Drawing.Image))
			Me.viewToolStripMenuItem.Name = "viewToolStripMenuItem"
			Me.viewToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.viewToolStripMenuItem.Text = "&View"
'			Me.viewToolStripMenuItem.Click += New System.EventHandler(Me.viewToolStripMenuItem_Click)
			' 
			' downloadToolStripMenuItem
			' 
			Me.downloadToolStripMenuItem.Image = (CType(resources.GetObject("downloadToolStripMenuItem.Image"), System.Drawing.Image))
			Me.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem"
			Me.downloadToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.downloadToolStripMenuItem.Text = "Download"
'			Me.downloadToolStripMenuItem.Click += New System.EventHandler(Me.downloadToolStripMenuItem_Click)
			' 
			' uploadFileToolStripMenuItem
			' 
			Me.uploadFileToolStripMenuItem.Image = (CType(resources.GetObject("uploadFileToolStripMenuItem.Image"), System.Drawing.Image))
			Me.uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem"
			Me.uploadFileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.uploadFileToolStripMenuItem.Text = "&Upload"
'			Me.uploadFileToolStripMenuItem.Click += New System.EventHandler(Me.uploadFileToolStripMenuItem_Click)
			' 
			' uploadUniqueFileToolStripMenuItem
			' 
			Me.uploadUniqueFileToolStripMenuItem.Name = "uploadUniqueFileToolStripMenuItem"
			Me.uploadUniqueFileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.uploadUniqueFileToolStripMenuItem.Text = "U&pload Unique"
'			Me.uploadUniqueFileToolStripMenuItem.Click += New System.EventHandler(Me.uploadUniqueFileToolStripMenuItem_Click)
			' 
			' resumeDownloadToolStripMenuItem
			' 
			Me.resumeDownloadToolStripMenuItem.Image = (CType(resources.GetObject("resumeDownloadToolStripMenuItem.Image"), System.Drawing.Image))
			Me.resumeDownloadToolStripMenuItem.Name = "resumeDownloadToolStripMenuItem"
			Me.resumeDownloadToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.resumeDownloadToolStripMenuItem.Text = "Resume Download"
'			Me.resumeDownloadToolStripMenuItem.Click += New System.EventHandler(Me.resumeDownloadToolStripMenuItem_Click)
			' 
			' resumeUploadToolStripMenuItem
			' 
			Me.resumeUploadToolStripMenuItem.Image = (CType(resources.GetObject("resumeUploadToolStripMenuItem.Image"), System.Drawing.Image))
			Me.resumeUploadToolStripMenuItem.Name = "resumeUploadToolStripMenuItem"
			Me.resumeUploadToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.resumeUploadToolStripMenuItem.Text = "Resume Upload"
'			Me.resumeUploadToolStripMenuItem.Click += New System.EventHandler(Me.resumeUploadToolStripMenuItem_Click)
			' 
			' calculateTotalSizeToolStripMenuItem
			' 
			Me.calculateTotalSizeToolStripMenuItem.Name = "calculateTotalSizeToolStripMenuItem"
			Me.calculateTotalSizeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.calculateTotalSizeToolStripMenuItem.Text = "Calculate Total Size"
'			Me.calculateTotalSizeToolStripMenuItem.Click += New System.EventHandler(Me.calculateTotalSizeToolStripMenuItem_Click)
			' 
			' propertiesToolStripMenuItem
			' 
			Me.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem"
			Me.propertiesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.propertiesToolStripMenuItem.Text = "Proper&ties..."
'			Me.propertiesToolStripMenuItem.Click += New System.EventHandler(Me.propertiesToolStripMenuItem_Click)
			' 
			' refreshToolStripMenuItem
			' 
			Me.refreshToolStripMenuItem.Image = (CType(resources.GetObject("refreshToolStripMenuItem.Image"), System.Drawing.Image))
			Me.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem"
			Me.refreshToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.refreshToolStripMenuItem.Text = "Refres&h"
'			Me.refreshToolStripMenuItem.Click += New System.EventHandler(Me.refreshToolStripMenuItem_Click)
			' 
			' toolStripSeparator8
			' 
			Me.toolStripSeparator8.Name = "toolStripSeparator8"
			Me.toolStripSeparator8.Size = New System.Drawing.Size(177, 6)
			' 
			' exitToolStripMenuItem
			' 
			Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
			Me.exitToolStripMenuItem.Text = "E&xit"
'			Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click)
			' 
			' settingsToolStripMenuItem
			' 
			Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
			Me.settingsToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
			Me.settingsToolStripMenuItem.Text = "&Settings"
'			Me.settingsToolStripMenuItem.Click += New System.EventHandler(Me.settingsToolStripMenuItem_Click)
			' 
			' toolStripSeparator7
			' 
			Me.toolStripSeparator7.Name = "toolStripSeparator7"
			Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 52)
			' 
			' toolStripSeparator4
			' 
			Me.toolStripSeparator4.Name = "toolStripSeparator4"
			Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 52)
			' 
			' toolStripSeparator5
			' 
			Me.toolStripSeparator5.Name = "toolStripSeparator5"
			Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 52)
			' 
			' progressBar
			' 
			Me.progressBar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.progressBar.Enabled = False
			Me.progressBar.Location = New System.Drawing.Point(5, 571)
			Me.progressBar.Name = "progressBar"
			Me.progressBar.Size = New System.Drawing.Size(716, 10)
			Me.progressBar.TabIndex = 23
			' 
			' splitContainerUpDown
			' 
			Me.splitContainerUpDown.BackColor = System.Drawing.SystemColors.Control
			Me.splitContainerUpDown.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainerUpDown.Location = New System.Drawing.Point(0, 76)
			Me.splitContainerUpDown.Name = "splitContainerUpDown"
			Me.splitContainerUpDown.Orientation = System.Windows.Forms.Orientation.Horizontal
			' 
			' splitContainerUpDown.Panel1
			' 
			Me.splitContainerUpDown.Panel1.Controls.Add(Me.splitContainerLeftRight)
			' 
			' splitContainerUpDown.Panel2
			' 
			Me.splitContainerUpDown.Panel2.BackColor = System.Drawing.SystemColors.Control
			Me.splitContainerUpDown.Panel2.Controls.Add(Me.txtLog)
			Me.splitContainerUpDown.Size = New System.Drawing.Size(726, 519)
			Me.splitContainerUpDown.SplitterDistance = 363
			Me.splitContainerUpDown.SplitterWidth = 2
			Me.splitContainerUpDown.TabIndex = 27
			' 
			' splitContainerLeftRight
			' 
			Me.splitContainerLeftRight.BackColor = System.Drawing.SystemColors.Control
			Me.splitContainerLeftRight.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainerLeftRight.Location = New System.Drawing.Point(0, 0)
			Me.splitContainerLeftRight.Name = "splitContainerLeftRight"
			' 
			' splitContainerLeftRight.Panel1
			' 
			Me.splitContainerLeftRight.Panel1.BackColor = System.Drawing.SystemColors.Control
			Me.splitContainerLeftRight.Panel1.Controls.Add(Me.btnLocalDirBrowse)
			Me.splitContainerLeftRight.Panel1.Controls.Add(Me.txtLocalDir)
			Me.splitContainerLeftRight.Panel1.Controls.Add(Me.lblLocalDir)
			Me.splitContainerLeftRight.Panel1.Controls.Add(Me.lvwLocal)
			' 
			' splitContainerLeftRight.Panel2
			' 
			Me.splitContainerLeftRight.Panel2.BackColor = System.Drawing.SystemColors.Control
			Me.splitContainerLeftRight.Panel2.Controls.Add(Me.txtRemoteDir)
			Me.splitContainerLeftRight.Panel2.Controls.Add(Me.lblRemoteDir)
			Me.splitContainerLeftRight.Panel2.Controls.Add(Me.lvwRemote)
			Me.splitContainerLeftRight.Size = New System.Drawing.Size(726, 363)
			Me.splitContainerLeftRight.SplitterDistance = 354
			Me.splitContainerLeftRight.TabIndex = 0
			' 
			' btnLocalDirBrowse
			' 
			Me.btnLocalDirBrowse.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnLocalDirBrowse.Location = New System.Drawing.Point(327, 3)
			Me.btnLocalDirBrowse.Name = "btnLocalDirBrowse"
			Me.btnLocalDirBrowse.Size = New System.Drawing.Size(26, 20)
			Me.btnLocalDirBrowse.TabIndex = 2
			Me.btnLocalDirBrowse.Text = "..."
			Me.btnLocalDirBrowse.UseVisualStyleBackColor = True
'			Me.btnLocalDirBrowse.Click += New System.EventHandler(Me.btnLocalDirBrowse_Click)
			' 
			' txtLocalDir
			' 
			Me.txtLocalDir.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txtLocalDir.Location = New System.Drawing.Point(56, 3)
			Me.txtLocalDir.Name = "txtLocalDir"
			Me.txtLocalDir.Size = New System.Drawing.Size(267, 20)
			Me.txtLocalDir.TabIndex = 1
'			Me.txtLocalDir.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.txtLocalDir_KeyDown)
			' 
			' lblLocalDir
			' 
			Me.lblLocalDir.AutoSize = True
			Me.lblLocalDir.Location = New System.Drawing.Point(1, 6)
			Me.lblLocalDir.Name = "lblLocalDir"
			Me.lblLocalDir.Size = New System.Drawing.Size(52, 13)
			Me.lblLocalDir.TabIndex = 57
			Me.lblLocalDir.Text = "Local Dir:"
			' 
			' lvwLocal
			' 
			Me.lvwLocal.AllowDrag = True
			Me.lvwLocal.AllowDrop = True
			Me.lvwLocal.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lvwLocal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.chFileName, Me.chSize, Me.chDateTime})
			Me.lvwLocal.ContextMenuStrip = Me.localContextMenu
			Me.lvwLocal.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lvwLocal.FullRowSelect = True
			Me.lvwLocal.LabelEdit = True
			Me.lvwLocal.Location = New System.Drawing.Point(0, 25)
			Me.lvwLocal.Name = "lvwLocal"
			Me.lvwLocal.Size = New System.Drawing.Size(354, 336)
			Me.lvwLocal.SmallImageList = Me.imglist
			Me.lvwLocal.TabIndex = 3
			Me.lvwLocal.UseCompatibleStateImageBehavior = False
			Me.lvwLocal.View = System.Windows.Forms.View.Details
'			Me.lvwLocal.AfterLabelEdit += New System.Windows.Forms.LabelEditEventHandler(Me.lvwLocal_AfterLabelEdit)
'			Me.lvwLocal.SelectedIndexChanged += New System.EventHandler(Me.lvwLocal_SelectedIndexChanged)
'			Me.lvwLocal.DoubleClick += New System.EventHandler(Me.lvwLocal_DoubleClick)
'			Me.lvwLocal.DragDrop += New System.Windows.Forms.DragEventHandler(Me.lvwLocal_DragDrop)
'			Me.lvwLocal.ColumnClick += New System.Windows.Forms.ColumnClickEventHandler(Me.lvwLocal_ColumnClick)
'			Me.lvwLocal.BeforeLabelEdit += New System.Windows.Forms.LabelEditEventHandler(Me.lvwLocal_BeforeLabelEdit)
'			Me.lvwLocal.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.lvwLocal_KeyDown)
			' 
			' chFileName
			' 
			Me.chFileName.Text = "File Name"
			Me.chFileName.Width = 200
			' 
			' chSize
			' 
			Me.chSize.Text = "Size"
			Me.chSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			Me.chSize.Width = 100
			' 
			' chDateTime
			' 
			Me.chDateTime.Text = "Date"
			Me.chDateTime.Width = 150
			' 
			' txtRemoteDir
			' 
			Me.txtRemoteDir.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txtRemoteDir.Enabled = False
			Me.txtRemoteDir.Location = New System.Drawing.Point(67, 3)
			Me.txtRemoteDir.Name = "txtRemoteDir"
			Me.txtRemoteDir.Size = New System.Drawing.Size(301, 20)
			Me.txtRemoteDir.TabIndex = 10
'			Me.txtRemoteDir.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.txtRemoteDir_KeyDown)
			' 
			' lblRemoteDir
			' 
			Me.lblRemoteDir.AutoSize = True
			Me.lblRemoteDir.Location = New System.Drawing.Point(2, 6)
			Me.lblRemoteDir.Name = "lblRemoteDir"
			Me.lblRemoteDir.Size = New System.Drawing.Size(63, 13)
			Me.lblRemoteDir.TabIndex = 54
			Me.lblRemoteDir.Text = "Remote Dir:"
			' 
			' lvwRemote
			' 
			Me.lvwRemote.AllowDrag = True
			Me.lvwRemote.AllowDrop = True
			Me.lvwRemote.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lvwRemote.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.colFileName, Me.colSize, Me.colDate, Me.colPermissions})
			Me.lvwRemote.ContextMenuStrip = Me.remoteContextMenu
			Me.lvwRemote.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lvwRemote.FullRowSelect = True
			Me.lvwRemote.LabelEdit = True
			Me.lvwRemote.Location = New System.Drawing.Point(1, 25)
			Me.lvwRemote.Name = "lvwRemote"
			Me.lvwRemote.Size = New System.Drawing.Size(367, 336)
			Me.lvwRemote.SmallImageList = Me.imglist
			Me.lvwRemote.TabIndex = 11
			Me.lvwRemote.UseCompatibleStateImageBehavior = False
			Me.lvwRemote.View = System.Windows.Forms.View.Details
'			Me.lvwRemote.AfterLabelEdit += New System.Windows.Forms.LabelEditEventHandler(Me.lvwRemote_AfterLabelEdit)
'			Me.lvwRemote.SelectedIndexChanged += New System.EventHandler(Me.lvwRemote_SelectedIndexChanged)
'			Me.lvwRemote.DoubleClick += New System.EventHandler(Me.lvwRemote_DoubleClick)
'			Me.lvwRemote.DragDrop += New System.Windows.Forms.DragEventHandler(Me.lvwRemote_DragDrop)
'			Me.lvwRemote.ColumnClick += New System.Windows.Forms.ColumnClickEventHandler(Me.lvwRemote_ColumnClick)
'			Me.lvwRemote.BeforeLabelEdit += New System.Windows.Forms.LabelEditEventHandler(Me.lvwRemote_BeforeLabelEdit)
'			Me.lvwRemote.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.lvwRemote_KeyDown)
			' 
			' colFileName
			' 
			Me.colFileName.Text = "File Name"
			Me.colFileName.Width = 200
			' 
			' colSize
			' 
			Me.colSize.Text = "Size"
			Me.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			Me.colSize.Width = 100
			' 
			' colDate
			' 
			Me.colDate.Text = "Date"
			Me.colDate.Width = 150
			' 
			' colPermissions
			' 
			Me.colPermissions.Text = "Permissions"
			Me.colPermissions.Width = 100
			' 
			' txtLog
			' 
			Me.txtLog.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txtLog.BackColor = System.Drawing.Color.Black
			Me.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.txtLog.Font = New System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.txtLog.ForeColor = System.Drawing.Color.Silver
			Me.txtLog.Location = New System.Drawing.Point(0, 2)
			Me.txtLog.MaxLength = 0
			Me.txtLog.Name = "txtLog"
			Me.txtLog.ReadOnly = True
			Me.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
			Me.txtLog.Size = New System.Drawing.Size(726, 125)
			Me.txtLog.TabIndex = 22
			Me.txtLog.Text = ""
			' 
			' progressBarTotal
			' 
			Me.progressBarTotal.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.progressBarTotal.Location = New System.Drawing.Point(5, 582)
			Me.progressBarTotal.Name = "progressBarTotal"
			Me.progressBarTotal.Size = New System.Drawing.Size(716, 10)
			Me.progressBarTotal.TabIndex = 136
			' 
			' btnAbort
			' 
			Me.btnAbort.AutoSize = False
			Me.btnAbort.Enabled = False
			Me.btnAbort.Image = (CType(resources.GetObject("btnAbort.Image"), System.Drawing.Image))
			Me.btnAbort.Name = "btnAbort"
			Me.btnAbort.Size = New System.Drawing.Size(52, 49)
			Me.btnAbort.Text = "Abort"
			Me.btnAbort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.btnAbort.Click += New System.EventHandler(Me.btnAbort_Click)
			' 
			' tsbLogin
			' 
			Me.tsbLogin.AutoSize = False
			Me.tsbLogin.Image = (CType(resources.GetObject("tsbLogin.Image"), System.Drawing.Image))
			Me.tsbLogin.Name = "tsbLogin"
			Me.tsbLogin.Size = New System.Drawing.Size(52, 49)
			Me.tsbLogin.Text = "Connect"
			Me.tsbLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbLogin.Click += New System.EventHandler(Me.tsbLogin_Click)
			' 
			' tsbLogout
			' 
			Me.tsbLogout.Image = (CType(resources.GetObject("tsbLogout.Image"), System.Drawing.Image))
			Me.tsbLogout.Name = "tsbLogout"
			Me.tsbLogout.Size = New System.Drawing.Size(63, 49)
			Me.tsbLogout.Text = "Disconnect"
			Me.tsbLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
			Me.tsbLogout.Visible = False
'			Me.tsbLogout.Click += New System.EventHandler(Me.tsbLogout_Click)
			' 
			' tsbRefresh
			' 
			Me.tsbRefresh.Image = (CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image))
			Me.tsbRefresh.Name = "tsbRefresh"
			Me.tsbRefresh.Size = New System.Drawing.Size(42, 66)
			Me.tsbRefresh.Text = "Refresh"
'			Me.tsbRefresh.Click += New System.EventHandler(Me.tsbRefresh_Click)
			' 
			' tsbSettings
			' 
			Me.tsbSettings.AutoSize = False
			Me.tsbSettings.Image = (CType(resources.GetObject("tsbSettings.Image"), System.Drawing.Image))
			Me.tsbSettings.Name = "tsbSettings"
			Me.tsbSettings.Size = New System.Drawing.Size(52, 49)
			Me.tsbSettings.Text = "Settings"
			Me.tsbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbSettings.Click += New System.EventHandler(Me.tsbSettings_Click)
			' 
			' tsbCreateDir
			' 
			Me.tsbCreateDir.AutoSize = False
			Me.tsbCreateDir.Enabled = False
			Me.tsbCreateDir.Image = (CType(resources.GetObject("tsbCreateDir.Image"), System.Drawing.Image))
			Me.tsbCreateDir.Name = "tsbCreateDir"
			Me.tsbCreateDir.Size = New System.Drawing.Size(62, 49)
			Me.tsbCreateDir.Text = "Create Dir"
			Me.tsbCreateDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbCreateDir.Click += New System.EventHandler(Me.tsbCreateDir_Click)
			' 
			' tsbDelete
			' 
			Me.tsbDelete.AutoSize = False
			Me.tsbDelete.Enabled = False
			Me.tsbDelete.Image = (CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image))
			Me.tsbDelete.Name = "tsbDelete"
			Me.tsbDelete.Size = New System.Drawing.Size(52, 49)
			Me.tsbDelete.Text = "Delete"
			Me.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbDelete.Click += New System.EventHandler(Me.tsbDelete_Click)
			' 
			' tsbMove
			' 
			Me.tsbMove.AutoSize = False
			Me.tsbMove.Enabled = False
			Me.tsbMove.Image = (CType(resources.GetObject("tsbMove.Image"), System.Drawing.Image))
			Me.tsbMove.Name = "tsbMove"
			Me.tsbMove.Size = New System.Drawing.Size(52, 49)
			Me.tsbMove.Text = "Move..."
			Me.tsbMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbMove.Click += New System.EventHandler(Me.tsbMove_Click)
			' 
			' tsbDownload
			' 
			Me.tsbDownload.Enabled = False
			Me.tsbDownload.Image = (CType(resources.GetObject("tsbDownload.Image"), System.Drawing.Image))
			Me.tsbDownload.Name = "tsbDownload"
			Me.tsbDownload.Size = New System.Drawing.Size(58, 49)
			Me.tsbDownload.Text = "Download"
			Me.tsbDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbDownload.Click += New System.EventHandler(Me.tsbDownload_Click)
			' 
			' tsbUpload
			' 
			Me.tsbUpload.AutoSize = False
			Me.tsbUpload.Enabled = False
			Me.tsbUpload.Image = (CType(resources.GetObject("tsbUpload.Image"), System.Drawing.Image))
			Me.tsbUpload.Name = "tsbUpload"
			Me.tsbUpload.Size = New System.Drawing.Size(52, 49)
			Me.tsbUpload.Text = "Upload"
			Me.tsbUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbUpload.Click += New System.EventHandler(Me.tsbUpload_Click)
			' 
			' tsbView
			' 
			Me.tsbView.AutoSize = False
			Me.tsbView.Enabled = False
			Me.tsbView.Image = (CType(resources.GetObject("tsbView.Image"), System.Drawing.Image))
			Me.tsbView.Name = "tsbView"
			Me.tsbView.Size = New System.Drawing.Size(52, 49)
			Me.tsbView.Text = "View"
			Me.tsbView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbView.Click += New System.EventHandler(Me.tsbView_Click)
			' 
			' tsbSynchronize
			' 
			Me.tsbSynchronize.AutoSize = False
			Me.tsbSynchronize.Enabled = False
			Me.tsbSynchronize.Image = (CType(resources.GetObject("tsbSynchronize.Image"), System.Drawing.Image))
			Me.tsbSynchronize.Name = "tsbSynchronize"
			Me.tsbSynchronize.Size = New System.Drawing.Size(72, 49)
			Me.tsbSynchronize.Text = "Synchronize"
			Me.tsbSynchronize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbSynchronize.Click += New System.EventHandler(Me.tsbSynchronize_Click)
			' 
			' toolbarMain
			' 
			Me.toolbarMain.ImageScalingSize = New System.Drawing.Size(32, 32)
			Me.toolbarMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.tsbLogin, Me.tsbLogout, Me.tsbSettings, Me.toolStripSeparator4, Me.tsbUpload, Me.tsbDownload, Me.btnAbort, Me.toolStripSeparator5, Me.tsbDelete, Me.tsbMove, Me.tsbCreateDir, Me.tsbSynchronize, Me.toolStripSeparator7, Me.tsbView})
			Me.toolbarMain.Location = New System.Drawing.Point(0, 24)
			Me.toolbarMain.Name = "toolbarMain"
			Me.toolbarMain.Size = New System.Drawing.Size(726, 52)
			Me.toolbarMain.TabIndex = 137
			' 
			' statusStrip
			' 
			Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.status})
			Me.statusStrip.Location = New System.Drawing.Point(0, 595)
			Me.statusStrip.Name = "statusStrip"
			Me.statusStrip.Size = New System.Drawing.Size(726, 22)
			Me.statusStrip.TabIndex = 139
			' 
			' status
			' 
			Me.status.Name = "status"
			Me.status.Size = New System.Drawing.Size(38, 17)
			Me.status.Text = "Ready"
			' 
			' Main
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(726, 617)
			Me.Controls.Add(Me.progressBar)
			Me.Controls.Add(Me.progressBarTotal)
			Me.Controls.Add(Me.splitContainerUpDown)
			Me.Controls.Add(Me.toolbarMain)
			Me.Controls.Add(Me.menuStrip)
			Me.Controls.Add(Me.statusStrip)
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "Main"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Ultimate FTP Client Demo"
			Me.localContextMenu.ResumeLayout(False)
			Me.remoteContextMenu.ResumeLayout(False)
			Me.menuStrip.ResumeLayout(False)
			Me.menuStrip.PerformLayout()
			Me.splitContainerUpDown.Panel1.ResumeLayout(False)
			Me.splitContainerUpDown.Panel2.ResumeLayout(False)
			Me.splitContainerUpDown.ResumeLayout(False)
			Me.splitContainerLeftRight.Panel1.ResumeLayout(False)
			Me.splitContainerLeftRight.Panel1.PerformLayout()
			Me.splitContainerLeftRight.Panel2.ResumeLayout(False)
			Me.splitContainerLeftRight.Panel2.PerformLayout()
			Me.splitContainerLeftRight.ResumeLayout(False)
			Me.toolbarMain.ResumeLayout(False)
			Me.toolbarMain.PerformLayout()
			Me.statusStrip.ResumeLayout(False)
			Me.statusStrip.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private menuStrip As System.Windows.Forms.MenuStrip
		Private WithEvents renameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents makeDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents deleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents downloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents uploadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents uploadUniqueFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private progressBar As System.Windows.Forms.ProgressBar
		Private WithEvents btnAbort As System.Windows.Forms.ToolStripButton
		Friend WithEvents remoteContextMenu As System.Windows.Forms.ContextMenuStrip
		Friend WithEvents mnuPopRename As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents mnuPopDelete As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents mnuPopRetrieve As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents mnuPopView As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents mnuPopRefresh As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents loginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents settingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private splitContainerUpDown As System.Windows.Forms.SplitContainer
		Public txtLog As System.Windows.Forms.RichTextBox
		Private WithEvents refreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private keepAliveTimer As System.Windows.Forms.Timer
		Private splitContainerLeftRight As System.Windows.Forms.SplitContainer
		Private WithEvents txtRemoteDir As System.Windows.Forms.TextBox
		Private lblRemoteDir As System.Windows.Forms.Label
		Public WithEvents lvwRemote As DragAndDropListView
		Private colFileName As System.Windows.Forms.ColumnHeader
		Private colSize As System.Windows.Forms.ColumnHeader
		Private colDate As System.Windows.Forms.ColumnHeader
		Private colPermissions As System.Windows.Forms.ColumnHeader
		Private WithEvents txtLocalDir As System.Windows.Forms.TextBox
		Private lblLocalDir As System.Windows.Forms.Label
		Public WithEvents lvwLocal As DragAndDropListView
		Private chFileName As System.Windows.Forms.ColumnHeader
		Private chSize As System.Windows.Forms.ColumnHeader
		Private chDateTime As System.Windows.Forms.ColumnHeader
		Private WithEvents btnLocalDirBrowse As System.Windows.Forms.Button
		Friend WithEvents localContextMenu As System.Windows.Forms.ContextMenuStrip
		Friend WithEvents lcmRename As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents lcmMakeDir As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents lcmDelete As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents lcmUpload As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents lcmUploadUnique As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents lcmView As System.Windows.Forms.ToolStripMenuItem
		Friend WithEvents lcmRefresh As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopMove As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents lcmMove As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents moveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents tsbLogin As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbLogout As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbSettings As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbCreateDir As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbMove As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbDownload As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbUpload As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbView As System.Windows.Forms.ToolStripButton
		Public imglist As System.Windows.Forms.ImageList
		Private WithEvents tsbSynchronize As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
		Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
		Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
		Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents synchronizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopSynchronize As System.Windows.Forms.ToolStripMenuItem
		Private menuItem3 As System.Windows.Forms.ToolStripSeparator
		Private menuItem1 As System.Windows.Forms.ToolStripSeparator
		Private menuItem4 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents lcmSynchronize As System.Windows.Forms.ToolStripMenuItem
		Private menuItem6 As System.Windows.Forms.ToolStripSeparator
		Private menuItem7 As System.Windows.Forms.ToolStripSeparator
		Private menuItem8 As System.Windows.Forms.ToolStripSeparator
		Friend WithEvents mnuPopMkdir As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents propertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopProperties As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents lcmProperties As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopResumeDownload As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopExecuteCommand As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopGetTimeDiff As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopCalcTotalSize As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents lcmResumeUpload As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents executeCommandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents getTimeDifferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents resumeDownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents resumeUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents calculateTotalSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
		Private progressBarTotal As System.Windows.Forms.ProgressBar
		Private menuItem9 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents mnuPopSelectGroup As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopUnselectGroup As System.Windows.Forms.ToolStripMenuItem
		Private menuItem10 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents lcmSelectGroup As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents lcmUnselectGroup As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents deleteMultipleFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents mnuPopDeleteMultipleFiles As System.Windows.Forms.ToolStripMenuItem
		Private toolbarMain As System.Windows.Forms.ToolStrip
		Private fileMenu As System.Windows.Forms.ToolStripMenuItem
		Private statusStrip As StatusStrip
		Private status As ToolStripStatusLabel
	End Class
End Namespace

