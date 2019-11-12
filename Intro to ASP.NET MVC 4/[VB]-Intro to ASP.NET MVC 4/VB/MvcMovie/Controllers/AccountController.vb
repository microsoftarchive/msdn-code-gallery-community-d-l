Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Web.Routing

<Authorize()> _
Public Class AccountController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Account/Login

    <AllowAnonymous()> _
    Public Function Login() As ActionResult
        Return ContextDependentView()
    End Function

    '
    ' POST: /Account/JsonLogin

    <AllowAnonymous()> _
    <HttpPost()> _
    Public Function JsonLogin(ByVal model As LoginModel, ByVal returnUrl As String) As JsonResult
        If ModelState.IsValid Then
            If Membership.ValidateUser(model.UserName, model.Password) Then
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe)
                Return Json(New With {.success = True, .redirect = returnUrl})
            Else
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If
        End If

        ' If we got this far, something failed
        Return Json(New With {.errors = GetErrorsFromModelState()})
    End Function

    '
    ' POST: /Account/Login

    <AllowAnonymous()> _
    <HttpPost()> _
    Public Function Login(ByVal model As LoginModel, ByVal returnUrl As String) As ActionResult
        If ModelState.IsValid Then
            If Membership.ValidateUser(model.UserName, model.Password) Then
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe)
                If Url.IsLocalUrl(returnUrl) Then
                    Return Redirect(returnUrl)
                Else
                    Return RedirectToAction("Index", "Home")
                End If
            Else
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' GET: /Account/LogOff

    Public Function LogOff() As ActionResult
        FormsAuthentication.SignOut()

        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Account/Register

    <AllowAnonymous()> _
    Public Function Register() As ActionResult
        Return ContextDependentView()
    End Function

    '
    ' POST: /Account/JsonRegister

    <AllowAnonymous()> _
    <HttpPost()> _
    Public Function JsonRegister(ByVal model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            ' Attempt to register the user
            Dim createStatus As MembershipCreateStatus
            Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion:=Nothing, passwordAnswer:=Nothing, isApproved:=True, providerUserKey:=Nothing, status:=createStatus)

            If createStatus = MembershipCreateStatus.Success Then
                FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie:=False)
                Return Json(New With {.success = True})
            Else
                ModelState.AddModelError("", ErrorCodeToString(createStatus))
            End If
        End If

        ' If we got this far, something failed
        Return Json(New With {.errors = GetErrorsFromModelState()})
    End Function

    '
    ' POST: /Account/Register

    <AllowAnonymous()> _
    <HttpPost()> _
    Public Function Register(ByVal model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            ' Attempt to register the user
            Dim createStatus As MembershipCreateStatus
            Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion:=Nothing, passwordAnswer:=Nothing, isApproved:=True, providerUserKey:=Nothing, status:=createStatus)

            If createStatus = MembershipCreateStatus.Success Then
                FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie:=False)
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", ErrorCodeToString(createStatus))
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' GET: /Account/ChangePassword

    Public Function ChangePassword() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Account/ChangePassword

    <HttpPost()> _
    Public Function ChangePassword(ByVal model As ChangePasswordModel) As ActionResult
        If ModelState.IsValid Then
            ' ChangePassword will throw an exception rather
            ' than return false in certain failure scenarios.
            Dim changePasswordSucceeded As Boolean

            Try
                Dim currentUser As MembershipUser = Membership.GetUser(User.Identity.Name, userIsOnline:=True)
                changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword)
            Catch ex As Exception
                changePasswordSucceeded = False
            End Try

            If changePasswordSucceeded Then
                Return RedirectToAction("ChangePasswordSuccess")
            Else
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' GET: /Account/ChangePasswordSuccess

    Public Function ChangePasswordSuccess() As ActionResult
        Return View()
    End Function

    Private Function ContextDependentView() As ActionResult
        Dim actionName As String = ControllerContext.RouteData.GetRequiredString("action")
        If Request.QueryString("content") <> Nothing Then
            ViewBag.FormAction = "Json" + actionName
            Return PartialView()
        Else
            ViewBag.FormAction = actionName
            Return View()
        End If
    End Function

    Private Function GetErrorsFromModelState() As IEnumerable(Of String)
        Return ModelState.SelectMany(Function(x) x.Value.Errors.Select(Function(errorCode) errorCode.ErrorMessage))
    End Function

#Region "Status Code"
    Public Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String
        ' See http://go.microsoft.com/fwlink/?LinkID=177550 for
        ' a full list of status codes.
        Select Case createStatus
            Case MembershipCreateStatus.DuplicateUserName
                Return "User name already exists. Please enter a different user name."

            Case MembershipCreateStatus.DuplicateEmail
                Return "A user name for that e-mail address already exists. Please enter a different e-mail address."

            Case MembershipCreateStatus.InvalidPassword
                Return "The password provided is invalid. Please enter a valid password value."

            Case MembershipCreateStatus.InvalidEmail
                Return "The e-mail address provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidAnswer
                Return "The password retrieval answer provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidQuestion
                Return "The password retrieval question provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidUserName
                Return "The user name provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.ProviderError
                Return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

            Case MembershipCreateStatus.UserRejected
                Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

            Case Else
                Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
        End Select
    End Function
#End Region

End Class
