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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdInsertRow = New System.Windows.Forms.Button()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdDeleteCurrentRow = New System.Windows.Forms.Button()
        Me.cmdGetCurrentRow = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdUpdateCurrent = New System.Windows.Forms.Button()
        Me.txtNewLastName = New System.Windows.Forms.TextBox()
        Me.txtNewFirstName = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lblAddress)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 212)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(623, 337)
        Me.Panel1.TabIndex = 1
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(24, 288)
        Me.lblAddress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(60, 17)
        Me.lblAddress.TabIndex = 2
        Me.lblAddress.Text = "Address"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.SeaShell
        Me.GroupBox2.Controls.Add(Me.txtLength)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmdInsertRow)
        Me.GroupBox2.Controls.Add(Me.txtLastName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtFirstName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 7)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(601, 138)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add new row"
        '
        'txtLength
        '
        Me.txtLength.Location = New System.Drawing.Point(381, 46)
        Me.txtLength.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.ReadOnly = True
        Me.txtLength.Size = New System.Drawing.Size(123, 22)
        Me.txtLength.TabIndex = 3
        Me.txtLength.Text = "500"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(321, 49)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Length"
        '
        'cmdInsertRow
        '
        Me.cmdInsertRow.Location = New System.Drawing.Point(16, 97)
        Me.cmdInsertRow.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdInsertRow.Name = "cmdInsertRow"
        Me.cmdInsertRow.Size = New System.Drawing.Size(100, 28)
        Me.cmdInsertRow.TabIndex = 6
        Me.cmdInsertRow.Text = "Insert"
        Me.cmdInsertRow.UseVisualStyleBackColor = True
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(63, 65)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(240, 22)
        Me.txtLastName.TabIndex = 5
        Me.txtLastName.Text = "Brown"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Last"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(63, 25)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(240, 22)
        Me.txtFirstName.TabIndex = 1
        Me.txtFirstName.Text = "Mary"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Bisque
        Me.GroupBox1.Controls.Add(Me.cmdDeleteCurrentRow)
        Me.GroupBox1.Controls.Add(Me.cmdGetCurrentRow)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmdUpdateCurrent)
        Me.GroupBox1.Controls.Add(Me.txtNewLastName)
        Me.GroupBox1.Controls.Add(Me.txtNewFirstName)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 154)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(599, 129)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update current record"
        '
        'cmdDeleteCurrentRow
        '
        Me.cmdDeleteCurrentRow.Location = New System.Drawing.Point(510, 73)
        Me.cmdDeleteCurrentRow.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDeleteCurrentRow.Name = "cmdDeleteCurrentRow"
        Me.cmdDeleteCurrentRow.Size = New System.Drawing.Size(69, 54)
        Me.cmdDeleteCurrentRow.TabIndex = 7
        Me.cmdDeleteCurrentRow.Text = "Delete"
        Me.cmdDeleteCurrentRow.UseVisualStyleBackColor = True
        '
        'cmdGetCurrentRow
        '
        Me.cmdGetCurrentRow.Location = New System.Drawing.Point(510, 15)
        Me.cmdGetCurrentRow.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdGetCurrentRow.Name = "cmdGetCurrentRow"
        Me.cmdGetCurrentRow.Size = New System.Drawing.Size(69, 54)
        Me.cmdGetCurrentRow.TabIndex = 2
        Me.cmdGetCurrentRow.Text = "Get"
        Me.cmdGetCurrentRow.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 59)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Last"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "First"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 79)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Values are intentionally blank"
        '
        'cmdUpdateCurrent
        '
        Me.cmdUpdateCurrent.Location = New System.Drawing.Point(19, 98)
        Me.cmdUpdateCurrent.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdUpdateCurrent.Name = "cmdUpdateCurrent"
        Me.cmdUpdateCurrent.Size = New System.Drawing.Size(100, 28)
        Me.cmdUpdateCurrent.TabIndex = 6
        Me.cmdUpdateCurrent.Text = "Update"
        Me.cmdUpdateCurrent.UseVisualStyleBackColor = True
        '
        'txtNewLastName
        '
        Me.txtNewLastName.Location = New System.Drawing.Point(63, 50)
        Me.txtNewLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNewLastName.Name = "txtNewLastName"
        Me.txtNewLastName.Size = New System.Drawing.Size(240, 22)
        Me.txtNewLastName.TabIndex = 3
        '
        'txtNewFirstName
        '
        Me.txtNewFirstName.Location = New System.Drawing.Point(63, 21)
        Me.txtNewFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNewFirstName.Name = "txtNewFirstName"
        Me.txtNewFirstName.Size = New System.Drawing.Size(240, 22)
        Me.txtNewFirstName.TabIndex = 1
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
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(623, 212)
        Me.DataGridView1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 549)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdInsertRow As System.Windows.Forms.Button
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdUpdateCurrent As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNewFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtNewLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents cmdGetCurrentRow As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteCurrentRow As System.Windows.Forms.Button
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
