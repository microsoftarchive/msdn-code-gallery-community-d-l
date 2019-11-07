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

    /// <summary>Type for the definition of the running parameters of the scheduler.</summary>
    public sealed class ResponseLimitedConcurrencyTaskConfiguration
    {
        // private backing fields
        private int defaultDegreeOfParallelism;
        private int maximumSampleCount;
        private int averageSampleCount;
        private int minimumSampleCount;
        private int samplingRateMilliseconds;

        /// <summary>Initializes a new instance of the ResponseLimitedConcurrencyTaskConfiguration class with default values.</summary>
        public ResponseLimitedConcurrencyTaskConfiguration()
        {
            this.defaultDegreeOfParallelism = 2 * Environment.ProcessorCount;
            this.averageSampleCount = 5000;
            this.minimumSampleCount = 100;
            this.samplingRateMilliseconds = 5000;
            this.maximumSampleCount = 4 * this.averageSampleCount;
        }

        /// <summary>Gets or sets the default MDOP for the scheduler.</summary>
        public int DefaultDegreeOfParallelism
        {
            get
            {
                return this.defaultDegreeOfParallelism;
            }
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("DefaultDegreeOfParallelism", "Default MDOP must be Positive."); }
                this.defaultDegreeOfParallelism = value;
            }
        }

        /// <summary>Gets or sets the maximum number of sample entries that should be added to the queue.</summary>
        public int MaximumSampleCount
        {
            get
            {
                return this.maximumSampleCount;
            }
            set
            {
                if (value <= 0 || value < (2 * this.averageSampleCount)) { throw new ArgumentOutOfRangeException("MaximumSampleCount", "Maximum Sample Count must be Positive and Greater than 2*Average."); }
                this.maximumSampleCount = value;
            }
        }

        /// <summary>Gets or sets the maximum number of sample entries to use for execution average.</summary>
        public int AverageSampleCount
        {
            get
            {
                return this.averageSampleCount;
            }
            set
            {
                if (value <= 0 || value < this.minimumSampleCount) { throw new ArgumentOutOfRangeException("AverageSampleCount", "Average Sample Count must be Positive and Greater than Minimum."); }
                this.averageSampleCount = value;
                if (this.maximumSampleCount < (2 * this.averageSampleCount)) { this.maximumSampleCount = 4 * this.averageSampleCount; }
            }
        }

        /// <summary>Gets or sets the minimum number of entries to be found before modifying the MDOP.</summary>
        public int MinimumSampleCount
        {
            get
            {
                return this.minimumSampleCount;
            }
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("MinimumSampleCount", "Minimum Sample Count must be Positive."); }
                this.minimumSampleCount = value;
            }
        }

        /// <summary>Gets or sets the interval for which sampling occurs for recalculating the MDOP.</summary>
        public int SamplingRateMilliseconds
        {
            get
            {
                return this.samplingRateMilliseconds;
            }
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("SamplingRateMilliseconds", "Sampling Rate Milliseconds must be Positive."); }
                this.samplingRateMilliseconds = value;
            }
        }
    }
}