Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ops As New ExportOperations
        ops.ExportData()
        If ops.HasErrors Then
            MessageBox.Show($"Failed: {ops.ExeptionMessage}")
        Else
            MessageBox.Show($"Done: inserted {ops.RecordsInserted} records.")
        End If
    End Sub
End Class
