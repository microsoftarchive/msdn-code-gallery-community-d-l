using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using Microsoft.Synchronization.Data;

namespace SyncApplication
{
    /// <summary>
    /// Derived DbSyncProvider for Oracle.
    /// </summary>
    public class OracleDbSyncProvider : DbSyncProvider
    {
        public OracleDbSyncProvider()
        {
            // We need to modify this particular column name because the default is longer than Oracle allows.
            this.ScopeForgottenKnowledgeColName = "scope_forgotten_knowledge";
        }

        /// <summary>
        /// The IsolationLevel is ReadCommitted, however executing "set transaction read only" guarantees transaction-level
        /// read consistency. 
        /// </summary>
        /// <returns></returns>
        protected override IDbTransaction CreateEnumerationTransaction()
        {
            OracleTransaction trans = (OracleTransaction)this.Connection.BeginTransaction();            
            new OracleCommand("set transaction read only", (OracleConnection)this.Connection, trans).ExecuteNonQuery();
            return trans; 
        }
    }
}
