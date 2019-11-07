//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ResponseLimitedConcurrencyTaskScheduler.cs
//
//--------------------------------------------------------------------------

namespace MSDN.Schedulers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides a task scheduler that ensures a maximum concurrency level while running on top of the ThreadPool.</summary>
    public sealed class ResponseLimitedConcurrencyTaskScheduler : TaskScheduler, IDisposable
    {
        /// <summary>Values defining the current state of the scheduler.</summary>
        public struct ExecutionState
        {
            /// <summary>Gets the current Max Degree of Parallelism.</summary>
            public int MaxDegreeOfParallelism { get; internal set; }

            /// <summary>Gets the current level of concurrency.</summary>
            public int CurrentConcurrency { get; internal set; }

            /// <summary>Gets the current count of awaiting task.</summary>
            public int AwaitingTasks { get; internal set; }

            /// <summary>Gets the last sampled average of the execution times.</summary>
            public int LastSampledAverage { get; internal set; }
        }

        /// <summary>Whether the current thread is processing work items.</summary>
        [ThreadStatic]
        private static bool CurrentThreadIsProcessingItems;

        /// <summary>Scheduler running configuration.</summary>
        private readonly ResponseLimitedConcurrencyTaskConfiguration configuration;

        /// <summary>The list of tasks to be executed.</summary>
        private readonly LinkedList<Task> tasks = new LinkedList<Task>(); // protected by lock(_tasks)

        /// <summary>The maximum concurrency level allowed by this scheduler for the current response times.</summary>
        private volatile int maxDegreeOfParallelism;

        /// <summary>Last sampled average of the execution times.</summary>
        private volatile int lastSampledAverage;

        /// <summary>Whether the scheduler is currently processing work items.</summary>
        private int delegatesQueuedOrRunning = 0; // protected by lock(_tasks)

        /// <summary>Stack for holding execution times for calculating MDOP </summary>
        private ConcurrentStack<int> timings = new ConcurrentStack<int>();

        /// <summary>Object to ensure MDOP is only set on a single thread.</summary>
        private object timingsSync = new object();

        /// <summary>Function determining the MDOP, where a zero average gives the starting MDOP.</summary>
        private Func<int, int> funcMdop;

        /// <summary>The timer for refreshing the scheduler MDOP.</summary>
        private Timer refreshTimer;

        /// <summary>Indicator for whether Dispose has been called.</summary>
        private bool disposed = false;

        /// <summary> Initializes a new instance of the ResponseLimitedConcurrencyTaskScheduler class with the specified MDOP function. </summary>
        /// <param name="maxDegreeOfParallelism">The maximum degree of parallelism function provider for this scheduler.</param>
        /// <param name="configuration">Scheduler configuration.</param>
        public ResponseLimitedConcurrencyTaskScheduler(Func<int, int> funcMdop, ResponseLimitedConcurrencyTaskConfiguration configuration)
        {
            // Finally ensure zero average gives a starting MDOP
            if (funcMdop(0) < 0) { throw new ArgumentOutOfRangeException("funcMdop", "Calculated Zero Max Degree of Parallelism cannot be negative."); }

            this.funcMdop = funcMdop;
            this.configuration = configuration;

            // Get the default MDOP
            int mdop = this.funcMdop(0);
            this.maxDegreeOfParallelism = mdop == 0 ? this.configuration.DefaultDegreeOfParallelism : mdop;
            this.lastSampledAverage = 0;

            // Setup the refresh of the MDOP
            int rate = this.configuration.SamplingRateMilliseconds;
            this.refreshTimer = new Timer(state => this.SetMdop(), null, rate + 1000, rate);
        }

        /// <summary>Initializes a new instance of the ResponseLimitedConcurrencyTaskScheduler class with the specified MDOP function.</summary>
        /// <param name="maxDegreeOfParallelism">The maximum degree of parallelism function provider for this scheduler.</param>
        public ResponseLimitedConcurrencyTaskScheduler(Func<int, int> funcMdop)
            : this(funcMdop, new ResponseLimitedConcurrencyTaskConfiguration())
        {
        }

        /// <summary> Define the MDOP based on the current state of the execution times. </summary>
        private void SetMdop()
        {
            if (this.timings != null && this.timings.Count > this.configuration.MinimumSampleCount)
            {
                lock (this.timingsSync)
                {
                    if (this.timings != null && this.timings.Count > this.configuration.MinimumSampleCount)
                    {
                        int[] latestTimes = new int[this.configuration.AverageSampleCount];
                        int count = this.timings.TryPopRange(latestTimes);

                        if (count > this.configuration.MinimumSampleCount)
                        {
                            this.timings.Clear();
                            int average = (int)latestTimes.Take(count).Average();
                            int mdop = this.funcMdop(average);

                            this.lastSampledAverage = average;
                            if (mdop > 0) { this.maxDegreeOfParallelism = mdop <= 0 ? this.configuration.DefaultDegreeOfParallelism : mdop; }
                        }
                    }
                }
            }
        }

        /// <summary>Attempts to execute the specified task recording execution time.</summary>
        /// <param name="task">The task to be executed.</param>
        /// <returns>Whether the task could be executed on the current thread.</returns>
        private bool TryExecuteTaskInternal(Task task)
        {
            Stopwatch sw = Stopwatch.StartNew();

            bool result = base.TryExecuteTask(task);

            sw.Stop();
            TimeSpan timing = sw.Elapsed;

            // Ensure queue is not growing too much before adding timing
            if (this.timings.Count < this.configuration.MaximumSampleCount) { this.timings.Push((int)timing.TotalMilliseconds); }

            return result;
        }

        /// <summary>Queues a task to the scheduler.</summary>
        /// <param name="task">The task to be queued.</param>
        protected override void QueueTask(Task task)
        {
            // Add the task to the list of tasks to be processed.  If there aren't enough
            // delegates currently queued or running to process tasks, schedule another.
            lock (this.tasks)
            {
                this.tasks.AddLast(task);
                if (this.delegatesQueuedOrRunning < this.maxDegreeOfParallelism)
                {
                    ++this.delegatesQueuedOrRunning;
                    this.NotifyThreadPoolOfPendingWork();
                }
            }
        }

        /// <summary> Informs the ThreadPool that there's work to be executed for this scheduler. </summary>
        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                // Note that the current thread is now processing work items.
                // This is necessary to enable inlining of tasks into this thread.
                CurrentThreadIsProcessingItems = true;
                try
                {
                    // Process all available items in the queue.
                    while (true)
                    {
                        Task item;
                        lock (this.tasks)
                        {
                            // When there are no more items to be processed,
                            // or if running with too much concurrency,
                            // note that we're done processing, and get out.
                            if (this.tasks.Count == 0 || this.delegatesQueuedOrRunning > this.maxDegreeOfParallelism)
                            {
                                --this.delegatesQueuedOrRunning;
                                break;
                            }

                            // Get the next item from the queue
                            item = this.tasks.First.Value;
                            this.tasks.RemoveFirst();
                        }

                        // Execute the task we pulled out of the queue
                        this.TryExecuteTaskInternal(item);
                    }
                }

                // We're done processing items on the current thread
                finally
                {
                    CurrentThreadIsProcessingItems = false;
                }
            }, null);
        }

        /// <summary>Attempts to execute the specified task on the current thread.</summary>
        /// <param name="task">The task to be executed.</param>
        /// <param name="taskWasPreviouslyQueued">Indicator for whether the task was previously dequeued.</param>
        /// <returns>Whether the task could be executed on the current thread.</returns>
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // If this thread isn't already processing a task, we don't support inlining
            if (!CurrentThreadIsProcessingItems) { return false; }

            // If the task was previously queued, remove it from the queue
            if (taskWasPreviouslyQueued) this.TryDequeue(task);

            // Try to run the task.
            return this.TryExecuteTaskInternal(task);
        }

        /// <summary>Attempts to remove a previously scheduled task from the scheduler.</summary>
        /// <param name="task">The task to be removed.</param>
        /// <returns>Whether the task could be found and removed.</returns>
        protected override bool TryDequeue(Task task)
        {
            lock (this.tasks)
            {
                return this.tasks.Remove(task);
            }
        }

        /// <summary>Gets the maximum concurrency level supported by this scheduler.</summary>
        public override int MaximumConcurrencyLevel
        {
            get
            {
                return this.maxDegreeOfParallelism;
            }
        }

        /// <summary>Gets an enumerable of the tasks currently scheduled on this scheduler.</summary>
        /// <returns>An enumerable of the tasks currently scheduled.</returns>
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(this.tasks, ref lockTaken);

                if (lockTaken)
                {
                    return this.tasks.ToArray();
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            finally
            {
                if (lockTaken) { Monitor.Exit(this.tasks); }
            }
        }

        /// <summary>Gets the current Execution State of the scheduler.</summary>
        public ExecutionState SchedulerExecutionState
        {
            get
            {
                ExecutionState state = new ExecutionState();
                state.LastSampledAverage = this.lastSampledAverage;
                state.MaxDegreeOfParallelism = this.maxDegreeOfParallelism;
                state.CurrentConcurrency = this.delegatesQueuedOrRunning;
                state.AwaitingTasks = this.tasks.Count;

                return state;
            }
        }

        /// <summary>Gets the current Configuration of the scheduler.</summary>
        public ResponseLimitedConcurrencyTaskConfiguration SchedulerTaskConfiguration
        {
            get
            {
                return this.configuration;
            }
        }

        /// <summary>Gets a value indicating whether the scheduler is processing.</summary>
        public bool IsProcessing
        {
            get
            {
                return this.tasks.Count > 0 || this.delegatesQueuedOrRunning > 0;
            }
        }

        /// <summary>Method to control the disposing of resources. </summary>
        /// <param name="disposing">Indicator for whether Dispose has been called directly.</param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.refreshTimer != null)
                    {
                        this.refreshTimer.Dispose();
                    }
                }

                // Indicate that the instance has been disposed.
                this.refreshTimer = null;
                this.disposed = true;
            }
        }

        /// <summary>IDisposable Dispose method.</summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}