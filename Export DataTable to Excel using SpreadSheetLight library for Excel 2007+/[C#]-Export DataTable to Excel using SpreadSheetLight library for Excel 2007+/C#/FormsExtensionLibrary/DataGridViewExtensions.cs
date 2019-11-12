using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsExtensionLibrary
{
    public static class DataGridViewExtensions
    {
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        public static DataTable DataTable(this DataGridView sender)
        {
            return (DataTable)sender.DataSource;
        }
    }
}
