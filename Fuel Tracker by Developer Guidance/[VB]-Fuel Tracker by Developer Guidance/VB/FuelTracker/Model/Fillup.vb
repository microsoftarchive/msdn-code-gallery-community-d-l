' ===================================================================================
'  Microsoft Developer Guidance
'  Application Guidance for Windows Phone 7 
' ===================================================================================
'  Copyright (c) Microsoft Corporation.  All rights reserved.
'  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
'  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
'  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
'  FITNESS FOR A PARTICULAR PURPOSE.
' ===================================================================================
'  The example companies, organizations, products, domain names,
'  e-mail addresses, logos, people, places, and events depicted
'  herein are fictitious.  No association with any real company,
'  organization, product, domain name, email address, logo, person,
'  places, or events is intended or should be inferred.
' ===================================================================================

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace Model

    Public Class Fillup
        Implements INotifyPropertyChanged

        Private _date As DateTime
        Private _fuelQuantity As Single
        Private _odometerReading As Single
        Private _pricePerFuelUnit As Single

        Public Property [Date] As DateTime
            Get
                Return _date
            End Get
            Set(value As DateTime)
                If _date = value Then Return
                _date = value
                NotifyPropertyChanged("Date")
            End Set
        End Property

        Public Property OdometerReading As Single
            Get
                Return _odometerReading
            End Get
            Set(value As Single)
                Dim roundedValue As Single = Math.Round(value, 0)
                If _odometerReading = roundedValue Then Return
                _odometerReading = roundedValue
                NotifyPropertyChanged("OdometerReading")
            End Set
        End Property

        Public Property FuelQuantity As Single
            Get
                Return _fuelQuantity
            End Get
            Set(value As Single)
                Dim roundedValue As Single = Math.Round(value, 1)
                If _fuelQuantity = roundedValue Then Return
                _fuelQuantity = roundedValue
                NotifyPropertyChanged("FuelQuantity")
            End Set
        End Property

        Public Property PricePerFuelUnit As Single
            Get
                Return _pricePerFuelUnit
            End Get
            Set(value As Single)
                Dim roundedValue As Single = Math.Round(value, 2)
                If _pricePerFuelUnit = roundedValue Then Return
                _pricePerFuelUnit = roundedValue
                NotifyPropertyChanged("PricePerFuelUnit")
            End Set
        End Property

        Public ReadOnly Property FuelEfficiency As Single
            Get
                Return (DistanceDriven / FuelQuantity)
            End Get
        End Property

        Public Property DistanceDriven As Single

        Public Function Validate() As IList(Of String)
            Dim results = New List(Of String)
            If OdometerReading <= 0 Then _
                results.Add("The odometer value must be a number greater than zero.")
            If DistanceDriven <= 0 Then _
                results.Add("The odometer value must be greater than the previous value.")
            If FuelQuantity <= 0 Then _
                results.Add("The fuel quantity must be greater than zero.")
            If PricePerFuelUnit <= 0 Then _
                results.Add("The fuel price must be greater than zero.")
            Return results
        End Function

#Region "INotifyPropertyChanged"

        Public Event PropertyChanged As PropertyChangedEventHandler _
            Implements INotifyPropertyChanged.PropertyChanged

        Private Sub NotifyPropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

#End Region

    End Class

End Namespace
