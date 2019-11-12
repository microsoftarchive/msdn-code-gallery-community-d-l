using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.IO;
using System.Windows.Forms;
/// <summary>
/// Author      : Shanu
/// Create date : 2015-12-01
/// Description : Biz Class
/// Latest
/// Modifier    : 
/// Modify date : 
/// </summary>

namespace DatagridViewCRUD.Helper
{
	
	class BizClass
	{
		DatagridViewCRUD.Helper.SQLDALClass objDAL = new DatagridViewCRUD.Helper.SQLDALClass();

		//All Business Method here
		#region ALL Business method here
		public DataSet SelectList(String SP_NAME, SortedDictionary<string, string> sd)
		{
			try
			{
				return objDAL.SP_Dataset_return(SP_NAME, GetSdParameter(sd));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Insert
		public DataSet SP_student_ImageInsert(String SP_NAME, string StudentName,
															   string Email,
															   string Phone,
															   string Address,															
															   byte[] IMAGEs)
		{
			try
			{
				return objDAL.SP_Student_ImageInsert(SP_NAME, StudentName,
																 Email,
																 Phone,
																 Address,
																 IMAGEs);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// EDIT
		public DataSet SP_student_ImageEdit(String SP_NAME, int std_ID,string StudentName,
															   string Email,
															   string Phone,
															   string Address,
															   byte[] IMAGEs)
		{
			try
			{
				return objDAL.SP_Student_ImageEdit(SP_NAME, std_ID,
																StudentName,
																 Email,
																 Phone,
																 Address,
																 IMAGEs);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion


		#region Methods Parameter

		/// <summary>
		/// This method Sorted-Dictionary key values to an array of SqlParameters
		/// </summary>
		public static SqlParameter[] GetSdParameter(SortedDictionary<string, string> sortedDictionary)
		{
			SqlParameter[] paramArray = new SqlParameter[] { };

			foreach (string key in sortedDictionary.Keys)
			{
				AddParameter(ref paramArray, new SqlParameter(key, sortedDictionary[key]));
			}

			return paramArray;
		}


		public static void AddParameter(ref SqlParameter[] paramArray, string parameterName, object parameterValue)
		{
			SqlParameter parameter = new SqlParameter(parameterName, parameterValue);

			AddParameter(ref paramArray, parameter);
		}


		public static void AddParameter(ref SqlParameter[] paramArray, string parameterName, object parameterValue, object parameterNull)
		{
			SqlParameter parameter = new SqlParameter();
			parameter.ParameterName = parameterName;

			if (parameterValue.ToString() == parameterNull.ToString())
				parameter.Value = DBNull.Value;
			else
				parameter.Value = parameterValue;

			AddParameter(ref paramArray, parameter);
		}

		public static void AddParameter(ref SqlParameter[] paramArray, string parameterName, SqlDbType dbType, object parameterValue)
		{
			SqlParameter parameter = new SqlParameter(parameterName, dbType);
			parameter.Value = parameterValue;

			AddParameter(ref paramArray, parameter);
		}

		public static void AddParameter(ref SqlParameter[] paramArray, string parameterName, SqlDbType dbType, ParameterDirection direction, object parameterValue)
		{
			SqlParameter parameter = new SqlParameter(parameterName, dbType);
			parameter.Value = parameterValue;
			parameter.Direction = direction;

			AddParameter(ref paramArray, parameter);
		}

		////public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, SqlDbType dbType, int size, object parameterValue)
		////{
		////    MySqlParameter parameter = new MySqlParameter(parameterName, dbType, size);
		////    parameter.Value = parameterValue;

		////    AddParameter(ref paramArray, parameter);
		////}

		////public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, SqlDbType dbType, int size, ParameterDirection direction, object parameterValue)
		////{
		////    MySqlParameter parameter = new MySqlParameter(parameterName, dbType, size);
		////    parameter.Value = parameterValue;
		////    parameter.Direction = direction;

		////    AddParameter(ref paramArray, parameter);
		////}

		public static void AddParameter(ref SqlParameter[] paramArray, params SqlParameter[] newParameters)
		{
			SqlParameter[] newArray = Array.CreateInstance(typeof(SqlParameter), paramArray.Length + newParameters.Length) as SqlParameter[];
			paramArray.CopyTo(newArray, 0);
			newParameters.CopyTo(newArray, paramArray.Length);

			paramArray = newArray;
		}

		#endregion
	}
}
