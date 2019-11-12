Imports System.ComponentModel.DataAnnotations

Namespace Web

    Partial Public NotInheritable Class RegistrationData
        Private _UserName As String
        <Key()> _
        <Required(ErrorMessageResourceName:="ValidationErrorRequiredField", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <Display(Order:=0, Name:="UserNameLabel", ResourceType:=GetType(RegistrationDataResources))> _
        <RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessageResourceName:="ValidationErrorInvalidUserName", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <StringLength(255, MinimumLength:=4, ErrorMessageResourceName:="ValidationErrorBadUserNameLength", ErrorMessageResourceType:=GetType(ErrorResources))> _
        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property

        Private _Email As String
        <Key()> _
        <Required(ErrorMessageResourceName:="ValidationErrorRequiredField", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <Display(Order:=2, Name:="EmailLabel", ResourceType:=GetType(RegistrationDataResources))> _
        <RegularExpression("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessageResourceName:="ValidationErrorInvalidEmail", ErrorMessageResourceType:=GetType(ErrorResources))> _
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property

        Private _Password As String
        <Required(ErrorMessageResourceName:="ValidationErrorRequiredField", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <Display(Order:=3, Name:="PasswordLabel", Description:="PasswordDescription", ResourceType:=GetType(RegistrationDataResources))> _
        <RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName:="ValidationErrorBadPasswordStrength", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <StringLength(50, MinimumLength:=7, ErrorMessageResourceName:="ValidationErrorBadPasswordLength", ErrorMessageResourceType:=GetType(ErrorResources))> _
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property

        Private _FriendlyName As String
        <Display(Order:=1, Name:="FriendlyNameLabel", Description:="FriendlyNameDescription", ResourceType:=GetType(RegistrationDataResources))> _
        <StringLength(255, MinimumLength:=0, ErrorMessageResourceName:="ValidationErrorBadFriendlyNameLength", ErrorMessageResourceType:=GetType(ErrorResources))> _
        Public Property FriendlyName() As String
            Get
                Return _FriendlyName
            End Get
            Set(ByVal value As String)
                _FriendlyName = value
            End Set
        End Property

        Private _Question As String
        <Required(ErrorMessageResourceName:="ValidationErrorRequiredField", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <Display(Order:=5, Name:="SecurityQuestionLabel", ResourceType:=GetType(RegistrationDataResources))> _
        Public Property Question() As String
            Get
                Return _Question
            End Get
            Set(ByVal value As String)
                _Question = value
            End Set
        End Property

        Private _Answer As String
        <Required(ErrorMessageResourceName:="ValidationErrorRequiredField", ErrorMessageResourceType:=GetType(ErrorResources))> _
        <Display(Order:=6, Name:="SecurityAnswerLabel", ResourceType:=GetType(RegistrationDataResources))> _
        Public Property Answer() As String
            Get
                Return _Answer
            End Get
            Set(ByVal value As String)
                _Answer = value
            End Set
        End Property
    End Class
End Namespace