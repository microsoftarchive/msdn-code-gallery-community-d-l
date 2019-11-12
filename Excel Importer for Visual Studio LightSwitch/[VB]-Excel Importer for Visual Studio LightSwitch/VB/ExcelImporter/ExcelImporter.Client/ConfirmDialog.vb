Imports Microsoft.LightSwitch.Runtime.Shell.Framework
Imports System.Windows.Data


<TemplatePart(Name:=ConfirmDialog.OkButtonElement, Type:=GetType(Button))> _
<TemplatePart(Name:=ConfirmDialog.CancelButtonElement, Type:=GetType(Button))> _
Public Class ConfirmDialog
    Inherits ScreenChildWindowContent

    Public Const OkButtonElement As String = "OKButton"
    Public Const CancelButtonElement As String = "CancelButton"

    Private WithEvents okButton As Button
    Private WithEvents cancelButton As Button

    Public Sub New()
        MyBase.New()
        Me.DefaultStyleKey = GetType(ConfirmDialog)
    End Sub

    Public Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()

        okButton = Me.GetTemplateChild(OkButtonElement)
        cancelButton = Me.GetTemplateChild(CancelButtonElement)
        UpdateTitle()
        UpdateCloseButton()
    End Sub

    Private ReadOnly Property ParentChildWindow As ScreenChildWindow
        Get
            Return TryCast(Me.Parent, ScreenChildWindow)
        End Get
    End Property

    Private Sub okButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles okButton.Click
        Me.ParentChildWindow.DialogResult = True
        Me.ParentChildWindow.DialogResultCancel = False
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles cancelButton.Click
        Me.ParentChildWindow.DialogResult = False
        Me.ParentChildWindow.DialogResultCancel = True
    End Sub

#Region "Dependency Properties"
    Public Property Title() As String
        Get
            Return CType(Me.GetValue(TitleProperty), String)
        End Get
        Set(ByVal value As String)
            Me.SetValue(TitleProperty, value)
        End Set
    End Property
    Public Shared ReadOnly TitleProperty As DependencyProperty = DependencyProperty.Register("Title", GetType(String), GetType(ConfirmDialog), New PropertyMetadata(Nothing, AddressOf TitleChanged))
    Shared Sub TitleChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim dialog As ConfirmDialog = d
        dialog.UpdateTitle()
    End Sub

    Private Sub UpdateTitle()
        If Me.ParentChildWindow IsNot Nothing And Title IsNot Nothing Then
            Me.ParentChildWindow.Title = Me.Title
        End If
    End Sub

    Public Property ShowCloseButton() As Boolean
        Get
            Return CType(Me.GetValue(ShowCloseButtonProperty), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Me.SetValue(ShowCloseButtonProperty, value)
        End Set
    End Property
    Public Shared ReadOnly ShowCloseButtonProperty As DependencyProperty = DependencyProperty.Register("ShowCloseButton", GetType(Boolean), GetType(ConfirmDialog), New PropertyMetadata(AddressOf ShowCloseButtonChanged))
    Shared Sub ShowCloseButtonChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim dialog As ConfirmDialog = d
        dialog.UpdateCloseButton()
    End Sub

    Private Sub UpdateCloseButton()
        If Me.ParentChildWindow IsNot Nothing Then
            Me.ParentChildWindow.HasCloseButton = Me.ShowCloseButton
        End If
    End Sub

    Public Property OkButtonVisible As Boolean
        Get
            Return CType(Me.GetValue(OkButtonVisibleProperty), Boolean)
        End Get
        Set(value As Boolean)
            Me.SetValue(OkButtonVisibleProperty, value)
        End Set
    End Property
    Public Shared ReadOnly OkButtonVisibleProperty As DependencyProperty = DependencyProperty.Register("OkButtonVisible", GetType(Boolean), GetType(ConfirmDialog), New PropertyMetadata(True))

    Public Property CancelButtonVisible As Boolean
        Get
            Return CType(Me.GetValue(CancelButtonVisibleProperty), Boolean)
        End Get
        Set(value As Boolean)
            Me.SetValue(CancelButtonVisibleProperty, value)
        End Set
    End Property
    Public Shared ReadOnly CancelButtonVisibleProperty As DependencyProperty = DependencyProperty.Register("CancelButtonVisible", GetType(Boolean), GetType(ConfirmDialog), New PropertyMetadata(True))

    Public Property OkButtonTitle As String
        Get
            Return CType(Me.GetValue(OkButtonTitleProperty), Boolean)
        End Get
        Set(value As String)
            Me.SetValue(OkButtonTitleProperty, value)
        End Set
    End Property
    Public Shared ReadOnly OkButtonTitleProperty As DependencyProperty = DependencyProperty.Register("OkButtonTitle", GetType(String), GetType(ConfirmDialog), New PropertyMetadata("Ok"))

    Public Property CancelButtonTitle As String
        Get
            Return CType(Me.GetValue(CancelButtonTitleProperty), Boolean)
        End Get
        Set(value As String)
            Me.SetValue(CancelButtonTitleProperty, value)
        End Set
    End Property
    Public Shared ReadOnly CancelButtonTitleProperty As DependencyProperty = DependencyProperty.Register("CancelButtonTitle", GetType(String), GetType(ConfirmDialog), New PropertyMetadata("Cancel"))

#End Region
End Class

Public Class BooleanToVisibilityConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
        Dim vis As Boolean = value
        If vis Then
            Return Visibility.Visible
        Else
            Return Visibility.Collapsed
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
