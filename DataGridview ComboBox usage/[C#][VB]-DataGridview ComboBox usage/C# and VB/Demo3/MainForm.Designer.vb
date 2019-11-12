<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainForm
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkAutoDropDown = New System.Windows.Forms.CheckBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(587, 434)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkAutoDropDown)
        Me.Panel1.Controls.Add(Me.cmdClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 388)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(587, 46)
        Me.Panel1.TabIndex = 1
        '
        'chkAutoDropDown
        '
        Me.chkAutoDropDown.AutoSize = True
        Me.chkAutoDropDown.Location = New System.Drawing.Point(247, 15)
        Me.chkAutoDropDown.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkAutoDropDown.Name = "chkAutoDropDown"
        Me.chkAutoDropDown.Size = New System.Drawing.Size(125, 21)
        Me.chkAutoDropDown.TabIndex = 3
        Me.chkAutoDropDown.Text = "Auto dropdown"
        Me.chkAutoDropDown.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdClose.Location = New System.Drawing.Point(472, 15)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(99, 27)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 434)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents chkAutoDropDown As System.Windows.Forms.CheckBox

End Class
