using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TeamBaseLibrary
{
    public static class BindingSourceExtensions
    {
        public static DataTable DataTable(this BindingSource pBindingSource)
        {
            return (DataTable)pBindingSource.DataSource;
        }
        public static DataRow CurrentRow(this BindingSource pBindingSource)
        {
            return ((DataRowView)pBindingSource.Current).Row;
        }
    }
}


