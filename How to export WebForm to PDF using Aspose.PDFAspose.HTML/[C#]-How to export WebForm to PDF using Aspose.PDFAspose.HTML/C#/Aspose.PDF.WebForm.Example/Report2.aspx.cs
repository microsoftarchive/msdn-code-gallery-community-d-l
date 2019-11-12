using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.PDF.WebForm.Example.Helpers;

namespace Aspose.PDF.WebForm.Example
{
    public partial class Report2 : PdfPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/print.css") + "\" />"));
            RenderToPDF = true;
            GridView1.AllowPaging = false;
            Button1.Visible = false;
        }
    }
}