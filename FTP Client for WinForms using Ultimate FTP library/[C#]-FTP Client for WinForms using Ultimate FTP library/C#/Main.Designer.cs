using System.Drawing;
using System.Windows.Forms;

namespace ClientSample
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.localContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lcmMakeDir = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmSynchronize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.lcmSelectGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmUnselectGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.lcmRename = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmMove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.lcmView = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmResumeUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmUploadUnique = new System.Windows.Forms.ToolStripMenuItem();
            this.lcmProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.lcmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.remoteContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPopMkdir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopSynchronize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopExecuteCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopGetTimeDiff = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPopSelectGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopUnselectGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPopRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopDeleteMultipleFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopMove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPopView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopRetrieve = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopResumeDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopCalcTotalSize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPopProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPopRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.makeDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synchronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTimeDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMultipleFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadUniqueFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateTotalSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.splitContainerUpDown = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeftRight = new System.Windows.Forms.SplitContainer();
            this.btnLocalDirBrowse = new System.Windows.Forms.Button();
            this.txtLocalDir = new System.Windows.Forms.TextBox();
            this.lblLocalDir = new System.Windows.Forms.Label();
            this.lvwLocal = new ClientSample.DragAndDropListView();
            this.chFileName = new System.Windows.Forms.ColumnHeader();
            this.chSize = new System.Windows.Forms.ColumnHeader();
            this.chDateTime = new System.Windows.Forms.ColumnHeader();
            this.txtRemoteDir = new System.Windows.Forms.TextBox();
            this.lblRemoteDir = new System.Windows.Forms.Label();
            this.lvwRemote = new ClientSample.DragAndDropListView();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colPermissions = new System.Windows.Forms.ColumnHeader();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.btnAbort = new System.Windows.Forms.ToolStripButton();
            this.keepAliveTimer = new System.Windows.Forms.Timer(this.components);
            this.tsbLogin = new System.Windows.Forms.ToolStripButton();
            this.tsbLogout = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbCreateDir = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbMove = new System.Windows.Forms.ToolStripButton();
            this.tsbDownload = new System.Windows.Forms.ToolStripButton();
            this.tsbUpload = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbSynchronize = new System.Windows.Forms.ToolStripButton();
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.localContextMenu.SuspendLayout();
            this.remoteContextMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.splitContainerUpDown.Panel1.SuspendLayout();
            this.splitContainerUpDown.Panel2.SuspendLayout();
            this.splitContainerUpDown.SuspendLayout();
            this.splitContainerLeftRight.Panel1.SuspendLayout();
            this.splitContainerLeftRight.Panel2.SuspendLayout();
            this.splitContainerLeftRight.SuspendLayout();
            this.toolbarMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // localContextMenu
            // 
            this.localContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lcmMakeDir,
            this.lcmSynchronize,
            this.menuItem10,
            this.lcmSelectGroup,
            this.lcmUnselectGroup,
            this.menuItem6,
            this.lcmRename,
            this.lcmDelete,
            this.lcmMove,
            this.menuItem7,
            this.lcmView,
            this.lcmUpload,
            this.lcmResumeUpload,
            this.lcmUploadUnique,
            this.lcmProperties,
            this.menuItem8,
            this.lcmRefresh});
            this.localContextMenu.Name = "localContextMenu";
            this.localContextMenu.Size = new System.Drawing.Size(160, 314);
            this.localContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.localContextMenu_Popup);
            // 
            // lcmMakeDir
            // 
            this.lcmMakeDir.Image = ((System.Drawing.Image)(resources.GetObject("lcmMakeDir.Image")));
            this.lcmMakeDir.Name = "lcmMakeDir";
            this.lcmMakeDir.Size = new System.Drawing.Size(159, 22);
            this.lcmMakeDir.Text = "&Make Directory";
            this.lcmMakeDir.Click += new System.EventHandler(this.lcmMakeDir_Click);
            // 
            // lcmSynchronize
            // 
            this.lcmSynchronize.Image = ((System.Drawing.Image)(resources.GetObject("lcmSynchronize.Image")));
            this.lcmSynchronize.Name = "lcmSynchronize";
            this.lcmSynchronize.Size = new System.Drawing.Size(159, 22);
            this.lcmSynchronize.Text = "&Synchronize...";
            this.lcmSynchronize.Click += new System.EventHandler(this.lcmSynchronize_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Name = "menuItem10";
            this.menuItem10.Size = new System.Drawing.Size(156, 6);
            // 
            // lcmSelectGroup
            // 
            this.lcmSelectGroup.Name = "lcmSelectGroup";
            this.lcmSelectGroup.Size = new System.Drawing.Size(159, 22);
            this.lcmSelectGroup.Text = "Select Group...";
            this.lcmSelectGroup.Click += new System.EventHandler(this.lcmSelectGroup_Click);
            // 
            // lcmUnselectGroup
            // 
            this.lcmUnselectGroup.Name = "lcmUnselectGroup";
            this.lcmUnselectGroup.Size = new System.Drawing.Size(159, 22);
            this.lcmUnselectGroup.Text = "Unselect Group...";
            this.lcmUnselectGroup.Click += new System.EventHandler(this.lcmUnselectGroup_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(156, 6);
            // 
            // lcmRename
            // 
            this.lcmRename.Name = "lcmRename";
            this.lcmRename.Size = new System.Drawing.Size(159, 22);
            this.lcmRename.Text = "&Rename";
            this.lcmRename.Click += new System.EventHandler(this.lcmRename_Click);
            // 
            // lcmDelete
            // 
            this.lcmDelete.Image = ((System.Drawing.Image)(resources.GetObject("lcmDelete.Image")));
            this.lcmDelete.Name = "lcmDelete";
            this.lcmDelete.Size = new System.Drawing.Size(159, 22);
            this.lcmDelete.Text = "&Delete";
            this.lcmDelete.Click += new System.EventHandler(this.lcmDelete_Click);
            // 
            // lcmMove
            // 
            this.lcmMove.Name = "lcmMove";
            this.lcmMove.Size = new System.Drawing.Size(159, 22);
            this.lcmMove.Text = "M&ove...";
            this.lcmMove.Click += new System.EventHandler(this.lcmMove_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Name = "menuItem7";
            this.menuItem7.Size = new System.Drawing.Size(156, 6);
            // 
            // lcmView
            // 
            this.lcmView.Image = ((System.Drawing.Image)(resources.GetObject("lcmView.Image")));
            this.lcmView.Name = "lcmView";
            this.lcmView.Size = new System.Drawing.Size(159, 22);
            this.lcmView.Text = "&View...";
            this.lcmView.Click += new System.EventHandler(this.lcmView_Click);
            // 
            // lcmUpload
            // 
            this.lcmUpload.Image = ((System.Drawing.Image)(resources.GetObject("lcmUpload.Image")));
            this.lcmUpload.Name = "lcmUpload";
            this.lcmUpload.Size = new System.Drawing.Size(159, 22);
            this.lcmUpload.Text = "&Upload";
            this.lcmUpload.Click += new System.EventHandler(this.lcmUpload_Click);
            // 
            // lcmResumeUpload
            // 
            this.lcmResumeUpload.Image = ((System.Drawing.Image)(resources.GetObject("lcmResumeUpload.Image")));
            this.lcmResumeUpload.Name = "lcmResumeUpload";
            this.lcmResumeUpload.Size = new System.Drawing.Size(159, 22);
            this.lcmResumeUpload.Text = "Resume Upload";
            this.lcmResumeUpload.Click += new System.EventHandler(this.lcmResumeUpload_Click);
            // 
            // lcmUploadUnique
            // 
            this.lcmUploadUnique.Image = ((System.Drawing.Image)(resources.GetObject("lcmUploadUnique.Image")));
            this.lcmUploadUnique.Name = "lcmUploadUnique";
            this.lcmUploadUnique.Size = new System.Drawing.Size(159, 22);
            this.lcmUploadUnique.Text = "U&pload Unique";
            this.lcmUploadUnique.Click += new System.EventHandler(this.lcmUploadUnique_Click);
            // 
            // lcmProperties
            // 
            this.lcmProperties.Name = "lcmProperties";
            this.lcmProperties.Size = new System.Drawing.Size(159, 22);
            this.lcmProperties.Text = "Properties...";
            this.lcmProperties.Click += new System.EventHandler(this.lcmProperties_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Name = "menuItem8";
            this.menuItem8.Size = new System.Drawing.Size(156, 6);
            // 
            // lcmRefresh
            // 
            this.lcmRefresh.Image = ((System.Drawing.Image)(resources.GetObject("lcmRefresh.Image")));
            this.lcmRefresh.Name = "lcmRefresh";
            this.lcmRefresh.Size = new System.Drawing.Size(159, 22);
            this.lcmRefresh.Text = "&Refresh";
            this.lcmRefresh.Click += new System.EventHandler(this.lcmRefresh_Click);
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "UpFolder.gif");
            this.imglist.Images.SetKeyName(1, "");
            this.imglist.Images.SetKeyName(2, "");
            // 
            // remoteContextMenu
            // 
            this.remoteContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPopMkdir,
            this.mnuPopSynchronize,
            this.mnuPopExecuteCommand,
            this.mnuPopGetTimeDiff,
            this.menuItem9,
            this.mnuPopSelectGroup,
            this.mnuPopUnselectGroup,
            this.menuItem3,
            this.mnuPopRename,
            this.mnuPopDelete,
            this.mnuPopDeleteMultipleFiles,
            this.mnuPopMove,
            this.menuItem1,
            this.mnuPopView,
            this.mnuPopRetrieve,
            this.mnuPopResumeDownload,
            this.mnuPopCalcTotalSize,
            this.mnuPopProperties,
            this.menuItem4,
            this.mnuPopRefresh});
            this.remoteContextMenu.Name = "remoteContextMenu";
            this.remoteContextMenu.Size = new System.Drawing.Size(183, 380);
            this.remoteContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.remoteContextMenu_Popup);
            // 
            // mnuPopMkdir
            // 
            this.mnuPopMkdir.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopMkdir.Image")));
            this.mnuPopMkdir.Name = "mnuPopMkdir";
            this.mnuPopMkdir.Size = new System.Drawing.Size(182, 22);
            this.mnuPopMkdir.Text = "&Make Directory";
            this.mnuPopMkdir.Click += new System.EventHandler(this.mnuPopMkdir_Click);
            // 
            // mnuPopSynchronize
            // 
            this.mnuPopSynchronize.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopSynchronize.Image")));
            this.mnuPopSynchronize.Name = "mnuPopSynchronize";
            this.mnuPopSynchronize.Size = new System.Drawing.Size(182, 22);
            this.mnuPopSynchronize.Text = "&Synchronize...";
            this.mnuPopSynchronize.Click += new System.EventHandler(this.mnuSynchronize_Click);
            // 
            // mnuPopExecuteCommand
            // 
            this.mnuPopExecuteCommand.Name = "mnuPopExecuteCommand";
            this.mnuPopExecuteCommand.Size = new System.Drawing.Size(182, 22);
            this.mnuPopExecuteCommand.Text = "Execute Command...";
            this.mnuPopExecuteCommand.Click += new System.EventHandler(this.mnuPopExecuteCommand_Click);
            // 
            // mnuPopGetTimeDiff
            // 
            this.mnuPopGetTimeDiff.Name = "mnuPopGetTimeDiff";
            this.mnuPopGetTimeDiff.Size = new System.Drawing.Size(182, 22);
            this.mnuPopGetTimeDiff.Text = "Get Time Difference";
            this.mnuPopGetTimeDiff.Click += new System.EventHandler(this.mnuPopGetTimeDiff_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Name = "menuItem9";
            this.menuItem9.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuPopSelectGroup
            // 
            this.mnuPopSelectGroup.Name = "mnuPopSelectGroup";
            this.mnuPopSelectGroup.Size = new System.Drawing.Size(182, 22);
            this.mnuPopSelectGroup.Text = "Select Group...";
            this.mnuPopSelectGroup.Click += new System.EventHandler(this.mnuPopSelectGroup_Click);
            // 
            // mnuPopUnselectGroup
            // 
            this.mnuPopUnselectGroup.Name = "mnuPopUnselectGroup";
            this.mnuPopUnselectGroup.Size = new System.Drawing.Size(182, 22);
            this.mnuPopUnselectGroup.Text = "Unselect Group...";
            this.mnuPopUnselectGroup.Click += new System.EventHandler(this.mnuPopUnselectGroup_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuPopRename
            // 
            this.mnuPopRename.Name = "mnuPopRename";
            this.mnuPopRename.Size = new System.Drawing.Size(182, 22);
            this.mnuPopRename.Text = "&Rename";
            this.mnuPopRename.Click += new System.EventHandler(this.mnuPopRename_Click);
            // 
            // mnuPopDelete
            // 
            this.mnuPopDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopDelete.Image")));
            this.mnuPopDelete.Name = "mnuPopDelete";
            this.mnuPopDelete.Size = new System.Drawing.Size(182, 22);
            this.mnuPopDelete.Text = "&Delete";
            this.mnuPopDelete.Click += new System.EventHandler(this.mnuPopDelete_Click);
            // 
            // mnuPopDeleteMultipleFiles
            // 
            this.mnuPopDeleteMultipleFiles.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopDeleteMultipleFiles.Image")));
            this.mnuPopDeleteMultipleFiles.Name = "mnuPopDeleteMultipleFiles";
            this.mnuPopDeleteMultipleFiles.Size = new System.Drawing.Size(182, 22);
            this.mnuPopDeleteMultipleFiles.Text = "Delete Multiple Files...";
            this.mnuPopDeleteMultipleFiles.Click += new System.EventHandler(this.mnuPopDeleteMultipleFiles_Click);
            // 
            // mnuPopMove
            // 
            this.mnuPopMove.Name = "mnuPopMove";
            this.mnuPopMove.Size = new System.Drawing.Size(182, 22);
            this.mnuPopMove.Text = "M&ove...";
            this.mnuPopMove.Click += new System.EventHandler(this.mnuPopMove_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuPopView
            // 
            this.mnuPopView.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopView.Image")));
            this.mnuPopView.Name = "mnuPopView";
            this.mnuPopView.Size = new System.Drawing.Size(182, 22);
            this.mnuPopView.Text = "&View...";
            this.mnuPopView.Click += new System.EventHandler(this.mnuPopView_Click);
            // 
            // mnuPopRetrieve
            // 
            this.mnuPopRetrieve.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopRetrieve.Image")));
            this.mnuPopRetrieve.Name = "mnuPopRetrieve";
            this.mnuPopRetrieve.Size = new System.Drawing.Size(182, 22);
            this.mnuPopRetrieve.Text = "Download";
            this.mnuPopRetrieve.Click += new System.EventHandler(this.mnuPopRetrieve_Click);
            // 
            // mnuPopResumeDownload
            // 
            this.mnuPopResumeDownload.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopResumeDownload.Image")));
            this.mnuPopResumeDownload.Name = "mnuPopResumeDownload";
            this.mnuPopResumeDownload.Size = new System.Drawing.Size(182, 22);
            this.mnuPopResumeDownload.Text = "Resume Download";
            this.mnuPopResumeDownload.Click += new System.EventHandler(this.mnuPopResumeDownload_Click);
            // 
            // mnuPopCalcTotalSize
            // 
            this.mnuPopCalcTotalSize.Name = "mnuPopCalcTotalSize";
            this.mnuPopCalcTotalSize.Size = new System.Drawing.Size(182, 22);
            this.mnuPopCalcTotalSize.Text = "Calculate Total Size...";
            this.mnuPopCalcTotalSize.Click += new System.EventHandler(this.mnuPopCalcTotalSize_Click);
            // 
            // mnuPopProperties
            // 
            this.mnuPopProperties.Name = "mnuPopProperties";
            this.mnuPopProperties.Size = new System.Drawing.Size(182, 22);
            this.mnuPopProperties.Text = "Proper&ties / CHMOD...";
            this.mnuPopProperties.Click += new System.EventHandler(this.mnuPopProperties_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuPopRefresh
            // 
            this.mnuPopRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuPopRefresh.Image")));
            this.mnuPopRefresh.Name = "mnuPopRefresh";
            this.mnuPopRefresh.Size = new System.Drawing.Size(182, 22);
            this.mnuPopRefresh.Text = "&Refresh";
            this.mnuPopRefresh.Click += new System.EventHandler(this.mnuPopRefresh_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(726, 24);
            this.menuStrip.TabIndex = 138;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.toolStripSeparator6,
            this.makeDirectoryToolStripMenuItem,
            this.synchronizeToolStripMenuItem,
            this.executeCommandToolStripMenuItem,
            this.getTimeDifferenceToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteMultipleFilesToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.uploadFileToolStripMenuItem,
            this.uploadUniqueFileToolStripMenuItem,
            this.resumeDownloadToolStripMenuItem,
            this.resumeUploadToolStripMenuItem,
            this.calculateTotalSizeToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator8,
            this.exitToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(35, 20);
            this.fileMenu.Text = "&File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginToolStripMenuItem.Text = "&Connect...";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // makeDirectoryToolStripMenuItem
            // 
            this.makeDirectoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("makeDirectoryToolStripMenuItem.Image")));
            this.makeDirectoryToolStripMenuItem.Name = "makeDirectoryToolStripMenuItem";
            this.makeDirectoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.makeDirectoryToolStripMenuItem.Text = "&Make Directory";
            this.makeDirectoryToolStripMenuItem.Click += new System.EventHandler(this.makeDirectoryToolStripMenuItem_Click);
            // 
            // synchronizeToolStripMenuItem
            // 
            this.synchronizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("synchronizeToolStripMenuItem.Image")));
            this.synchronizeToolStripMenuItem.Name = "synchronizeToolStripMenuItem";
            this.synchronizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.synchronizeToolStripMenuItem.Text = "&Synchronize...";
            this.synchronizeToolStripMenuItem.Click += new System.EventHandler(this.synchronizeToolStripMenuItem_Click);
            // 
            // executeCommandToolStripMenuItem
            // 
            this.executeCommandToolStripMenuItem.Name = "executeCommandToolStripMenuItem";
            this.executeCommandToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.executeCommandToolStripMenuItem.Text = "Execute Command";
            this.executeCommandToolStripMenuItem.Click += new System.EventHandler(this.executeCommandToolStripMenuItem_Click);
            // 
            // getTimeDifferenceToolStripMenuItem
            // 
            this.getTimeDifferenceToolStripMenuItem.Name = "getTimeDifferenceToolStripMenuItem";
            this.getTimeDifferenceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.getTimeDifferenceToolStripMenuItem.Text = "Get Time Difference";
            this.getTimeDifferenceToolStripMenuItem.Click += new System.EventHandler(this.getTimeDifferenceToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renameToolStripMenuItem.Text = "&Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteMultipleFilesToolStripMenuItem
            // 
            this.deleteMultipleFilesToolStripMenuItem.Name = "deleteMultipleFilesToolStripMenuItem";
            this.deleteMultipleFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteMultipleFilesToolStripMenuItem.Text = "Delete Multiple Files...";
            this.deleteMultipleFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteMultipleFilesToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.moveToolStripMenuItem.Text = "M&ove...";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewToolStripMenuItem.Image")));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("downloadToolStripMenuItem.Image")));
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // uploadFileToolStripMenuItem
            // 
            this.uploadFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadFileToolStripMenuItem.Image")));
            this.uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem";
            this.uploadFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uploadFileToolStripMenuItem.Text = "&Upload";
            this.uploadFileToolStripMenuItem.Click += new System.EventHandler(this.uploadFileToolStripMenuItem_Click);
            // 
            // uploadUniqueFileToolStripMenuItem
            // 
            this.uploadUniqueFileToolStripMenuItem.Name = "uploadUniqueFileToolStripMenuItem";
            this.uploadUniqueFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uploadUniqueFileToolStripMenuItem.Text = "U&pload Unique";
            this.uploadUniqueFileToolStripMenuItem.Click += new System.EventHandler(this.uploadUniqueFileToolStripMenuItem_Click);
            // 
            // resumeDownloadToolStripMenuItem
            // 
            this.resumeDownloadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resumeDownloadToolStripMenuItem.Image")));
            this.resumeDownloadToolStripMenuItem.Name = "resumeDownloadToolStripMenuItem";
            this.resumeDownloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resumeDownloadToolStripMenuItem.Text = "Resume Download";
            this.resumeDownloadToolStripMenuItem.Click += new System.EventHandler(this.resumeDownloadToolStripMenuItem_Click);
            // 
            // resumeUploadToolStripMenuItem
            // 
            this.resumeUploadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resumeUploadToolStripMenuItem.Image")));
            this.resumeUploadToolStripMenuItem.Name = "resumeUploadToolStripMenuItem";
            this.resumeUploadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resumeUploadToolStripMenuItem.Text = "Resume Upload";
            this.resumeUploadToolStripMenuItem.Click += new System.EventHandler(this.resumeUploadToolStripMenuItem_Click);
            // 
            // calculateTotalSizeToolStripMenuItem
            // 
            this.calculateTotalSizeToolStripMenuItem.Name = "calculateTotalSizeToolStripMenuItem";
            this.calculateTotalSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.calculateTotalSizeToolStripMenuItem.Text = "Calculate Total Size";
            this.calculateTotalSizeToolStripMenuItem.Click += new System.EventHandler(this.calculateTotalSizeToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.propertiesToolStripMenuItem.Text = "Proper&ties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "Refres&h";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(5, 571);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(716, 10);
            this.progressBar.TabIndex = 23;
            // 
            // splitContainerUpDown
            // 
            this.splitContainerUpDown.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUpDown.Location = new System.Drawing.Point(0, 76);
            this.splitContainerUpDown.Name = "splitContainerUpDown";
            this.splitContainerUpDown.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerUpDown.Panel1
            // 
            this.splitContainerUpDown.Panel1.Controls.Add(this.splitContainerLeftRight);
            // 
            // splitContainerUpDown.Panel2
            // 
            this.splitContainerUpDown.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerUpDown.Panel2.Controls.Add(this.txtLog);
            this.splitContainerUpDown.Size = new System.Drawing.Size(726, 519);
            this.splitContainerUpDown.SplitterDistance = 363;
            this.splitContainerUpDown.SplitterWidth = 2;
            this.splitContainerUpDown.TabIndex = 27;
            // 
            // splitContainerLeftRight
            // 
            this.splitContainerLeftRight.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeftRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeftRight.Name = "splitContainerLeftRight";
            // 
            // splitContainerLeftRight.Panel1
            // 
            this.splitContainerLeftRight.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerLeftRight.Panel1.Controls.Add(this.btnLocalDirBrowse);
            this.splitContainerLeftRight.Panel1.Controls.Add(this.txtLocalDir);
            this.splitContainerLeftRight.Panel1.Controls.Add(this.lblLocalDir);
            this.splitContainerLeftRight.Panel1.Controls.Add(this.lvwLocal);
            // 
            // splitContainerLeftRight.Panel2
            // 
            this.splitContainerLeftRight.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerLeftRight.Panel2.Controls.Add(this.txtRemoteDir);
            this.splitContainerLeftRight.Panel2.Controls.Add(this.lblRemoteDir);
            this.splitContainerLeftRight.Panel2.Controls.Add(this.lvwRemote);
            this.splitContainerLeftRight.Size = new System.Drawing.Size(726, 363);
            this.splitContainerLeftRight.SplitterDistance = 354;
            this.splitContainerLeftRight.TabIndex = 0;
            // 
            // btnLocalDirBrowse
            // 
            this.btnLocalDirBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalDirBrowse.Location = new System.Drawing.Point(327, 3);
            this.btnLocalDirBrowse.Name = "btnLocalDirBrowse";
            this.btnLocalDirBrowse.Size = new System.Drawing.Size(26, 20);
            this.btnLocalDirBrowse.TabIndex = 2;
            this.btnLocalDirBrowse.Text = "...";
            this.btnLocalDirBrowse.UseVisualStyleBackColor = true;
            this.btnLocalDirBrowse.Click += new System.EventHandler(this.btnLocalDirBrowse_Click);
            // 
            // txtLocalDir
            // 
            this.txtLocalDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalDir.Location = new System.Drawing.Point(56, 3);
            this.txtLocalDir.Name = "txtLocalDir";
            this.txtLocalDir.Size = new System.Drawing.Size(267, 20);
            this.txtLocalDir.TabIndex = 1;
            this.txtLocalDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocalDir_KeyDown);
            // 
            // lblLocalDir
            // 
            this.lblLocalDir.AutoSize = true;
            this.lblLocalDir.Location = new System.Drawing.Point(1, 6);
            this.lblLocalDir.Name = "lblLocalDir";
            this.lblLocalDir.Size = new System.Drawing.Size(52, 13);
            this.lblLocalDir.TabIndex = 57;
            this.lblLocalDir.Text = "Local Dir:";
            // 
            // lvwLocal
            // 
            this.lvwLocal.AllowDrag = true;
            this.lvwLocal.AllowDrop = true;
            this.lvwLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chSize,
            this.chDateTime});
            this.lvwLocal.ContextMenuStrip = this.localContextMenu;
            this.lvwLocal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwLocal.FullRowSelect = true;
            this.lvwLocal.LabelEdit = true;
            this.lvwLocal.Location = new System.Drawing.Point(0, 25);
            this.lvwLocal.Name = "lvwLocal";
            this.lvwLocal.Size = new System.Drawing.Size(354, 336);
            this.lvwLocal.SmallImageList = this.imglist;
            this.lvwLocal.TabIndex = 3;
            this.lvwLocal.UseCompatibleStateImageBehavior = false;
            this.lvwLocal.View = System.Windows.Forms.View.Details;
            this.lvwLocal.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvwLocal_AfterLabelEdit);
            this.lvwLocal.SelectedIndexChanged += new System.EventHandler(this.lvwLocal_SelectedIndexChanged);
            this.lvwLocal.DoubleClick += new System.EventHandler(this.lvwLocal_DoubleClick);
            this.lvwLocal.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwLocal_DragDrop);
            this.lvwLocal.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwLocal_ColumnClick);
            this.lvwLocal.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvwLocal_BeforeLabelEdit);
            this.lvwLocal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwLocal_KeyDown);
            // 
            // chFileName
            // 
            this.chFileName.Text = "File Name";
            this.chFileName.Width = 200;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            this.chSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chSize.Width = 100;
            // 
            // chDateTime
            // 
            this.chDateTime.Text = "Date";
            this.chDateTime.Width = 150;
            // 
            // txtRemoteDir
            // 
            this.txtRemoteDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteDir.Enabled = false;
            this.txtRemoteDir.Location = new System.Drawing.Point(67, 3);
            this.txtRemoteDir.Name = "txtRemoteDir";
            this.txtRemoteDir.Size = new System.Drawing.Size(301, 20);
            this.txtRemoteDir.TabIndex = 10;
            this.txtRemoteDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemoteDir_KeyDown);
            // 
            // lblRemoteDir
            // 
            this.lblRemoteDir.AutoSize = true;
            this.lblRemoteDir.Location = new System.Drawing.Point(2, 6);
            this.lblRemoteDir.Name = "lblRemoteDir";
            this.lblRemoteDir.Size = new System.Drawing.Size(63, 13);
            this.lblRemoteDir.TabIndex = 54;
            this.lblRemoteDir.Text = "Remote Dir:";
            // 
            // lvwRemote
            // 
            this.lvwRemote.AllowDrag = true;
            this.lvwRemote.AllowDrop = true;
            this.lvwRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colSize,
            this.colDate,
            this.colPermissions});
            this.lvwRemote.ContextMenuStrip = this.remoteContextMenu;
            this.lvwRemote.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwRemote.FullRowSelect = true;
            this.lvwRemote.LabelEdit = true;
            this.lvwRemote.Location = new System.Drawing.Point(1, 25);
            this.lvwRemote.Name = "lvwRemote";
            this.lvwRemote.Size = new System.Drawing.Size(367, 336);
            this.lvwRemote.SmallImageList = this.imglist;
            this.lvwRemote.TabIndex = 11;
            this.lvwRemote.UseCompatibleStateImageBehavior = false;
            this.lvwRemote.View = System.Windows.Forms.View.Details;
            this.lvwRemote.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvwRemote_AfterLabelEdit);
            this.lvwRemote.SelectedIndexChanged += new System.EventHandler(this.lvwRemote_SelectedIndexChanged);
            this.lvwRemote.DoubleClick += new System.EventHandler(this.lvwRemote_DoubleClick);
            this.lvwRemote.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwRemote_DragDrop);
            this.lvwRemote.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwRemote_ColumnClick);
            this.lvwRemote.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvwRemote_BeforeLabelEdit);
            this.lvwRemote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwRemote_KeyDown);
            // 
            // colFileName
            // 
            this.colFileName.Text = "File Name";
            this.colFileName.Width = 200;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSize.Width = 100;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 150;
            // 
            // colPermissions
            // 
            this.colPermissions.Text = "Permissions";
            this.colPermissions.Width = 100;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Silver;
            this.txtLog.Location = new System.Drawing.Point(0, 2);
            this.txtLog.MaxLength = 0;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(726, 125);
            this.txtLog.TabIndex = 22;
            this.txtLog.Text = "";
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTotal.Location = new System.Drawing.Point(5, 582);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(716, 10);
            this.progressBarTotal.TabIndex = 136;
            // 
            // btnAbort
            // 
            this.btnAbort.AutoSize = false;
            this.btnAbort.Enabled = false;
            this.btnAbort.Image = ((System.Drawing.Image)(resources.GetObject("btnAbort.Image")));
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(52, 49);
            this.btnAbort.Text = "Abort";
            this.btnAbort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // tsbLogin
            // 
            this.tsbLogin.AutoSize = false;
            this.tsbLogin.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogin.Image")));
            this.tsbLogin.Name = "tsbLogin";
            this.tsbLogin.Size = new System.Drawing.Size(52, 49);
            this.tsbLogin.Text = "Connect";
            this.tsbLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLogin.Click += new System.EventHandler(this.tsbLogin_Click);
            // 
            // tsbLogout
            // 
            this.tsbLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogout.Image")));
            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Size = new System.Drawing.Size(63, 49);
            this.tsbLogout.Text = "Disconnect";
            this.tsbLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLogout.Visible = false;
            this.tsbLogout.Click += new System.EventHandler(this.tsbLogout_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(42, 66);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.AutoSize = false;
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(52, 49);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // tsbCreateDir
            // 
            this.tsbCreateDir.AutoSize = false;
            this.tsbCreateDir.Enabled = false;
            this.tsbCreateDir.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateDir.Image")));
            this.tsbCreateDir.Name = "tsbCreateDir";
            this.tsbCreateDir.Size = new System.Drawing.Size(62, 49);
            this.tsbCreateDir.Text = "Create Dir";
            this.tsbCreateDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCreateDir.Click += new System.EventHandler(this.tsbCreateDir_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.AutoSize = false;
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(52, 49);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbMove
            // 
            this.tsbMove.AutoSize = false;
            this.tsbMove.Enabled = false;
            this.tsbMove.Image = ((System.Drawing.Image)(resources.GetObject("tsbMove.Image")));
            this.tsbMove.Name = "tsbMove";
            this.tsbMove.Size = new System.Drawing.Size(52, 49);
            this.tsbMove.Text = "Move...";
            this.tsbMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMove.Click += new System.EventHandler(this.tsbMove_Click);
            // 
            // tsbDownload
            // 
            this.tsbDownload.Enabled = false;
            this.tsbDownload.Image = ((System.Drawing.Image)(resources.GetObject("tsbDownload.Image")));
            this.tsbDownload.Name = "tsbDownload";
            this.tsbDownload.Size = new System.Drawing.Size(58, 49);
            this.tsbDownload.Text = "Download";
            this.tsbDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDownload.Click += new System.EventHandler(this.tsbDownload_Click);
            // 
            // tsbUpload
            // 
            this.tsbUpload.AutoSize = false;
            this.tsbUpload.Enabled = false;
            this.tsbUpload.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpload.Image")));
            this.tsbUpload.Name = "tsbUpload";
            this.tsbUpload.Size = new System.Drawing.Size(52, 49);
            this.tsbUpload.Text = "Upload";
            this.tsbUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUpload.Click += new System.EventHandler(this.tsbUpload_Click);
            // 
            // tsbView
            // 
            this.tsbView.AutoSize = false;
            this.tsbView.Enabled = false;
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(52, 49);
            this.tsbView.Text = "View";
            this.tsbView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // tsbSynchronize
            // 
            this.tsbSynchronize.AutoSize = false;
            this.tsbSynchronize.Enabled = false;
            this.tsbSynchronize.Image = ((System.Drawing.Image)(resources.GetObject("tsbSynchronize.Image")));
            this.tsbSynchronize.Name = "tsbSynchronize";
            this.tsbSynchronize.Size = new System.Drawing.Size(72, 49);
            this.tsbSynchronize.Text = "Synchronize";
            this.tsbSynchronize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSynchronize.Click += new System.EventHandler(this.tsbSynchronize_Click);
            // 
            // toolbarMain
            // 
            this.toolbarMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLogin,
            this.tsbLogout,
            this.tsbSettings,
            this.toolStripSeparator4,
            this.tsbUpload,
            this.tsbDownload,
            this.btnAbort,
            this.toolStripSeparator5,
            this.tsbDelete,
            this.tsbMove,
            this.tsbCreateDir,
            this.tsbSynchronize,
            this.toolStripSeparator7,
            this.tsbView});
            this.toolbarMain.Location = new System.Drawing.Point(0, 24);
            this.toolbarMain.Name = "toolbarMain";
            this.toolbarMain.Size = new System.Drawing.Size(726, 52);
            this.toolbarMain.TabIndex = 137;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 595);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(726, 22);
            this.statusStrip.TabIndex = 139;
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(38, 17);
            this.status.Text = "Ready";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 617);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.progressBarTotal);
            this.Controls.Add(this.splitContainerUpDown);
            this.Controls.Add(this.toolbarMain);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimate FTP Client Demo";
            this.localContextMenu.ResumeLayout(false);
            this.remoteContextMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainerUpDown.Panel1.ResumeLayout(false);
            this.splitContainerUpDown.Panel2.ResumeLayout(false);
            this.splitContainerUpDown.ResumeLayout(false);
            this.splitContainerLeftRight.Panel1.ResumeLayout(false);
            this.splitContainerLeftRight.Panel1.PerformLayout();
            this.splitContainerLeftRight.Panel2.ResumeLayout(false);
            this.splitContainerLeftRight.Panel2.PerformLayout();
            this.splitContainerLeftRight.ResumeLayout(false);
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadUniqueFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton btnAbort;
        internal System.Windows.Forms.ContextMenuStrip remoteContextMenu;
        internal System.Windows.Forms.ToolStripMenuItem mnuPopRename;
        internal System.Windows.Forms.ToolStripMenuItem mnuPopDelete;
        internal System.Windows.Forms.ToolStripMenuItem mnuPopRetrieve;
        internal System.Windows.Forms.ToolStripMenuItem mnuPopView;
        internal System.Windows.Forms.ToolStripMenuItem mnuPopRefresh;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerUpDown;
        public System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Timer keepAliveTimer;
        private System.Windows.Forms.SplitContainer splitContainerLeftRight;
        private System.Windows.Forms.TextBox txtRemoteDir;
        private System.Windows.Forms.Label lblRemoteDir;
        public DragAndDropListView lvwRemote;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colPermissions;
        private System.Windows.Forms.TextBox txtLocalDir;
        private System.Windows.Forms.Label lblLocalDir;
        public DragAndDropListView lvwLocal;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chDateTime;
        private System.Windows.Forms.Button btnLocalDirBrowse;
        internal System.Windows.Forms.ContextMenuStrip localContextMenu;
        internal System.Windows.Forms.ToolStripMenuItem lcmRename;
        internal System.Windows.Forms.ToolStripMenuItem lcmMakeDir;
        internal System.Windows.Forms.ToolStripMenuItem lcmDelete;
        internal System.Windows.Forms.ToolStripMenuItem lcmUpload;
        internal System.Windows.Forms.ToolStripMenuItem lcmUploadUnique;
        internal System.Windows.Forms.ToolStripMenuItem lcmView;
        internal System.Windows.Forms.ToolStripMenuItem lcmRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuPopMove;
        private System.Windows.Forms.ToolStripMenuItem lcmMove;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbLogin;
        private System.Windows.Forms.ToolStripButton tsbLogout;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripButton tsbCreateDir;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbMove;
        private System.Windows.Forms.ToolStripButton tsbDownload;
        private System.Windows.Forms.ToolStripButton tsbUpload;
        private System.Windows.Forms.ToolStripButton tsbView;
        public System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.ToolStripButton tsbSynchronize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem synchronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPopSynchronize;
        private System.Windows.Forms.ToolStripSeparator menuItem3;
        private System.Windows.Forms.ToolStripSeparator menuItem1;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem lcmSynchronize;
        private System.Windows.Forms.ToolStripSeparator menuItem6;
        private System.Windows.Forms.ToolStripSeparator menuItem7;
        private System.Windows.Forms.ToolStripSeparator menuItem8;
        internal System.Windows.Forms.ToolStripMenuItem mnuPopMkdir;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPopProperties;
        private System.Windows.Forms.ToolStripMenuItem lcmProperties;
        private System.Windows.Forms.ToolStripMenuItem mnuPopResumeDownload;
        private System.Windows.Forms.ToolStripMenuItem mnuPopExecuteCommand;
        private System.Windows.Forms.ToolStripMenuItem mnuPopGetTimeDiff;
        private System.Windows.Forms.ToolStripMenuItem mnuPopCalcTotalSize;
        private System.Windows.Forms.ToolStripMenuItem lcmResumeUpload;
        private System.Windows.Forms.ToolStripMenuItem executeCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getTimeDifferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateTotalSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ProgressBar progressBarTotal;
        private System.Windows.Forms.ToolStripSeparator menuItem9;
        private System.Windows.Forms.ToolStripMenuItem mnuPopSelectGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuPopUnselectGroup;
        private System.Windows.Forms.ToolStripSeparator menuItem10;
        private System.Windows.Forms.ToolStripMenuItem lcmSelectGroup;
        private System.Windows.Forms.ToolStripMenuItem lcmUnselectGroup;
        private System.Windows.Forms.ToolStripMenuItem deleteMultipleFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPopDeleteMultipleFiles;
        private System.Windows.Forms.ToolStrip toolbarMain;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel status;
    }
}

