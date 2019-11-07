# Dining Philosophers in C++ 11
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C++
## Topics
- threading
- Parallel Programming
## Updated
- 04/10/2013
## Description

<h1>Introduction</h1>
<div style="font-size:small">
<p>I have previously <a title="Dining philosophers in c#" href="http://code.msdn.microsoft.com/vstudio/Dining-Philosophers-in-C-9ec1dcef" target="_blank">
shown</a> how to solve the problem using c#. I have to say that C&#43;&#43; 11 is officially awesome! Here's my&nbsp;offering&nbsp;using that language.</p>
<div></div>
<p>There are numerous solutions to the dining philosophers problem on the internet and I will not be reciting the story. You can find it at one of the following two links:</p>
<div>&nbsp;</div>
<div><a title="Solving The Dining Philosophers Problem With Asynchronous Agents" href="http://msdn.microsoft.com/en-us/magazine/dd882512.aspx" target="_blank">MSDN Magazine</a></div>
<div><a title="Dining philosophers" href="http://rosettacode.org/wiki/Dining_philosophers" target="_blank">Rosetta Code</a></div>
<br>
<p>A few notes. Each philosopher is marked with a circle and can pick a chopstick on the left and on the&nbsp;right before he can eat. So, if philosopher 1 picks chopstick #5, philosopher #5 must wait for philosopher 1 to finish eating before he can pick the
 chopstick.</p>
<div>&nbsp;</div>
<div><img id="79655" src="79655-philosophers.png" alt="" width="251" height="243"></div>
<div>&nbsp;</div>
<p>Application of this pattern could be transferring of money from one account A to another account B. Similarity would be where you have to acquire locks on A and B before money could exchange hands. That is necessary to ensure that only one transaction could
 go through both accounts at the same time. Another example could be swapping of two objects in multithreaded environment where you have to use both instances of the objects to acquire locks.</p>
<p>In this project I am introducing quite a few concepts, so let us discuss them.</p>
<div>In this example we have each thread to lock&nbsp;a pair of&nbsp;mutexes to perform some operation. If thread 1 locked on mutex 1 and is&nbsp;waiting for mutex 2, while at the same time thread 2 locked on mutex 2 and is waiting on mutex 1, the result will
 be a deadlock and the program will hang.</div>
<p>The common advice for avoiding deadlock is to acquire two mutexes in the same order, and that is what I recommended in my C# example. Sometimes it is easy to enforce in code, but in the example of transferring funds between accounts A and B, if you do two
 transfers at the same time from A to B, and B to A, you may not be able to achieve the order. Besides, someone maintaining code could not realize that the call requires to pass mutexes in a certain order and make a mistake. Another example where order may
 be difficult to enforce is in swapping of two objects. If two threads try to exchange data between the same two instances with the parameters swapped, the program may deadlock.</p>
