//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ResponseLimitedConcurrencyActionLoader.cs
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

    /// <summary>A class to load a ResponseLimitedConcurrencyTaskScheduler with a single Action.</summary>
    public class ResponseLimitedConcurrencyActionLoader
    {
        /// <summary>Indicator for whether to continue loading.</summary>
        private volatile bool continueProcessing = false;

        /// <summary>The ResponseLimitedConcurrencyTaskScheduler reference.</summary>
        private ResponseLimitedConcurrencyTaskScheduler scheduler;

        /// <summary>The factory to be used for loading the action.</summary>
        private TaskFactory factory;

        /// <summary>The Task used to load the data on a background thread.</summary>
        private Task loaderTask;

        /// <summary>The interval (in milliseconds) for which to review the outstanding tasks.</summary>
        private int baseInterval;

        /// <summary>Initializes a new instance of the ResponseLimitedConcurrencyActionLoader class.</summary>
        /// <param name="scheduler">The scheduler to load.</param>
        /// <param name="interval">The interval (in milliseconds) for which to perform a load check.</param>
        public ResponseLimitedConcurrencyActionLoader(ResponseLimitedConcurrencyTaskScheduler scheduler, int interval)
        {
            this.scheduler = scheduler;
            this.factory = new TaskFactory(scheduler);
            this.baseInterval = interval;
        }

        /// <summary>Initializes a new instance of the ResponseLimitedConcurrencyActionLoader class.</summary>
        /// <param name="scheduler">The scheduler to load.</param>
        /// <param name="interval">The interval (in milliseconds) for which to perform a load check.</param>
        public ResponseLimitedConcurrencyActionLoader(ResponseLimitedConcurrencyTaskScheduler scheduler)
            : this(scheduler, 1000)
        {
        }

        /// <summary>Indicators whether the scheduler or loader is currently busy.</summary>
        public bool IsProcessing()
        {
            return this.continueProcessing || this.scheduler.IsProcessing;
        }

        /// <summary>Performs a load of the specified action until stop is called.</summary>
        /// <param name="action">The action to execute.</param>
        public void Start(Action action)
        {
            // Ensure loading is currently not active
            if (this.IsProcessing()) { throw new InvalidOperationException("Loader is currently active."); }

            // Note now running
            this.continueProcessing = true;

            // Define base configuration values
            var configuration = this.scheduler.SchedulerTaskConfiguration;
            int minSampleRate = Math.Min(configuration.MinimumSampleCount * 3, configuration.AverageSampleCount * 2);
            int interval = Math.Min(configuration.SamplingRateMilliseconds, this.baseInterval);

            // Load actions into scheduler until processing needs to stop
            this.loaderTask = Task.Factory.StartNew(() =>
                {
                    while (this.continueProcessing)
                    {
                        // Calculate tasks that should be pending
                        int actualNeeded;
                        if (this.scheduler.SchedulerExecutionState.LastSampledAverage == 0)
                        {
                            double rate = ((double)this.scheduler.SchedulerExecutionState.MaxDegreeOfParallelism * 1000.0) / (double)this.scheduler.SchedulerExecutionState.LastSampledAverage;
                            int minNeeded = Math.Max((int)((rate * (double)interval * 2.0) / 1000.0), minSampleRate);
                            actualNeeded = minNeeded - this.scheduler.SchedulerExecutionState.AwaitingTasks;
                        }
                        else
                        {
                            actualNeeded = minSampleRate;
                        }

                        // Load any needed tasks
                        if (actualNeeded > 0)
                        {
                            for (int idx = 0; idx < actualNeeded; idx++)
                            {
                                factory.StartNew(action);
                            }
                        }

                        // Wait for inteval before looping back around
                        Thread.Sleep(interval);
                    }
                });
        }

        /// <summary>Tell the loader to stop processing.</summary>
        public void Stop()
        {
            this.continueProcessing = false;
            if (this.loaderTask != null) { this.loaderTask.Wait(); }
        }

        /// <summary>Tell the loader to stop processing and block until all actions complete.</summary>
        public void StopAndWait()
        {
            this.Stop();
            while (this.scheduler.IsProcessing) { Thread.Sleep(250); }
        }
    }
}
