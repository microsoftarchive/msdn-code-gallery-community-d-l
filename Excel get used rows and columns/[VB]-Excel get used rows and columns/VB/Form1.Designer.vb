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
        Me.cmdPoor = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdEachColumnDemo = New System.Windows.Forms.Button()
        Me.cmdDump = New System.Windows.Forms.Button()
        Me.cmdGood = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPoor
        '
        Me.cmdPoor.Location = New System.Drawing.Point(12, 16)
        Me.cmdPoor.Name = "cmdPoor"
        Me.cmdPoor.Size = New System.Drawing.Size(82, 32)
        Me.cmdPoor.TabIndex = 0
        Me.cmdPoor.Text = "Poor"
        Me.cmdPoor.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(594, 228)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdEachColumnDemo)
        Me.Panel1.Controls.Add(Me.cmdDump)
        Me.Panel1.Controls.Add(Me.cmdGood)
        Me.Panel1.Controls.Add(Me.cmdPoor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 228)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 69)
        Me.Panel1.TabIndex = 1
        '
        'cmdEachColumnDemo
        '
        Me.cmdEachColumnDemo.Location = New System.Drawing.Point(346, 16)
        Me.cmdEachColumnDemo.Name = "cmdEachColumnDemo"
        Me.cmdEachColumnDemo.Size = New System.Drawing.Size(78, 32)
        Me.cmdEachColumnDemo.TabIndex = 3
        Me.cmdEachColumnDemo.Text = "Each Col"
        Me.cmdEachColumnDemo.UseVisualStyleBackColor = True
        '
        'cmdDump
        '
        Me.cmdDump.Location = New System.Drawing.Point(240, 16)
        Me.cmdDump.Name = "cmdDump"
        Me.cmdDump.Size = New System.Drawing.Size(82, 32)
        Me.cmdDump.TabIndex = 2
        Me.cmdDump.Text = "Dump"
        Me.cmdDump.UseVisualStyleBackColor = True
        '
        'cmdGood
        '
        Me.cmdGood.Location = New System.Drawing.Point(130, 16)
        Me.cmdGood.Name = "cmdGood"
        Me.cmdGood.Size = New System.Drawing.Size(82, 32)
        Me.cmdGood.TabIndex = 1
        Me.cmdGood.Text = "Good"
        Me.cmdGood.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 297)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPoor As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdGood As System.Windows.Forms.Button
    Friend WithEvents cmdDump As System.Windows.Forms.Button
    Friend WithEvents cmdEachColumnDemo As System.Windows.Forms.Button

End Class
