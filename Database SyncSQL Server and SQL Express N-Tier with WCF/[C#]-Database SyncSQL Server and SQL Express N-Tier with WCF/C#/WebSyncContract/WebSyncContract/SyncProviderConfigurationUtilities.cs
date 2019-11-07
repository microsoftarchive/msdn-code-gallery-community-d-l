using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceModel;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace WebSyncContract
{
    public class SyncProviderConfigurationUtilities
    {
        public static SqlSyncProvider ConfigureSqlSyncProvider(string scopeName)
        {
            SqlSyncProvider provider = new SqlSyncProvider();
            provider.ScopeName = scopeName;

            //Service should know list of adapters for given scope name.
            //Sample only shows for 'Sales' scope
            switch (scopeName.ToLower())
            {
                case "sales":

                    break;
                default:
                    throw new FaultException<WebSyncFaultException>(new WebSyncFaultException("Invalid SQL Scope name", null));
            }

            return provider;
        }
    }
}
