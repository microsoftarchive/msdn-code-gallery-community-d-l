using DataOperations_VB;
using System.Data;
using System.Linq;

namespace DuplicateForDataTable_CS
{
    /// <summary>
    /// Sample how to get duplicate records/datarows in a DataTable
    /// via more than one column and include the primary key so we
    /// can have options to a) shows data to users b) allow user
    /// to delete records as we need a key to do this.
    /// </summary>
    public class DataTableDuplicateFinder
    {
        public DataTable GetDuplicates()
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.AllCustomersDataDataTable;

            DataTable dtNew = dt.Clone();
            dtNew.Columns["Identifier"].AutoIncrement = false;

            var duplicates = from row in dt.AsEnumerable()
                             select
                             new
                             {
                                 Identifier = row[0],
                                 CompanyName = row[1],
                                 ContactName = row[2],
                                 ContactTitle = row[3],
                                 Address = row[4],
                                 City = row[5],
                                 PostalCode = row[6]
                             }
                                 into temp
                                 group temp by
                                 new
                                 {
                                     CompanyName = temp.CompanyName,
                                     ContactName = temp.ContactName,
                                     ContactTitle = temp.ContactTitle
                                 }
                                     into grouped
                                     where grouped.Count() > 1
                                     select grouped.Select(g =>
                                     new
                                     {
                                         g.Identifier,
                                         g.CompanyName,
                                         g.ContactName,
                                         g.ContactTitle,
                                         g.Address,
                                         g.City,
                                         g.PostalCode
                                     }
                                 );

            foreach (var Item in duplicates)
            {
                foreach (var row in Item)
                {
                    dtNew.Rows.Add(new object[]
                        {
                            (int)row.Identifier,
                            row.CompanyName,
                            row.ContactName,
                            row.ContactTitle,
                            row.Address,
                            row.City,
                            row.PostalCode
                        }
                    );
                }
            }

            return dtNew;
        }
    }
}