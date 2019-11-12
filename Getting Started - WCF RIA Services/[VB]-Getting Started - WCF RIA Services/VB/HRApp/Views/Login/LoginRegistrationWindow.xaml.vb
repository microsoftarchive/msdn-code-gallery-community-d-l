Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ServiceModel.DomainServices.Client
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports System.Windows
Imports System.Windows.Controls

Partial Public Class LoginRegistrationWindow
    Inherits ChildWindow

    Private possiblyPendingOperations As IList(Of OperationBase) = New List(Of OperationBase)()

    Public Sub New()
        InitializeComponent()

        Me.registrationForm.SetParentWindow(Me)
        Me.loginForm.SetParentWindow(Me)

        AddHandler Me.LayoutUpdated, AddressOf Me.GoToInitialState
        AddHandler Me.LayoutUpdated, AddressOf Me.UpdateTitle
    End Sub

    ''' <summary>
    '''     Initializes the <see cref="VisualStateManager"/> for this component
    '''     by putting it into the "AtLogin" state
    ''' </summary>
    Private Sub GoToInitialState(ByVal sender As Object, ByVal eventArgs As EventArgs)
        VisualStateManager.GoToState(Me, "AtLogin", False)
        RemoveHandler Me.LayoutUpdated, AddressOf Me.GoToInitialState
    End Sub

    ''' <summary>
    '''     Updates the window title according to which panel
    '''     (registration / login) is currently being displayed
    ''' </summary>
    Private Sub UpdateTitle(ByVal sender As Object, ByVal eventArgs As EventArgs)
        Me.Title = If(Me.registrationForm.Visibility = Visibility.Visible, _
                        ApplicationStrings.RegistrationWindowTitle, _
                        ApplicationStrings.LoginWindowTitle)
    End Sub

    ''' <summary>
    '''     Notifies the <see cref="LoginRegistrationWindow"/> window that it can only close
    '''     if <paramref name="operation"/> is finished or can be cancelled
    ''' </summary>
    ''' <param name="operation">The pending operation to monitor</param>
    Public Sub AddPendingOperation(ByVal operation As OperationBase)
        Me.possiblyPendingOperations.Add(operation)
    End Sub

    Public Overridable Sub NavigateToLogin()
        VisualStateManager.GoToState(Me, "AtLogin", True)
    End Sub

    Public Overridable Sub NavigateToRegistration()
        VisualStateManager.GoToState(Me, "AtRegistration", True)
    End Sub

    ''' <summary>
    '''     Prevents the window from closing while there are operations in progress
    ''' </summary>
    Private Sub LoginWindow_Closing(ByVal sender As Object, ByVal eventArgs As CancelEventArgs) Handles Me.Closing
        For Each operation As OperationBase In Me.possiblyPendingOperations
            If Not operation.IsComplete Then
                If operation.CanCancel Then
                    operation.Cancel()
                Else
                    eventArgs.Cancel = True
                End If
            End If
        Next
    End Sub
End Class