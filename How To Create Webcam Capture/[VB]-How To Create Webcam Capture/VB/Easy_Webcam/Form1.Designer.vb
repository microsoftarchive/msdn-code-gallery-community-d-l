<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lst1 = New System.Windows.Forms.ListBox
        Me.pView = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmd3 = New System.Windows.Forms.Button
        Me.cmd2 = New System.Windows.Forms.Button
        Me.cmd1 = New System.Windows.Forms.Button
        Me.opt1 = New System.Windows.Forms.RadioButton
        Me.opt2 = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.sfdImages = New System.Windows.Forms.SaveFileDialog
        Me.opt3 = New System.Windows.Forms.RadioButton
        Me.opt4 = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.pView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Easy Webcam"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lst1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(545, 92)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Webcam"
        '
        'lst1
        '
        Me.lst1.FormattingEnabled = True
        Me.lst1.ItemHeight = 17
        Me.lst1.Location = New System.Drawing.Point(16, 24)
        Me.lst1.Name = "lst1"
        Me.lst1.Size = New System.Drawing.Size(522, 55)
        Me.lst1.TabIndex = 0
        '
        'pView
        '
        Me.pView.Location = New System.Drawing.Point(16, 131)
        Me.pView.Name = "pView"
        Me.pView.Size = New System.Drawing.Size(234, 200)
        Me.pView.TabIndex = 2
        Me.pView.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmd3)
        Me.GroupBox2.Controls.Add(Me.cmd2)
        Me.GroupBox2.Controls.Add(Me.cmd1)
        Me.GroupBox2.Location = New System.Drawing.Point(256, 246)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 65)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Main Control"
        '
        'cmd3
        '
        Me.cmd3.Location = New System.Drawing.Point(206, 20)
        Me.cmd3.Name = "cmd3"
        Me.cmd3.Size = New System.Drawing.Size(92, 36)
        Me.cmd3.TabIndex = 7
        Me.cmd3.Text = "S&ave"
        Me.cmd3.UseVisualStyleBackColor = True
        '
        'cmd2
        '
        Me.cmd2.Location = New System.Drawing.Point(108, 20)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(92, 36)
        Me.cmd2.TabIndex = 6
        Me.cmd2.Text = "&Stop"
        Me.cmd2.UseVisualStyleBackColor = True
        '
        'cmd1
        '
        Me.cmd1.Location = New System.Drawing.Point(10, 20)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(92, 36)
        Me.cmd1.TabIndex = 5
        Me.cmd1.Text = "&Capture"
        Me.cmd1.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.AutoSize = True
        Me.opt1.Location = New System.Drawing.Point(338, 191)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(61, 21)
        Me.opt1.TabIndex = 2
        Me.opt1.TabStop = True
        Me.opt1.Text = "&Invert"
        Me.opt1.UseVisualStyleBackColor = True
        '
        'opt2
        '
        Me.opt2.AutoSize = True
        Me.opt2.Location = New System.Drawing.Point(266, 191)
        Me.opt2.Name = "opt2"
        Me.opt2.Size = New System.Drawing.Size(70, 21)
        Me.opt2.TabIndex = 1
        Me.opt2.TabStop = True
        Me.opt2.Text = "&Normal"
        Me.opt2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.Location = New System.Drawing.Point(256, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(305, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Graphics Effect"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'opt3
        '
        Me.opt3.AutoSize = True
        Me.opt3.Location = New System.Drawing.Point(397, 191)
        Me.opt3.Name = "opt3"
        Me.opt3.Size = New System.Drawing.Size(85, 21)
        Me.opt3.TabIndex = 3
        Me.opt3.TabStop = True
        Me.opt3.Text = "&Grayscale"
        Me.opt3.UseVisualStyleBackColor = True
        '
        'opt4
        '
        Me.opt4.AutoSize = True
        Me.opt4.Location = New System.Drawing.Point(479, 191)
        Me.opt4.Name = "opt4"
        Me.opt4.Size = New System.Drawing.Size(83, 21)
        Me.opt4.TabIndex = 4
        Me.opt4.TabStop = True
        Me.opt4.Text = "Infra &Red"
        Me.opt4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(253, 314)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(308, 26)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Copyright (C) 2011, Albert Sandro Mamu"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(568, 340)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.opt4)
        Me.Controls.Add(Me.opt3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.opt2)
        Me.Controls.Add(Me.opt1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pView)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easy Webcam"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lst1 As System.Windows.Forms.ListBox
    Friend WithEvents pView As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd2 As System.Windows.Forms.Button
    Friend WithEvents cmd1 As System.Windows.Forms.Button
    Friend WithEvents cmd3 As System.Windows.Forms.Button
    Friend WithEvents opt1 As System.Windows.Forms.RadioButton
    Friend WithEvents opt2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents sfdImages As System.Windows.Forms.SaveFileDialog
    Friend WithEvents opt3 As System.Windows.Forms.RadioButton
    Friend WithEvents opt4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
