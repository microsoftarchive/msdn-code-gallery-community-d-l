using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Example
{
    public static class LanguageExtensions
    {
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                col.HeaderText = string.Join(" ", System.Text.RegularExpressions.Regex.Split(col.HeaderText, "(?=[A-Z])"));
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> sender)
        {

            DataTable dt = new DataTable();
            var FieldNameRow = sender.First();

            foreach (var pi in FieldNameRow.GetType().GetProperties())
            {
                dt.Columns.Add(pi.Name, pi.GetValue(FieldNameRow, null).GetType());
            }

            foreach (var result in sender)
            {
                var nr = dt.NewRow();
                foreach (var pi in result.GetType().GetProperties())
                {
                    nr[pi.Name] = pi.GetValue(result, null);
                }
                dt.Rows.Add(nr);
            }

            return dt;

        }
    }
}
