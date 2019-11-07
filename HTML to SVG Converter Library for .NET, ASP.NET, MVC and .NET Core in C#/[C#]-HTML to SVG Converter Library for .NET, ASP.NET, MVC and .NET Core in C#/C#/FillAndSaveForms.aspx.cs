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
    public partial class FillAndSaveForms : System.Web.UI.Page
    {
        protected void buttonFillAndSavePdf_Click(object sender, EventArgs e)
        {
            string pdfFileWithForm = Server.MapPath("~") + @"\DemoFiles\Pdf\PdfWithForm.pdf";

            // load the PDF document with form from file
            PdfDocument document = PdfDocument.FromFile(pdfFileWithForm);

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // get the Check Box field by name from form fields collection and set its value
            PdfFormField checkBoxField = document.Form.Fields["cb"];
            if (checkBoxField != null)
                checkBoxField.Value = checkBoxChecked.Checked;

            // get the Text Box field by name from form fields collection and set its value
            PdfFormField textBoxField = document.Form.Fields["tb"];
            if (textBoxField != null)
                textBoxField.Value = textBoxText.Text;

            // get the List Box field by name from form fields collection and set its value
            PdfFormField listBoxField = document.Form.Fields["lb"];
            if (listBoxField != null)
                listBoxField.Value = dropDownListListBoxValue.SelectedValue;

            // get the Combo Box field by name from form fields collection and set its value
            PdfFormField comboBoxField = document.Form.Fields["combo"];
            if (comboBoxField != null)
                comboBoxField.Value = dropDownListComboBoxValue.SelectedValue;

            // get the Radio Buttons Group field by name from form fields collection and set its value
            PdfFormField radioGroupField = document.Form.Fields["rg"];
            if (radioGroupField != null)
                radioGroupField.Value = radioButton1.Checked ? "rb1" : "rb2";

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=FillForms.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                document.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageUri = HttpContext.Current.Request.Url.AbsoluteUri;
                hyperLinkOpen.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Pdf/PdfWithForm.pdf";
                textBoxPdf.Text = hyperLinkOpen.NavigateUrl;

                dropDownListListBoxValue.SelectedValue = "List Value 2";
                dropDownListComboBoxValue.SelectedValue = "Combo Value 2";

                Master.SelectNode("fillAndSaveForms");
            }
        }
    }
}
