using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jQuery_Datatable_With_Server_Side_Data.Models
{
    public class Sales
    {
        public object GetSales(TrialsDBEntities tdb)
        {
            try
            {
                var myList = ((from l in tdb.SalesOrderDetails
                           select new 
                           {
                               SalesOrderID = l.SalesOrderID,
                               SalesOrderDetailID = l.SalesOrderDetailID,
                               CarrierTrackingNumber = l.CarrierTrackingNumber,
                               OrderQty = l.OrderQty,
                               ProductID = l.ProductID,
                               UnitPrice = l.UnitPrice
                           }).OrderBy(l => l.SalesOrderID)).Take(100).ToList();
                return myList;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            
        }
        public List<SalesOrderDetail> GetSalesSP(TrialsDBEntities tdb)
        {
            try
            {                
                var myList = tdb.Database.SqlQuery<SalesOrderDetail>("EXEC usp_Get_SalesOrderDetail").ToList();
                return myList;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }
    }
}