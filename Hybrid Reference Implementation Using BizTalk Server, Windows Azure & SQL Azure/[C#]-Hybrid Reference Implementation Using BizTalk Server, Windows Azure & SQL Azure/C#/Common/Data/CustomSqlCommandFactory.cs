//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Common.Data
{
    #region Using references
    using System;
    using System.Xml;
    using System.Data;
    using System.Data.Common;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Globalization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Data;
    using Contoso.Cloud.Integration.Common.Properties;
    #endregion

    /// <summary>
    /// Provides factory methods for instantiating application-specific SQL commands.
    /// </summary>
    public static class CustomSqlCommandFactory
    {
        #region SqlAzurePersistenceQueue commands
        /// <summary>
        /// Provides factory methods for instantiating SQL commands related to operations with the SQL Azure-based Persistence Queue database.
        /// </summary>
        public struct SqlAzurePersistenceQueue
        {
            #region Public methods
            /// <summary>
            /// Returns a SQL command describing the database operation for creating a new item in the Persistence Queue database.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateNewCommand(IDbConnection connection)
            {
                return SqlCommandFactory.CreateCommand(connection, SqlCommandResources.SqlAzurePersistenceQueueNew);
            }

            /// <summary>
            /// Returns a SQL command describing the database operation for adding a queue item with the specified unique ID.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <param name="itemId">The unique ID of the queue item.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateEnqueueCommand(IDbConnection connection, Guid itemId)
            {
                IDbCommand command = SqlCommandFactory.CreateCommand(connection, SqlCommandResources.SqlAzurePersistenceQueueEnqueue);

                command.Parameters.Add(SqlParameterUtility.CreateParameter(SqlObjectResources.ColumnQueueItemID, SqlDbType.UniqueIdentifier, itemId));
                command.Parameters.Add(SqlParameterUtility.CreateOutputParameter(SqlObjectResources.ColumnQueueItemSize, SqlDbType.BigInt));
                command.Parameters.Add(SqlParameterUtility.CreateOutputParameter(SqlObjectResources.ColumnQueueItemType, SqlDbType.VarChar, 255));

                return command;
            }

            /// <summary>
            /// Returns a SQL command describing the database operation for removing a queue item from the Persistence Queue database.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <param name="itemId">The unique ID of the queue item.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateRemoveCommand(IDbConnection connection, Guid itemId)
            {
                IDbCommand command = SqlCommandFactory.CreateCommand(connection, SqlCommandResources.SqlAzurePersistenceQueueRemove);

                command.Parameters.Add(SqlParameterUtility.CreateParameter(SqlObjectResources.ColumnQueueItemID, SqlDbType.UniqueIdentifier, itemId));

                return command;
            }

            /// <summary>
            /// Returns a SQL command describing the database operation for reading the queue item data from the Persistence Queue database.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <param name="itemId">The unique ID of the queue item.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateQueueItemReadCommand(IDbConnection connection, Guid itemId)
            {
                return SqlCommandFactory.CreateSqlStreamReadCommand(connection, SqlObjectResources.SchemaUserApplication, SqlObjectResources.TablePersistenceQueue, SqlObjectResources.ColumnQueueItemDataRaw, SqlObjectResources.ColumnQueueItemID, SqlDbType.UniqueIdentifier, itemId);
            }

            /// <summary>
            /// Returns a SQL command describing the database operation for writing data into the specified queue item in the Persistence Queue database.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <param name="itemId">The unique ID of the queue item.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateQueueItemWriteCommand(IDbConnection connection, Guid itemId)
            {
                return SqlCommandFactory.CreateSqlStreamWriteCommand(connection, SqlObjectResources.SchemaUserApplication, SqlObjectResources.TablePersistenceQueue, SqlObjectResources.ColumnQueueItemDataRaw, SqlObjectResources.ColumnQueueItemID, SqlDbType.UniqueIdentifier, itemId);
            }

            /// <summary>
            /// Returns a SQL command describing the database operation for returning data size of the specified queue item in the Persistence Queue database.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <param name="itemId">The unique ID of the queue item.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateQueueItemGetSizeCommand(IDbConnection connection, Guid itemId)
            {
                return SqlCommandFactory.CreateSqlStreamGetSizeCommand(connection, SqlObjectResources.SchemaUserApplication, SqlObjectResources.TablePersistenceQueue, SqlObjectResources.ColumnQueueItemDataRaw, SqlObjectResources.ColumnQueueItemID, SqlDbType.UniqueIdentifier, itemId);
            }

            /// <summary>
            /// Returns a SQL command describing the database operation for retrieving XML data from the specified queue item in the Persistence Queue database.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <param name="itemId">The unique ID of the queue item.</param>
            /// <param name="headerXPath">A collection of XPath expressions referencing the header part in the XML payload associated with the queue item.</param>
            /// <param name="bodyXPath">A collection of XPath expressions referencing the body part in the XML payload associated with the queue item.</param>
            /// <param name="footerXPath">A collection of XPath expressions referencing the footer part in the XML payload associated with the queue item.</param>
            /// <param name="nsManager">The <see cref="System.Xml.XmlNamespaceManager"/> object providing the mechanism for resolving namespace prefixes to their respective namespaces.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateDequeueXmlDataCommand(IDbConnection connection, Guid itemId, string[] headerXPath, string[] bodyXPath, string[] footerXPath, XmlNamespaceManager nsManager)
            {
                Guard.ArgumentNotNull(connection, "connection");

                IDbCommand command = SqlCommandFactory.CreateCommand(connection, SqlCommandResources.SqlAzurePersistenceQueueDequeueXmlData);

                command.Parameters.Add(SqlParameterUtility.CreateParameter(SqlObjectResources.ColumnQueueItemID, SqlDbType.UniqueIdentifier, itemId));

                for (int i = 0; headerXPath != null && headerXPath.Length > 0 && i < headerXPath.Length; i++)
                {
                    command.Parameters.Add(SqlParameterUtility.CreateParameter(String.Format(CultureInfo.CurrentCulture, SqlObjectResources.CommandParamTemplateHeaderXPath, i + 1), SqlDbType.VarChar, headerXPath[i]));
                }

                for (int i = 0; bodyXPath != null && bodyXPath.Length > 0 && i < bodyXPath.Length; i++)
                {
                    command.Parameters.Add(SqlParameterUtility.CreateParameter(String.Format(CultureInfo.CurrentCulture, SqlObjectResources.CommandParamTemplateBodyXPath, i + 1), SqlDbType.VarChar, bodyXPath[i]));
                }

                for (int i = 0; footerXPath != null && footerXPath.Length > 0 && i < footerXPath.Length; i++)
                {
                    command.Parameters.Add(SqlParameterUtility.CreateParameter(String.Format(CultureInfo.CurrentCulture, SqlObjectResources.CommandParamTemplateFooterXPath, i + 1), SqlDbType.VarChar, footerXPath[i]));
                }

                AddNamespaces(command, nsManager);

                return command;
            }

            /// <summary>
            /// Returns a SQL command describing the database operation for applying XPath expressions against the XML queue item data in the Persistence Queue database.
            /// </summary>
            /// <param name="connection">The database connection object to be associated with the new command.</param>
            /// <param name="itemId">The unique ID of the queue item.</param>
            /// <param name="xPathCollection">A collection of XPath expressions that will be applied against the XML payload associated with the queue item.</param>
            /// <param name="nsManager">The <see cref="System.Xml.XmlNamespaceManager"/> object providing the mechanism for resolving namespace prefixes to their respective namespaces.</param>
            /// <returns>A new SQL command initialized with the respective command text, parameters and their initial values.</returns>
            public static IDbCommand CreateQueryXmlDataCommand(IDbConnection connection, Guid itemId, string[] xPathCollection, XmlNamespaceManager nsManager)
            {
                Guard.ArgumentNotNull(connection, "connection");

                IDbCommand command = SqlCommandFactory.CreateCommand(connection, SqlCommandResources.SqlAzurePersistenceQueueQueryXmlData);

                command.Parameters.Add(SqlParameterUtility.CreateParameter(SqlObjectResources.ColumnQueueItemID, SqlDbType.UniqueIdentifier, itemId));

                for (int i = 0; xPathCollection != null && xPathCollection.Length > 0 && i < xPathCollection.Length; i++)
                {
                    command.Parameters.Add(SqlParameterUtility.CreateParameter(String.Format(CultureInfo.CurrentCulture, SqlObjectResources.CommandParamTemplateXPath, i + 1), SqlDbType.VarChar, xPathCollection[i]));
                }

                AddNamespaces(command, nsManager);

                return command;
            } 
            #endregion

            #region Private methods
            private static void AddNamespaces(IDbCommand command, XmlNamespaceManager nsManager)
            {
                if (nsManager != null)
                {
                    IEnumerator nsEnumerator = nsManager.GetEnumerator();
                    int nsIndex = 1;

                    while (nsEnumerator.MoveNext())
                    {
                        string nsPrefix = nsEnumerator.Current as string;

                        // Should filter the standard XML namespace, otherwise can get "Attempt to redefine namespace prefix 'xmlns'" error.
                        if (String.Compare(nsPrefix, "xmlns", true, CultureInfo.CurrentCulture) != 0)
                        {
                            command.Parameters.Add(SqlParameterUtility.CreateParameter(String.Format(CultureInfo.CurrentCulture, SqlObjectResources.CommandParamTemplateNamespace, nsIndex), SqlDbType.VarChar, String.Format(CultureInfo.CurrentCulture, SqlObjectResources.CommandParamTemplateNamespaceValue, nsPrefix, nsManager.LookupNamespace(nsPrefix))));
                            nsIndex++;
                        }
                    }
                }
            }
            #endregion
        }
        #endregion
    }
}
