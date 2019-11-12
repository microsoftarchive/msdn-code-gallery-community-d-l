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

Imports System.ComponentModel
Imports System.Windows.Media.Imaging
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace Model

    Public Class Car
        Implements INotifyPropertyChanged

        Private _name As String
        Private _picture As BitmapImage
        Private _initialOdometerReading As Single
        Private _fillupHistory As ObservableCollection(Of Fillup)

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                If _name = value Then Return
                _name = value
                NotifyPropertyChanged("Name")
            End Set
        End Property

        <System.Runtime.Serialization.IgnoreDataMemberAttribute()> _
        Public Property Picture As BitmapImage
            Get
                Return _picture
            End Get
            Set(value As BitmapImage)
                If (_picture Is Nothing AndAlso value Is Nothing) OrElse
                    (_picture IsNot Nothing AndAlso
                     _picture.Equals(value)) Then Return
                _picture = value
                NotifyPropertyChanged("Picture")
            End Set
        End Property

        Public Property InitialOdometerReading As Single
            Get
                Return _initialOdometerReading
            End Get
            Set(value As Single)
                Dim roundedValue As Single = Math.Round(value, 0)
                If _initialOdometerReading = roundedValue Then Return
                _initialOdometerReading = roundedValue
                NotifyPropertyChanged("InitialOdometerReading")
            End Set
        End Property

        Public ReadOnly Property AverageFuelEfficiency As Single
            Get
                If FillupHistory Is Nothing Then Return 0
                Dim totalFuel As Single =
                    FillupHistory.Sum(Function(fillup) fillup.FuelQuantity)
                Dim totalDistance As Single =
                    FillupHistory.Sum(Function(fillup) fillup.DistanceDriven)
                If totalDistance = 0 Then Return 0
                Return totalDistance / totalFuel
            End Get
        End Property

        Public Property FillupHistory As ObservableCollection(Of Fillup)
            Get
                Return _fillupHistory
            End Get
            Set(value As ObservableCollection(Of Fillup))
                If (_fillupHistory Is Nothing AndAlso value Is Nothing) OrElse
                    (_fillupHistory IsNot Nothing AndAlso
                     _fillupHistory.Equals(value)) Then Return
                _fillupHistory = value
                If _fillupHistory IsNot Nothing Then
                    AddHandler _fillupHistory.CollectionChanged,
                        Sub()
                            NotifyPropertyChanged("AverageFuelEfficiency")
                            NotifyPropertyChanged("LastFillup")
                        End Sub
                End If
                NotifyPropertyChanged("FillupHistory")
                NotifyPropertyChanged("AverageFuelEfficiency")
            End Set
        End Property

        Public ReadOnly Property LastFillup As Fillup
            Get
                If (FillupHistory IsNot Nothing And FillupHistory.Count > 0) Then
                    Return FillupHistory.Item(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

#Region "INotifyPropertyChanged"

        Public Event PropertyChanged As PropertyChangedEventHandler _
            Implements INotifyPropertyChanged.PropertyChanged

        Private Sub NotifyPropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

#End Region

    End Class

End Namespace
