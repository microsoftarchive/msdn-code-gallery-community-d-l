using System.Linq;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;
using ExtendedDataGridView;

namespace Extended_DGV_Demo3
{
    public partial class frmMain { 

        List<int> answers;

        int x;

        Random r = new Random();
        DataTable dt = new DataTable();
        string[,] operands = {
        {
            "+",
            "-"
        },
        {
            "/",
            "*"
        } };

        public frmMain()
        {
            InitializeComponent();

            loadDGV1();
            ExtendedDataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(235, 240, 250);
            ExtendedDataGridView1.Rows[1].Cells[2].Style.BackColor = Color.FromArgb(230, 250, 175);
            loadDGV2();
            foreach (DataGridViewRow row in ExtendedDataGridView2.Rows)
            {
                if (row.Index == ExtendedDataGridView2.NewRowIndex)
                    continue;
                row.Cells[2].Value = "Button" + (row.Index + 1).ToString();
            }
            loadDGV3();
            loadDGV4();
        }  
        
                
#region "     loadDGVs"

        public void loadDGV1()
        {
            answers = new List<int>();
            ExtendedDataGridView1.Rows.Clear();
            ExtendedDataGridView1.Rows.Add(10);

            for (int i = 1; i <= 10; i++)
            {
                int i1 = r.Next(2, 11);
                int i2 = r.Next(2, 11);
                int i3 = r.Next(2, 11);

                while (i2 == i1)
                {
                    i2 = r.Next(1, 11);
                }

                while (i3 == i1 | i3 == i2)
                {
                    i3 = r.Next(1, 11);
                }

                //Label2.Text
                string s1 = operands[0, r.Next(0, 2)] + " " + i1.ToString();
                //Label3.Text
                string s2 = operands[1, r.Next(0, 2)] + " " + i2.ToString();
                //Label4.Text
                string s3 = operands[0, r.Next(0, 2)] + " " + i3.ToString();

                x = r.Next(1, 101);
                while (Convert.ToDecimal(dt.Compute(string.Format("((({0} {1}) {2}) {3})", x.ToString(), s1, s2, s3), null)) % 1 != 0)
                {
                    x = r.Next(1, 101);
                }

                ExtendedDataGridView1.Rows[i - 1].Cells[0].Value = string.Format("x {0} {1} {2} = {3}", s1, s2, s3, Convert.ToInt32(dt.Compute(string.Format("((({0} {1}) {2}) {3})", x.ToString(), s1, s2, s3), null)));
                ExtendedDataGridView1.Rows[i - 1].Tag = x;
                answers.Add(x);
            }

            answers = answers.OrderBy(x1 => r.NextDouble()).Distinct().ToList();
            ((DataGridViewComboBoxColumn)ExtendedDataGridView1.Columns[1]).ValueType = typeof(int);
            ((DataGridViewComboBoxColumn)ExtendedDataGridView1.Columns[1]).DataSource = answers;
        }

        public void loadDGV2()
        {
            ExtendedDataGridView2.Rows.Add(10);
            for (int y = 0; y <= 9; y++)
            {
                ExtendedDataGridView2.Rows[y].Cells[0].Value = y + 2;
                ExtendedDataGridView2.Rows[y].Cells[1].Value = (y + 2).ToString() + " ^ 1";
            }
        }

        public void loadDGV3()
        {
            ExtendedDataGridView3.Rows.Add(10);
            ExtendedDataGridView3.Rows[0].SetValues("Google", "https://www.google.co.uk");
            ExtendedDataGridView3.Rows[1].SetValues("bing", "http://www.bing.com/");
            ExtendedDataGridView3.Rows[2].SetValues("Yahoo", "https://uk.yahoo.com/?p=us");
            ExtendedDataGridView3.Rows[3].SetValues("altavista", "https://search.yahoo.com/?fr=altavista");
            ExtendedDataGridView3.Rows[4].SetValues("excite", "http://www.excite.com/");
            ExtendedDataGridView3.Rows[5].SetValues("Go.com", "http://go.com/");
            ExtendedDataGridView3.Rows[6].SetValues("HotBot", "http://www.hotbot.com/");
            ExtendedDataGridView3.Rows[7].SetValues("Galaxy", "http://www.galaxy.com/");
            ExtendedDataGridView3.Rows[8].SetValues("search.aol", "http://search.aol.com/aol/webhome");
            ExtendedDataGridView3.Rows[9].SetValues("GigaBlast", "http://www.gigablast.com/");
        }

