using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfigurationLibrary_cs;

namespace Demo_cs
{
    public partial class Form1 : Form
    {
        ConnectionProtection operations = 
            new ConnectionProtection(Application.ExecutablePath);
        public Form1()
        {
            InitializeComponent();
        }

        private void peopleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.peopleBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.peopleDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // This line need to be executed once before giving the app to your customer
            operations.EncryptFile();


            operations.DecryptFile();

            // TODO: This line of code loads data into the 'peopleDataSet.People' table. You can move, or remove it, as needed.
            this.peopleTableAdapter.Fill(this.peopleDataSet.People);

            operations.EncryptFile();
        }
    }
}
