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
        Me.ctlDriveListBox = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox()
        Me.ctlFolderList = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox()
        Me.ctlFileList = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox()
        Me.ctlPicture = New System.Windows.Forms.PictureBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnConvert = New System.Windows.Forms.Button()
        CType(Me.ctlPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ctlDriveListBox
        '
        Me.ctlDriveListBox.FormattingEnabled = True
        Me.ctlDriveListBox.Location = New System.Drawing.Point(12, 12)
        Me.ctlDriveListBox.Name = "ctlDriveListBox"
        Me.ctlDriveListBox.Size = New System.Drawing.Size(276, 21)
        Me.ctlDriveListBox.TabIndex = 0
        '
        'ctlFolderList
        '
        Me.ctlFolderList.FormattingEnabled = True
        Me.ctlFolderList.IntegralHeight = False
        Me.ctlFolderList.Location = New System.Drawing.Point(13, 40)
        Me.ctlFolderList.Name = "ctlFolderList"
        Me.ctlFolderList.Size = New System.Drawing.Size(275, 444)
        Me.ctlFolderList.TabIndex = 1
        '
        'ctlFileList
        '
        Me.ctlFileList.FormattingEnabled = True
        Me.ctlFileList.Location = New System.Drawing.Point(294, 12)
        Me.ctlFileList.Name = "ctlFileList"
        Me.ctlFileList.Pattern = "*.bmp"
        Me.ctlFileList.Size = New System.Drawing.Size(246, 472)
        Me.ctlFileList.TabIndex = 2
        '
        'ctlPicture
        '
        Me.ctlPicture.Location = New System.Drawing.Point(546, 62)
        Me.ctlPicture.Name = "ctlPicture"
        Me.ctlPicture.Size = New System.Drawing.Size(381, 241)
        Me.ctlPicture.TabIndex = 3
        Me.ctlPicture.TabStop = False
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(563, 20)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(0, 13)
        Me.lblLocation.TabIndex = 4
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"JPEG", "PNG", "GIF"})
        Me.ComboBox1.Location = New System.Drawing.Point(547, 320)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(236, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(789, 318)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(138, 23)
        Me.btnConvert.TabIndex = 6
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 499)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.ctlPicture)
        Me.Controls.Add(Me.ctlFileList)
        Me.Controls.Add(Me.ctlFolderList)
        Me.Controls.Add(Me.ctlDriveListBox)
        Me.Name = "Form1"
        Me.Text = "Image Converter Sample"
        CType(Me.ctlPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ctlDriveListBox As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
    Friend WithEvents ctlFolderList As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
    Friend WithEvents ctlFileList As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
    Friend WithEvents ctlPicture As System.Windows.Forms.PictureBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnConvert As System.Windows.Forms.Button

End Class
