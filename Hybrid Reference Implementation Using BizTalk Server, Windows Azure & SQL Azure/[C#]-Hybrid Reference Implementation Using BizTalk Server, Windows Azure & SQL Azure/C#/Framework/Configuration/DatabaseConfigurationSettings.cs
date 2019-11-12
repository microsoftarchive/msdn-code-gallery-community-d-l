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

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
    #endregion

    /// <summary>
    /// Wrapper class for strongly-typed database configuration settings.
    /// </summary>
    public class DatabaseConfigurationSettings
    {
        #region Private members
        /// <summary>
        /// The database configuration settings.
        /// </summary>
        private readonly DatabaseSyntheticConfigSettings databaseSettings;

        /// <summary>
        /// The connection string viewer helper.
        /// </summary>
        private ConnectionStringView connStrView;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConfigurationSettings"/> class.
        /// </summary>
        /// <param name="configSource">The configuration source used to retrieve the database configuration.</param>
        internal DatabaseConfigurationSettings(IConfigurationSource configSource)
        {
            this.databaseSettings = new DatabaseSyntheticConfigSettings(configSource);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the default database instance name (if defined).
        /// </summary>
        public string DefaultDatabase
        {
            get { return this.databaseSettings.DefaultDatabase; }
        }

        /// <summary>
        /// Returns an instance of the helper class that provides the indexer-based access to the database connection strings
        /// as well as a set of connection strings to the well-known databases.
        /// </summary>
        public ConnectionStringView ConnectionStrings
        {
            get
            {
                if (null == this.connStrView)
                {
                    this.connStrView = new ConnectionStringView(this.databaseSettings);
                }

                return this.connStrView;
            }
        } 
        #endregion
    }
}
