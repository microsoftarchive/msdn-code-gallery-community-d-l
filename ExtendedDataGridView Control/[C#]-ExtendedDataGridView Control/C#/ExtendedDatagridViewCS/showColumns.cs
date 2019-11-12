using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace ExtendedDataGridView
{

    public partial class showColumns
	{

		private DataGridView dgv;

		private ContextMenuStrip cms;

		public showColumns(DataGridView dgv, ContextMenuStrip cms)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent() call.

			this.dgv = dgv;
			this.cms = cms;

			for (int x = 0; x <= dgv.Columns.Count - 1; x++) {
				if (!dgv.Columns[x].Visible && dgv.Columns[x].HeaderCell is checkHideColumnHeaderCell) {
					ListBox1.Items.Add(dgv.Columns[x].HeaderText.Trim());
				}
			}

			Button1.Enabled = false;

		}

		private void Button1_Click(System.Object sender, System.EventArgs e)
		{
			for (int x = 0; x <= ListBox1.Items.Count - 1; x++) {
				if (ListBox1.GetSelected(x)) {
					int tempX = x;
					((checkHideColumnHeaderCell)dgv.Columns[Array.FindIndex(dgv.Columns.Cast<DataGridViewColumn>().ToArray(), c => c.HeaderText.Trim().Equals(ListBox1.GetItemText(ListBox1.Items[tempX])))].HeaderCell).isChecked = true;
				}
			}
			cms.Close();
		}

		private void ListBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			Button1.Enabled = ListBox1.SelectedItems.Count > 0;
		}

	}
}
