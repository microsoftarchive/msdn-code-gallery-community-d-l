Imports System.ComponentModel.DataAnnotations
Imports System.ServiceModel.DomainServices.Client
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports HRApp.Web

''' <summary>
''' This internal entity is used to ease the binding between the UI controls
''' (DataForm and the label displaying a validation error) and the log on
''' credentials entered by the user
''' </summary>
Public Class LoginInfo
    Inherits Entity
    Private _UserName As String
    <Display(Name:="UserNameLabel", ResourceType:=GetType(RegistrationDataResources))> _
    <Required()> _
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Private _Password As String
    <Display(Name:="PasswordLabel", ResourceType:=GetType(RegistrationDataResources))> _
    <Required()> _
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Private _RememberMe As Boolean
    <Display(Name:="RememberMeLabel", ResourceType:=GetType(ApplicationStrings))> _
    Public Property RememberMe() As Boolean
        Get
            Return _RememberMe
        End Get
        Set(ByVal value As Boolean)
            _RememberMe = value
        End Set
    End Property

    ''' <summary>
    '''     Creates a new <see cref="System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters"/>
    '''     using the data stored in this entity
    ''' </summary>
    Public Function ToLoginParameters() As LoginParameters
        Return New System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters(Me.UserName, Me.Password, Me.RememberMe, Nothing)
    End Function
End Class
