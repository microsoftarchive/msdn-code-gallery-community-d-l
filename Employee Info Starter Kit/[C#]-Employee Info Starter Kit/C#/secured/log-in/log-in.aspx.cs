using System;
using Eisk.Helpers;

public partial class Public_Log_On : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            SiteLogin.RedirectToDefaultPage();
        }
    }
    
    protected void ButtonLogOn_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtUserName.Value) || String.IsNullOrEmpty(txtPassword.Value))
            labelMessage.Text = MessageFormatter.GetFormattedErrorMessage("You can login using a username and a password associated with your account. Make sure that it is typed correctly.");
        else
        {
            if (txtUserName.Value == "any" && txtPassword.Value == "any")//if the log-in is successful
            {
                SiteLogin.PerformAuthentication("member1", checkBoxRemember.Checked);
            }
            else
            {
                labelMessage.Text = MessageFormatter.GetFormattedErrorMessage("<strong>Login Failed!</strong><hr/>The username and/or password you entered do not belong to any User account on our system.<br/>You can login using a username and a password associated with your account. Make sure that it is typed correctly.");
            }
        }
    }
    protected void ButtonAdminLogOn_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtUserName.Value) || String.IsNullOrEmpty(txtPassword.Value))
            labelMessage.Text = MessageFormatter.GetFormattedErrorMessage("<strong>Login Please!</strong><hr/>You can login using a username and a password associated with your account. Make sure that it is typed correctly.");
        else
        {

            if (txtUserName.Value == "any" && txtPassword.Value == "any")//if the log-in is successful
            {
                SiteLogin.PerformAdminAuthentication("admin1", checkBoxRemember.Checked);
            }
            else
            {
                labelMessage.Text = MessageFormatter.GetFormattedErrorMessage("<strong>Login Failed!</strong><hr/>The username and/or password you entered do not belong to any Administrator ccount on our system.<br/>You can login using a username and a password associated with your account. Make sure that it is typed correctly.");
            }
        }
    }
}
