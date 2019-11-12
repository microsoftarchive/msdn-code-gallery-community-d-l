@ModelType MvcMovie.ChangePasswordModel

@Code
    ViewData("Title") = "Change Password"
End Code

<hgroup class="title">
    <h1>@ViewBag.Title.</h1>
    <h2>Use the form below to change your password.</h2>
</hgroup>

<p class="message-info">
    New passwords are required to be a minimum of @Membership.MinRequiredPasswordLength characters in length.
</p>

<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(true, "Password change was unsuccessful. Please correct the errors and try again.")

    @<fieldset>
        <legend>Change Password Form</legend>
        <ol>
            <li>
                @Html.LabelFor(Function(m) m.OldPassword)
                @Html.PasswordFor(Function(m) m.OldPassword)
                @Html.ValidationMessageFor(Function(m) m.OldPassword)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.NewPassword)
                @Html.PasswordFor(Function(m) m.NewPassword)
                @Html.ValidationMessageFor(Function(m) m.NewPassword)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.ConfirmPassword)
                @Html.PasswordFor(Function(m) m.ConfirmPassword)
                @Html.ValidationMessageFor(Function(m) m.ConfirmPassword)
            </li>
        </ol>
        <input type="submit" value="Change password" />
    </fieldset>
End Using
