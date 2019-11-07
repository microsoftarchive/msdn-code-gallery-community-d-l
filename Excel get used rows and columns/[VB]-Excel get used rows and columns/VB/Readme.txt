Shows how to get used rows/columns in a worksheet.

* Function UsedInformation(ByVal FileName As String, ByVal Sheets As List(Of String)) As List(Of ExcelInfo)
  This method uses one OleDb connection for a list of sheets

* Public Function UsedInformation(ByVal FileName As String, ByVal SheetName As String) As ExcelInfo
  Good for one sheet, can be used in a loop as shown in Form1 but then you open the file for each sheet.

* Function UsedRows(ByVal FileName As String, ByVal SheetName As String) As Integer
  Simply gets the last used row for a sheet.

* Function UsedRows_Columns(ByVal FileName As String, ByVal SheetName As String) As Tuple(Of Int32, Int32)
  Same as second item above but Tuple is harder to read return values as in simply looking at them

All routines follow the two-dot-rule
http://www.siddharthrout.com/2012/08/06/vb-net-two-dot-rule-when-working-with-office-applications-2/


Changes
12/08/2013 Added ExcelUsedColumnsLib project. Demo from Form1.cmdMultipleDemo which shows how to get last row for
           individual columns.



