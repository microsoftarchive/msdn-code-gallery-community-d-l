using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Synchronization;
using System.ServiceModel;
using WebSyncContract;
using System.ServiceModel.Channels;
using Microsoft.Synchronization.Data;
using System.IO;

namespace WebSyncContract
{
    public abstract class RelationalProviderProxy : KnowledgeSyncProvider, IDisposable
    {
        protected IRelationalSyncContract proxy;
        protected SyncIdFormatGroup idFormatGroup;
        protected string scopeName;
        protected DirectoryInfo localBatchingDirectory;
        protected bool disposed = false;

        //Represents the database connection string.
        //
        protected string connectionString;

        private string batchingDirectory = Environment.ExpandEnvironmentVariables("%TEMP%");

        public string BatchingDirectory
        {
            get { return batchingDirectory; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("value cannot be null or empty");
                }
                try
                {
                    Uri uri = new Uri(value);
                    if (!uri.IsFile || uri.IsUnc)
                    {
                        throw new ArgumentException("value must be a local directory");
                    }
                    batchingDirectory = value;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Invalid batching directory.", e);
                }
            }
        }

        public RelationalProviderProxy(string scopeName, string connectionString)
        {
            this.scopeName = scopeName;
            this.connectionString = connectionString;
            this.CreateProxy();            
            this.proxy.Initialize(scopeName, connectionString);
        }

        public override void BeginSession(SyncProviderPosition position, SyncSessionContext syncSessionContext)
        {
            this.proxy.BeginSession(position);
        }

        public override void EndSession(SyncSessionContext syncSessionContext)
        {
            proxy.EndSession();
            if (this.localBatchingDirectory != null)
            {
                this.localBatchingDirectory.Refresh();

                if (this.localBatchingDirectory.Exists)
                {
                    //Cleanup batching releated files from this session
                    this.localBatchingDirectory.Delete(true);
                }
            }          
        }

        public override ChangeBatch GetChangeBatch(uint batchSize, SyncKnowledge destinationKnowledge, out object changeDataRetriever)
        {
            GetChangesParameters changesWrapper = proxy.GetChanges(batchSize, destinationKnowledge);
            //Retrieve the ChangeDataRetriever and the ChangeBatch
            changeDataRetriever = changesWrapper.DataRetriever;

            DbSyncContext context = changeDataRetriever as DbSyncContext;
            //Check to see if the data is batched.
            if (context != null && context.IsDataBatched)
            {
                if (this.localBatchingDirectory == null)
                {
                    //Retrieve the remote peer id from the MadeWithKnowledge.ReplicaId. MadeWithKnowledge is the local knowledge of the peer 
                    //that is enumerating the changes.
                    string remotePeerId = context.MadeWithKnowledge.ReplicaId.ToString();

                    //Generate a unique Id for the directory.
                    //We use the peer id of the store enumerating the changes so that the local temp directory is same for a given source
                    //across sync sessions. This enables us to restart a failed sync by not downloading already received files.
                    string sessionDir = Path.Combine(this.batchingDirectory, "WebSync_" + remotePeerId);
                    this.localBatchingDirectory = new DirectoryInfo(sessionDir);
                    //Create the directory if it doesnt exist.
                    if (!this.localBatchingDirectory.Exists)
                    {
                        this.localBatchingDirectory.Create();
                    }
                }

                string localFileName = Path.Combine(this.localBatchingDirectory.FullName, context.BatchFileName);
                FileInfo localFileInfo = new FileInfo(localFileName);
                
                //Download the file only if doesnt exist                
                if (!localFileInfo.Exists)
                {
                    byte[] remoteFileContents = this.proxy.DownloadBatchFile(context.BatchFileName);
                    using (FileStream localFileStream = new FileStream(localFileName, FileMode.Create, FileAccess.Write))
                    {
                        localFileStream.Write(remoteFileContents, 0, remoteFileContents.Length);
                    }
                }
                //Set DbSyncContext.Batchfile name to the new local file name
                context.BatchFileName = localFileName;
            }

            return changesWrapper.ChangeBatch;
        }

