using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace getPostGetMethods
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["path"], true);
            
            if (Request.QueryString.Count > 0)
            {
                sw.WriteLine("vars sent " + DateTime.Now + " Get Method");
                for (int i = 0; i < Request.QueryString.Count; i++)
                {
                    sw.WriteLine("Index: " + Request.QueryString.GetKey(i) + " Values: " + Request.QueryString[i]);
                }
                sw.WriteLine(" ");
            }


            if (Request.Form.Count > 0)
            {
                sw.WriteLine("vars sent " + DateTime.Now + " Post Method");
                for (int i = 0; i < Request.Form.Count; i++)
                {
                    sw.WriteLine("Index: " + Request.Form.GetKey(i) + " Values: " + Request.Form[i]);
                }
                sw.WriteLine(" ");
            }

                sw.Close();
            
        }
    }
}