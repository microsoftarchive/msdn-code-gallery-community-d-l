using System;
using System.Collections.Generic;
using System.Text;
using WebSyncContract;
using Microsoft.Synchronization;
using System.ServiceModel;
using Microsoft.Synchronization.Data;
using CommonUtils;

namespace WebSyncContract
{
    public class SqlSyncProviderProxy : RelationalProviderProxy
    {
        ISqlSyncContract dbProxy;
        public SqlSyncProviderProxy(string scopeName, string connectionString): base(scopeName, connectionString)
        { }

        protected override void CreateProxy()
        {
            WSHttpBinding binding = new WSHttpBinding();
            binding.ReaderQuotas.MaxArrayLength = 10485760;
            binding.MaxReceivedMessageSize = 10485760;
            ChannelFactory<ISqlSyncContract> factory = new ChannelFactory<ISqlSyncContract>(binding, new EndpointAddress(SyncUtils.SqlSyncServiceUri));
            base.proxy = factory.CreateChannel();
            this.dbProxy = base.proxy as ISqlSyncContract;
        }

        public void CreateScopeDescription(DbSyncScopeDescription scopeDescription)
        {
            this.dbProxy.CreateScopeDescription(scopeDescription);
        }

        public DbSyncScopeDescription GetScopeDescription()
        {
            return this.dbProxy.GetScopeDescription();
        }        

        public bool NeedsScope()
        {
            return this.dbProxy.NeedsScope();
        }
    }
}
