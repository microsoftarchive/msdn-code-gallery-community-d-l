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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvColumns = New System.Windows.Forms.DataGridView()
        Me.ProcessColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RealNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AliasColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdLoad)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 301)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(881, 58)
        Me.Panel2.TabIndex = 1
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(12, 16)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(75, 23)
        Me.cmdLoad.TabIndex = 0
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Location = New System.Drawing.Point(794, 16)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Exit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvColumns)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(881, 301)
        Me.SplitContainer1.SplitterDistance = 359
        Me.SplitContainer1.TabIndex = 0
        '
        'dgvColumns
        '
        Me.dgvColumns.AllowUserToAddRows = False
        Me.dgvColumns.AllowUserToDeleteRows = False
        Me.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvColumns.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProcessColumn, Me.RealNameColumn, Me.AliasColumn})
        Me.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvColumns.Location = New System.Drawing.Point(0, 0)
        Me.dgvColumns.Name = "dgvColumns"
        Me.dgvColumns.RowTemplate.Height = 24
        Me.dgvColumns.Size = New System.Drawing.Size(359, 301)
        Me.dgvColumns.TabIndex = 0
        '
        'ProcessColumn
        '
        Me.ProcessColumn.HeaderText = "Use"
        Me.ProcessColumn.Name = "ProcessColumn"
        Me.ProcessColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProcessColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'RealNameColumn
        '
        Me.RealNameColumn.HeaderText = "Real"
        Me.RealNameColumn.Name = "RealNameColumn"
        Me.RealNameColumn.ReadOnly = True
        '
        'AliasColumn
        '
        Me.AliasColumn.HeaderText = "Alias"
        Me.AliasColumn.Name = "AliasColumn"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(518, 301)
        Me.DataGridView1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 359)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvColumns As System.Windows.Forms.DataGridView
    Friend WithEvents ProcessColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RealNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AliasColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
