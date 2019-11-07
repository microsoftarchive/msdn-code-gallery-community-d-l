using System;
using System.Collections.Generic;

using System.Text;
using System.ServiceModel;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization;
using System.Runtime.Serialization;
using System.Data;
using System.IO;

namespace WebSyncContract
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    [ServiceKnownType(typeof(SyncIdFormatGroup))]
    [ServiceKnownType(typeof(DbSyncContext))]
    [ServiceKnownType(typeof(SyncSchema))]
    [ServiceKnownType(typeof(WebSyncFaultException))]
    [ServiceKnownType(typeof(SyncBatchParameters))]
    [ServiceKnownType(typeof(GetChangesParameters))]
    public interface IRelationalSyncContract
    {
        [OperationContract(IsInitiating=true)]
        void Initialize(string scopeName, string hostName);

        [OperationContract]
        void BeginSession(SyncProviderPosition position);

        [OperationContract]
        SyncBatchParameters GetKnowledge();

        [OperationContract]
        GetChangesParameters GetChanges(uint batchSize, SyncKnowledge destinationKnowledge);

        [OperationContract]
        SyncSessionStatistics ApplyChanges(ConflictResolutionPolicy resolutionPolicy, ChangeBatch sourceChanges, object changeData);

        [OperationContract]
        bool HasUploadedBatchFile(string batchFileid, string remotePeerId);

        [OperationContract]
        void UploadBatchFile(string batchFileid, byte[] batchFile, string remotePeerId);

        [OperationContract]
        byte[] DownloadBatchFile(string batchFileId);

        [OperationContract]
        void EndSession();

        [OperationContract(IsTerminating= true)]
        void Cleanup();
    }

    [DataContract]
    public class SyncBatchParameters
    {
        [DataMember]
        public SyncKnowledge DestinationKnowledge;

        [DataMember]
        public uint BatchSize;
    }

    [DataContract]
    [KnownType(typeof(DataSet))]
    public class GetChangesParameters
    {
        [DataMember]
        public object DataRetriever;

        [DataMember]
        public ChangeBatch ChangeBatch;
    }
}
