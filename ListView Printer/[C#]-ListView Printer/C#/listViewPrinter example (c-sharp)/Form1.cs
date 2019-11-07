using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] groupNames = {
	                            "Group1",
	                            "Group2",
	                            "Group3"
                              };
        Random randomObject = new Random();


        private void Form1_Load(object sender, EventArgs e)
        {
            for (int r = 1; r <= 250; r++)
            {
                string randomGroupName = groupNames[randomObject.Next(0, 3)];
                ListViewGroup group = new ListViewGroup(randomGroupName, randomGroupName);
                if (!ListView1.Groups.Cast<ListViewGroup>().Any((ListViewGroup lvg) => lvg.Name == randomGroupName))
                {
                    ListView1.Groups.Add(group);
                }

                ListViewItem item = ListView1.Items.Add(new ListViewItem(new string[] {
				string.Format("A{0}", r),
				string.Format("B{0}", r),
				string.Format("C{0}", r),
				string.Format("D{0}", r),
				string.Format("E{0}", r),
				string.Format("F{0}", r),
				string.Format("G{0}", r),
				string.Format("H{0}", r),
				string.Format("I{0}", r),
				string.Format("J{0}", r),
				string.Format("K{0}", r),
				string.Format("L{0}", r),
				string.Format("M{0}", r),
				string.Format("N{0}", r),
				string.Format("O{0}", r),
				string.Format("P{0}", r),
				string.Format("Q{0}", r),
				string.Format("R{0}", r),
				string.Format("S{0}", r),
				string.Format("T{0}", r),
				string.Format("U{0}", r),
				string.Format("V{0}", r),
				string.Format("W{0}", r),
				string.Format("X{0}", r),
				string.Format("Y{0}", r),
				string.Format("Z{0}", r)
			}));

                ListView1.Groups.Cast<ListViewGroup>().First((ListViewGroup lvg) => lvg.Name == randomGroupName).Items.Add(item);
            }

            List<ListViewGroup> listGroups = ListView1.Groups.Cast<ListViewGroup>().ToList();
            listGroups.Sort(new groupSorter());
            ListView1.Groups.Clear();
            ListView1.Groups.AddRange(listGroups.ToArray());

            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for (int x = 0; x < ListView1.Columns.Count; x++)
            {
                ListView1.Columns[x].Width += 12;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listViewPrinter printer = new listViewPrinter(ListView1, new Point(50, 50), chkBorder.Checked, ListView1.Groups.Count > 0, "titleText");
            printer.print();
        }

        private void chkGridLines_CheckedChanged(object sender, EventArgs e)
        {
            ListView1.GridLines = chkGridLines.Checked;
        }
    }
}