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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.trackBar1 = New System.Windows.Forms.TrackBar()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioButton2 = New System.Windows.Forms.RadioButton()
        Me.radioButton1 = New System.Windows.Forms.RadioButton()
        CType(Me.trackBar1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mode: Trial version"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 89)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Generate demo file"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Enabled = false
        Me.Button2.Location = New System.Drawing.Point(194, 118)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Export to Excel"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(293, 44)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "File generated"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(194, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Set License"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = true
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 377)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(276, 13)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = true
        Me.LinkLabel1.Text = "To get a temporary license, please go to Aspose website."
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = true
        Me.CheckBox1.Location = New System.Drawing.Point(12, 310)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(149, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Insert blank column at first"
        Me.CheckBox1.UseVisualStyleBackColor = true
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = true
        Me.CheckBox2.Location = New System.Drawing.Point(12, 333)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(223, 17)
        Me.CheckBox2.TabIndex = 7
        Me.CheckBox2.Text = "Each PDF page as separated worksheets"
        Me.CheckBox2.UseVisualStyleBackColor = true
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(194, 89)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Open PDF File"
        Me.Button4.UseVisualStyleBackColor = true
        '
        'label3
        '
        Me.label3.AutoSize = true
        Me.label3.Location = New System.Drawing.Point(13, 207)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(97, 13)
        Me.label3.TabIndex = 14
        Me.label3.Text = "Scale Factor:  0.90"
        '
        'trackBar1
        '
        Me.trackBar1.LargeChange = 10
        Me.trackBar1.Location = New System.Drawing.Point(16, 236)
        Me.trackBar1.Maximum = 100
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(294, 45)
        Me.trackBar1.SmallChange = 2
        Me.trackBar1.TabIndex = 13
        Me.trackBar1.TickFrequency = 2
        Me.trackBar1.Value = 90
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.radioButton2)
        Me.groupBox1.Controls.Add(Me.radioButton1)
        Me.groupBox1.Location = New System.Drawing.Point(16, 147)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(293, 48)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = false
        Me.groupBox1.Text = "Save Format:"
        '
        'radioButton2
        '
        Me.radioButton2.AutoSize = true
        Me.radioButton2.Location = New System.Drawing.Point(152, 20)
        Me.radioButton2.Name = "radioButton2"
        Me.radioButton2.Size = New System.Drawing.Size(134, 17)
        Me.radioButton2.TabIndex = 1
        Me.radioButton2.TabStop = true
        Me.radioButton2.Text = "Excel 2007 Workbook "
        Me.radioButton2.UseVisualStyleBackColor = true
        '
        'radioButton1
        '
        Me.radioButton1.AutoSize = true
        Me.radioButton1.Checked = true
        Me.radioButton1.Location = New System.Drawing.Point(7, 20)
        Me.radioButton1.Name = "radioButton1"
        Me.radioButton1.Size = New System.Drawing.Size(139, 17)
        Me.radioButton1.TabIndex = 0
        Me.radioButton1.TabStop = true
        Me.radioButton1.Text = "Excel XML Spreadsheet"
        Me.radioButton1.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 366)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.trackBar1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.Name = "Form1"
        Me.Text = "Aspose.PDF2Excel Demo"
        CType(Me.trackBar1,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Button4 As Button
    Private WithEvents label3 As Label
    Private WithEvents trackBar1 As TrackBar
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents radioButton2 As RadioButton
    Private WithEvents radioButton1 As RadioButton
End Class
