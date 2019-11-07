<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoNotepad = New System.Windows.Forms.RadioButton()
        Me.rdoApp = New System.Windows.Forms.RadioButton()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label2 = New System.Windows.Forms.Label()
        Me.pnlNotepad = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNotepadTextWrite = New System.Windows.Forms.Button()
        Me.btnNotepadTextread = New System.Windows.Forms.Button()
        Me.txtNotepadWrite = New System.Windows.Forms.TextBox()
        Me.txtNotepadread = New System.Windows.Forms.TextBox()
        Me.BTNReadTEXT = New System.Windows.Forms.Button()
        Me.pnlApplication = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblControlID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAppWrite = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ClassNames = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Control_IDs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Texts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAppWrite = New System.Windows.Forms.Button()
        Me.btnAppRead = New System.Windows.Forms.Button()
        Me.txtAppread = New System.Windows.Forms.TextBox()
        Me.groupBox1.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.pnlNotepad.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlApplication.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(128, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(453, 32)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Enter External Program Title "
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(9, 60)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTitle.Multiline = True
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(572, 59)
        Me.txtTitle.TabIndex = 1
        Me.txtTitle.Text = "SHANUEPTR.txt - 메모장"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rdoNotepad)
        Me.groupBox1.Controls.Add(Me.rdoApp)
        Me.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.groupBox1.Location = New System.Drawing.Point(597, 10)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.groupBox1.Size = New System.Drawing.Size(182, 120)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Application Type"
        '
        'rdoNotepad
        '
        Me.rdoNotepad.AutoSize = True
        Me.rdoNotepad.Checked = True
        Me.rdoNotepad.Location = New System.Drawing.Point(27, 40)
        Me.rdoNotepad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdoNotepad.Name = "rdoNotepad"
        Me.rdoNotepad.Size = New System.Drawing.Size(82, 19)
        Me.rdoNotepad.TabIndex = 1
        Me.rdoNotepad.TabStop = True
        Me.rdoNotepad.Text = "Notepad"
        Me.rdoNotepad.UseVisualStyleBackColor = True
        '
        'rdoApp
        '
        Me.rdoApp.AutoSize = True
        Me.rdoApp.Location = New System.Drawing.Point(27, 70)
        Me.rdoApp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdoApp.Name = "rdoApp"
        Me.rdoApp.Size = New System.Drawing.Size(140, 19)
        Me.rdoApp.TabIndex = 0
        Me.rdoApp.Text = "External Program"
        Me.rdoApp.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel1.Controls.Add(Me.groupBox1)
        Me.panel1.Controls.Add(Me.txtTitle)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Location = New System.Drawing.Point(11, 10)
        Me.panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(796, 139)
        Me.panel1.TabIndex = 3
        '
        'label2
        '
        Me.label2.AllowDrop = True
        Me.label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.DarkRed
        Me.label2.Location = New System.Drawing.Point(27, 160)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(942, 50)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Note :  Enter the same External program Main Title Name as  same as in external p" &
    "rogram.It might be Any external program like our own .net or notepad or any othe" &
    "r application."
        '
        'pnlNotepad
        '
        Me.pnlNotepad.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.pnlNotepad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlNotepad.Controls.Add(Me.GroupBox2)
        Me.pnlNotepad.Location = New System.Drawing.Point(13, 220)
        Me.pnlNotepad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlNotepad.Name = "pnlNotepad"
        Me.pnlNotepad.Size = New System.Drawing.Size(1043, 601)
        Me.pnlNotepad.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnNotepadTextWrite)
        Me.GroupBox2.Controls.Add(Me.btnNotepadTextread)
        Me.GroupBox2.Controls.Add(Me.txtNotepadWrite)
        Me.GroupBox2.Controls.Add(Me.txtNotepadread)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(-9, 10)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1089, 648)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "  NotePad Text      READ/EDIT    "
        '
        'btnNotepadTextWrite
        '
        Me.btnNotepadTextWrite.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotepadTextWrite.ForeColor = System.Drawing.Color.OrangeRed
        Me.btnNotepadTextWrite.Location = New System.Drawing.Point(769, 390)
        Me.btnNotepadTextWrite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNotepadTextWrite.Name = "btnNotepadTextWrite"
        Me.btnNotepadTextWrite.Size = New System.Drawing.Size(251, 160)
        Me.btnNotepadTextWrite.TabIndex = 8
        Me.btnNotepadTextWrite.Text = "Write to Notepad "
        Me.btnNotepadTextWrite.UseVisualStyleBackColor = True
        '
        'btnNotepadTextread
        '
        Me.btnNotepadTextread.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotepadTextread.ForeColor = System.Drawing.Color.OliveDrab
        Me.btnNotepadTextread.Location = New System.Drawing.Point(769, 109)
        Me.btnNotepadTextread.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNotepadTextread.Name = "btnNotepadTextread"
        Me.btnNotepadTextread.Size = New System.Drawing.Size(250, 200)
        Me.btnNotepadTextread.TabIndex = 7
        Me.btnNotepadTextread.Text = "READ Notepad TEXT"
        Me.btnNotepadTextread.UseVisualStyleBackColor = True
        '
        'txtNotepadWrite
        '
        Me.txtNotepadWrite.Location = New System.Drawing.Point(23, 359)
        Me.txtNotepadWrite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNotepadWrite.Multiline = True
        Me.txtNotepadWrite.Name = "txtNotepadWrite"
        Me.txtNotepadWrite.Size = New System.Drawing.Size(732, 219)
        Me.txtNotepadWrite.TabIndex = 3
        '
        'txtNotepadread
        '
        Me.txtNotepadread.AllowDrop = True
        Me.txtNotepadread.Location = New System.Drawing.Point(23, 29)
        Me.txtNotepadread.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNotepadread.Multiline = True
        Me.txtNotepadread.Name = "txtNotepadread"
        Me.txtNotepadread.ReadOnly = True
        Me.txtNotepadread.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotepadread.Size = New System.Drawing.Size(736, 319)
        Me.txtNotepadread.TabIndex = 2
        '
        'BTNReadTEXT
        '
        Me.BTNReadTEXT.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNReadTEXT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.BTNReadTEXT.Location = New System.Drawing.Point(815, 22)
        Me.BTNReadTEXT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNReadTEXT.Name = "BTNReadTEXT"
        Me.BTNReadTEXT.Size = New System.Drawing.Size(243, 120)
        Me.BTNReadTEXT.TabIndex = 6
        Me.BTNReadTEXT.Text = "Load External Program"
        Me.BTNReadTEXT.UseVisualStyleBackColor = True
        '
        'pnlApplication
        '
        Me.pnlApplication.BackColor = System.Drawing.Color.BurlyWood
        Me.pnlApplication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlApplication.Controls.Add(Me.GroupBox3)
        Me.pnlApplication.Location = New System.Drawing.Point(13, 220)
        Me.pnlApplication.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlApplication.Name = "pnlApplication"
        Me.pnlApplication.Size = New System.Drawing.Size(1039, 601)
        Me.pnlApplication.TabIndex = 6
        Me.pnlApplication.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.lblControlID)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtAppWrite)
        Me.GroupBox3.Controls.Add(Me.ListView1)
        Me.GroupBox3.Controls.Add(Me.btnAppWrite)
        Me.GroupBox3.Controls.Add(Me.btnAppRead)
        Me.GroupBox3.Controls.Add(Me.txtAppread)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(-9, 10)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(1052, 740)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "        Application Text Read          "
        '
        'lblControlID
        '
        Me.lblControlID.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControlID.ForeColor = System.Drawing.Color.White
        Me.lblControlID.Location = New System.Drawing.Point(933, 710)
        Me.lblControlID.Name = "lblControlID"
        Me.lblControlID.Size = New System.Drawing.Size(311, 20)
        Me.lblControlID.TabIndex = 16
        Me.lblControlID.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(812, 286)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 50)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Selected Editbox content can be updated."
        '
        'txtAppWrite
        '
        Me.txtAppWrite.Location = New System.Drawing.Point(812, 336)
        Me.txtAppWrite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAppWrite.Multiline = True
        Me.txtAppWrite.Name = "txtAppWrite"
        Me.txtAppWrite.Size = New System.Drawing.Size(229, 109)
        Me.txtAppWrite.TabIndex = 14
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.AutoArrange = False
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClassNames, Me.Control_IDs, Me.Texts})
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(18, 20)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(788, 561)
        Me.ListView1.TabIndex = 13
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ClassNames
        '
        Me.ClassNames.Text = "Class name"
        Me.ClassNames.Width = 340
        '
        'Control_IDs
        '
        Me.Control_IDs.Text = "Control_ID"
        Me.Control_IDs.Width = 90
        '
        'Texts
        '
        Me.Texts.Text = "Text"
        Me.Texts.Width = 320
        '
        'btnAppWrite
        '
        Me.btnAppWrite.Font = New System.Drawing.Font("Verdana", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAppWrite.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnAppWrite.Location = New System.Drawing.Point(812, 463)
        Me.btnAppWrite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAppWrite.Name = "btnAppWrite"
        Me.btnAppWrite.Size = New System.Drawing.Size(229, 118)
        Me.btnAppWrite.TabIndex = 8
        Me.btnAppWrite.Text = "Write to External Program Text"
        Me.btnAppWrite.UseVisualStyleBackColor = True
        '
        'btnAppRead
        '
        Me.btnAppRead.Font = New System.Drawing.Font("Verdana", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAppRead.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnAppRead.Location = New System.Drawing.Point(814, 20)
        Me.btnAppRead.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAppRead.Name = "btnAppRead"
        Me.btnAppRead.Size = New System.Drawing.Size(227, 132)
        Me.btnAppRead.TabIndex = 7
        Me.btnAppRead.Text = "READ External Program Text"
        Me.btnAppRead.UseVisualStyleBackColor = False
        '
        'txtAppread
        '
        Me.txtAppread.Location = New System.Drawing.Point(812, 163)
        Me.txtAppread.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAppread.Multiline = True
        Me.txtAppread.Name = "txtAppread"
        Me.txtAppread.ReadOnly = True
        Me.txtAppread.Size = New System.Drawing.Size(229, 109)
        Me.txtAppread.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1069, 839)
        Me.Controls.Add(Me.BTNReadTEXT)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.pnlApplication)
        Me.Controls.Add(Me.pnlNotepad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Form1"
        Me.Text = "SHANU   E   P    T    C  (External program Text Read)"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.pnlNotepad.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlApplication.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtTitle As System.Windows.Forms.TextBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents rdoNotepad As System.Windows.Forms.RadioButton
    Private WithEvents rdoApp As System.Windows.Forms.RadioButton
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents pnlNotepad As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNotepadTextWrite As System.Windows.Forms.Button
    Friend WithEvents btnNotepadTextread As System.Windows.Forms.Button
    Private WithEvents txtNotepadWrite As System.Windows.Forms.TextBox
    Private WithEvents txtNotepadread As System.Windows.Forms.TextBox
    Friend WithEvents BTNReadTEXT As System.Windows.Forms.Button
    Friend WithEvents pnlApplication As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAppWrite As System.Windows.Forms.Button
    Friend WithEvents btnAppRead As System.Windows.Forms.Button
    Private WithEvents txtAppread As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ClassNames As System.Windows.Forms.ColumnHeader
    Friend WithEvents Control_IDs As System.Windows.Forms.ColumnHeader
    Friend WithEvents Texts As System.Windows.Forms.ColumnHeader
    Private WithEvents txtAppWrite As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents lblControlID As System.Windows.Forms.Label

End Class
