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
              str_SqlQuery = "select pk_id,ProductId,ProductName,ProductPrice from Product";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Add Details"
      public string AddDetails(string ProdId,string ProdName,string  ProdPrice)
      {
          try
          {
              str_SqlQuery = "insert into Product (ProductId,ProductName,ProductPrice) values ('" + ProdId + "','" + ProdName + "'," + ProdPrice + ") ";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Update Details"
      public string UpdateDetails(string ProdPk_id, string ProdId, string ProdName, string ProdPrice)
      {
          try
          {
              str_SqlQuery = "update Product set ProductId='" + ProdId + "',ProductName='" + ProdName + "',ProductPrice=" + ProdPrice + "  where  Pk_id='" + ProdPk_id + "' ";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Delete Details"
      public string DeleteDetails(string ProdPk_id)
      {
          try
          {
              str_SqlQuery = "delete from  Product  where Pk_id='" + ProdPk_id + "'";

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
