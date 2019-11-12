using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;

namespace shanuEasySQLTool
{
	public partial class shanuEasySQLTool : Form
	{
		#region Variables
		Helper.sqlBizClass objSQL = new Helper.sqlBizClass();
		Helper.smoSQLServerClass objSMO = new Helper.smoSQLServerClass();
		#endregion

		#region FormLoad
		public shanuEasySQLTool()
		{
			InitializeComponent();
		}
		Boolean chkConnection = false;
		private void shanuEasySQLTool_Load(object sender, EventArgs e)
		{
			chkConnection=setSQLConnection();
			if(chkConnection)
			{
				loadDatabaseName();
				ClearTableCreationControl();
			}
			
        }
		#endregion

		#region Methods

		//to clear the controls
		private void ClearTableCreationControl()
		{		
			cboColDataType.SelectedIndex = 0;
			txtColumnName.Text = "";
			txttableName.Text = "";
			chkMaxSize.Checked = false;
			lstTableColumn.Items.Clear();
		}

		//to save the SQL Connection string to public variable
		private bool setSQLConnection()
		{
			if (txtServerName.Text.Trim() == "")
			{
				MessageBox.Show("Enter SQL Server Name");
				txtServerName.Focus();
                return false;
			}

			if (txtLogin.Text.Trim() == "")
			{
				MessageBox.Show("Enter SQL Server LoginID");
				txtLogin.Focus();
				return false;
			}

			if (txtpwd.Text.Trim() == "")
			{
				MessageBox.Show("Enter SQL Server password");
				txtpwd.Focus();
				return false;
			}

			Helper.smoSQLServerClass.serverName = txtServerName.Text.Trim();
			Helper.smoSQLServerClass.LoginID = txtLogin.Text.Trim();
			Helper.smoSQLServerClass.password = txtpwd.Text.Trim();
			return true;
		}

		//to load Database names to Combobox
		private void loadDatabaseName()
		{
			if (!setSQLConnection())
			{
				return;
			}
			
			objSQL.loaddbNames(cboDatabase);		
		}

		//to load all Table Names to combobox.In this method we pass the combobox as parameter to biz class to load all details.
		private void loadTableName()
		{
			if (!setSQLConnection())
			{
				return;
			}
			objSQL.loadTableNames(cboTable, txtDBNAME.Text.Trim());		
		}

		//we will pass the insert panel for adding all dynmic controls for user inpu to insert record
		private void loadColumnDetails()
		{
			if (!setSQLConnection())
			{
				return;
			}
			objSQL.loadTableColumnDetails(pnlInsertControls, txtDBNAME.Text.Trim(),cboTable.SelectedItem.ToString());
		}

		//we will pass the checkedlistbox to load all the column details for user selecting columns to display.
		private void loadColumnDetailsforSelect()
		{
			if (!setSQLConnection())
			{
				return;
			}
			objSQL.loadColumnDetailsforSelect(chkListBoxColumns, txtDBNAME.Text.Trim(), cboTable.SelectedItem.ToString());

		}
		//we will pass the insert panel for adding all dynmic controls for user inpu to insert record
		private void loadTableColumnDetails()
		{
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}
			if (cboTable.Items.Count <= 0)
			{
				MessageBox.Show("Select valid Table to select Column");
				return;
			}
			if (cboTable.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Select valid Table to select Column");
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			loadColumnDetails();
			Cursor.Current = Cursors.Default;
		}

		//In this function we will check for the Select query type as user entered or user selected columns to display.

