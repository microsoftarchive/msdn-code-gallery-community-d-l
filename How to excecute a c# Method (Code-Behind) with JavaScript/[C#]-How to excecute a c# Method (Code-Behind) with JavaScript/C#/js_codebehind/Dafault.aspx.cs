using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace js_codebehind
{
    public partial class Dafault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);//This is important to make the "__doPostBack()" method, works properly

            if (Request.Form["__EVENTTARGET"] == "Button2_Click")
            {
                //call the method
                Button2_Click(this, new EventArgs());
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "Method called!!!";
        }
    }
}