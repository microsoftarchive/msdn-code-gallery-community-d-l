using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using System.IO;
using System.ServiceModel;

namespace WebSyncContract
{
    public abstract class RelationalWebSyncService: IRelationalSyncContract
    {
        protected bool isProxyToCompactDatabase;
        protected RelationalSyncProvider peerProvider;
        protected DirectoryInfo sessionBatchingDirectory = null;
        protected Dictionary<string, string> batchIdToFileMapper;
        int batchCount = 0;

        public void Initialize(string scopeName, string connectionString)
        {
            this.peerProvider = this.ConfigureProvider(scopeName, connectionString);
            this.batchIdToFileMapper = new Dictionary<string, string>();
        }

        public void Cleanup()
        {
            this.peerProvider = null;
            //Delete all file in the temp session directory
            if (sessionBatchingDirectory != null)
            {
                sessionBatchingDirectory.Refresh();

                if (sessionBatchingDirectory.Exists)
                {
                    try
                    {
                        sessionBatchingDirectory.Delete(true);
                    }
                    catch
                    {
                        //Ignore 
                    }
                }
            }
        }

        public void BeginSession(SyncProviderPosition position)
        {
            Log("*****************************************************************");
            Log("******************** New Sync Session ***************************");
            Log("*****************************************************************");
            Log("BeginSession: ScopeName: {0}, Position: {1}", this.peerProvider.ScopeName, position);
            //Clean the mapper for each session.
            this.batchIdToFileMapper = new Dictionary<string, string>();

            this.peerProvider.BeginSession(position, null/*SyncSessionContext*/);
            this.batchCount = 0;
        }

        public SyncBatchParameters GetKnowledge()
        {
            Log("GetSyncBatchParameters: {0}", this.peerProvider.Connection.ConnectionString);
            SyncBatchParameters destParameters = new SyncBatchParameters();
            this.peerProvider.GetSyncBatchParameters(out destParameters.BatchSize, out destParameters.DestinationKnowledge);
            return destParameters;
        }

        public GetChangesParameters GetChanges(uint batchSize, SyncKnowledge destinationKnowledge)
        {
            Log("GetChangeBatch: {0}", this.peerProvider.Connection.ConnectionString);
            GetChangesParameters changesWrapper = new GetChangesParameters();
            changesWrapper.ChangeBatch  = this.peerProvider.GetChangeBatch(batchSize, destinationKnowledge, out changesWrapper.DataRetriever);

            DbSyncContext context = changesWrapper.DataRetriever as DbSyncContext;
            //Check to see if data is batched
            if (context != null && context.IsDataBatched)
            {
                Log("GetChangeBatch: Data Batched. Current Batch #:{0}", ++this.batchCount);
                //Dont send the file location info. Just send the file name
                string fileName = new FileInfo(context.BatchFileName).Name;
                this.batchIdToFileMapper[fileName] = context.BatchFileName;
                context.BatchFileName = fileName;
            }
            return changesWrapper;
        }

        public SyncSessionStatistics ApplyChanges(ConflictResolutionPolicy resolutionPolicy, ChangeBatch sourceChanges, object changeData)
        {
            Log("ProcessChangeBatch: {0}", this.peerProvider.Connection.ConnectionString);

            DbSyncContext dataRetriever = changeData as DbSyncContext;

            if (dataRetriever != null && dataRetriever.IsDataBatched)
            {
                string remotePeerId = dataRetriever.MadeWithKnowledge.ReplicaId.ToString();
                //Data is batched. The client should have uploaded this file to us prior to calling ApplyChanges.
                //So look for it.
                //The Id would be the DbSyncContext.BatchFileName which is just the batch file name without the complete path
                string localBatchFileName = null;
                if (!this.batchIdToFileMapper.TryGetValue(dataRetriever.BatchFileName, out localBatchFileName))
                {
                    //Service has not received this file. Throw exception
                    throw new FaultException<WebSyncFaultException>(new WebSyncFaultException("No batch file uploaded for id " + dataRetriever.BatchFileName, null));
                }
                dataRetriever.BatchFileName = localBatchFileName;
            }

            SyncSessionStatistics sessionStatistics = new SyncSessionStatistics();
            this.peerProvider.ProcessChangeBatch(resolutionPolicy, sourceChanges, changeData, new SyncCallbacks(), sessionStatistics);
            return sessionStatistics;
        }

        public void EndSession()
        {
            Log("EndSession: {0}", this.peerProvider.Connection.ConnectionString);
            Log("*****************************************************************");
            Log("******************** End Sync Session ***************************");
            Log("*****************************************************************");
            this.peerProvider.EndSession(null);
            Log("");
        }

