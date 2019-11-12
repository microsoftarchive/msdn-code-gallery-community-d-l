<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultsForm
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GenderIdentifierColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 206)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 62)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idColumn, Me.FirstNameColumn, Me.LastNameColumn, Me.GenderIdentifierColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(496, 206)
        Me.DataGridView1.TabIndex = 1
        '
        'idColumn
        '
        Me.idColumn.DataPropertyName = "id"
        Me.idColumn.HeaderText = "Id"
        Me.idColumn.Name = "idColumn"
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
        'GenderIdentifierColumn
        '
        Me.GenderIdentifierColumn.DataPropertyName = "GenderIdentifier"
        Me.GenderIdentifierColumn.HeaderText = "Gender id"
        Me.GenderIdentifierColumn.Name = "GenderIdentifierColumn"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(389, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 34)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ResultsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 268)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ResultsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ResultsForm"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
    Friend WithEvents FirstNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents GenderIdentifierColumn As DataGridViewTextBoxColumn
End Class
