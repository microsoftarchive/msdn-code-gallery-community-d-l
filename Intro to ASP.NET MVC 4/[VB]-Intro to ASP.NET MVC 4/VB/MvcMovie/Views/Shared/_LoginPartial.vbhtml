@If Request.IsAuthenticated Then
    @<p>
        Hello, @Html.ActionLink(User.Identity.Name, "ChangePassword", "Account", routeValues:=Nothing, htmlAttributes:=New With {.class = "username", .title = "Change password"})!
        @Html.ActionLink("Log off", "LogOff", "Account")
    </p>
Else
    @<ul>
        <li>@Html.ActionLink("Register", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink", .data_dialog_title = "Registration"})</li>
        <li>@Html.ActionLink("Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink", .data_dialog_title = "Identification"})</li>
    </ul>
End If
