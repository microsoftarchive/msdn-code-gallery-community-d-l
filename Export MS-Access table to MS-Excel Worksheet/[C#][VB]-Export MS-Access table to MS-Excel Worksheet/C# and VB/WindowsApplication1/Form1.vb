Imports AccessConnections_vb
Imports ExportAccessToExcel_vb
Imports ExcelOleDbLibrary
Imports Cue_BannerLibrary

Public Class Form1

    WithEvents bsTables As New BindingSource
    Private msAccessFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NorthWind.accdb")
    Private ops As New AccessInformation

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bsTables.DataSource = ops.TableNames(msAccessFileName)
        ListBox1.DataSource = bsTables

        ops.GetTableColumnInformation(msAccessFileName)

        AddHandler bsTables.PositionChanged, AddressOf bsCustomers_PositionChanged

        txtWorkSheetName.SetCueText("Enter a Worksheet name")

    End Sub
    Private Sub bsCustomers_PositionChanged(sender As Object, e As EventArgs)
        updateCheckListBox()
    End Sub
    Private Sub updateCheckListBox()
        CheckedListBox1.Items.Clear()
        Dim ColumnNames As List(Of String) = ops.ColumnDict(ListBox1.Text)
        For Each col In ColumnNames
            CheckedListBox1.Items.Add(col)
        Next
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        updateCheckListBox()
    End Sub
    ''' <summary>
    ''' For a real project you would prompt for a Excel and MS-Access files.
    ''' When doing so you need to make sure that 
    ''' If selecting a .xls file it must match up with a .mdb
    ''' If selecting a .xlsx file it must match up to a .accdb
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If String.IsNullOrWhiteSpace(txtWorkSheetName.Text) Then
            MessageBox.Show("Please enter a valid worksheet name")
            Exit Sub
        End If

        ' file to export too
        Dim excelFile As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel1111.xlsx")
        ' create a dynamic connection for our Excel file to get sheet names
        Dim cons As Connections = New Connections
        ' this class gets sheet names from excelFile
        Dim utls As New Utility

        ' determine if sheet exists
        If Not utls.SheetNames(cons.NoHeaderConnectionString(excelFile)).Where(Function(sheet) sheet.DisplayName.ToLower = txtWorkSheetName.Text.ToLower).Any Then
            ' prepare for export 
            ' current Header property is ignored
            Dim ops As New ExportToExcel With
            {
                .DatabaseName = msAccessFileName,
                .Headers = False,
                .ExcelFileName = excelFile,
                .TableName = ListBox1.Text,
                .WorkSheetName = txtWorkSheetName.Text
            }

            Dim Success As Boolean = False
            '
            ' Export either all fields or selected fields from CheckListBox.
            ' I wrote comments in the Try/Catch for the Execute method about some fields may cause an exception
            '
            If CheckedListBox1.CheckedItems.Count > 0 Then
                Success = ops.Execute(CheckedListBox1.SelectColumns)
            Else
                Success = ops.Execute()
            End If

            ' indicate how many records were exported or show and exception message
            If Success Then
                MessageBox.Show($"Exported {ops.RecordsInserted}")
            Else
                MessageBox.Show($"Failed: {ops.ExceptionMessage}")
            End If

        Else
            MessageBox.Show($"{txtWorkSheetName.Text} already exist, aborted.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        txtWorkSheetName.Text = ListBox1.Text
    End Sub
End Class
