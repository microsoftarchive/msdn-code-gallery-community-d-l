using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace SyncApplication
{
    /// <summary>
    /// Static class holding some const strings
    /// </summary>
    public static class SyncUtils
    {
        public static string ScopeName = "sales";
        public static string[] SyncAdapterTables = new string[] { "orders", "order_details" };
        public static string[] SyncAdapterTablePrimaryKeys = new string[] { "order_id", "order_Details_id" };
        public static int TombstoneAgingInHours = 10;
    }

    /// <summary>
    /// Enum that denotes what mode a client is added to the gui
    /// </summary>
    public enum CEDatabaseCreationMode
    {
        FullInitialization,
        SnapshotInitialization,
    }

    /// <summary>
    /// Utility class that holds information about a single CE client database
    /// </summary>
    public class CEDatabase
    {
        string dbName;
        SqlCeConnection connection;

        public string Name
        {
            get { return dbName; }
            set { dbName = value; }
        }
        string dbLocation;

        public string Location
        {
            get { return dbLocation; }
            set { dbLocation = value; }
        }
        CEDatabaseCreationMode creationMode;

        public CEDatabaseCreationMode CreationMode
        {
            get { return creationMode; }
            set { creationMode = value; }
        }

        public SqlCeConnection Connection
        {
            get 
            {
                if (connection == null)
                {
                    connection = new SqlCeConnection("Data Source=\"" + dbLocation + "\"");
                }
                return connection;
            }
        }
    }
}
