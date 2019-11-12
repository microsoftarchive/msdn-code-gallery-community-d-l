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
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Implements the reliability layer between the Windows Azure Service Bus and client code to ensure that all major operations 
    /// against WCF infrastructure such as creating and opening a client communication channel will respect potential transient 
    /// conditions that may manifest themselves in a highly multi-tenant hosting environment such as Windows Azure.
    /// </summary>
    /// <typeparam name="T">The type of client channel contract. Must inherit from service contract as well as <see cref="System.ServiceModel.IClientChannel"/>.</typeparam>
    public sealed class ReliableServiceBusClient<T> : ICommunicationObject, IDisposable where T : IClientChannel
    {
        #region Private members
        private const int DefaultOpenTimeoutSec = 60 * 5;

        private readonly RetryPolicy retryPolicy;
        private readonly ChannelFactory<T> channelFactory;
        private readonly ServiceBusEndpointInfo sbEndpointInfo;
        
        private bool disposed;
        private T clientChannel;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Service Bus client component to communicate with the specified Service Bus endpoint.
        /// No retry policy will be enforced when using this constructor overload.
        /// </summary>
        /// <param name="sbEndpointInfo">The endpoint details.</param>
        public ReliableServiceBusClient(ServiceBusEndpointInfo sbEndpointInfo)
            : this(sbEndpointInfo, RetryPolicy.NoRetry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Service Bus client component to communicate with the specified Service Bus endpoint
        /// using a custom retry policy.
        /// </summary>
        /// <param name="sbEndpointInfo">The endpoint details.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying WCF infrastructure.</param>
        public ReliableServiceBusClient(ServiceBusEndpointInfo sbEndpointInfo, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            this.sbEndpointInfo = sbEndpointInfo;
            this.channelFactory = ServiceBusClientFactory.CreateServiceBusClientChannelFactory<T>(sbEndpointInfo);
            
            this.clientChannel = this.channelFactory.CreateChannel();
            this.clientChannel.Opening += new EventHandler(HandleOpeningEvent);
            this.clientChannel.Opened += new EventHandler(HandleOpenedEvent);
            this.clientChannel.Faulted += new EventHandler(HandleFaultedEvent);
            this.clientChannel.Closing += new EventHandler(HandleClosingEvent);
            this.clientChannel.Closed += new EventHandler(HandleClosedEvent);
            
            this.retryPolicy = retryPolicy;
            this.retryPolicy.RetryOccurred += HandleRetryState;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns an instance of the client communication channel that can be used for invoking the service operations.
        /// </summary>
        public T Client
        {
            get 
            {
                if (!(this.clientChannel != null && this.clientChannel.State == CommunicationState.Opened))
                {
                    Open();
                }

                return this.clientChannel;  
            }
        }

        /// <summary>
        /// Returns the retry policy that is being used for ensuring reliable access to the underlying WCF infrastructure.
        /// </summary>
        public RetryPolicy RetryPolicy
        {
            get { return this.retryPolicy; }
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~ReliableServiceBusClient()
        {
            this.Dispose(false);
        }

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
                    // Terminating the WCF service client channel.
                    try
                    {
                        if (this.clientChannel != null)
                        {
                            if (this.clientChannel.State == CommunicationState.Opened)
                            {
                                this.clientChannel.Close();
                            }
                            else
                            {
                                this.clientChannel.Abort();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Abort();
                    }

                    // Terminating the WCF service channel factory.
                    try
                    {
                        if (this.channelFactory.State == CommunicationState.Opened)
                        {
                            this.channelFactory.Close();
                        }
                        else
                        {
                            this.channelFactory.Abort();
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            this.channelFactory.Abort();
                        }
                        catch
                        {
                            // It is acceptable to ignore any exceptions within this context.
                        }

                    }

                    this.retryPolicy.RetryOccurred -= HandleRetryState;
                    this.disposed = true;
                }
            }
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
                if (this.clientChannel != null)
                {
                    this.clientChannel.Abort();
                }
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
            return this.clientChannel.BeginClose(timeout, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to close a communication object.
        /// </summary>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous close operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous close operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous close operation.</returns>
        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return this.clientChannel.BeginClose(callback, state);
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
            return this.clientChannel.BeginOpen(timeout, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to open a communication object.
        /// </summary>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous open operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous open operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous open operation.</returns>
        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return this.clientChannel.BeginOpen(callback, state);
        }

        /// <summary>
        /// Causes a communication object to transition from its current state into the closed state.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        public void Close(TimeSpan timeout)
        {
            this.clientChannel.Close(timeout);
        }

        /// <summary>
        /// Causes a communication object to transition from its current state into the closed state.
        /// </summary>
        public void Close()
        {
            this.clientChannel.Close();
        }

        /// <summary>
        /// Completes an asynchronous operation to close a communication object.
        /// </summary>
        /// <param name="result">The System.IAsyncResult that is returned by a call to the System.ServiceModel.ICommunicationObject.BeginClose method.</param>
        public void EndClose(IAsyncResult result)
        {
            this.clientChannel.EndClose(result);
        }

        /// <summary>
        /// Completes an asynchronous operation to open a communication object.
        /// </summary>
        /// <param name="result">The System.IAsyncResult that is returned by a call to the System.ServiceModel.ICommunicationObject.BeginOpen method.</param>
        public void EndOpen(IAsyncResult result)
        {
            this.clientChannel.EndOpen(result);
        }

        /// <summary>
        /// Causes a communication object to transition from the created state into the opened state within a specified interval of time.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        public void Open(TimeSpan timeout)
        {
            this.retryPolicy.ExecuteAction(() =>
            {
                EnsureValidChannel();
                this.clientChannel.Open(timeout);
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
            get { return this.clientChannel.State; }
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

        #region Private methods
        private void HandleRetryState(int currentRetryCount, Exception lastException, TimeSpan delay)
        {
            TraceManager.DebugComponent.TraceWarning(Resources.MsgReliableServiceBusClientRetryConditions, this.sbEndpointInfo.Name, lastException.Message, currentRetryCount);
        }

        private void EnsureValidChannel()
        {
            if (!(this.clientChannel != null && this.clientChannel.State == CommunicationState.Opened))
            {
                TraceManager.DebugComponent.TraceWarning(TraceLogMessages.ServiceClientChannelStateWarning, this.clientChannel.State);

                if (this.clientChannel.State == CommunicationState.Faulted || this.clientChannel.State == CommunicationState.Closed || this.clientChannel.State == CommunicationState.Closing)
                {
                    TraceManager.DebugComponent.TraceWarning(TraceLogMessages.ServiceClientChannelStateResetWarning);

                    Abort();

                    // Recreate a client channel if it was previously marked as Faulted.
                    this.clientChannel = this.channelFactory.CreateChannel();
                }
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
        #endregion
    }
}