<p>C&#43;&#43; 11 has a solution to the deadlocks in the <span style="color:#339966">std::lock
</span>function which can lock two or more mutexes to aleviate risk of deadlocks.</p>
<p>First we must ensure that we are not locking twice on the same mutex, illegal operation which results in undefined behavior.
<span style="color:#339966">std::recursive_lock</span> allows multiple locking by the same thread.</p>
<div></div>
<p>Next call to <span style="color:#339966">std::lock</span> locks two mutexes, and two
<span style="color:#339966">std::lock_guard</span> instances are constructed, one for each mutex.
<span style="color:#339966">std::adopt_lock</span> parameter indicates that the mutexes are already locked and they should adopt the ownership of the existing lock.</p>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">auto eat = [](Chopstick* leftChopstick, Chopstick* rightChopstick, int philosopherNumber)
{
	if (leftChopstick == rightChopstick)
		throw exception(&quot;Left and right chopsticks should not be the same!&quot;);

	lock(leftChopstick-&gt;m, rightChopstick-&gt;m);	// ensures there are no deadlocks
	lock_guard&lt;mutex&gt; a(leftChopstick-&gt;m, adopt_lock);
	lock_guard&lt;mutex&gt; b(rightChopstick-&gt;m, adopt_lock);					

	string pe = &quot;Philosopher &quot; &#43; to_string(philosopherNumber) &#43; &quot; eats.\n&quot;;
	cout &lt;&lt; pe;

	//std::chrono::milliseconds timeout(500);
	//std::this_thread::sleep_for(timeout);
};
</pre>
<div class="preview">
<pre class="cplusplus">auto&nbsp;eat&nbsp;=&nbsp;[](Chopstick*&nbsp;leftChopstick,&nbsp;Chopstick*&nbsp;rightChopstick,&nbsp;<span class="cpp__datatype">int</span>&nbsp;philosopherNumber)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(leftChopstick&nbsp;==&nbsp;rightChopstick)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">throw</span>&nbsp;exception(<span class="cpp__string">&quot;Left&nbsp;and&nbsp;right&nbsp;chopsticks&nbsp;should&nbsp;not&nbsp;be&nbsp;the&nbsp;same!&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lock(leftChopstick-&gt;m,&nbsp;rightChopstick-&gt;m);&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ensures&nbsp;there&nbsp;are&nbsp;no&nbsp;deadlocks</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lock_guard&lt;mutex&gt;&nbsp;a(leftChopstick-&gt;m,&nbsp;adopt_lock);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lock_guard&lt;mutex&gt;&nbsp;b(rightChopstick-&gt;m,&nbsp;adopt_lock);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">string</span>&nbsp;pe&nbsp;=&nbsp;<span class="cpp__string">&quot;Philosopher&nbsp;&quot;</span>&nbsp;&#43;&nbsp;to_string(philosopherNumber)&nbsp;&#43;&nbsp;<span class="cpp__string">&quot;&nbsp;eats.\n&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;pe;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//std::chrono::milliseconds&nbsp;timeout(500);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//std::this_thread::sleep_for(timeout);</span>&nbsp;
};&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">here Chopstick is defined as following:</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">class Chopstick
{
public:
	Chopstick(){};
	mutex m;
};
</pre>
<div class="preview">
<pre class="js">class&nbsp;Chopstick&nbsp;
<span class="js__brace">{</span>&nbsp;
public:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Chopstick()<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mutex&nbsp;m;&nbsp;
<span class="js__brace">}</span>;&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">You will notice that <span style="color:#993366">auto eat</span> is a name for an anonymous lambda&nbsp;which can be used multiple times in our code just like an&nbsp;ordinary function call. The actual type for eat is some implementation-dependent
 type selected by compiler to keep track of lambdas.</p>
</div>
<div class="endscriptcode"></div>
<p class="endscriptcode">What's left is to create objects that we will use for synchronization, these are the chopsticks:</p>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">static const int numPhilosophers = 5;

// 5 utencils on the left and right of each philosopher. Use them to acquire locks.
vector&lt; unique_ptr&lt;Chopstick&gt; &gt; chopsticks(numPhilosophers);

