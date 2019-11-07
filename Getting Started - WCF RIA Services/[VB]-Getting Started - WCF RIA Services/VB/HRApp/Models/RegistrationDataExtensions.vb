Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ServiceModel.DomainServices.Client.ApplicationServices

Namespace Web

    Partial Public Class RegistrationData

#Region "Password Confirmation Field and Validation"
        Private _passwordConfirmation As String

        ''' <summary>
        '''     Stores the password the user entered in the registration UI, even if it is
        '''     invalid. This way we can validate the password confirmation adequately all
        '''     the times
        ''' </summary>
        ''' <remarks>
        '''     This gets set on the <see cref="System.Windows.Controls.PasswordBox.PasswordChanged"/> event
        ''' </remarks>
        Private _ActualPassword As String
        <Display(AutoGenerateField:=False)> _
        Friend Property ActualPassword() As String
            Get
                Return _ActualPassword
            End Get
            Set(ByVal value As String)
                _ActualPassword = value
            End Set
        End Property

        <Required(ErrorMessageResourceName:="ValidationErrorRequiredField", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <Display(Order:=4, Name:="PasswordConfirmationLabel", ResourceType:=GetType(RegistrationDataResources))> _
        <CustomValidation(GetType(RegistrationData), "CheckPasswordConfirmation")> _
        Public Property PasswordConfirmation() As String
            Get
                Return Me._passwordConfirmation
            End Get

            Set(ByVal value As String)
                Me.ValidateProperty("PasswordConfirmation", value)
                Me._passwordConfirmation = value
                Me.RaisePropertyChanged("PasswordConfirmation")
            End Set
        End Property

        Public Shared Function CheckPasswordConfirmation(ByVal passwordConfirmation As String, ByVal validationContext As ValidationContext) As ValidationResult
            If validationContext Is Nothing Then
                Throw New ArgumentNullException("validationContext")
            End If

            Dim registrationData As RegistrationData = DirectCast(validationContext.ObjectInstance, RegistrationData)

            If registrationData.ActualPassword = passwordConfirmation Then
                Return ValidationResult.Success
            End If

            Return New ValidationResult(ErrorResources.ValidationErrorPasswordConfirmationMismatch, New String() {"PasswordConfirmation"})
        End Function
#End Region

#Region "Make DisplayName Bindable"
        Protected Overrides Sub OnPropertyChanged(ByVal e As System.ComponentModel.PropertyChangedEventArgs)
            If e Is Nothing Then
                Throw New ArgumentNullException("e")
            End If

            MyBase.OnPropertyChanged(e)

            If e.PropertyName = "UserName" Or e.PropertyName = "FriendlyName" Then
                Me.RaisePropertyChanged("DisplayName")
            End If
        End Sub
#End Region

#Region "Convenience Methods"
        ''' <summary>
        '''     Creates a new <see cref="System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters"/>
        '''     initialized with this entity's data (IsPersistent will default to false)
        ''' </summary>
        Public Function ToLoginParameters() As LoginParameters
            Return New System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters(Me.UserName, Me.Password, False, Nothing)
        End Function
#End Region
    End Class
End Namespace