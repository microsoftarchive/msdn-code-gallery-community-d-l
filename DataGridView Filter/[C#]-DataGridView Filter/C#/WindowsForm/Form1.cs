using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataGridViewAutoFilter;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //CitiBankEntities1 data = new CitiBankEntities1();
            //var query = data.Student.ToList();
            //IList<Student> list = query;
            //DataTable dt = new DataTable();
            List<SK> s2 = new List<SK>();
            
            SK l = new SK();
            l.ID = 3;
            l.Name = "dsdf";
            s2.Add(l);

            SK k = new SK();
            k.ID = 4;
            k.Name = "dsf";
            s2.Add(k);
            IList<SK> list = s2;
            FilteredBindingList<SK> sm = new FilteredBindingList<SK>(list);
            
            //BindingCollection<Student> s = new BindingCollection<Student>(list); 

            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = sm;
            dataGridView1.DataSource = dataSource;
            this.dataGridView1.SummaryColumns = new string[] { "ID" };

            //Show the SummaryBox
            this.dataGridView1.SummaryRowVisible = true; 

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {           
            // Continue only if the data source has been set.
            String filterStatus = DataGridViewAutoFilterColumnHeaderCell
                .GetFilterStatus(dataGridView1);
            if (String.IsNullOrEmpty(filterStatus))
            {
                showAllLabel.Visible = false;
                filterStatusLabel.Visible = false;
            }
            else
            {
                showAllLabel.Visible = true;
                filterStatusLabel.Visible = true;
                filterStatusLabel.Text = filterStatus;
            }
          

        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            // Continue only if the data source has been set.
            if (dataGridView1.DataSource == null)
            {
                return;
            }

            // Add the AutoFilter header cell to each column.
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell = new
                    DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
            }

            // Resize the columns to fit their contents.
            dataGridView1.AutoResizeColumns();
        }

      


        private void showAllLabel_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(dataGridView1);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.dataGridView1.SummaryRowVisible = !dataGridView1.SummaryRowVisible;   
        }
    }
}
