using System;


namespace Aspose.PDF.WebForm.Example
{
    public partial class _Default : WebForms.Helpers.HtmlPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/print.css") + "\" />"));
            RenderToPDF = true;
            GridView1.CssClass = String.Empty;
            GridView1.AllowPaging = false;
            Button1.Visible = false;
        }
    }
}