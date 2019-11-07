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
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Globalization;

    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Provides the indexer-based access to the collection of the database connection strings.
    /// </summary>
    public class ConnectionStringView
    {
        #region Private members
        /// <summary>
        /// A reference to the <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSyntheticConfigSettings"/> class that has instantiated the <see cref="ConnectionStringView"/> class.
        /// </summary>
        private readonly DatabaseSyntheticConfigSettings databaseSettings;

        /// <summary>
        /// An internal cache of connection strings for performance optimization.
        /// </summary>
        private readonly IDictionary<string, string> connectionStringCache;

        /// <summary>
        /// A lock object for serialized access to the connection string cache.
        /// </summary>
        private readonly object cacheLockObj = new object();

        /// <summary>
        /// The configuration section storing the connection string information.
        /// </summary>
        private readonly ConnectionStringsSection connectionStringsConfig;
        #endregion

        #region Constructors
        /// <summary>
        /// The default constructor is inaccessible, the object needs to be instantiated using non-parameterless overloads.
        /// </summary>
        private ConnectionStringView()
        {
            this.connectionStringCache = new Dictionary<string, string>(16);
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="ConnectionStringView"/> object initialized with the specified <see cref="System.Configuration.ConnectionStringsSection"/> instance.
        /// </summary>
        /// <param name="connectionStringsConfig">An instance of the <see cref="System.Configuration.ConnectionStringsSection"/> object providing the collection of connection strings.</param>
        public ConnectionStringView(ConnectionStringsSection connectionStringsConfig): this()
        {
            Guard.ArgumentNotNull(connectionStringsConfig, "connectionStringsConfig");

            this.connectionStringsConfig = connectionStringsConfig;
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="ConnectionStringView"/> object initialized with the specified <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSyntheticConfigSettings"/> instance.
        /// </summary>
        /// <param name="databaseSettings">An instance of the <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSyntheticConfigSettings"/> object providing the collection of connection strings.</param>
        public ConnectionStringView(DatabaseSyntheticConfigSettings databaseSettings) : this()
        {
            Guard.ArgumentNotNull(databaseSettings, "databaseSettings");

            this.databaseSettings = databaseSettings;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Retrieves a connection string by the given database identifier.
        /// </summary>
        /// <param name="databaseName">A database identifier as defined using the Enterprise Library Configuration Tool.</param>
        /// <returns>A well-formed provider-specific connection string.</returns>
        public string this[string databaseName]
        {
            get
            {
                string connectionString = null;

                // Try to retrieve the connection string from the cache
                if (!this.connectionStringCache.TryGetValue(databaseName, out connectionString))
                {
                    lock (this.cacheLockObj)
                    {
                        if (!this.connectionStringCache.TryGetValue(databaseName, out connectionString))
                        {
                            ConnectionStringSettings connStrSettings = null;

                            if (this.databaseSettings != null)
                            {
                                // Retrieve the connection string information from the application configuration.
                                connStrSettings = this.databaseSettings.GetConnectionStringSettings(databaseName);
                            }
                            else if (this.connectionStringsConfig != null)
                            {
                                // Retrieve the connection string information from the in-memory collection of strings.
                                connStrSettings = this.connectionStringsConfig.ConnectionStrings[databaseName];
                            }

                            if (connStrSettings != null)
                            {
                                connectionString = connStrSettings.ConnectionString;

                                // Add this connection string to the cache so that it can be quickly retrieved at the later stage.
                                this.connectionStringCache.Add(databaseName, connectionString);
                            }
                        }
                    }
                }

                // If we haven't found a connection string, throw a configuration exception to inform the user.
                if (null == connectionString)
                {
                    throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConnectionStringNotDefined, databaseName));
                }

                return connectionString;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Verifies whether or not a connection string for the specified database identifier exists.
        /// </summary>
        /// <param name="databaseName">A database identifier.</param>
        /// <returns>A flag indicating that the connection string has been registered in the configuration.</returns>
        public bool Exists(string databaseName)
        {
            Guard.ArgumentNotNullOrEmptyString(databaseName, "databaseName");

            try
            {
                ConnectionStringSettings connStrSettings = null;

                if (this.databaseSettings != null)
                {
                    connStrSettings = this.databaseSettings.GetConnectionStringSettings(databaseName);
                }
                else if (this.connectionStringsConfig != null)
                {
                    connStrSettings = this.connectionStringsConfig.ConnectionStrings[databaseName];
                }

                return connStrSettings != null && !String.IsNullOrEmpty(connStrSettings.ConnectionString);
            }
            catch (ConfigurationErrorsException ex)
            {
                Trace.WriteLine(ExceptionTextFormatter.Format(ex));
                return false;
            }
        }

        /// <summary>
        /// Adds a new connection string for the specified database.
        /// </summary>
        /// <param name="databaseName">The database identifier.</param>
        /// <param name="connectionString">The provider-specific connection string.</param>
        public void Add(string databaseName, string connectionString)
        {
            Add(databaseName, connectionString, Resources.DefaultDatabaseProviderName);
        }

        /// <summary>
        /// Adds a new connection string for the specified database and provider.
        /// </summary>
        /// <param name="databaseName">The database identifier.</param>
        /// <param name="connectionString">The provider-specific connection string.</param>
        /// <param name="providerName">The name of the provider to use with the connection string.</param>
        public void Add(string databaseName, string connectionString, string providerName)
        {
            Guard.ArgumentNotNullOrEmptyString(databaseName, "databaseName");
            Guard.ArgumentNotNullOrEmptyString(connectionString, "connectionString");
            Guard.ArgumentNotNullOrEmptyString(providerName, "providerName");

            if (this.connectionStringsConfig != null)
            {
                this.connectionStringsConfig.ConnectionStrings.Add(new ConnectionStringSettings(databaseName, connectionString, providerName));
            }
            else
            {
                throw new NotSupportedException();
            }
        }
        #endregion
    }
}
