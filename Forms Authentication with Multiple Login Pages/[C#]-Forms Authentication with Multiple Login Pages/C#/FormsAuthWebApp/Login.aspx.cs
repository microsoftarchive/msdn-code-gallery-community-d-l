using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormsAuthWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            char[] character = { '/' };

            if (Request["ReturnUrl"] != null)
            {
                // Request["ReturnUrl"].ToString() -> 
                // http://localhost:1965/Admin/Login.aspx;
                // http://localhost:1965/Customer/Login.aspx

                string[] strs = Request["ReturnUrl"].Split(character);

                // if the second part is Admin go to admin login
                if (strs[1] == "Admin")
                {
                    Response.Redirect(@"/Admin/Login.aspx");
                }
                // if the second part is Customer go to customer login
                else if (strs[1] == "Customer")
                {
                    Response.Redirect(@"/Customer/Login.aspx");
                }
            }
        }
    }
}