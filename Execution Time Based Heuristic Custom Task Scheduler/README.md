# Execution Time Based Heuristic Custom Task Scheduler
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Parallel Programming
- Task Parallel Library
## Topics
- threading
- Parallel Programming
- Task Parallelism
- Scheduled Task
- Custom Task Scheduler
## Updated
- 10/04/2012
## Description

<p>If you follow the samples for <a href="http://code.msdn.microsoft.com/ParExtSamples" target="_blank">
Parallel Programming with the .Net Framework</a>, you may have come across the <a href="http://blogs.msdn.com/b/pfxteam/archive/2010/04/04/9990342.aspx" target="_blank">
ParallelExtensionsExtras</a> and the <a href="http://blogs.msdn.com/b/pfxteam/archive/2010/04/09/9990424.aspx" target="_blank">
Additional TaskSchedulers</a>. Although these samples cover a broad set of requirements I recently came across another that could be satisfied with the creation of a custom task scheduler. In the current samples the Maximum Degree of Parallelism (MDOP) is fixed.
 But what if one wanted to adjust the MDOP based on the task execution time.</p>
<p>As an example consider calling a web service, or performing any data processing, from a message queue. I recently came across this requirement, where if the response times drop then the MDOP also needed to drop. One could take the approach of a service that
 manages its threads but a custom task scheduler enables a far greater set of usage scenarios.</p>
<p>As a starting point the <a href="http://blogs.msdn.com/b/pfxteam/" target="_blank">
PfX Team</a> have provided a&nbsp;custom task scheduler that allows one to specify the MDOP. In meeting the requirement to vary the MDOP, based on execution times, there are three main differences one needs to accommodate. Firstly one needs a function that
 can be used for determining the MDOP; based an average task execution time. Secondly, one needs to record the actual task execution times in such a manner that the MDOP can be determined. Lastly, the MDOP needs to be re-evaluated, based on the recorded execution
 times, and the number of executing threads adjusted.</p>
<p>This is the purpose of the new ResponseLimitedConcurrencyTaskScheduler task scheduler. To support the requirement for determining the MDOP the scheduler class constructor now supports the following prototype:</p>
<p>public ResponseLimitedConcurrencyTaskScheduler(Func funcMdop, ResponseLimitedConcurrencyTaskConfiguration configuration)</p>
<p>This function is passed an average execution time and returns a calculated MDOP. To calculate the average execution times a ConcurrentStack&lt;int&gt; is used to record the tack execution times. On a timed schedule the top X items from the stack are averaged,
 and this value is used in the MDOP calculation.</p>
<p>To use the task scheduler one just has to create an instance, with the required MDOP function, and then as before create a Factory with the newly created scheduler:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;config&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ResponseLimitedConcurrencyStepDefinition&gt;();&nbsp;
config.Add(<span class="cs__keyword">new</span>&nbsp;ResponseLimitedConcurrencyStepDefinition(<span class="cs__number">5</span>,&nbsp;<span class="cs__number">500</span>));&nbsp;
config.Add(<span class="cs__keyword">new</span>&nbsp;ResponseLimitedConcurrencyStepDefinition(<span class="cs__number">3</span>,&nbsp;<span class="cs__number">5000</span>));&nbsp;
config.Add(<span class="cs__keyword">new</span>&nbsp;ResponseLimitedConcurrencyStepDefinition(<span class="cs__number">2</span>,&nbsp;Int32.MaxValue));&nbsp;
&nbsp;
var&nbsp;mdopFunc&nbsp;=&nbsp;ResponseLimitedConcurrencyFunctionFactory.StepDecrement(config);&nbsp;
&nbsp;
ResponseLimitedConcurrencyTaskScheduler&nbsp;rlcts&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ResponseLimitedConcurrencyTaskScheduler(mdopFunc);&nbsp;
TaskFactory&nbsp;factory&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TaskFactory(rlcts);&nbsp;
&nbsp;
factory.StartNew(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__number">10</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}&nbsp;on&nbsp;thread&nbsp;{1}&quot;</span>,&nbsp;i,&nbsp;Thread.CurrentThread.ManagedThreadId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
);&nbsp;
&nbsp;
ParallelOptions&nbsp;options&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ParallelOptions();&nbsp;
options.TaskScheduler&nbsp;=&nbsp;rlcts;&nbsp;
&nbsp;
Parallel.For(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">50</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(<span class="cs__number">100</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Finish&nbsp;Thread={0},&nbsp;i={1}&quot;</span>,&nbsp;Thread.CurrentThread.ManagedThreadId,&nbsp;i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
rlcts.Dispose();</pre>
</div>
</div>
</div>
<p>To assist in creating this function the code comes with a few starters for 10. Firstly a step up and down function, and secondly a linearly increasing and decreasing function.</p>
<p>There is one final item to solution to meet the requirements that initially drove the solution. How do you use the scheduler to process a queue of calls. As such the code also contains a Loader class where one can specify an Action that is used to ensure
 the scheduler always has an active processing queue. If needed these components can be used to construct a windows service that processes items from a queue and where the MDOP of the scheduler varies based on the workload.</p>
<p>The code download also contains the original PfX team LimitedConcurrencyLevelTaskScheduler task scheduler from which the new scheduler is based.</p>
<p>More information on the code can be found here: <a href="http://blogs.msdn.com/b/carlnol/archive/2012/10/02/execution-time-based-heuristic-custom-task-scheduler.aspx">
http://blogs.msdn.com/b/carlnol/archive/2012/10/02/execution-time-based-heuristic-custom-task-scheduler.aspx</a></p>
