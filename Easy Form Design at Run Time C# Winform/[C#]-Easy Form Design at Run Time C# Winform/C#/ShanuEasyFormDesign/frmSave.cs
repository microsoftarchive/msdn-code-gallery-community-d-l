using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
/// <summary>
/// Author      : Shanu
/// Create date : 2015-01-05
/// Description : To Save the Form created by User
/// Latest
/// Modifier    : 
/// Modify date : 
/// </summary>
namespace ShanuEasyFormDesign
{
    public partial class frmSave : Form
    {
        #region Attribute
        //////////////////////////////////
        /// <summary>
        /// Attributes
        /// </summary>
        /// <returns></returns>
        /// 
        public String SaveFileName = "";
        #endregion
        #region Form Load

        public frmSave()
        {
            InitializeComponent();
        }


        private void frmSave_Load(object sender, EventArgs e)
        {
            LoadnodestoComboBox();
        }

      
        #endregion


        #region Method

        private void LoadnodestoComboBox()
        {
            string path = Application.StartupPath + @"XMLFILE";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filename = Application.StartupPath + @"\XMLFILE\NewFormNameList.XML";
            comboBox1.Items.Add("Select");
            if (File.Exists(filename))
            {

                //create new instance of XmlDocument
                XmlDocument doc = new XmlDocument();

                //load from file
                doc.Load(filename);


                foreach (XmlNode RootNode in doc.ChildNodes)
                {
                    if (RootNode.NodeType != XmlNodeType.XmlDeclaration)
                    {
                        foreach (XmlNode Node1Node in RootNode.ChildNodes)
                        {
                            comboBox1.Items.Add(Node1Node.Name);
                        }
                    }
                }
            }
            comboBox1.SelectedIndex = 0;

        }

        private void GenerateMenuList()
        {
            String fileName = Application.StartupPath + @"\XMLForms\" + txtXMLFileName.Text.Trim() + ".XML";
            SaveFileName = txtXMLFileName.Text.Trim();
            if (File.Exists(fileName))
            {
                return;
            }

            string filename = Application.StartupPath + @"\XMLFILE\NewFormNameList.XML";

            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();

            if (!File.Exists(filename))
            {
                //Populate with data here if necessary, then save to make sure it exists


                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);

                // Create the root element
                XmlElement rootNode1 = doc.CreateElement("MenuList");
                doc.InsertBefore(xmlDeclaration, doc.DocumentElement);
                doc.AppendChild(rootNode1);
                doc.Save(filename);
            }

            //load from file
            doc.Load(filename);
            XmlNode rootNode = null;

            if (comboBox1.SelectedItem.ToString() == "Select")
            {
                rootNode = doc.CreateNode(XmlNodeType.Element, txtXMLFileName.Text.Trim(), null);
                doc.DocumentElement.AppendChild(rootNode);
            }
            else
            {
                rootNode = doc.SelectSingleNode("MenuList/" + comboBox1.SelectedItem.ToString());
                if (rootNode != null)
                {
                    XmlElement xmlEle = doc.CreateElement(txtXMLFileName.Text.Trim());
                    rootNode.AppendChild(xmlEle);
                }
                else
                {
                    rootNode = doc.CreateNode(XmlNodeType.Element, txtXMLFileName.Text.Trim(), null);
                    doc.DocumentElement.AppendChild(rootNode);
                }
            }

            //save back
            doc.Save(filename);
           
        }
        #endregion





        #region Events

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtXMLFileName.Text.Trim() == "")
            {
                MessageBox.Show("Enter the Valid Menu Name");
            }
            GenerateMenuList();
            LoadnodestoComboBox();
        }
        #endregion

        private void btnCancle_Click(object sender, EventArgs e)
        {
            SaveFileName = "";
        }





    }
}
