using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CommonLayer;
using DBAccess;
using System.Data;

namespace BusinessLogic
{
   public class businessProductDetails
    {
        #region "Variable Declaration"

        DataSet _ds_AllDetails = null;
        string _get_query = string.Empty;

        #endregion       
        
        #region "Object Initialization"

        commonfunction _CmnFuncObj = new commonfunction();
        DALProductDetails _DataAccessOBj = new DALProductDetails();
        int rowCount = 0;

        #endregion

        #region "Get Grid Bind Details"
        public DataSet GetBindDetails()
        {

            _ds_AllDetails = new DataSet();
            _get_query = _DataAccessOBj.GetDetais();
            _ds_AllDetails = _CmnFuncObj.GetDataSet(_get_query);
            return _ds_AllDetails;

        }

        #endregion

        #region "Add Details"
        public int AddDetails(string ProdId,string ProdName,string  ProdPrice)
        {
            try
            {
                _get_query = _DataAccessOBj.AddDetails(ProdId, ProdName, ProdPrice);
                rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                return rowCount;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region "Update Details"
        public int UpdateDetails(string ProdPk_id,string ProdId, string ProdName, string ProdPrice)
        {
            try
            {
                _get_query = _DataAccessOBj.UpdateDetails(ProdPk_id,ProdId, ProdName, ProdPrice);
                rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                return rowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region "Delete Details"
        public int DeleteDetails(string ProdPk_id)
        {
            try
            {
                _get_query = _DataAccessOBj.DeleteDetails(ProdPk_id);
                rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                return rowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
    
}
