using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PassingData
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void QueryStringButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("QueryStringPage.aspx?Data=" + Server.UrlEncode(DataToSendTextBox.Text));
        }

        protected void SessionStateButton_Click(object sender, EventArgs e)
        {
            Session["Data"] = DataToSendTextBox.Text;
            Response.Redirect("SessionStatePage.aspx");
        }

        public string DataToSend
        {
            get
            {
                return DataToSendTextBox.Text;
            }
        }

        protected void PublicPropertiesButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("PublicPropertiesPage.aspx");
        }

        protected void ControlInfoButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("ControlInfoPage.aspx");
        }

    }
}