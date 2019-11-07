<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.cmdLambdaFilteringAsDataTable = New System.Windows.Forms.Button()
        Me.cmdLambdaFilteringAsList = New System.Windows.Forms.Button()
        Me.cboCountries = New System.Windows.Forms.ComboBox()
        Me.cboContactType = New System.Windows.Forms.ComboBox()
        Me.cboCompanyNames = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdLambdaFilteringAsDataTable)
        Me.Panel1.Controls.Add(Me.cmdLambdaFilteringAsList)
        Me.Panel1.Controls.Add(Me.cboCountries)
        Me.Panel1.Controls.Add(Me.cboContactType)
        Me.Panel1.Controls.Add(Me.cboCompanyNames)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 246)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(685, 144)
        Me.Panel1.TabIndex = 1
        '
        'cmdLambdaFilteringAsDataTable
        '
        Me.cmdLambdaFilteringAsDataTable.Location = New System.Drawing.Point(341, 81)
        Me.cmdLambdaFilteringAsDataTable.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLambdaFilteringAsDataTable.Name = "cmdLambdaFilteringAsDataTable"
        Me.cmdLambdaFilteringAsDataTable.Size = New System.Drawing.Size(287, 35)
        Me.cmdLambdaFilteringAsDataTable.TabIndex = 3
        Me.cmdLambdaFilteringAsDataTable.Text = "Filter as DataTable"
        Me.cmdLambdaFilteringAsDataTable.UseVisualStyleBackColor = True
        '
        'cmdLambdaFilteringAsList
        '
        Me.cmdLambdaFilteringAsList.Location = New System.Drawing.Point(341, 28)
        Me.cmdLambdaFilteringAsList.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLambdaFilteringAsList.Name = "cmdLambdaFilteringAsList"
        Me.cmdLambdaFilteringAsList.Size = New System.Drawing.Size(287, 35)
        Me.cmdLambdaFilteringAsList.TabIndex = 1
        Me.cmdLambdaFilteringAsList.Text = "Filter as list"
        Me.cmdLambdaFilteringAsList.UseVisualStyleBackColor = True
        '
        'cboCountries
        '
        Me.cboCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountries.FormattingEnabled = True
        Me.cboCountries.Location = New System.Drawing.Point(27, 92)
        Me.cboCountries.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCountries.Name = "cboCountries"
        Me.cboCountries.Size = New System.Drawing.Size(279, 24)
        Me.cboCountries.TabIndex = 4
        '
        'cboContactType
        '
        Me.cboContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContactType.FormattingEnabled = True
        Me.cboContactType.Location = New System.Drawing.Point(27, 60)
        Me.cboContactType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboContactType.Name = "cboContactType"
        Me.cboContactType.Size = New System.Drawing.Size(279, 24)
        Me.cboContactType.TabIndex = 2
        '
        'cboCompanyNames
        '
        Me.cboCompanyNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompanyNames.FormattingEnabled = True
        Me.cboCompanyNames.Location = New System.Drawing.Point(27, 28)
        Me.cboCompanyNames.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCompanyNames.Name = "cboCompanyNames"
        Me.cboCompanyNames.Size = New System.Drawing.Size(279, 24)
        Me.cboCompanyNames.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(685, 246)
        Me.DataGridView1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 390)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboCompanyNames As System.Windows.Forms.ComboBox
    Friend WithEvents cboContactType As System.Windows.Forms.ComboBox
    Friend WithEvents cboCountries As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdLambdaFilteringAsList As System.Windows.Forms.Button
    Friend WithEvents cmdLambdaFilteringAsDataTable As System.Windows.Forms.Button
End Class
