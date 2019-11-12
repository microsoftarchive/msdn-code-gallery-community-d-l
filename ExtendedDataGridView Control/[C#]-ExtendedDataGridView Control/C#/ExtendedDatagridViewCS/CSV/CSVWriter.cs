using System;
using System.Windows.Forms;
namespace ExtendedDataGridView
{

    public class CSVWriter
	{

		public void writeCSV(ExtendedDataGridViewControl mainTable, bool includeRowHeaders, bool includeColumnHeaders, bool includeHiddenColumns)
		{
			string output = "";

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.AddExtension = true;
			sfd.Filter = "CSV Files *.csv|*.CSV";
			sfd.FilterIndex = 1;
			if (sfd.ShowDialog() == DialogResult.OK) {
				mainTable.EndEdit();

				if (includeColumnHeaders) {
					if (includeRowHeaders) {
						output += ",";
					}
					for (int x = 0; x <= mainTable.ColumnCount - 1; x++) {
						if (!mainTable.Columns[x].Visible & !includeHiddenColumns) {
							continue;
						}
						if (x < mainTable.ColumnCount - 1) {
							output += mainTable.Columns[x].HeaderText + ",";
						} else {
							output += mainTable.Columns[x].HeaderText + Environment.NewLine;
						}
					}
				}

				for (int y = 0; y <= mainTable.RowCount - 1; y++) {
					if (y == mainTable.NewRowIndex)
						continue;
					for (int x = -1; x <= mainTable.ColumnCount - 1; x++) {
						if (x == -1) {
							if (includeRowHeaders) {
								object o = mainTable.Rows[y].HeaderCell.Value;
								if (o == null) {
									o = "";
								}
								output += o.ToString() + ",";
							}
							continue;
						}
						if (!mainTable.Columns[x].Visible & !includeHiddenColumns) {
							continue;
						}
						string cellValue = "";
						if (mainTable[x, y] is DataGridViewCheckBoxCell) {
							bool b = false;
							bool.TryParse(mainTable[x, y].FormattedValue.ToString(), out b);
							cellValue = b.ToString();
						} else if (mainTable[x, y] is DataGridViewImageCell) {
							cellValue = "Bitmap";
						} else {
							if (mainTable[x, y].Value != null) {
								cellValue = mainTable[x, y].Value.ToString();
							}
						}
						if (x < mainTable.ColumnCount - 1) {
							output += cellValue + ",";
						} else {
							output += cellValue + Environment.NewLine;
						}
					}
				}
				System.IO.File.WriteAllText(sfd.FileName, output);
			}

		}

	}
}
