using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace WebForms.Helpers
{
    public class HtmlPage : System.Web.UI.Page
    {
        public bool RenderToPDF;
        public string OutputFileName;
        public Aspose.Html.Rendering.Pdf.PdfRenderingOptions options;
        public HtmlPage()
        {
            RenderToPDF = false;
            OutputFileName = "aspose-html-demo.pdf";
            var height = Aspose.Html.Drawing.Unit.FromMillimeters(210);
            var width = Aspose.Html.Drawing.Unit.FromMillimeters(297);
            var pageSizeA4 = new Aspose.Html.Drawing.Size(width, height);
            var margins = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Unit.FromMillimeters(15), // left
                Aspose.Html.Drawing.Unit.FromMillimeters(10), // top
                Aspose.Html.Drawing.Unit.FromMillimeters(15), // right
                Aspose.Html.Drawing.Unit.FromMillimeters(20));// bottom
            options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions
            {
                PageSetup =
                {
                    AnyPage = new Aspose.Html.Drawing.Page(pageSizeA4, margins)
                }
            };
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (RenderToPDF)
            {
                // setup a TextWriter to capture the current page HTML code
                TextWriter tw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(tw);

                // render the HTML markup into the TextWriter
                base.Render(htw);

                // get the current page HTML code
                var htmlCode = tw.ToString();

                // Load HTML file
                var baseUri = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
                var _document = new Aspose.Html.HTMLDocument(htmlCode, baseUri);                

                // Save output as PDF format
                using (var streamOut = new System.IO.MemoryStream())
                {
                    var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, streamOut);
                    var renderer = new Aspose.Html.Rendering.HtmlRenderer();
                    renderer.Render(device, _document);
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AppendHeader("Content-Disposition", $"attachment; filename={OutputFileName}");
                    HttpContext.Current.Response.BinaryWrite(streamOut.ToArray());
                    HttpContext.Current.Response.End();
                }
            }
            else
            {
                // render web page in browser
                base.Render(writer);
            }
        }
    }
}