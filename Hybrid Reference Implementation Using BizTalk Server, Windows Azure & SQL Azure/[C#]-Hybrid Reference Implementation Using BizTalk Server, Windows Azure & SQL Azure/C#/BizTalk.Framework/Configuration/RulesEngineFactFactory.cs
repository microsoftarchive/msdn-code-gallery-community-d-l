//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.Configuration
{
    #region Using references
    using System;
    using System.Configuration;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
    #endregion

    /// <summary>
    /// Implements a set of factory methods dealing with Rules Engine facts.
    /// </summary>
    internal static class RulesEngineFactFactory
    {
        /// <summary>
        /// Returns a collection of facts that belong to the specified configuration section.
        /// </summary>
        /// <param name="configSection">The <see cref="System.Configuration.ConfigurationSection"/> object containing the configuration section.</param>
        /// <returns>A collection of section-specific facts.</returns>
        public static object[] GetFacts(ConfigurationSection configSection)
        {
            Guard.ArgumentNotNull(configSection, "configSection");

            List<object> facts = new List<object>();

            facts.Add(configSection);

            if (configSection is ConnectionStringsSection)
            {
                ConnectionStringsSection connectionStringConfig = configSection as ConnectionStringsSection;

                facts.Add(connectionStringConfig.ConnectionStrings);
                facts.Add(new ConnectionStringView(connectionStringConfig));
            }
            else if (configSection is ServiceBusConfigurationSettings)
            {
                facts.Add((configSection as ServiceBusConfigurationSettings).Endpoints);
            }
            else if (configSection is XPathQueryLibrary)
            {
                XPathQueryLibrary xPathLib = configSection as XPathQueryLibrary;

                facts.Add(xPathLib.Namespaces);
                facts.Add(xPathLib.Queries);
            }
            else if (configSection is LoggingSettings)
            {
                facts.Add(new LoggingConfigurationView(configSection as LoggingSettings));
            }
            else if (configSection is CacheManagerSettings)
            {
                facts.Add(new CachingConfigurationView(configSection as CacheManagerSettings));
            }

            return facts.ToArray();
        }
    }
}
