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
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Extends the IConfigurationSource contract to support application-specific configuration that can be localized to a particular 
    /// application name or machine on which the application is running.
    /// </summary>
    public interface IApplicationConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Retrieves the specified <see cref="System.Configuration.ConfigurationSection"/> for a given application running of the specified machine.
        /// </summary>
        /// <param name="sectionName">The name of the section to be retrieved.</param>
        /// <param name="applicationName">The name of the application for which a configuration section is being requested.</param>
        /// <param name="machineName">The name of the machine on which the requesting application is running.</param>
        /// <returns>The specified <see cref="System.Configuration.ConfigurationSection"/>, or a null reference if a section by that name is not found.</returns>
        ConfigurationSection GetSection(string sectionName, string applicationName, string machineName);
    }
}
