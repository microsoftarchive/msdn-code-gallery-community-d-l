using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
/// <summary>
/// Author      : Shanu
/// Create date : 2014-09-26
/// Description : User can create there own Form Design at Runtime
/// Latest
/// Modifier    : 
/// Modify date : 
/// </summary>
namespace ShanuEasyFormDesign
{
    public partial class frmmain : Form
    {
        #region Attribute
        //////////////////////////////////
        /// <summary>
        /// Attributes
        /// </summary>
        /// <returns></returns>
        String fileName = "";
        String xmlFileName_Query = "";
        string[] gParam = null;
        #endregion

        #region Form Load
        public frmmain()
        {
            InitializeComponent();
        }
        private void frmmain_Load(object sender, EventArgs e)
        {
            loadTreeViewFromXML();
        }
        #endregion
        #region Methods
        private void loadTreeViewFromXML()
        {
            string filename = Application.StartupPath + @"\XMLFILE\NewFormNameList.XML";

            if (!File.Exists(filename))
            {
                return;
            }
            try
            {
                // SECTION 1. Create a DOM Document and load the XML data into it.
                XmlDocument dom = new XmlDocument();
                dom.Load(filename);

                // SECTION 2. Initialize the TreeView control.
                treeMenu.Nodes.Clear();
                treeMenu.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
                TreeNode tNode = new TreeNode();
                tNode = treeMenu.Nodes[0];

                // SECTION 3. Populate the TreeView with the DOM nodes.
                AddNode(dom.DocumentElement, tNode);
                treeMenu.ExpandAll();
            }
            catch (XmlException xmlEx)
            {
                MessageBox.Show(xmlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.Name).Trim();
            }
        }
        
        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // MessageBox.Show(treeMenu.SelectedNode.Text);

