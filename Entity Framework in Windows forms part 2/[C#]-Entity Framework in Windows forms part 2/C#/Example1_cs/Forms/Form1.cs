using CustomBindingList_cs;
using EntityFrameWorkNorthWind_cs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static DialogLibrary.KarenDialogs;

namespace Example1_cs
{
    public partial class Form1 : Form
    {
        private SortableBindingList<Customer> blCustomers = new SortableBindingList<Customer>();
        private BindingSource bsCustomers = new BindingSource();
        private Customer currentCustomer;
        private List<string> ContactTitles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set up to allow filtering by company name
            cboFilterOptionsForString.DataSource = typeof(FilterOptions).Names().ToList();

            // Read our data
            Customers customers = new Customers(true);
            ContactTitles = customers.ContactList;

            // Setup for sorting
            blCustomers = new SortableBindingList<Customer>(customers.DataSource);

            // Bind to the BindingList
            bsCustomers.DataSource = blCustomers;

            // Set DataGridView DataSource
            dataGridView1.DataSource = bsCustomers;

            SetupDataBindingsForLabels();
            PrepDataGridViewColumns();
            SetupEventsForSorting();

            bsCustomers.Position = 1;

        }

        /// <summary>
        /// Remove filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Things get a tad complicated here in regards to keeping the current row
        /// as we need to make sure the row still exists
        /// </remarks>
        private void cmdRemoveFilter_Click(object sender, EventArgs e)
        {
            Customer tempCustomer = null;

            if (bsCustomers.CurrentRowIsValid())
            {
                tempCustomer = bsCustomers.Customer();
            }

            Customers customers = new Customers();
            blCustomers = new SortableBindingList<Customer>(customers.DataSource);

            bsCustomers.DataSource = blCustomers;
            dataGridView1.DataSource = bsCustomers;

            if (tempCustomer.IsValid())
            {
                currentCustomer = blCustomers.Where(cust => cust.CustomerIdentifier == tempCustomer.CustomerIdentifier).FirstOrDefault();
                if (currentCustomer.IsValid())
                {
                    bsCustomers.Position = blCustomers.IndexOf(currentCustomer);
                }
            }
        }
        private void ResetCurrentCustomer()
        {
            if (bsCustomers.CurrentRowIsValid())
            {
                currentCustomer = bsCustomers.Customer();
                bsCustomers.Position = blCustomers.IndexOf(currentCustomer);
            }
            else
            {
                currentCustomer = null;
            }
        }

        /// <summary>
        /// Apply filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFilterByColumn_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();

            // try and filter if we have text else remove filter
            if (!string.IsNullOrWhiteSpace(txtCompanyNameFilter.Text))
            {
                customers.CompanyNameFilter(txtCompanyNameFilter.Text, cboFilterOptionsForString.Text.ToEnum<FilterOptions>());
                blCustomers = new SortableBindingList<Customer>(customers.DataSource);
            }
            else
            {
                blCustomers = new SortableBindingList<Customer>(customers.DataSource);
            }

            bsCustomers.DataSource = blCustomers;
            dataGridView1.DataSource = bsCustomers;
            if (bsCustomers.Count == 0)
            {
                MessageBox.Show("No matches for search string entered");
            }
            else
            {
                ResetCurrentCustomer();
            }
        }

        #region Keep position when sorting logic

        /// <summary>
        /// Use the form level variable currentCustomer set in the
        /// BindingSource PositionChanged event to keep the item current
        /// when sorting via the DataGridView column headers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            if (bsCustomers.CurrentRowIsValid())
            {
                bsCustomers.Position = blCustomers.IndexOf(currentCustomer);
            }
        }

        /// <summary>
        /// Get the current customer displayed in the DataGridView and
        /// assign it to a private variable for use in the Sorted event of
        /// the DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bsCustomers_PositionChanged(object sender, EventArgs e)
        {
            if (bsCustomers.CurrentRowIsValid())
            {
                currentCustomer = ((Customer)bsCustomers.Current);
            }
            else
            {
                currentCustomer = null;
            }
        }

        #endregion Keep position when sorting logic

        #region Setup

        /// <summary>
        /// Data bind two fields to labels
        /// </summary>
        private void SetupDataBindingsForLabels()
        {
            lblCustomerIdentifier.DataBindings.Add("text", bsCustomers, "CustomerIdentifier");
            lblCompanyName.DataBindings.Add("text", bsCustomers, "CompanyName");
        }

        /// <summary>
        /// Here we are preparing for keeping the current Customer as the current row
        /// in our DataGridView
        /// </summary>
        private void SetupEventsForSorting()
        {
            bsCustomers.PositionChanged += bsCustomers_PositionChanged;
            dataGridView1.Sorted += dataGridView1_Sorted;
        }

        /// <summary>
        /// This code hide several columns from being shown in the DataGridView.
        /// Note that Orders can not be displayed and also when setting the column
        /// widths using Extensions.ExpandColumns there is logic that ensures the
        /// Orders DataGridViewColumn does not attempt to set the width.
        /// </summary>
        private void PrepDataGridViewColumns()
        {
            // First four we simply don't want to see, last column EF can not handle this in the dataGridView (see below)
            List<string> hideColumns = new List<string>() { "CustomerIdentifier", "Region", "Phone", "Fax", "Orders" };

            foreach (string colName in hideColumns)
            {
                if (dataGridView1.Columns.Contains(colName))
                {
                    dataGridView1.Columns[colName].Visible = false;
                }
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Visible)
                {
                    if (col.HeaderText != "PostalCode")
                    {
                        col.HeaderText = Regex.Replace(col.HeaderText, "(\\B[A-Z])", " $1");
                    }
                }

            }
            // see comments in extension method!!!
            dataGridView1.ExpandColumns();
        }

        #endregion Setup
        /// <summary>
        /// One method to edit the current customer in the DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// * 
        /// * Another method is to data bind customer properties to controls on the edit form.
        /// </remarks>
        private void cmdEditCurrent_Click(object sender, EventArgs e)
        {
            EditorForm f = new EditorForm(bsCustomers.Customer(), ContactTitles);

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Customer customer = blCustomers.FirstOrDefault(cust => cust.CustomerIdentifier == bsCustomers.CustomerIdentifier());
                    Customers customers = new Customers();
                    if (customers.UpdateCustomer(customer))
                    {
                        bsCustomers.ResetCurrentItem();
                    }
                    else
                    {
                        MessageBox.Show(customers.ValidationMessage);
                    }
                }
            }
            finally
            {
                f.Dispose();
            }
        }
        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }
        private void cmdRemoveCurrent_Click(object sender, EventArgs e)
        {
            if (Question($"Remove '{bsCustomers.CompanyName()}' ?"))
            {
                InformationDialog("Not available");
            }           
        }
    }
}