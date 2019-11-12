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
    using Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// This factory class is responsible for instantiating the ConfigurationSection objects for given configuration section names.
    /// </summary>
    public static class ConfigurationSectionFactory
    {
        #region Private members
        private static readonly string FactoryTypeFullName = typeof(ConfigurationSectionFactory).FullName;
        private static readonly string FactoryAssemblyQualifiedName = typeof(ConfigurationSectionFactory).AssemblyQualifiedName;
        #endregion

        /// <summary>
        /// Returns an instance of the <see cref="System.Configuration.ConfigurationSection"/> representing a configuration section associated with the given name.
        /// </summary>
        /// <param name="sectionName">The name of the configuration section.</param>
        /// <returns>The instance of <see cref="System.Configuration.ConfigurationSection"/>, or an empty instance of <see cref="ApplicationConfigurationSettings"/> if a section by that name was not found.</returns>
        public static ConfigurationSection GetSection(string sectionName)
        {
            Guard.ArgumentNotNullOrEmptyString(sectionName, "sectionName");

            // First verify if the specified section name represents a .NET type name (either a full type name or assembly-qualified name).
            if (ContainsFullTypeName(sectionName))
            {
                string sectionTypeName = sectionName;

                // If this is not an assembly-qualified name, construct the assembly-qualified name by assuming that section is located in the current assembly.
                if (!ContainsFullyQualifiedTypeName(sectionName))
                {
                    sectionTypeName = FactoryAssemblyQualifiedName.Replace(FactoryTypeFullName, sectionName);
                }

                // Try to retrieve the .NET type that corresponds to the specified section name.
                Type sectionType = TryGetConfigurationSectionType(sectionTypeName);

                // If .NET type is found, create a new instance and return it immediately, no further checks are required.
                if (sectionType != null)
                {
                    return Activator.CreateInstance(sectionType) as ConfigurationSection;
                }
            }

            if (String.Compare(sectionName, DatabaseSettings.SectionName, true) == 0)
            {
                return new DatabaseSettings();
            }
            
            if (String.Compare(sectionName, Resources.ConnectionStringsConfigurationSectionName, true) == 0)
            {
                return new ConnectionStringsSection();
            }
            
            if (String.Compare(sectionName, ServiceBusConfigurationSettings.SectionName, true) == 0)
            {
                return new ServiceBusConfigurationSettings();
            }
            
            if (String.Compare(sectionName, ApplicationDiagnosticSettings.SectionName, true) == 0)
            {
                return new ApplicationDiagnosticSettings();
            }
            
            if (String.Compare(sectionName, XPathQueryLibrary.SectionName, true) == 0)
            {
                return new XPathQueryLibrary();
            }
            
            if (String.Compare(sectionName, LoggingSettings.SectionName, true) == 0)
            {
                return new LoggingSettings();
            }
            
            if (String.Compare(sectionName, TypeRegistrationProvidersConfigurationSection.SectionName, true) == 0)
            {
                return new TypeRegistrationProvidersConfigurationSection();
            }
            
            if (String.Compare(sectionName, CacheManagerSettings.SectionName, true) == 0)
            {
                return new CacheManagerSettings();
            }
            
            if (String.Compare(sectionName, InstrumentationConfigurationSection.SectionName, true) == 0)
            {
                return new InstrumentationConfigurationSection();
            }
            
            if (String.Compare(sectionName, CryptographySettings.SectionName, true) == 0)
            {
                return new CryptographySettings();
            }
            
            if (String.Compare(sectionName, ExceptionHandlingSettings.SectionName, true) == 0)
            {
                return new ExceptionHandlingSettings();
            }
            
            if (String.Compare(sectionName, PolicyInjectionSettings.SectionName, true) == 0)
            {
                return new PolicyInjectionSettings();
            }
            
            if (String.Compare(sectionName, SecuritySettings.SectionName, true) == 0)
            {
                return new SecuritySettings();
            }
           
            if (String.Compare(sectionName, RetryPolicyConfigurationSettings.SectionName, true) == 0)
            {
                return new RetryPolicyConfigurationSettings();
            }
            
            if (String.Compare(sectionName, StorageAccountConfigurationSettings.SectionName, true) == 0)
            {
                return new StorageAccountConfigurationSettings();
            }

            // If no matched section type was found, return a new instance of ApplicationConfigurationSettings section.
            return new ApplicationConfigurationSettings();
        }

        #region Private methods
        private static bool ContainsFullyQualifiedTypeName(string sectionName)
        {
            return sectionName != null && sectionName.Contains(",");
        }

        private static bool ContainsFullTypeName(string sectionName)
        {
            return sectionName != null && sectionName.Contains(".");
        }

        private static Type TryGetConfigurationSectionType(string sectionTypeName)
        {
            Type sectionType = null;

            return sectionTypeName != null && (sectionType = Type.GetType(sectionTypeName, false)) != null && typeof(ConfigurationSection).IsAssignableFrom(sectionType) ? sectionType : null;
        }
        #endregion
    }
}