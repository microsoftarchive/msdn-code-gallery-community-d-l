<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraph
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGridSpacing = New System.Windows.Forms.TextBox()
        Me.picGraph = New System.Windows.Forms.PictureBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnGraph = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMinValue = New System.Windows.Forms.TextBox()
        Me.txtMaxValue = New System.Windows.Forms.TextBox()
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter The Horrizontal Grid Lines Spacing Value : "
        '
        'txtGridSpacing
        '
        Me.txtGridSpacing.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGridSpacing.Location = New System.Drawing.Point(340, 10)
        Me.txtGridSpacing.Name = "txtGridSpacing"
        Me.txtGridSpacing.Size = New System.Drawing.Size(450, 24)
        Me.txtGridSpacing.TabIndex = 0
        '
        'picGraph
        '
        Me.picGraph.Image = Global.DynamicGraphVBApp.My.Resources.Resources.Whitebackground
        Me.picGraph.Location = New System.Drawing.Point(18, 42)
        Me.picGraph.Name = "picGraph"
        Me.picGraph.Size = New System.Drawing.Size(771, 419)
        Me.picGraph.TabIndex = 2
        Me.picGraph.TabStop = False
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(19, 510)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(629, 17)
        Me.txtStatus.TabIndex = 3
        '
        'btnGraph
        '
        Me.btnGraph.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGraph.Location = New System.Drawing.Point(564, 506)
        Me.btnGraph.Name = "btnGraph"
        Me.btnGraph.Size = New System.Drawing.Size(133, 29)
        Me.btnGraph.TabIndex = 3
        Me.btnGraph.Text = "Draw Graph"
        Me.btnGraph.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(200, 475)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(325, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Enter The Range Of Values To Plot The Graph : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 509)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Min Value : (>-10 && <0)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(276, 511)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Max Value : (>0 && < 10)"
        '
        'txtMinValue
        '
        Me.txtMinValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinValue.Location = New System.Drawing.Point(186, 508)
        Me.txtMinValue.Name = "txtMinValue"
        Me.txtMinValue.Size = New System.Drawing.Size(84, 24)
        Me.txtMinValue.TabIndex = 1
        '
        'txtMaxValue
        '
        Me.txtMaxValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxValue.Location = New System.Drawing.Point(444, 508)
        Me.txtMaxValue.Name = "txtMaxValue"
        Me.txtMaxValue.Size = New System.Drawing.Size(100, 24)
        Me.txtMaxValue.TabIndex = 2
        '
        'frmGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(806, 548)
        Me.Controls.Add(Me.txtMaxValue)
        Me.Controls.Add(Me.txtMinValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGraph)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.picGraph)
        Me.Controls.Add(Me.txtGridSpacing)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGraph"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dynamic Graph Plotter"
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGridSpacing As System.Windows.Forms.TextBox
    Friend WithEvents picGraph As System.Windows.Forms.PictureBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnGraph As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMinValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxValue As System.Windows.Forms.TextBox

End Class
