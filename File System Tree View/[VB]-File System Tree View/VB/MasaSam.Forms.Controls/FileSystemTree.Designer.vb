<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSystemTree
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileSystemTree))
        Me.tvFiles = New System.Windows.Forms.TreeView()
        Me.imageListIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'tvFiles
        '
        Me.tvFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvFiles.ImageIndex = 0
        Me.tvFiles.ImageList = Me.imageListIcons
        Me.tvFiles.Location = New System.Drawing.Point(0, 0)
        Me.tvFiles.Name = "tvFiles"
        Me.tvFiles.SelectedImageIndex = 0
        Me.tvFiles.ShowNodeToolTips = True
        Me.tvFiles.Size = New System.Drawing.Size(176, 234)
        Me.tvFiles.TabIndex = 0
        '
        'imageListIcons
        '
        Me.imageListIcons.ImageStream = CType(resources.GetObject("imageListIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageListIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imageListIcons.Images.SetKeyName(0, "computer.png")
        Me.imageListIcons.Images.SetKeyName(1, "drive.png")
        Me.imageListIcons.Images.SetKeyName(2, "drive_cd.png")
        Me.imageListIcons.Images.SetKeyName(3, "drive_cd_empty.png")
        Me.imageListIcons.Images.SetKeyName(4, "drive_network.png")
        Me.imageListIcons.Images.SetKeyName(5, "file.png")
        Me.imageListIcons.Images.SetKeyName(6, "file_archive.png")
        Me.imageListIcons.Images.SetKeyName(7, "file_excel.png")
        Me.imageListIcons.Images.SetKeyName(8, "file_image.png")
        Me.imageListIcons.Images.SetKeyName(9, "file_music.png")
        Me.imageListIcons.Images.SetKeyName(10, "file_powerpoint.png")
        Me.imageListIcons.Images.SetKeyName(11, "file_setting.png")
        Me.imageListIcons.Images.SetKeyName(12, "file_text.png")
        Me.imageListIcons.Images.SetKeyName(13, "file_word.png")
        Me.imageListIcons.Images.SetKeyName(14, "folder.png")
        '
        'FileSystemTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tvFiles)
        Me.Name = "FileSystemTree"
        Me.Size = New System.Drawing.Size(176, 234)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvFiles As System.Windows.Forms.TreeView
    Friend WithEvents imageListIcons As System.Windows.Forms.ImageList

End Class
