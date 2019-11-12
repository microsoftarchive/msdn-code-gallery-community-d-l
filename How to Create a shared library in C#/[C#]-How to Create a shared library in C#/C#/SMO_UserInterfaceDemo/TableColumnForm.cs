using SMO_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMO_UserInterfaceDemo
{
    public partial class TableColumnForm : Form
    {
        List<ColumnDetails> columDetails;
        public TableColumnForm()
        {
            InitializeComponent();
        }
        public TableColumnForm(List<ColumnDetails> pColumnDetails)
        {
            InitializeComponent();
            columDetails = pColumnDetails;
            Shown += TableColumnForm_Shown;
        }

        private void TableColumnForm_Shown(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = columDetails;
        }
    }
}
