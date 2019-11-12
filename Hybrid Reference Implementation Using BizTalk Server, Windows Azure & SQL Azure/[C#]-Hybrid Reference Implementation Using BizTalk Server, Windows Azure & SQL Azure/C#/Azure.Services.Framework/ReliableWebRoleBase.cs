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
    using System.Net;
    using System.Linq;
    using System.Threading;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.Collections.Generic;
    using System.Globalization;

    using Microsoft.WindowsAzure.Diagnostics;
    using Microsoft.WindowsAzure.ServiceRuntime;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Provides a base class for custom implementations of Windows Azure web roles.
    /// </summary>
    public abstract class ReliableWebRoleBase : IExtensibleCloudServiceComponent
    {
        #region Private members
        private readonly Stopwatch runTimeStopwatch = new Stopwatch();
        private readonly Guid instanceId = Guid.NewGuid();
        private readonly object extensionsLock = new object();

        private IExtensionCollection<IExtensibleCloudServiceComponent> extensions;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableWebRoleBase"/> object initialized with default global settings.
        /// </summary>
        public ReliableWebRoleBase()
        {
        }
        #endregion

        #region Public members
        /// <summary>
        /// Returns an unique <see cref="System.Guid"/> value for the worker role instance. This ID is being used by the base class for tracing purposes.
        /// </summary>
        public Guid InstanceId
        {
            get { return this.instanceId; }
        }
        #endregion

        #region IExtensibleObject implementation
        /// <summary>
        /// Gets a collection of extension objects for this extensible object.
        /// </summary>
        public IExtensionCollection<IExtensibleCloudServiceComponent> Extensions
        {
            get
            {
                if (null == this.extensions)
                {
                    lock (this.extensionsLock)
                    {
                        if (null == this.extensions)
                        {
                            this.extensions = new ExtensionCollection<IExtensibleCloudServiceComponent>(this, this.extensionsLock);
                        }
                    }
                }
                return this.extensions;
            }
        }
        #endregion

        #region RoleEntryPoint implementation
        /// <summary>
        /// Called by Windows Azure to initialize the role instance.
        /// </summary>
        public void OnStart()
        {
            try
            {
                TraceManager.WorkerRoleComponent.TraceIn(InstanceId, CloudEnvironment.CurrentRoleInstanceId);

                this.runTimeStopwatch.Start();

                RoleEnvironment.Changing += this.RoleEnvironmentChanging;
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

                // Disable the Nagle algorithm globally. This would help improve the performance of storage operations.
                // Turning Nagle off should be considered for Table and Queue (and any protocol that deals with small sized messages). 
                // More information on http://blogs.msdn.com/b/windowsazurestorage/archive/2010/06/25/nagle-s-algorithm-is-not-friendly-towards-small-requests.aspx
                ServicePointManager.UseNagleAlgorithm = false;

                // Add standard extensions.
                ConfigureDefaultExtensions();

                // Invoke the user-defined implementation of the OnStart method.
                OnRoleStart();
            }
            catch (Exception ex)
            {
                TraceManager.WorkerRoleComponent.TraceError(ex, InstanceId);
#if DEBUG
                // This is to prevent the role from recycling under debugger.
                if (Debugger.IsAttached)
                {
                    throw;
                }
#endif
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(InstanceId);
            }
        }

        /// <summary>
        /// Called by Windows Azure when the role instance is to be stopped.
        /// </summary>
        public void OnStop()
        {
            try
            {
                TraceManager.WorkerRoleComponent.TraceIn(InstanceId, CloudEnvironment.CurrentRoleInstanceId);

                OnRoleStop();
            }
            catch (Exception ex)
            {
                // Should log but not re-throw any exceptions here.
                TraceManager.WorkerRoleComponent.TraceError(ex, InstanceId);
#if DEBUG
                // This is to prevent the role from recycling under debugger.
                if (Debugger.IsAttached)
                {
                    throw;
                }
#endif
            }
            finally
            {
                this.runTimeStopwatch.Stop();
                this.Extensions.Clear();

                TraceManager.WorkerRoleComponent.TraceOut(InstanceId);
            }
        }

        /// <summary>
        /// Called by Windows Azure when the role instance encounters an unhandled exception.
        /// </summary>
        /// <param name="fault">The unhandled exception.</param>
        public void OnError(Exception fault)
        {
            try
            {
                TraceManager.WorkerRoleComponent.TraceIn(InstanceId, CloudEnvironment.CurrentRoleInstanceId);

                OnRoleError(fault);
            }
            catch (Exception ex)
            {
                // Should log but not re-throw any exceptions here.
                TraceManager.WorkerRoleComponent.TraceError(ex, InstanceId);
#if DEBUG
                // This is to prevent the role from recycling under debugger.
                if (Debugger.IsAttached)
                {
                    throw;
                }
#endif
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(InstanceId);
            }
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Enables the user code to extend the OnStart phase that is called by Windows Azure runtime to initialize the role instance.
        /// </summary>
        protected abstract void OnRoleStart();

        /// <summary>
        /// Enables the user code to extend the OnStop phase that is called by Windows Azure runtime when the role instance is to be stopped.
        /// </summary>
        protected abstract void OnRoleStop();

        /// <summary>
        /// Enables the user code to extend the OnError phase that is called by Windows Azure runtime when the role instance encounters an unhandled exception.
        /// </summary>
        /// <param name="fault">The unhandled exception.</param>
        protected virtual void OnRoleError(Exception fault)
        {
            UnhandledExceptionHandler(this, new UnhandledExceptionEventArgs(fault, false));
        }

        /// <summary>
        /// Enables the user code to provide a handler for the Changing event that occurs before a change to the service 
        /// configuration is applied to the running instances of the role.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        protected virtual void OnRoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
        }
        #endregion

        #region Private methods
        private void ConfigureDefaultExtensions()
        {
            this.EnsureExists<RoleConfigurationSettingsExtension>();
            this.EnsureExists<RoleDiagnosticMonitorExtension>();
            this.EnsureExists<InterRoleEventRelayCommunicationExtension>();
            this.EnsureExists<CloudStorageProviderExtension>();
            this.EnsureExists<CloudCacheProviderExtension>();
        }

        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            TraceManager.WorkerRoleComponent.TraceIn(InstanceId, CloudEnvironment.CurrentRoleInstanceId);

            // If a configuration setting is changing.
            if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
            {
                // Tell the configuration manager to unload any cached configuration data.
                ApplicationConfiguration.Current.Unload();

                // Set e.Cancel to true to restart this role instance, otherwise keep the role instance running.
                e.Cancel = false;
            }

            // Invoke the user defined part of the RoleEnvironmentChanging event handler.
            OnRoleEnvironmentChanging(sender, e);

            TraceManager.WorkerRoleComponent.TraceOut(InstanceId, e.Cancel);
        }

        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e != null ? e.ExceptionObject as Exception : null;

            if (ex != null)
            {
                TraceManager.WorkerRoleComponent.TraceError(ex);
            }
            else
            {
                TraceManager.WorkerRoleComponent.TraceError(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.AppDomainUnhandledException, AppDomain.CurrentDomain.FriendlyName));
            }
        }
        #endregion
    }
}
