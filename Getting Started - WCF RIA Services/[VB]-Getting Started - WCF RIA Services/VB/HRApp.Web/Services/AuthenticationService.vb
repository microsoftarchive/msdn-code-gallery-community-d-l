Imports System.Security.Authentication
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server
Imports System.ServiceModel.DomainServices.Server.ApplicationServices
Imports System.Threading
Namespace Web

    ''' <summary>
    ''' RIA Services DomainService responsible for authenticating users when
    ''' they try to log on to the application.
    ''' 
    ''' Most of the functionality is already provided by the base class
    ''' AuthenticationBase
    ''' </summary>
    <EnableClientAccess()> _
    Public Class AuthenticationService
        Inherits AuthenticationBase(Of User)
    End Class
End Namespace