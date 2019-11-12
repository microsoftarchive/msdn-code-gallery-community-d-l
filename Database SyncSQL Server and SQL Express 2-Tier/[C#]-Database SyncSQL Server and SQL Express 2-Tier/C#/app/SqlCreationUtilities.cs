using System.Data.SqlClient;

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
        public static string PeerNamePrefix = "Peer";
        public static string FirstPeerDBName = "peer1";
        public static string FirstPeerName = "Peer1";

        public static string GenerateSqlConnectionString(string hostName, string databaseName, string userName, string password, bool useTrustConnection)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = hostName;
            builder.InitialCatalog = databaseName;
            builder.IntegratedSecurity = useTrustConnection;
            if (!useTrustConnection)
            {
                builder.UserID = userName;
                builder.Password = password;
            }

            builder.ConnectTimeout = 1;
            return builder.ConnectionString;
        }
    }

    /// <summary>
    /// Enum that denotes what mode a client is added to the gui
    /// </summary>
    public enum SqlDatabaseCreationMode
    {
        FullInitialization,
        SnapshotInitialization,
    }

    /// <summary>
    /// Utility class contains information for a SQL Server database peer.
    /// </summary>
    public class SqlDatabase
    {
        string name;
        string serverName;
        string dbName;
        string connectionStr;
        string masterConnectionStr;
        SqlConnection connection = null;
        SqlConnection masterConnection = null;

        /// <summary>
        ///  Name of the Sync Peer 
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        ///  Name of the server.
        /// </summary>
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        /// <summary>
        ///  Name of the SQL Server database.
        /// </summary>
        public string DBName
        {
            get { return dbName; }
            set { dbName = value; }
        }

        /// <summary>
        /// Connection string to the peer SQL Server database.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return connectionStr;
            }
            set
            {
                connectionStr = value;
            }
        }

        /// <summary>
        /// Connection string to the master database of the peer SQL server.
        /// </summary>
        public string MasterConnectionString
        {
            get
            {
                return masterConnectionStr;
            }
            set
            {
                masterConnectionStr = value;
            }
        }

        /// <summary>
        ///  a SqlConnection instance of the peer SQL Server database.
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connectionStr);
                }
                return connection;
            }
        }

        /// <summary>
        ///  A SqlConnection instance of the master database of the peer SQL Server.
        /// </summary>
        public SqlConnection MasterConnection
        {
            get
            {
                if (masterConnection == null)
                {
                    masterConnection = new SqlConnection(masterConnectionStr);
                }
                return masterConnection;
            }
        }
    }
}
