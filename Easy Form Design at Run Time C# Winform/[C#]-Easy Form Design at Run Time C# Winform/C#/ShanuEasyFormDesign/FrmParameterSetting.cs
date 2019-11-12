using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace ShanuEasyFormDesign
{
    public partial class FrmParameterSetting : Form
    {
        string[] gParam = null;
        List<String> ControlNames = new List<String>();
        public FrmParameterSetting(List<String> ControlNamesget)
        {
            InitializeComponent();
            ControlNames = ControlNamesget;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         


        }

        private void FrmParameterSetting_Load(object sender, EventArgs e)
        {
            LoadSPCopmbo();
            listView2.Items.Clear();
            foreach (string prime in ControlNames) // Loop through List with foreach.
            {               
                    ListViewItem lvi = new ListViewItem(prime);                  
                    this.listView2.Items.Add(lvi);               
            }
        }

        public void LoadSPCopmbo()
        {
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            String Query = "SELECT name  FROM dbo.sysobjects WHERE (type = 'P') ORDER BY  name";
            DataTable dt = returnDataDatable(Query);
            comboBox1.ValueMember = "name";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = dt;

        }

        private String ReadConnectionString()
        {
            string path = Application.StartupPath + @"\DBConnection.txt";
            String connectionString = "";
            if (!File.Exists(path))
            {
                using (StreamWriter tw = File.CreateText(path))
                {
                    tw.WriteLine("Data Source=YOURServerName;Initial Catalog=DynamicProject;User id = YOURUID;password=YOURPWD");
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
        public DataTable returnDataDatable(String Query)
        {
            String ConnectionString = ReadConnectionString();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
           
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);
            return dt;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                txtSPNAME.Text = comboBox1.SelectedValue.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            String Query = "SELECT p.name AS Name, t.name AS Type, p.max_length AS Length FROM sys.parameters AS p JOIN sys.types AS t ON t.user_type_id = p.user_type_id WHERE object_id = OBJECT_ID('" + txtSPNAME.Text.Trim().ToString() +"')";
            DataTable dt = returnDataDatable(Query);
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lvi = new ListViewItem(dr["Name"].ToString());

                lvi.SubItems.Add(dr["Type"].ToString());
                lvi.SubItems.Add(dr["Length"].ToString());

                this.listView1.Items.Add(lvi);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtParameter.Text="";
            if (listView1.SelectedItems.Count > 0)
            {
                txtParameter.Text = listView1.SelectedItems[0].Text.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtControlName.Text = "";
            if (listView2.SelectedItems.Count > 0)
            {
                txtControlName.Text = listView2.SelectedItems[0].Text.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtParameter.Text.Trim() == "")
            {
                MessageBox.Show("Add parameter");
                return;
            }
            if (txtControlName.Text.Trim() == "")
            {
                MessageBox.Show("Add Control Name");
                return;
            }

            ListViewItem lvi = new ListViewItem(txtParameter.Text.Trim());

            lvi.SubItems.Add(txtControlName.Text.Trim());

            this.listView3.Items.Add(lvi);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView3.Items.Count; i++)
            {
                ShanuEasyFormDesign.Class.ControlList obj1 = new ShanuEasyFormDesign.Class.ControlList(txtSPNAME.Text.Trim(), listView3.Items[i].SubItems[0].Text.ToString(), listView3.Items[i].SubItems[1].Text.ToString());
                
                ShanuEasyFormDesign.Class.ControlList.objDGVBind.Add(obj1);
            }
        }
    }
}
