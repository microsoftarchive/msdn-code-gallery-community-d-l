using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Xml.XPath;

namespace FillFormField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //open form
            Document document = new Document("UserForm.doc");

            //load data
            using (Stream stream = File.OpenRead("User.xml"))
            {
                XPathDocument xpathDoc = new XPathDocument(stream);
                XPathNavigator user = xpathDoc.CreateNavigator().SelectSingleNode("/user");

                //fill data
                foreach (FormField field in document.Sections[0].Body.FormFields)
                {
                    String path = String.Format("{0}/text()", field.Name);
                    XPathNavigator propertyNode = user.SelectSingleNode(path);
                    if (propertyNode != null)
                    {
                        switch (field.Type)
                        {
                            case FieldType.FieldFormTextInput:
                                field.Text = propertyNode.Value;
                                break;

                            case FieldType.FieldFormDropDown:
                                DropDownFormField combox = field as DropDownFormField;
                                for(int i = 0; i < combox.DropDownItems.Count; i++)
                                {
                                    if (combox.DropDownItems[i].Text == propertyNode.Value)
                                    {
                                        combox.DropDownSelectedIndex = i;
                                        break;
                                    }
                                    if (field.Name == "country" && combox.DropDownItems[i].Text == "Others")
                                    {
                                        combox.DropDownSelectedIndex = i;
                                    }
                                }
                                break;

                            case FieldType.FieldFormCheckBox:
                                if (Convert.ToBoolean(propertyNode.Value))
                                {
                                    CheckBoxFormField checkBox = field as CheckBoxFormField;
                                    checkBox.Checked = true;
                                }
                                break;
                        }
                    }
                }
            }

            //Save doc file.
            document.SaveToFile("Sample.doc",FileFormat.Doc);

            //Launching the MS Word file.
            WordDocViewer("Sample.doc");
        }

        private void WordDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