        /// <summary>
        /// Used by proxy to see if the batch file has already been uploaded. Optimizes by not resending batch files.
        /// NOTE: This method takes in a file name as an input parameter and hence is suseptible for name canonicalization
        /// attacks. This sample is meant to be a starting point in demonstrating how to transfer sync batch files and is
        /// not intended to be a secure way of doing the same. This SHOULD NOT be used as such in production environment
        /// without doing proper security analysis.
        /// 
        /// Please refer to the following two MSDN whitepapers for more information on guidelines for securing Web servies.
        /// 
        /// Design Guidelines for Secure Web Applications - http://msdn.microsoft.com/en-us/library/aa302420.aspx (Refer InputValidation section)
        /// Architecture and Design Review for Security - http://msdn.microsoft.com/en-us/library/aa302421.aspx (Refer InputValidation section)
        /// </summary>
        /// <param name="batchFileId"></param>
        /// <returns>bool</returns>
        public bool HasUploadedBatchFile(String batchFileId, string remotePeerId)
        {
            this.CheckAndCreateBatchingDirectory(remotePeerId);

            //The batchFileId is the fileName without the path information in it.
            FileInfo fileInfo = new FileInfo(Path.Combine(this.sessionBatchingDirectory.FullName, batchFileId));
            if (fileInfo.Exists && !this.batchIdToFileMapper.ContainsKey(batchFileId))
            {
                //If file exists but is not in the memory id to location mapper then add it to the mapping
                this.batchIdToFileMapper.Add(batchFileId, fileInfo.FullName);
            }
            //Check to see if the proxy has already uploaded this file to the service
            return fileInfo.Exists;
        }

        /// <summary>
        /// NOTE: This method takes in a file name as an input parameter and hence is suseptible for name canonicalization
        /// attacks. This sample is meant to be a starting point in demonstrating how to transfer sync batch files and is
        /// not intended to be a secure way of doing the same. This SHOULD NOT be used as such in production environment
        /// without doing proper security analysis.
        /// 
        /// Please refer to the following two MSDN whitepapers for more information on guidelines for securing Web servies.
        /// 
        /// Design Guidelines for Secure Web Applications - http://msdn.microsoft.com/en-us/library/aa302420.aspx (Refer InputValidation section)
        /// Architecture and Design Review for Security - http://msdn.microsoft.com/en-us/library/aa302421.aspx (Refer InputValidation section)
        /// </summary>
        /// <param name="batchFileId"></param>
        /// <param name="batchContents"></param>
        /// <param name="remotePeerId"></param>
        public void UploadBatchFile(string batchFileId, byte[] batchContents, string remotePeerId)
        {
            Log("UploadBatchFile: {0}", this.peerProvider.Connection.ConnectionString);
            try
            {
                if (HasUploadedBatchFile(batchFileId, remotePeerId))
                {
                    //Service has already received this file. So dont save it again.
                    return;
                }
                
                //Service hasnt seen the file yet so save it.
                String localFileLocation = Path.Combine(sessionBatchingDirectory.FullName, batchFileId);
                FileStream fs = new FileStream(localFileLocation, FileMode.Create, FileAccess.Write);
                using (fs)
                {
                        fs.Write(batchContents, 0, batchContents.Length);
                }
                //Save this Id to file location mapping in the mapper object
                this.batchIdToFileMapper[batchFileId] = localFileLocation;
            }
            catch (Exception e)
            {
                throw new FaultException<WebSyncFaultException>(new WebSyncFaultException("Unable to save batch file.", e));
            }
        }

        /// <summary>
        /// NOTE: This method takes in a file name as an input parameter and hence is suseptible for name canonicalization
        /// attacks. This sample is meant to be a starting point in demonstrating how to transfer sync batch files and is
        /// not intended to be a secure way of doing the same. This SHOULD NOT be used as such in production environment
        /// without doing proper security analysis.
        /// 
        /// Please refer to the following two MSDN whitepapers for more information on guidelines for securing Web servies.
        /// 
        /// Design Guidelines for Secure Web Applications - http://msdn.microsoft.com/en-us/library/aa302420.aspx (Refer InputValidation section)
        /// Architecture and Design Review for Security - http://msdn.microsoft.com/en-us/library/aa302421.aspx (Refer InputValidation section)
        /// </summary>
        /// <param name="batchFileId"></param>
        /// <returns></returns>
        public byte[] DownloadBatchFile(string batchFileId)
        {
            try
            {
                Log("DownloadBatchFile: {0}", this.peerProvider.Connection.ConnectionString);
                Stream localFileStream = null;

                string localBatchFileName = null;

                if (!this.batchIdToFileMapper.TryGetValue(batchFileId, out localBatchFileName))
                {
                    throw new FaultException<WebSyncFaultException>(new WebSyncFaultException("Unable to retrieve batch file for id." + batchFileId, null));
                }

                using (localFileStream = new FileStream(localBatchFileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] contents = new byte[localFileStream.Length];
                    localFileStream.Read(contents, 0, contents.Length);
                    return contents;
                }                
            }
            catch (Exception e)
            {
                throw new FaultException<WebSyncFaultException>(new WebSyncFaultException("Unable to read batch file for id " + batchFileId, e));
            }
        }

        protected void Log(string p, params object[] paramArgs)
        {
            Console.WriteLine(p, paramArgs);
        }

        //Utility functions that the sub classes need to implement.
        protected abstract RelationalSyncProvider ConfigureProvider(string scopeName, string hostName);


        private void CheckAndCreateBatchingDirectory(string remotePeerId)
        {
            //Check to see if we have temp directory for this session.
            if (sessionBatchingDirectory == null)
            {
                //Generate a unique Id for the directory
                //We use the peer id of the store enumerating the changes so that the local temp directory is same for a given source
                //across sync sessions. This enables us to restart a failed sync by not downloading already received files.
                string sessionDir = Path.Combine(this.peerProvider.BatchingDirectory, "WebSync_" + remotePeerId);
                sessionBatchingDirectory = new DirectoryInfo(sessionDir);
                //Create the directory if it doesnt exist.
                if (!sessionBatchingDirectory.Exists)
                {
                    sessionBatchingDirectory.Create();
                }
            }
        }
    }
}
