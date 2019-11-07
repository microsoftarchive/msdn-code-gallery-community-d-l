using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Management;

namespace ExtendedDataGridView
{
    public partial class altPrintDialog
    {
        PrintDocument document;

        DataTable dt = new DataTable();
        Dictionary<int, string> states = new Dictionary<int, string> {
        {
            1,
            "Other"
        },
        {
            2,
            "Unknown"
        },
        {
            3,
            "Idle"
        },
        {
            4,
            "Printing"
        },
        {
            5,
            "Warmup"
        },
        {
            6,
            "Stopped Printing"
        },
        {
            7,
            "Offline"
        }

    };

        ErrorProvider ep = new ErrorProvider();
        public int maxPortraitPages { get; set; }
        public int maxLandscapePages { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        public altPrintDialog(PrintDocument document, int maxPortraitPages, int maxLandscapePages)
        {
            dt.Columns.Add("Name");
            dt.Columns.Add("Status");
            dt.Columns.Add("Type");
            dt.Columns.Add("Where");

            queryPrinters(ref dt);

            this.document = document;
            this.maxPortraitPages = maxPortraitPages;
            this.maxLandscapePages = maxLandscapePages;
            string selectedPrinter = this.document.PrinterSettings.PrinterName;

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

            ComboBox1.DataSource = dt;
            ComboBox1.DisplayMember = "Name";

            Label7.DataBindings.Add("Text", dt, "Status");
            Label8.DataBindings.Add("Text", dt, "Type");
            Label9.DataBindings.Add("Text", dt, "Where");

            ComboBox1.SelectedIndex = ComboBox1.FindStringExact(selectedPrinter);

            NumericUpDown4.Value = document.DefaultPageSettings.Margins.Left;
            NumericUpDown5.Value = document.DefaultPageSettings.Margins.Right;
            NumericUpDown6.Value = document.DefaultPageSettings.Margins.Top;
            NumericUpDown7.Value = document.DefaultPageSettings.Margins.Bottom;

            RadioButton4.Checked = this.document.DefaultPageSettings.Landscape;
            NumericUpDown3.Maximum = RadioButton4.Checked ? maxLandscapePages : maxPortraitPages;
            NumericUpDown2.Maximum = NumericUpDown3.Maximum;

            NumericUpDown3.Value = NumericUpDown3.Maximum;
            NumericUpDown2.Value = 1;

            this.document.PrinterSettings.FromPage = 1;
            this.document.PrinterSettings.ToPage = Convert.ToInt32(NumericUpDown3.Value);

            this.document.PrinterSettings.Collate = false;

        }

        private void queryPrinters(ref DataTable dt)
        {
            dynamic printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (ManagementBaseObject p in printerQuery.Get())
            {
                string Name = p.GetPropertyValue("Name").ToString();
                string status = states[Convert.ToInt32(p.GetPropertyValue("PrinterStatus").ToString())];
                string type = p.GetPropertyValue("deviceID").ToString();
                string @where = p.GetPropertyValue("portName").ToString();
                dt.Rows.Add(Name, status, type, @where);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                PictureBox1.Image = ExtendedDataGridViewCS.Properties.Resources.a;
                CheckBox1.Top += 3;
            }
            else
            {
                PictureBox1.Image = ExtendedDataGridViewCS.Properties.Resources.b;
                CheckBox1.Top -= 3;
            }
            this.document.PrinterSettings.Collate = CheckBox1.Checked;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)ComboBox1.SelectedItem;
            this.document.PrinterSettings.PrinterName = drv["Name"].ToString();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (NumericUpDown1.Value > 1)
            {
                CheckBox1.Enabled = true;
            }
            else
            {
                CheckBox1.Checked = false;
                CheckBox1.Enabled = false;
            }
            this.document.PrinterSettings.Copies = Convert.ToInt16(NumericUpDown1.Value);
        }

        private void RadioButtonsPageSelection_CheckedChanged(object sender, EventArgs e)
        {
            Label2.Enabled = RadioButton2.Checked;
            NumericUpDown2.Enabled = RadioButton2.Checked;
            Label3.Enabled = RadioButton2.Checked;
            NumericUpDown3.Enabled = RadioButton2.Checked;
            if (RadioButton1.Checked)
            {
                this.document.PrinterSettings.FromPage = 1;
                this.document.PrinterSettings.ToPage = Convert.ToInt32(NumericUpDown3.Maximum);
            }
            else
            {
                this.document.PrinterSettings.FromPage = Convert.ToInt32(NumericUpDown2.Value);
                this.document.PrinterSettings.ToPage = Convert.ToInt32(NumericUpDown3.Value);
            }
        }

        private void RadioButtonsOrientation_CheckedChanged(object sender, EventArgs e)
        {
            this.document.DefaultPageSettings.Landscape = RadioButton4.Checked;
            NumericUpDown3.Maximum = RadioButton4.Checked ? maxLandscapePages : maxPortraitPages;
            NumericUpDown3.Value = RadioButton1.Checked ? Convert.ToInt32(NumericUpDown3.Maximum) : NumericUpDown3.Value;
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.document.PrinterSettings.FromPage = Convert.ToInt32(NumericUpDown2.Value);
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown2.Maximum = NumericUpDown3.Value;
            this.document.PrinterSettings.ToPage = Convert.ToInt32(NumericUpDown3.Value);
        }

        private void NumericUpDowns_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            int value = 0;
            if (int.TryParse(nud.Text, out value))
            {
                if (!Enumerable.Range(1, Convert.ToInt32(nud.Maximum)).Contains(value))
                {
                    ep.SetError(nud, string.Format("Valid Range: {0} to {1}", ((int)(nud.Minimum)), ((int)(nud.Maximum))));
                }
                else
                {
                    ep.Clear();
                }
            }
        }

        private void NumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            this.document.DefaultPageSettings.Margins.Left = Convert.ToInt32(NumericUpDown4.Value);
        }

        private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            this.document.DefaultPageSettings.Margins.Right = Convert.ToInt32(NumericUpDown5.Value);
        }

        private void NumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            this.document.DefaultPageSettings.Margins.Top = Convert.ToInt32(NumericUpDown6.Value);
        }

        private void NumericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            this.document.DefaultPageSettings.Margins.Bottom = Convert.ToInt32(NumericUpDown7.Value);
        }

    }

}

