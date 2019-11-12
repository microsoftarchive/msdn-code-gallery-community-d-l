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
        Me.cmdQuickAdd = New System.Windows.Forms.Button()
        Me.cmdDemo = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdPeekAtAllRows = New System.Windows.Forms.Button()
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
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(386, 434)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdQuickAdd)
        Me.Panel1.Controls.Add(Me.cmdDemo)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.cmdPeekAtAllRows)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 350)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 84)
        Me.Panel1.TabIndex = 1
        '
        'cmdQuickAdd
        '
        Me.cmdQuickAdd.Location = New System.Drawing.Point(13, 52)
        Me.cmdQuickAdd.Name = "cmdQuickAdd"
        Me.cmdQuickAdd.Size = New System.Drawing.Size(100, 28)
        Me.cmdQuickAdd.TabIndex = 3
        Me.cmdQuickAdd.Text = "Quick Add"
        Me.cmdQuickAdd.UseVisualStyleBackColor = True
        '
        'cmdDemo
        '
        Me.cmdDemo.Location = New System.Drawing.Point(308, 12)
        Me.cmdDemo.Name = "cmdDemo"
        Me.cmdDemo.Size = New System.Drawing.Size(65, 47)
        Me.cmdDemo.TabIndex = 2
        Me.cmdDemo.Text = "Demo"
        Me.cmdDemo.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(120, 21)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(178, 21)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "Show only MessageBox"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdPeekAtAllRows
        '
        Me.cmdPeekAtAllRows.Location = New System.Drawing.Point(13, 16)
        Me.cmdPeekAtAllRows.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPeekAtAllRows.Name = "cmdPeekAtAllRows"
        Me.cmdPeekAtAllRows.Size = New System.Drawing.Size(100, 28)
        Me.cmdPeekAtAllRows.TabIndex = 0
        Me.cmdPeekAtAllRows.Text = "All"
        Me.cmdPeekAtAllRows.UseVisualStyleBackColor = True
        '
        'frmMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 434)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents cmdPeekAtAllRows As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdDemo As System.Windows.Forms.Button
    Friend WithEvents cmdQuickAdd As System.Windows.Forms.Button

End Class
