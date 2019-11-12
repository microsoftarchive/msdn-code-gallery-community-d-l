using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.UI;

namespace UsingRESX
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("UsingRESX.Resource1",
                Assembly.GetExecutingAssembly());
            String strWebsite = rm.GetString("Website",CultureInfo.CurrentCulture);
            String strName = rm.GetString("Name");
            form1.InnerText = "Website: " + strWebsite + "--Name: " + strName;
        }
    }
}