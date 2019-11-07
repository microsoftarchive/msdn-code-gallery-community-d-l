using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormsAuthWebApp.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userData = "";
            string userName = "";

            if (DropDownList1.SelectedIndex == 0) // admin
            {
                userData = "Admin"; // set userData
                userName = "Admin User Name"; 
            }
            else if (DropDownList1.SelectedIndex == 1) //customer
            {
                userData = "Customer"; // set userData
                userName = "Customer User Name";
            }

            // initialize FormsAuthentication
            FormsAuthentication.Initialize();

            // create a new ticket used for authentication
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

            // encrypt the cookie using the machine key for secure transport
            string encTicket = FormsAuthentication.Encrypt(authTicket);

            // create and add the cookie to the list for outgoing response
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            Response.Cookies.Add(faCookie);

            Response.Redirect("/Admin/WebForm1.aspx");
        }
    }
}