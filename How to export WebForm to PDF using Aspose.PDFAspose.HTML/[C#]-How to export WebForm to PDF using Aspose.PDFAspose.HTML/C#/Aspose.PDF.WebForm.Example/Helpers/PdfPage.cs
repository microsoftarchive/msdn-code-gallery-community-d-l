using System;
using System.IO;
using System.Web.UI;
using Aspose.Pdf;

namespace Aspose.PDF.WebForm.Example.Helpers
{
    public class PdfPage : System.Web.UI.Page
    {
        public bool RenderToPDF;
        public readonly string OutputFileName;
        public MarginInfo margins;
        public PdfPage()
        {
            RenderToPDF = false;
            OutputFileName = "aspose-pdf-demo.pdf";
            margins = new MarginInfo(10, 10, 10, 10);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (RenderToPDF)
            {
                // get html of the page                
                var pageInfo = new PageInfo { Margin = margins };

                var memoryStream = new MemoryStream();
                var streamWriter = new StreamWriter(memoryStream);
                var htmlWriter = new HtmlTextWriter(streamWriter);
                base.Render(htmlWriter);

                string baseUri = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
                streamWriter.Flush();
                               
                // Load HTML file
                memoryStream.Position = 0;
                var pdfDocument = new Document(memoryStream,
                    new HtmlLoadOptions(baseUri)
                    {
                        PageInfo = pageInfo,
                    });

                // Save output as PDF format
                using (var streamOut = new MemoryStream())
                {
                    pdfDocument.Save(streamOut);
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={OutputFileName}");
                    Response.BinaryWrite(streamOut.ToArray());
                    Response.End();
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