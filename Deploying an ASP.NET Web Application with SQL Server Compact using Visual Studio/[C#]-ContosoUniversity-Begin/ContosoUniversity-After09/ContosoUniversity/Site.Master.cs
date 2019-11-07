using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ContosoUniversity
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string environment = ConfigurationManager.AppSettings["Environment"].ToString();
            if (environment == "Dev" || environment == "Test")
            {
                EnvironmentLabel.Text = "(" + environment + ")";
            }
        }
    }
}
