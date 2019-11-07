using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;


namespace DuplicateForDataTable_CS
{
    public static class ForDataTable
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> sender)
        {
            DataTable dt = new DataTable();

            // column names
            PropertyInfo[] FirstRecord = null;

            if (sender == null) return dt;

            foreach (T rec in sender)
            {
                if (FirstRecord == null)
                {
                    FirstRecord = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in FirstRecord)
                    {
                        Type columnType = pi.PropertyType;

                        if ((columnType.IsGenericType) && (columnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            columnType = columnType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(pi.Name, columnType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pi in FirstRecord)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

    }
}
