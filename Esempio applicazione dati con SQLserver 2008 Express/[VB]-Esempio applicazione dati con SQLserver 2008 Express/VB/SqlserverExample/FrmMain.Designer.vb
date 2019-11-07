<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblLinq = New System.Windows.Forms.Label()
        Me.lblCustom = New System.Windows.Forms.Label()
        Me.lblFind = New System.Windows.Forms.Label()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.btnFindLinq = New System.Windows.Forms.Button()
        Me.cbxLinq = New System.Windows.Forms.ComboBox()
        Me.btnFindTypeData = New System.Windows.Forms.Button()
        Me.cbxTypeData = New System.Windows.Forms.ComboBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSurName = New System.Windows.Forms.TextBox()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblSurName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.dgvExample = New System.Windows.Forms.DataGridView()
        Me.ExampleDataSet = New SqlserverExample.ExampleDataSet()
        Me.TABELLA1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TABELLA1TableAdapter = New SqlserverExample.ExampleDataSetTableAdapters.TABELLA1TableAdapter()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NAMES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SURNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AGE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.dgvExample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExampleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TABELLA1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.groupBox2.Controls.Add(Me.lblLinq)
        Me.groupBox2.Controls.Add(Me.lblCustom)
        Me.groupBox2.Controls.Add(Me.lblFind)
        Me.groupBox2.Controls.Add(Me.txtFind)
        Me.groupBox2.Controls.Add(Me.btnFindLinq)
        Me.groupBox2.Controls.Add(Me.cbxLinq)
        Me.groupBox2.Controls.Add(Me.btnFindTypeData)
        Me.groupBox2.Controls.Add(Me.cbxTypeData)
        Me.groupBox2.Location = New System.Drawing.Point(14, 195)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(457, 179)
        Me.groupBox2.TabIndex = 16
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "SEARCH TYPE"
        '
        'lblLinq
        '
        Me.lblLinq.AutoSize = True
        Me.lblLinq.Location = New System.Drawing.Point(151, 87)
        Me.lblLinq.Name = "lblLinq"
        Me.lblLinq.Size = New System.Drawing.Size(73, 13)
        Me.lblLinq.TabIndex = 19
        Me.lblLinq.Text = "LINQ QUERY"
        '
        'lblCustom
        '
        Me.lblCustom.AutoSize = True
        Me.lblCustom.Location = New System.Drawing.Point(151, 27)
        Me.lblCustom.Name = "lblCustom"
        Me.lblCustom.Size = New System.Drawing.Size(53, 13)
        Me.lblCustom.TabIndex = 18
        Me.lblCustom.Text = "CUSTOM"
        '
        'lblFind
        '
        Me.lblFind.AutoSize = True
        Me.lblFind.Location = New System.Drawing.Point(11, 151)
        Me.lblFind.Name = "lblFind"
        Me.lblFind.Size = New System.Drawing.Size(91, 13)
        Me.lblFind.TabIndex = 17
        Me.lblFind.Text = "RESULT QUERY"
        '
        'txtFind
        '
        Me.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFind.Location = New System.Drawing.Point(176, 52)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(156, 20)
        Me.txtFind.TabIndex = 16
        '
        'btnFindLinq
        '
        Me.btnFindLinq.Location = New System.Drawing.Point(376, 110)
        Me.btnFindLinq.Name = "btnFindLinq"
        Me.btnFindLinq.Size = New System.Drawing.Size(75, 23)
        Me.btnFindLinq.TabIndex = 15
        Me.btnFindLinq.Text = "Find Linq"
        Me.btnFindLinq.UseVisualStyleBackColor = True
        '
        'cbxLinq
        '
        Me.cbxLinq.BackColor = System.Drawing.Color.White
        Me.cbxLinq.FormattingEnabled = True
        Me.cbxLinq.Items.AddRange(New Object() {"ASCENDING NAME", "DESCENDING NAME", "ASCENDING SURNAME", "DESCENDING SURNAME", "ASCENDING AGE", "DESCENDING AGE"})
        Me.cbxLinq.Location = New System.Drawing.Point(14, 112)
        Me.cbxLinq.Name = "cbxLinq"
        Me.cbxLinq.Size = New System.Drawing.Size(156, 21)
        Me.cbxLinq.TabIndex = 14
        '
        'btnFindTypeData
        '
        Me.btnFindTypeData.Location = New System.Drawing.Point(376, 50)
        Me.btnFindTypeData.Name = "btnFindTypeData"
        Me.btnFindTypeData.Size = New System.Drawing.Size(75, 23)
        Me.btnFindTypeData.TabIndex = 13
        Me.btnFindTypeData.Text = "Find Data"
        Me.btnFindTypeData.UseVisualStyleBackColor = True
        '
        'cbxTypeData
        '
        Me.cbxTypeData.BackColor = System.Drawing.Color.White
        Me.cbxTypeData.FormattingEnabled = True
        Me.cbxTypeData.Items.AddRange(New Object() {"NAME", "SURNAME", "AGE"})
        Me.cbxTypeData.Location = New System.Drawing.Point(14, 52)
        Me.cbxTypeData.Name = "cbxTypeData"
        Me.cbxTypeData.Size = New System.Drawing.Size(156, 21)
        Me.cbxTypeData.TabIndex = 0
        '
        'groupBox1
        '
        Me.groupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.groupBox1.Controls.Add(Me.txtSurName)
        Me.groupBox1.Controls.Add(Me.btnInsert)
        Me.groupBox1.Controls.Add(Me.txtAge)
        Me.groupBox1.Controls.Add(Me.btnDelete)
        Me.groupBox1.Controls.Add(Me.lblAge)
        Me.groupBox1.Controls.Add(Me.btnUpdate)
        Me.groupBox1.Controls.Add(Me.lblName)
        Me.groupBox1.Controls.Add(Me.lblSurName)
        Me.groupBox1.Controls.Add(Me.txtName)
        Me.groupBox1.Location = New System.Drawing.Point(14, 10)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(457, 179)
        Me.groupBox1.TabIndex = 15
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "INSERT DELETE UPDATE"
        '
        'txtSurName
        '
        Me.txtSurName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurName.Location = New System.Drawing.Point(95, 117)
        Me.txtSurName.Name = "txtSurName"
        Me.txtSurName.Size = New System.Drawing.Size(100, 20)
        Me.txtSurName.TabIndex = 7
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(14, 24)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(75, 23)
        Me.btnInsert.TabIndex = 0
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'txtAge
        '
        Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAge.Location = New System.Drawing.Point(95, 143)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(100, 20)
        Me.txtAge.TabIndex = 8
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(95, 24)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Location = New System.Drawing.Point(14, 146)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(26, 13)
        Me.lblAge.TabIndex = 5
        Me.lblAge.Text = "Age"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(176, 24)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(14, 91)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Name"
        '
        'lblSurName
        '
        Me.lblSurName.AutoSize = True
        Me.lblSurName.Location = New System.Drawing.Point(14, 120)
        Me.lblSurName.Name = "lblSurName"
        Me.lblSurName.Size = New System.Drawing.Size(51, 13)
        Me.lblSurName.TabIndex = 4
        Me.lblSurName.Text = "SurName"
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Location = New System.Drawing.Point(95, 91)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 6
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(390, 399)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'dgvExample
        '
        Me.dgvExample.AutoGenerateColumns = False
        Me.dgvExample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExample.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.NAMES, Me.SURNAME, Me.AGE})
        Me.dgvExample.DataSource = Me.TABELLA1BindingSource
        Me.dgvExample.Location = New System.Drawing.Point(477, 10)
        Me.dgvExample.Name = "dgvExample"
        Me.dgvExample.ReadOnly = True
        Me.dgvExample.Size = New System.Drawing.Size(446, 412)
        Me.dgvExample.TabIndex = 14
        '
        'ExampleDataSet
        '
        Me.ExampleDataSet.DataSetName = "ExampleDataSet"
        Me.ExampleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TABELLA1BindingSource
        '
        Me.TABELLA1BindingSource.DataMember = "TABELLA1"
        Me.TABELLA1BindingSource.DataSource = Me.ExampleDataSet
        '
        'TABELLA1TableAdapter
        '
        Me.TABELLA1TableAdapter.ClearBeforeFill = True
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NAMES
        '
        Me.NAMES.DataPropertyName = "NOME"
        Me.NAMES.HeaderText = "NAME"
        Me.NAMES.Name = "NAMES"
        Me.NAMES.ReadOnly = True
        '
        'SURNAME
        '
        Me.SURNAME.DataPropertyName = "COGNOME"
        Me.SURNAME.HeaderText = "SURNAME"
        Me.SURNAME.Name = "SURNAME"
        Me.SURNAME.ReadOnly = True
        '
        'AGE
        '
        Me.AGE.DataPropertyName = "AGE"
        Me.AGE.HeaderText = "AGE"
        Me.AGE.Name = "AGE"
        Me.AGE.ReadOnly = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 433)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.dgvExample)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SqlServerExample"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.dgvExample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExampleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TABELLA1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents lblLinq As System.Windows.Forms.Label
    Private WithEvents lblCustom As System.Windows.Forms.Label
    Private WithEvents lblFind As System.Windows.Forms.Label
    Private WithEvents txtFind As System.Windows.Forms.TextBox
    Private WithEvents btnFindLinq As System.Windows.Forms.Button
    Private WithEvents cbxLinq As System.Windows.Forms.ComboBox
    Private WithEvents btnFindTypeData As System.Windows.Forms.Button
    Private WithEvents cbxTypeData As System.Windows.Forms.ComboBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtSurName As System.Windows.Forms.TextBox
    Private WithEvents btnInsert As System.Windows.Forms.Button
    Private WithEvents txtAge As System.Windows.Forms.TextBox
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents lblAge As System.Windows.Forms.Label
    Private WithEvents btnUpdate As System.Windows.Forms.Button
    Private WithEvents lblName As System.Windows.Forms.Label
    Private WithEvents lblSurName As System.Windows.Forms.Label
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents btnExit As System.Windows.Forms.Button
    Private WithEvents dgvExample As System.Windows.Forms.DataGridView
    Friend WithEvents ExampleDataSet As SqlserverExample.ExampleDataSet
    Friend WithEvents TABELLA1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TABELLA1TableAdapter As SqlserverExample.ExampleDataSetTableAdapters.TABELLA1TableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NAMES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SURNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
