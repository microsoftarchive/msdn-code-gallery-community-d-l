using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EntityFrameWorkNorthWind_cs;

namespace Example1_cs
{
    public partial class EditorForm : Form
    {
        public Customer Customer { get; set; }
        public bool Adding { get; set; }
        public EditorForm()
        {
            InitializeComponent();
        }
        public EditorForm(Customer customer, List<string> contactTitles)
        {
            InitializeComponent();

            this.Customer = customer;
            cboTitles.DataSource = contactTitles;
            cboCountry.DataSource = Countries.Names;

            if (customer == null)
            {
                Adding = true;
            }
            else
            {

                Adding = false;

                txtCompanyName.Text = Customer.CompanyName;
                txtContactName.Text = Customer.ContactName;
                int index = cboTitles.FindString(Customer.ContactTitle);
                if (index != -1)
                {
                    cboTitles.SelectedIndex = index;
                }

                index = cboCountry.FindStringExact(Customer.Country);
                if (index != -1)
                {
                    cboCountry.SelectedIndex = index;
                }
            }
        }
        /// <summary>
        /// Validation is done in the main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// * No reason not to place validation here, I left that for you :-)
        /// * I avoided checking if the text properties of the TextBoxes 
        ///   are empty as we are focused on EF validation not form control 
        ///   validation
        /// </remarks>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            Customer.CompanyName = txtCompanyName.Text;
            Customer.ContactName = txtContactName.Text;
            Customer.ContactTitle = cboTitles.Text;
            Customer.Country = cboCountry.Text;
        }
    }
}
