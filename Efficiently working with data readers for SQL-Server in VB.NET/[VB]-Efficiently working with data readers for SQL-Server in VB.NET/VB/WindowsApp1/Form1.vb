Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ops As New DataOperations
        Dim dt As DataTable = ops.CustomerView
        If Not ops.IsSuccessFul Then
            If ops.HasSqlException Then
                MessageBox.Show($"Data error: {ops.LastSqlException.Message}")
            ElseIf ops.HasException Then
                MessageBox.Show($"General error: {ops.LastException.Message}")
            End If
        End If
    End Sub
End Class
