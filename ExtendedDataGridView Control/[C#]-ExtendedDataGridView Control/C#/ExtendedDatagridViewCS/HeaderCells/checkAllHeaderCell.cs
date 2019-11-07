using System.Drawing;
using System.Windows.Forms;
namespace ExtendedDataGridView
{

    public class checkAllHeaderCell : DataGridViewColumnHeaderCell
	{

		Point l;

		Size s = new Size(12, 12);
		ToolTip tt = new ToolTip();

		Point lastPoint = Point.Empty;

		public checkAllHeaderCell()
		{
		}

		private bool _isChecked;
		public bool isChecked {
			get { return _isChecked; }
			set {
				_isChecked = value;
				this.DataGridView.EndEdit();
				for (int x = 0; x <= this.DataGridView.Rows.Count - 1; x++) {
					if (this.DataGridView.Rows[x].IsNewRow)
						continue;
					this.DataGridView.Rows[x].Cells[this.OwningColumn.Index].Value = value;
				}
			}
		}

		protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, System.Windows.Forms.DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, System.Windows.Forms.DataGridViewCellStyle cellStyle, System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle,
		System.Windows.Forms.DataGridViewPaintParts paintParts)
		{
			string spaces = new string(' ', 2);
			l = new Point(cellBounds.Width - 18, 5);
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, spaces + value.ToString().Trim(), spaces + formattedValue.ToString().Trim(), errorText, cellStyle, advancedBorderStyle,
			paintParts);
			CheckBoxRenderer.DrawCheckBox(graphics, new Point(cellBounds.X + l.X, l.Y), isChecked ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
		}

		protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
		{
			if (new Rectangle(l, s).Contains(e.Location) & !(e.Location == lastPoint)) {
				lastPoint = e.Location;
				this.OwningColumn.DataGridView.ShowCellToolTips = false;
				tt.SetToolTip(this.OwningColumn.DataGridView, "Check/uncheck all cells");
			} else {
				lastPoint = Point.Empty;
				tt.Hide(this.OwningColumn.DataGridView);
				tt.SetToolTip(this.OwningColumn.DataGridView, "");
				this.OwningColumn.DataGridView.ShowCellToolTips = true;
			}
			base.OnMouseMove(e);
		}

		protected override void OnMouseClick(System.Windows.Forms.DataGridViewCellMouseEventArgs e)
		{
			if (new Rectangle(l, s).Contains(e.Location)) {
				isChecked = !isChecked;
			}
			base.OnMouseClick(e);
		}

	}
}
