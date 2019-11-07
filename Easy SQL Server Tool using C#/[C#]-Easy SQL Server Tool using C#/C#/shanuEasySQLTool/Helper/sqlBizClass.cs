using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
/// <summary>
/// Author      : Shanu
/// Create date : 2016-01-01
/// Description :SMO Biz Class
/// Latest
/// Modifier    : Shanu
/// Modify date : 2016-01-01
/// </summary>
namespace shanuEasySQLTool.Helper
{
	class sqlBizClass
	{
		Helper.smoSQLServerClass objSQL = new Helper.smoSQLServerClass();

		#region SMO Server Connect
		//
		#region Database Details
		// to load database names
		public void loaddbNames(ComboBox cbo)
		{
			//return objSQL.loaddbNames();
			DatabaseCollection dbnamesCol = objSQL.loaddbNames();
			cbo.Items.Clear();
			cbo.Items.Add("");
			if (dbnamesCol != null)
			{
				string dbnames = "";
				int ival = 0;
                foreach (Database db in dbnamesCol)
				{
					if (ival < 6)
					{
						if (db.Name != "master")
						{
							cbo.Items.Add(db.Name);
						}
					}
					else
					{
						break;
					}				
					ival = ival + 1;

						//if (db.Name != "master")
						//{
						//	cbo.Items.Add(db.Name);
						//}
					}
				}
			cbo.SelectedIndex = 0;
		}

		// to check and Create new database
		public string CreatingOurDatabase(string DatabaseName)
		{
			return objSQL.createourDatabase(DatabaseName);
		}

		// to check and Delete database
		public string deleteDatabase(string DatabaseName)
		{
			return objSQL.deleteDatabase(DatabaseName);
		}

		//to BackUP Database
		public string backUpDatabase(string path, string DatabaseName)
		{
			return objSQL.backUpDatabase(path, DatabaseName);
		}

		//to Restore Database
		public string restoreDatabase(string path,string DatabaseName)
		{
			return objSQL.restoreDatabase(path,DatabaseName);
		}
		#endregion
	

		#region Database Details

		//load all tableName
		public void loadTableNames(ComboBox cbo,string DataBaseName)
		{
			//return objSQL.loaddbNames();
			TableCollection tableNames = objSQL.loadTableNames(DataBaseName);
			cbo.Items.Clear();
			cbo.Items.Add("");
			if (tableNames != null)
			{
				string dbnames = "";
				int ival = 0;
				foreach (Table tblName in tableNames)
				{				
					cbo.Items.Add(tblName.Name);					
                }
			}
			cbo.SelectedIndex = 0;
		}

		// to check and Delete Table
		public string deleteTable(string DatabaseName,string TableName)
		{
			return objSQL.deleteTable(DatabaseName,  TableName);
		}

		// to check and Create a new table
		public string createTable(string DatabaseName, string TableName,DataTable dt)
		{
			return objSQL.createTable(DatabaseName, TableName,dt);
		}
		#endregion

		#region Insert Details Load

