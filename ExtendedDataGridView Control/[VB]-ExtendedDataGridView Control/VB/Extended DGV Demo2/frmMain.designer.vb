<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ExtendedDataGridView1 = New ExtendedDataGridView.ExtendedDataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column3 = New ExtendedDataGridView.altDataGridViewCheckBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ExtendedDataGridView2 = New ExtendedDataGridView.ExtendedDataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New ExtendedDataGridView.altDataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ExtendedDataGridView3 = New ExtendedDataGridView.ExtendedDataGridView()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ExtendedDataGridView4 = New ExtendedDataGridView.ExtendedDataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.ExtendedDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.ExtendedDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.ExtendedDataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.ExtendedDataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(657, 511)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button4, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button3, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 468)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(651, 40)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button4.Location = New System.Drawing.Point(308, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 22)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "&Check Answers"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Location = New System.Drawing.Point(408, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(74, 22)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "&SaveAsCSV"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(488, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(74, 22)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(568, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 22)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "P&review"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Right-click grid for options..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(651, 459)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ExtendedDataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(643, 433)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Example 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ExtendedDataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExtendedDataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ExtendedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExtendedDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.ExtendedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExtendedDataGridView1.Location = New System.Drawing.Point(4, 4)
        Me.ExtendedDataGridView1.Name = "ExtendedDataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExtendedDataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedDataGridView1.Size = New System.Drawing.Size(635, 425)
        Me.ExtendedDataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Solve"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 300
        '
        'Column2
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "x = ?"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderStyle = ExtendedDataGridView.enumerations.style2.CheckAll
        Me.Column3.HeaderText = "Submit"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 75
        '
        'Column4
        '
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.Width = 25
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ExtendedDataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(643, 433)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Example 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ExtendedDataGridView2
        '
        Me.ExtendedDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExtendedDataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column7})
        Me.ExtendedDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExtendedDataGridView2.Location = New System.Drawing.Point(4, 4)
        Me.ExtendedDataGridView2.Name = "ExtendedDataGridView2"
        Me.ExtendedDataGridView2.Size = New System.Drawing.Size(635, 425)
        Me.ExtendedDataGridView2.TabIndex = 1
        '
        'Column5
        '
        Me.Column5.HeaderText = "Value"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.Width = 275
        '
        'Column6
        '
        Me.Column6.HeaderStyle = ExtendedDataGridView.enumerations.style1.HideColumn
        Me.Column6.HeaderText = "Sum"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.Width = 200
        '
        'Column7
        '
        Me.Column7.HeaderText = "Calculate"
        Me.Column7.Name = "Column7"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ExtendedDataGridView3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Size = New System.Drawing.Size(643, 433)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Example 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ExtendedDataGridView3
        '
        Me.ExtendedDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExtendedDataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column9})
        Me.ExtendedDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExtendedDataGridView3.Location = New System.Drawing.Point(4, 4)
        Me.ExtendedDataGridView3.Name = "ExtendedDataGridView3"
        Me.ExtendedDataGridView3.Size = New System.Drawing.Size(635, 425)
        Me.ExtendedDataGridView3.TabIndex = 1
        '
        'Column8
        '
        Me.Column8.HeaderText = "Search Engine"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 200
        '
        'Column9
        '
        Me.Column9.HeaderText = "Url"
        Me.Column9.Name = "Column9"
        Me.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column9.Width = 350
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ExtendedDataGridView4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage4.Size = New System.Drawing.Size(643, 433)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Example 4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ExtendedDataGridView4
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ExtendedDataGridView4.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.ExtendedDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExtendedDataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExtendedDataGridView4.Location = New System.Drawing.Point(4, 4)
        Me.ExtendedDataGridView4.Name = "ExtendedDataGridView4"
        Me.ExtendedDataGridView4.Size = New System.Drawing.Size(635, 425)
        Me.ExtendedDataGridView4.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 511)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmMain"
        Me.Text = "Extended DGV Demo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.ExtendedDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.ExtendedDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.ExtendedDataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.ExtendedDataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ExtendedDataGridView1 As ExtendedDataGridView.ExtendedDataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ExtendedDataGridView2 As ExtendedDataGridView.ExtendedDataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ExtendedDataGridView3 As ExtendedDataGridView.ExtendedDataGridView
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ExtendedDataGridView4 As ExtendedDataGridView.ExtendedDataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewComboBoxColumn
    Friend WithEvents Column3 As ExtendedDataGridView.altDataGridViewCheckBoxColumn
    Friend WithEvents Column4 As DataGridViewImageColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As ExtendedDataGridView.altDataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewButtonColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewLinkColumn
End Class
