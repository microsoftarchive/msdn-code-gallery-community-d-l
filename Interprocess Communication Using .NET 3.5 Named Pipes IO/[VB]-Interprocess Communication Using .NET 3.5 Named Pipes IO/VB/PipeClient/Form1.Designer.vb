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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbClientText = New System.Windows.Forms.TextBox
        Me.button1 = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tbStatus = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 22)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter text to send to PipeServer:"
        '
        'tbClientText
        '
        Me.tbClientText.Location = New System.Drawing.Point(5, 28)
        Me.tbClientText.Name = "tbClientText"
        Me.tbClientText.Size = New System.Drawing.Size(280, 20)
        Me.tbClientText.TabIndex = 1
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(5, 55)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 2
        Me.button1.Text = "Send"
        Me.button1.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(87, 55)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tbStatus
        '
        Me.tbStatus.AutoSize = True
        Me.tbStatus.Location = New System.Drawing.Point(5, 97)
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(0, 13)
        Me.tbStatus.TabIndex = 4
        '
        'Form1
        '
        Me.AcceptButton = Me.button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(292, 116)
        Me.Controls.Add(Me.tbStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.tbClientText)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Pipe Client"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbClientText As System.Windows.Forms.TextBox
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tbStatus As System.Windows.Forms.Label

End Class
