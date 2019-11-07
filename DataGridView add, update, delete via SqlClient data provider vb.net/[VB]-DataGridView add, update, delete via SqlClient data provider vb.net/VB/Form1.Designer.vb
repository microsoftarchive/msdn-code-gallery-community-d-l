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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdDeleteCurrentRow = New System.Windows.Forms.Button()
        Me.cmdAddNewRow = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmdEditCurrentRow = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdEditCurrentRow)
        Me.Panel1.Controls.Add(Me.cmdDeleteCurrentRow)
        Me.Panel1.Controls.Add(Me.cmdAddNewRow)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 279)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(558, 49)
        Me.Panel1.TabIndex = 1
        '
        'cmdDeleteCurrentRow
        '
        Me.cmdDeleteCurrentRow.Location = New System.Drawing.Point(165, 7)
        Me.cmdDeleteCurrentRow.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdDeleteCurrentRow.Name = "cmdDeleteCurrentRow"
        Me.cmdDeleteCurrentRow.Size = New System.Drawing.Size(150, 33)
        Me.cmdDeleteCurrentRow.TabIndex = 1
        Me.cmdDeleteCurrentRow.Text = "Remove current"
        Me.cmdDeleteCurrentRow.UseVisualStyleBackColor = True
        '
        'cmdAddNewRow
        '
        Me.cmdAddNewRow.Location = New System.Drawing.Point(11, 7)
        Me.cmdAddNewRow.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAddNewRow.Name = "cmdAddNewRow"
        Me.cmdAddNewRow.Size = New System.Drawing.Size(150, 33)
        Me.cmdAddNewRow.TabIndex = 0
        Me.cmdAddNewRow.Text = "Add new row(s)"
        Me.cmdAddNewRow.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(558, 279)
        Me.DataGridView1.TabIndex = 0
        '
        'cmdEditCurrentRow
        '
        Me.cmdEditCurrentRow.Location = New System.Drawing.Point(319, 7)
        Me.cmdEditCurrentRow.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditCurrentRow.Name = "cmdEditCurrentRow"
        Me.cmdEditCurrentRow.Size = New System.Drawing.Size(150, 33)
        Me.cmdEditCurrentRow.TabIndex = 2
        Me.cmdEditCurrentRow.Text = "Save current"
        Me.cmdEditCurrentRow.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 328)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAddNewRow As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteCurrentRow As System.Windows.Forms.Button
    Friend WithEvents cmdEditCurrentRow As System.Windows.Forms.Button

End Class
