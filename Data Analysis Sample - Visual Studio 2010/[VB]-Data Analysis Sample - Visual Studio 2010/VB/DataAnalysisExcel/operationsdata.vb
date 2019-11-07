' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization
Imports System.Text

Partial Public Class OperationsBaseData
    Protected Overridable Sub OnSalesInventoryChanged(ByVal e As System.Data.DataColumnChangeEventArgs)
    End Sub

    Partial Public Class SalesDataTable
        Inherits System.Data.TypedTableBase(Of SalesRow)
        Implements System.Collections.IEnumerable

        Protected Overrides Sub OnColumnChanged(ByVal e As System.Data.DataColumnChangeEventArgs)
            Dim dataSet As OperationsBaseData = TryCast(Me.DataSet, OperationsBaseData)

            If dataSet IsNot Nothing AndAlso e.Column Is Me.InventoryColumn Then
                dataSet.OnSalesInventoryChanged(e)
            End If

            MyBase.OnColumnChanged(e)
        End Sub
    End Class
End Class


Friend Class OperationsData
    Inherits OperationsBaseData
    Friend Class OperationsView
        Inherits DataView

        Friend Property CurrentDate() As Nullable(Of DateTime)
            Get
                Return currentDateField
            End Get

            Set(ByVal Value As Nullable(Of DateTime))
                currentDateField = Value
                SetRowFilter()
            End Set
        End Property

        Friend Property Flavor() As String
            Get
                Return flavorField
            End Get
            Set(ByVal Value As String)
                flavorField = Value
                SetRowFilter()
            End Set
        End Property

        Friend Shadows ReadOnly Property Table() As OperationsBaseData.SalesDataTable
            Get
                Return CType(MyBase.Table, OperationsBaseData.SalesDataTable)
            End Get
        End Property

        Private currentDateField As Nullable(Of DateTime) = Nothing

        Private flavorField As String

        Private boundToList As Boolean = False

        Private Sub SetRowFilter()

            Dim conditions As New List(Of String)(2)

            If currentDateField.HasValue Then
                conditions.Add( _
                    String.Format( _
                        CultureInfo.InvariantCulture, _
                        "Date=#{0:d}#", _
                        Me.currentDateField))
            End If

            If Flavor IsNot Nothing Then
                conditions.Add("Flavor='" + Me.Flavor.Replace("'", "''") + "'")
            End If

            Me.RowFilter = String.Join(" AND ", conditions.ToArray())
        End Sub

        Friend Sub BindToProtectedList(ByVal list As Microsoft.Office.Tools.Excel.ListObject, ByVal ParamArray mappedColumns() As String)

            Globals.ThisWorkbook.MakeReadWrite()

            list.SetDataBinding(Me, "", mappedColumns)
            Globals.ThisWorkbook.MakeReadOnly()
            boundToList = True
        End Sub

        Protected Overrides Sub OnListChanged(ByVal e As System.ComponentModel.ListChangedEventArgs)
            If boundToList Then
                Globals.ThisWorkbook.MakeReadWrite()
                MyBase.OnListChanged(e)
                Globals.ThisWorkbook.MakeReadOnly()
            Else
                MyBase.OnListChanged(e)
            End If

        End Sub
        Friend Sub New()
            MyBase.New()
        End Sub

        Friend Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub
    End Class

    Friend Function CreateView() As OperationsView
        Dim view As New OperationsView(Me.Sales)

        Return view
    End Function

    Private lastDaysView As OperationsView

    Friend Sub New()
        MyBase.New()
    End Sub

    Friend Overloads Sub Load()
        Load(ThisWorkbook.GetAbsolutePath("."))
    End Sub

    Friend Overloads Sub Load(ByVal folder As String)
        Try
            Me.Pricing.ReadXml(System.IO.Path.Combine(folder, "PricingData.xml"))
            Me.Sales.ReadXml(System.IO.Path.Combine(folder, "SalesData.xml"))
            Me.Inventory.ReadXml(System.IO.Path.Combine(folder, "InventoryData.xml"))
            ComputeSoldColumn()

            lastDaysView = CreateView()
            lastDaysView.CurrentDate = MaxDate
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            Throw
        End Try
    End Sub

    Friend Sub Save()
        Save(ThisWorkbook.GetAbsolutePath("."))
    End Sub

    Friend Sub Save(ByVal folder As String)
        Me.Sales.WriteXml(System.IO.Path.Combine(folder, "SalesData.xml"), False)
    End Sub

    Private Sub ComputeSoldColumn()
        Dim lastInventory As New Dictionary(Of String, Integer)()
        Dim maxDate As Date = Me.MaxDate

        For Each row As OperationsBaseData.SalesRow In Me.Sales
            If lastInventory.ContainsKey(row.Flavor) Then
                Dim received As Integer
                Dim lastInventoryValue As Integer = lastInventory(row.Flavor)
                Dim inventoryRows() As OperationsBaseData.InventoryRow = row.GetInventoryRows()

                If inventoryRows Is Nothing OrElse inventoryRows.Length = 0 Then
                    received = 0
                Else
                    received = inventoryRows(0).Received
                End If

                row.Sold = lastInventoryValue - row.Inventory + received

                lastInventory(row.Flavor) = row.Inventory

                ' Update estimated and recommendation for last day's rows.
                ' Estimated and recommendation may not be in the data or
                ' the recommendation may be in the wrong language.
                If row._Date = maxDate Then
                    Dim sellingSpeed As Double = ComputeAverageSellingSpeed(row.Flavor)
                    EstimateInventory(row, sellingSpeed)
                End If

            Else
                lastInventory.Add(row.Flavor, row.Inventory)

                row.SetSoldNull()
            End If
        Next
    End Sub


    Private Sub ComputeSoldColumn(ByVal row As OperationsBaseData.SalesRow)
        Dim previousDay As SalesRow = Me.Sales.FindBy_DateFlavor(row._Date.AddDays(-1), row.Flavor)

        If previousDay Is Nothing Then
            row.SetSoldNull()
        Else
            Dim lastInventory As Integer = previousDay.Inventory
            Dim received As Integer

            Dim inventoryRows() As OperationsBaseData.InventoryRow = row.GetInventoryRows()

            If inventoryRows Is Nothing OrElse inventoryRows.Length = 0 Then
                received = 0
            Else
                received = inventoryRows(0).Received
                Debug.Assert(inventoryRows.Length = 1)
            End If

            row.Sold = lastInventory - row.Inventory + received
        End If
    End Sub

    Friend ReadOnly Property MinDate() As DateTime
        Get
            Return CDate(Me.Sales.Compute("MIN(Date)", String.Empty))
        End Get
    End Property

    Friend ReadOnly Property MaxDate() As DateTime
        Get
            Return CDate(Me.Sales.Compute("MAX(Date)", String.Empty))
        End Get
    End Property

    Friend ReadOnly Property NextWeeklyDeliveryDate() As DateTime
        Get
            Dim lastDate As DateTime = Me.MaxDate
            Dim lastDay As DayOfWeek = lastDate.DayOfWeek
            Dim deliveryDate As DateTime
            Const oneWeek As Integer = 7

            If lastDay <= DayOfWeek.Tuesday Then
                deliveryDate = lastDate.AddDays(DayOfWeek.Thursday - lastDay)
            Else
                deliveryDate = lastDate.AddDays(DayOfWeek.Thursday - lastDay + oneWeek)
            End If

            Return deliveryDate
        End Get
    End Property

    Friend Function ComputeAverageSellingSpeed(ByVal flavor As String) As Integer
        Try
            Dim average As Object = Me.Sales.Compute("AVG(Sold)", String.Format(CultureInfo.CurrentUICulture, "Flavor = '{0}'", flavor))

            Return CInt(average)
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            Throw
        End Try
    End Function

    Friend Function IsLastDayComplete() As Boolean
        Try
            Dim count As Object = Me.Sales.Compute("COUNT(Inventory)", "Date=MAX(Date)")

            Return CInt(count) = Me.Pricing.Count
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            Throw
        End Try
    End Function


    ' Changing the inventory means changes in sales for the current day and the next day.
    Protected Overrides Sub OnSalesInventoryChanged(ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim row As OperationsBaseData.SalesRow = DirectCast(e.Row, OperationsBaseData.SalesRow)
        If row.RowState = DataRowState.Modified Or row.RowState = DataRowState.Added Then
            ComputeSoldColumn(row)
            Dim sellingSpeed As Double = ComputeAverageSellingSpeed(row.Flavor)

            Dim nextDay As SalesRow = Me.Sales.FindBy_DateFlavor(row._Date.AddDays(1), row.Flavor)

            If nextDay IsNot Nothing Then
                ComputeSoldColumn(nextDay)
                EstimateInventory(nextDay, sellingSpeed)
            End If

            ' Now that all relevant sold columns are computed,
            ' we can estimate the inventory.
            EstimateInventory(row, sellingSpeed)
        End If
    End Sub

    Private Sub EstimateInventory(ByVal row As OperationsBaseData.SalesRow, ByVal sellingSpeed As Double)
        Dim estimatedInventory As Double = row.Inventory - sellingSpeed * (NextWeeklyDeliveryDate - row._Date).Days
        row.Estimated_Inventory = estimatedInventory

        If estimatedInventory < 0 Then
            row.Recommendation = My.Resources.CreateUnscheduledOrderRecommendation
        Else
            row.SetRecommendationNull()
        End If
    End Sub
End Class
