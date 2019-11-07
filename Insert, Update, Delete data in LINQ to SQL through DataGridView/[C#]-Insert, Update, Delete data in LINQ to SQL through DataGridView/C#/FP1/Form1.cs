using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30");
            StudentInfo SI = new StudentInfo();
            //dataGridView1.ColumnCount = 4;
            //dataGridView1.Columns[0].Name = "Student ID";
            //dataGridView1.Columns[1].Name = "Student Name";
            //dataGridView1.Columns[2].Name = "Student Marks";
            //dataGridView1.Columns[3].Name = "Student Grade";
            var query = from q in SDCD1.StudentInfos
                        select q;
            dataGridView1.DataSource = query;



        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30");
            StudentInfo SI = new StudentInfo();
            int rowindex = dataGridView1.CurrentRow.Index;  // here rowindex will get through currentrow property of datagridview.

            SI.Id = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            SI.Name = Convert.ToString(dataGridView1.Rows[rowindex].Cells[1].Value);
            SI.Marks = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[2].Value);

            SI.Grade = Convert.ToString(dataGridView1.Rows[rowindex].Cells[3].Value);

            SDCD1.StudentInfos.InsertOnSubmit(SI);//InsertOnSubmit queries will automatic call thats the data context class handle it.
            SDCD1.SubmitChanges();
            MessageBox.Show("Saved");
            rowindex = 0;
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            //StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30");
            //StudentInfo SI = new StudentInfo();
            //int rowindex = dataGridView1.CurrentRow.Index;

            //SI.Id = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            //SI.Name = Convert.ToString(dataGridView1.Rows[rowindex].Cells[1].Value);
            //SI.Marks = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[2].Value);

            //SI.Grade = Convert.ToString(dataGridView1.Rows[rowindex].Cells[3].Value);

            //SDCD1.StudentInfos.InsertOnSubmit(SI);
            //SDCD1.SubmitChanges();
            //MessageBox.Show(rowindex.ToString());
            //rowindex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iid = 0;
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30");
            StudentInfo SI = new StudentInfo();
            int rowindex = dataGridView1.CurrentRow.Index;  // here rowindex will get through currentrow property of datagridview.
            iid = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            var delete = from p in SDCD1.StudentInfos
                         where p.Id == iid// match the ecords.
                         select p;
            SDCD1.StudentInfos.DeleteAllOnSubmit(delete);// DeleteAllOnSubmit function will call and queries will automatic call thats the data context class handle it.
            SDCD1.SubmitChanges();
         //   SI = SDCD1.StudentInfos.Single(c => c.Id == iid);   
            rowindex = 0;

            MessageBox.Show("deleted");
            Refresh();

        }
        private void Refresh()
        {
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30");
            StudentInfo SI = new StudentInfo();
            var query = from q in SDCD1.StudentInfos
                        select q;
            dataGridView1.DataSource = query;// Attaching the all data with Datagridview
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iid = 0;
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30");
            StudentInfo SI = new StudentInfo();
            int rowindex = dataGridView1.CurrentRow.Index;   // here rowindex will get through currentrow property of datagridview.
            iid = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            var update = from s1 in SDCD1.StudentInfos
                         where s1.Id == iid
                         select s1;
            foreach (var v in update)
            {
                v.Id = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
                v.Name = Convert.ToString(dataGridView1.Rows[rowindex].Cells[1].Value);
                v.Marks = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[2].Value);
                v.Grade = Convert.ToString(dataGridView1.Rows[rowindex].Cells[3].Value);
            SDCD1.SubmitChanges(); // here will submitchanges function call and queries will automatic call.
            }
            MessageBox.Show("Updated");
            Refresh();// refresh the data gridview.

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox1.Items.Add(checkBox1.Text);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox1.Items.Add(checkBox2.Text);
        }
    }
}
