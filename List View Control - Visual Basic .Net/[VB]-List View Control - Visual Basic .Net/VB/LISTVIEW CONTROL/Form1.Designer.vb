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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImgLargeIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ImgSmallIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ListView4 = New System.Windows.Forms.ListView()
        Me.ImgTitle = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.ListView5 = New System.Windows.Forms.ListView()
        Me.ImgDetails = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(3, 111)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(665, 348)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.ImageKey = "1381922708_131867.ico"
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(657, 321)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "LargeIcon"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.LargeImageList = Me.ImgLargeIcon
        Me.ListView1.Location = New System.Drawing.Point(6, 6)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(645, 297)
        Me.ListView1.SmallImageList = Me.ImgLargeIcon
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImgLargeIcon
        '
        Me.ImgLargeIcon.ImageStream = CType(resources.GetObject("ImgLargeIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLargeIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLargeIcon.Images.SetKeyName(0, "1381922821_131919.ico")
        Me.ImgLargeIcon.Images.SetKeyName(1, "1381922355_131802.ico")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.ImageKey = "1381922589_131905.ico"
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(657, 321)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Small Icon"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ListView3)
        Me.TabPage3.ImageKey = "1381922420_131719.ico"
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(657, 321)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "List"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(146, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(415, 56)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "List View Control"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(192, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(298, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Basic Understanding Listview Control"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1381922708_131867.ico")
        Me.ImageList1.Images.SetKeyName(1, "1381922420_131719.ico")
        Me.ImageList1.Images.SetKeyName(2, "1381922660_131711.ico")
        Me.ImageList1.Images.SetKeyName(3, "1381922589_131905.ico")
        Me.ImageList1.Images.SetKeyName(4, "1381922686_131692.ico")
        '
        'ListView2
        '
        Me.ListView2.LargeImageList = Me.ImgLargeIcon
        Me.ListView2.Location = New System.Drawing.Point(6, 12)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(645, 297)
        Me.ListView2.SmallImageList = Me.ImgSmallIcon
        Me.ListView2.TabIndex = 1
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.SmallIcon
        '
        'ImgSmallIcon
        '
        Me.ImgSmallIcon.ImageStream = CType(resources.GetObject("ImgSmallIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgSmallIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgSmallIcon.Images.SetKeyName(0, "1381922821_131919.ico")
        Me.ImgSmallIcon.Images.SetKeyName(1, "1381922355_131802.ico")
        '
        'ListView3
        '
        Me.ListView3.LargeImageList = Me.ImgList
        Me.ListView3.Location = New System.Drawing.Point(6, 12)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(645, 297)
        Me.ListView3.SmallImageList = Me.ImgList
        Me.ListView3.TabIndex = 2
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.List
        '
        'ImgList
        '
        Me.ImgList.ImageStream = CType(resources.GetObject("ImgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgList.Images.SetKeyName(0, "1381922821_131919.ico")
        Me.ImgList.Images.SetKeyName(1, "1381922355_131802.ico")
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ListView4)
        Me.TabPage4.ImageKey = "1381922660_131711.ico"
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(657, 321)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Title"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ListView4
        '
        Me.ListView4.LargeImageList = Me.ImgTitle
        Me.ListView4.Location = New System.Drawing.Point(6, 12)
        Me.ListView4.Name = "ListView4"
        Me.ListView4.Size = New System.Drawing.Size(645, 297)
        Me.ListView4.SmallImageList = Me.ImgTitle
        Me.ListView4.TabIndex = 3
        Me.ListView4.UseCompatibleStateImageBehavior = False
        Me.ListView4.View = System.Windows.Forms.View.Tile
        '
        'ImgTitle
        '
        Me.ImgTitle.ImageStream = CType(resources.GetObject("ImgTitle.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgTitle.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgTitle.Images.SetKeyName(0, "1381922821_131919.ico")
        Me.ImgTitle.Images.SetKeyName(1, "1381922355_131802.ico")
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.ListView5)
        Me.TabPage5.ImageKey = "1381922686_131692.ico"
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(657, 321)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Details"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'ListView5
        '
        Me.ListView5.LargeImageList = Me.ImgDetails
        Me.ListView5.Location = New System.Drawing.Point(6, 12)
        Me.ListView5.Name = "ListView5"
        Me.ListView5.Size = New System.Drawing.Size(645, 297)
        Me.ListView5.SmallImageList = Me.ImgDetails
        Me.ListView5.TabIndex = 4
        Me.ListView5.UseCompatibleStateImageBehavior = False
        Me.ListView5.View = System.Windows.Forms.View.Details
        '
        'ImgDetails
        '
        Me.ImgDetails.ImageStream = CType(resources.GetObject("ImgDetails.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgDetails.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgDetails.Images.SetKeyName(0, "1381922821_131919.ico")
        Me.ImgDetails.Images.SetKeyName(1, "1381922355_131802.ico")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(680, 460)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "List View Control"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ImgLargeIcon As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ImgSmallIcon As System.Windows.Forms.ImageList
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents ImgList As System.Windows.Forms.ImageList
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ListView4 As System.Windows.Forms.ListView
    Friend WithEvents ImgTitle As System.Windows.Forms.ImageList
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ListView5 As System.Windows.Forms.ListView
    Friend WithEvents ImgDetails As System.Windows.Forms.ImageList

End Class
