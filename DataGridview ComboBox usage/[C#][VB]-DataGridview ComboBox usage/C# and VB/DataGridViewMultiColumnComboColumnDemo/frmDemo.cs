/**************************************************************************************************
 * 
 * FILE NAME:
 *      frmDemo.cs
 * 
 * AUTHOR:
 *      Issahar Gourfinkel, 
 *      gurfi@barak-online.net
 *      This code is Completely free. I will be happy if it will help somebody.     
 * 
 * DESCRIPTION:
 *      Demonstrating the MultiColumnCombobox simulation for DataGridView cells controls.
 * 
 * 
 * 
 * DISCLAIMER OF WARRANTY:
 *      All of the code, information, instructions, and recommendations in this software component are 
 *      offered on a strictly "as is" basis. This material is offered as a free public resource, 
 *      without any warranty, expressed or implied.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataGridViewMultiColumnComboColumnDemo.DB;
using DataGridViewMultiColumnComboColumnDemo.DB.SampleDBDataSetTableAdapters;
using System.IO;

namespace DataGridViewMultiColumnComboColumnDemo
{
    public partial class frmDemo : Form
    {
        const string LogTable_LogMessageTypesRelation = "LogTable_LogMessageTypes";
        const string MDBConnFmt = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True";

        private SampleDBDataSet ds = new SampleDBDataSet();

        DataTable gridValuesList = new DataTable("GridValuesList");
        DataTable comboValuesList = new DataTable("ComboValuesList");
        public frmDemo()
        {
            InitializeComponent();
        }

        private void frmDemo_Load(object sender, EventArgs e)
        {
            RefreshData();

        }


        private void RefreshData()
        {
            LogTableTableAdapter logMsgAd = new LogTableTableAdapter();
            LogMessageTypesTableAdapter logMsgTypesAd = new LogMessageTypesTableAdapter();


            string dbPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DB\\SampleDB.mdb");


            logMsgAd.Connection.ConnectionString = string.Format(MDBConnFmt, dbPath);
            logMsgTypesAd.Connection.ConnectionString = string.Format(MDBConnFmt, dbPath);

            logMsgTypesAd.Fill(ds.LogMessageTypes);
            logMsgAd.Fill(ds.LogTable);

            dataGridView1.DataSource = ds;

            dataGridView1.DataMember = ds.LogTable.TableName;



            int position = dataGridView1.Columns.Count;
            if (dataGridView1.Columns.Contains(ds.LogTable.TypeColumn.ColumnName))
            {
                position = dataGridView1.Columns[ds.LogTable.TypeColumn.ColumnName].Index;

                //create the multicolumncombo column
                DataGridViewMultiColumnComboColumn newColumn 
                    = new DataGridViewMultiColumnComboColumn();
                //DataGridViewComboBoxColumn newColumn = new DataGridViewComboBoxColumn();

                newColumn.CellTemplate = new DataGridViewMultiColumnComboCell();
                //newColumn.CellTemplate = new DataGridViewComboBoxCell();
                newColumn.DataSource = ds.LogMessageTypes;
                newColumn.HeaderText = ds.LogTable.TypeColumn.ColumnName;
                newColumn.DataPropertyName = ds.LogTable.TypeColumn.ColumnName;
                newColumn.DisplayMember = ds.LogMessageTypes.TypeNameColumn.ColumnName;
                newColumn.ValueMember = ds.LogMessageTypes.TypeIdColumn.ColumnName;
                newColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                
                dataGridView1.Columns.Remove(ds.LogTable.TypeColumn.ColumnName);
                dataGridView1.Columns.Insert(position, newColumn);
                dataGridView1.Columns[position].Width = 300;

                //newColumn.Items.Clear();
                //foreach(SampleDBDataSet.LogTableRow row in ds.LogMessageTypes)
                //{
                //    newColumn.Items.Add(row);
                //}
            }


        }
    }
}