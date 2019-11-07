using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;
/// <summary>
/// Author      : SHANU
/// Create date : 2014-11-24
/// Description : BizBase
/// Latest
/// Modifier    : SHANU
/// Modify date : 2014-11-24
/// </summary>

namespace shanuDatagridViewCellpainting.Helper
{
	class BizBase
	{
		#region Variables

		private  string  connString = "server=YourDBServer; database=projectDB; user id=UID; password=PWD;";

		#endregion

		#region Properties

		protected string ConnectionString
		{
			get { return  ReadConnectionString();  }
		}
		public String ReadConnectionString()
		{
			string path = Application.StartupPath + @"\DBConnection.txt";
			
			if (!File.Exists(path))
			{
				using (StreamWriter tw = File.CreateText(path))
				{
					tw.WriteLine("server=YourDBServer; database=projectDB; user id=UID; password=PWD;");
					tw.Close();
					connString = "server=YourDBServer; database=projectDB; user id=UID; password=PWD;";
				}

			}
			else
			{
				TextReader tr = new StreamReader(path);
				connString = tr.ReadLine();
				tr.Close();
			}
			return connString;

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

		public static void AddParameter(ref SqlParameter[] paramArray, string parameterName, SqlDbType dbType, int size, object parameterValue)
		{
			SqlParameter parameter = new SqlParameter(parameterName, dbType, size);
			parameter.Value = parameterValue;

			AddParameter(ref paramArray, parameter);
		}

		public static void AddParameter(ref SqlParameter[] paramArray, string parameterName, SqlDbType dbType, int size, ParameterDirection direction, object parameterValue)
		{
			SqlParameter parameter = new SqlParameter(parameterName, dbType, size);
			parameter.Value = parameterValue;
			parameter.Direction = direction;

			AddParameter(ref paramArray, parameter);
		}

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