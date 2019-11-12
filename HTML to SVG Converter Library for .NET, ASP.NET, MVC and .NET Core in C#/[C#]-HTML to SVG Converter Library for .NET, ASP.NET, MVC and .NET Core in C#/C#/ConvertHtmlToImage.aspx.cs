using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class ConvertHtmlToImage : System.Web.UI.Page
    {
        protected void buttonConvertToImage_Click(object sender, EventArgs e)
        {
            // create the HTML to Image converter
            HtmlToImage htmlToImageConverter = new HtmlToImage();

            // set a demo serial number
            htmlToImageConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set browser width
            htmlToImageConverter.BrowserWidth = int.Parse(textBoxBrowserWidth.Text);

            // set browser height if specified, otherwise use the default
            if (textBoxBrowserHeight.Text.Length > 0)
                htmlToImageConverter.BrowserHeight = int.Parse(textBoxBrowserHeight.Text);

            // set HTML Load timeout
            htmlToImageConverter.HtmlLoadedTimeout = int.Parse(textBoxLoadHtmlTimeout.Text);

            // set whether the resulted image is transparent (has effect only when the output format is PNG)
            htmlToImageConverter.TransparentImage = (dropDownListImageFormat.SelectedValue == "PNG") ?
                        checkBoxTransparentImage.Checked : false;

            // set triggering mode; for WaitTime mode set the wait time before convert
            switch (dropDownListTriggeringMode.SelectedValue)
            {
                case "Auto":
                    htmlToImageConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
                case "WaitTime":
                    htmlToImageConverter.TriggerMode = ConversionTriggerMode.WaitTime;
                    htmlToImageConverter.WaitBeforeConvert = int.Parse(textBoxWaitTime.Text);
                    break;
                case "Manual":
                    htmlToImageConverter.TriggerMode = ConversionTriggerMode.Manual;
                    break;
                default:
                    htmlToImageConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
            }

            // convert to image
            System.Drawing.Image imageObject = null;
            string imageFormatName = dropDownListImageFormat.SelectedValue.ToLower();
            string imageFileName = String.Format("HtmlToImage.{0}", imageFormatName);

            if (radioButtonConvertUrl.Checked)
            {
                // convert URL
                string url = textBoxUrl.Text;

                imageObject = htmlToImageConverter.ConvertUrlToImage(url)[0];
            }
            else
            {
                // convert HTML code
                string htmlCode = textBoxHtmlCode.Text;
                string baseUrl = textBoxBaseUrl.Text;

                imageObject = htmlToImageConverter.ConvertHtmlToImage(htmlCode, baseUrl)[0];
            }

            // get the image buffer in the selected image format
            byte[] imageBuffer = GetImageBuffer(imageObject);

            // the image object rturned by converter can be disposed
            imageObject.Dispose();

            // inform the browser about the binary data format
            string mimeType = imageFormatName == "jpg" ? "jpeg" : imageFormatName;
            HttpContext.Current.Response.AddHeader("Content-Type", "image/" + mimeType);

            // let the browser know how to open the image and the image name
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                        String.Format("attachment; filename={0}; size={1}", imageFileName, imageBuffer.Length.ToString()));

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
            imageObject.Save(imageMemoryStream, GetSelectedImageFormat());

            // get a copy of the image buffer to allow image disposing
            byte[] imageBuffer = new byte[imageMemoryStream.Length];
            Array.Copy(imageMemoryStream.GetBuffer(), imageBuffer, imageBuffer.Length);

            // close the memory stream
            imageMemoryStream.Close();

            return imageBuffer;
        }

        private System.Drawing.Imaging.ImageFormat GetSelectedImageFormat()
        {
            switch (dropDownListImageFormat.SelectedValue)
            {
                case "PNG":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case "JPG":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "BMP":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                default:
                    return System.Drawing.Imaging.ImageFormat.Png;
            }
        }

        protected void dropDownListImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxTransparentImage.Visible = dropDownListImageFormat.SelectedValue == "PNG";
        }

        protected void radioButtonConvertUrl_CheckedChanged(object sender, EventArgs e)
        {
            panelUrl.Visible = radioButtonConvertUrl.Checked;
            panelHtmlCode.Visible = !radioButtonConvertUrl.Checked;
        }

        protected void radioButtonConvertHtmlCode_CheckedChanged(object sender, EventArgs e)
        {
            panelUrl.Visible = !radioButtonConvertHtmlCode.Checked;
            panelHtmlCode.Visible = radioButtonConvertHtmlCode.Checked;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDownListImageFormat.SelectedValue = "PNG";
                checkBoxTransparentImage.Visible = true;

                panelUrl.Visible = radioButtonConvertUrl.Checked;
                panelHtmlCode.Visible = !radioButtonConvertUrl.Checked;

                dropDownListTriggeringMode.SelectedValue = "WaitTime";
                panelWaitTime.Visible = true;

                Master.SelectNode("htmlToImage");
            }
        }

        protected void dropDownListTriggeringMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelWaitTime.Visible = dropDownListTriggeringMode.SelectedValue == "WaitTime";
        }
    }
}
