Imports System
Imports System.Collections.Generic
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server
Imports System.Web.Profile
Imports System.Web.Security
Namespace Web

    ''' <summary>
    ''' RIA Services Domain Service that exposes methods for performing user
    ''' registrations.
    ''' </summary>
    <EnableClientAccess()> _
    Public Class UserRegistrationService
        Inherits DomainService
        ' Users will be added to this role by default
        Public Const DefaultRole As String = "Registered Users"

        ' NOTE: This is a sample code to get your application started. In the production code you would 
        ' want to provide a mitigation against a denial of service attack by providing CAPTCHA 
        ' control functionality or verifying user's email address.

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")> _
        Public Sub AddUser(ByVal user As RegistrationData)
            If user Is Nothing Then
                Throw New ArgumentNullException("user")
            End If

            ' Run this BEFORE creating the user to make sure roles are enabled and the default role
            ' will be available
            '
            ' If there are a problem with the role manager it is better to fail now than to have it
            ' happening after the user is created
            If Not Roles.RoleExists(UserRegistrationService.DefaultRole) Then
                Roles.CreateRole(UserRegistrationService.DefaultRole)
            End If

            ' NOTE: ASP.NET by default uses SQL Server Express to create the user database. 
            ' CreateUser will fail if you do not have SQL Server Express installed.
            Dim createStatus As MembershipCreateStatus
            Membership.CreateUser(user.UserName, user.Password, user.Email, user.Question, user.Answer, True, _
            Nothing, createStatus)

            If createStatus <> MembershipCreateStatus.Success Then
                Throw New DomainException(ErrorCodeToString(createStatus))
            End If

            ' Assign it to the default role
            ' This *can* fail but only if role management is disabled
            Roles.AddUserToRole(user.UserName, UserRegistrationService.DefaultRole)

            ' Set its friendly name (profile setting)
            ' This *can* fail but only if Web.config is configured incorrectly 
            Dim profile As ProfileBase = ProfileBase.Create(user.UserName, True)
            profile.SetPropertyValue("FriendlyName", user.FriendlyName)
            profile.Save()
        End Sub

        ' This is never used but without it RIA Services will complain RegistrationData
        ' is not exposed as an entity
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")> _
        Public Function GetUsers() As IEnumerable(Of RegistrationData)
            Throw New NotSupportedException()
        End Function

        Private Shared Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String
            ' See http://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus.aspx for
            ' a full list of status codes and add appropriate error handling.
            Select Case createStatus
                Case MembershipCreateStatus.DuplicateUserName
                    Return ClientCultureBasedResources.GetResource(Function() ErrorResources.MembershipCreateStatusDuplicateUserName)

                Case MembershipCreateStatus.DuplicateEmail
                    Return ClientCultureBasedResources.GetResource(Function() ErrorResources.MembershipCreateStatusDuplicateEmail)

                Case MembershipCreateStatus.ProviderError
                    Return ClientCultureBasedResources.GetResource(Function() ErrorResources.MembershipCreateStatusProviderError)

                Case MembershipCreateStatus.UserRejected
                    Return ClientCultureBasedResources.GetResource(Function() ErrorResources.MembershipCreateStatusUserRejected)

                Case MembershipCreateStatus.InvalidPassword, MembershipCreateStatus.InvalidEmail, MembershipCreateStatus.InvalidAnswer, MembershipCreateStatus.InvalidQuestion, MembershipCreateStatus.InvalidUserName
                    ' All this errors should have been handled by the UI validation so theoretically
                    ' we should never get to this point
                    Return "Validation Error: " & createStatus.ToString()
                Case Else

                    Return "Could not register the user, please verify the provided information and try again."
            End Select
        End Function
    End Class
End Namespace