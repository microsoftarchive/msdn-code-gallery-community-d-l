using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;
using System.IO;
/// <summary>
/// Author      : Shanu
/// Create date : 2016-01-01
/// Description :SMO Connection Class
/// Latest
/// Modifier    : Shanu
/// Modify date : 2016-01-01
/// </summary>
namespace shanuEasySQLTool.Helper
{
	class smoSQLServerClass
	{
		#region Variables
		ServerConnection servConn = new ServerConnection();
		public static string serverName = "";
		public static string LoginID = "";
		public static string password = "";
		#endregion


		/// <summary>
		/// This method is to connect to SQL server
		/// </summary>
		/// <returns> return true or false</returns>
		#region SMO Server Connect
		public bool SqlServerConnect()
		{
			try
			{
				servConn = new ServerConnection();
				servConn.ServerInstance = serverName;
				servConn.LoginSecure = false;
				servConn.Login = LoginID;
				servConn.Password = password;
				servConn.Connect();
				if(servConn.IsOpen)
				{
					return true;
				}
				else
				{
					return false;
				}
               
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());

			}
			return false;
		}
		#endregion

		/// <summary>
		/// This method is to disconnect from SQL server
		/// </summary>
		/// <returns> return true or false</returns>
		#region SMO Server Disconnect
		public bool SqlServerDisconnect()
		{
			try
			{
				servConn.Disconnect();
				return true;
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return false;
		}
		#endregion

		/// <summary>
		/// For Database related all Functions
		/// </summary>
		/// <returns> </returns>
		#region Database Details

		/// <summary>
		/// This method is to get all the database name and return the DatabaseCollections
		/// </summary>
		/// <returns> return the DatabaseCollections</returns>
		#region load Database
		public DatabaseCollection loaddbNames()
		{
			DatabaseCollection dbNames = null;
			try
			{				
				if (SqlServerConnect())
			{
				Server srv = new Server(servConn);
					dbNames = srv.Databases;
					SqlServerDisconnect();
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return dbNames;
        }
		#endregion

		/// <summary>
		/// To Delete the database and return the string message
		/// </summary>
		/// <returns> return the string message</returns>
		#region Delete Database
		public string deleteDatabase(string DatabaseName)
		{
			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);
					Database database = srv.Databases[DatabaseName];
					if (database != null)
					{						
						database.Drop();						
						SqlServerDisconnect();
						return "Database Deleted";
					}					
				}
				else
				{
					return "Enter valid SQL Connection Details";
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());

			}
			return "Sorry Error While Deleting DB";
		}
		#endregion

		/// <summary>
		/// To Create the database and return the string message
		/// </summary>
		/// <returns> return the string message</returns>
		#region Create Database
		public string createourDatabase(string DatabaseName)
		{

			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);

