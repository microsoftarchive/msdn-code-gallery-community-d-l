@ModelType MvcMovie.RegisterModel

@Code
    ViewData("Title") = "Register"
End Code

<hgroup class="title">
    <h1>@ViewBag.Title.</h1>
    <h2>Use the form below to create a new account.</h2>
</hgroup>

<p class="message-info">
    Passwords are required to be a minimum of @Membership.MinRequiredPasswordLength characters in length.
</p>

<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>

@Using Html.BeginForm(ViewBag.FormAction, "Account")
    @Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again." )

    @<fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li>
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.Email)
                @Html.TextBoxFor(Function(m) m.Email)
                @Html.ValidationMessageFor(Function(m) m.Email)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.Password)
                @Html.PasswordFor(Function(m) m.Password)
                @Html.ValidationMessageFor(Function(m) m.Password)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.ConfirmPassword)
                @Html.PasswordFor(Function(m) m.ConfirmPassword)
                @Html.ValidationMessageFor(Function(m) m.ConfirmPassword)
            </li>
        </ol>
        <input type="submit" value="Register" />
    </fieldset>
End Using
