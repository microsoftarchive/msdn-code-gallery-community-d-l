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
    public partial class ConversionTriggeringMode : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set triggering mode; for WaitTime mode set the wait time before convert
            switch (dropDownListTriggeringMode.SelectedValue)
            {
                case "Auto":
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
                case "WaitTime":
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.WaitTime;
                    htmlToPdfConverter.WaitBeforeConvert = int.Parse(textBoxWaitTime.Text);
                    break;
                case "Manual":
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Manual;
                    break;
                default:
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
            }

            // convert the URL to PDF
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(textBoxHtmlCode.Text, null);

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=TriggeringMode.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

            // write the PDF buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(pdfBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }

        protected void dropDownListTriggeringMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelWaitTime.Visible = dropDownListTriggeringMode.SelectedValue == "WaitTime";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDownListTriggeringMode.SelectedValue = "Manual";
                panelWaitTime.Visible = dropDownListTriggeringMode.SelectedValue == "WaitTime";

                Master.SelectNode("conversionTriggeringMode");
            }
        }
    }
}
