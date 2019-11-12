//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: LimitedConcurrencyTaskScheduler.cs
//
//--------------------------------------------------------------------------

namespace MSDN.Schedulers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides a task scheduler that ensures a maximum concurrency level while running on top of the ThreadPool.</summary>
    public sealed class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
    {
        /// <summary>Values defining the current state of the scheduler.</summary>
        public struct ExecutionState
        {
            /// <summary>Gets the current level of concurrency.</summary>
            public int CurrentConcurrency { get; internal set; }

            /// <summary>Gets the current count of awaiting task.</summary>
            public int AwaitingTasks { get; internal set; }
        }

        /// <summary>Whether the current thread is processing work items.</summary>
        [ThreadStatic]
        private static bool CurrentThreadIsProcessingItems;

        /// <summary>The list of tasks to be executed.</summary>
        private readonly LinkedList<Task> tasks = new LinkedList<Task>(); // protected by lock(tasks)

        /// <summary>The maximum concurrency level allowed by this scheduler.</summary>
        private readonly int maxDegreeOfParallelism;

        /// <summary>Whether the scheduler is currently processing work items.</summary>
        private int delegatesQueuedOrRunning = 0; // protected by lock(_tasks)

        /// <summary>Initializes a new instance of the LimitedConcurrencyLevelTaskScheduler class with the specified degree of parallelism.</summary>
        /// <param name="maxDegreeOfParallelism">The maximum degree of parallelism provided by this scheduler.</param>
        public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism < 1) { throw new ArgumentOutOfRangeException("maxDegreeOfParallelism"); }
            this.maxDegreeOfParallelism = maxDegreeOfParallelism;
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

        /// <summary>Informs the ThreadPool that there's work to be executed for this scheduler.</summary>
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
                            // note that we're done processing, and get out.
                            if (this.tasks.Count == 0)
                            {
                                --this.delegatesQueuedOrRunning;
                                break;
                            }

                            // Get the next item from the queue
                            item = this.tasks.First.Value;
                            this.tasks.RemoveFirst();
                        }

                        // Execute the task we pulled out of the queue
                        base.TryExecuteTask(item);
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
            if (taskWasPreviouslyQueued) { this.TryDequeue(task); }

            // Try to run the task.
            return base.TryExecuteTask(task);
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

        /// <summary>Gets an enumerable of the tasks currently scheduled on this scheduler.</summary>
        /// <returns>An enumerable of the tasks currently scheduled.</returns>
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;

            try
            {
                Monitor.TryEnter(this.tasks, ref lockTaken);
                if (lockTaken) { return this.tasks.ToArray(); }
                else { throw new NotSupportedException(); }
            }
            finally
            {
                if (lockTaken) { Monitor.Exit(this.tasks); }
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

        /// <summary>Gets the current Execution State of the scheduler.</summary>
        public ExecutionState SchedulerExecutionState
        {
            get
            {
                ExecutionState state = new ExecutionState();
                state.CurrentConcurrency = this.delegatesQueuedOrRunning;
                state.AwaitingTasks = this.tasks.Count;

                return state;
            }
        }

        /// <summary>Gets a value indicating whether the scheduler is currently processing.</summary>
        public bool IsProcessing
        {
            get
            {
                return this.tasks.Count > 0 || this.delegatesQueuedOrRunning > 0;
            }
        }
    }
}