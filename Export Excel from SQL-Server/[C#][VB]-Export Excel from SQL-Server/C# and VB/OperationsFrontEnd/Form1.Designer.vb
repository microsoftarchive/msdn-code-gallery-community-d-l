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
        Me.CreateNewExcelFileCheckBox = New System.Windows.Forms.CheckBox()
        Me.selectAllButton = New System.Windows.Forms.Button()
        Me.selectByCountryButton = New System.Windows.Forms.Button()
        Me.countriesCombox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'CreateNewExcelFileCheckBox
        '
        Me.CreateNewExcelFileCheckBox.AutoSize = True
        Me.CreateNewExcelFileCheckBox.Checked = True
        Me.CreateNewExcelFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CreateNewExcelFileCheckBox.Location = New System.Drawing.Point(21, 112)
        Me.CreateNewExcelFileCheckBox.Name = "CreateNewExcelFileCheckBox"
        Me.CreateNewExcelFileCheckBox.Size = New System.Drawing.Size(161, 17)
        Me.CreateNewExcelFileCheckBox.TabIndex = 3
        Me.CreateNewExcelFileCheckBox.Text = "If checked, create a new file"
        Me.CreateNewExcelFileCheckBox.UseVisualStyleBackColor = True
        '
        'selectAllButton
        '
        Me.selectAllButton.Location = New System.Drawing.Point(21, 12)
        Me.selectAllButton.Name = "selectAllButton"
        Me.selectAllButton.Size = New System.Drawing.Size(135, 23)
        Me.selectAllButton.TabIndex = 0
        Me.selectAllButton.Text = "Export All"
        Me.selectAllButton.UseVisualStyleBackColor = True
        '
        'selectByCountryButton
        '
        Me.selectByCountryButton.Location = New System.Drawing.Point(21, 54)
        Me.selectByCountryButton.Name = "selectByCountryButton"
        Me.selectByCountryButton.Size = New System.Drawing.Size(135, 23)
        Me.selectByCountryButton.TabIndex = 1
        Me.selectByCountryButton.Text = "Export by Country"
        Me.selectByCountryButton.UseVisualStyleBackColor = True
        '
        'countriesCombox
        '
        Me.countriesCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.countriesCombox.FormattingEnabled = True
        Me.countriesCombox.Location = New System.Drawing.Point(173, 56)
        Me.countriesCombox.Name = "countriesCombox"
        Me.countriesCombox.Size = New System.Drawing.Size(175, 21)
        Me.countriesCombox.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 162)
        Me.Controls.Add(Me.countriesCombox)
        Me.Controls.Add(Me.selectByCountryButton)
        Me.Controls.Add(Me.CreateNewExcelFileCheckBox)
        Me.Controls.Add(Me.selectAllButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents selectAllButton As Button
    Friend WithEvents CreateNewExcelFileCheckBox As CheckBox
    Friend WithEvents selectByCountryButton As Button
    Friend WithEvents countriesCombox As ComboBox
End Class
