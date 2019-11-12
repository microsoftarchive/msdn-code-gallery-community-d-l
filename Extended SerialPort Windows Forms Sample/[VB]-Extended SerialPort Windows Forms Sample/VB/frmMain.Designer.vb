<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.toolstripComPort = New System.Windows.Forms.ToolStrip
        Me.label10 = New System.Windows.Forms.ToolStripLabel
        Me.cboComPort = New System.Windows.Forms.ToolStripComboBox
        Me.label11 = New System.Windows.Forms.ToolStripLabel
        Me.cboBaudrate = New System.Windows.Forms.ToolStripComboBox
        Me.Label30 = New System.Windows.Forms.ToolStripLabel
        Me.cboDataBits = New System.Windows.Forms.ToolStripComboBox
        Me.Label12 = New System.Windows.Forms.ToolStripLabel
        Me.cboParity = New System.Windows.Forms.ToolStripComboBox
        Me.Label13 = New System.Windows.Forms.ToolStripLabel
        Me.cboStopbits = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cboDelay = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.cboThreshold = New System.Windows.Forms.ToolStripComboBox
        Me.btnConnect = New System.Windows.Forms.ToolStripButton
        Me.statusC = New System.Windows.Forms.ToolStripLabel
        Me.Status1 = New System.Windows.Forms.StatusStrip
        Me.status0 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Menu1 = New System.Windows.Forms.MenuStrip
        Me.FileTool = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitTool = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsTool = New System.Windows.Forms.ToolStripMenuItem
        Me.ReceiveboxFontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LargeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MediumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SmallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.rtbRX = New System.Windows.Forms.RichTextBox
        Me.chkRxShowHex = New System.Windows.Forms.CheckBox
        Me.chkRxShowAscii = New System.Windows.Forms.CheckBox
        Me.toolstripRX = New System.Windows.Forms.ToolStrip
        Me.Label1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClearReceiveBox = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSaveFileFromRxBox = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.lblRxCnt = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.statusRX = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.chkAddCR = New System.Windows.Forms.CheckBox
        Me.chkAddLF = New System.Windows.Forms.CheckBox
        Me.chkTxEnterHex = New System.Windows.Forms.CheckBox
        Me.rtbTX = New System.Windows.Forms.RichTextBox
        Me.mnuTxBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyTx = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteTx = New System.Windows.Forms.ToolStripMenuItem
        Me.CutTx = New System.Windows.Forms.ToolStripMenuItem
        Me.SendLine = New System.Windows.Forms.ToolStripMenuItem
        Me.SendSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.toolstripSend = New System.Windows.Forms.ToolStrip
        Me.cboEnterMessage = New System.Windows.Forms.ToolStripComboBox
        Me.chkTxShowHex = New System.Windows.Forms.CheckBox
        Me.chkTxShowAscii = New System.Windows.Forms.CheckBox
        Me.toolstripTX = New System.Windows.Forms.ToolStrip
        Me.Label2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClearTxBox = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnLoadFileToTxBox = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.lblTxCnt = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.statusTX = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.toolstripComPort.SuspendLayout()
        Me.Status1.SuspendLayout()
        Me.Menu1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.toolstripRX.SuspendLayout()
        Me.mnuTxBox.SuspendLayout()
        Me.toolstripSend.SuspendLayout()
        Me.toolstripTX.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'toolstripComPort
        '
        Me.toolstripComPort.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.label10, Me.cboComPort, Me.label11, Me.cboBaudrate, Me.Label30, Me.cboDataBits, Me.Label12, Me.cboParity, Me.Label13, Me.cboStopbits, Me.ToolStripLabel1, Me.cboDelay, Me.ToolStripLabel2, Me.cboThreshold, Me.btnConnect, Me.statusC})
        Me.toolstripComPort.Location = New System.Drawing.Point(0, 24)
        Me.toolstripComPort.Name = "toolstripComPort"
        Me.toolstripComPort.Size = New System.Drawing.Size(746, 25)
        Me.toolstripComPort.TabIndex = 0
        Me.toolstripComPort.Text = "ToolStrip1"
        '
        'label10
        '
        Me.label10.AutoSize = False
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(35, 22)
        Me.label10.Text = "Port"
        Me.label10.ToolTipText = "ComPort"
        '
        'cboComPort
        '
        Me.cboComPort.AutoSize = False
        Me.cboComPort.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.Size = New System.Drawing.Size(60, 23)
        '
        'label11
        '
        Me.label11.AutoSize = False
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(35, 22)
        Me.label11.Text = "Baud"
        Me.label11.ToolTipText = "Baudrate"
        '
        'cboBaudrate
        '
        Me.cboBaudrate.AutoSize = False
        Me.cboBaudrate.DropDownWidth = 50
        Me.cboBaudrate.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400", "115200"})
        Me.cboBaudrate.Name = "cboBaudrate"
        Me.cboBaudrate.Size = New System.Drawing.Size(60, 23)
        Me.cboBaudrate.Text = "9600"
        '
        'Label30
        '
        Me.Label30.AutoSize = False
        Me.Label30.AutoToolTip = True
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(35, 22)
        Me.Label30.Text = "Data"
        Me.Label30.ToolTipText = "Databits"
        '
        'cboDataBits
        '
        Me.cboDataBits.AutoSize = False
        Me.cboDataBits.Items.AddRange(New Object() {"7", "8"})
        Me.cboDataBits.Name = "cboDataBits"
        Me.cboDataBits.Size = New System.Drawing.Size(35, 23)
        Me.cboDataBits.Text = "8"
        '
        'Label12
        '
        Me.Label12.AutoSize = False
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 22)
        Me.Label12.Text = "Parity"
        Me.Label12.ToolTipText = "Parity"
        '
        'cboParity
        '
        Me.cboParity.AutoSize = False
        Me.cboParity.Items.AddRange(New Object() {"None", "Even", "Mark", "Odd", "Space"})
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(60, 23)
        Me.cboParity.Text = "None"
        '
        'Label13
        '
        Me.Label13.AutoSize = False
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 22)
        Me.Label13.Text = "Stop"
        Me.Label13.ToolTipText = "Stopbits"
        '
        'cboStopbits
        '
        Me.cboStopbits.AutoSize = False
        Me.cboStopbits.DropDownWidth = 50
        Me.cboStopbits.Items.AddRange(New Object() {"None", "One", "Two"})
        Me.cboStopbits.Name = "cboStopbits"
        Me.cboStopbits.Size = New System.Drawing.Size(45, 23)
        Me.cboStopbits.Text = "One"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "delay"
        '
        'cboDelay
        '
        Me.cboDelay.AutoSize = False
        Me.cboDelay.Items.AddRange(New Object() {"1", "2", "5", "10", "20", "50", "100", "200", "500", "1000"})
        Me.cboDelay.Name = "cboDelay"
        Me.cboDelay.Size = New System.Drawing.Size(45, 23)
        Me.cboDelay.Text = "1"
        Me.cboDelay.ToolTipText = "Datareceived handle delay"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripLabel2.Text = "thresh"
        '
        'cboThreshold
        '
        Me.cboThreshold.AutoSize = False
        Me.cboThreshold.Items.AddRange(New Object() {"1", "2", "5", "10", "20", "50", "100", "200", "500", "1000"})
        Me.cboThreshold.Name = "cboThreshold"
        Me.cboThreshold.Size = New System.Drawing.Size(45, 23)
        Me.cboThreshold.Text = "1"
        Me.cboThreshold.ToolTipText = ".receivedBytesThreshold property"
        '
        'btnConnect
        '
        Me.btnConnect.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(64, 22)
        Me.btnConnect.Text = "*connect*"
        '
        'statusC
        '
        Me.statusC.Image = Global.comTerm.My.Resources.Resources.ledGray
        Me.statusC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.statusC.Name = "statusC"
        Me.statusC.Size = New System.Drawing.Size(16, 22)
        Me.statusC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.statusC.ToolTipText = "connection state"
        '
        'Status1
        '
        Me.Status1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status0})
        Me.Status1.Location = New System.Drawing.Point(0, 484)
        Me.Status1.Name = "Status1"
        Me.Status1.Size = New System.Drawing.Size(746, 22)
        Me.Status1.TabIndex = 1
        Me.Status1.Text = "StatusStrip1"
        '
        'status0
        '
        Me.status0.Name = "status0"
        Me.status0.Size = New System.Drawing.Size(121, 17)
        Me.status0.Text = "ToolStripStatusLabel1"
        '
        'Menu1
        '
        Me.Menu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileTool, Me.OptionsTool})
        Me.Menu1.Location = New System.Drawing.Point(0, 0)
        Me.Menu1.Name = "Menu1"
        Me.Menu1.Size = New System.Drawing.Size(746, 24)
        Me.Menu1.TabIndex = 2
        Me.Menu1.Text = "MenuStrip1"
        '
        'FileTool
        '
        Me.FileTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadConfig, Me.SaveConfig, Me.ExitTool})
        Me.FileTool.Name = "FileTool"
        Me.FileTool.Size = New System.Drawing.Size(37, 20)
        Me.FileTool.Text = "File"
        '
        'LoadConfig
        '
        Me.LoadConfig.Image = Global.comTerm.My.Resources.Resources.Disk
        Me.LoadConfig.Name = "LoadConfig"
        Me.LoadConfig.Size = New System.Drawing.Size(137, 22)
        Me.LoadConfig.Text = "Load config"
        '
        'SaveConfig
        '
        Me.SaveConfig.Image = Global.comTerm.My.Resources.Resources.Disk_download
        Me.SaveConfig.Name = "SaveConfig"
        Me.SaveConfig.Size = New System.Drawing.Size(137, 22)
        Me.SaveConfig.Text = "save config"
        '
        'ExitTool
        '
        Me.ExitTool.Image = Global.comTerm.My.Resources.Resources.Standby
        Me.ExitTool.Name = "ExitTool"
        Me.ExitTool.Size = New System.Drawing.Size(137, 22)
        Me.ExitTool.Text = "Exit"
        '
        'OptionsTool
        '
        Me.OptionsTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReceiveboxFontToolStripMenuItem})
        Me.OptionsTool.Name = "OptionsTool"
        Me.OptionsTool.Size = New System.Drawing.Size(61, 20)
        Me.OptionsTool.Text = "Options"
        '
        'ReceiveboxFontToolStripMenuItem
        '
        Me.ReceiveboxFontToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LargeToolStripMenuItem, Me.MediumToolStripMenuItem, Me.SmallToolStripMenuItem})
        Me.ReceiveboxFontToolStripMenuItem.Name = "ReceiveboxFontToolStripMenuItem"
        Me.ReceiveboxFontToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.ReceiveboxFontToolStripMenuItem.Text = "font"
        '
        'LargeToolStripMenuItem
        '
        Me.LargeToolStripMenuItem.Name = "LargeToolStripMenuItem"
        Me.LargeToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.LargeToolStripMenuItem.Text = "Large"
        '
        'MediumToolStripMenuItem
        '
        Me.MediumToolStripMenuItem.Name = "MediumToolStripMenuItem"
        Me.MediumToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.MediumToolStripMenuItem.Text = "Medium"
        '
        'SmallToolStripMenuItem
        '
        Me.SmallToolStripMenuItem.Name = "SmallToolStripMenuItem"
        Me.SmallToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.SmallToolStripMenuItem.Text = "Small"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtbRX)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkRxShowHex)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkRxShowAscii)
        Me.SplitContainer1.Panel1.Controls.Add(Me.toolstripRX)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkAddCR)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkAddLF)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkTxEnterHex)
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbTX)
        Me.SplitContainer1.Panel2.Controls.Add(Me.toolstripSend)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkTxShowHex)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkTxShowAscii)
        Me.SplitContainer1.Panel2.Controls.Add(Me.toolstripTX)
        Me.SplitContainer1.Size = New System.Drawing.Size(746, 435)
        Me.SplitContainer1.SplitterDistance = 270
        Me.SplitContainer1.TabIndex = 3
        '
        'rtbRX
        '
        Me.rtbRX.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rtbRX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbRX.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbRX.Location = New System.Drawing.Point(0, 25)
        Me.rtbRX.Name = "rtbRX"
        Me.rtbRX.Size = New System.Drawing.Size(744, 243)
        Me.rtbRX.TabIndex = 3
        Me.rtbRX.Text = "*"
        Me.rtbRX.WordWrap = False
        '
        'chkRxShowHex
        '
        Me.chkRxShowHex.AutoSize = True
        Me.chkRxShowHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkRxShowHex.Location = New System.Drawing.Point(330, 3)
        Me.chkRxShowHex.Name = "chkRxShowHex"
        Me.chkRxShowHex.Size = New System.Drawing.Size(74, 17)
        Me.chkRxShowHex.TabIndex = 2
        Me.chkRxShowHex.Text = "show HEX"
        Me.ToolTip1.SetToolTip(Me.chkRxShowHex, "show HEX data")
        Me.chkRxShowHex.UseVisualStyleBackColor = True
        '
        'chkRxShowAscii
        '
        Me.chkRxShowAscii.AutoSize = True
        Me.chkRxShowAscii.Checked = True
        Me.chkRxShowAscii.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRxShowAscii.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkRxShowAscii.Location = New System.Drawing.Point(410, 3)
        Me.chkRxShowAscii.Name = "chkRxShowAscii"
        Me.chkRxShowAscii.Size = New System.Drawing.Size(79, 17)
        Me.chkRxShowAscii.TabIndex = 1
        Me.chkRxShowAscii.Text = "show ASCII"
        Me.chkRxShowAscii.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.chkRxShowAscii, "show ascii")
        Me.chkRxShowAscii.UseVisualStyleBackColor = True
        '
        'toolstripRX
        '
        Me.toolstripRX.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Label1, Me.ToolStripSeparator2, Me.btnClearReceiveBox, Me.ToolStripSeparator3, Me.btnSaveFileFromRxBox, Me.ToolStripSeparator9, Me.lblRxCnt, Me.ToolStripSeparator10, Me.statusRX, Me.ToolStripSeparator11})
        Me.toolstripRX.Location = New System.Drawing.Point(0, 0)
        Me.toolstripRX.Name = "toolstripRX"
        Me.toolstripRX.Size = New System.Drawing.Size(744, 25)
        Me.toolstripRX.TabIndex = 0
        Me.toolstripRX.Text = "ToolStrip2"
        '
        'Label1
        '
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 22)
        Me.Label1.Text = "Receive box"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnClearReceiveBox
        '
        Me.btnClearReceiveBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClearReceiveBox.Image = Global.comTerm.My.Resources.Resources.Doc_Del
        Me.btnClearReceiveBox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClearReceiveBox.Name = "btnClearReceiveBox"
        Me.btnClearReceiveBox.Size = New System.Drawing.Size(23, 22)
        Me.btnClearReceiveBox.ToolTipText = "clear received box"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnSaveFileFromRxBox
        '
        Me.btnSaveFileFromRxBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveFileFromRxBox.Image = Global.comTerm.My.Resources.Resources.Disk_download
        Me.btnSaveFileFromRxBox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveFileFromRxBox.Name = "btnSaveFileFromRxBox"
        Me.btnSaveFileFromRxBox.Size = New System.Drawing.Size(23, 22)
        Me.btnSaveFileFromRxBox.ToolTipText = "save output to textfile"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'lblRxCnt
        '
        Me.lblRxCnt.Name = "lblRxCnt"
        Me.lblRxCnt.Size = New System.Drawing.Size(37, 22)
        Me.lblRxCnt.Text = "00000"
        Me.lblRxCnt.ToolTipText = "count bytes received"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'statusRX
        '
        Me.statusRX.AutoSize = False
        Me.statusRX.Image = Global.comTerm.My.Resources.Resources.ledGray
        Me.statusRX.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.statusRX.Name = "statusRX"
        Me.statusRX.Size = New System.Drawing.Size(53, 22)
        Me.statusRX.Text = "status"
        Me.statusRX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.statusRX.ToolTipText = "receive status"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'chkAddCR
        '
        Me.chkAddCR.AutoSize = True
        Me.chkAddCR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkAddCR.Location = New System.Drawing.Point(599, 28)
        Me.chkAddCR.Name = "chkAddCR"
        Me.chkAddCR.Size = New System.Drawing.Size(39, 17)
        Me.chkAddCR.TabIndex = 7
        Me.chkAddCR.Text = "CR"
        Me.ToolTip1.SetToolTip(Me.chkAddCR, "add CR")
        Me.chkAddCR.UseVisualStyleBackColor = True
        '
        'chkAddLF
        '
        Me.chkAddLF.AutoSize = True
        Me.chkAddLF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkAddLF.Location = New System.Drawing.Point(559, 28)
        Me.chkAddLF.Name = "chkAddLF"
        Me.chkAddLF.Size = New System.Drawing.Size(36, 17)
        Me.chkAddLF.TabIndex = 6
        Me.chkAddLF.Text = "LF"
        Me.ToolTip1.SetToolTip(Me.chkAddLF, "add LF")
        Me.chkAddLF.UseVisualStyleBackColor = True
        '
        'chkTxEnterHex
        '
        Me.chkTxEnterHex.AutoSize = True
        Me.chkTxEnterHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkTxEnterHex.Location = New System.Drawing.Point(244, 3)
        Me.chkTxEnterHex.Name = "chkTxEnterHex"
        Me.chkTxEnterHex.Size = New System.Drawing.Size(73, 17)
        Me.chkTxEnterHex.TabIndex = 5
        Me.chkTxEnterHex.Text = "enter HEX"
        Me.ToolTip1.SetToolTip(Me.chkTxEnterHex, "enter mode HEX")
        Me.chkTxEnterHex.UseVisualStyleBackColor = True
        '
        'rtbTX
        '
        Me.rtbTX.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rtbTX.ContextMenuStrip = Me.mnuTxBox
        Me.rtbTX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbTX.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTX.Location = New System.Drawing.Point(0, 50)
        Me.rtbTX.Name = "rtbTX"
        Me.rtbTX.Size = New System.Drawing.Size(744, 109)
        Me.rtbTX.TabIndex = 4
        Me.rtbTX.Text = "*"
        Me.ToolTip1.SetToolTip(Me.rtbTX, "press right mouse button" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "left: line into send box")
        Me.rtbTX.WordWrap = False
        '
        'mnuTxBox
        '
        Me.mnuTxBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyTx, Me.PasteTx, Me.CutTx, Me.SendLine, Me.SendSelect})
        Me.mnuTxBox.Name = "MenuTxBox"
        Me.mnuTxBox.Size = New System.Drawing.Size(150, 114)
        '
        'CopyTx
        '
        Me.CopyTx.Image = Global.comTerm.My.Resources.Resources.Copy
        Me.CopyTx.Name = "CopyTx"
        Me.CopyTx.Size = New System.Drawing.Size(149, 22)
        Me.CopyTx.Text = "Copy"
        '
        'PasteTx
        '
        Me.PasteTx.Image = Global.comTerm.My.Resources.Resources.Paste
        Me.PasteTx.Name = "PasteTx"
        Me.PasteTx.Size = New System.Drawing.Size(149, 22)
        Me.PasteTx.Text = "Paste"
        '
        'CutTx
        '
        Me.CutTx.Image = Global.comTerm.My.Resources.Resources.Clipboard_Cut
        Me.CutTx.Name = "CutTx"
        Me.CutTx.Size = New System.Drawing.Size(149, 22)
        Me.CutTx.Text = "Cut"
        '
        'SendLine
        '
        Me.SendLine.Image = Global.comTerm.My.Resources.Resources.Arrow1_Right
        Me.SendLine.Name = "SendLine"
        Me.SendLine.Size = New System.Drawing.Size(149, 22)
        Me.SendLine.Text = "send line"
        '
        'SendSelect
        '
        Me.SendSelect.Image = Global.comTerm.My.Resources.Resources.Arrow2_Right
        Me.SendSelect.Name = "SendSelect"
        Me.SendSelect.Size = New System.Drawing.Size(149, 22)
        Me.SendSelect.Text = "send selection"
        '
        'toolstripSend
        '
        Me.toolstripSend.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboEnterMessage})
        Me.toolstripSend.Location = New System.Drawing.Point(0, 25)
        Me.toolstripSend.Name = "toolstripSend"
        Me.toolstripSend.Size = New System.Drawing.Size(744, 25)
        Me.toolstripSend.TabIndex = 3
        Me.toolstripSend.Text = "ToolStrip1"
        '
        'cboEnterMessage
        '
        Me.cboEnterMessage.Name = "cboEnterMessage"
        Me.cboEnterMessage.Size = New System.Drawing.Size(530, 25)
        Me.cboEnterMessage.Text = "enter message to sent here and type<enter>"
        Me.cboEnterMessage.ToolTipText = "enter message here and type<enter>"
        '
        'chkTxShowHex
        '
        Me.chkTxShowHex.AutoSize = True
        Me.chkTxShowHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkTxShowHex.Location = New System.Drawing.Point(330, 3)
        Me.chkTxShowHex.Name = "chkTxShowHex"
        Me.chkTxShowHex.Size = New System.Drawing.Size(71, 17)
        Me.chkTxShowHex.TabIndex = 2
        Me.chkTxShowHex.Text = "show Hex"
        Me.ToolTip1.SetToolTip(Me.chkTxShowHex, "show HEX")
        Me.chkTxShowHex.UseVisualStyleBackColor = True
        '
        'chkTxShowAscii
        '
        Me.chkTxShowAscii.AutoSize = True
        Me.chkTxShowAscii.Checked = True
        Me.chkTxShowAscii.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTxShowAscii.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkTxShowAscii.Location = New System.Drawing.Point(410, 3)
        Me.chkTxShowAscii.Name = "chkTxShowAscii"
        Me.chkTxShowAscii.Size = New System.Drawing.Size(79, 17)
        Me.chkTxShowAscii.TabIndex = 1
        Me.chkTxShowAscii.Text = "show ASCII"
        Me.ToolTip1.SetToolTip(Me.chkTxShowAscii, "show ascii")
        Me.chkTxShowAscii.UseVisualStyleBackColor = True
        '
        'toolstripTX
        '
        Me.toolstripTX.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Label2, Me.ToolStripSeparator1, Me.btnClearTxBox, Me.ToolStripSeparator4, Me.btnLoadFileToTxBox, Me.ToolStripSeparator6, Me.lblTxCnt, Me.ToolStripSeparator7, Me.statusTX, Me.ToolStripSeparator12})
        Me.toolstripTX.Location = New System.Drawing.Point(0, 0)
        Me.toolstripTX.Name = "toolstripTX"
        Me.toolstripTX.Size = New System.Drawing.Size(744, 25)
        Me.toolstripTX.TabIndex = 0
        Me.toolstripTX.Text = "ToolStrip3"
        '
        'Label2
        '
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 22)
        Me.Label2.Text = "Transmit box"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnClearTxBox
        '
        Me.btnClearTxBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClearTxBox.Image = Global.comTerm.My.Resources.Resources.Doc_Del
        Me.btnClearTxBox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClearTxBox.Name = "btnClearTxBox"
        Me.btnClearTxBox.Size = New System.Drawing.Size(23, 22)
        Me.btnClearTxBox.ToolTipText = "Clear transmit box"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnLoadFileToTxBox
        '
        Me.btnLoadFileToTxBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLoadFileToTxBox.Image = Global.comTerm.My.Resources.Resources.Disk
        Me.btnLoadFileToTxBox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoadFileToTxBox.Name = "btnLoadFileToTxBox"
        Me.btnLoadFileToTxBox.Size = New System.Drawing.Size(23, 22)
        Me.btnLoadFileToTxBox.ToolTipText = "load file into box"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'lblTxCnt
        '
        Me.lblTxCnt.Name = "lblTxCnt"
        Me.lblTxCnt.Size = New System.Drawing.Size(37, 22)
        Me.lblTxCnt.Text = "00000"
        Me.lblTxCnt.ToolTipText = "count sent bytes"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'statusTX
        '
        Me.statusTX.AutoSize = False
        Me.statusTX.Image = Global.comTerm.My.Resources.Resources.ledGray
        Me.statusTX.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.statusTX.Name = "statusTX"
        Me.statusTX.Size = New System.Drawing.Size(53, 22)
        Me.statusTX.Text = "status"
        Me.statusTX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.statusTX.ToolTipText = "send status"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 506)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Status1)
        Me.Controls.Add(Me.toolstripComPort)
        Me.Controls.Add(Me.Menu1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.Menu1
        Me.MinimumSize = New System.Drawing.Size(716, 250)
        Me.Name = "frmMain"
        Me.Text = "Ellen's terminal II   2011 - 2012 -"
        Me.toolstripComPort.ResumeLayout(False)
        Me.toolstripComPort.PerformLayout()
        Me.Status1.ResumeLayout(False)
        Me.Status1.PerformLayout()
        Me.Menu1.ResumeLayout(False)
        Me.Menu1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.toolstripRX.ResumeLayout(False)
        Me.toolstripRX.PerformLayout()
        Me.mnuTxBox.ResumeLayout(False)
        Me.toolstripSend.ResumeLayout(False)
        Me.toolstripSend.PerformLayout()
        Me.toolstripTX.ResumeLayout(False)
        Me.toolstripTX.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents toolstripComPort As System.Windows.Forms.ToolStrip
    Friend WithEvents Status1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Menu1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReceiveboxFontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents toolstripRX As System.Windows.Forms.ToolStrip
    Friend WithEvents Label1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolstripTX As System.Windows.Forms.ToolStrip
    Friend WithEvents Label2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnClearTxBox As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClearReceiveBox As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkTxShowHex As System.Windows.Forms.CheckBox
    Friend WithEvents chkTxShowAscii As System.Windows.Forms.CheckBox
    Friend WithEvents btnLoadFileToTxBox As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblTxCnt As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkRxShowAscii As System.Windows.Forms.CheckBox
    Friend WithEvents btnSaveFileFromRxBox As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblRxCnt As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkRxShowHex As System.Windows.Forms.CheckBox
    Friend WithEvents statusRX As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents statusTX As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents rtbRX As System.Windows.Forms.RichTextBox
    Friend WithEvents toolstripSend As System.Windows.Forms.ToolStrip
    Friend WithEvents cboEnterMessage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents rtbTX As System.Windows.Forms.RichTextBox
    Friend WithEvents status0 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents label10 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboComPort As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents label11 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboBaudrate As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Label12 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboParity As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Label13 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboStopbits As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents statusC As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LargeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkTxEnterHex As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents mnuTxBox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyTx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteTx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutTx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkAddLF As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddCR As System.Windows.Forms.CheckBox
    Friend WithEvents Label30 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboDataBits As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents SendLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboDelay As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboThreshold As System.Windows.Forms.ToolStripComboBox

End Class
