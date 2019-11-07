using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBAccess
{
  public  class DALProductDetails
  {
      #region "Variable Declaration"

      string str_SqlQuery = string.Empty;

      #endregion

      #region "Get Details"

      public string GetDetais()
      {
          try
          {
              str_SqlQuery = "select pk_id,ProductId,ProductName,ProductLocation,ProductQuantity,ProductPrice from Product";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Add Details"
      public string AddDetails(string ProdId,string ProdName,string ProdLoc,string ProdQty, string  ProdPrice)
      {
          try
          {
              str_SqlQuery = "insert into Product (ProductId,ProductName,ProductLocation,ProductQuantity,ProductPrice) values ('" + ProdId + "','" + ProdName + "','" + ProdLoc + "','" + ProdQty + "'," + ProdPrice + ") ";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Update Details"
      public string UpdateDetails(int  ProdPKID,string ProdId, string ProdName, string ProdLoc, string ProdQty, string ProdPrice)
      {
          try
          {
              str_SqlQuery = "update Product set  ProductId='" + ProdId + "', ProductName='" + ProdName + "',ProductLocation='" + ProdLoc + "',ProductQuantity='" + ProdQty + "',ProductPrice=" + ProdPrice + "  where pk_id='" + ProdPKID + "'  ";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Delete Details"
      public string DeleteDetails(int ProdPKID)
      {
          try
          {
              str_SqlQuery = "delete from  Product  where pk_id='" + ProdPKID + "'";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion
  }
}
