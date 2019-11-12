using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class extensions
    {
        public static bool NeedsItem(this Stack<object[][]> instance, DataGridView dgv)
        {
            if (instance.Count == 0)
            {
                return true;
            }
            object[][] rows = instance.Peek();
            return !ItemEquals(rows, dgv.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).ToArray());
        }

        public static bool ItemEquals(this object[][] instance, DataGridViewRow[] dgvRows)
        {
            if (instance.Count() != dgvRows.Count())
            {
                return false;
            }
            return !Enumerable.Range(0, instance.GetLength(0)).Any(x => !instance[x].SequenceEqual(dgvRows[x].Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray()));
        }

    }

}
