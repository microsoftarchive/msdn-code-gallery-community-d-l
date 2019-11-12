using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MSDN.Schedulers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSDN.Schedulers.Test
{
    [TestClass]
    public class ResponseLimitedConcurrencyTaskSchedulerTest
    {
        private Func<int, int> GetSchedulerInit()
        {
            var config = new List<ResponseLimitedConcurrencyStepDefinition>();
            config.Add(new ResponseLimitedConcurrencyStepDefinition(5, 500));
            config.Add(new ResponseLimitedConcurrencyStepDefinition(3, 5000));
            config.Add(new ResponseLimitedConcurrencyStepDefinition(2, Int32.MaxValue));

            return ResponseLimitedConcurrencyFunctionFactory.StepDecrement(config);
        }

        [TestMethod]
        public void BasicSchedulingLimitedOnly()
        {
            LimitedConcurrencyLevelTaskScheduler lclts = new LimitedConcurrencyLevelTaskScheduler(5);
            TaskFactory factory = new TaskFactory(lclts);

            factory.StartNew(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("{0} on thread {1}", i, Thread.CurrentThread.ManagedThreadId);
                    }
                }
            );

            ParallelOptions options = new ParallelOptions();
            options.TaskScheduler = lclts;

            Parallel.For(
                    0,
                    50,
                    options,
                    (i) =>
                    {                        
                        Thread.Sleep(100);
                        Console.WriteLine("Finish Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                    }
                );
        }

        [TestMethod]
        public void BasicSchedulingVisual()
        {
            ResponseLimitedConcurrencyTaskScheduler rlcts = new ResponseLimitedConcurrencyTaskScheduler(GetSchedulerInit());
            TaskFactory factory = new TaskFactory(rlcts);

            factory.StartNew(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("{0} on thread {1}", i, Thread.CurrentThread.ManagedThreadId);
                    }
                }
            );

            ParallelOptions options = new ParallelOptions();
            options.TaskScheduler = rlcts;

            Parallel.For(
                    0,
                    50,
                    options,
                    (i) =>
                    {
                        //Console.WriteLine("Start Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                        Thread.Sleep(100);
                        Console.WriteLine("Finish Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                    }
                );

            rlcts.Dispose();
        }

        [TestMethod]
        public void SchedulingStepDown()
        {
            ResponseLimitedConcurrencyTaskConfiguration config = new ResponseLimitedConcurrencyTaskConfiguration();
            config.MinimumSampleCount = 2;
            config.SamplingRateMilliseconds = 250;
            config.AverageSampleCount = 5;

            ResponseLimitedConcurrencyTaskScheduler rlcts = new ResponseLimitedConcurrencyTaskScheduler(GetSchedulerInit(), config);
            ParallelOptions options = new ParallelOptions();
            options.TaskScheduler = rlcts;

            // Should start with 5 threads and switch down to 3
            Parallel.For(
                    0,
                    50,
                    options,
                    (i) =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Finish Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                    }
                );

            rlcts.Dispose();
        }

        [TestMethod]
        public void SchedulingStepDownDirect()
        {
            ResponseLimitedConcurrencyTaskConfiguration config = new ResponseLimitedConcurrencyTaskConfiguration();
            config.MinimumSampleCount = 2;
            config.SamplingRateMilliseconds = 250;
            config.AverageSampleCount = 5;

            ResponseLimitedConcurrencyTaskScheduler rlcts = new ResponseLimitedConcurrencyTaskScheduler(GetSchedulerInit(), config);
            TaskFactory factory = new TaskFactory(rlcts);
            Task[] tasks = new Task[50];

            // Should start with 5 threads and switch down to 3
            for (int idx = 0; idx < 50; idx++)
            {
                int i = idx;
                tasks[i] = factory.StartNew(() =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Finish Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                    }
                );
            }

            Task.WaitAll(tasks);
            rlcts.Dispose();
        }

        [TestMethod]
        public void SchedulingLoaderBriefTest()
        {
            Func<int, int> funcMdop = ResponseLimitedConcurrencyFunctionFactory.LinearDecreasing(5, 1, 2);

            ResponseLimitedConcurrencyTaskScheduler rlcts = new ResponseLimitedConcurrencyTaskScheduler(funcMdop);
            ResponseLimitedConcurrencyActionLoader loader = new ResponseLimitedConcurrencyActionLoader(rlcts);

            Action action = () =>
                    {
                        Thread.Sleep(10);
                        Console.WriteLine("Finish Thread={0}", Thread.CurrentThread.ManagedThreadId);
                    };

            loader.Start(action);
            Thread.Sleep(5000);
            loader.StopAndWait();

        }

        [TestMethod]
        public void SchedulingLoaderLongTimeTest()
        {
            ResponseLimitedConcurrencyTaskScheduler rlcts = new ResponseLimitedConcurrencyTaskScheduler(GetSchedulerInit());
            ResponseLimitedConcurrencyActionLoader loader = new ResponseLimitedConcurrencyActionLoader(rlcts);

            Action action = () =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Finish Thread={0}", Thread.CurrentThread.ManagedThreadId);
            };

            loader.Start(action);
            Thread.Sleep(20000);
            loader.StopAndWait();
        }

        [TestMethod]
        public void SchedulingLoaderLongRunningTest()
        {
            ResponseLimitedConcurrencyTaskConfiguration config = new ResponseLimitedConcurrencyTaskConfiguration();
            config.MinimumSampleCount = 5;
            config.SamplingRateMilliseconds = 2000;
            config.AverageSampleCount = 10;

            ResponseLimitedConcurrencyTaskScheduler rlcts = new ResponseLimitedConcurrencyTaskScheduler(GetSchedulerInit(), config);
            ResponseLimitedConcurrencyActionLoader loader = new ResponseLimitedConcurrencyActionLoader(rlcts);

            Action action = () =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Finish Thread={0}", Thread.CurrentThread.ManagedThreadId);
            };

            loader.Start(action);
            Thread.Sleep(5000);
            loader.StopAndWait();
        }
    }
}
