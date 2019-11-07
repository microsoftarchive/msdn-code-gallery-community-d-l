using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGetInstalledApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            

    private void LoadSoftwareList()
    {
        listBox1.Items.Clear();
        ManagementObjectCollection moReturn;  
        ManagementObjectSearcher moSearch;

        moSearch = new ManagementObjectSearcher("Select * from Win32_Product");

        moReturn = moSearch.Get();
       foreach(ManagementObject mo in moReturn)
       {
           listBox1.Items.Add(mo["Name"].ToString());
       }

    }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSoftwareList();
        }
    }
}