		private void buildSelectScript()
		{
			DataTable dt = new DataTable();
			Cursor.Current = Cursors.WaitCursor;

			if (chkWriteSelectQuery.Checked == true)
			{
				if (txtSelectQuery.Text.Trim() == "")
				{
					MessageBox.Show("Enter Select Query");
					txtSelectQuery.Focus();
                    return;
				}

				string sqlSelectQuery = txtSelectQuery.Text.ToLower().Trim();
					if (sqlSelectQuery.Contains("select") == true)
					{

					if(!objSQL.sqlInjectionCheck(sqlSelectQuery))
					{
						return;
					}
					 dt = objSQL.selectRecordsfromTableQuery(txtDBNAME.Text.Trim(), txtSelectQuery.Text.Trim());
					}			
			}
			else
			{
				if (cboTable.Items.Count <= 0)
				{
					MessageBox.Show("Select valid Table to select Column");
					return;

				}
				if (cboTable.SelectedItem.ToString() == "")
				{
					MessageBox.Show("Select valid Table to select Column");
					return;
				}

				bool isAllcolumn = false;
				if (chkAllColumns.Checked == true)
				{
					isAllcolumn = true;
				}
				else
				{
					if(chkListBoxColumns.CheckedItems.Count <=0)
					{
						MessageBox.Show("Select Columns ");
						return;
					}
                }
				GridSelect.DataSource = null;
				dt = objSQL.selectRecordsfromTableQuery(isAllcolumn, chkListBoxColumns, txtDBNAME.Text.Trim(), cboTable.SelectedItem.ToString());
			}

			if (dt.Rows.Count > 0)
			{
				txtoutput.SendToBack();
				GridSelect.BringToFront();
				GridSelect.DataSource = dt;
			}
			else
			{
				txtoutput.BringToFront();
				GridSelect.SendToBack();
				txtoutput.ForeColor = Color.DarkRed;
				txtoutput.Text = "Sorry No records to Display";
				MessageBox.Show("Sorry No records to Display");
			}
			Cursor.Current = Cursors.Default;
		}
		#endregion

		#region Events

		#region Database Connect and left panel all controls

		//To Connect to database
		private void btnConnect_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (!setSQLConnection())
			{
				return;
			}
			string createdDB = objSQL.CreatingOurDatabase(txtDBNAME.Text.Trim());

			if (createdDB == "Database Created Successfully !")
			{
				txtoutput.ForeColor = Color.RoyalBlue;
			}
			else
			{
				txtoutput.ForeColor = Color.DarkRed;
			}
			txtoutput.Text = createdDB;

			MessageBox.Show(createdDB);
			loadDatabaseName();
			Cursor.Current = Cursors.Default;
		}
		//To load database name
		private void btnloadDB_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (!setSQLConnection())
			{
				return;
			}
			loadDatabaseName();

