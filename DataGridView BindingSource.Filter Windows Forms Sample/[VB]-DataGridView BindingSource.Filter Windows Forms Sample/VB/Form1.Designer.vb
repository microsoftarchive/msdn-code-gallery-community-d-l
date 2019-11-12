<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Caption = New System.Windows.Forms.ToolStripLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menueItemShowAll = New System.Windows.Forms.ToolStripMenuItem
        Me.menueItemFilter = New System.Windows.Forms.ToolStripMenuItem
        Me.DataSet1 = New System.Data.DataSet
        Me.btnClearFilter = New System.Windows.Forms.Button
        Me.btnExecuteFilter = New System.Windows.Forms.Button
        Me.tbxFilter = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Caption})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(629, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Caption
        '
        Me.Caption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Caption.Name = "Caption"
        Me.Caption.Size = New System.Drawing.Size(0, 22)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(629, 292)
        Me.DataGridView1.TabIndex = 1
        Me.DataGridView1.VirtualMode = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menueItemShowAll, Me.menueItemFilter})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 48)
        '
        'menueItemShowAll
        '
        Me.menueItemShowAll.Name = "menueItemShowAll"
        Me.menueItemShowAll.Size = New System.Drawing.Size(122, 22)
        Me.menueItemShowAll.Text = "show all"
        '
        'menueItemFilter
        '
        Me.menueItemFilter.Name = "menueItemFilter"
        Me.menueItemFilter.Size = New System.Drawing.Size(122, 22)
        Me.menueItemFilter.Text = "set filter: "
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Location = New System.Drawing.Point(12, 336)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnClearFilter.TabIndex = 2
        Me.btnClearFilter.Text = "clear filter"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'btnExecuteFilter
        '
        Me.btnExecuteFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExecuteFilter.Location = New System.Drawing.Point(533, 336)
        Me.btnExecuteFilter.Name = "btnExecuteFilter"
        Me.btnExecuteFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnExecuteFilter.TabIndex = 3
        Me.btnExecuteFilter.Text = "execute filter"
        Me.btnExecuteFilter.UseVisualStyleBackColor = True
        '
        'tbxFilter
        '
        Me.tbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxFilter.Location = New System.Drawing.Point(93, 336)
        Me.tbxFilter.Name = "tbxFilter"
        Me.tbxFilter.Size = New System.Drawing.Size(434, 26)
        Me.tbxFilter.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 371)
        Me.Controls.Add(Me.tbxFilter)
        Me.Controls.Add(Me.btnExecuteFilter)
        Me.Controls.Add(Me.btnClearFilter)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Form1"
        Me.Text = "DataGridview BindingSource.Filter Demo"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Caption As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menueItemShowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menueItemFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSet1 As System.Data.DataSet
    Friend WithEvents btnClearFilter As System.Windows.Forms.Button
    Friend WithEvents btnExecuteFilter As System.Windows.Forms.Button
    Friend WithEvents tbxFilter As System.Windows.Forms.TextBox

End Class
