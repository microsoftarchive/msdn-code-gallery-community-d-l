/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using System;
using Eisk.DataAccessLayer;
using System.Web.UI.WebControls;
using System.Web;
using Eisk.Helpers;

public partial class Master_Default : System.Web.UI.MasterPage
{
    protected void lbtGenerateTestData_Click(object sender, EventArgs e)
    {
        SqlScriptRunner.RunScript(Server.MapPath("~/App_Data/SQL/Data/Clean-Data.sql"));
        SqlScriptRunner.RunScript(Server.MapPath("~/App_Data/SQL/Data/Create-Data.sql"));
        ltlMessage.Text = MessageFormatter.GetFormattedSuccessMessage("Test Data Generated.");
        Page.DataBind();

    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Page.Header.DataBind();
    }
}
