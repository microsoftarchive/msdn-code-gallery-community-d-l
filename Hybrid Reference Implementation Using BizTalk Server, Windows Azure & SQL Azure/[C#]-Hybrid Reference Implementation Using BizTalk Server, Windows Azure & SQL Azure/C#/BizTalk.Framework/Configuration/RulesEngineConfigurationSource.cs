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
    using System.Globalization;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.RulesEngine;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a configuration source that uses BizTalk Business Rules Engine for storing configuration data.
    /// </summary>
    [ConfigurationElementType(typeof(RulesEngineConfigurationSourceElement))]
    public sealed class RulesEngineConfigurationSource : IApplicationConfigurationSource
    {
        #region Private members
        /// <summary>
        /// The name of the BRE policy which will be invoked to retrieve the configuration data.
        /// </summary>
        private readonly string configPolicy;

        /// <summary>
        /// The version of the BRE policy which will be invoked to retrieve the configuration data.
        /// </summary>
        private readonly Version configVersion;

        /// <summary>
        /// The actual version number of the BRE policy returned by the Rules Engine.
        /// </summary>
        private Version actualConfigVersion;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the RulesEngineConfigurationSource class.
        /// </summary>
        /// <param name="configPolicy">The BRE policy which will be invoked to retrieve the configuration data.</param>
        /// <param name="configVersion">The version of the BRE policy which will be invoked to retrieve the configuration data.</param>
        public RulesEngineConfigurationSource(string configPolicy, Version configVersion)
        {
            Guard.ArgumentNotNull(configPolicy, "configPolicy");

            this.configPolicy = configPolicy;
            this.configVersion = configVersion;
            this.actualConfigVersion = configVersion;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the name of the BRE policy which will be invoked to retrieve the configuration data.
        /// </summary>
        public string PolicyName
        {
            get { return this.configPolicy; }
        }

        /// <summary>
        /// Returns the version of the BRE policy which will be invoked to retrieve the configuration data.
        /// </summary>
        public Version PolicyVersion
        {
            get { return this.actualConfigVersion; }
        } 
        #endregion

        #region IConfigurationSource implementation
        /// <summary>
        /// Adds a <see cref="System.Configuration.ConfigurationSection"/> to the configuration source and saves the configuration source. 
        /// </summary>
        /// <param name="sectionName">The name by which the configurationSection should be added.</param>
        /// <param name="configurationSection">The configuration section to add.</param>
        public void Add(string sectionName, ConfigurationSection configurationSection)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Adds a handler to be called when changes to the section named sectionName are detected.
        /// </summary>
        /// <param name="sectionName">The name of the section to watch for.</param>
        /// <param name="handler">The handler for the change event to add.</param>
        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieves the specified <see cref="System.Configuration.ConfigurationSection"/>. 
        /// </summary>
        /// <param name="sectionName">The name of the section to be retrieved.</param>
        /// <returns>The specified <see cref="System.Configuration.ConfigurationSection"/>, or a null reference if a section by that name is not found.</returns>
        public ConfigurationSection GetSection(string sectionName)
        {
            return GetSection(sectionName, AppDomain.CurrentDomain.SetupInformation.ApplicationName, Environment.MachineName);
        }

        /// <summary>
        /// Retrieves the specified <see cref="System.Configuration.ConfigurationSection"/> for a given application running of the specified machine.
        /// </summary>
        /// <param name="sectionName">The name of the section to be retrieved.</param>
        /// <param name="applicationName">The name of the application for which a configuration section is being requested.</param>
        /// <param name="machineName">The name of the machine on which the requesting application is running.</param>
        /// <returns>The specified <see cref="System.Configuration.ConfigurationSection"/>, or a null reference if a section by that name is not found.</returns>
        public ConfigurationSection GetSection(string sectionName, string applicationName, string machineName)
        {
            var callToken = TraceManager.RulesComponent.TraceIn(sectionName, this.configPolicy, this.configVersion);

            try
            {
                PolicyExecutionInfo policyExecInfo = new PolicyExecutionInfo(PolicyName, PolicyVersion);

                policyExecInfo.AddParameter(WellKnownContractMember.MessageParameters.SectionName, sectionName);
                policyExecInfo.AddParameter(WellKnownContractMember.MessageParameters.ApplicationName, applicationName);
                policyExecInfo.AddParameter(WellKnownContractMember.MessageParameters.MachineName, machineName);

                ConfigurationSection configSection = ConfigurationSectionFactory.GetSection(sectionName);

                if (configSection != null)
                {
                    PolicyExecutionResult execResult = PolicyHelper.Execute(policyExecInfo, RulesEngineFactFactory.GetFacts(configSection));

                    if (execResult.Success)
                    {
                        // If policy invocation was successful, we need to update the policy version number of reflect the true version of the policy.
                        this.actualConfigVersion = new Version(execResult.PolicyVersion.Major, execResult.PolicyVersion.Minor);

                        if (SourceChanged != null)
                        {
                            SourceChanged(this, new ConfigurationSourceChangedEventArgs(this, new string[] { sectionName }));
                        }

                        return configSection;
                    }
                    else
                    {
                        throw new ConfigurationErrorsException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.ConfigPolicyExecutionFailed, execResult.PolicyName), execResult.Errors.Count > 0 ? execResult.Errors[0] : null);
                    }
                }
                else
                {
                    throw new ConfigurationErrorsException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.ConfigurationSectionNotSupported, sectionName, Resources.RulesEngineConfigurationSourceElementDisplayName));
                }
            }
            finally
            {
                TraceManager.RulesComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Removes a <see cref="System.Configuration.ConfigurationSection"/> from the configuration source. 
        /// </summary>
        /// <param name="sectionName">The name of the section to remove.</param>
        public void Remove(string sectionName)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Removes a handler to be called when changes to section are detected.
        /// </summary>
        /// <param name="sectionName">The name of the watched section.</param>
        /// <param name="handler">The handler for the change event to remove.</param>
        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Event raised when the underlying configuration source has changed any section.
        /// </summary>
        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;
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
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        #endregion
    }
}
