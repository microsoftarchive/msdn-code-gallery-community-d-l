<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LocateByIdButton = New System.Windows.Forms.Button()
        Me.ForLocateComboBox = New System.Windows.Forms.ComboBox()
        Me.ReloadButton = New System.Windows.Forms.Button()
        Me.MockedFilterButtonThisForm = New System.Windows.Forms.Button()
        Me.NameComboBox = New System.Windows.Forms.ComboBox()
        Me.FilterFirstOrLastNameTextBox = New System.Windows.Forms.TextBox()
        Me.FilterForFirstNameComboBox = New System.Windows.Forms.ComboBox()
        Me.MockedFilterDialogButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LocateByIdButton)
        Me.Panel1.Controls.Add(Me.ForLocateComboBox)
        Me.Panel1.Controls.Add(Me.ReloadButton)
        Me.Panel1.Controls.Add(Me.MockedFilterButtonThisForm)
        Me.Panel1.Controls.Add(Me.NameComboBox)
        Me.Panel1.Controls.Add(Me.FilterFirstOrLastNameTextBox)
        Me.Panel1.Controls.Add(Me.FilterForFirstNameComboBox)
        Me.Panel1.Controls.Add(Me.MockedFilterDialogButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 262)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(759, 102)
        Me.Panel1.TabIndex = 1
        '
        'LocateByIdButton
        '
        Me.LocateByIdButton.Location = New System.Drawing.Point(615, 40)
        Me.LocateByIdButton.Name = "LocateByIdButton"
        Me.LocateByIdButton.Size = New System.Drawing.Size(75, 23)
        Me.LocateByIdButton.TabIndex = 11
        Me.LocateByIdButton.Text = "Locate Id"
        Me.LocateByIdButton.UseVisualStyleBackColor = True
        '
        'ForLocateComboBox
        '
        Me.ForLocateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ForLocateComboBox.FormattingEnabled = True
        Me.ForLocateComboBox.Location = New System.Drawing.Point(615, 15)
        Me.ForLocateComboBox.Name = "ForLocateComboBox"
        Me.ForLocateComboBox.Size = New System.Drawing.Size(132, 21)
        Me.ForLocateComboBox.TabIndex = 10
        '
        'ReloadButton
        '
        Me.ReloadButton.Location = New System.Drawing.Point(433, 15)
        Me.ReloadButton.Name = "ReloadButton"
        Me.ReloadButton.Size = New System.Drawing.Size(118, 75)
        Me.ReloadButton.TabIndex = 9
        Me.ReloadButton.Text = "Reload data"
        Me.ReloadButton.UseVisualStyleBackColor = True
        '
        'MockedFilterButtonThisForm
        '
        Me.MockedFilterButtonThisForm.Location = New System.Drawing.Point(309, 14)
        Me.MockedFilterButtonThisForm.Name = "MockedFilterButtonThisForm"
        Me.MockedFilterButtonThisForm.Size = New System.Drawing.Size(118, 75)
        Me.MockedFilterButtonThisForm.TabIndex = 8
        Me.MockedFilterButtonThisForm.Text = "Filter"
        Me.MockedFilterButtonThisForm.UseVisualStyleBackColor = True
        '
        'NameComboBox
        '
        Me.NameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NameComboBox.FormattingEnabled = True
        Me.NameComboBox.Location = New System.Drawing.Point(14, 42)
        Me.NameComboBox.Name = "NameComboBox"
        Me.NameComboBox.Size = New System.Drawing.Size(121, 21)
        Me.NameComboBox.TabIndex = 7
        '
        'FilterFirstOrLastNameTextBox
        '
        Me.FilterFirstOrLastNameTextBox.Location = New System.Drawing.Point(12, 70)
        Me.FilterFirstOrLastNameTextBox.Name = "FilterFirstOrLastNameTextBox"
        Me.FilterFirstOrLastNameTextBox.Size = New System.Drawing.Size(127, 20)
        Me.FilterFirstOrLastNameTextBox.TabIndex = 6
        '
        'FilterForFirstNameComboBox
        '
        Me.FilterForFirstNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterForFirstNameComboBox.FormattingEnabled = True
        Me.FilterForFirstNameComboBox.Location = New System.Drawing.Point(14, 15)
        Me.FilterForFirstNameComboBox.Name = "FilterForFirstNameComboBox"
        Me.FilterForFirstNameComboBox.Size = New System.Drawing.Size(121, 21)
        Me.FilterForFirstNameComboBox.TabIndex = 5
        '
        'MockedFilterDialogButton
        '
        Me.MockedFilterDialogButton.Location = New System.Drawing.Point(141, 15)
        Me.MockedFilterDialogButton.Name = "MockedFilterDialogButton"
        Me.MockedFilterDialogButton.Size = New System.Drawing.Size(118, 75)
        Me.MockedFilterDialogButton.TabIndex = 4
        Me.MockedFilterDialogButton.Text = "Filter dialog"
        Me.MockedFilterDialogButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(759, 237)
        Me.DataGridView1.TabIndex = 0
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(759, 25)
        Me.BindingNavigator1.TabIndex = 2
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
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
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 364)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code Sample"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BindingNavigator1 As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents MockedFilterDialogButton As Button
    Friend WithEvents FilterForFirstNameComboBox As ComboBox
    Friend WithEvents FilterFirstOrLastNameTextBox As TextBox
    Friend WithEvents NameComboBox As ComboBox
    Friend WithEvents MockedFilterButtonThisForm As Button
    Friend WithEvents ReloadButton As Button
    Friend WithEvents ForLocateComboBox As ComboBox
    Friend WithEvents LocateByIdButton As Button
End Class
