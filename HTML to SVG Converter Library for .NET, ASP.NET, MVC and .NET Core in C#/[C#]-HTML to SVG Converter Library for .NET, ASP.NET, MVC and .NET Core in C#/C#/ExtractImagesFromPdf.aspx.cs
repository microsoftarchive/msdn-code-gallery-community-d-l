using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class ExtractImagesFromPdf : System.Web.UI.Page
    {
        protected void buttonExtractImages_Click(object sender, EventArgs e)
        {
            // get the PDF file
            string pdfFile = Server.MapPath("~") + @"\DemoFiles\Pdf\InputPdf.pdf";

            // create the PDF images extractor
            PdfImagesExtract pdfImagesExtract = new PdfImagesExtract();

            // set a demo serial number
            pdfImagesExtract.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            int fromPdfPageNumber = int.Parse(textBoxFromPage.Text);
            int toPdfPageNumber = textBoxToPage.Text.Length > 0 ? int.Parse(textBoxToPage.Text) : 0;

            // extract the images from PDF document to memory in .NET Image objects
            // the images can also be extracted to a folder using the ExtractToImageFiles method 
            // or they can be extracted one by one using the RaiseImageExtractedEvent method
            ExtractedPdfImage[] extractedImages = pdfImagesExtract.ExtractToImageObjects(pdfFile, fromPdfPageNumber, toPdfPageNumber);

            // return if no image was extracted
            if (extractedImages.Length == 0)
                return;

            // get the largest image bytes in a buffer
            byte[] imageBuffer = null;
            try
            {
                // select the largest image
                ExtractedPdfImage largestImage = null;
                for (int i = 0; i < extractedImages.Length; i++)
                {
                    if (largestImage == null || extractedImages[i].ImageObject.Size.Width * extractedImages[i].ImageObject.Size.Height >
                        largestImage.ImageObject.Size.Width * largestImage.ImageObject.Size.Height)
                    {
                        largestImage = extractedImages[i];
                    }
                }

                // get the .NET Image object
                System.Drawing.Image imageObject = largestImage.ImageObject;

                // get the image data in a buffer
                imageBuffer = GetImageBuffer(imageObject);
            }
            finally
            {
                // dispose the extracted images
                for (int i = 0; i < extractedImages.Length; i++)
                    extractedImages[i].Dispose();
            }

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "image/png");

            // let the browser know how to open the image and the image name
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                        String.Format("attachment; filename={0}; size={1}", "ExtractedImage.png", imageBuffer.Length.ToString()));

            // write the image buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(imageBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
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

                Master.SelectNode("extractImages");
            }
        }
    }
}