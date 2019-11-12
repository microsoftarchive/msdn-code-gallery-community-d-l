' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Windows.Forms
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel
 
Class OrderingSheet
    Friend Enum StatHeadings
        DailySales = 0
        Required
        CurrentInventory
        ProjectInventory
        OrderQuanity
    End Enum

    Private headers() As String = _
    { _
        My.Resources.MaxDailySalesHeader, _
        My.Resources.ProjectedSalesHeader, _
        My.Resources.CurrentInventoryHeader, _
        My.Resources.ProjectedInventoryHeader, _
        My.Resources.OrderQuantityHeader _
    }

    Dim deliveryDate As DateTime

    Dim nextScheduledDeliveryDate As DateTime

    Dim orderDate As DateTime

    Dim worksheet As Excel.Worksheet

    Const orderDateAddress As String = "$B$4"
    Const pivotTableAddress As String = "$B$10"

    Public Sub New(ByVal isUnscheduled As Boolean)
        If (Not Globals.DataSet.IsLastDayComplete()) Then
            Throw New ApplicationException(Globals.ThisWorkbook.IncompleteDataMessage)
        End If

        Me.orderDate = Globals.DataSet.MaxDate

        Dim worksheetName As String

        If (isUnscheduled) Then
            worksheetName = ExcelHelpers.CreateValidWorksheetName(String.Format(CultureInfo.CurrentUICulture, My.Resources.UnscheduledOrderSheetName, Me.orderDate.ToShortDateString()))
            nextScheduledDeliveryDate = ComputeWeeklyDeliveryDate()
        Else
            worksheetName = ExcelHelpers.CreateValidWorksheetName(String.Format(CultureInfo.CurrentUICulture, My.Resources.WeeklyOrderSheetName, Me.orderDate.ToShortDateString()))
            nextScheduledDeliveryDate = deliveryDate.AddDays(7)
        End If

        Dim worksheet As Excel.Worksheet = Nothing

        ' Worksheet creation will throw an exception if the name already exists.
        Try
            worksheet = ThisWorkbook.CreateWorksheet(worksheetName)
        Catch ex As Exception
            Dim message As String

            If isUnscheduled Then
                message = String.Format(CultureInfo.CurrentUICulture, My.Resources.UnscheduledOrderSheetCreationError, worksheetName)
            Else
                message = String.Format(CultureInfo.CurrentUICulture, My.Resources.WeeklyOrderSheetCreationError, worksheetName)
            End If

            Throw New ApplicationException(message, ex)
        End Try

        Me.worksheet = worksheet

        CreateOrder(isUnscheduled)
    End Sub

    Private Function ComputeUnscheduledDeliveryDate() As DateTime
        Return Me.orderDate.AddDays(1).Date
    End Function

    Private Function ComputeWeeklyDeliveryDate() As DateTime
        Return Globals.DataSet.NextWeeklyDeliveryDate
    End Function

    Private Sub CreateOrder(ByVal isUnscheduled As Boolean)
        If (isUnscheduled) Then
            Me.deliveryDate = ComputeUnscheduledDeliveryDate()
        Else
            Me.deliveryDate = ComputeWeeklyDeliveryDate()
        End If

        ' This creates a PivotTable with information regarding the 
        ' amounts of ice cream sold.
        Me.PopulateDateInformation(Me.orderDate)

        Dim pivotTable As Excel.PivotTable = Me.CreatePivotTable()

        Me.AddCalculations(pivotTable)

    End Sub

    Private Sub AddCalculations(ByVal pivotTable As Excel.PivotTable)
        ' Activates the worksheet in case it isn't
        ' currently active.

        ' Gets the ranges that make up the PivotTable.
        Dim tableRange As Excel.Range = pivotTable.TableRange1
        Dim dataRange As Excel.Range = pivotTable.DataBodyRange

        ' Gets each of the columns that needs to be added after the
        ' PivotTable.
        Dim values As System.Array = System.Enum.GetValues(GetType(StatHeadings))

        ' Determines upper left cell of the PivotTable.
        Dim tableStartCell As Excel.Range = ExcelHelpers.GetCellFromRange(tableRange, 1, 1)

        ' Gets the first available cell in the appropriate row at the
        ' end of the PivotTable.
        Dim nextHeader As Excel.Range = tableStartCell.End(Excel.XlDirection.xlDown).End(Excel.XlDirection.xlToRight).End(Excel.XlDirection.xlUp).Next

        ' Determines the boundary cells that make up the calculated fields
        ' for the current column.
        Dim colStart As Excel.Range = ExcelHelpers.GetCellFromRange(nextHeader, 2, 1)

        Dim colEnd As Excel.Range = colStart.Offset(dataRange.Rows.Count - 1, 0)

        ' For each of the columns that need to be added,
        ' populates its stats and headings.

        Dim i As Integer
        For Each i In values
            nextHeader.Value2 = Me.headers(i)
            Me.PopulateStatColumn(i, colStart, colEnd)
            nextHeader = nextHeader.Next
            colStart = colStart.Next
            colEnd = colEnd.Next
        Next
    End Sub

    Private Sub PopulateStatColumn(ByVal column As Integer, ByVal startCell As Excel.Range, ByVal endCell As Excel.Range)
        Try
            ' Determines the range that needs to get filled with data.
            Dim twoLines As Excel.Range = startCell.Resize(2, 1)

            twoLines.Merge(System.Type.Missing)

            Dim fillRange As Excel.Range = Me.worksheet.Range(startCell, endCell)
            endCell.Select()

            Select Case column
                Case StatHeadings.DailySales
                    ' Fills in the daily sales column.
                    ' Gets the addresses of the cells containing the
                    ' standard deviation and average.
                    Dim average As Excel.Range = startCell.Previous
                    Dim averageAddress As String = average.Address(False, False, Excel.XlReferenceStyle.xlA1)
                    Dim standardDev As Excel.Range = average.Offset(1, 0)
                    Dim standardDevAddress As String = standardDev.Address(False, False, Excel.XlReferenceStyle.xlA1)

                    ' Sets the formulas for the column.
                    startCell.Formula = "=" + averageAddress + "+ (2*" + standardDevAddress + ")"

                    ' Format "0.00" - two decimal places.
                    startCell.NumberFormat = "0.00"
                    twoLines.AutoFill(fillRange, Excel.XlAutoFillType.xlFillDefault)
                    Exit Select

                Case StatHeadings.Required
                    ' Fills in the required column.
                    ' Determines the address for the cell containing
                    ' the expected sales.
                    Dim expectedSales As Excel.Range = startCell.Previous
                    Dim salesAddress As String = expectedSales.Address(False, False, Excel.XlReferenceStyle.xlA1)

                    ' Determines how much inventory is required 
                    ' until delivery.
                    ' Determines the number of days until delivery.
                    Dim waitDays As Integer = Me.GetDaysToDelivery()

                    startCell.Formula = "=" + waitDays.ToString() + "*" + salesAddress

                    ' Format "0.00" - two decimal places.
                    startCell.NumberFormat = "0.00"
                    twoLines.AutoFill(fillRange, Excel.XlAutoFillType.xlFillDefault)

                Case StatHeadings.CurrentInventory
                    ' Fills in the current inventory column.
                    ' Gets the range for the last day from the journal.
                    Dim count As Integer = (endCell.Row - startCell.Row + 1) \ 2
                    Dim currentCell As Excel.Range = startCell

                    For row As Integer = 0 To count - 1
                        Dim flavorCell As Excel.Range = currentCell.Offset(0, 0 - 5)


                        Dim flavor As String = ExcelHelpers.GetValueAsString(flavorCell)
                        Dim inventory As Integer

                        inventory = Globals.DataSet.Sales.FindBy_DateFlavor(Globals.DataSet.MaxDate, flavor).Inventory

                        currentCell.Value2 = inventory

                        If (row <> 0) Then
                            Dim twoCells As Excel.Range = currentCell.Resize(2, 1)

                            twoCells.Merge(System.Type.Missing)
                            currentCell = twoCells
                        End If

                        currentCell = currentCell.Offset(1, 0)
                    Next
                    Exit Select

                Case StatHeadings.ProjectInventory

                    ' Gets the addresses for the projected sales and
                    ' current inventory.
                    Dim currentInventory As Excel.Range = startCell.Previous
                    Dim required As Excel.Range = currentInventory.Previous
                    Dim currentInventoryAddress As String = currentInventory.Address(False, False, Excel.XlReferenceStyle.xlA1)
                    Dim requiredAddress As String = required.Address(False, False, Excel.XlReferenceStyle.xlA1)

                    ' Determines the inventory expected on the 
                    ' delivery date.
                    startCell.Formula = "=MAX(0," + currentInventoryAddress + "-" + requiredAddress + ")"

                    ' Format "0.00" - two decimal places.
                    startCell.NumberFormat = "0.00"
                    twoLines.AutoFill(fillRange, Excel.XlAutoFillType.xlFillDefault)
                    Exit Select

                Case StatHeadings.OrderQuanity
                    ' Determines the addresses for the projected inventory
                    ' and the required amounts.
                    Dim projectedInventory As Excel.Range = startCell.Previous
                    Dim needed As Excel.Range = projectedInventory.Previous.Previous
                    Dim projectedInventoryAddress As String = projectedInventory.Address(False, False, Excel.XlReferenceStyle.xlA1)
                    Dim neededAddress As String = needed.Address(False, False, Excel.XlReferenceStyle.xlA1)

                    ' Determines the order size needed for each item.
                    startCell.Formula = "=" + neededAddress + "-" + projectedInventoryAddress

                    ' Format "0.00" - two decimal places.
                    startCell.NumberFormat = "0.00"
                    twoLines.AutoFill(fillRange, Excel.XlAutoFillType.xlFillDefault)
                    Exit Select

                Case Else
                    Exit Select
            End Select
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            Throw
        End Try
    End Sub

    Private Function GetDaysToDelivery() As Integer

        ' This method determines the number of days
        ' till the next scheduled delivery.
        'This is needed to estimate for how many days the order is made.

        Dim difference As TimeSpan = Me.nextScheduledDeliveryDate - Me.deliveryDate

        Return difference.Days
    End Function

    Private Function CreatePivotTable() As Excel.PivotTable
        Dim generator As TextFileGenerator = New TextFileGenerator(Globals.DataSet.Sales)
        Dim pivotTable As Excel.PivotTable = Nothing

        Try

            ' Gets the destination of the new PivotTable.
            Dim destination As Excel.Range = Me.worksheet.Range(pivotTableAddress)

            pivotTable = Globals.ThisWorkbook.CreateSalesPivotTable(destination, generator.FullPath)

            ' Adjusts the properties of the new PivotTable to
            ' format information the desired way.
            pivotTable.ColumnGrand = False
            pivotTable.RowGrand = False

            ' Adds the desired rows and columns within 
            ' the PivotTable.
            pivotTable.AddFields("Flavor")

            Dim soldField As Excel.PivotField = pivotTable.AddDataField(pivotTable.PivotFields("Sold"), My.Resources.AverageOfUnitsSold, Excel.XlConsolidationFunction.xlAverage)

            ' Sets the view of data desired within the PivotTable.
            ' Format "0.0" - one decimal place.
            soldField.NumberFormat = "0.0"

            Dim profitField As Excel.PivotField = pivotTable.AddDataField(pivotTable.PivotFields("Sold"), My.Resources.StdDevOfUnitsSold, Excel.XlConsolidationFunction.xlStDev)

            ' Sets the view of data desired within the PivotTable.
            ' Format "0.00" - two decimal places.
            profitField.NumberFormat = "0.00"

            ' Hiding the two floating bars that get added when a PivotTable is created.
            Globals.ThisWorkbook.ShowPivotTableFieldList = False
            Me.worksheet.Application.CommandBars("PivotTable").Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Throw
        Finally
            generator.Dispose()
        End Try

        Return pivotTable
    End Function


    Private Sub PopulateDateInformation(ByVal orderDate As DateTime)
        ' This method populates the worksheet with the next order 
        ' date and its corresponding delivery date.
        ' Gets the next order date and populates it.
        Dim orderDateCell As Excel.Range = worksheet.Range(orderDateAddress)

        orderDateCell.Value2 = My.Resources.OrderDateHeader
        orderDateCell.Next.Value2 = orderDate.ToShortDateString()

        Dim deliveryDateCell As Excel.Range = ExcelHelpers.GetCellFromRange(orderDateCell, 2, 1)

        deliveryDateCell.Value2 = My.Resources.DeliveryDateHeader
        deliveryDateCell.Next.Value2 = Me.deliveryDate.ToShortDateString()
    End Sub

End Class
