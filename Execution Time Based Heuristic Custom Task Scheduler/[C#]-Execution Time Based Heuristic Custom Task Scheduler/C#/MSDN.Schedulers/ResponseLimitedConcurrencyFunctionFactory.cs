//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ResponseLimitedConcurrencyFunctionFactory.cs
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

    /// <summary>Defines a response time for which a MDOP should be applied.</summary>
    public class ResponseLimitedConcurrencyStepDefinition
    {
        /// <summary>Gets or sets the maximum concurrency level allowed by this scheduler.</summary>
        public int MaxDegreeOfParallelism { get; set; }

        /// <summary>Gets or sets the maximum average execution time (milli-seconds) for which the MDOP should be applied.</summary>
        public int MaxAverageResponse { get; set; }

        /// <summary>
        /// Initializes a new instance of the ResponseLimitedParallelConcurrency class.
        /// </summary>
        /// <param name="maxDegreeOfParallelism">The maximum concurrency level allowed by this scheduler.</param>
        /// <param name="maxAverageResponse">The maximum average execution time (seconds) for which the MDOP should be applied.</param>
        public ResponseLimitedConcurrencyStepDefinition(int maxDegreeOfParallelism, int maxAverageResponseMs)
        {
            this.MaxDegreeOfParallelism = maxDegreeOfParallelism;
            this.MaxAverageResponse = maxAverageResponseMs;
        }
    }

    /// <summary>Basic functions for controlling scheduler MDOP.</summary>
    public static class ResponseLimitedConcurrencyFunctionFactory
    {
        /// <summary>Initializes an instance of the ResponseLimitedConcurrencyStepDefinition class working towards maximum concurrency.</summary>
        /// <param name="maxDegreeOfParallelism">The maximum degree of parallelism provided by this scheduler.</param>
        /// <returns>Function calculating MDOP based on Average response time.</returns>
        public static Func<int, int> StepDecrement(List<ResponseLimitedConcurrencyStepDefinition> responseLimitedParallelConcurrency)
        {
            // Validate the collection
            if (responseLimitedParallelConcurrency == null)
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Definition cannot be null.");
            if (responseLimitedParallelConcurrency.Count <= 1)
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Definition must contain more than a single entry.");
            if (responseLimitedParallelConcurrency.Any(responseDef => (responseDef.MaxDegreeOfParallelism <= 0)))
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Max Degree of Parallelism must be positive.");
            if (responseLimitedParallelConcurrency.Any(responseDef => (responseDef.MaxAverageResponse <= 0)))
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Execution time boundaries must be positive.");

            Func<int, int> funcMdop = average =>
            {
                var ordered = responseLimitedParallelConcurrency.OrderBy(responseDef => responseDef.MaxAverageResponse);
                if (average <= 0)
                {
                    return ordered.Select(responseDef => responseDef.MaxDegreeOfParallelism).Max();
                }
                else
                {
                    var maxDef = ordered.SkipWhile(responseDef => (responseDef.MaxAverageResponse < average)).FirstOrDefault();
                    if (maxDef != null) { return maxDef.MaxDegreeOfParallelism; }
                    else { return 0; }
                }
            };

            return funcMdop;
        }

        /// <summary>Initializes an instance of the ResponseLimitedConcurrencyTaskScheduler class working towards minimum concurrency.</summary>
        /// <param name="maxDegreeOfParallelism">The maximum degree of parallelism provided by this scheduler.</param>
        /// <returns>Function calculating MDOP based on Average response time.</returns>
        public static Func<int, int> StepIncrement(List<ResponseLimitedConcurrencyStepDefinition> responseLimitedParallelConcurrency)
        {
            // Validate the collection
            if (responseLimitedParallelConcurrency == null)
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Definition cannot be null.");
            if (responseLimitedParallelConcurrency.Count <= 1)
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Definition must contain more than a single entry.");
            if (responseLimitedParallelConcurrency.Any(responseDef => (responseDef.MaxDegreeOfParallelism <= 0)))
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Max Degree of Parallelism must be positive.");
            if (responseLimitedParallelConcurrency.Any(responseDef => (responseDef.MaxAverageResponse <= 0)))
                throw new ArgumentOutOfRangeException("responseLimitedParallelConcurrency", "Execution time boundaries must be positive.");

            Func<int, int> funcMdop = average =>
            {
                var ordered = responseLimitedParallelConcurrency.OrderBy(responseDef => responseDef.MaxAverageResponse);
                if (average <= 0)
                {
                    return ordered.Select(responseDef => responseDef.MaxDegreeOfParallelism).Min();
                }
                else
                {
                    var maxDef = ordered.SkipWhile(responseDef => (responseDef.MaxAverageResponse < average)).FirstOrDefault();
                    if (maxDef != null) { return maxDef.MaxDegreeOfParallelism; }
                    else { return 0; }
                }
            };

            return funcMdop;
        }

        /// <summary>Initializes an instance of the ResponseLimitedConcurrencyTaskScheduler class working towards maximum concurrency.</summary>
        /// <remarks>A function of the form (max - (dec/1000)x) until the min value is reached.</remarks>
        /// <param name="maximumMdop">Maximum MDOP and starting value.</param>
        /// <param name="decreasePerSecond">Decrease in MDOP for each second of execution time.</param>
        /// <param name="minimumMdop">Minimum MDOP and finishing value.</param>
        /// <returns>Function calculating MDOP based on Average response time.</returns>
        public static Func<int, int> LinearDecreasing(int maximumMdop, int decreasePerSecond, int minimumMdop)
        {
            // Validate have positive and ordered value values
            if (maximumMdop <= 0)
                throw new ArgumentOutOfRangeException("maximumMdop", "Maximum Degree of Parallelism must be positive.");
            if (minimumMdop <= 0)
                throw new ArgumentOutOfRangeException("minimumMdop", "Minimum Degree of Parallelism must be positive.");
            if (maximumMdop <= minimumMdop)
                throw new ArgumentOutOfRangeException("maximumMdop", "Maximum MDOP must be greater than Minimum MDOP.");
            if (decreasePerSecond <= 0)
                throw new ArgumentOutOfRangeException("decreasePerSecond", "MDOP Decrease rate must be positive.");

            Func<int, int> funcMdop = average =>
                {
                    if (average <= 0)
                    {
                        return maximumMdop;
                    }
                    else
                    {
                        double maxMilli = ((double)(maximumMdop - minimumMdop) * 1000.0) / (double)decreasePerSecond;
                        if (average < maxMilli)
                        {
                            return (int)Math.Ceiling((double)maximumMdop - (double)(decreasePerSecond * ((double)average / 1000)));
                        }
                        else
                        {
                            return minimumMdop;
                        }
                    }
                };

            return funcMdop;
        }

        /// <summary>Initializes an instance of the ResponseLimitedConcurrencyTaskScheduler class working towards minimum concurrency.</summary>
        /// <remarks>A function of the form (min + (dec/1000)x) until the max value is reached.</remarks>
        /// <param name="minimumMdop">Minimum MDOP and starting value.</param>        
        /// <param name="decreasePerSecond">Decrease in MDOP for each second of execution time.</param>
        /// <param name="maximumMdop">Maximum MDOP and finishing value.</param>
        /// <returns>Function calculating MDOP based on Average response time.</returns>
        public static Func<int, int> LinearIncreasing(int minimumMdop, int increasePerSecond, int maximumMdop)
        {
            // Validate have positive and ordered value values
            if (maximumMdop <= 0)
                throw new ArgumentOutOfRangeException("maximumMdop", "Maximum Degree of Parallelism must be positive.");
            if (minimumMdop <= 0)
                throw new ArgumentOutOfRangeException("minimumMdop", "Minimum Degree of Parallelism must be positive.");
            if (minimumMdop >= maximumMdop)
                throw new ArgumentOutOfRangeException("minimumMdop", "Minimum MDOP must be less than Maximum MDOP.");
            if (increasePerSecond <= 0)
                throw new ArgumentOutOfRangeException("increasePerSecond", "MDOP Decrease rate must be positive.");

            Func<int, int> funcMdop = average =>
            {
                if (average <= 0)
                {
                    return minimumMdop;
                }
                else
                {
                    double minMilli = ((double)(maximumMdop - minimumMdop) * 1000.0) / (double)increasePerSecond;
                    if (average < minMilli)
                    {
                        return (int)Math.Floor((double)minimumMdop + (double)(increasePerSecond * ((double)average / 1000)));
                    }
                    else
                    {
                        return maximumMdop;
                    }
                }
            };

            return funcMdop;
        }
    }
}