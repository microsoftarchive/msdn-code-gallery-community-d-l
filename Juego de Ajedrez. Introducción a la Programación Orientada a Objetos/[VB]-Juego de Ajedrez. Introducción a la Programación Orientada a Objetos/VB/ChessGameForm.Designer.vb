<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChessGameForm
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
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblWin = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.radioBlack = New System.Windows.Forms.RadioButton()
        Me.radioWhite = New System.Windows.Forms.RadioButton()
        Me.panelBoard = New System.Windows.Forms.Panel()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.lblWin)
        Me.groupBox1.Controls.Add(Me.btnStart)
        Me.groupBox1.Controls.Add(Me.radioBlack)
        Me.groupBox1.Controls.Add(Me.radioWhite)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.groupBox1.Location = New System.Drawing.Point(563, 0)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(158, 487)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Jugador arriba"
        '
        'lblWin
        '
        Me.lblWin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWin.Location = New System.Drawing.Point(22, 156)
        Me.lblWin.Name = "lblWin"
        Me.lblWin.Size = New System.Drawing.Size(111, 120)
        Me.lblWin.TabIndex = 3
        Me.lblWin.Text = "Blancas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ganan"
        Me.lblWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWin.Visible = False
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(16, 92)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(118, 31)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Reiniciar"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'radioBlack
        '
        Me.radioBlack.AutoSize = True
        Me.radioBlack.Location = New System.Drawing.Point(16, 52)
        Me.radioBlack.Name = "radioBlack"
        Me.radioBlack.Size = New System.Drawing.Size(59, 17)
        Me.radioBlack.TabIndex = 1
        Me.radioBlack.Text = "Negras"
        Me.radioBlack.UseVisualStyleBackColor = True
        '
        'radioWhite
        '
        Me.radioWhite.AutoSize = True
        Me.radioWhite.Checked = True
        Me.radioWhite.Location = New System.Drawing.Point(16, 29)
        Me.radioWhite.Name = "radioWhite"
        Me.radioWhite.Size = New System.Drawing.Size(63, 17)
        Me.radioWhite.TabIndex = 0
        Me.radioWhite.TabStop = True
        Me.radioWhite.Text = "Blancas"
        Me.radioWhite.UseVisualStyleBackColor = True
        '
        'panelBoard
        '
        Me.panelBoard.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelBoard.Location = New System.Drawing.Point(0, 0)
        Me.panelBoard.Name = "panelBoard"
        Me.panelBoard.Size = New System.Drawing.Size(553, 487)
        Me.panelBoard.TabIndex = 2
        '
        'ChessGameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 487)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.panelBoard)
        Me.MinimumSize = New System.Drawing.Size(520, 320)
        Me.Name = "ChessGameForm"
        Me.Text = "Chess"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents groupBox1 As GroupBox
    Private WithEvents lblWin As Label
    Private WithEvents btnStart As Button
    Private WithEvents radioBlack As RadioButton
    Private WithEvents radioWhite As RadioButton
    Private WithEvents panelBoard As Panel
End Class