			Cursor.Current = Cursors.Default;
		}


		//to delete the selected table

		private void btnDeleteDB_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (!setSQLConnection())
			{
				return;
			}

			if (cboDatabase.SelectedItem.ToString()=="")
			{
				MessageBox.Show("Select valid database for delete");
				return;
			}
			if (MessageBox.Show("Are You Sure to Delete Select Database ?", "Delete Database", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!setSQLConnection())
				{
					return;
				}
				string deleteDBMsg = objSQL.deleteDatabase(cboDatabase.SelectedItem.ToString().Trim());
				MessageBox.Show(deleteDBMsg);
				loadDatabaseName();
			}
			Cursor.Current = Cursors.Default;
		}
	
		//to restore the database
		private void btnRestoreDB_Click(object sender, EventArgs e)
		{
			if (cboDatabase.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Select valid database for Restore");
				return;
			}
			if (!setSQLConnection())
			{
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Bak Files (*.bak)|*.bak";
			ofd.Title = "Restore Database";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string restoreDBMsg = objSQL.restoreDatabase(ofd.FileName, cboDatabase.SelectedItem.ToString().Trim());

				if (restoreDBMsg == "Database Restore Sucessfull")
				{
					txtoutput.ForeColor = Color.RoyalBlue;
				}
				else
				{
					txtoutput.ForeColor = Color.DarkRed;
				}
				txtoutput.Text = restoreDBMsg;
				MessageBox.Show(restoreDBMsg);
			}
			Cursor.Current = Cursors.Default;
		}

		//to backup database
		private void btnBackupDB_Click(object sender, EventArgs e)
		{
			if (cboDatabase.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Select valid database for BackUp");
				return;
			}

			if (!setSQLConnection())
			{
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				string fileName = fbd.SelectedPath + @"\" + cboDatabase.SelectedItem.ToString() + ".bak";

				string restoreDBMsg = objSQL.backUpDatabase(fileName, cboDatabase.SelectedItem.ToString().Trim());

				if (restoreDBMsg == "Database Backup Sucessfull")
				{
					txtoutput.ForeColor = Color.RoyalBlue;
				}
				else
				{
					txtoutput.ForeColor = Color.DarkRed;
				}
				txtoutput.Text = restoreDBMsg;
				MessageBox.Show(restoreDBMsg);
			}
			Cursor.Current = Cursors.Default;
		}

		// to display the selected databasen name to a textbox

		private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtDBNAME.Text = cboDatabase.SelectedItem.ToString().Trim();
        }

		#endregion
		#region Table Load and Delete
		//to load all the Tablename 
		private void btnTableList_Click(object sender, EventArgs e)
		{
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			loadTableName();
			Cursor.Current = Cursors.Default;
		}

		//to delete the selected table.
		private void btnDeleteTable_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (!setSQLConnection())
			{
				return;
			}
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}

			if (cboTable.Items.Count <= 0)
			{
				return;
			}

			if (cboTable.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Select valid Table to delete");
				return;
			}
			if (MessageBox.Show("Are You Sure to Delete the Selected Table ?", "Delete Table", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!setSQLConnection())
				{
					return;
				}

				string deleteTableMsg = objSQL.deleteTable(txtDBNAME.Text.Trim(), cboTable.SelectedItem.ToString().Trim());

				if (deleteTableMsg == "Table Deleted Successfully !")
				{
					txtoutput.ForeColor = Color.RoyalBlue;
					pnlInsertControls.Controls.Clear();
                }
				else
				{
					txtoutput.ForeColor = Color.DarkRed;
				}
				txtoutput.Text = deleteTableMsg;
				MessageBox.Show(deleteTableMsg);
				loadTableName();
			}
			Cursor.Current = Cursors.Default;
		}
		#endregion
		#region Table Creation all Events
	
	
		//to Add columns , data type and column size to list view to create table	
		private void btnAddColumn_Click(object sender, EventArgs e)
		{
			if (txtColumnName.Text.Trim() == "")
			{
				MessageBox.Show("Enter Column Name");
				txtColumnName.Focus();
                return;
			}
			string dataType = cboColDataType.SelectedItem.ToString();

            if (dataType == "")
			{
				MessageBox.Show("Select Data Type");
				return;
			}
			
            string dataTypetoAdd = "Varchar";
			switch (dataType)
			{
				case "Text (Varchar)":
					dataTypetoAdd = "Varchar";
					break;
				case "Numbers (Int)":
					dataTypetoAdd = "Int";
					break;
				case "Numbres and Text (nVarchar)":
					dataTypetoAdd = "nVarchar";
					break;
			}			

			string ColumnSize = "10";
			if (dataTypetoAdd=="Int")
			{
				ColumnSize = "";
			}
			else
			{
				ColumnSize = numericSize.Value.ToString();
				if (chkMaxSize.Checked ==true)
				{
					ColumnSize = "max";
				}
            }

			ListViewItem lvi = new ListViewItem();

			if (!lstTableColumn.Items.ContainsKey(txtColumnName.Text.Trim()))
			{
				lvi.Text = txtColumnName.Text.Trim();
				lvi.Name = txtColumnName.Text.Trim();
				lvi.SubItems.Add(dataTypetoAdd);
				lvi.SubItems.Add(ColumnSize);
				lstTableColumn.Items.Add(lvi);
			}
			else
			{
				MessageBox.Show("Column Already Added");
			}

			txtColumnName.Text = "";
		}

		//to delete the user entered colums rfom listview
		private void btnDeleteColumn_Click(object sender, EventArgs e)
		{
			if(lstTableColumn.SelectedItems.Count<=0)
			{
				MessageBox.Show("No columns has been selected to delete");
				return;
			}
			lstTableColumn.Items.Cast<ListViewItem>().Where(L => L.Selected)
	.Select(L => L.Index).ToList().ForEach(L => lstTableColumn.Items.RemoveAt(L));
        }

		//to create a table
		private void btncreateTable_Click(object sender, EventArgs e)
		{
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}

			if (txttableName.Text.Trim() == "")
			{
				MessageBox.Show("Enter Table Name to Create");
				txttableName.Focus();
				return;
			}
			if(lstTableColumn.Items.Count<=0)
			{
				MessageBox.Show("Add Columns for Table");				
				return;
			}
			
			//Here we add the Table column Details from list to a dataTable 
		 DataTable dt = new DataTable();
			dt.Columns.Add("ColumName", typeof(string));
			dt.Columns.Add("DataType", typeof(string));
			dt.Columns.Add("Size", typeof(string));	

            for (int i = 0; i < lstTableColumn.Items.Count; i++)
            {
				dt.Rows.Add(lstTableColumn.Items[i].SubItems[0].Text, lstTableColumn.Items[i].SubItems[1].Text, lstTableColumn.Items[i].SubItems[2].Text);
            }

			Cursor.Current = Cursors.WaitCursor;
			if (!setSQLConnection())
			{
				return;
			}
			
			if (MessageBox.Show("Are You Sure to Create New Table?", "Create Table", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!setSQLConnection())
				{
					return;
				}
				string createTableMsg = objSQL.createTable(txtDBNAME.Text.Trim(), txttableName.Text.Trim(), dt);
				MessageBox.Show(createTableMsg);
				if(createTableMsg== "Table Created Successfully !")
				{
					txtoutput.ForeColor = Color.RoyalBlue;
					loadTableName();
					ClearTableCreationControl();
				}
				else
				{
					txtoutput.ForeColor = Color.DarkRed;
                }
				txtoutput.Text = createTableMsg;              
            }
			Cursor.Current = Cursors.Default;
		}

		//to clear the table column listview 

		private void btnClearTableGrid_Click(object sender, EventArgs e)
		{
			lstTableColumn.Items.Clear();
		}
		#endregion

		#region Insert Tab

		// to load all column details of a selected table
		private void btnInsertLoad_Click(object sender, EventArgs e)
		{
			loadTableColumnDetails();
		}

		//to insert a record
		private void btnInsertRecords_Click(object sender, EventArgs e)
		{
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}

			if (cboTable.Items.Count <= 0)
			{
				MessageBox.Show("Select valid Table to select Column");
				return;
			}
			if (cboTable.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Select valid Table to select Column");
				return;
			}

			if (pnlInsertControls.Controls.Count <= 0)
			{
				MessageBox.Show("There is no Insert Column for insert");
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			if (!setSQLConnection())
			{
				return;
			}

			string insertMsg = objSQL.saveTableInsertQuery(pnlInsertControls, txtDBNAME.Text.Trim(), cboTable.SelectedItem.ToString());

			if (insertMsg == "One record Inserted to ")
			{
				insertMsg = insertMsg + cboTable.SelectedItem.ToString() + " Table !";
				txtoutput.ForeColor = Color.RoyalBlue;
			}
			else
			{
				txtoutput.ForeColor = Color.DarkRed;
			}
			txtoutput.Text = insertMsg;
			MessageBox.Show(insertMsg);
			Cursor.Current = Cursors.Default;
		}


		//to delete all records of a selected table
		private void btnDeleteRecords_Click(object sender, EventArgs e)
		{
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}

			if (cboTable.Items.Count <= 0)
			{
				MessageBox.Show("Select valid Table to Delete Records");
				return;
			}
			if (cboTable.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Select valid Table to Delete");
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			if (MessageBox.Show("Are You Sure to Delete All the records of selected Table ?", "Delete Records", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!setSQLConnection())
				{
					return;
				}

				string deleterecordsMsg = objSQL.deleteRecordsfromTableQuery(txtDBNAME.Text.Trim(), cboTable.SelectedItem.ToString());

				if (deleterecordsMsg == "All Records deleted from table ")
				{
					deleterecordsMsg = deleterecordsMsg + cboTable.SelectedItem.ToString() + " !";
					txtoutput.ForeColor = Color.RoyalBlue;
				}
				else
				{
					txtoutput.ForeColor = Color.DarkRed;
				}
				txtoutput.Text = deleterecordsMsg;
				MessageBox.Show(deleterecordsMsg);
				Cursor.Current = Cursors.Default;
			}
		}




		#endregion


		#region Select Tab
		// to load all column details for select query 
		private void btnSelectColumnLoad_Click(object sender, EventArgs e)
		{
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}

			if (cboTable.Items.Count <= 0)
			{
				MessageBox.Show("Select valid Table to select Column");
				return;
			}
			if (cboTable.SelectedItem.ToString() == "")
			{
				MessageBox.Show("Select valid Table to select Column");
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			loadColumnDetailsforSelect();
			Cursor.Current = Cursors.Default;
			
        }
		
		//to build the select query and bind the result 
		private void btnSelectQuery_Click(object sender, EventArgs e)
		{
			if (txtDBNAME.Text.Trim() == "")
			{
				MessageBox.Show("Select Database");
				return;
			}
			
			buildSelectScript();		
		}

		//to save the sql script
		private void btnSaveSqlScript_Click(object sender, EventArgs e)
		{
			if (txtSelectQuery.Text.Trim() == "")
			{
				MessageBox.Show("Enter Select Query to Save");
				txtSelectQuery.Focus();
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			using (var savetxtFile = new SaveFileDialog())
			{
				savetxtFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				savetxtFile.FilterIndex = 2;

				if (savetxtFile.ShowDialog() == DialogResult.OK)
				{
					string path = savetxtFile.FileName + ".txt";
					using (StreamWriter tw = File.CreateText(path))
					{
						tw.WriteLine(txtSelectQuery.Text.Trim());
						tw.Close();
					
					}
					MessageBox.Show("SQL Select Query Saved");
				}
			}

			

			Cursor.Current = Cursors.Default;

		}

		//to open the saved sql Script
		private void btnLoadScript_Click(object sender, EventArgs e)
		{
		
			Cursor.Current = Cursors.WaitCursor;
			using (var openSqlScript = new OpenFileDialog())
			{
				openSqlScript.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openSqlScript.FilterIndex = 2;

				if (openSqlScript.ShowDialog() == DialogResult.OK)
				{					
					TextReader tr = new StreamReader(openSqlScript.FileName);
					txtSelectQuery.Text = tr.ReadToEnd();
					tr.Close();
				}
			}

			Cursor.Current = Cursors.Default;
		}


		//to export the select query output to csv format.
		private void btnExporttoExcel_Click(object sender, EventArgs e)
		{
			if (GridSelect.Rows.Count <= 0)
			{
				MessageBox.Show("There is no records to Export");
				return;
			}

			using (var savetxtFile = new SaveFileDialog())
			{
				savetxtFile.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
				savetxtFile.FilterIndex = 2;
				savetxtFile.FileName = "exporttoCSV.csv";
                if (savetxtFile.ShowDialog() == DialogResult.OK)
				{
					string path = savetxtFile.FileName;
				exportGridtoCSV(GridSelect, path);

				}
			}
		}

		public void exportGridtoCSV(DataGridView gridSelect, string csvPath)
		{			
				string value = "";			

			using (StreamWriter tw = File.CreateText(csvPath))
			{
				//first we read all grid Headertext and write 
				for (int i = 0; i <= gridSelect.Columns.Count - 1; i++)
				{
					if (i > 0)
					{
						tw.Write(",");
					}
					tw.Write(gridSelect.Columns[i].HeaderText);
				}
				tw.WriteLine();

				//Here we read all Datagridview rows and cell vaule and make a csv file
				foreach (DataGridViewRow dr in gridSelect.Rows)
				{		
					for (int i = 0; i <= gridSelect.Columns.Count - 1; i++)
					{
						string writeValue = dr.Cells[i].Value.ToString();
                        tw.Write(writeValue);
						if (i < gridSelect.Columns.Count-1)
						{
							tw.Write(",");
						}
					}				
					tw.Write(tw.NewLine);					
				}
				tw.Close();
			}			
		}
		#endregion


		#region for Tabstrip Click to bring textboxfront

		private void tabPage1_Click(object sender, EventArgs e)
		{
			pnlInsertControls.Controls.Clear();
			chkListBoxColumns.Items.Clear();
            txtoutput.BringToFront();
			GridSelect.SendToBack();
			txtoutput.Text = "";
		}
		private void tabPage2_Click(object sender, EventArgs e)
		{
			pnlInsertControls.Controls.Clear();
			chkListBoxColumns.Items.Clear();
			txtoutput.BringToFront();
			GridSelect.SendToBack();
			txtoutput.Text = "";
		}

		private void tabPage3_Click(object sender, EventArgs e)
		{
			pnlInsertControls.Controls.Clear();
			chkListBoxColumns.Items.Clear();
			txtoutput.BringToFront();
			GridSelect.SendToBack();
			txtoutput.Text = "";
		}

		private void tabSqlScripts_Click(object sender, EventArgs e)
		{
			pnlInsertControls.Controls.Clear();
			chkListBoxColumns.Items.Clear();
			txtoutput.BringToFront();
			GridSelect.SendToBack();
			txtoutput.Text = "";
		}
		#endregion
		#endregion
	}
}
