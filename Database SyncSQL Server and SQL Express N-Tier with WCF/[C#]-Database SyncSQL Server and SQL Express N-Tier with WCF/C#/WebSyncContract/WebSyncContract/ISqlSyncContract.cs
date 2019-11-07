using System.Runtime.Serialization;
using System.ServiceModel;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;

namespace WebSyncContract
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ISqlSyncContract : IRelationalSyncContract
    {
        [OperationContract]
        [FaultContract(typeof(WebSyncFaultException))]
        void CreateScopeDescription(DbSyncScopeDescription scopeDescription);

        [OperationContract]
        [FaultContract(typeof(WebSyncFaultException))]
        DbSyncScopeDescription GetScopeDescription();

        [OperationContract]
        [FaultContract(typeof(WebSyncFaultException))]
        bool NeedsScope();        
    }
}
