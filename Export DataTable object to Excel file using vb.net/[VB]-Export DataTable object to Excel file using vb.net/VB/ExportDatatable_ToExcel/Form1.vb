Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Public Class Form1

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        'Using save file dialog that allow you to chosse the file name.
        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Excel File|*.xls"
        objDlg.OverwritePrompt = False
        If objDlg.ShowDialog = DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            ExportToExcel(GetDatatable(), filepath)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set the datatable to DataGridView1's datasorurce property
        DataGridView1.DataSource = GetDatatable()

    End Sub
    Private Function GetDatatable() As DataTable
        'Create the data table at runtime
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("Name")

        dt.Rows.Add()
        dt.Rows(0)(0) = "1"
        dt.Rows(0)(1) = "David"

        dt.Rows.Add()
        dt.Rows(1)(0) = "2"
        dt.Rows(1)(1) = "Ram"

        dt.Rows.Add()
        dt.Rows(2)(0) = "3"
        dt.Rows(2)(1) = "John"
        Return dt
    End Function
    Private Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            If (MessageBox.Show("Do you want to replace from the existing file?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
                System.IO.File.Delete(strFileName)
            Else
                Return
            End If
       
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        ' export the Columns 
        If CheckBox1.Checked Then
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(1, colIndex) = dc.ColumnName
            Next
        End If

        'export the rows 
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        MessageBox.Show("File Export Successfully!")
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
End Class
