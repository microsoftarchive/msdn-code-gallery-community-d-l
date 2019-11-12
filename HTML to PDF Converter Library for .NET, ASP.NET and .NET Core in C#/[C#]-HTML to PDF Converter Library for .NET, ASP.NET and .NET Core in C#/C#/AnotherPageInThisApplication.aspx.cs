using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiQPdf_Demo
{
    public partial class AnotherPageInThisApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litSessionVariableValue.Text = Session["SessionVariable"] == null ? "Not Set" : Session["SessionVariable"].ToString();
        }
    }
}