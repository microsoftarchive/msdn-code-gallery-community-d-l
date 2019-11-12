' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System.Globalization
Imports Office = Microsoft.Office.Core

Partial Public Class UnscheduledOrderControl
    Inherits System.Windows.Forms.UserControl

    ''' <summary>
    ''' ComboBox with the whole list of flavors.
    ''' </summary>
    Private WithEvents flavorComboBox As System.Windows.Forms.ComboBox

    ''' <summary>
    ''' list of high inventory items.
    ''' </summary>
    Private WithEvents highList As System.Windows.Forms.ListBox

    ''' <summary>
    ''' list of low inventory items.
    ''' </summary>
    Private WithEvents lowList As System.Windows.Forms.ListBox

    ''' <summary>
    '''  Data viewField based on the Sales table, representing the current day.
    ''' </summary>
    Private WithEvents viewField As OperationsData.OperationsView

    Private selectorLabel As System.Windows.Forms.Label

    Private highLabel As System.Windows.Forms.Label

    Private lowLabel As System.Windows.Forms.Label

    Private recommendationGroup As System.Windows.Forms.GroupBox

    ''' <summary>
    ''' This displays recommendation as to whether an unscheduled
    ''' order should be placed. 
    ''' </summary>
    Private recommendationLabel As System.Windows.Forms.Label

    Private orderLabel As System.Windows.Forms.Label

    ''' <summary>
    ''' The button to create an unscheduled order.
    ''' </summary>
    Private WithEvents createOrderButton As System.Windows.Forms.Button

    ''' <summary>
    ''' Gets or sets the current day's viewField.
    ''' </summary>
    ''' <value></value>
    Friend Property View() As OperationsData.OperationsView
        Get
            Return viewField
        End Get
        Set(ByVal Value As OperationsData.OperationsView)
            viewField = Value
            If viewField IsNot Nothing Then
                UpdateRecommendationLabel()
            End If
        End Set
    End Property

    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
        If (disposing) Then
            If (Not components Is Nothing) Then
                components.Dispose()
            End If
        End If

        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnscheduledOrderControl))
        Me.selectorLabel = New System.Windows.Forms.Label
        Me.flavorComboBox = New System.Windows.Forms.ComboBox
        Me.highLabel = New System.Windows.Forms.Label
        Me.lowLabel = New System.Windows.Forms.Label
        Me.highList = New System.Windows.Forms.ListBox
        Me.lowList = New System.Windows.Forms.ListBox
        Me.recommendationGroup = New System.Windows.Forms.GroupBox
        Me.createOrderButton = New System.Windows.Forms.Button
        Me.orderLabel = New System.Windows.Forms.Label
        Me.recommendationLabel = New System.Windows.Forms.Label
        Me.recommendationGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'selectorLabel
        '
        resources.ApplyResources(Me.selectorLabel, "selectorLabel")
        Me.selectorLabel.Name = "selectorLabel"
        '
        'flavorComboBox
        '
        Me.flavorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.flavorComboBox.FormattingEnabled = True
        resources.ApplyResources(Me.flavorComboBox, "flavorComboBox")
        Me.flavorComboBox.Name = "flavorComboBox"
        '
        'highLabel
        '
        resources.ApplyResources(Me.highLabel, "highLabel")
        Me.highLabel.Name = "highLabel"
        '
        'lowLabel
        '
        resources.ApplyResources(Me.lowLabel, "lowLabel")
        Me.lowLabel.Name = "lowLabel"
        '
        'highList
        '
        Me.highList.FormattingEnabled = True
        resources.ApplyResources(Me.highList, "highList")
        Me.highList.Name = "highList"
        '
        'lowList
        '
        Me.lowList.FormattingEnabled = True
        resources.ApplyResources(Me.lowList, "lowList")
        Me.lowList.Name = "lowList"
        '
        'recommendationGroup
        '
        Me.recommendationGroup.Controls.Add(Me.createOrderButton)
        Me.recommendationGroup.Controls.Add(Me.orderLabel)
        Me.recommendationGroup.Controls.Add(Me.recommendationLabel)
        resources.ApplyResources(Me.recommendationGroup, "recommendationGroup")
        Me.recommendationGroup.Name = "recommendationGroup"
        Me.recommendationGroup.TabStop = False
        '
        'createOrderButton
        '
        resources.ApplyResources(Me.createOrderButton, "createOrderButton")
        Me.createOrderButton.Name = "createOrderButton"
        '
        'orderLabel
        '
        resources.ApplyResources(Me.orderLabel, "orderLabel")
        Me.orderLabel.Name = "orderLabel"
        '
        'recommendationLabel
        '
        resources.ApplyResources(Me.recommendationLabel, "recommendationLabel")
        Me.recommendationLabel.Name = "recommendationLabel"
        '
        'UnscheduledOrderControl
        '
        Me.Controls.Add(Me.recommendationGroup)
        Me.Controls.Add(Me.lowList)
        Me.Controls.Add(Me.highList)
        Me.Controls.Add(Me.lowLabel)
        Me.Controls.Add(Me.highLabel)
        Me.Controls.Add(Me.flavorComboBox)
        Me.Controls.Add(Me.selectorLabel)
        Me.Name = "UnscheduledOrderControl"
        resources.ApplyResources(Me, "$this")
        Me.recommendationGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
