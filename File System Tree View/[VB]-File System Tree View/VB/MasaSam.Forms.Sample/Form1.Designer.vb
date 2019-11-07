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
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.btnShowSelectedFiles = New System.Windows.Forms.Button()
        Me.btnShowSelectedFolders = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRoot = New System.Windows.Forms.TextBox()
        Me.btnRoot = New System.Windows.Forms.Button()
        Me.FileSystemTree1 = New MasaSam.Forms.Controls.FileSystemTree()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnExpand = New System.Windows.Forms.Button()
        Me.btnCollapse = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(290, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selected:"
        '
        'txtSelected
        '
        Me.txtSelected.Location = New System.Drawing.Point(348, 22)
        Me.txtSelected.Name = "txtSelected"
        Me.txtSelected.Size = New System.Drawing.Size(248, 20)
        Me.txtSelected.TabIndex = 2
        '
        'btnShowSelectedFiles
        '
        Me.btnShowSelectedFiles.Location = New System.Drawing.Point(348, 58)
        Me.btnShowSelectedFiles.Name = "btnShowSelectedFiles"
        Me.btnShowSelectedFiles.Size = New System.Drawing.Size(162, 23)
        Me.btnShowSelectedFiles.TabIndex = 3
        Me.btnShowSelectedFiles.Text = "Show selected files"
        Me.btnShowSelectedFiles.UseVisualStyleBackColor = True
        '
        'btnShowSelectedFolders
        '
        Me.btnShowSelectedFolders.Location = New System.Drawing.Point(348, 101)
        Me.btnShowSelectedFolders.Name = "btnShowSelectedFolders"
        Me.btnShowSelectedFolders.Size = New System.Drawing.Size(162, 23)
        Me.btnShowSelectedFolders.TabIndex = 4
        Me.btnShowSelectedFolders.Text = "Show selected folders"
        Me.btnShowSelectedFolders.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(348, 297)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(248, 147)
        Me.ListBox1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(290, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Root:"
        '
        'txtRoot
        '
        Me.txtRoot.Location = New System.Drawing.Point(348, 153)
        Me.txtRoot.Name = "txtRoot"
        Me.txtRoot.Size = New System.Drawing.Size(162, 20)
        Me.txtRoot.TabIndex = 7
        '
        'btnRoot
        '
        Me.btnRoot.Location = New System.Drawing.Point(521, 151)
        Me.btnRoot.Name = "btnRoot"
        Me.btnRoot.Size = New System.Drawing.Size(75, 23)
        Me.btnRoot.TabIndex = 8
        Me.btnRoot.Text = "Set"
        Me.btnRoot.UseVisualStyleBackColor = True
        '
        'FileSystemTree1
        '
        Me.FileSystemTree1.FileExtensions = "*"
        Me.FileSystemTree1.Location = New System.Drawing.Point(12, 16)
        Me.FileSystemTree1.Name = "FileSystemTree1"
        Me.FileSystemTree1.RootDrive = Nothing
        Me.FileSystemTree1.ShowImages = True
        Me.FileSystemTree1.Size = New System.Drawing.Size(260, 452)
        Me.FileSystemTree1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(290, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Path:"
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(348, 206)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(162, 20)
        Me.txtPath.TabIndex = 10
        '
        'btnExpand
        '
        Me.btnExpand.Location = New System.Drawing.Point(521, 204)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(35, 23)
        Me.btnExpand.TabIndex = 11
        Me.btnExpand.Text = "+"
        Me.btnExpand.UseVisualStyleBackColor = True
        '
        'btnCollapse
        '
        Me.btnCollapse.Location = New System.Drawing.Point(561, 204)
        Me.btnCollapse.Name = "btnCollapse"
        Me.btnCollapse.Size = New System.Drawing.Size(35, 23)
        Me.btnCollapse.TabIndex = 12
        Me.btnCollapse.Text = "-"
        Me.btnCollapse.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 480)
        Me.Controls.Add(Me.btnCollapse)
        Me.Controls.Add(Me.btnExpand)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnRoot)
        Me.Controls.Add(Me.txtRoot)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnShowSelectedFolders)
        Me.Controls.Add(Me.btnShowSelectedFiles)
        Me.Controls.Add(Me.txtSelected)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FileSystemTree1)
        Me.Name = "Form1"
        Me.Text = "File Tree Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileSystemTree1 As MasaSam.Forms.Controls.FileSystemTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSelected As System.Windows.Forms.TextBox
    Friend WithEvents btnShowSelectedFiles As System.Windows.Forms.Button
    Friend WithEvents btnShowSelectedFolders As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRoot As System.Windows.Forms.TextBox
    Friend WithEvents btnRoot As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnExpand As System.Windows.Forms.Button
    Friend WithEvents btnCollapse As System.Windows.Forms.Button

End Class
