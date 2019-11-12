using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EntityFrameWorkNorthWind_cs;

namespace Example1_cs
{
    /// <summary>
    ///  In regards to validation
    ///  * Max characters for a field, all but CompanyName are done by setting max length of
    ///    the TextBoxes to the max length set at the database level and set in the model. For
    ///    CompanyName I set an annotation in CustomerMetadata [StringLength(40,ErrorMessage = "Must be 40 characters or less")]
    ///    
    ///    There are advantages and disadvantages to each one. For instance refreshing the model were max length
    ///    of a field changes we need to manaully updata CustomerMetadata while the holds true for TextBox max length
    ///    while the other option is to rely on ValidationContext as partly done in Customer class in CustomerPartial.cs
    ///    
    /// </summary>
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
            
            Customer = customer;
            cboTitles.DataSource = contactTitles;
            cboCountry.DataSource = Countries.Names;

            if (string.IsNullOrWhiteSpace( customer.CompanyName))
            {
                cboTitles.SelectedIndex = -1;
                cboCountry.SelectedIndex = -1;
                Adding = true;
                this.Text = "Adding";
            }
            else
            {

                Adding = false;

                this.Text = "Editing";

                txtCompanyName.Text = Customer.CompanyName;
                txtContactName.Text = Customer.ContactName;
                txtAddress.Text = Customer.Address;
                txtCity.Text = Customer.City;
                txtPostalCode.Text = Customer.PostalCode;

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
            Customers customers = new Customers();

            if (Adding)
            {
                Customer.CompanyName = txtCompanyName.Text;
                Customer.ContactName = txtContactName.Text;
                Customer.ContactTitle = cboTitles.Text;
                Customer.Address = txtAddress.Text;
                Customer.Country = cboCountry.Text;
                Customer.City = txtCity.Text;
                Customer.PostalCode = txtPostalCode.Text;

                if (!customers.AddNew(Customer))
                {                    
                    MessageBox.Show(customers.ValidationMessage);
                    return;
                }
                else
                {
                    /*
                     * We will access the new customer back in the calling form so we
                     * need the new key.
                     */
                    Customer.CustomerIdentifier = customers.NewIdentifier;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                Customer.CompanyName = txtCompanyName.Text;
                Customer.ContactName = txtContactName.Text;
                Customer.ContactTitle = cboTitles.Text;
                Customer.Address = txtAddress.Text;
                Customer.Country = cboCountry.Text;
                Customer.City = txtCity.Text;
                Customer.PostalCode = txtPostalCode.Text;

                if (!customers.UpdateCustomer(Customer))
                {
                    MessageBox.Show(customers.ValidationMessage);
                    return;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