            try
            {
                fileName = Application.StartupPath + @"\XMLForms\" + treeMenu.SelectedNode.Text + ".XML";
                xmlFileName_Query = Application.StartupPath + @"\XMLForms\" + treeMenu.SelectedNode.Text + "_Query.XML";
                pnlMain.Controls.Clear();
                loadXMLFILE();
                // MessageBox.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private Font StringToFont(string font)
        {
            string[] parts = font.Split(':');
            if (parts.Length != 3)
                throw new ArgumentException("Not a valid font string", "font");

            Font loadedFont = new Font(parts[0], float.Parse(parts[1]), (FontStyle)int.Parse(parts[2]));
            return loadedFont;
        }

        private void loadXMLFILE()
        {
            if (fileName == "")
            {
                return;
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            XmlNode xnList = xml.SelectSingleNode("ShanuFormSave");

            int i = 0;
            
            foreach (XmlNode xn in xnList)
            {
                string CntrlType = xn["ControlsType"].InnerText;
                string LOCX = xn["LocationX"].InnerText;
                string LOCY = xn["LocationY"].InnerText;

                string CNTLWidth = xn["SizeWidth"].InnerText;
                string CNTLHeight = xn["SizeHeight"].InnerText;

                string CntrlText = xn["Text"].InnerText;

                string fonts = xn["Fonts"].InnerText;
                string PictuerImg = xn["picImage"].InnerText;

                string bckColor = xn["BackColor"].InnerText;
                string foreColor = xn["ForeColor"].InnerText;
                string CntrlsName = xn["CntrlsName"].InnerText;
                string CntrlssendtoType = xn["CntrlssendtoType"].InnerText;
                //For grid
                string gridsrowsBackColor = xn["gridsrowsBackColor"].InnerText;
                string gridsAlternaterowsBackColor = xn["gridsAlternaterowsBackColor"].InnerText;
                string gridsheaderColor = xn["gridsheaderColor"].InnerText;
                // For Grid
                if (CntrlType != "System.Windows.Forms.Panel")
                {
                    gParam = new string[] { CntrlType, 
                                                LOCX, 
                                                LOCY, 
                                                CNTLWidth,
                                                CNTLHeight, 
                                                CntrlText,
                                                fonts,
                                                PictuerImg,
                                                 bckColor,
                                                foreColor,
                                                CntrlsName,
                                                CntrlssendtoType,
                                                gridsrowsBackColor,
                                                gridsAlternaterowsBackColor,
                                                gridsheaderColor
                                              };
                    loadShanuLabelDesign();
                }

            }
            foreach (XmlNode xn in xnList)
            {
                string CntrlType = xn["ControlsType"].InnerText;
                string LOCX = xn["LocationX"].InnerText;
                string LOCY = xn["LocationY"].InnerText;

                string CNTLWidth = xn["SizeWidth"].InnerText;
                string CNTLHeight = xn["SizeHeight"].InnerText;

                string CntrlText = xn["Text"].InnerText;

                string fonts = xn["Fonts"].InnerText;
                string PictuerImg = xn["picImage"].InnerText;

                string bckColor = xn["BackColor"].InnerText;
                string foreColor = xn["ForeColor"].InnerText;
                string CntrlsName = xn["CntrlsName"].InnerText;
                string CntrlssendtoType = xn["CntrlssendtoType"].InnerText;
                if (CntrlType == "System.Windows.Forms.Panel")
                {
                    gParam = new string[] { CntrlType, 
                                                LOCX, 
                                                LOCY, 
                                                CNTLWidth,
                                                CNTLHeight, 
                                                CntrlText,
                                                fonts,
                                                PictuerImg,
                                                 bckColor,
                                                foreColor,
                                                CntrlsName,
                                                CntrlssendtoType
                                              };
                    loadShanuLabelDesign();
                }
            }

        }
        private void loadShanuLabelDesign()
        {
            try
            {

                switch (gParam[0])
                {

                    case "System.Windows.Forms.DataGridView": //현재화면 사용가능여부 조회
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);

                            System.Drawing.Color RowsBackColor = new System.Drawing.Color();
                            RowsBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[12]);

                            System.Drawing.Color AlternatebackColor = new System.Drawing.Color();
                            AlternatebackColor = System.Drawing.ColorTranslator.FromHtml(gParam[13]);

                            System.Drawing.Color HeaderColor = new System.Drawing.Color();
                            HeaderColor = System.Drawing.ColorTranslator.FromHtml(gParam[14]);

                            DataGridView ctrl = new DataGridView();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.RowHeadersVisible = false;
                            ctrl.RowsDefaultCellStyle.BackColor = RowsBackColor;
                            ////ctrl.BackgroundColor = RowsBackColor;
                            //////GridColumnStylesCollection Alternate Rows Backcolr
                            ////ctrl.AlternatingRowsDefaultCellStyle.BackColor = AlternatebackColor;
                            ////ctrl.RowsDefaultCellStyle.BackColor = RowsBackColor;
                            //////Column Header back Color
                            ////ctrl.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;

                            ctrl.BackgroundColor = myBackColor;

                            ctrl.RowsDefaultCellStyle.BackColor = Color.White;

                            //GridColumnStylesCollection Alternate Rows Backcolr
                            ctrl.AlternatingRowsDefaultCellStyle.BackColor = AlternatebackColor;

                            //Column Header back Color
                            ctrl.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;
                            ctrl.ColumnHeadersHeight = 30;

                            //////ctrl.AutoGenerateColumns = false;
                            ctrl.EnableHeadersVisualStyles = false;

                            // Enable the row header
                            ctrl.RowHeadersVisible = false;

                            // to Hide the Last Empty row here we use false.
                            ctrl.AllowUserToAddRows = false;
                            pnlMain.Controls.Add(ctrl);
                            //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Label": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);
                            Label ctrl = new Label();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Button":
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            Button ctrl = new Button();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            ctrl.Click += new EventHandler(control_Click);
                            pnlMain.Controls.Add(ctrl);
                            //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.ComboBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);
                            ComboBox ctrl = new ComboBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.ListBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);
                            ListBox ctrl = new ListBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Panel": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            Panel ctrl = new Panel();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            ctrl.SendToBack();
                            pnlMain.Controls.Add(ctrl);
                            //    ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.NumericUpDown": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            NumericUpDown ctrl = new NumericUpDown();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.TreeView": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            TreeView ctrl = new TreeView();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.DateTimePicker": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            DateTimePicker ctrl = new DateTimePicker();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.TextBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            TextBox ctrl = new TextBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.RadioButton": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            RadioButton ctrl = new RadioButton();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.CheckBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            CheckBox ctrl = new CheckBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            pnlMain.Controls.Add(ctrl);
                            // ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.PictureBox": //현재화면 사용가능여부 조회
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            PictureBox ctrl = new PictureBox();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;

                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));

