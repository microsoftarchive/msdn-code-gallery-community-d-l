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
/// Create date : 2015-05-09
/// Description :MYSQL DBCONNECT Helper CLASS
/// Latest
/// Modifier    : 
/// Modify date : 
/// </summary>

namespace DatagridViewCRUD.Helper
{
	class SQLDALClass
	{
		public String ConnectionString = "server=.; database=StudentsDB; user id=URID; password=PWD;";
		public SqlConnection connection;

		#region Initiallize
		public SQLDALClass()
		{
			Initialize();
		}

		//Initialize values
		private void Initialize()
		{
			ConnectionString = ReadConnectionString();

			connection = new SqlConnection(ConnectionString);
		}

		public String ReadConnectionString()
		{
			string path = Application.StartupPath + @"\DBConnection.txt";
			String connectionString = "";
			if (!File.Exists(path))
			{
				using (StreamWriter tw = File.CreateText(path))
				{
					tw.WriteLine("server=.; database=StudentsDB; user id=URID; password=PWD;");
					tw.Close();
					ConnectionString = "server=.; database=StudentsDB; user id=URID; password=PWD;";
				}

			}
			else
			{
				TextReader tr = new StreamReader(path);
				connectionString = tr.ReadLine();
				tr.Close();
			}
			return connectionString;

		}

		#endregion


		#region DB ConnectionOpen
		public bool OpenConnection()
		{
			try
			{
				connection.Open();
				return true;
			}
			catch (SqlException ex)
			{
				writeLogMessage(ex.Message.ToString());

			}
			return false;

		}
		#endregion

		#region DB Connection Close
		//Close connection
		public bool CloseConnection()
		{
			try
			{
				connection.Close();
				return true;
			}
			catch (SqlException ex)
			{
				writeLogMessage(ex.Message.ToString());
				return false;
			}
		}


		#endregion

		#region ExecuteNonQuery for insert/Update and Delete

		// For Student
		// Insert
		public DataSet SP_Student_ImageInsert(String SP_NAME, 
																string StudentName,
																string Email,
																string Phone,
																string Address,																
																byte[] IMAGEs
																)
		{
			DataSet ds = new DataSet();

			//open connection
			if (OpenConnection() == true)
			{
				//create command and assign the query and connection from the constructor
				SqlCommand cmd = new SqlCommand(SP_NAME, connection);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.Add("@StudentName", SqlDbType.VarChar);
				cmd.Parameters.Add("@Email", SqlDbType.VarChar);
				cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
				cmd.Parameters.Add("@Address", SqlDbType.VarChar);
				cmd.Parameters.Add("@IMAGEs", SqlDbType.VarBinary);
				

				cmd.Parameters["@StudentName"].Value = StudentName;
				cmd.Parameters["@Email"].Value = Email;
				cmd.Parameters["@Phone"].Value = Phone;
				cmd.Parameters["@Address"].Value = Address;
				if (IMAGEs == null)
				{
					cmd.Parameters["@IMAGEs"].Value = DBNull.Value;
                }
				else
				{ 
				cmd.Parameters["@IMAGEs"].Value = IMAGEs;
				}

				//Execute command
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);

				//close connection
				CloseConnection();
			}
			return ds;
		}


		// Update
		public DataSet SP_Student_ImageEdit(String SP_NAME,		int    std_ID,
                                                                string StudentName,
																string Email,
																string Phone,
																string Address,
																byte[] IMAGEs
																)
		{
			DataSet ds = new DataSet();

			//open connection
			if (OpenConnection() == true)
			{
				//create command and assign the query and connection from the constructor
				SqlCommand cmd = new SqlCommand(SP_NAME, connection);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.Add("@std_ID", SqlDbType.Int);
				cmd.Parameters.Add("@StudentName", SqlDbType.VarChar);
				cmd.Parameters.Add("@Email", SqlDbType.VarChar);
				cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
				cmd.Parameters.Add("@Address", SqlDbType.VarChar);
				cmd.Parameters.Add("@IMAGEs", SqlDbType.VarBinary);

				cmd.Parameters["@std_ID"].Value = std_ID;
				cmd.Parameters["@StudentName"].Value = StudentName;
				cmd.Parameters["@Email"].Value = Email;
				cmd.Parameters["@Phone"].Value = Phone;
				cmd.Parameters["@Address"].Value = Address;
				if (IMAGEs == null)
				{
					cmd.Parameters["@IMAGEs"].Value = DBNull.Value;
				}
				else
				{
					cmd.Parameters["@IMAGEs"].Value = IMAGEs;
				}

				//Execute command
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);

				//close connection
				CloseConnection();
			}
			return ds;
		}

		#endregion



		#region Write Log Message to textFile
		public void writeLogMessage(String logMessage)
		{
			string path = Application.StartupPath + @"\LogFile.txt";

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

		#region DataTable for select result and return as DataTable
		//for select result and return as DataTable
		public DataSet SP_Dataset_return(String ProcName, params SqlParameter[] commandParameters)
		{
			DataSet ds = new DataSet();
			//open connection
			if (OpenConnection() == true)
			{
				//for Select Query               

				SqlCommand cmdSel = new SqlCommand(ProcName, connection);
				cmdSel.CommandType = CommandType.StoredProcedure;
				// Assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, commandParameters);
				AttachParameters(cmdSel, commandParameters);
				SqlDataAdapter da = new SqlDataAdapter(cmdSel);
				da.Fill(ds);
				//close connection
				CloseConnection();
			}



			return ds;
		}
		private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
		{
			if (command == null) throw new ArgumentNullException("command");
			if (commandParameters != null)
			{
				foreach (SqlParameter p in commandParameters)
				{
					if (p != null)
					{
						// Check for derived output value with no value assigned
						if ((p.Direction == ParameterDirection.InputOutput ||
							p.Direction == ParameterDirection.Input) &&
							(p.Value == null))
						{
							p.Value = DBNull.Value;
						}
						command.Parameters.Add(p);
					}
				}
			}
		}

		private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null) || (parameterValues == null))
			{
				// Do nothing if we get no data
				return;
			}

			// We must have the same number of values as we pave parameters to put them in
			if (commandParameters.Length != parameterValues.Length)
			{
				throw new ArgumentException("Parameter count does not match Parameter Value count.");
			}

			// Iterate through the SqlParameters, assigning the values from the corresponding position in the 
			// value array
			for (int i = 0, j = commandParameters.Length; i < j; i++)
			{
				// If the current array value derives from IDbDataParameter, then assign its Value property
				if (parameterValues[i] is IDbDataParameter)
				{
					IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
					if (paramInstance.Value == null)
					{
						commandParameters[i].Value = DBNull.Value;
					}
					else
					{
						commandParameters[i].Value = paramInstance.Value;
					}
				}
				else if (parameterValues[i] == null)
				{
					commandParameters[i].Value = DBNull.Value;
				}
				else
				{
					commandParameters[i].Value = parameterValues[i];
				}
			}
		}
		#endregion




	}
}
