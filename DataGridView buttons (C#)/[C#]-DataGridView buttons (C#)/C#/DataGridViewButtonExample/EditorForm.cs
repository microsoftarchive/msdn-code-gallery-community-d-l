using SqlDataOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewButtonExample
{
    /// <summary>
    /// There are several different ways to handle pushing and popping
    /// data to this form, this is simply one of them that is easy 
    /// to follow.
    /// 
    /// There is no validation e.g. is a field empty or perhaps
    /// in your app there may be constraints e.g. no duplicates so
    /// that would be out of scope of this code sample which focuses
    /// on the DataGridViewButton.
    /// </summary>
    public partial class EditorForm : Form
    {
        private DataRow mRow;
        public DataRow Row { get { return mRow; } }
        public EditorForm()
        {
            InitializeComponent();
        }
        public EditorForm(DataRow pRow, List<ContactType> contactList)
        {
            InitializeComponent();

            mRow = pRow;

            cboContactTitle.DataSource = contactList;
            cboContactTitle.SelectedIndex = cboContactTitle.FindString(mRow.Field<string>("ContactTitle"));

            txtCompanyName.Text = Row.Field<string>("CompanyName");
            txtContactName.Text = Row.Field<string>("ContactName");
            txtCity.Text = Row.Field<string>("City");
            txtCountry.Text = Row.Field<string>("Country");

        }
        /// <summary>
        /// No validation done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            mRow.SetField<string>("CompanyName", txtCompanyName.Text);
            mRow.SetField<string>("ContactName", txtContactName.Text);
            mRow.SetField<string>("ContactTitle", cboContactTitle.Text);
            mRow.SetField<int>("ContactTypeIdentifier", ((ContactType)cboContactTitle.SelectedItem).ContactTypeIdentifier);
            mRow.SetField<string>("City", txtCity.Text);
            mRow.SetField<string>("Country", txtCountry.Text);
        }
    }
}
