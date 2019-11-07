using System.Windows.Forms;
using System.ComponentModel;
namespace ExtendedDataGridView
{

    public class altDataGridViewCheckBoxColumn : DataGridViewCheckBoxColumn
	{

		private enumerations.style2 _HeaderStyle;
		[Category("Design"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public enumerations.style2 HeaderStyle {
			get { return _HeaderStyle; }
			set {
				_HeaderStyle = value;
				switch (_HeaderStyle) {
					case enumerations.style2.Standard:
						base.HeaderCell = new DataGridViewColumnHeaderCell();
						break;
					case enumerations.style2.CheckAll:
						base.HeaderCell = new checkAllHeaderCell();
						break;
					case enumerations.style2.HideColumn:
						base.HeaderCell = new checkHideColumnHeaderCell();
						break;
				}
			}
		}

		public override object Clone()
		{
			altDataGridViewCheckBoxColumn copyColumn = (altDataGridViewCheckBoxColumn)base.Clone();
			copyColumn._HeaderStyle = this.HeaderStyle;
			return copyColumn;
		}

	}
}
