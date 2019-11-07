<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutoComplete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAutoComplete))
        Me.TABELLAPAROLEBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.TABELLAPAROLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParoleDataSet = New AutocompleteTextBox.ParoleDataSet()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TABELLAPAROLEBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.AutoCompleteDataGridView = New System.Windows.Forms.DataGridView()
        Me.PAROLE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAROLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAutocomplete = New System.Windows.Forms.Button()
        Me.TxtAutoComplete = New System.Windows.Forms.TextBox()
        Me.TABELLAPAROLETableAdapter = New AutocompleteTextBox.ParoleDataSetTableAdapters.TABELLAPAROLETableAdapter()
        Me.TableAdapterManager = New AutocompleteTextBox.ParoleDataSetTableAdapters.TableAdapterManager()
        CType(Me.TABELLAPAROLEBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TABELLAPAROLEBindingNavigator.SuspendLayout()
        CType(Me.TABELLAPAROLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParoleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoCompleteDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TABELLAPAROLEBindingNavigator
        '
        Me.TABELLAPAROLEBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.TABELLAPAROLEBindingNavigator.BindingSource = Me.TABELLAPAROLEBindingSource
        Me.TABELLAPAROLEBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TABELLAPAROLEBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.TABELLAPAROLEBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TABELLAPAROLEBindingNavigatorSaveItem})
        Me.TABELLAPAROLEBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TABELLAPAROLEBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TABELLAPAROLEBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TABELLAPAROLEBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TABELLAPAROLEBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TABELLAPAROLEBindingNavigator.Name = "TABELLAPAROLEBindingNavigator"
        Me.TABELLAPAROLEBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TABELLAPAROLEBindingNavigator.Size = New System.Drawing.Size(655, 25)
        Me.TABELLAPAROLEBindingNavigator.TabIndex = 0
        Me.TABELLAPAROLEBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Aggiungi nuovo"
        '
        'TABELLAPAROLEBindingSource
        '
        Me.TABELLAPAROLEBindingSource.DataMember = "TABELLAPAROLE"
        Me.TABELLAPAROLEBindingSource.DataSource = Me.ParoleDataSet
        '
        'ParoleDataSet
        '
        Me.ParoleDataSet.DataSetName = "ParoleDataSet"
        Me.ParoleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(34, 22)
        Me.BindingNavigatorCountItem.Text = "di {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Numero totale di elementi"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Elimina"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Sposta in prima posizione"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Sposta indietro"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posizione"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posizione corrente"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Sposta avanti"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Sposta in ultima posizione"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TABELLAPAROLEBindingNavigatorSaveItem
        '
        Me.TABELLAPAROLEBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TABELLAPAROLEBindingNavigatorSaveItem.Image = CType(resources.GetObject("TABELLAPAROLEBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.TABELLAPAROLEBindingNavigatorSaveItem.Name = "TABELLAPAROLEBindingNavigatorSaveItem"
        Me.TABELLAPAROLEBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.TABELLAPAROLEBindingNavigatorSaveItem.Text = "Salva dati"
        '
        'AutoCompleteDataGridView
        '
        Me.AutoCompleteDataGridView.AutoGenerateColumns = False
        Me.AutoCompleteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AutoCompleteDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PAROLE1, Me.PAROLE})
        Me.AutoCompleteDataGridView.DataSource = Me.TABELLAPAROLEBindingSource
        Me.AutoCompleteDataGridView.Location = New System.Drawing.Point(12, 52)
        Me.AutoCompleteDataGridView.Name = "AutoCompleteDataGridView"
        Me.AutoCompleteDataGridView.Size = New System.Drawing.Size(243, 220)
        Me.AutoCompleteDataGridView.TabIndex = 1
        '
        'PAROLE1
        '
        Me.PAROLE1.DataPropertyName = "PAROLEID"
        Me.PAROLE1.HeaderText = "PAROLEID"
        Me.PAROLE1.Name = "PAROLE1"
        Me.PAROLE1.ReadOnly = True
        '
        'PAROLE
        '
        Me.PAROLE.DataPropertyName = "PAROLE"
        Me.PAROLE.HeaderText = "PAROLE"
        Me.PAROLE.Name = "PAROLE"
        '
        'btnAutocomplete
        '
        Me.btnAutocomplete.Location = New System.Drawing.Point(277, 52)
        Me.btnAutocomplete.Name = "btnAutocomplete"
        Me.btnAutocomplete.Size = New System.Drawing.Size(75, 23)
        Me.btnAutocomplete.TabIndex = 2
        Me.btnAutocomplete.Text = "Carica "
        Me.btnAutocomplete.UseVisualStyleBackColor = True
        '
        'TxtAutoComplete
        '
        Me.TxtAutoComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAutoComplete.Location = New System.Drawing.Point(277, 97)
        Me.TxtAutoComplete.Name = "TxtAutoComplete"
        Me.TxtAutoComplete.Size = New System.Drawing.Size(366, 20)
        Me.TxtAutoComplete.TabIndex = 6
        '
        'TABELLAPAROLETableAdapter
        '
        Me.TABELLAPAROLETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.TABELLAPAROLETableAdapter = Me.TABELLAPAROLETableAdapter
        Me.TableAdapterManager.UpdateOrder = AutocompleteTextBox.ParoleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'FrmAutoComplete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(655, 295)
        Me.Controls.Add(Me.TxtAutoComplete)
        Me.Controls.Add(Me.btnAutocomplete)
        Me.Controls.Add(Me.AutoCompleteDataGridView)
        Me.Controls.Add(Me.TABELLAPAROLEBindingNavigator)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrmAutoComplete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AUTOCOMPLETE SAMPLES"
        CType(Me.TABELLAPAROLEBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TABELLAPAROLEBindingNavigator.ResumeLayout(False)
        Me.TABELLAPAROLEBindingNavigator.PerformLayout()
        CType(Me.TABELLAPAROLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParoleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoCompleteDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ParoleDataSet As AutocompleteTextBox.ParoleDataSet
    Friend WithEvents TABELLAPAROLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TABELLAPAROLETableAdapter As AutocompleteTextBox.ParoleDataSetTableAdapters.TABELLAPAROLETableAdapter
    Friend WithEvents TableAdapterManager As AutocompleteTextBox.ParoleDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TABELLAPAROLEBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TABELLAPAROLEBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents AutoCompleteDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btnAutocomplete As System.Windows.Forms.Button
    Friend WithEvents PAROLE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAROLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtAutoComplete As System.Windows.Forms.TextBox

End Class
