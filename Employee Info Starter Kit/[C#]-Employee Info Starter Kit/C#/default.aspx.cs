using System;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Eisk.Install.TestSqlClientConnectionString() == string.Empty)
        {
            Response.Redirect("~/web-form-samples/listing-page.aspx");
        }
        else
        {
            Response.Redirect("~/App_Resources/system/install/install-db.aspx");
        }
    }
}
