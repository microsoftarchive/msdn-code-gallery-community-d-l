using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class RasterizePdfPagesToImages : System.Web.UI.Page
    {
        protected void buttonRasterizeToImages_Click(object sender, EventArgs e)
        {
            // get the PDF file
            string pdfFile = Server.MapPath("~") + @"\DemoFiles\Pdf\InputPdf.pdf";

            // create the PDF rasterizer
            PdfRasterizer pdfRasterizer = new PdfRasterizer();

            // set a demo serial number
            pdfRasterizer.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set the output images color space
            pdfRasterizer.ColorSpace = GetColorSpace();

            // set the rasterization resolution in DPI
            pdfRasterizer.DPI = int.Parse(textBoxDPI.Text);

            int fromPdfPageNumber = int.Parse(textBoxFromPage.Text);
            int toPdfPageNumber = textBoxToPage.Text.Length > 0 ? int.Parse(textBoxToPage.Text) : 0;

            // rasterize a range of pages of the PDF document to memory in .NET Image objects
            // the images can also be produced to a folder using the RasterizeToImageFiles method
            // or they can be produced one by one using the RaisePageRasterizedEvent method
            PdfPageRasterImage[] pageImages = pdfRasterizer.RasterizeToImageObjects(pdfFile, fromPdfPageNumber, toPdfPageNumber);

            // return if no page was rasterized
            if (pageImages.Length == 0)
                return;

            // get the first page image bytes in a buffer
            byte[] imageBuffer = null;
            try
            {
                // get the .NET Image object
                System.Drawing.Image imageObject = pageImages[0].ImageObject;

                // get the image data in a buffer
                imageBuffer = GetImageBuffer(imageObject);
            }
            finally
            {
                // dispose the page images
                for (int i = 0; i < pageImages.Length; i++)
                    pageImages[i].Dispose();
            }

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "image/png");

            // let the browser know how to open the image and the image name
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                        String.Format("attachment; filename={0}; size={1}", "PageImage.png", imageBuffer.Length.ToString()));

            // write the image buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(imageBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }

        private RasterImageColorSpace GetColorSpace()
        {
            switch (dropDownListColorSpace.SelectedItem.ToString())
            {
                case "RGB":
                    return RasterImageColorSpace.Rgb;
                case "Gray Scale":
                    return RasterImageColorSpace.GrayScale;
                case "Black and White":
                    return RasterImageColorSpace.BlackWhite;
                default:
                    return RasterImageColorSpace.Rgb;
            }
        }

        private byte[] GetImageBuffer(System.Drawing.Image imageObject)
        {
            // create a memory stream where to save the image
            System.IO.MemoryStream imageMemoryStream = new System.IO.MemoryStream();

            // save the image to memory stream
            imageObject.Save(imageMemoryStream, System.Drawing.Imaging.ImageFormat.Png);

            // get a copy of the image buffer to allow image disposing
            byte[] imageBuffer = new byte[imageMemoryStream.Length];
            Array.Copy(imageMemoryStream.GetBuffer(), imageBuffer, imageBuffer.Length);

            // close the memory stream
            imageMemoryStream.Close();

            return imageBuffer;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageUri = HttpContext.Current.Request.Url.AbsoluteUri;
                hyperLinkOpenPdf.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Pdf/InputPdf.pdf";

                Master.SelectNode("rasterizePdf");
            }
        }
    }
}