        public void loadDGV4()
        {
            for (int x = (int)'A'; x <= (int)'A' + 25; x++)
            {
                ExtendedDataGridView4.Columns.Add("column" + (x - (int)'A' + 1).ToString(), ((Char)x).ToString());
            }
            ExtendedDataGridView4.Rows.Add(100);
            ExtendedDataGridView4.RowHeadersWidth = 60;
            for (int y = 0; y <= 99; y++)
            {
                ExtendedDataGridView4.Rows[y].HeaderCell.Value = (y + 1).ToString();
            }
            for (int y = 1; y <= 100; y++)
            {
                for (int x = 1; x <= 26; x++)
                {
                    ExtendedDataGridView4.Rows[y - 1].Cells[x - 1].Value = string.Format("R{0}C{1}", y, x);
                }
            }
        }

        #endregion

        private void ExtendedDataGridView1_cellCheckedChanged(object sender, CheckBoxChangedEventArgs e)
        {
            ExtendedDataGridView1[1, e.rowIndex].ReadOnly = e.newValue;
            //Debugger.Break();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //preview
            ((ExtendedDataGridView.ExtendedDataGridViewControl)TabControl1.SelectedTab.Controls[0]).PreviewPrint();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //print
            ((ExtendedDataGridView.ExtendedDataGridViewControl)TabControl1.SelectedTab.Controls[0]).Print();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //save
            ((ExtendedDataGridView.ExtendedDataGridViewControl)TabControl1.SelectedTab.Controls[0]).SaveasCSV();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //check answers
            foreach (DataGridViewRow row in ExtendedDataGridView1.Rows)
            {
                if (row.Index == ExtendedDataGridView1.NewRowIndex)
                    continue;
                int correctAnswer = (int)row.Tag;
                int userAnswer = 0;
                if (row.Cells[1].Value != null)
                {
                    userAnswer = Convert.ToInt32(row.Cells[1].Value.ToString());
                }
                else
                {
                    row.Cells[3].Value = Extended_DGV_Demo3_cs.Properties.Resources.cross;
                    continue;
                }
                if (correctAnswer == userAnswer)
                {
                    row.Cells[3].Value = Extended_DGV_Demo3_cs.Properties.Resources.tick;
                }
                else
                {
                    row.Cells[3].Value = Extended_DGV_Demo3_cs.Properties.Resources.cross;
                }
            }
        }

        private void ExtendedDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex == ExtendedDataGridView2.NewRowIndex)
                return;
            if (ExtendedDataGridView2[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                BigInteger value = BigInteger.Parse(ExtendedDataGridView2[0, e.RowIndex].Value.ToString());
                ExtendedDataGridView2[0, e.RowIndex].Value = BigInteger.Pow(value, 2);
                ExtendedDataGridView2[1, e.RowIndex].Value = value.ToString() + " ^ 2";
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button4.Visible = TabControl1.SelectedIndex == 0;
        }

        private void ExtendedDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex == ExtendedDataGridView3.NewRowIndex)
                return;
            if (e.ColumnIndex == 1)
            {
                object o = ExtendedDataGridView3[1, e.RowIndex].Value;
                if (o != null)
                {
                    Uri uri = null;
                    if (Uri.TryCreate(o.ToString(), UriKind.Absolute, out uri))
                    {
                        Process.Start(uri.ToString());
                    }
                }
            }
        }
                
    }
}


