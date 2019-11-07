using System;
using System.Windows.Forms;

namespace CreateDynamicTextBoxes_CS
{
    public partial class customerEditor : Form
    {
        Customer customer;
        public readonly Customer Customer;
        public customerEditor()
        {
            InitializeComponent();           
        }
        public customerEditor(Customer sender)
        {
            InitializeComponent();
            customer = sender;
            Customer = customer;
        }
        /// <summary>
        /// Data bind to the passed in customer so upon closing this
        /// form we have updated data if the OK button was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void customerEditor_Load(object sender, EventArgs e)
        {
            Text = $"Identifier: {customer.CustomerIdentifier}";
            txtCompanyName.DataBindings.Add("Text", customer, "CompanyName");
            txtContactName.DataBindings.Add("Text", customer, "ContactName");
            txtContactTitle.DataBindings.Add("Text", customer, "ContactTitle");
        }
    }
}
