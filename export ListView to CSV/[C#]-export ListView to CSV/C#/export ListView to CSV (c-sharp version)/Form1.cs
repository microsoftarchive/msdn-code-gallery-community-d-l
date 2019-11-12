using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace export_ListView_to_CSV__c_sharp_version_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            //declare new SaveFileDialog + set it's initial properties

            {
	            SaveFileDialog sfd = new SaveFileDialog {
		            Title = "Choose file to save to",
		            FileName = "example.csv",
		            Filter = "CSV (*.csv)|*.csv",
		            FilterIndex = 0,
		            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
	            };

	            //show the dialog + display the results in a msgbox unless cancelled


                if (sfd.ShowDialog() == DialogResult.OK) {
                    
                    string[] headers = ListView1.Columns
                               .OfType<ColumnHeader>()
                               .Select(header => header.Text.Trim())
                               .ToArray();

                    string[][] items = ListView1.Items
                                .OfType<ListViewItem>()
                                .Select(lvi => lvi.SubItems
                                    .OfType<ListViewItem.ListViewSubItem>()
                                    .Select(si => si.Text).ToArray()).ToArray();

                    string table = string.Join(",", headers) + Environment.NewLine;
                    foreach (string[] a in items)
                    {
                        //a = a_loopVariable;
                        table += string.Join(",", a) + Environment.NewLine;
                    }
                    table = table.TrimEnd('\r', '\n');
                    System.IO.File.WriteAllText(sfd.FileName, table);

                }
            }
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 1; x <= 5; x++)
            {
                ListView1.Items.Add(new ListViewItem(new string[] {
				"r" + x.ToString() + "c1",
				"r" + x.ToString() + "c2",
				"r" + x.ToString() + "c3",
				"r" + x.ToString() + "c4",
				"r" + x.ToString() + "c5"
			}));
            }

        }
    }
}
