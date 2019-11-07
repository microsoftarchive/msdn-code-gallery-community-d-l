Imports System
Imports System.ComponentModel

Namespace Web

    Partial Public Class User
#Region "Make DisplayName Bindable"
        Protected Overrides Sub OnPropertyChanged(ByVal e As System.ComponentModel.PropertyChangedEventArgs)
            If e Is Nothing Then
                Throw New ArgumentNullException("e")
            End If

            MyBase.OnPropertyChanged(e)

            If e.PropertyName = "Name" Or e.PropertyName = "FriendlyName" Then
                Me.RaisePropertyChanged("DisplayName")
            End If
        End Sub
#End Region
    End Class
End Namespace