Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq
Imports System.Reflection
Imports System.ServiceModel.DomainServices.Client
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports System.Windows
Imports System.Windows.Automation.Peers
Imports System.Windows.Automation.Provider
Imports System.Windows.Controls
Imports System.Windows.Data
Imports HRApp.Web

Partial Public Class RegistrationForm
    Inherits StackPanel

    Private registration As New RegistrationData()
    Private registrationContext As New UserRegistrationContext()
    Private parentWindow As LoginRegistrationWindow

    Public Sub New()
        InitializeComponent()

        Me.registrationContext.RegistrationDatas.Add(Me.registration)
        Me.registerForm.CurrentItem = Me.registration
    End Sub

    ''' <remarks>
    '''     <see cref="LoginRegistrationWindow"/> will call this setter
    '''     during its initialization
    ''' </remarks>
    Public Sub SetParentWindow(ByVal window As LoginRegistrationWindow)
        Me.parentWindow = window
    End Sub

    ''' <summary>
    '''     Adds some additional behaviors to some of the DataForm's fields
    ''' </summary>
    Private Sub RegisterForm_AutoGeneratingField(ByVal dataForm As Object, ByVal e As DataFormAutoGeneratingFieldEventArgs) Handles registerForm.AutoGeneratingField
        If e.PropertyName = "Password" Then
            Dim passwordBox As PasswordBox = DirectCast(e.Field.Content, PasswordBox)

            AddHandler passwordBox.PasswordChanged, AddressOf Me.PasswordField_PasswordChanged
            AddHandler passwordBox.LostFocus, AddressOf Me.PasswordField_LostFocus
        ElseIf e.PropertyName = "Question" Then
            ' Create a ComboBox populated with security questions
            Dim comboBoxWithSecurityQuestions As ComboBox = RegistrationForm.CreateComboBoxWithSecurityQuestions()

            ' Replace the control
            ' Note: Since TextBox.Text treats empty text as string.Empty and ComboBox.SelectedItem
            ' treats an empty selection as null, we need to use a converter on the binding
            e.Field.ReplaceTextBox(comboBoxWithSecurityQuestions, ComboBox.SelectedItemProperty, AddressOf Me.ConfigureComboBoxBinding)
        ElseIf e.PropertyName = "UserName" Then
            AddHandler e.Field.Content.LostFocus, AddressOf Me.UserNameTextBox_LostFocus
        End If
    End Sub

    Private Sub ConfigureComboBoxBinding(ByVal comboBoxBinding As Binding)
        comboBoxBinding.Converter = New TargetNullValueConverter()
    End Sub

    ''' <returns>
    '''   Creates a <see cref="ComboBox" /> object whose <see cref="ComboBox.ItemsSource" /> property
    '''   is initialized with the resource string defined in <see cref="SecurityQuestions" />
    ''' </returns>
    Private Shared Function CreateComboBoxWithSecurityQuestions() As ComboBox

        ' Use reflection to grab all the localized security questions
        Dim availableQuestions As IEnumerable(Of String) = From propertyInfo In GetType(SecurityQuestions).GetProperties() _
                                                           Where propertyInfo.PropertyType.Equals(GetType(String)) _
                                                           Select DirectCast(propertyInfo.GetValue(Nothing, Nothing), String)

        ' Create and initialize the ComboBox object
        Dim comboBox As ComboBox = New ComboBox()
        comboBox.ItemsSource = availableQuestions
        Return comboBox
    End Function

    Private Sub PasswordField_PasswordChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' If the password is invalid, the entity property doesn't get updated.
        ' Thus, we keep a separate password copy (the ActualPassword property)
        ' that is guaranteed to match what the user typed
        DirectCast(Me.registerForm.CurrentItem, RegistrationData).ActualPassword = DirectCast(sender, PasswordBox).Password
    End Sub

    Private Sub PasswordField_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        ' Prevent this from having any effect after a submission
        If Me.registration.EntityState = EntityState.Unmodified Then
            Return
        End If

        ' If there is something typed on the password confirmation box
        ' then we need to re-validate it
        If Not [String].IsNullOrEmpty(DirectCast(Me.registerForm.Fields("PasswordConfirmation").Content, PasswordBox).Password) Then
            Me.registerForm.Fields("PasswordConfirmation").Validate()
        End If
    End Sub

    Private Sub UserNameTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        ' Prevent this from having any effect after a submission
        If Me.registration.EntityState = EntityState.Unmodified Then
            Return
        End If

        ' Autofill friendly name from user name if there is not something already in there
        Dim userNameTextBox As TextBox = DirectCast(sender, TextBox)
        Dim friendlyNameTextBox As TextBox = DirectCast(Me.registerForm.Fields("FriendlyName").Content, TextBox)

        If String.IsNullOrEmpty(friendlyNameTextBox.Text) Then
            friendlyNameTextBox.Text = userNameTextBox.Text
        End If
    End Sub

    ''' <summary>
    '''     If form is valid, submits registrationContext information to the server
    ''' </summary>
    Private Sub RegisterButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Me.registerForm.ValidateItem() AndAlso Me.registerForm.CommitEdit() Then
            Dim regOp As SubmitOperation = Me.registrationContext.SubmitChanges(AddressOf Me.RegistrationOperation_Completed, Nothing)
            Me.BindUIToOperation(regOp)
            Me.parentWindow.AddPendingOperation(regOp)
        End If
    End Sub

    ''' <summary>
    '''     Handles <see cref="SubmitOperation.Completed"/> for a registrationContext
    '''     operation. If there was an error, an <see cref="ErrorWindow"/> is
    '''     displayed to the user. Otherwise, this triggers a <see cref="LoginOperation"/>
    '''     that will automatically log in the just registered user
    ''' </summary>
    Private Sub RegistrationOperation_Completed(ByVal asyncResult As SubmitOperation)
        If asyncResult.HasError Then
            ErrorWindow.CreateNew(asyncResult.Error)
            asyncResult.MarkErrorAsHandled()
            Me.registerForm.BeginEdit()
        Else
            Dim loginOperation As LoginOperation = WebContext.Current.Authentication.Login(Me.registration.ToLoginParameters(), AddressOf Me.LoginOperation_Completed, Nothing)
            Me.BindUIToOperation(loginOperation)
            Me.parentWindow.AddPendingOperation(loginOperation)
        End If
    End Sub

    ''' <summary>
    '''     Binds UI so that controls will look disabled and activity will be
    '''     displayed while operation is in progress. For simplicity Cancel button 
    '''     will be disabled during the operation even if it is cancellable
    ''' </summary>
    ''' <param name="operation"></param>
    Private Sub BindUIToOperation(ByVal operation As OperationBase)
        Dim isActivityActiveBinding As Binding = operation.CreateOneWayBinding("IsComplete", New NotOperatorValueConverter())
        Dim isEnabledBinding As Binding = operation.CreateOneWayBinding("IsComplete")

        Me.activity.SetBinding(Activity.IsActiveProperty, isActivityActiveBinding)
        Me.registerForm.SetBinding(Control.IsEnabledProperty, isEnabledBinding)
        Me.registerButton.SetBinding(Control.IsEnabledProperty, isEnabledBinding)
        Me.registerCancel.SetBinding(Control.IsEnabledProperty, isEnabledBinding)
        Me.backToLogin.SetBinding(Control.IsEnabledProperty, isEnabledBinding)
    End Sub

    ''' <summary>
    '''     Handles <see cref="LoginOperation.Completed"/> event for
    '''     the login operation that is sent right after a successful
    '''     registrationContext. This will close the window. On the unexpected
    '''     event that this operation failed (the user was just added so
    '''     why wouldn't it be authenticated successfully) an 
    '''     <see cref="ErrorWindow"/> is created and will display the
    '''     error message.
    ''' </summary>
    ''' <param name="loginOperation"></param>
    Private Sub LoginOperation_Completed(ByVal loginOperation As LoginOperation)
        Me.parentWindow.Close()

        If loginOperation.HasError Then
            ErrorWindow.CreateNew(String.Format(CultureInfo.CurrentUICulture, ApplicationStrings.ErrorLoginAfterRegistrationFailed, loginOperation.Error.Message))
            loginOperation.MarkErrorAsHandled()
        ElseIf Not loginOperation.LoginSuccess Then
            ' ApplicationStrings.ErrorBadUserNameOrPassword is the correct error message as operation succeeded but login failed
            ErrorWindow.CreateNew(String.Format(CultureInfo.CurrentUICulture, ApplicationStrings.ErrorLoginAfterRegistrationFailed, ApplicationStrings.ErrorBadUserNameOrPassword))
        End If
    End Sub

    Private Sub BackToLogin_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.parentWindow.NavigateToLogin()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.parentWindow.Close()
    End Sub
End Class