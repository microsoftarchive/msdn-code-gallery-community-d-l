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
    public partial class CreateAndSubmitForms : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create a PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // add a page to document
            PdfPage page = document.AddPage();

            // create true type fonts that can be used in document
            System.Drawing.Font ttfFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont newTimesFont = document.CreateFont(ttfFont, false);

            // create a standard font that can be used in document
            PdfFont helveticaStd = document.CreateStandardFont(PdfStandardFont.Helvetica);
            helveticaStd.Size = 10;

            float crtXPos = 10;
            float crtYPos = 10;

            #region Add Check Box Field

            if (checkBoxAddCheckBox.Checked)
            {
                // add a check box field to PDF form
                PdfFormCheckBox checkBoxField = document.Form.AddCheckBox(page, new System.Drawing.RectangleF(crtXPos, crtYPos, 10, 10));

                checkBoxField.Checked = checkBoxCheckedState.Checked;

                // common field properties 
                checkBoxField.Name = "cb";
                checkBoxField.ToolTip = "Click to change the checked state";
                checkBoxField.Required = false;
                checkBoxField.ReadOnly = false;
                checkBoxField.Flatten = false;

                // advance the current drawing position in PDF page
                crtYPos = checkBoxField.BoundingRectangle.Bottom + 5;
            }

            #endregion

            #region Add Text Box Field

            if (checkBoxAddTextBox.Checked)
            {
                string initialText = textBoxInitialText.Text;
                PdfFormTextBox textBoxField = document.Form.AddTextBox(page, new System.Drawing.RectangleF(crtXPos, crtYPos, 300, 50), initialText, newTimesFont);

                textBoxField.IsMultiLine = checkBoxMultiline.Checked;
                textBoxField.IsPassword = checkBoxIsPassword.Checked;

                textBoxField.Style.ForeColor = System.Drawing.Color.Navy;
                textBoxField.Style.BackColor = System.Drawing.Color.WhiteSmoke;
                textBoxField.Style.BorderStyle = PdfBorderStyle.FixedSingle;
                textBoxField.Style.BorderColor = System.Drawing.Color.Green;

                // common field properties
                textBoxField.Name = "tb";
                textBoxField.ToolTip = "Please enter some text";
                textBoxField.Required = false;
                textBoxField.ReadOnly = false;
                textBoxField.DefaultValue = "Default text";
                textBoxField.Flatten = false;

                // advance the current drawing position in PDF page
                crtYPos = textBoxField.BoundingRectangle.Bottom + 5;
            }

            #endregion

            #region Add  List Box Field

            if (checkBoxAddListBox.Checked)
            {
                string[] listValues = textBoxListBoxValues.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                PdfFormListBox listBoxField = document.Form.AddListBox(page, new System.Drawing.RectangleF(crtXPos, crtYPos, 300, 50), listValues, helveticaStd);

                // common field properties
                listBoxField.Name = "lb";
                listBoxField.ToolTip = "Select an element from the list";
                listBoxField.Required = false;
                listBoxField.ReadOnly = false;
                if (listValues.Length > 0)
                    listBoxField.DefaultValue = listValues[0];
                listBoxField.Flatten = false;

                // advance the current drawing position in PDF page
                crtYPos = listBoxField.BoundingRectangle.Bottom + 5;
            }

            #endregion

            #region Add Combo Box Field

            if (checkBoxAddComboBox.Checked)
            {
                string[] listValues = textBoxComboBoxValues.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                PdfFormComboBox comboBoxField = document.Form.AddComboBox(page, new System.Drawing.RectangleF(crtXPos, crtYPos, 300, 15), listValues, helveticaStd);

                comboBoxField.Editable = checkBoxEditableCombo.Checked;

                // common field properties
                comboBoxField.Name = "combo";
                comboBoxField.ToolTip = "Select an element from the combo drop down";
                comboBoxField.Required = false;
                comboBoxField.ReadOnly = false;
                if (listValues.Length > 0)
                    comboBoxField.DefaultValue = listValues[0];
                comboBoxField.Flatten = false;

                // advance the current drawing position in PDF page
                crtYPos = comboBoxField.BoundingRectangle.Bottom + 5;
            }

            #endregion

            #region Add Radio Buttons Group Field

            if (checkBoxAddRadioButtons.Checked)
            {
                PdfFormRadioButtonsGroup radioGroup = document.Form.AddRadioButtonsGroup(page);

                PdfFormRadioButton rb1 = radioGroup.AddRadioButton(new System.Drawing.RectangleF(crtXPos, crtYPos, 10, 10), "rb1");
                PdfFormRadioButton rb2 = radioGroup.AddRadioButton(new System.Drawing.RectangleF(crtXPos + 20, crtYPos, 10, 10), "rb2");

                radioGroup.SetCheckedRadioButton(rb2);

                radioGroup.Name = "rg";

                // advance the current drawing position in PDF page
                crtYPos = rb1.BoundingRectangle.Bottom + 20;
            }

            #endregion

            #region Create the Submit Button

            // create the Submit button
            PdfFormButton submitButton = document.Form.AddButton(page, new System.Drawing.RectangleF(crtXPos, crtYPos, 100, 20), "Submit Form", newTimesFont);
            submitButton.Name = "submitButton";

            // create the submit action with the submit URL
            PdfSubmitFormAction submitAction = new PdfSubmitFormAction(textBoxSubmitUrl.Text);
            // set the action flags such that the form values are submitted in HTML form format
            submitAction.Flags |= PdfFormSubmitFlags.ExportFormat;
            if (radioButtonGet.Checked)
                submitAction.Flags |= PdfFormSubmitFlags.GetMethod;

            // set the submit button action
            submitButton.Action = submitAction;

            #endregion

            #region Create the Reset Button

            if (checkBoxAddResetButton.Checked)
            {
                // create the reset button
                PdfFormButton resetButton = document.Form.AddButton(page, new System.Drawing.RectangleF(crtXPos + 120, crtYPos, 100, 20),
                                                        "Reset Form", newTimesFont);
                resetButton.Name = "resetButton";

                // create the reset action
                PdfResetFormAction resetAction = new PdfResetFormAction();

                // set the reset button action
                resetButton.Action = resetAction;
            }

            #endregion

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=CreateForms.pdf; size={0}",
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
                Master.SelectNode("createAndSubmitForms");
            }
        }
    }
}