					Database database = srv.Databases[DatabaseName];
					if (database == null)
					{
						database = new Database(srv, DatabaseName);
						database.Create();
						database.Refresh();
						SqlServerDisconnect();
						return "Database Created Successfully !";
					}
					else
					{
						SqlServerDisconnect();
						return "Database Already Exist";
					}
				}
				else
				{
					return "Enter valid SQL Connection Details";
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return "Sorry Error While creating DB";
		}
		#endregion

		/// <summary>
		/// To Backup the database and return the string message
		/// </summary>
		/// <returns> return the string message</returns>
		#region Backup Database
		public string backUpDatabase(string path, string DatabaseName)
		{
			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);

					Database database = srv.Databases[DatabaseName];
					if (database != null)
					{
						Backup dbBackup = new Backup();
						dbBackup.Action = BackupActionType.Database;
						dbBackup.Database = database.Name;
						dbBackup.Devices.AddDevice(path, DeviceType.File);
						dbBackup.SqlBackup(srv);
						SqlServerDisconnect();
						return "Database Backup Sucessfull";
					}
				}
				else
				{
					return "Enter valid SQL Connection Details";
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());

			}
			return "Sorry Error While Restore DB";
		}

		#endregion

		/// <summary>
		/// To Restote the database and return the string message
		/// </summary>
		/// <returns> return the string message</returns>
		#region Restore Database
		public string restoreDatabase(string path,string DatabaseName)
		{
			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);

					Database database = srv.Databases[DatabaseName];					

					Restore restoreBackUp = new Restore();
					restoreBackUp.Action = RestoreActionType.Database;
					restoreBackUp.Database = DatabaseName;
					BackupDeviceItem source = new BackupDeviceItem(path, DeviceType.File);
					restoreBackUp.Devices.Add(source);
					restoreBackUp.ReplaceDatabase = true;
					restoreBackUp.NoRecovery = false;
					restoreBackUp.SqlRestore(srv);

					SqlServerDisconnect();
						return "Database Restore Sucessfull";
					}
				
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return "Sorry Error While Restore DB";			
		}


		#endregion
		#endregion
		/// <summary>
		/// For SQL Table related all Functions
		/// </summary>
		/// <returns> </returns>
		#region Table Details
		/// <summary>
		/// To load all Table Name and return the TableCollection
		/// </summary>
		/// <returns>  return the TableCollection</returns>
		#region load Table Name
		public TableCollection loadTableNames(string DatabaseName)
		{
			TableCollection	 tableNames = null;
			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);
					Database db = srv.Databases[DatabaseName];
					tableNames = db.Tables;
					SqlServerDisconnect();
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return tableNames;
		}
		#endregion

		/// <summary>
		/// To Delete Table and return the message as String
		/// </summary>
		/// <returns> return the message as String </returns>
		#region Delete Table
		public string deleteTable(string DatabaseName,string TableName)
		{
			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);

					Database database = srv.Databases[DatabaseName];
					if (database != null)
					{
						bool tableExists = database.Tables.Contains(TableName);
						if (tableExists)
						{
							database.Tables[TableName].Drop();
						}
						SqlServerDisconnect();
						return "Table Deleted Successfully !";
					}
				}
				else
				{
					return "Enter valid SQL Connection Details";
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return "Sorry Error While Deleting Table";
		}
		#endregion

		/// <summary>
		/// To Create Table and return the message as String
		/// </summary>
		/// <returns> return the message as String </returns>
		#region Create Table
		public string createTable(string DatabaseName, string TableName,DataTable dtColumns)
		{
			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);
					Database database = srv.Databases[DatabaseName];
					if (database != null)
					{
						bool tableExists = database.Tables.Contains(TableName);
						if (tableExists)
						{
							SqlServerDisconnect();
							return "Table Already Exist.kindly Enter Different Table Name";
						}
						else
						{
							Table tbl = new Table(database, TableName);					
							foreach (DataRow dr in dtColumns.Rows)
							{
								string columnName = dr["ColumName"].ToString();
								string DataType = dr["DataType"].ToString();
								string dataSize = dr["Size"].ToString();
								Microsoft.SqlServer.Management.Smo.Column columntoAdd =null;						
								switch (DataType)
								{
									case "Varchar":
										if(dataSize=="max")
										{
											columntoAdd = new Column(tbl, columnName, Microsoft.SqlServer.Management.Smo.DataType.VarCharMax);
										}
										else if (dataSize != "")
										{
											columntoAdd = new Column(tbl, columnName, Microsoft.SqlServer.Management.Smo.DataType.VarChar(Convert.ToInt32(dataSize)));
										}
										break;
									case "Int":										
											columntoAdd = new Column(tbl, columnName, Microsoft.SqlServer.Management.Smo.DataType.Int);										
										break;
									case "nVarchar":
										if (dataSize == "max")
										{
											columntoAdd = new Column(tbl, columnName, Microsoft.SqlServer.Management.Smo.DataType.NVarCharMax);
										}
										else if (dataSize != "")
										{
											columntoAdd = new Column(tbl, columnName, Microsoft.SqlServer.Management.Smo.DataType.NVarChar(Convert.ToInt32(dataSize)));
										}
										break;
								}
								if(columntoAdd!=null)
								{ 
								tbl.Columns.Add(columntoAdd);
								}
							}
							tbl.Create();
							SqlServerDisconnect();
							return "Table Created Successfully !";
						}						
					}
				}
				else
				{
					return "Enter valid SQL Connection Details";
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return "Sorry Error While Creating Table";
		}
		#endregion

		/// <summary>
		/// For Table Insert all Functions
		/// </summary>
		/// <returns>  </returns>
		/// 
		#region Table Insert Details
		/// <summary>
		/// To get all Column details for a given Table and return the ColumnCollection
		/// </summary>
		/// <returns> return the ColumnCollection </returns>
		#region load Table Column Name
		public ColumnCollection loadTableColumnDetails(string DatabaseName,string TableName)
		{
			ColumnCollection columnDetails = null;
			try
			{
				if (SqlServerConnect())
				{
					Server srv = new Server(servConn);
					Database db = srv.Databases[DatabaseName];
					bool tableExists = db.Tables.Contains(TableName);
					if (tableExists)
					{					
						foreach (Table table in db.Tables)
						{
							if (table.Name == TableName)
							{
								columnDetails = table.Columns;
								break;
							}
						}						
					}	
									
					SqlServerDisconnect();
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
			}
			return columnDetails;
		}
		#endregion

		/// <summary>
		/// To Insert records to given Table and return the message as String
		/// </summary>
		/// <returns> return the message as String </returns>
		#region Insert into Table
		public string insertQuery(string DatabaseName, string query, SqlCommand cmd)
		{
			string result = "";
			//SqlCommand command = new SqlCommand(query);
			string connectionString = "server="+ serverName + "; database=" + DatabaseName + "; user id=" + LoginID +"; password=" + password +";";
			SqlCommand command = cmd;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					command.Connection = connection;
					command.CommandType = System.Data.CommandType.Text;
					connection.Open();
					result = command.ExecuteNonQuery().ToString();
				}
				if (result == "1")
				{
					result = "One record Inserted to ";
				}
				else
				{
					result = "Insert failed .Please try again !";
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
				result = "Sorry Error While Inserting to Table";
			}

			return result;
           
		}
		#endregion

		/// <summary>
		/// To delete all the records of given Table and return the message as String
		/// </summary>
		/// <returns> return the message as String </returns>
		#region Delete All records of  Table
		public string deleteAllRecordsQuery(string DatabaseName,  SqlCommand cmd)
		{
			string result = "";
			//SqlCommand command = new SqlCommand(query);
			string connectionString = "server=" + serverName + "; database=" + DatabaseName + "; user id=" + LoginID + "; password=" + password + ";";
			SqlCommand command = cmd;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					command.Connection = connection;
					command.CommandType = System.Data.CommandType.Text;
					connection.Open();
					result = command.ExecuteNonQuery().ToString();
				}
				if (result == "1")
				{
					result = "All Records deleted from table ";
				}
				else
				{
					result = "There is no records to be deleted !";
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
				result = "Sorry Error While Deleting Table";
			}

			return result;

		}
		#endregion
		#endregion


		/// <summary>
		///  To Select records from Table 
		/// </summary>
		/// <returns>  </returns>
		#region Select tab

		/// <summary>
		/// To Select records from Table and return datatable to display output
		/// </summary>
		/// <returns> return datatable to display output </returns>
		#region Select records from Table
		public DataTable selectRecordsfromTableQuery(string DatabaseName, SqlCommand cmd)
		{
			DataTable dt = new DataTable();
			string connectionString = "server=" + serverName + "; database=" + DatabaseName + "; user id=" + LoginID + "; password=" + password + ";";
			SqlCommand command = cmd;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					command.Connection = connection;
					command.CommandType = System.Data.CommandType.Text;
					connection.Open();
					SqlDataAdapter da = new SqlDataAdapter(command);
					da.Fill(dt);
				}
			}
			catch (Exception ex)
			{
				writeLogMessage(ex.Message.ToString());
				return dt;
			}
			return dt;
        }
		#endregion

		#endregion

		#endregion

		#region Write Log Message to textFile
		public void writeLogMessage(String logMessage)
		{
			string path = Application.StartupPath + @"\LogFile.txt";
			logMessage = logMessage + " - on " + DateTime.Now.ToString();
            if (!File.Exists(path))
			{
				using (StreamWriter tw = File.CreateText(path))
				{
					tw.WriteLine(logMessage);
					tw.Close();
				}
			}
			else
			{
				StreamWriter tr = new StreamWriter(path);
				tr.WriteLine(logMessage);
				tr.Close();
			}
		}
		#endregion
	}
}