                            if (gParam[7] != "")
                            {
                                Bitmap bmp1 = new Bitmap(new MemoryStream(Convert.FromBase64String(gParam[7])));
                                ctrl.Image = bmp1;
                            }
                            if (gParam[11] == "Front")
                            {
                                ctrl.BringToFront();
                            }
                            else
                            {
                                ctrl.SendToBack();
                            }
                            ctrl.SendToBack();
                            pnlMain.Controls.Add(ctrl);
                            ctrl.SendToBack();
                            //  ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }




        private String ReadConnectionString()
        {
            string path = Application.StartupPath + @"\DBConnection.txt";
            String connectionString = "";
            if (!File.Exists(path))
            {
                using (StreamWriter tw = File.CreateText(path))
                {
                    tw.WriteLine("Data Source=YOURServerName;Initial Catalog=DynamicProject;User id = UID;password=PWD");
                    tw.Close();
                }

            }
            else
            {
                TextReader tr = new StreamReader(path);
                connectionString = tr.ReadLine();
                tr.Close();
            }
            return connectionString;

        }
        public Control returnTextBox(String ControlName)
        {
            Control ctl = null;
            foreach (Control pnlCntl in pnlMain.Controls)
            {
                if (pnlCntl.Name == ControlName)
                {
                    ctl = (Control)pnlCntl;
                    break;
                }
            }

            return ctl;
        }
        #endregion

        #region Events
        private void btnNewForm_Click(object sender, EventArgs e)
        {
            frmMaindesign obj = new frmMaindesign();
            obj.ShowDialog();
            loadTreeViewFromXML();
        }

        /// <summary>
        /// When Runtime Control Clicks this event triger here we can write our code for runtime control click.     
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_Click(object sender, EventArgs e)
        {
            try
            {
                if (xmlFileName_Query != "")
                {
                    XmlDocument xmlQuery = new XmlDocument();
                    xmlQuery.Load(xmlFileName_Query);
                    XmlNode xnQueryList = xmlQuery.SelectSingleNode("ShanuQuerySave");
                    int i = 0;
                    //XmlNode xnListQuery = xnList.SelectSingleNode("SQLQuery");
                    String txtBox1Name = "";
                    String ParameterName1 = "";
                    String ControltoBindName = "";
                    String Query = "";

                    foreach (XmlNode xn in xnQueryList)
                    {
                        Query = xn["ProcedureName"].InnerText;
                    }

                    DataTable dt = new DataTable();
                    String ConnectionString = ReadConnectionString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (XmlNode xn in xnQueryList)
                    {
                        txtBox1Name = xn["cntrlName"].InnerText;
                        ParameterName1 = xn["ParameterName"].InnerText;
                        ControltoBindName = xn["cntrltoBind"].InnerText;
                        Query = xn["ProcedureName"].InnerText;
                        if (txtBox1Name != "")
                        {
                            Control control = returnTextBox(txtBox1Name);
                            if (control is TextBox)
                            {
                                txtBox1Name = control.Text.Trim().ToString();
                            }
                        }
                        cmd.Parameters.AddWithValue(ParameterName1, txtBox1Name);
                    }

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Columns[0].ColumnName == "Result")
                        {
                            MessageBox.Show("Record :" + dt.Rows[0].ItemArray[0].ToString());
                            return;
                        }
                    }

                    //////////if (Query != "")
                    //////////{
                    //////////    String ConnectionString = ReadConnectionString();
                    //////////    if (ParameterName1 != "")
                    //////////    {                      
                    //////////        SqlConnection con = new SqlConnection(ConnectionString);
                    //////////        Query = Query + " Where " + ParameterName1 + " LIKE '" + txtBox1Name + "%'";
                    //////////        SqlCommand cmd = new SqlCommand(Query, con);
                    //////////        cmd.CommandType = CommandType.Text;
                    //////////        SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    //////////        sda.Fill(dt);
                    //////////    }
                    //////////    else
                    //////////    {
                    //////////        SqlConnection con = new SqlConnection(ConnectionString);
                    //////////        SqlCommand cmd = new SqlCommand(Query, con);
                    //////////        cmd.CommandType = CommandType.Text;
                    //////////        SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    //////////        sda.Fill(dt);
                    //////////    }
                    //////////}

                    if (ControltoBindName != "")
                    {
                        foreach (Control pnlCntl in pnlMain.Controls)
                        {
                            if (pnlCntl is DataGridView)
                            {
                                if (pnlCntl.Name == ControltoBindName)
                                {
                                    DataGridView grid = (DataGridView)pnlCntl;
                                    grid.DataSource = dt;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
       
        
    }
}
