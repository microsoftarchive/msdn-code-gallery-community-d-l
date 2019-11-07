<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GenderColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.CurrentButton = New System.Windows.Forms.Button()
        Me.addedRowsButton = New System.Windows.Forms.Button()
        Me.updatesButton = New System.Windows.Forms.Button()
        Me.acceptChangesButton = New System.Windows.Forms.Button()
        Me.hasDeletedButton = New System.Windows.Forms.Button()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dataGridView1
        '
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdColumn, Me.FirstNameColumn, Me.LastNameColumn, Me.GenderColumn})
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.dataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(676, 390)
        Me.dataGridView1.TabIndex = 3
        '
        'IdColumn
        '
        Me.IdColumn.DataPropertyName = "id"
        Me.IdColumn.HeaderText = "id"
        Me.IdColumn.Name = "IdColumn"
        Me.IdColumn.ReadOnly = True
        '
        'FirstNameColumn
        '
        Me.FirstNameColumn.DataPropertyName = "FirstName"
        Me.FirstNameColumn.HeaderText = "First"
        Me.FirstNameColumn.Name = "FirstNameColumn"
        '
        'LastNameColumn
        '
        Me.LastNameColumn.DataPropertyName = "LastName"
        Me.LastNameColumn.HeaderText = "Last"
        Me.LastNameColumn.Name = "LastNameColumn"
        '
        'GenderColumn
        '
        Me.GenderColumn.DataPropertyName = "GenderIdentifier"
        Me.GenderColumn.HeaderText = "Gender"
        Me.GenderColumn.Name = "GenderColumn"
        Me.GenderColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GenderColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.CurrentButton)
        Me.panel1.Controls.Add(Me.addedRowsButton)
        Me.panel1.Controls.Add(Me.updatesButton)
        Me.panel1.Controls.Add(Me.acceptChangesButton)
        Me.panel1.Controls.Add(Me.hasDeletedButton)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel1.Location = New System.Drawing.Point(0, 390)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(676, 69)
        Me.panel1.TabIndex = 2
        '
        'CurrentButton
        '
        Me.CurrentButton.Location = New System.Drawing.Point(344, 21)
        Me.CurrentButton.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrentButton.Name = "CurrentButton"
        Me.CurrentButton.Size = New System.Drawing.Size(100, 28)
        Me.CurrentButton.TabIndex = 4
        Me.CurrentButton.Text = "Current"
        Me.CurrentButton.UseVisualStyleBackColor = True
        '
        'addedRowsButton
        '
        Me.addedRowsButton.Location = New System.Drawing.Point(224, 21)
        Me.addedRowsButton.Margin = New System.Windows.Forms.Padding(4)
        Me.addedRowsButton.Name = "addedRowsButton"
        Me.addedRowsButton.Size = New System.Drawing.Size(100, 28)
        Me.addedRowsButton.TabIndex = 3
        Me.addedRowsButton.Text = "Added"
        Me.addedRowsButton.UseVisualStyleBackColor = True
        '
        'updatesButton
        '
        Me.updatesButton.Location = New System.Drawing.Point(116, 21)
        Me.updatesButton.Margin = New System.Windows.Forms.Padding(4)
        Me.updatesButton.Name = "updatesButton"
        Me.updatesButton.Size = New System.Drawing.Size(100, 28)
        Me.updatesButton.TabIndex = 2
        Me.updatesButton.Text = "Updates"
        Me.updatesButton.UseVisualStyleBackColor = True
        '
        'acceptChangesButton
        '
        Me.acceptChangesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.acceptChangesButton.Location = New System.Drawing.Point(452, 21)
        Me.acceptChangesButton.Margin = New System.Windows.Forms.Padding(4)
        Me.acceptChangesButton.Name = "acceptChangesButton"
        Me.acceptChangesButton.Size = New System.Drawing.Size(100, 28)
        Me.acceptChangesButton.TabIndex = 1
        Me.acceptChangesButton.Text = "Accept"
        Me.acceptChangesButton.UseVisualStyleBackColor = True
        '
        'hasDeletedButton
        '
        Me.hasDeletedButton.Location = New System.Drawing.Point(8, 21)
        Me.hasDeletedButton.Margin = New System.Windows.Forms.Padding(4)
        Me.hasDeletedButton.Name = "hasDeletedButton"
        Me.hasDeletedButton.Size = New System.Drawing.Size(100, 28)
        Me.hasDeletedButton.TabIndex = 0
        Me.hasDeletedButton.Text = "Deleted"
        Me.hasDeletedButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 459)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents dataGridView1 As DataGridView
    Private WithEvents IdColumn As DataGridViewTextBoxColumn
    Private WithEvents FirstNameColumn As DataGridViewTextBoxColumn
    Private WithEvents LastNameColumn As DataGridViewTextBoxColumn
    Private WithEvents GenderColumn As DataGridViewComboBoxColumn
    Private WithEvents panel1 As Panel
    Private WithEvents CurrentButton As Button
    Private WithEvents addedRowsButton As Button
    Private WithEvents updatesButton As Button
    Private WithEvents acceptChangesButton As Button
    Private WithEvents hasDeletedButton As Button
End Class
