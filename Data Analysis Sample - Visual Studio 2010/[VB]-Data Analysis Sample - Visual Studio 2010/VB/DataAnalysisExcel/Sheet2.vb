' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Excel = Microsoft.Office.Interop.Excel

''' <summary>
''' This worksheet displays historic sales data for an ice cream flavorField.
''' </summary>
Public Class Sheet2
    ''' <summary>
    ''' The data view built on the Sales table and filtered by flavorField.
    ''' </summary>
    Private view As OperationsData.OperationsView

    ''' <summary>
    ''' The flavorField for which history is displayed.
    ''' </summary>
    Private flavorField As String = Nothing

    ''' <summary>
    ''' Accessor and mutator for the flavorField field. When
    ''' property is modified, changes the view accordingly.
    ''' </summary>
    ''' <value>The current flavorField.</value>
    Public Property Flavor() As String
        Get
            Return flavorField
        End Get
        Set(ByVal Value As String)
            flavorField = Value

            RaiseEvent FlavorChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Flavor"))

            If view IsNot Nothing Then
                view.Flavor = flavorField
            End If
        End Set
    End Property

    ''' <summary>
    ''' Event raised when Flavor is changed. When the Flavor property is
    ''' used for data binding, the PropertyManager listens for this event.
    ''' </summary>
    Public Event FlavorChanged As EventHandler


    Private Sub Sheet2_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup

        Me.Sheet2_TitleLabel.Value2 = My.Resources.Sheet2Title
        Me.Name = My.Resources.Sheet2Name
        Me.IceCreamLabel.Value2 = My.Resources.IceCreamHeader

        Me.Chart_1.ChartTitle.Text = My.Resources.ProfitHeader
        CType(Me.Chart_1.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary), Excel.Axis).AxisTitle.Text = My.Resources.ProfitHeader
        CType(Me.Chart_1.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary), Excel.Axis).AxisTitle.Text = My.Resources.DateHeader

        Me.view = Globals.DataSet.CreateView()

        If Me.flavorField IsNot Nothing Then
            view.Flavor = Me.flavorField
        Else
            Me.Flavor = CType(view(0).Row("Flavor"), String)
        End If

        Me.History.SetDataBinding(view, "", "Date", "Inventory", "Sold", "Profit")
        Me.History.ListColumns(1).Name = My.Resources.DateHeader
        Me.History.ListColumns(2).Name = My.Resources.InventoryHeader
        Me.History.ListColumns(3).Name = My.Resources.SoldHeader
        Me.History.ListColumns(4).Name = My.Resources.ProfitHeader

        Me.FlavorNamedRange.DataBindings.Add("Value2", Me, "Flavor")
    End Sub

    Private Sub Sheet2_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
