Imports System.IO
Imports Aspose.PDF.Text

Module Module1
    Public Sub SaveToExcel(asposeFilePdf As String, asposeFileXls As String, excelSaveOption As ExcelSaveOptions)
        Dim pdfDocument = New Document(filename:=asposeFilePdf)
        pdfDocument.Save(asposeFileXls, excelSaveOption)
    End Sub

    Sub AddInvoiceData(asposeFilePdf As String)
        'Create New a PDF document
        Dim document = New Document()
        '-----------------------------------            
        Dim pdfPage = document.Pages.Add()

        ' Initializes a New instance of the Table
        Dim table = New Table()
        ' Set column auto widths of the table
        table.ColumnWidths = "10 10 10 10 10"
        table.ColumnAdjustment = ColumnAdjustment.AutoFitToContent
        ' Set cell padding
        table.DefaultCellPadding = New MarginInfo(5, 5, 5, 5)
        ' Set the table border color as Black
        table.Border = New BorderInfo(BorderSide.All, 0.5F, Color.Black)
        ' Set the border for table cells as Black
        table.DefaultCellBorder = New BorderInfo(BorderSide.All, 0.2F, Color.Black)
        table.DefaultCellTextState = New TextState("TimesNewRoman", 10)

        Dim paymentFormat = New TextState("TimesNewRoman", 10)
        paymentFormat.HorizontalAlignment = HorizontalAlignment.Right

        table.SetColumnTextState(2, paymentFormat)
        table.SetColumnTextState(4, paymentFormat)
        table.ImportDataTable(GenerateDataTable(), True, 0, 1, 5, 5)

        'Repeat Header
        table.RepeatingRowsCount = 1

        ' Add table object to first page of input document
        pdfPage.Paragraphs.Add(table)

        Dim streamOut = New FileStream(asposeFilePdf, FileMode.OpenOrCreate)
        document.Save(streamOut)
        streamOut.Close()
    End Sub
    Function GenerateDataTable() As DataTable
        Dim dt = New DataTable("InovoiceItems")
        dt.Columns.Add("ID", Type.GetType("System.Int32"))
        dt.Columns.Add("ItemName", Type.GetType("System.String"))
        dt.Columns.Add("Price", Type.GetType("System.Single"))
        dt.Columns.Add("Qunatity", Type.GetType("System.Int32"))
        dt.Columns.Add("Summa", Type.GetType("System.Single"))

        ' Add 5 rows into the DataTable object programmatically
        Dim dr = dt.NewRow()
        For i = 1 To 5
            dr(0) = i
            dr(1) = "Sun Glasses Type " & i
            dr(2) = 199.99
            dr(3) = 1
            dr(4) = 199.99
            dt.Rows.Add(dr)
            dr = dt.NewRow()
        Next
        GenerateDataTable = dt

    End Function
End Module