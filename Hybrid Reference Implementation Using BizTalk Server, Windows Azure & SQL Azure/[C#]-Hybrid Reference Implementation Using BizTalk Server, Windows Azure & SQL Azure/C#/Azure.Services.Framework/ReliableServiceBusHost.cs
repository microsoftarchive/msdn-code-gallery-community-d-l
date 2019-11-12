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
namespace Contoso.Cloud.Integration.Azure.Services.Framework
{
    #region Using references
    using System;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Implements the reliability layer between the Windows Azure Service Bus and client code to ensure that all major operations 
    /// against WCF infrastructure such as opening a service host will respect potential transient conditions that may manifest 
    /// themselves in a highly multi-tenant hosting environment such as Windows Azure.
    /// </summary>
    /// <typeparam name="T">The type of service contract hosted by the Windows Azure Service Bus.</typeparam>
    public sealed class ReliableServiceBusHost<T> : ICommunicationObject, IDisposable where T : class
    {
        #region Private members
        private const int DefaultOpenTimeoutSec = 60 * 5;

        private readonly ServiceHost serviceHost;
        private readonly RetryPolicy retryPolicy;
        private readonly ServiceBusEndpointInfo sbEndpointInfo;
        private ServiceHost failoverServiceHost;

        private bool disposed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Service Bus service host that will listen on the specified Service Bus endpoint.
        /// No retry policy will be enforced when using this constructor overload.
        /// </summary>
        /// <param name="sbEndpointInfo">The endpoint details.</param>
        public ReliableServiceBusHost(ServiceBusEndpointInfo sbEndpointInfo)
            : this(sbEndpointInfo, RetryPolicy.NoRetry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Service Bus service host that will listen on the specified Service Bus endpoint
        /// and utilize the specified custom retry policy.
        /// </summary>
        /// <param name="sbEndpointInfo">The endpoint details.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying WCF infrastructure.</param>
        public ReliableServiceBusHost(ServiceBusEndpointInfo sbEndpointInfo, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            this.sbEndpointInfo = sbEndpointInfo;
            this.serviceHost = ServiceBusHostFactory.CreateServiceBusHost<T>(sbEndpointInfo);
            this.retryPolicy = retryPolicy;
            this.retryPolicy.RetryOccurred += HandleRetryState;

            AttachEventHandlers(this.serviceHost);
        }

        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Service Bus service host from the specified generic WCF service host.
        /// Utilizes the specified custom retry policy.
        /// </summary>
        /// <param name="serviceHost">The initialized WCF service host that will be wrapped by this instance of <see cref="ReliableServiceBusHost&lt;T&gt;"/>.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying WCF infrastructure.</param>
        public ReliableServiceBusHost(ServiceHost serviceHost, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(serviceHost, "serviceHost");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            this.serviceHost = serviceHost;
            this.retryPolicy = retryPolicy;
            this.retryPolicy.RetryOccurred += HandleRetryState;

            AttachEventHandlers(this.serviceHost);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns a singleton instance of the hosted service or a null reference if the service host has not been explicitly initialized to host the singleton instance.
        /// </summary>
        public T ServiceInstance
        {
            get { return ServiceHost.SingletonInstance as T; }
        }

        /// <summary>
        /// Returns the retry policy that is being used for ensuring reliable access to the underlying WCF infrastructure.
        /// </summary>
        public RetryPolicy RetryPolicy
        {
            get { return this.retryPolicy; }
        }
        #endregion

        #region Private properties
        private ServiceHost ServiceHost
        {
            get { return this.serviceHost.State != CommunicationState.Faulted ? this.serviceHost : (this.failoverServiceHost != null ? this.failoverServiceHost : this.serviceHost); }
        }
        #endregion

        #region ICommunicationObject implementation
        /// <summary>
        /// Causes a communication object to transition immediately from its current state into the closed state.
        /// </summary>
        public void Abort()
        {
            try
            {
                ServiceHost.Abort();
            }
            catch
            {
                // It is acceptable to ignore any exceptions within this context.
            }
        }

        /// <summary>
        /// Begins an asynchronous operation to close a communication object with a specified timeout.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous close operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous close operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous close operation.</returns>
        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return ServiceHost.BeginClose(timeout, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to close a communication object.
        /// </summary>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous close operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous close operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous close operation.</returns>
        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return ServiceHost.BeginClose(callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to open a communication object within a specified interval of time.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous open operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous open operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous open operation.</returns>
        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return ServiceHost.BeginOpen(timeout, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to open a communication object.
        /// </summary>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous open operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous open operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous open operation.</returns>
        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return ServiceHost.BeginOpen(callback, state);
        }

        /// <summary>
        /// Causes a communication object to transition from its current state into the closed state.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        public void Close(TimeSpan timeout)
        {
            ServiceHost.Close(timeout);
        }

        /// <summary>
        /// Causes a communication object to transition from its current state into the closed state.
        /// </summary>
        public void Close()
        {
            try
            {
                ServiceHost.Close();
            }
            catch
            {
                // It is acceptable to ignore any exceptions within this context.
            }
        }

        /// <summary>
        /// Completes an asynchronous operation to close a communication object.
        /// </summary>
        /// <param name="result">The System.IAsyncResult that is returned by a call to the System.ServiceModel.ICommunicationObject.BeginClose method.</param>
        public void EndClose(IAsyncResult result)
        {
            ServiceHost.EndClose(result);
        }

        /// <summary>
        /// Completes an asynchronous operation to open a communication object.
        /// </summary>
        /// <param name="result">The System.IAsyncResult that is returned by a call to the System.ServiceModel.ICommunicationObject.BeginOpen method.</param>
        public void EndOpen(IAsyncResult result)
        {
            ServiceHost.EndOpen(result);
        }

        /// <summary>
        /// Causes a communication object to transition from the created state into the opened state within a specified interval of time.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        public void Open(TimeSpan timeout)
        {
            this.retryPolicy.ExecuteAction(() =>
            {
                ServiceHost.Open(timeout);
            });
        }

        /// <summary>
        /// Causes a communication object to transition from the created state into the opened state.
        /// </summary>
        public void Open()
        {
            Open(TimeSpan.FromSeconds(DefaultOpenTimeoutSec));
        }

        /// <summary>
        /// Gets the current state of the communication-oriented object.
        /// </summary>
        public CommunicationState State
        {
            get { return ServiceHost.State; }
        }

        /// <summary>
        /// Occurs when the communication object completes its transition from the opening state into the opened state.
        /// </summary>
        public event EventHandler Opened;

        /// <summary>
        /// Occurs when the communication object first enters the opening state.
        /// </summary>
        public event EventHandler Opening;

        /// <summary>
        /// Occurs when the communication object first enters the faulted state.
        /// </summary>
        public event EventHandler Faulted;

        /// <summary>
        /// Occurs when the communication object completes its transition from the closing state into the closed state.
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        /// Occurs when the communication object first enters the closing state.
        /// </summary>
        public event EventHandler Closing;
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A flag indicating that managed resources must be released.</param>
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    try
                    {
                        if (ServiceHost != null)
                        {
                            // Unbind from the all event handler.
                            DettachEventHandlers(ServiceHost);

                            if (ServiceHost.State == CommunicationState.Opened)
                            {
                                ServiceHost.Close();
                            }
                            else
                            {
                                ServiceHost.Abort();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Abort();
                    }

                    this.retryPolicy.RetryOccurred -= HandleRetryState;
                    this.disposed = true;
                }
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~ReliableServiceBusHost()
        {
            this.Dispose(false);
        }
        #endregion

        #region Private methods
        private void HandleRetryState(int currentRetryCount, Exception lastException, TimeSpan delay)
        {
            if (lastException != null)
            {
                TraceManager.ServiceComponent.TraceWarning(Resources.MsgReliableServiceBusClientRetryConditions, ServiceHost.Description.Name, lastException.Message, currentRetryCount);
            }
        }

        private void HandleServiceHostFaultedState(object sender, EventArgs e)
        {
            // Unbind from the all event handler.
            DettachEventHandlers(ServiceHost);

            // Allow user-code to participate in the Faulted event handling.
            HandleFaultedEvent(sender, e);

            // Recycle and reopen the host.
            Abort();

            // Declare a failover host which we will be attempting to spin off.
            ServiceHost failoverHost = null;

            // Attempt to open the failover host.
            this.retryPolicy.ExecuteAction(() =>
            {
                try
                {
                    if (null == failoverHost)
                    {
                        // Create and initialize a failover host based on the original service host configuration.
                        failoverHost = CreateFailoverHost();
                    }

                    // Attempt to open the newly initialized service host.
                    failoverHost.Open(failoverHost.OpenTimeout);
                }
                finally
                {
                    if (failoverHost.State == CommunicationState.Faulted)
                    {
                        try
                        {
                            failoverHost.Abort();
                        }
                        catch
                        {
                            // It is acceptable to ignore any exceptions within this context.
                        }
                        finally
                        {
                            failoverHost = null;
                        }
                    }
                }
            });

            // Ensure that all standard event handlers are attached to the new service.
            AttachEventHandlers(failoverHost);

            // Activate the new service host as a failover host.
            this.failoverServiceHost = failoverHost;
        }

        private ServiceHost CreateFailoverHost()
        {
            // If a Service Bus endpoint is known, we can simply ask the factory object to create a new service host.
            if (this.sbEndpointInfo != null)
            {
                return ServiceBusHostFactory.CreateServiceBusHost<T>(this.sbEndpointInfo);
            }
            else
            {
                // Create a new service host depending on whether or not the original service host was hosting a singleton.
                ServiceHost newHost = ServiceHost.SingletonInstance != null ? new ServiceHost(ServiceHost.SingletonInstance) : new ServiceHost(typeof(T));

                // Clone the endpoint information into the new service host.
                foreach (var endpoint in ServiceHost.Description.Endpoints)
                {
                    if (!newHost.Description.Endpoints.Contains(endpoint))
                    {
                        newHost.Description.Endpoints.Add(endpoint);
                    }
                }

                // Clone the behavior information into the new service host.
                foreach (var behavior in ServiceHost.Description.Behaviors)
                {
                    if (!newHost.Description.Behaviors.Contains(behavior.GetType()))
                    {
                        newHost.Description.Behaviors.Add(behavior);
                    }
                }

                // Clone the extension information into the new service host.
                foreach (var extension in ServiceHost.Extensions)
                {
                    if (!newHost.Extensions.Contains(extension))
                    {
                        newHost.Extensions.Add(extension);
                    }
                }

                // Clone other service host settings and properties.
                newHost.Description.Name = ServiceHost.Description.Name;
                newHost.Description.Namespace = ServiceHost.Description.Namespace;
                newHost.Description.ConfigurationName = ServiceHost.Description.ConfigurationName;
                newHost.OpenTimeout = ServiceHost.OpenTimeout;
                newHost.CloseTimeout = ServiceHost.CloseTimeout;

                return newHost;
            }
        }

        private void HandleOpeningEvent(object sender, EventArgs e)
        {
            if (Opening != null)
            {
                Opening(sender, e);
            }
        }

        private void HandleOpenedEvent(object sender, EventArgs e)
        {
            if (Opened != null)
            {
                Opened(sender, e);
            }
        }

        private void HandleFaultedEvent(object sender, EventArgs e)
        {
            if (Faulted != null)
            {
                Faulted(sender, e);
            }
        }

        private void HandleClosingEvent(object sender, EventArgs e)
        {
            if (Closing != null)
            {
                Closing(sender, e);
            }
        }

        private void HandleClosedEvent(object sender, EventArgs e)
        {
            if (Closed != null)
            {
                Closed(sender, e);
            }
        }

        private void AttachEventHandlers(ServiceHost host)
        {
            Guard.ArgumentNotNull(host, "host");

            host.Opening += HandleOpeningEvent;
            host.Opened += HandleOpenedEvent;
            host.Faulted += HandleServiceHostFaultedState;
            host.Closing += HandleClosingEvent;
            host.Closed += HandleClosedEvent;
        }

        private void DettachEventHandlers(ServiceHost host)
        {
            Guard.ArgumentNotNull(host, "host");

            host.Opening -= HandleOpeningEvent;
            host.Opened -= HandleOpenedEvent;
            host.Faulted -= HandleServiceHostFaultedState;
            host.Closing -= HandleClosingEvent;
            host.Closed -= HandleClosedEvent;
        }
        #endregion
    }
}
