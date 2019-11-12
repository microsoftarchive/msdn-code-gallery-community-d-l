using System;
using System.Windows.Forms;

namespace MultipleExports_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportOperations ops = new ExportOperations();
            ops.ExportData();
            if (ops.HasErrors)
            {
                MessageBox.Show($"Failed: {ops.ExeptionMessage}");
            }
            else
            {
                MessageBox.Show($"Done: inserted {ops.RecordsInserted} records.");
            }
        }
    }
}
