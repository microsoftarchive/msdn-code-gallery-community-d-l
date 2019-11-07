Imports Microsoft.JScript.Vsa
Imports Microsoft.JScript

Public Class Form1


    Private Function EvalExpression(expression As String) As String
        Dim engine As VsaEngine = VsaEngine.CreateEngine()
        Try
            Dim o As Object = Eval.JScriptEvaluate(txtExpression.Text, engine)
            Return System.Convert.ToDouble(o).ToString()
        Catch
            Return "No se puede evaluar la expresión"
        End Try
        engine.Close()
    End Function

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs) Handles btnEvaluate.Click
        lblResultado.Text = EvalExpression(txtExpression.Text)
    End Sub

End Class