	//To load all column details of a table.Here we will dynamically add all textbox for user input to insert record depend on columns selected
		public void loadTableColumnDetails(Panel pnControls, string DataBaseName,string TableName)
		{			
			ColumnCollection tableColumnDetail = objSQL.loadTableColumnDetails(DataBaseName, TableName);
			pnControls.Controls.Clear();
		
			if (tableColumnDetail != null)
			{
				string dbnames = "";
				int lableHeight = 20;
				int textboxHeight = 20;
				int lablewidth = 100;
				int lableXVal = 10;
				int lableYVal = 10;

				foreach (Column colName in tableColumnDetail)
				{
					string s = colName.Name;

					Random rnd = new Random();
					int randNumber = rnd.Next(1, 1000);

					//to add Column name to display as caption
					Label ctrl = new Label();
					ctrl.Location = new Point(lableXVal , lableYVal+6);
					ctrl.Size = new Size(lablewidth , lableHeight);
					ctrl.Name = "lbl_" + randNumber; ;
					ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					ctrl.Text = colName.Name;
					pnControls.Controls.Add(ctrl);

					//to add textbox for user enter insert text
					TextBox ctrltxt = new TextBox();
					ctrltxt.Location = new Point(lableXVal+110, lableYVal);
					ctrltxt.Size = new Size(lablewidth+40, lableHeight);
					ctrltxt.Name = "txt_" + randNumber;
					ctrltxt.Font = new System.Drawing.Font("NativePrinterFontA", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					ctrltxt.Text = "";
					
                    if (colName.DataType.Name== "int")
					{
						ctrltxt.MaxLength = 20;
                        ctrltxt.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
					}
					else
					{
						if(colName.DataType.MaximumLength.ToString()!="-1")
						{
							ctrltxt.MaxLength = Convert.ToInt32(colName.DataType.MaximumLength.ToString());
                        }
						else
						{
							ctrltxt.MaxLength =100;
						}
					}
					
					pnControls.Controls.Add(ctrltxt);

					//to add Column datatype as hidden field 
					Label ctrllbl = new Label();
					ctrllbl.Location = new Point(lableXVal + 112, lableYVal + 6);
					ctrllbl.Size = new Size(1, 1);
					ctrllbl.Name = "_lblDT_" + randNumber; ;
					ctrllbl.Font = new System.Drawing.Font("NativePrinterFontA", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					ctrllbl.Text = colName.DataType.Name;
					ctrllbl.Visible = false;
                    pnControls.Controls.Add(ctrllbl);

					if (lableXVal + 360 < pnControls.Width-110)
					{
						lableXVal = lableXVal + 270;
                    }
					else
					{
						lableXVal = 10;
						lableYVal = lableYVal + 40;
                    }
				}
			}			
		}
		//for numeric textbox validation
		private void textBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
		#endregion

		#region insert Save to database
		//insert data to table
		public string saveTableInsertQuery(Panel pnControls, string DataBaseName, string TableName)
		{
			string result = "";
			StringBuilder sqlQuery = new StringBuilder("INSERT INTO " + TableName );
			StringBuilder Insert = new StringBuilder(" (");
			StringBuilder values = new StringBuilder("VALUES (");
			SortedDictionary<string, string> sd = new SortedDictionary<string, string>();

			string columnName = "";
			string colvalue = "";
			string dataType = "";
			int iCount = 0;

			SqlCommand command = new SqlCommand();

			foreach (Control p in pnControls.Controls)
			{
				
				if (p.Name.ToString().Substring(0, 4) == "lbl_")
				{
					columnName = p.Text;					
				}
				else if (p.Name.ToString().Substring(0, 4) == "txt_")
				{
					colvalue = p.Text;
				}
				else if (p.Name.ToString().Substring(0, 4) == "_lbl")
				{
					Insert.Append(columnName);
					Insert.Append(", ");

					sd.Add(columnName, colvalue);
					values.Append("@" + columnName);

					values.Append(", ");
					if (p.Text == "int")
					{
						command.Parameters.Add("@" + columnName, SqlDbType.Int).Value = colvalue;
					}
					else if (p.Text == "varchar")
					{
						command.Parameters.Add("@" + columnName, SqlDbType.VarChar).Value = colvalue;
					}
					else if (p.Text == "nvarchar")
					{
						command.Parameters.Add("@" + columnName, SqlDbType.NVarChar).Value = colvalue;
					}
				}
			}
			string sqlresult = Insert.ToString().Remove(Insert.Length - 2) + ") ";

			sqlQuery.Append(sqlresult);
			
			string valueresult = values.ToString().Remove(values.Length - 2) + ") ";

			sqlQuery.Append(valueresult);
			sqlQuery.Append(";");
			
				command.CommandText = sqlQuery.ToString();
				command.CommandType = CommandType.Text;

			return objSQL.insertQuery(DataBaseName, sqlQuery.ToString(),  command); 			

		}


		#endregion

		#region insert Save to database
	//	Delete all records from table
		public string deleteRecordsfromTableQuery(string DataBaseName, string TableName)
		{
			string result = "";
			StringBuilder sqlQuery = new StringBuilder("DELETE FROM " + TableName);

			SqlCommand command = new SqlCommand();
			command.CommandText = sqlQuery.ToString();
			command.CommandType = CommandType.Text;

			return objSQL.deleteAllRecordsQuery(DataBaseName, command);

		}
		#endregion


		#region Insert Details Load

		// load all column of a table
		public void loadColumnDetailsforSelect(CheckedListBox chkListBoxCols, string DataBaseName, string TableName)
		{
			ColumnCollection tableColumnDetail = objSQL.loadTableColumnDetails(DataBaseName, TableName);			
			if (tableColumnDetail != null)
			{
				string dbnames = "";

				chkListBoxCols.Items.Clear();

                foreach (Column colName in tableColumnDetail)
				{
					string s = colName.Name;
					chkListBoxCols.Items.Add(s,true);
				}
			}
		}

		//Select selected table all columns or user selected columns
		public DataTable selectRecordsfromTableQuery(bool isAllColumns, CheckedListBox chkListBoxCols, string DataBaseName, string TableName)
		{
			string result = "";
			StringBuilder sqlQuery = new StringBuilder("Select * FROM " + TableName);

			string sqlresult = sqlQuery.ToString();
            if (!isAllColumns)
			{
				sqlQuery = new StringBuilder("Select  " );
				foreach (object itemChecked in chkListBoxCols.CheckedItems)
				{
					string colsName = itemChecked.ToString();
					sqlQuery.Append(colsName+", ");
				}
				sqlresult = sqlQuery.ToString().Remove(sqlQuery.Length - 2) + " FROM " + TableName;
			}		

			SqlCommand command = new SqlCommand();
			command.CommandText = sqlresult;
			command.CommandType = CommandType.Text;

			return objSQL.selectRecordsfromTableQuery(DataBaseName, command);

		}

		//Select query using user entered dynamic query
		public DataTable selectRecordsfromTableQuery(string DataBaseName, string selectQuery)
		{
			string result = "";		
			SqlCommand command = new SqlCommand();
			command.CommandText = selectQuery;
			command.CommandType = CommandType.Text;
			return objSQL.selectRecordsfromTableQuery(DataBaseName, command);
		}

		//Sql Injection test for user entered sql selecvt query
		public bool sqlInjectionCheck(String InjectionCheckString)
		{
			string[] sqlInjectionArray = { "create", "drop", "delete", "insert", "update", "truncate",
				"grant ","print","sp_executesql ","objects","declare","table","into","sqlcancel","sqlsetprop",
				"sqlexec","sqlcommit","revoke","rollback","sqlrollback","values","sqldisconnect","sqlconnect",
				"user","system_user","use","schema_name","schemata","information_schema","dbo","guest","db_owner",
				"db_","table","@@","Users","execute","sysname","sp_who","sysobjects","sp_","sysprocesses ","master",
				"sys","db_","is_","exec", "end", "xp_","; --", "/*", "*/", "alter", "begin", "cursor", "kill","--" ,"tabname","or","sys"};
            foreach (string sqlInjectionValue in sqlInjectionArray)
			{
				if (InjectionCheckString.Contains(sqlInjectionValue) == true)
				{
					MessageBox.Show("Sorry " + sqlInjectionValue + " keyword is not accepted in select query");
					return false;
				}
			}
			return true;
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

		public static void AddParameter(ref SqlParameter[] paramArray, params SqlParameter[] newParameters)
		{
			SqlParameter[] newArray = Array.CreateInstance(typeof(SqlParameter), paramArray.Length + newParameters.Length) as SqlParameter[];
			paramArray.CopyTo(newArray, 0);
			newParameters.CopyTo(newArray, paramArray.Length);

			paramArray = newArray;
		}

		#endregion
		#endregion

	}
}