        public override FullEnumerationChangeBatch GetFullEnumerationChangeBatch(uint batchSize, SyncId lowerEnumerationBound, SyncKnowledge knowledgeForDataRetrieval, out object changeDataRetriever)
        {
            throw new NotImplementedException();
        }

        public override void GetSyncBatchParameters(out uint batchSize, out SyncKnowledge knowledge)
        {
            SyncBatchParameters wrapper = proxy.GetKnowledge();
            batchSize = wrapper.BatchSize;
            knowledge = wrapper.DestinationKnowledge;
        }

        public override SyncIdFormatGroup IdFormats
        {
            get
            {
                if (idFormatGroup == null)
                {
                    idFormatGroup = new SyncIdFormatGroup();

                    //
                    // 1 byte change unit id (Harmonica default before flexible ids)
                    //
                    idFormatGroup.ChangeUnitIdFormat.IsVariableLength = false;
                    idFormatGroup.ChangeUnitIdFormat.Length = 1;

                    //
                    // Guid replica id
                    //
                    idFormatGroup.ReplicaIdFormat.IsVariableLength = false;
                    idFormatGroup.ReplicaIdFormat.Length = 16;


                    //
                    // Sync global id for item ids
                    //
                    idFormatGroup.ItemIdFormat.IsVariableLength = true;
                    idFormatGroup.ItemIdFormat.Length = 10 * 1024;
                }

                return idFormatGroup;
            }
        }

        public override void ProcessChangeBatch(ConflictResolutionPolicy resolutionPolicy, ChangeBatch sourceChanges, object changeDataRetriever, SyncCallbacks syncCallbacks, SyncSessionStatistics sessionStatistics)
        {
            DbSyncContext context = changeDataRetriever as DbSyncContext;
            if (context != null && context.IsDataBatched)
            {
                string fileName = new FileInfo(context.BatchFileName).Name;

                //Retrieve the remote peer id from the MadeWithKnowledge.ReplicaId. MadeWithKnowledge is the local knowledge of the peer 
                //that is enumerating the changes.
                string peerId = context.MadeWithKnowledge.ReplicaId.ToString();

                //Check to see if service already has this file
                if (!this.proxy.HasUploadedBatchFile(fileName, peerId))
                {
                    //Upload this file to remote service
                    FileStream stream = new FileStream(context.BatchFileName, FileMode.Open, FileAccess.Read);
                    byte[] contents = new byte[stream.Length];
                    using (stream)
                    {
                        stream.Read(contents, 0, contents.Length);
                    }
                    this.proxy.UploadBatchFile(fileName, contents, peerId);
                }

                context.BatchFileName = fileName;
            }
            
            SyncSessionStatistics stats = this.proxy.ApplyChanges(resolutionPolicy, sourceChanges, changeDataRetriever);
            sessionStatistics.ChangesApplied += stats.ChangesApplied;
            sessionStatistics.ChangesFailed += stats.ChangesFailed;

        }

        public override void ProcessFullEnumerationChangeBatch(ConflictResolutionPolicy resolutionPolicy, FullEnumerationChangeBatch sourceChanges, object changeDataRetriever, SyncCallbacks syncCallbacks, SyncSessionStatistics sessionStatistics)
        {
            throw new NotImplementedException();
        }

        protected abstract void CreateProxy();

        ~RelationalProviderProxy()
        {
            Dispose(false);
        }

        #region IDisposable Members

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (proxy != null)
                    {
                        CloseProxy();
                    }
                }

                disposed = true;
            }
        }

        /// <summary>
        ///  Clean up and close proxy.
        /// </summary>
        public virtual void CloseProxy()
        {
            if (proxy != null)
            {
                proxy.Cleanup();
                ICommunicationObject channel = proxy as ICommunicationObject;
                if (channel != null)
                {
                    try
                    {
                        channel.Close();
                    }
                    catch (TimeoutException)
                    {
                        channel.Abort();
                    }
                    catch (CommunicationException)
                    {
                        channel.Abort();
                    }
                }

                proxy = null;
            }
        }
        #endregion
    }
}
