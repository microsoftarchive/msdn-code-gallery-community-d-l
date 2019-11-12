Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dops As New DataOperations With
            {
                .ExcelFileName = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleData.xlsx"),
                .CsvFileName = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "People.csv"),
                .SheetName = "People2"
            }

        If dops.GetSheetData Then
            If dops.ExportToCsv() Then
                MessageBox.Show("CSV created")
            Else
                MessageBox.Show("Failed to create CSV")
            End If
        Else
            MessageBox.Show("Failed to get sheet data")
        End If
    End Sub
End Class
