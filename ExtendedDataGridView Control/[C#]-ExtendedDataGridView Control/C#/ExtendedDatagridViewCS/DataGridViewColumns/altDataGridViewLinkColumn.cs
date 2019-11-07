using System.Windows.Forms;
using System.ComponentModel;
namespace ExtendedDataGridView
{

    public class altDataGridViewLinkColumn : DataGridViewLinkColumn
	{

		private enumerations.style1 _HeaderStyle;
		[Category("Design"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public enumerations.style1 HeaderStyle {
			get { return _HeaderStyle; }
			set {
				_HeaderStyle = value;
				switch (_HeaderStyle) {
					case enumerations.style1.Standard:
						base.HeaderCell = new DataGridViewColumnHeaderCell();
						break;
					case enumerations.style1.HideColumn:
						base.HeaderCell = new checkHideColumnHeaderCell();
						break;
				}
			}
		}

		public override object Clone()
		{
			altDataGridViewLinkColumn copyColumn = (altDataGridViewLinkColumn)base.Clone();
			copyColumn._HeaderStyle = this.HeaderStyle;
			return copyColumn;
		}

	}
}
