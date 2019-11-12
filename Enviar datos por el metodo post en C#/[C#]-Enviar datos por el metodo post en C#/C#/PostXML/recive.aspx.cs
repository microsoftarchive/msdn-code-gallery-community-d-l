using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PostXML
{
    public partial class recive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/xml";
            // Read XML posted via HTTP
            StreamReader reader = new StreamReader(Page.Request.InputStream);
            String xmlData = reader.ReadToEnd();
            //aqui podemos hacer lo que se nos ocurra con xmlData, por ejemplo
            //podemos parsear el codigo xml y guardarlo en una base de datos por ejemplo

            if (xmlData != "" && Request.Form.Count == 0)
            {
                Application["xml"] = xmlData;
            }
            
        }

        protected void show_Click(object sender, EventArgs e)
        {
            Label1.Text =HttpUtility.HtmlEncode(Application["xml"]==null? "" : Application["xml"].ToString());
        }
    }
}