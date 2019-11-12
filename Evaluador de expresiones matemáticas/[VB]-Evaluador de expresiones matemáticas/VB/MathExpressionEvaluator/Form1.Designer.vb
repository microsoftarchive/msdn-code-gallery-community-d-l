<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtExpression = New System.Windows.Forms.TextBox()
        Me.btnEvaluate = New System.Windows.Forms.Button()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtExpression
        '
        Me.txtExpression.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpression.Location = New System.Drawing.Point(29, 40)
        Me.txtExpression.Name = "txtExpression"
        Me.txtExpression.Size = New System.Drawing.Size(187, 29)
        Me.txtExpression.TabIndex = 0
        '
        'btnEvaluate
        '
        Me.btnEvaluate.Location = New System.Drawing.Point(240, 46)
        Me.btnEvaluate.Name = "btnEvaluate"
        Me.btnEvaluate.Size = New System.Drawing.Size(75, 23)
        Me.btnEvaluate.TabIndex = 1
        Me.btnEvaluate.Text = "Evaluar"
        Me.btnEvaluate.UseVisualStyleBackColor = True
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultado.Location = New System.Drawing.Point(26, 128)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(0, 24)
        Me.lblResultado.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 234)
        Me.Controls.Add(Me.lblResultado)
        Me.Controls.Add(Me.btnEvaluate)
        Me.Controls.Add(Me.txtExpression)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtExpression As System.Windows.Forms.TextBox
    Friend WithEvents btnEvaluate As System.Windows.Forms.Button
    Friend WithEvents lblResultado As System.Windows.Forms.Label

End Class
