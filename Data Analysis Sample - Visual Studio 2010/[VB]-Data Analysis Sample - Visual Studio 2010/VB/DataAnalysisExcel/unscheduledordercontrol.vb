' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel
Imports Office = Microsoft.Office.Core

''' <summary>
''' This is the control that shows in the Actions Pane. It allows to create
''' an unscheduled ice cream order and to see an ice cream's sales history.
''' </summary>
Public Class UnscheduledOrderControl

    Private Const unscheduledDeliveryCost As Double = 25

    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()

        InitializeComponent()

        Dim resources As System.ComponentModel.ComponentResourceManager = _
            New System.ComponentModel.ComponentResourceManager(GetType(UnscheduledOrderControl))

        resources.ApplyResources(Me.selectorLabel, "selectorLabel", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.flavorComboBox, "flavorComboBox", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.highLabel, "highLabel", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.lowLabel, "lowLabel", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.highList, "highList", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.lowList, "lowList", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.recommendationGroup, "recommendationGroup", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.createOrderButton, "createOrderButton", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.orderLabel, "orderLabel", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me.recommendationLabel, "recommendationLabel", CultureInfo.CurrentUICulture)
        resources.ApplyResources(Me, "$this", CultureInfo.CurrentUICulture)

        ' Data bind the flavor combo box to the pricing table.
        Me.flavorComboBox.DataSource = Globals.DataSet.Pricing
        Me.flavorComboBox.DisplayMember = "Flavor"
    End Sub

    ''' <summary>
    ''' Creates a new order worksheet.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CreateOrderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles createOrderButton.Click

        Try
            Dim sheet As New OrderingSheet(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Event handler for the flavor combo box's SelectedIndexChanged event.
    ''' Have the flavor history worksheet display the selected flavor.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub flavorComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flavorComboBox.SelectedIndexChanged
        Dim selectedItem As DataRowView = CType((CType(sender, ComboBox)).SelectedItem, DataRowView)
        DisplayFlavorHistory((CType(selectedItem.Row, OperationsBaseData.PricingRow)).Flavor)
    End Sub

    ''' <summary>
    ''' Event handler for the viewField's ListChanged event. When the viewField changes to display
    ''' a date that is not the most recent one, the only controls showing are the flavor
    ''' combo box and its label. When inventory data changes in the viewField, three controls are updated:
    ''' the low inventory list, the high inventory list and the recommendation label.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub view_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs) Handles viewField.ListChanged
        If Me.viewField.CurrentDate.HasValue AndAlso (Globals.DataSet.MaxDate = Me.viewField.CurrentDate.Value) Then
            If (e.ListChangedType = ListChangedType.Reset) Then
                ShowLastDayControls(True)
            ElseIf (e.ListChangedType = ListChangedType.ItemChanged) Then
                Dim estimatedInventory As Double = CType(Me.viewField(e.NewIndex)("Estimated Inventory"), Double)
                Dim flavor As String = CType(Me.viewField(e.NewIndex)("Flavor"), String)

                If (estimatedInventory < 0) Then
                    ShowAsLowInventory(flavor)
                Else
                    ' if more than 10 percent more than warranted by previous sales
                    Dim todaysInventory As Double
                    todaysInventory = (CType(Me.viewField(e.NewIndex).Row, OperationsBaseData.SalesRow)).Inventory

                    Dim idealInventory As Double
                    idealInventory = todaysInventory - estimatedInventory

                    If (todaysInventory > idealInventory * 1.1) Then
                        ShowAsHighInventory(flavor)
                    Else
                        ShowAsAdequateInventory(flavor)
                    End If
                End If

                UpdateRecommendationLabel()
            End If
        Else
            If (e.ListChangedType = ListChangedType.Reset) Then
                ShowLastDayControls(False)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Shows a flavor as a low inventory item.
    ''' </summary>
    ''' <param name="flavor">Flavor to show.</param>
    Private Sub ShowAsLowInventory(ByVal flavor As String)
        If (Not Me.lowList.Items.Contains(flavor)) Then
            Me.lowList.Items.Add(flavor)

            If Me.highList.Items.Contains(flavor) Then
                Me.highList.Items.Remove(flavor)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Shows a flavor as a high inventory item.
    ''' </summary>
    ''' <param name="flavor">Flavor to show.</param>
    Private Sub ShowAsHighInventory(ByVal flavor As String)
        If (Not Me.highList.Items.Contains(flavor)) Then
            Me.highList.Items.Add(flavor)

            If Me.lowList.Items.Contains(flavor) Then
                Me.lowList.Items.Remove(flavor)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Removes a flavor from high- and low inventory lists.
    ''' </summary>
    ''' <param name="flavor">Flavor to remove from lists.</param>
    Private Sub ShowAsAdequateInventory(ByVal flavor As String)
        If Me.highList.Items.Contains(flavor) Then
            Me.highList.Items.Remove(flavor)
        End If

        If Me.lowList.Items.Contains(flavor) Then
            Me.lowList.Items.Remove(flavor)
        End If
    End Sub

    ''' <summary>
    ''' Show or hide the low/high inventory list boxes, 
    ''' their labels and the recommendation group box.
    ''' </summary>
    ''' <param name="show">True to show, false to hide.</param>
    Private Sub ShowLastDayControls(ByVal show As Boolean)
        Dim dynamicControls() As Control = New Control() {Me.highLabel, Me.highList, Me.lowLabel, Me.lowList, Me.recommendationGroup}

        For Each c As Control In dynamicControls
            c.Visible = show
        Next
    End Sub

    ''' <summary>
    ''' Click event handler for the high and low inventory lists. Displays sales history
    ''' for the flavor being clicked on.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub inventoryList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lowList.Click, highList.Click
        Dim flavor As String = CType(((CType(sender, ListBox)).SelectedItem), String)
        If flavor IsNot Nothing Then
            DisplayFlavorHistory(flavor)
        End If
    End Sub

    ''' <summary>
    ''' Shows a flavor's sales history in the Flavor History worksheet.
    ''' </summary>
    ''' <param name="flavor">Flavor for which history is displayed.</param>
    Private Shared Sub DisplayFlavorHistory(ByVal flavor As String)
        Globals.Sheet2.Flavor = flavor
        Globals.Sheet2.Activate()
    End Sub

    ''' <summary>
    ''' Calculates potential profit from ordering ice cream.
    ''' </summary>
    ''' <returns>Potential profit.</returns>
    Private Function CalculatePotentialProfit() As Double
        Dim profit As Double = 0 - unscheduledDeliveryCost

        Dim rowView As DataRowView
        For Each rowView In Me.viewField
            Dim row As OperationsBaseData.SalesRow = CType(rowView.Row, OperationsBaseData.SalesRow)

            If (Not row.IsEstimated_InventoryNull() AndAlso row.Estimated_Inventory < 0) Then

                Dim pricing As OperationsBaseData.PricingRow = CType(row.GetParentRow("Pricing_Sales"), OperationsBaseData.PricingRow)
                Dim flavorProfit As Double = (pricing.Price - pricing.Cost) * (0 - row.Estimated_Inventory)

                profit += flavorProfit
            End If
        Next

        Return profit
    End Function

    ''' <summary>
    ''' Compute and display ordering recommendation in recommendationLabel.
    ''' </summary>
    Private Sub UpdateRecommendationLabel()
        Dim profit As Double = CalculatePotentialProfit()

        If (profit > 0) Then
            Me.recommendationLabel.Text = _
                String.Format( _
                    CultureInfo.CurrentUICulture, _
                    My.Resources.UnscheduledOrderRecommended, _
                    profit)
        Else
            Me.recommendationLabel.Text = _
                String.Format( _
                    CultureInfo.CurrentUICulture, _
                    My.Resources.UnscheduledOrderNotRecommended, _
                    0 - profit)
        End If

    End Sub

End Class
