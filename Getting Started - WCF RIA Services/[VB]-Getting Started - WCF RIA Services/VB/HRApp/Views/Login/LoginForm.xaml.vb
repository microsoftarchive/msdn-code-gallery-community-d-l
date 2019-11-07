Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.ServiceModel.DomainServices.Client
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Controls
Imports HRApp.Web

Partial Public Class LoginForm
    Inherits StackPanel
    Private parentWindow As LoginRegistrationWindow
    Private loginInfo As New LoginInfo()
    Private lastLoginOperation As LoginOperation

    Public Sub New()
        InitializeComponent()

        Me.loginForm.CurrentItem = Me.loginInfo
    End Sub

    ''' <remarks>
    '''     <see cref="LoginRegistrationWindow"/> will call this setter
    '''     during its initialization
    ''' </remarks>
    Public Sub SetParentWindow(ByVal newLoginContext As LoginRegistrationWindow)
        Me.parentWindow = newLoginContext
    End Sub

    ''' <summary>
    '''     Handles <see cref="DataForm.AutoGeneratingField"/>. Adds the necessary event listeners
    '''     so that the OK button will only be enabled when both username and password are filled
    ''' </summary>
    Private Sub LoginForm_OnAutoGeneratingField(ByVal sender As Object, ByVal e As DataFormAutoGeneratingFieldEventArgs)
        If e.PropertyName = "UserName" Then
            AddHandler DirectCast(e.Field.Content, TextBox).TextChanged, AddressOf EnableOrDisableOKButton
        ElseIf e.PropertyName = "Password" Then
            AddHandler DirectCast(e.Field.Content, PasswordBox).PasswordChanged, AddressOf EnableOrDisableOKButton
        End If
    End Sub

    ''' <summary>
    '''     Enables the OK button if both username and password are not empty, disable it
    '''     otherwise
    ''' </summary>
    Private Sub EnableOrDisableOKButton(ByVal sender As Object, ByVal e As EventArgs)
        Me.loginButton.IsEnabled = Not (String.IsNullOrEmpty(DirectCast(Me.loginForm.Fields("UserName").Content, TextBox).Text.Trim()) Or _
                                        String.IsNullOrEmpty(DirectCast(Me.loginForm.Fields("Password").Content, PasswordBox).Password))
    End Sub
    ''' <summary>
    '''     Submits the <see cref="LoginOperation"/> to the server
    ''' </summary>
    Private Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.loginForm.ValidationSummary.Errors.Clear()

        If Me.loginForm.ValidateItem() Then
            Dim loginOperation As LoginOperation = WebContext.Current.Authentication.Login(Me.loginInfo.ToLoginParameters(), AddressOf Me.LoginOperation_Completed, Nothing)
            Me.BindUIToOperation(loginOperation)
            Me.parentWindow.AddPendingOperation(loginOperation)
            Me.lastLoginOperation = loginOperation
        End If
    End Sub

    ''' <summary>
    '''     Handles <see cref="LoginOperation.Completed"/> event. If operation
    '''     succeeds, it closes the window. If it has an error, we show an <see cref="ErrorWindow"/>
    '''     and mark the error as handled. If it was not canceled, succeded but login failed, 
    '''     it must have been because credentials were incorrect so we add a validation error 
    '''     to notify the user
    ''' </summary>        
    Private Sub LoginOperation_Completed(ByVal loginOperation As LoginOperation)
        If loginOperation.LoginSuccess Then
            Me.parentWindow.Close()
        Else
            If loginOperation.HasError Then
                ErrorWindow.CreateNew(loginOperation.Error)
                loginOperation.MarkErrorAsHandled()
            ElseIf Not loginOperation.IsCanceled Then
                Me.loginForm.ValidationSummary.Errors.Add(New ValidationSummaryItem(ErrorResources.ErrorBadUserNameOrPassword))
            End If

            Me.loginForm.BeginEdit()
        End If
    End Sub

    ''' <summary>
    '''     Binds UI so that controls will look disabled and activity control will
    '''     be displaying while operation is in progress, and cancel button will
    '''     be enabled only while the login operation can be cancelled
    ''' </summary>
    Private Sub BindUIToOperation(ByVal loginOperation As LoginOperation)
        Dim isEnabledBinding As Binding = loginOperation.CreateOneWayBinding("IsComplete")
        Dim isActivityActiveBinding As Binding = loginOperation.CreateOneWayBinding("IsComplete", New NotOperatorValueConverter())
        Dim isCancelEnabledBinding As Binding = loginOperation.CreateOneWayBinding("CanCancel")

        Me.activity.SetBinding(Activity.IsActiveProperty, isActivityActiveBinding)
        Me.loginButton.SetBinding(Control.IsEnabledProperty, isEnabledBinding)
        Me.loginForm.SetBinding(Control.IsEnabledProperty, isEnabledBinding)
        Me.registerNow.SetBinding(Control.IsEnabledProperty, isEnabledBinding)

        ' The correct binding for the cancel button would be
        ' IsEnabled = loginOperation.CanCancel || loginOperation.IsComplete
        '
        '  However, this is a binding to two distinct properties which is
        '  not supported, so we bind solely to CanCancel and remove the binding
        '  once the operation is complete with a callback
        Me.loginCancel.SetBinding(Control.IsEnabledProperty, isCancelEnabledBinding)
        AddHandler loginOperation.Completed, AddressOf Me.ReEnableCancelButton
    End Sub

    ''' <summary>
    '''     Removes the binding that the cancel button will have to <see cref="LoginOperation.CanCancel"/>
    '''     and makes it enabled again
    ''' </summary>
    Private Sub ReEnableCancelButton(ByVal sender As Object, ByVal eventArgs As EventArgs)
        Me.loginCancel.IsEnabled = True
    End Sub

    Private Sub SetEditableState(ByVal enabled As Boolean)
        Activity.IsActive = Not enabled

        Me.loginButton.IsEnabled = enabled
        Me.loginForm.IsEnabled = enabled
        Me.registerNow.IsEnabled = enabled
        Me.loginForm.BeginEdit()
    End Sub

    Private Sub RegisterNow_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.parentWindow.NavigateToRegistration()
    End Sub

    ''' <summary>
    '''     If a login operation is in progress and is cancellable, cancel it.
    '''     Otherwise, closes the window
    ''' </summary>
    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Me.lastLoginOperation IsNot Nothing AndAlso Me.lastLoginOperation.CanCancel Then
            Me.lastLoginOperation.Cancel()
        Else
            Me.parentWindow.Close()
        End If
    End Sub

    ''' <summary>
    '''     Maps ESC to the cancel button and Enter to the
    '''     OK button
    ''' </summary>
    Private Sub LoginPanel_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.Escape Then
            Me.CancelButton_Click(Me.loginCancel, New EventArgs())
        ElseIf e.Key = Key.Enter AndAlso Me.loginButton.IsEnabled Then
            Me.LoginButton_Click(Me.loginButton, New EventArgs())
        End If
    End Sub
End Class