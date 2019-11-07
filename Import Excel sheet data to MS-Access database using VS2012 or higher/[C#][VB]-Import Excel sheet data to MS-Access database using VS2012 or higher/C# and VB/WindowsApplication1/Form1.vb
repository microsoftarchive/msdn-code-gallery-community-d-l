Public Class Form1
    Private AccessFile As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    Private ExcelFile As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx")

    ''' <summary>
    ''' Import sheet data from Excel to ms-access only if the table name does
    ''' not already exists.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdRun_Click(sender As Object, e As EventArgs) Handles cmdRunDoNotOverWrite.Click

        ' Setup for import operation. Note if FieldNames is not set * is the default
        Dim ImportData As New Importer(
            New ExcelInfo With
                {
                    .FileName = ExcelFile,
                    .HasHeaders = True,
                    .SheetName = "Customers"
                },
            New AccessInfo With
                {
                    .FileName = AccessFile,
                    .TableName = "Customers1",
                    .FieldNames = "CompanyName,ContactName"
                }
            )

        ' Run the import operation and report back results
        If ImportData.Run Then
            MessageBox.Show("Imported " & ImportData.RecordCount.ToString)
            ListBox1.Items.Add(ImportData.AccessInformation.TableName)
        Else
            If ImportData.ExceptionWasThrown Then
                MessageBox.Show(ImportData.Exception.Message)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Import sheet data from Excel to ms-access, if table exists
    ''' drop the table then do the import
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdOverWrite_Click(sender As Object, e As EventArgs) Handles cmdOverWrite.Click
        ' Setup for import operation. Note if FieldNames is not set * is the default
        Dim ImportData As New Importer(
            New ExcelInfo With
                {
                    .FileName = ExcelFile,
                    .HasHeaders = True,
                    .SheetName = "Customers"
                },
            New AccessInfo With
                {
                    .FileName = AccessFile,
                    .TableName = "Customers31",
                    .FieldNames = "CompanyName,ContactName"
                }
            )

        ImportData.OverWriteExisting = True

        ' Run the import operation and report back results
        If ImportData.Run Then

            MessageBox.Show("Imported " & ImportData.RecordCount.ToString)

            If Not ListBox1.Items.Contains(ImportData.AccessInformation.TableName) Then
                ListBox1.Items.Add(ImportData.AccessInformation.TableName)
            End If

        Else

            If ImportData.ExceptionWasThrown Then
                MessageBox.Show(ImportData.Exception.Message)
            End If

        End If
    End Sub
    ''' <summary>
    ''' This might be of use to show we can get existing table names
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ImportData As New Importer

        ImportData.AccessInformation =
            New AccessInfo With {.FileName = AccessFile}

        For Each table In ImportData.ExistsingTableNames
            ListBox1.Items.Add(table)
        Next
    End Sub
End Class
