' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Sheet1

    ''' <summary>
    ''' This is the location where the pivotTable will be created.
    ''' </summary>        
    Private Const pivotTableAddress As String = "$B$22"

    ''' <summary>
    ''' The data source for the sales list. This view is based on the Sales table of 
    ''' Globals.DataSet, filtered to display one day's worth of data.
    ''' </summary>
    Private dayView As OperationsData.OperationsView

    ''' <summary>
    ''' The PivotTable with sales statistics.
    ''' </summary>
    Private pivotTable As Excel.PivotTable

    ''' <summary>
    ''' When the date currently selected is the last one for which data is available,
    ''' two additional columns are shown: "Estimated Inventory" and "Recommendation"
    ''' and columnsAdded is set to true. Otherwise it is false.
    ''' </summary>
    Private columnsAdded As Boolean = False

    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup

        Try
            Me.Sheet1_TitleLabel.Value2 = My.Resources.Sheet1Title
            Me.Name = My.Resources.Sheet1Name

            Me.newDateButton.Text = My.Resources.AddNewDateButton
            Me.saveButton.Text = My.Resources.SaveDataButton

            Me.dayView = Globals.DataSet.CreateView()

            If Globals.DataSet.Sales.Count <> 0 Then
                Me.DateSelector.MinDate = Globals.DataSet.MinDate
                Me.DateSelector.MaxDate = Globals.DataSet.MaxDate
            End If


            Using textFile As New TextFileGenerator(Globals.DataSet.Sales)
                Me.pivotTable = CreatePivotTable(textFile.FullPath)
            End Using

            AddHandler Globals.DataSet.Sales.SalesRowChanged, AddressOf Me.ViewInventoryChange

            SetLocalizedColumnNames()

            Dim smartPaneControl As New UnscheduledOrderControl()
            smartPaneControl.Dock = DockStyle.Fill
            smartPaneControl.View = Me.dayView

            Globals.ThisWorkbook.ActionsPane.Controls.Add(smartPaneControl)

            Me.Activate()

        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub


    ''' <summary>
    ''' Add columns "Estimated Inventory" and "Recommendation" to the list
    ''' object on the worksheet.
    ''' </summary>
    Private Sub AddColumns()
        If (Not Me.columnsAdded) Then
            dayView.BindToProtectedList(Me.DayInventory, "Flavor", "Inventory", "Sold", "Profit", "Estimated Inventory", "Recommendation")
            SetLocalizedColumnNames()
            Me.columnsAdded = True
        End If
    End Sub

    ''' <summary>
    ''' Remove columns "Estimated Inventory" and "Recommendation" from the list
    ''' object on the worksheet.
    ''' </summary>
    Private Sub RemoveColumns()
        If (columnsAdded) Then
            dayView.BindToProtectedList(Me.DayInventory, "Flavor", "Inventory", "Sold", "Profit")
            SetLocalizedColumnNames()
            Me.columnsAdded = False
        End If
    End Sub

    ''' <summary>
    ''' Create a PivotTable with data from a tab-delimiter text file.
    ''' </summary>
    ''' <param name="filePath">Text file location.</param>
    ''' <returns>Created PivotTable.</returns>
    Private Function CreatePivotTable(ByVal filePath As String) As Excel.PivotTable
        ' If the table is already there,
        ' return the existing table.
        Dim tableName As String = My.Resources.AveragesPivotTableName
        Dim tables As Excel.PivotTables = CType(Me.PivotTables, Excel.PivotTables)
        Dim savedWidths As New System.Collections.Generic.Queue(Of Double)()

        If tables IsNot Nothing Then
            Dim count As Integer = tables.Count

            For i As Integer = 1 To count
                Dim table As Excel.PivotTable = tables.Item(i)
                If table.Name = tableName Then
                    Return table
                End If
            Next
        End If

        Try
            ' AddFields will resize the columns. Save the columns' widths
            ' for restoring them after pivot fields are added
            For Each column As Excel.Range In DayInventory.HeaderRowRange.Cells
                savedWidths.Enqueue(CType(column.ColumnWidth, Double))
            Next

            ' PivotTable creation requires that protection be off.
            Globals.ThisWorkbook.MakeReadWrite()

            Dim table As Excel.PivotTable = Globals.ThisWorkbook.CreateSalesPivotTable(Me.Range(pivotTableAddress, System.Type.Missing), filePath)

            ' Adds the desired rows and columns within 
            ' the PivotTable.
            table.AddFields("Flavor")

            Dim soldField As Excel.PivotField = table.AddDataField(table.PivotFields("Sold"), My.Resources.AverageSold, Excel.XlConsolidationFunction.xlAverage)

            ' Sets the view of data desired within the PivotTable.
            ' Format "0.0" - one decimal place.
            soldField.NumberFormat = "0.0"

            Dim profitField As Excel.PivotField = table.AddDataField(table.PivotFields("Profit"), My.Resources.AverageProfit, Excel.XlConsolidationFunction.xlAverage)

            ' Sets the view of data desired within the PivotTable.
            ' Format "0.00" - two decimal places.
            profitField.NumberFormat = "0.00"

            ' Hiding the two floating bars that get added when a PivotTable is created.
            Globals.ThisWorkbook.ShowPivotTableFieldList = False
            Application.CommandBars("PivotTable").Visible = False

            Return table
        Finally
            ' AddFields will have resized the columns. Restore the columns' widths.
            For Each column As Excel.Range In DayInventory.HeaderRowRange.Cells
                column.ColumnWidth = savedWidths.Dequeue()
            Next

            Globals.ThisWorkbook.MakeReadOnly()
        End Try

    End Function


    Private Sub ViewInventoryChange(ByVal sender As Object, ByVal e As OperationsData.SalesRowChangeEvent)
        If e.Action = DataRowAction.Change Then
            Globals.ThisWorkbook.UpdateSalesPivotTable(Me.pivotTable)
        End If
    End Sub

    ''' <summary>
    ''' Set the list object's column headers to values from the resources.
    ''' </summary>
    Private Sub SetLocalizedColumnNames()
        Dim localizedInventoryColumns() As String = { _
            My.Resources.IceCreamHeader, _
            My.Resources.EodInventoryHeader, _
            My.Resources.UnitsSoldHeader, _
            My.Resources.NetGainHeader, _
            My.Resources.EstimatedInventoryHeader, _
            My.Resources.RecommendationHeader _
        }

        Try
            Globals.ThisWorkbook.MakeReadWrite()
            Me.DayInventory.HeaderRowRange.Value2 = localizedInventoryColumns
        Finally
            Globals.ThisWorkbook.MakeReadOnly()
        End Try
    End Sub

    ''' <summary>
    ''' ValueChanged event handler for the DateTimePicker. Changes the
    ''' dateView to show the selected date.
    ''' </summary>
    ''' <param name="sender">Sender of the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub dateSelector_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateSelector.ValueChanged
        Dim control As DateTimePicker = CType(sender, DateTimePicker)

        dayView.CurrentDate = control.Value

        Dim lastDay As DateTime = control.MaxDate

        If (control.Value = lastDay) Then
            AddColumns()
        Else
            RemoveColumns()
        End If
    End Sub

    Private Sub newDateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newDateButton.Click
        Try
            If (Not Globals.DataSet.IsLastDayComplete()) Then
                MessageBox.Show(Globals.ThisWorkbook.IncompleteDataMessage)
                Return
            End If

            Dim nextDate As DateTime = Globals.DataSet.MaxDate.AddDays(1)

            Dim row As OperationsBaseData.PricingRow
            For Each row In Globals.DataSet.Pricing
                Dim NewRow As OperationsBaseData.SalesRow = CType(Me.dayView.Table.NewRow(), OperationsBaseData.SalesRow)
                NewRow.Flavor = row.Flavor
                NewRow._Date = nextDate

                Me.dayView.Table.AddSalesRow(NewRow)
            Next

            Me.DateSelector.MaxDate = nextDate
            Me.DateSelector.Value = nextDate
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveButton.Click
        Globals.DataSet.Save()
    End Sub

End Class
