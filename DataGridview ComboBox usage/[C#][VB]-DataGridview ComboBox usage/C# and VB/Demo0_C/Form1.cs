using System;
using System.Windows.Forms;

namespace Demo0_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrepareDataGridView.Populate(DataGridView1);
            DataGridView1.ExpandColumns();
        }
    }
}