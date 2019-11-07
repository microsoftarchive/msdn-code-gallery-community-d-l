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
    public partial class ConvertHtmlToSvg : System.Web.UI.Page
    {
        protected void buttonConvertToSvg_Click(object sender, EventArgs e)
        {
            // create the HTML to SVG converter
            HtmlToSvg htmlToSvgConverter = new HtmlToSvg();

            // set a demo serial number
            htmlToSvgConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set browser width
            htmlToSvgConverter.BrowserWidth = int.Parse(textBoxBrowserWidth.Text);

            // set browser height if specified, otherwise use the default
            if (textBoxBrowserHeight.Text.Length > 0)
                htmlToSvgConverter.BrowserHeight = int.Parse(textBoxBrowserHeight.Text);

            // set HTML Load timeout
            htmlToSvgConverter.HtmlLoadedTimeout = int.Parse(textBoxLoadHtmlTimeout.Text);

            // set triggering mode; for WaitTime mode set the wait time before convert
            switch (dropDownListTriggeringMode.SelectedValue)
            {
                case "Auto":
                    htmlToSvgConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
                case "WaitTime":
                    htmlToSvgConverter.TriggerMode = ConversionTriggerMode.WaitTime;
                    htmlToSvgConverter.WaitBeforeConvert = int.Parse(textBoxWaitTime.Text);
                    break;
                case "Manual":
                    htmlToSvgConverter.TriggerMode = ConversionTriggerMode.Manual;
                    break;
                default:
                    htmlToSvgConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
            }

            // convert to SVG
            string svgFileName = "HtmlToSvg.svg";
            byte[] svgBuffer = null;

            if (radioButtonConvertUrl.Checked)
            {
                // convert URL
                string url = textBoxUrl.Text;

                svgBuffer = htmlToSvgConverter.ConvertUrlToMemory(url);
            }
            else
            {
                // convert HTML code
                string htmlCode = textBoxHtmlCode.Text;
                string baseUrl = textBoxBaseUrl.Text;

                svgBuffer = htmlToSvgConverter.ConvertHtmlToMemory(htmlCode, baseUrl);
            }

            // inform the browser about the data format
            HttpContext.Current.Response.AddHeader("Content-Type", "image/svg+xml");

            // let the browser know how to open the SVG and the SVG file name
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                        String.Format("attachment; filename={0}; size={1}", svgFileName, svgBuffer.Length.ToString()));

            // write the SVG buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(svgBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
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
                panelUrl.Visible = radioButtonConvertUrl.Checked;
                panelHtmlCode.Visible = !radioButtonConvertUrl.Checked;

                dropDownListTriggeringMode.SelectedValue = "WaitTime";
                panelWaitTime.Visible = true;

                Master.SelectNode("htmlToSvg");
            }
        }

        protected void dropDownListTriggeringMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelWaitTime.Visible = dropDownListTriggeringMode.SelectedValue == "WaitTime";
        }
    }
}
