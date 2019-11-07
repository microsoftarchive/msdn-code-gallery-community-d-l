//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework
{
    #region Using references
    using System;
    using System.Configuration;
    using System.Security.Cryptography.X509Certificates;

    using Microsoft.WindowsAzure.ServiceRuntime;

    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Provides helper functions to enable user code to get safe access to the environmental parameters of the cloud infrastructure.
    /// </summary>
    public static class CloudEnvironment
    {
        #region Private members
        private readonly static TimeSpan maxQueueVisibilityTimeout = TimeSpan.FromHours(2);
        private readonly static bool runtimeAvailable;
        #endregion

        #region Constructor
        static CloudEnvironment()
        {
            try
            {
                runtimeAvailable = RoleEnvironment.IsAvailable;
            }
            catch
            {
                // Really don't care if we get an exception here as we simply assume that Azure environment is not available.
                runtimeAvailable = false;
            }
        } 
        #endregion

        #region Public properties
        /// <summary>
        /// Indicates whether the role instance is running in the Windows Azure environment.
        /// </summary>
        public static bool IsAvailable
        {
            get { return runtimeAvailable; }
        }

        /// <summary>
        /// Gets the ID of the object representing the role instance in which this code is currently executing.
        /// </summary>
        public static string CurrentRoleInstanceId
        {
            get { return IsAvailable ? RoleEnvironment.CurrentRoleInstance.Id : Guid.NewGuid().ToString("N"); }
        }

        /// <summary>
        /// Gets the name of the role in which this code is currently executing.
        /// </summary>
        public static string CurrentRoleName
        {
            get { return IsAvailable ? RoleEnvironment.CurrentRoleInstance.Role.Name : Resources.UnknownRoleName; }
        }

        /// <summary>
        /// Gets the machine name on which this code is currently executing.
        /// </summary>
        public static string CurrentRoleMachineName
        {
            get { return Environment.MachineName; }
        }

        /// <summary>
        /// Gets the deployment ID, a string value that uniquely identifies the deployment in which this role instance is running.
        /// </summary>
        public static string DeploymentId
        {
            get { return IsAvailable ? RoleEnvironment.DeploymentId : Guid.NewGuid().ToString("N"); }
        }

        /// <summary>
        /// Gets a maximum allowed visibility timeout for messages stored in the Azure queues.
        /// </summary>
        public static TimeSpan MaxQueueVisibilityTimeout
        {
            get { return maxQueueVisibilityTimeout; }
        }

        /// <summary>
        /// Gets a visibility timeout for messages stored in the Azure queues that is intended to avoid a race condition whereby
        /// Azure storage fabric attempts to reset the message visibility and remove it at the same time. The default safe value is
        /// 5 minutes below the maximum allowed visibility timeout.
        /// </summary>
        public static TimeSpan SafeQueueVisibilityTimeout
        {
            get { return maxQueueVisibilityTimeout.Subtract(TimeSpan.FromMinutes(5)); }
        }

        /// <summary>
        /// Retrieves the value of a setting in the service configuration file.
        /// </summary>
        /// <param name="configurationSettingName">The name of the configuration setting.</param>
        /// <returns>A String containing the value of the configuration setting.</returns>
        public static string GetConfigurationSettingValue(string configurationSettingName)
        {
            if (IsAvailable)
            {
                try
                {
                    return RoleEnvironment.GetConfigurationSettingValue(configurationSettingName);
                }
                catch (RoleEnvironmentException)
                {
                    return null;
                }
            }
            else
            {
                return ConfigurationManager.AppSettings[configurationSettingName];
            }
        }
        #endregion
    }
}