for (int i = 0; i &lt; numPhilosophers; &#43;&#43;i)
{
	auto c1 = unique_ptr&lt;Chopstick&gt;(new Chopstick());
	chopsticks[i] = move(c1);
}
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">static</span>&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;numPhilosophers&nbsp;=&nbsp;<span class="cpp__number">5</span>;&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;5&nbsp;utencils&nbsp;on&nbsp;the&nbsp;left&nbsp;and&nbsp;right&nbsp;of&nbsp;each&nbsp;philosopher.&nbsp;Use&nbsp;them&nbsp;to&nbsp;acquire&nbsp;locks.</span>&nbsp;
vector&lt;&nbsp;unique_ptr&lt;Chopstick&gt;&nbsp;&gt;&nbsp;chopsticks(numPhilosophers);&nbsp;
&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;numPhilosophers;&nbsp;&#43;&#43;i)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;auto&nbsp;c1&nbsp;=&nbsp;unique_ptr&lt;Chopstick&gt;(<span class="cpp__keyword">new</span>&nbsp;Chopstick());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chopsticks[i]&nbsp;=&nbsp;move(c1);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">Note the use of <span style="color:#339966">std::unique_ptr</span> which will ensure that objects will be destroyed automatically as soon as they leave the scope and
<span style="color:#339966">std::move</span> function which will copy the pointer to c1 into the chopsticks vector and null c1 so that it could not be used later.</p>
<div class="endscriptcode"></div>
<p class="endscriptcode">Next we are going to allocate threads, one for each philosopher:</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// This is where we create philosophers, each of 5 tasks represents one philosopher.
vector&lt;thread&gt; tasks(numPhilosophers);

tasks[0] = thread(eat, 
		chopsticks[0].get(),						// left chopstick:  #1
		chopsticks[numPhilosophers - 1].get(),		// right chopstick: #5
		0 &#43; 1,										// philosopher number
		1,
		numPhilosophers
	);

for (int i = 1; i &lt; numPhilosophers; &#43;&#43;i)
{
	tasks[i] = (thread(eat, 
			chopsticks[i - 1].get(),				// left chopstick
			chopsticks[i].get(),					// right chopstick
			i &#43; 1,									// philosopher number
			i,
			i &#43; 1
			)
		);
}
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;This&nbsp;is&nbsp;where&nbsp;we&nbsp;create&nbsp;philosophers,&nbsp;each&nbsp;of&nbsp;5&nbsp;tasks&nbsp;represents&nbsp;one&nbsp;philosopher.</span>&nbsp;
vector&lt;<span class="cpp__keyword">thread</span>&gt;&nbsp;tasks(numPhilosophers);&nbsp;
&nbsp;
tasks[<span class="cpp__number">0</span>]&nbsp;=&nbsp;<span class="cpp__keyword">thread</span>(eat,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chopsticks[<span class="cpp__number">0</span>].get(),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;left&nbsp;chopstick:&nbsp;&nbsp;#1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chopsticks[numPhilosophers&nbsp;-&nbsp;<span class="cpp__number">1</span>].get(),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;right&nbsp;chopstick:&nbsp;#5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__number">0</span>&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;philosopher&nbsp;number</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;numPhilosophers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;i&nbsp;&lt;&nbsp;numPhilosophers;&nbsp;&#43;&#43;i)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;tasks[i]&nbsp;=&nbsp;(<span class="cpp__keyword">thread</span>(eat,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chopsticks[i&nbsp;-&nbsp;<span class="cpp__number">1</span>].get(),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;left&nbsp;chopstick</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chopsticks[i].get(),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;right&nbsp;chopstick</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;philosopher&nbsp;number</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">Finally we can execute all threads in a loop and wait for all of them to complete:</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// May eat!
for_each(tasks.begin(), tasks.end(), mem_fn(&amp;thread::join));
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;May&nbsp;eat!</span>&nbsp;
for_each(tasks.begin(),&nbsp;tasks.end(),&nbsp;mem_fn(&amp;<span class="cpp__keyword">thread</span>::join));&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode"><span style="color:#339966">std::mem_fn</span> is a call wrapper.</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<p class="endscriptcode">And here is a possible output:</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">/*
   Philosopher 1 picked 1 chopstick.
   Philosopher 3 picked 2 chopstick.
   Philosopher 1 picked 5 chopstick.
   Philosopher 3 picked 3 chopstick.
Philosopher 1 eats.
Philosopher 3 eats.
   Philosopher 5 picked 4 chopstick.
   Philosopher 2 picked 1 chopstick.
   Philosopher 2 picked 2 chopstick.
   Philosopher 5 picked 5 chopstick.
Philosopher 2 eats.
Philosopher 5 eats.
   Philosopher 4 picked 3 chopstick.
   Philosopher 4 picked 4 chopstick.
Philosopher 4 eats.
*/</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;1&nbsp;picked&nbsp;1&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;3&nbsp;picked&nbsp;2&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;1&nbsp;picked&nbsp;5&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;3&nbsp;picked&nbsp;3&nbsp;chopstick.&nbsp;
Philosopher&nbsp;1&nbsp;eats.&nbsp;
Philosopher&nbsp;3&nbsp;eats.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;5&nbsp;picked&nbsp;4&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;2&nbsp;picked&nbsp;1&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;2&nbsp;picked&nbsp;2&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;5&nbsp;picked&nbsp;5&nbsp;chopstick.&nbsp;
Philosopher&nbsp;2&nbsp;eats.&nbsp;
Philosopher&nbsp;5&nbsp;eats.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;4&nbsp;picked&nbsp;3&nbsp;chopstick.&nbsp;
&nbsp;&nbsp;&nbsp;Philosopher&nbsp;4&nbsp;picked&nbsp;4&nbsp;chopstick.&nbsp;
Philosopher&nbsp;4&nbsp;eats.&nbsp;
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
<dl>
<p>I hope the code will help some of you to learn concepts of thread synchronization and parallel programming using C&#43;&#43; 11.</p>
</dl>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h2>Source Code Files</h2>
<dl><dt>program.cpp - the only file in the project &nbsp;</dt></dl>
<div>&nbsp;</div>
<dl></dl>
