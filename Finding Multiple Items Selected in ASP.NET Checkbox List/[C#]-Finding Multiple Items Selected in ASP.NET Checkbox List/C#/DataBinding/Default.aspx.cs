using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBinding
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblRes.Text = "";

            foreach (ListItem lst in CheckBoxList1.Items)
            {
                if (lst.Selected == true)
                {
                    lblRes.Text += "Selected Item Text: " + lst.Text + " Selected Item Value: " + lst.Value + "<br />";
                }
            }
        }
    }
}