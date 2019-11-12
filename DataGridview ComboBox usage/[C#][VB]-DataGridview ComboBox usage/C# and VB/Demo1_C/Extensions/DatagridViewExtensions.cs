using System.Windows.Forms;

namespace Demo1_C
{
    public static class DatagridViewExtensions
    {
        public static bool IsComboBoxCell(this DataGridViewCell sender)
        {
            bool Result = false;
            if (sender.EditType != null)
            {
                if (sender.EditType == typeof(DataGridViewComboBoxEditingControl))
                {
                    Result = true;
                }
            }
            return Result;
        }

        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}