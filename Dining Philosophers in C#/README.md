# Dining Philosophers in C#
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- threading
- Parallel Programming
## Topics
- threading
- Parallel Programming
## Updated
- 04/10/2013
## Description

<h1>Introduction</h1>
<div style="font-size:small">
<div>There are numerous solutions to the dining philosophers problem on the internet and I will not be reciting the story. You can find it at one of the following two links:</div>
<div>&nbsp;</div>
<div><a title="Solving The Dining Philosophers Problem With Asynchronous Agents" href="http://msdn.microsoft.com/en-us/magazine/dd882512.aspx" target="_blank">MSDN Magazine</a></div>
<div><a title="Dining philosophers" href="http://rosettacode.org/wiki/Dining_philosophers" target="_blank">Rosetta Code</a></div>
<br>
<div>A few notes. Each philosopher is marked with a circle and can pick a chopstick on the left and on the&nbsp;right before he can eat. So, if philosopher 1 picks chopstick #5, philosopher #5 must wait for philosopher 1 to finish eating before he can pick
 the chopstick.</div>
<div>&nbsp;</div>
<div><img id="79655" src="79655-philosophers.png" alt="" width="251" height="243"></div>
<div>&nbsp;</div>
<div>Application of this pattern could be transferring of money from one account A to another account B. Similarity would be where you have to acquire locks on A and B before money could exchange hands. That is necessary to ensure that only one transaction
 could go through both accounts at the same time.</div>
<div>&nbsp;</div>
<div>Once the problem is understood the code becomes very clear. We pass in left and right chopsticks and acquire locks on them, then a philosopher can eat. It is critical in such design that objects used for locking are always passed in the same order. Here
 chopsticks are numbered from 1 to 5 and must always be passed in ascending order. The consequence of&nbsp;mixing order, for example passing chopsticks 4 to left and 3 to right for philosopher 3 randomly could cause the code to deadlock at runtime.</div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Eat(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;leftChopstick,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;rightChopstick,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;philosopherNumber&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(leftChopstick)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Grab&nbsp;utencil&nbsp;on&nbsp;the&nbsp;left</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(rightChopstick)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Grab&nbsp;utencil&nbsp;on&nbsp;the&nbsp;right</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Eat&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Philosopher&nbsp;{0}&nbsp;eats.&quot;</span>,&nbsp;philosopherNumber);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">What's left is to create objects that we will use for synchronization, these are the chopsticks:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;numPhilosophers&nbsp;=&nbsp;<span class="cs__number">5</span>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;5&nbsp;utencils&nbsp;on&nbsp;the&nbsp;left&nbsp;and&nbsp;right&nbsp;of&nbsp;each&nbsp;philosopher.&nbsp;Use&nbsp;them&nbsp;to&nbsp;acquire&nbsp;locks.</span>&nbsp;
var&nbsp;chopsticks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">int</span>,&nbsp;<span class="cs__keyword">object</span>&gt;(numPhilosophers);&nbsp;
&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;numPhilosophers;&nbsp;&#43;&#43;i)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chopsticks.Add(i,&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">object</span>());&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Allocate tasks, one for each philosopher. Here's an interesting part, I am using loop local variable ix instead of loop global i variable. That is due to how variables are captured by lambdas in c#. Try using i instead of ix.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Task[]&nbsp;tasks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task[numPhilosophers];&nbsp;
&nbsp;
tasks[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task(()&nbsp;=&gt;&nbsp;Philoshoper.Eat(chopsticks[<span class="cs__number">0</span>],&nbsp;chopsticks[numPhilosophers&nbsp;-&nbsp;<span class="cs__number">1</span>],&nbsp;<span class="cs__number">0</span>&nbsp;&#43;&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;numPhilosophers));&nbsp;
&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;&nbsp;chopsticks.Count;&nbsp;&#43;&#43;i)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;ix&nbsp;=&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;tasks[ix]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task(()&nbsp;=&gt;&nbsp;Philoshoper.Eat(chopsticks[ix&nbsp;-&nbsp;<span class="cs__number">1</span>],&nbsp;chopsticks[ix],&nbsp;ix&nbsp;&#43;&nbsp;<span class="cs__number">1</span>,&nbsp;ix,&nbsp;ix&nbsp;&#43;&nbsp;<span class="cs__number">1</span>));&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">And that's all there is to it. Now we can execute the tasks and wait for all of them to complete:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;May&nbsp;eat!</span>&nbsp;
Parallel.ForEach(tasks,&nbsp;t&nbsp;=&gt;&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;t.Start();&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Wait&nbsp;for&nbsp;all&nbsp;philosophers&nbsp;to&nbsp;finish&nbsp;their&nbsp;dining</span>&nbsp;
Task.WaitAll(tasks);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">I have used Parallel.ForEach loop instead of a simple for loop in order to demonstrate the task parallel library and also to randomize execution of each task without adding delay which could be done inside Eat function's inner lock
 like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Task.Delay(<span class="js__num">5000</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">And here is a possible output:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;2&nbsp;picked&nbsp;1&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;4&nbsp;picked&nbsp;3&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;3&nbsp;picked&nbsp;2&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;4&nbsp;picked&nbsp;4&nbsp;chopstick.&nbsp;
Philosopher&nbsp;4&nbsp;eats.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;4&nbsp;released&nbsp;4&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;4&nbsp;released&nbsp;3&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;3&nbsp;picked&nbsp;3&nbsp;chopstick.&nbsp;
Philosopher&nbsp;3&nbsp;eats.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;3&nbsp;released&nbsp;3&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;3&nbsp;released&nbsp;2&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;5&nbsp;picked&nbsp;4&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;5&nbsp;picked&nbsp;5&nbsp;chopstick.&nbsp;
Philosopher&nbsp;5&nbsp;eats.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;5&nbsp;released&nbsp;5&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;5&nbsp;released&nbsp;4&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;2&nbsp;picked&nbsp;2&nbsp;chopstick.&nbsp;
Philosopher&nbsp;2&nbsp;eats.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;2&nbsp;released&nbsp;2&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;2&nbsp;released&nbsp;1&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;1&nbsp;picked&nbsp;1&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;1&nbsp;picked&nbsp;5&nbsp;chopstick.&nbsp;
Philosopher&nbsp;1&nbsp;eats.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;1&nbsp;released&nbsp;5&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;1&nbsp;released&nbsp;1&nbsp;chopstick.&nbsp;
*/</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
</div>
</div>
</div>
<div style="font-size:small">
<div class="endscriptcode" style="font-size:small">
<h2><span style="font-size:small">Summary</span></h2>
<dl><dt>I hope the code will help some of you to learn concepts of thread synchronization and parallel programming.</dt></dl>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h2>Source Code Files</h2>
<dl><dt>program.cs - the only file in the project &nbsp;</dt></dl>
<div>&nbsp;</div>
<dl></dl>
