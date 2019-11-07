Imports Operations
Public Class Form1
    Private CompanyFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx")
    ''' <summary>
    ''' Export all data to Excel into Customers.xlsx
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub selectAllButton_Click(sender As Object, e As EventArgs) Handles selectAllButton.Click
        Dim ops As New SqlServerOperations

        If CreateNewExcelFileCheckBox.Checked Then
            If Not ops.CopyToApplicationFolder(CompanyFileName) Then
                MessageBox.Show(ops.ExceptionMessage)
                Exit Sub
            End If
        End If

        Dim RowCount As Integer = 0
        If ops.ExportAllCustomersToExcel(CompanyFileName, RowCount) Then
            MessageBox.Show($"Exported {RowCount} rows.")
        Else
            MessageBox.Show(ops.ExceptionMessage)
        End If

    End Sub
    ''' <summary>
    ''' Export by country name, file name will be based on the selected country name
    ''' with spaces and ' char removed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub selectByCountryButton_Click(sender As Object, e As EventArgs) Handles selectByCountryButton.Click

        If countriesCombox.Text = "Select" Then
            MessageBox.Show("Please select a country")
            Exit Sub
        End If

        Dim ops As New SqlServerOperations

        Dim item = CType(countriesCombox.SelectedItem, CountryItem)
        Dim DestinationFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{item.Compact}.xlsx")

        If CreateNewExcelFileCheckBox.Checked Then
            If Not ops.CopyToApplicationFolder(CompanyFileName, DestinationFileName) Then
                MessageBox.Show("Copy failed")
                Exit Sub
            End If
        End If

        Dim RowCount As Integer = 0
        If ops.ExportByCountryNameCustomersToExcel(DestinationFileName, countriesCombox.Text, RowCount) Then
            MessageBox.Show($"Exported {RowCount} rows.")
        Else
            MessageBox.Show(ops.ExceptionMessage)
        End If

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ops As New SqlServerOperations
        countriesCombox.DataSource = ops.CountryList
        countriesCombox.DisplayMember = "Name"
    End Sub
End Class
