using System;
using System.Windows.Forms;
namespace ExtendedDataGridView
{

    public partial class frmOptions
	{

		public bool columns {
			get { return CheckBox1.Checked; }
		}

		public bool rows {
			get { return CheckBox2.Checked; }
		}

		public bool hidden {
			get { return CheckBox3.Checked; }
		}


		public frmOptions(bool print)
		{
			// This call is required by the designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent() call.

			if (print) {
				this.Text = "Print Options";
				CheckBox1.Text = "&Print Column Headers";
				CheckBox2.Text = "Print &Row Headers";
				CheckBox3.Text = "Print &Hidden Columns";
				Button1.Text = "Pr&int";
			}

		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}
