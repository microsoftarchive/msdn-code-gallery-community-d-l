//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Persistence worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Common
{
    #region Using references
    using System;
    using System.IO;
    using System.Data;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    using System.Transactions;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Data;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Common.Data;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.Common.Properties;
    #endregion

    #region StreamingMode definition
    /// <summary>
    /// Defines the type of buffer that will be used for streaming operations. Only FixedBuffer is supported in this version.
    /// </summary>
    public enum StreamingMode
    {
        /// <summary>
        /// Defines the fixed buffer type.
        /// </summary>
        FixedBuffer,
        
        /// <summary>
        /// Defines the elastic buffer type.
        /// </summary>
        ElasticBuffer
    }
    #endregion

    #region StreamingDataType definition
    /// <summary>
    /// Defines the type of data that will be used for streaming operations. Only Raw is supported in this version.
    /// </summary>
    public enum StreamingDataType
    {
        /// <summary>
        /// Defines the XML data type for streaming.
        /// </summary>
        Xml,

        /// <summary>
        /// Defines the raw data type for streaming.
        /// </summary>
        Raw
    }
    #endregion

    /// <summary>
    /// Implements a persistence queue that uses a SQL Azure database as a data store.
    /// </summary>
    public class SqlAzurePersistenceQueue : IPersistenceQueue
    {
        #region Private members
        private const int DefaultInitialBufferSize = 8040 * 100;
        private const int DefaultMaxBufferSize = DefaultInitialBufferSize * 10;

        private bool disposed;
        private string dbConnectionString;
        private readonly StreamingMode streamingMode = StreamingMode.FixedBuffer;
        private readonly StreamingDataType streamingDataType = StreamingDataType.Raw;
        private readonly int initialBufferSize = DefaultInitialBufferSize, maxBufferSize = DefaultMaxBufferSize;
        private readonly RetryPolicy connectionRetryPolicy, commandRetryPolicy;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SQL Azure database-based persistence queue using default settings.
        /// </summary>
        public SqlAzurePersistenceQueue() : this(StreamingMode.FixedBuffer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SQL Azure database-based persistence queue using the specified streaming mode.
        /// </summary>
        /// <param name="streamingMode">The type of buffer that will be used for streaming operations.</param>
        public SqlAzurePersistenceQueue(StreamingMode streamingMode) : this(streamingMode, StreamingDataType.Raw)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SQL Azure database-based persistence queue using the specified streaming mode and data type.
        /// </summary>
        /// <param name="streamingMode">The type of buffer that will be used for streaming operations.</param>
        /// <param name="streamingDataType">The type of data that will be used for streaming operations.</param>
        public SqlAzurePersistenceQueue(StreamingMode streamingMode, StreamingDataType streamingDataType) : this(streamingMode, streamingDataType, DefaultInitialBufferSize, DefaultMaxBufferSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SQL Azure database-based persistence queue using the specified streaming mode, data type and buffer settings.
        /// </summary>
        /// <param name="streamingMode">The type of buffer that will be used for streaming operations.</param>
        /// <param name="streamingDataType">The type of data that will be used for streaming operations.</param>
        /// <param name="initialBufferSize">The initial size of the buffer where data is being collected before flushed into a SQL Azure database.</param>
        /// <param name="maxBufferSize">The maximum allowed size of the data buffer.</param>
        public SqlAzurePersistenceQueue(StreamingMode streamingMode, StreamingDataType streamingDataType, int initialBufferSize, int maxBufferSize)
        {
            this.streamingMode = streamingMode;
            this.streamingDataType = streamingDataType;
            this.initialBufferSize = initialBufferSize;
            this.maxBufferSize = maxBufferSize;
            this.connectionRetryPolicy = RetryPolicyFactory.GetDefaultSqlConnectionRetryPolicy();
            this.commandRetryPolicy = RetryPolicyFactory.GetDefaultSqlCommandRetryPolicy();
        }
        #endregion

        #region Public members
        /// <summary>
        /// Gets the type of buffer that is being used for streaming operations.
        /// </summary>
        public StreamingMode StreamingMode
        {
            get { return this.streamingMode; }
        }

        /// <summary>
        /// Gets the type of data that is being used for streaming operations.
        /// </summary>
        public StreamingDataType StreamingDataType
        {
            get { return this.streamingDataType; }
        }
        #endregion

        #region IPersistenceQueue implementation
        /// <summary>
        /// Opens the specified persistence queue.
        /// </summary>
        /// <param name="queueName">The name of the persistence queue that needs to be opened.</param>
        public void Open(string queueName)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");

            var callToken = TraceManager.DataAccessComponent.TraceIn(queueName);

            this.dbConnectionString = ApplicationConfiguration.Current.Databases.ConnectionStrings[queueName];

            if (!String.IsNullOrEmpty(dbConnectionString))
            {
                // Will specifically avoid opening a SQL Azure connection at this point as pooled connections will be relied upon.
            }
            else
            {
                throw new CloudApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.DatabaseConnectionStringNotFound, queueName));
            }

            TraceManager.DataAccessComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Persists the specified stream of data in the queue.
        /// </summary>
        /// <param name="data">The stream containing the data to be persisted.</param>
        /// <returns>A data transfer object carrying the details of the persisted queue item.</returns>
        public PersistenceQueueItemInfo Enqueue(Stream data)
        {
            Guard.ArgumentNotNull(data, "data");
            Guard.ArgumentNotNullOrEmptyString(this.dbConnectionString, "dbConnectionString");

            var callToken = TraceManager.DataAccessComponent.TraceIn(StreamingMode, StreamingDataType);
            var scopeStartEnqueueMain = TraceManager.DataAccessComponent.TraceStartScope(Resources.ScopeSqlAzurePersistenceQueueEnqueueMain, callToken);

            try
            {
                PersistenceQueueItemInfo queueItemInfo = null;
                Guid txGuid = default(Guid);

                using (var txScope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.MaxValue))
                using (var dbConnection = new ReliableSqlConnection(this.dbConnectionString, this.connectionRetryPolicy, this.commandRetryPolicy))
                {
                    if (StreamingDataType == StreamingDataType.Raw)
                    {
                        var scopeStartExecuteQuery = TraceManager.DataAccessComponent.TraceStartScope(Resources.ScopeSqlAzurePersistenceQueueExecuteCommand, callToken);

                        using (IDbCommand newItemCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateNewCommand(dbConnection))
                        {
                            TraceManager.DataAccessComponent.TraceCommand(newItemCommand);

                            txGuid = dbConnection.ExecuteCommand<Guid>(newItemCommand);

                            using (IDbCommand readDataCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateQueueItemReadCommand(dbConnection, txGuid))
                            using (IDbCommand writeDataCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateQueueItemWriteCommand(dbConnection, txGuid))
                            using (IDbCommand getDataSizeCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateQueueItemGetSizeCommand(dbConnection, txGuid))
                            using (SqlStream sqlStream = new SqlStream(dbConnection, readDataCommand as SqlCommand, writeDataCommand as SqlCommand, getDataSizeCommand as SqlCommand))
                            {
                                BinaryReader dataReader = new BinaryReader(data);

                                byte[] buffer = new byte[this.initialBufferSize];
                                int bytesRead = 0;

                                do
                                {
                                    var scopeStartBufferRead = TraceManager.DataAccessComponent.TraceStartScope(Resources.ScopeSqlAzurePersistenceQueueBufferedReadBytes, callToken);

                                    bytesRead = dataReader.ReadBuffered(buffer, 0, this.initialBufferSize);

                                    TraceManager.DataAccessComponent.TraceEndScope(Resources.ScopeSqlAzurePersistenceQueueBufferedReadBytes, scopeStartBufferRead, callToken);

                                    if (bytesRead > 0)
                                    {
                                        TraceManager.DataAccessComponent.TraceInfo(TraceLogMessages.SqlStreamWriteOperationDetails, bytesRead);
                                        var scopeStartSqlWriteData = TraceManager.DataAccessComponent.TraceStartScope(Resources.ScopeSqlAzurePersistenceQueueWriteData, callToken);

                                        sqlStream.Write(buffer, 0, bytesRead);

                                        TraceManager.DataAccessComponent.TraceEndScope(Resources.ScopeSqlAzurePersistenceQueueWriteData, scopeStartSqlWriteData, callToken);
                                    }
                                }
                                while (bytesRead > 0);
                            }
                        }

                        using (IDbCommand enqueueCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateEnqueueCommand(dbConnection, txGuid))
                        {
                            TraceManager.DataAccessComponent.TraceCommand(enqueueCommand);

                            dbConnection.ExecuteCommand(enqueueCommand);

                            SqlCommandView<EnqueueCommandInspector> enqueueCommandView = new SqlCommandView<EnqueueCommandInspector>(enqueueCommand);
                            queueItemInfo = new PersistenceQueueItemInfo(txGuid, enqueueCommandView.Inspector.QueueItemSize, enqueueCommandView.Inspector.QueueItemType);
                        }

                        txScope.Complete();

                        TraceManager.DataAccessComponent.TraceEndScope(Resources.ScopeSqlAzurePersistenceQueueExecuteCommand, scopeStartExecuteQuery, callToken);
                    }

                    return queueItemInfo;
                }
            }
            catch (Exception ex)
            {
                TraceManager.DataAccessComponent.TraceError(ex, callToken);
                throw;
            }
            finally
            {
                TraceManager.DataAccessComponent.TraceEndScope(Resources.ScopeSqlAzurePersistenceQueueEnqueueMain, scopeStartEnqueueMain, callToken);
                TraceManager.DataAccessComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Retrieves data from the specified queue item stored in the persistence queue.
        /// </summary>
        /// <param name="queueItemId">The unique identity of the item.</param>
        /// <param name="headerXPath">The optional set of XPath expressions defining a header portion of the queue data.</param>
        /// <param name="bodyXPath">The optional set of XPath expressions defining a body portion of the queue data.</param>
        /// <param name="footerXPath">The optional set of XPath expressions defining a footer portion of the queue data.</param>
        /// <param name="nsManager">The optional XML namespace manager that will be used for XML namespace resolution.</param>
        /// <returns>An instance of the XML reader that provides non-cached, forward-only access to queue item data.</returns>
        public XmlReader DequeueXmlData(Guid queueItemId, IEnumerable<string> headerXPath, IEnumerable<string> bodyXPath, IEnumerable<string> footerXPath, XmlNamespaceManager nsManager)
        {
            var callToken = TraceManager.DataAccessComponent.TraceIn(queueItemId.ToString());
            var scopeStartMain = TraceManager.DataAccessComponent.TraceStartScope(Resources.ScopeSqlAzurePersistenceQueueDequeueXmlDataMain, callToken);
            
            ReliableSqlConnection dbConnection = null;
            bool leaveConnectionOpen = false;
            
            try
            {
                // SQL connection is intentionally left non-disposed here. It will be disposed along with XmlReader which this method returns (if at all).
                // This behavior is enforced through specifying CommandBehavior.CloseConnection when invoking the ExecuteCommand method.
                dbConnection = new ReliableSqlConnection(this.dbConnectionString, this.connectionRetryPolicy, this.commandRetryPolicy);

                using (IDbCommand dequeueCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateDequeueXmlDataCommand(dbConnection, queueItemId, headerXPath != null ? headerXPath.ToArray<string>() : null, bodyXPath != null ? bodyXPath.ToArray<string>() : null, footerXPath != null ? footerXPath.ToArray<string>() : null, nsManager))
                {
                    TraceManager.DataAccessComponent.TraceCommand(dequeueCommand);

                    XmlReader xmlDataReader = dbConnection.ExecuteCommand<XmlReader>(dequeueCommand, CommandBehavior.CloseConnection);

                    if (xmlDataReader != null && xmlDataReader.Read())
                    {
                        XmlReaderSettings readerSettings = new XmlReaderSettings() { CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None, ConformanceLevel = ConformanceLevel.Auto };
                        XmlReader nonValidatingReader = XmlReader.Create(xmlDataReader, readerSettings);
                        
                        leaveConnectionOpen = true;
                        return nonValidatingReader;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceManager.DataAccessComponent.TraceError(ex, callToken);
            }
            finally
            {
                if (dbConnection != null && !leaveConnectionOpen)
                {
                    dbConnection.Dispose();
                }

                TraceManager.DataAccessComponent.TraceEndScope(Resources.ScopeSqlAzurePersistenceQueueDequeueXmlDataMain, scopeStartMain, callToken);
                TraceManager.DataAccessComponent.TraceOut(callToken);
            }

            return null;
        }

        /// <summary>
        /// Performs a query against the XML data stored in the queue item.
        /// </summary>
        /// <param name="queueItemId">The unique identity of the queue item.</param>
        /// <param name="xPathCollection">One or more XPath expressions which will be invoked against the queue item's XML data.</param>
        /// <param name="nsManager">The XML namespace manager that will be used for XML namespace resolution.</param>
        /// <returns>An instance of the XML reader that provides non-cached, forward-only access to queue item data.</returns>
        public XmlReader QueryXmlData(Guid queueItemId, IEnumerable<string> xPathCollection, XmlNamespaceManager nsManager)
        {
            var callToken = TraceManager.DataAccessComponent.TraceIn(queueItemId.ToString());
            var scopeStartMain = TraceManager.DataAccessComponent.TraceStartScope(Resources.ScopeSqlAzurePersistenceQueueQueryXmlDataMain, callToken);

            ReliableSqlConnection dbConnection = null;
            bool leaveConnectionOpen = false;

            try
            {
                // SQL connection is intentionally left non-disposed here. It will be disposed along with XmlReader which this method returns (if at all).
                // This behavior is enforced through specifying CommandBehavior.CloseConnection when invoking the ExecuteCommand method.
                dbConnection = new ReliableSqlConnection(this.dbConnectionString, this.connectionRetryPolicy, this.commandRetryPolicy);

                using (IDbCommand queryCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateQueryXmlDataCommand(dbConnection, queueItemId, xPathCollection != null ? xPathCollection.ToArray<string>() : null, nsManager))
                {
                    TraceManager.DataAccessComponent.TraceCommand(queryCommand);

                    XmlReader xmlDataReader = dbConnection.ExecuteCommand<XmlReader>(queryCommand, CommandBehavior.CloseConnection);

                    if (xmlDataReader != null && xmlDataReader.Read())
                    {
                        leaveConnectionOpen = true;
                        return xmlDataReader;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceManager.DataAccessComponent.TraceError(ex, callToken);
            }
            finally
            {
                if (dbConnection != null && !leaveConnectionOpen)
                {
                    dbConnection.Dispose();
                }

                TraceManager.DataAccessComponent.TraceEndScope(Resources.ScopeSqlAzurePersistenceQueueQueryXmlDataMain, scopeStartMain, callToken);
                TraceManager.DataAccessComponent.TraceOut(callToken);
            }

            return null;
        }

        /// <summary>
        /// Removes the specified queue item from the persistence queue.
        /// </summary>
        /// <param name="queueItemId">The unique identity of the queue item.</param>
        /// <returns>A flag indicating whether or not the queue item has been actually deleted.</returns>
        public bool Remove(Guid queueItemId)
        {
            var callToken = TraceManager.DataAccessComponent.TraceIn(queueItemId.ToString());

            try
            {
                using (var dbConnection = new ReliableSqlConnection(this.dbConnectionString, this.connectionRetryPolicy, this.commandRetryPolicy))
                using (var removeCommand = CustomSqlCommandFactory.SqlAzurePersistenceQueue.CreateRemoveCommand(dbConnection, queueItemId))
                {
                    TraceManager.DataAccessComponent.TraceCommand(removeCommand);

                    int recordsAffected = dbConnection.ExecuteCommand<int>(removeCommand);

                    return recordsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                TraceManager.DataAccessComponent.TraceError(ex, callToken);
                return false;
            }
            finally
            {
                TraceManager.DataAccessComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Closes the currently open persistence queue.
        /// </summary>
        public void Close()
        {
            var callToken = TraceManager.DataAccessComponent.TraceIn();

            TraceManager.DataAccessComponent.TraceOut(callToken);
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A flag indicating that managed resources must be released.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                Close();
                disposed = true;
            }
        }
        #endregion
    }
}
