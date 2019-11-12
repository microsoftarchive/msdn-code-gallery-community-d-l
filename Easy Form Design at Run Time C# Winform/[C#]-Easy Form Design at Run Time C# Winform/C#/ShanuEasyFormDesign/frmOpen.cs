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
    public partial class frmOpen : Form
    {
        #region Attribute
        //////////////////////////////////
        /// <summary>
        /// Attributes
        /// </summary>
        /// <returns></returns>
        /// 
        public String OpenFileName = "";
        #endregion
        #region Form Load

        public frmOpen()
        {
            InitializeComponent();
        }

        private void frmOpen_Load(object sender, EventArgs e)
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
            #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            OpenFileName = txtFileNAME.Text;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            OpenFileName = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFileNAME.Text = comboBox1.SelectedItem.ToString();
           
        }

    }
}
