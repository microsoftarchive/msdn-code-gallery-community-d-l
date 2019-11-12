using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using CommonUtils;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace WebSyncContract
{
    public class ServerSynchronizationHelper
    {

        /// <summary>
        /// Configure the SqlSyncprovider.  Note that this method assumes you have a direct conection
        /// to the server as this is more of a design time use case vs. runtime use case.  We think
        /// of provisioning the server as something that occurs before an application is deployed whereas
        /// provisioning the client is somethng that happens during runtime (on intitial sync) after the 
        /// application is deployed.
        ///  
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public SqlSyncProvider ConfigureSqlSyncProvider(string scopeName, string connectionString)
        {

            SqlSyncProvider provider = new SqlSyncProvider();
            provider.ScopeName = scopeName;
            provider.Connection = new SqlConnection(connectionString);

            return provider;
        }        
    }
}
