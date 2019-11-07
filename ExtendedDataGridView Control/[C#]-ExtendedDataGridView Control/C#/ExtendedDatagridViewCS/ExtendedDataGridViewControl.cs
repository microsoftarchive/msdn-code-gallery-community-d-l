using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace ExtendedDataGridView
{

    public class ExtendedDataGridViewControl : DataGridView
	{

		public event cellSelectedIndexChangedEventHandler cellSelectedIndexChanged;
		public delegate void cellSelectedIndexChangedEventHandler(System.Object sender, ComboIndexChangedEventArgs e);
		public event cellCheckedChangedEventHandler cellCheckedChanged;
		public delegate void cellCheckedChangedEventHandler(System.Object sender, CheckBoxChangedEventArgs e);

		private ContextMenuStrip cms = new ContextMenuStrip(); 
		Printer printer = new Printer();
		CSVWriter writer = new CSVWriter();

		public ExtendedDataGridViewControl()
		{
			DataError += ExtendedDataGridView_DataError;
			this.DoubleBuffered = true;
			cms.Items.Add("&Print", null, Print1);
			cms.Items.Add("Print pre&view", null, PreviewPrint1);
			cms.Items.Add("-");
			cms.Items.Add("&Save as CSV", null, SaveasCSV1);
			cms.Items.Add("-");
			cms.Items.Add("&Reveal");
			this.ContextMenuStrip = cms;
			this.CellPainting += Me_CellPainting;
            cms.Opening += cms_Opening;
            cms.Closed += cms_Closed;
        }

		private void Me_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex == -1 | e.ColumnIndex == -1) {
				e.Handled = true;
				e.PaintBackground(e.ClipBounds, true);
				e.Graphics.FillRectangle(new SolidBrush(base.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds);
				Rectangle r = e.CellBounds;
				if (e.RowIndex == -1) {
					r.X -= 1;
				} else {
					r.Width -= 1;
				}
				r.Height -= 1;
				e.Graphics.DrawRectangle(Pens.DarkGray, r);
				e.PaintContent(e.ClipBounds);
			}
		}

		private void Print1(object sender, EventArgs e)
		{
            Print();
		}

		private void PreviewPrint1(object sender, EventArgs e)
		{
			PreviewPrint();
		}

		private void SaveasCSV1(object sender, EventArgs e)
		{
			SaveasCSV();
		}

		public void Print()
		{
			frmOptions frm = new frmOptions(true);
			if (frm.ShowDialog() == DialogResult.OK) {
				printer.startPrint(this, frm.rows, frm.columns, frm.hidden, false);
			}
		}

		public void PreviewPrint()
		{
			frmOptions frm = new frmOptions(true);
			if (frm.ShowDialog() == DialogResult.OK) {
				printer.startPrint(this, frm.rows, frm.columns, frm.hidden, true);
			}
		}

		public void SaveasCSV()
		{
			frmOptions frm = new frmOptions(false);
			if (frm.ShowDialog() == DialogResult.OK) {
				writer.writeCSV(this, frm.rows, frm.columns, frm.hidden);
			}
		}

		public override DataGridViewAdvancedBorderStyle AdjustColumnHeaderBorderStyle(DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceHolder, bool firstDisplayedColumn, bool lastVisibleColumn)
		{

			// Customize the left border of the first column header and the
			// bottom border of all the column headers. Use the input style for 
			// all other borders.
			if (firstDisplayedColumn) {
				dataGridViewAdvancedBorderStylePlaceHolder.Left = DataGridViewAdvancedCellBorderStyle.OutsetDouble;
			} else {
				dataGridViewAdvancedBorderStylePlaceHolder.Left = DataGridViewAdvancedCellBorderStyle.None;
			}

			var _with1 = dataGridViewAdvancedBorderStylePlaceHolder;
			_with1.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
			_with1.Right = dataGridViewAdvancedBorderStyleInput.Right;
			_with1.Top = dataGridViewAdvancedBorderStyleInput.Top;

			return dataGridViewAdvancedBorderStylePlaceHolder;
		}

		protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
		{
			if (this[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell) {
				e.CellStyle.NullValue = ExtendedDataGridViewCS.Properties.Resources.errorimage;
			}
			base.OnCellFormatting(e);
		}

		private void cms_Opening(object sender, CancelEventArgs e)
		{
			bool b = this.Columns.Cast<DataGridViewColumn>().Where(c => (!c.Visible & c.HeaderCell is checkHideColumnHeaderCell)).Count() > 0;
			((ToolStripMenuItem)cms.Items[5]).DropDownItems.Add(new ToolStripControlHost(new showColumns(this, cms)));
			cms.Items[5].Enabled = b;
		}

		private void cms_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			((ToolStripMenuItem)cms.Items[5]).DropDownItems.Clear();
		}

		private void ExtendedDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			return;
		}

		protected override void OnEditingControlShowing(System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
		{
			// Attempt to cast the EditingControl to a ComboBox.
			//this will only work if CurrentCell is a combobox column
			ComboBox cb = e.Control as ComboBox;
			//if it is a combobox column...
			if (cb != null) {
				cb.SelectedIndexChanged -= DGVComboIndexChanged;
				cb.SelectedIndexChanged += DGVComboIndexChanged;
			}
			base.OnEditingControlShowing(e);
		}

		private void DGVComboIndexChanged(System.Object sender, System.EventArgs e)
		{
			//this handles the datagridviewcombobox cell selectedindexchanged event
			ComboBox cb = (ComboBox)sender;
			if (cellSelectedIndexChanged != null) {
				cellSelectedIndexChanged(sender, new ComboIndexChangedEventArgs {
					columnIndex = base.CurrentCell.ColumnIndex,
					rowIndex = base.CurrentCell.RowIndex,
					selectedIndex = cb.SelectedIndex,
					selectedItem = cb.SelectedItem,
					selectedValue = cb.SelectedValue,
					text = cb.Text
				});
			}
		}

		protected override void OnCurrentCellDirtyStateChanged(System.EventArgs e)
		{
			if (base.CurrentCell is DataGridViewCheckBoxCell) {
				base.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
			base.OnCurrentCellDirtyStateChanged(e);
		}

		protected override void OnCellValueChanged(System.Windows.Forms.DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == -1 || e.RowIndex == -1)
				return;
			if (base.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell) {
				if (cellCheckedChanged != null) {
					cellCheckedChanged(this, new CheckBoxChangedEventArgs {
						columnIndex = e.ColumnIndex,
						rowIndex = e.RowIndex,
						newValue = base.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? false : Convert.ToBoolean(base.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
					});
				}
			}
			base.OnCellValueChanged(e);
		}

		protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
		{
			if (this.Columns[e.ColumnIndex].HeaderCell is checkHideColumnHeaderCell) {
				var l = new Point(this.Columns[e.ColumnIndex].Width - 18, 5);
				Size s = new Size(12, 12);
				if (new Rectangle(l, s).Contains(e.Location)) {
					return;
				}
			}
			base.OnColumnHeaderMouseClick(e);
		}

	}
}
