using System.Data;

namespace Demo1_C.Extensions
{
    public static class DataExtensions
    {
        public static T LastValue<T>(this DataTable dt, string ColumnName)
        {
            return dt.Rows[dt.Rows.Count - 1].Field<T>(dt.Columns[ColumnName]);
        }
    }
}