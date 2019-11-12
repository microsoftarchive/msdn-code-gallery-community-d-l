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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Extensions
{
    #region Using references
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    #region ICloudQueueServiceWorkerRoleExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for listening on a Windows Azure queue.
    /// </summary>
    public interface ICloudQueueServiceWorkerRoleExtension : ICloudServiceComponentExtension, IObserver<CloudQueueWorkDetectedTriggerEvent>
    {
        /// <summary>
        /// Starts a multi-threaded queue listener that uses the specified number of dequeue threads.
        /// </summary>
        /// <param name="threadCount">The number of dequeue threads.</param>
        void StartListener(int threadCount);

        /// <summary>
        /// Returns the current state of the queue listener to determine point-in-time load characteristics.
        /// </summary>
        /// <returns>An instance of the data object containing the point-in-time load characteristics.</returns>
        CloudQueueListenerInfo QueryState();

        /// <summary>
        /// Gets or sets the batch size when performing dequeue operation against a Windows Azure queue.
        /// </summary>
        int DequeueBatchSize { get; set; }

        /// <summary>
        /// Gets or sets the time interval that defines how long the queue listener will be idle for between polling a Windows Azure queue.
        /// </summary>
        TimeSpan DequeueInterval { get; set; }

        /// <summary>
        /// Defines a callback delegate which will be invoked whenever the queue is empty.
        /// </summary>
        event WorkCompletedDelegate QueueEmpty;

        /// <summary>
        /// Defines a callback delegate which will be invoked whenever a new work has arrived to a queue while the queue listener was idle.
        /// </summary>
        event WorkDetectedDelegate QueueWorkDetected;
    }
    #endregion

    #region ICloudQueueListenerExtension interface
    /// <summary>
    /// Defines a contract that must be supported by an extension that implements a generics-aware queue listener.
    /// </summary>
    /// <typeparam name="T">The type of queue item data that will be handled by the queue listener.</typeparam>
    public interface ICloudQueueListenerExtension<T> : ICloudQueueServiceWorkerRoleExtension, IObservable<T>
    {
        /// <summary>
        /// Returns the metadata object describing location of the queue in the Windows Azure storage infrastructure.
        /// </summary>
        CloudQueueLocation QueueLocation { get; }
    }
    #endregion

    #region CloudQueueListenerInfo class
    /// <summary>
    /// Implements a structure containing point-in-time load characteristics for a given queue listener.
    /// </summary>
    public struct CloudQueueListenerInfo
    {
        /// <summary>
        /// Returns the approximate number of items in the Windows Azure queue.
        /// </summary>
        public int CurrentQueueDepth { get; internal set; }

        /// <summary>
        /// Returns the number of dequeue tasks that are actively performing work or waiting for work.
        /// </summary>
        public int ActiveDequeueTasks { get; internal set; }

        /// <summary>
        /// Returns the maximum number of dequeue tasks that were active at a time.
        /// </summary>
        public int TotalDequeueTasks { get; internal set; }
    }
    #endregion

    #region Delegate declarations
    /// <summary>
    /// Defines a callback delegate which will be invoked whenever an unit of work has been completed and the worker is requesting further
    /// instructions as to next steps.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="idleCount">The value indicating how many times the worker has been idle.</param>
    /// <param name="delay">The time interval during which the worker will be instructed to sleep before performing next unit of work.</param>
    /// <returns>A boolean flag indicating that the worker should stop processing any further units of work and must terminate.</returns>
    public delegate bool WorkCompletedDelegate(object sender, int idleCount, out TimeSpan delay);

    /// <summary>
    /// Defines a callback delegate which will be invoked whenever a new work has arrived to a queue while the queue listener was idle.
    /// This delegate helps track state transitions from an empty to a non-empty queue for the purposes of triggering relevant actions such as auto-scaling.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    public delegate void WorkDetectedDelegate(object sender);
    #endregion

    /// <summary>
    /// Implements a generics-aware listener for a Windows Azure queue.
    /// </summary>
    /// <typeparam name="T">The type of queue item data that will be handled by the queue listener.</typeparam>
    public class CloudQueueListenerExtension<T> : ICloudQueueListenerExtension<T>
    {
        #region Private members
        private const int DefaultDequeueBatchSize = 20;
        private const int DefaultDequeueMaxReceiveInterval = 1000;

        private readonly CancellationTokenSource cancellationSignal = new CancellationTokenSource();
        private readonly ConcurrentBag<Task> dequeueTaskList = new ConcurrentBag<Task>();
        private readonly object initLock = new object();

        private BlockingCollection<Task> dequeueTasks;
        private BlockingCollection<QueueSubscriptionInfo<T>> subscriptions;
        private CloudQueueLocation queueLocation;
        private ICloudQueueStorage queueStorage;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a queue listener that will be listening to messages arriving to the specified queue.
        /// </summary>
        /// <param name="queueLocation">The location of a queue in the Windows Azure storage infrastructure.</param>
        public CloudQueueListenerExtension(CloudQueueLocation queueLocation)
        {
            Guard.ArgumentNotNull(queueLocation, "queueLocation");
            Guard.ArgumentNotNullOrEmptyString(queueLocation.QueueName, "queueLocation.QueueName");

            this.queueLocation = queueLocation;
            this.dequeueTasks = new BlockingCollection<Task>(this.dequeueTaskList);
            this.DequeueBatchSize = DefaultDequeueBatchSize;
            this.DequeueInterval = TimeSpan.FromMilliseconds(DefaultDequeueMaxReceiveInterval);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the batch size when performing dequeue operation against a Windows Azure queue.
        /// </summary>
        public int DequeueBatchSize { get; set; }

        /// <summary>
        /// Gets or sets the time interval that defines how long the queue listener will be idle for between polling a Windows Azure queue.
        /// </summary>
        public TimeSpan DequeueInterval { get; set; }

        /// <summary>
        /// An instance of a callback delegate which will be invoked whenever the queue is empty upon completing the dequeue operation.
        /// </summary>
        public event WorkCompletedDelegate QueueEmpty;

        /// <summary>
        /// An instance of a callback delegate which will be invoked whenever a new work has arrived to a queue while the queue listener was idle.
        /// </summary>
        public event WorkDetectedDelegate QueueWorkDetected;

        /// <summary>
        /// Returns the metadata object describing location of the queue in the Windows Azure storage infrastructure.
        /// </summary>
        public CloudQueueLocation QueueLocation
        {
            get { return this.queueLocation;  }
        }
        #endregion

        #region Private properties
        private BlockingCollection<QueueSubscriptionInfo<T>> Subscriptions 
        { 
            get
            {
                if (null == this.subscriptions)
                {
                    lock (this.initLock)
                    {
                        if (null == this.subscriptions)
                        {
                            this.subscriptions = new BlockingCollection<QueueSubscriptionInfo<T>>();
                        }
                    }
                }

                return this.subscriptions;
            }
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(this.queueLocation.StorageAccount, this.queueLocation.QueueName);

            try
            {
                owner.Extensions.Demand<ICloudStorageProviderExtension>();

                if (!this.queueLocation.IsDiscoverable)
                {
                    var queueLocationResolvers = owner.Extensions.FindAll<ICloudQueueLocationResolverExtension>();

                    foreach (ICloudQueueLocationResolverExtension locationResolver in queueLocationResolvers)
                    {
                        this.queueLocation = locationResolver.GetQueueLocation(this.queueLocation.QueueName);

                        if (this.queueLocation.IsDiscoverable) break;
                    }
                }

                if (this.queueLocation.IsDiscoverable)
                {
                    ICloudStorageProviderExtension storageProvider = owner.Extensions.Find<ICloudStorageProviderExtension>();

                    this.queueStorage = storageProvider.GetQueueStorage(this.queueLocation.StorageAccount);
                    
                    // Ensure that the queue is available, create a new queue if one doesn't exist.
                    this.queueStorage.CreateQueue(this.queueLocation.QueueName);
                }
                else
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.CloudQueueNotDiscoverable, this.queueLocation.QueueName));
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(this.queueLocation.StorageAccount, this.queueLocation.QueueName);

            try
            {
                // Communicate a request for cancellation of all running dequeue tasks.
                cancellationSignal.Cancel();

                foreach (var task in this.dequeueTasks)
                {
                    var taskStopScopeStart = TraceManager.WorkerRoleComponent.TraceStartScope(String.Format(CultureInfo.CurrentCulture, TraceLogMessages.ScopeCloudQueueListenerExtensionStopDequeueTask, task.Id, task.Status), callToken);

                    try
                    {
                        // Block until the task completes (if it's running).
                        if (task.Status != TaskStatus.Canceled && task.Status != TaskStatus.Faulted && task.Status != TaskStatus.RanToCompletion)
                        {
                            task.Wait();
                        }
                    }
                    catch (AggregateException)
                    {
                        // Should ensure a safe stop, just ignore this exception and don't let it damage the rest of the Detach logic.
                    }
                    catch (OperationCanceledException)
                    {
                        // Should ensure a safe stop, just ignore this exception and don't let it damage the rest of the Detach logic.
                    }
                    catch (Exception ex)
                    {
                        // Should ensure a safe stop, just log an exception and don't let it damage the rest of the Detach logic.
                        TraceManager.WorkerRoleComponent.TraceError(ex);
                    }
                    finally
                    {
                        TraceManager.WorkerRoleComponent.TraceEndScope(String.Format(CultureInfo.CurrentCulture, TraceLogMessages.ScopeCloudQueueListenerExtensionStopDequeueTask, task.Id, task.Status), taskStopScopeStart, callToken);

                        task.Dispose();
                    }
                }

                if (this.subscriptions != null)
                {
                    this.subscriptions.Dispose();
                    this.subscriptions = null;
                }

                if (this.queueStorage != null)
                {
                    this.queueStorage.Dispose();
                    this.queueStorage = null;
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region IObservable<T> implementation
        /// <summary>
        /// Notifies the provider that an observer is ready to receive notifications.
        /// </summary>
        /// <param name="subscriber">The object that is to receive notifications.</param>
        /// <returns>The observer's interface that enables resources to be disposed.</returns>
        public IDisposable Subscribe(IObserver<T> subscriber)
        {
            QueueSubscriptionInfo<T> subscription = new QueueSubscriptionInfo<T>(subscriber);
            Subscriptions.Add(subscription, this.cancellationSignal.Token);
            
            return subscription;
        }
        #endregion

        #region IObserver<CloudQueueNewPayloadTriggerEvent> implementation
        /// <summary>
        /// Gets called by the provider to notify this queue listener about a new trigger event.
        /// </summary>
        /// <param name="e">The trigger event indicating that a new payload was put in a queue.</param>
        public void OnNext(CloudQueueWorkDetectedTriggerEvent e)
        {
            Guard.ArgumentNotNull(e, "e");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(e.StorageAccount, e.QueueName, e.PayloadSize);

            try
            {
                // Make sure the trigger event is for the queue managed by this listener, otherwise ignore.
                if (this.queueLocation.StorageAccount == e.StorageAccount && this.queueLocation.QueueName == e.QueueName)
                {
                    if (QueueWorkDetected != null)
                    {
                        QueueWorkDetected(this);
                    }
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Gets called by the provider to indicate that it has finished sending notifications to observers.
        /// </summary>
        public void OnCompleted()
        {
        }

        /// <summary>
        /// Gets called by the provider to indicate that data is unavailable, inaccessible, or corrupted, 
        /// or that the provider has experienced some other error condition.
        /// </summary>
        /// <param name="error">The exception that resulted in an error condition.</param>
        public void OnError(Exception error)
        {
        }
        #endregion

        #region ICloudQueueServiceWorkerRoleExtension implementation
        /// <summary>
        /// Starts a multi-threaded queue listener that uses the specified number of dequeue threads.
        /// </summary>
        /// <param name="threadCount">The number of dequeue threads.</param>
        public void StartListener(int threadCount)
        {
            Guard.ArgumentNotZeroOrNegativeValue(threadCount, "threadCount");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(this.queueLocation.StorageAccount, this.queueLocation.QueueName, threadCount);

            try
            {
                // The collection of dequeue tasks needs to be reset on each call to this method.
                if (this.dequeueTasks.IsAddingCompleted)
                {
                    this.dequeueTasks = new BlockingCollection<Task>(this.dequeueTaskList);
                }
                
                for (int i = 0; i < threadCount; i++)
                {
                    CancellationToken cancellationToken = this.cancellationSignal.Token;
                    CloudQueueListenerDequeueTaskState<T> workerState = new CloudQueueListenerDequeueTaskState<T>(Subscriptions, cancellationToken, this.queueLocation, this.queueStorage);

                    // Start a new dequeue task and register it in the collection of tasks internally managed by this component.
                    this.dequeueTasks.Add(Task.Factory.StartNew(DequeueTaskMain, workerState, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default));
                }

                // Mark this collection as not accepting any more additions.
                this.dequeueTasks.CompleteAdding();
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Returns the current state of the queue listener to determine point-in-time load characteristics.
        /// </summary>
        /// <returns>An instance of the data object containing the point-in-time load characteristics.</returns>
        public CloudQueueListenerInfo QueryState()
        {
            return new CloudQueueListenerInfo()
            {
                CurrentQueueDepth = this.queueStorage.GetCount(this.queueLocation.QueueName),
                ActiveDequeueTasks = (from task in this.dequeueTasks where task.Status != TaskStatus.Canceled && task.Status != TaskStatus.Faulted && task.Status != TaskStatus.RanToCompletion select task).Count(),
                TotalDequeueTasks = this.dequeueTasks.Count
            };
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Implements a task performing dequeue operations against a given Windows Azure queue.
        /// </summary>
        /// <param name="state">An object containing data to be used by the task.</param>
        private void DequeueTaskMain(object state)
        {
            CloudQueueListenerDequeueTaskState<T> workerState = (CloudQueueListenerDequeueTaskState<T>)state;

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(workerState.QueueLocation.StorageAccount, workerState.QueueLocation.QueueName);
            
            int idleStateCount = 0;
            TimeSpan sleepInterval = DequeueInterval;

            try
            {
                // Run a dequeue task until asked to terminate or until a break condition is encountered.
                while (workerState.CanRun)
                {
                    try
                    {
                        var queueMessages = from msg in workerState.QueueStorage.Get<T>(workerState.QueueLocation.QueueName, DequeueBatchSize, workerState.QueueLocation.VisibilityTimeout).AsParallel() where msg != null select msg;
                        int messageCount = 0;

                        // Check whether or not work items arrived to a queue while the listener was idle.
                        if (idleStateCount > 0 && queueMessages.Count() > 0)
                        {
                            if (QueueWorkDetected != null)
                            {
                                QueueWorkDetected(this);
                            }
                        }

                        // Process the dequeued messages concurrently by taking advantage of the above PLINQ query.
                        queueMessages.ForAll((message) =>
                        {
                            // Reset the count of idle iterations.
                            idleStateCount = 0;

                            // Notify all subscribers that a new message requires processing.
                            workerState.OnNext(message);

                            // Once successful, remove the processed message from the queue.
                            workerState.QueueStorage.Delete<T>(message);

                            // Increment the number of processed messages.
                            messageCount++;
                        });

                        // Check whether or not we have done any work during this iteration.
                        if (0 == messageCount)
                        {
                            // Increment the number of iterations when we were not doing any work (e.g. no messages were dequeued).
                            idleStateCount++;

                            // Call the user-defined delegate informing that no more work is available.
                            if (QueueEmpty != null)
                            {
                                // Check if the user-defined delegate has requested a halt to any further work processing.
                                if (QueueEmpty(this, idleStateCount, out sleepInterval))
                                {
                                    TraceManager.WorkerRoleComponent.TraceInfo(String.Format(CultureInfo.CurrentCulture, TraceLogMessages.CloudQueueListenerTerminatedWithNoMoreWork, this.queueLocation.QueueName, this.queueLocation.StorageAccount));
                                    
                                    // Terminate the dequeue loop if user-defined delegate advised us to do so.
                                    break;
                                }
                            }

                            // Enter the idle state for the defined interval.
                            Thread.Sleep(sleepInterval);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is OperationCanceledException)
                        {
                            throw;
                        }
                        else
                        {
                            // Offload the responsibility for handling or reporting the error to the external object.
                            workerState.OnError(ex);

                            // Sleep for the specified interval to avoid a flood of errors.
                            Thread.Sleep(sleepInterval);
                        }
                    }
                }
            }
            finally
            {
                workerState.OnCompleted();
                TraceManager.WorkerRoleComponent.TraceOut(callToken, workerState.QueueLocation.StorageAccount, workerState.QueueLocation.QueueName);
            }
        }

        /// <summary>
        /// Returns the number of queue tasks that would be required to handle the payload in a queue given its current depth.
        /// </summary>
        /// <param name="queueName">The name of the queue on which a new payload was put.</param>
        /// <param name="payloadSize">The size of the queue's payload (e.g. the approximate size of an individual message).</param>
        /// <param name="currentDepth">The approximate number of items in the queue.</param>
        /// <returns>The optimal number of dequeue tasks.</returns>
        private int GetOptimalDequeueTaskCount(string queueName, long payloadSize, int currentDepth)
        {
            // Perform basic decision making to determine the number of dequeue tasks for handling "small" messages.
            if (payloadSize < 102400)
            {
                if (currentDepth < 100) return 10;
                if (currentDepth >= 100 && currentDepth < 1000) return 50;
                if (currentDepth >= 1000) return 100;
            }

            // Perform basic decision making to determine the number of dequeue tasks for handling "large" messages.
            if (payloadSize >= 102400)
            {
                if (currentDepth < 100) return 100;
                if (currentDepth >= 100 && currentDepth < 1000) return 250;
                if (currentDepth >= 1000) return 500;
            }

            // Return the minimum acceptable count.
            return 1;
        }
        #endregion

        #region QueueSubscriptionInfo class definition
        private sealed class QueueSubscriptionInfo<I> : IDisposable
        {
            private readonly IObserver<I> subscriber;
            private volatile bool disposed;

            public QueueSubscriptionInfo(IObserver<I> subscriber)
            {
                this.subscriber = subscriber;
            }

            public bool IsActive
            {
                get { return !this.disposed; }
            }

            public IObserver<I> Subscriber
            {
                get { return this.subscriber; }
            }

            public void Dispose()
            {
                this.disposed = true;
            }
        }
        #endregion

        #region CloudQueueListenerBackgroundWorkerState class definition
        private sealed class CloudQueueListenerDequeueTaskState<TItem> : IObserver<TItem>
        {
            #region Private members
            private readonly IEnumerable<QueueSubscriptionInfo<TItem>> subscriptions;
            private readonly CancellationToken cancellationToken;
            private readonly CloudQueueLocation queueLocation;
            private readonly ICloudQueueStorage queueStorage;
            #endregion

            #region Constructor
            public CloudQueueListenerDequeueTaskState(IEnumerable<QueueSubscriptionInfo<TItem>> subscriptions, CancellationToken cancellationToken, CloudQueueLocation queueLocation, ICloudQueueStorage queueStorage)
            {
                Guard.ArgumentNotNull(subscriptions, "subscriptions");
                Guard.ArgumentNotNull(cancellationToken, "cancellationToken");
                Guard.ArgumentNotNull(queueLocation, "queueLocation");
                Guard.ArgumentNotNull(queueStorage, "queueStorage");

                this.subscriptions = subscriptions;
                this.cancellationToken = cancellationToken;
                this.queueLocation = queueLocation;
                this.queueStorage = queueStorage;
            }
            #endregion

            #region Public properties
            public bool CanRun
            {
                get { return !this.cancellationToken.IsCancellationRequested; }
            }

            public CloudQueueLocation QueueLocation
            {
                get { return this.queueLocation; }
            }

            public ICloudQueueStorage QueueStorage
            {
                get { return this.queueStorage; }
            }
            #endregion

            #region IObserver<S> implementation
            /// <summary>
            /// Gets called by the provider to indicate that it has finished sending notifications to observers.
            /// </summary>
            public void OnCompleted()
            {
                foreach (QueueSubscriptionInfo<TItem> subscription in this.subscriptions)
                {
                    if (subscription.IsActive)
                    {
                        subscription.Subscriber.OnCompleted();
                    }
                }

                this.cancellationToken.ThrowIfCancellationRequested();
            }

            /// <summary>
            /// Gets called by the provider to indicate that data is unavailable, inaccessible, or corrupted, 
            /// or that the provider has experienced some other error condition.
            /// </summary>
            /// <param name="error">The exception that resulted in an error condition.</param>
            public void OnError(Exception error)
            {
                TraceManager.WorkerRoleComponent.TraceError(error);

                foreach (QueueSubscriptionInfo<TItem> subscription in this.subscriptions)
                {
                    if (subscription.IsActive)
                    {
                        subscription.Subscriber.OnError(error);
                    }
                }
            }

            public void OnNext(TItem item)
            {
                int subscriptionMatched = 0;

                foreach (QueueSubscriptionInfo<TItem> subscription in this.subscriptions)
                {
                    if (subscription.IsActive)
                    {
                        subscription.Subscriber.OnNext(item);
                    }

                    subscriptionMatched++;
                }

                if (0 == subscriptionMatched)
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.SubscribersNotFound, this.queueLocation.QueueName, this.queueLocation.StorageAccount));
                }
            }
            #endregion
        }
        #endregion
    }
}