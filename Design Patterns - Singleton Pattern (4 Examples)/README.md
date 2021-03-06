# Design Patterns - Singleton Pattern (4 Examples)
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- .NET
- Windows Forms
- WPF
- ASP.NET Web Forms
- WPF Silverlight XAML
## Topics
- Architecture and Design
- Design Patterns
- Singleton
- Singleton Pattern
## Updated
- 04/30/2013
## Description

<div class="endscriptcode"><span style="color:#008000; font-size:medium">Targeted Audience:</span></div>
<ol>
<li>.NET Architects </li><li>.NET Application Designers </li><li>.NET Application Developers </li></ol>
<div><span style="color:#008000; font-size:medium">Prerequisites:</span></div>
<ol>
<li>.Net technologies. </li><li>Basic understanding of design patterns. </li><li>Basic understanding of OOPS. </li></ol>
<div><span style="color:#008000; font-size:medium">Problem Statement:</span></div>
<ul>
<li>You are building an application in C# and you need a class that has only one instance, and you need to provide a global point of access to the instance.
</li><li>You want to be sure that your solution is efficient and that it takes advantage of the Microsoft .NET common language runtime features.
</li><li>You may also want to make sure that your solution is thread safe. </li></ul>
<div><strong>Note:</strong> The definition of singleton used here is intentionally narrower than in
<em>Design Patterns: Elements of Reusable Object-Oriented Software </em>[Gamma95].</div>
<div></div>
<div><span style="color:#008000; font-size:medium">Solution:</span></div>
<div><span style="font-size:small"><em>&nbsp;</em></span>&nbsp;</div>
<div><span style="font-size:small"><em>Singleton </em>provides a global, single instance by:</span></div>
<ul>
<li>Making the class create a single instance of itself. </li><li>Allowing other objects to access this instance through a class method that returns a reference to the instance. A class method is globally accessible.
</li><li>Declaring the class constructor as private so that no other object can create a new instance.
</li></ul>
<div><span style="color:#008000; font-size:medium">What is Singleton Pattern?</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div>A design pattern that restricts the instantiation of a class to one object</div>
<div>&nbsp;</div>
<div>Below Figure shows the static structure of this pattern. The UML class diagram is surprisingly simple because
<em>Singleton</em> consists of a simple class that holds a reference to a single instance of itself.</div>
<div>&nbsp;</div>
<div>&nbsp;<img id="63544" src="http://i1.gallery.technet.s-msft.com/dive-into-singleton-pattern-91ef8a8f/image/file/63544/1/stp.png" alt="" width="195" height="88"></div>
<div><span style="color:#008000; font-size:medium">Singleton Pattern Principle:</span></div>
<div></div>
<div>This approach ensures that only one instance is created and only when the instance is needed.</div>
<div></div>
<div><span style="color:#008000; font-size:medium">Advantages of Singleton Pattern:</span></div>
<ul>
<li>The static initialization approach is possible because the .NET Framework explicitly defines how and when static variable initialization occurs.
</li><li>The Double-Check Locking idiom described below in &quot;Multithreaded Singleton&quot; is implemented correctly in the common language runtime.
</li></ul>
<div><span style="color:#008000; font-size:medium">Disadvantages or liabilities of Singleton Pattern:</span></div>
<ul>
<li>Unit testing far more difficult as it introduces global state into an application.
</li><li>Reduces the potential for parallelism within a program, because access to the singleton in a multi-threaded context must be serialized, e.g., by locking.
</li><li>Requires explicit initialization in multithreaded application, and we have to take precautions to avoid threading issues.
</li><li>Advocates of dependency injection would regard this as an anti-pattern, mainly due to its use of private and static methods.
</li><li>The singleton instance is obtained using the class name. At the first view this is an easy way to access it, but it is not very flexible. If we need to replace the Singleton class, all the references in the code should be changed accordingly.
</li><li>Some have suggested ways to break down the singleton pattern using methods such as reflection in languages such as C#, Java etc.
</li></ul>
<div><span style="color:#008000; font-size:medium">Common Uses:</span></div>
<ul>
<li><strong>Logger Classes:</strong> The Singleton pattern is used in the design of logger classes. To provide a global logging access point in all the application components without being necessary to create an object each time a logging operations is performed.
</li><li><strong>Configuration Classes:</strong> The Singleton pattern is used to design the classes which provides the configuration settings for an application. By implementing configuration classes as Singleton not only that we provide a global access point,
 but we also keep the instance we use as a cache object. When the class is instantiated (or when a value is read) the singleton will keep the values in its internal structure. If the values are read from the database or from files this avoids the reloading
 the values each time the configuration parameters are used. </li><li><strong>Accessing resources in shared mode:</strong> It can be used in the design of an application that needs to work with the serial port. Let's say that there are many classes in the application, working in a multi-threading environment, which needs
 to operate actions on the serial port. In this case a singleton with synchronized methods could be used to manage all the operations on the serial port.
</li><li>Factories implemented as Singletons </li><li>Let's assume that we design an application with a factory to generate new objects (Account, Customer, Site, Address objects) with their IDs, in a multithreading environment. If the factory is instantiated twice in 2 different threads then it is possible
 to have 2 overlapping IDs for 2 different objects. If we implement the Factory as a singleton we avoid this problem. Combining Abstract Factory or Factory Method and Singleton design patterns is a common practice.
</li><li>The Abstract Factory, Builder, and Prototype patterns can use Singletons in their implementation.
</li><li>&nbsp;Facade Objects are often Singletons because only one Facade object is required.
</li><li>&nbsp;State objects are often Singletons. </li><li>&nbsp;Singletons are often preferred to global variables because:
<ul>
<li>They do not pollute the global name space (or, in languages with namespaces, their containing namespace) with unnecessary variables.[7]
</li><li>They permit lazy allocation and initialization, whereas global variables in many languages will always consume resources.
</li></ul>
</li></ul>
<div><span style="color:#008000; font-size:medium">Additional References:</span></div>
<div></div>
<div><a href="http://msdn.microsoft.com/en-us/library/ff650849.aspx">http://msdn.microsoft.com/en-us/library/ff650849.aspx</a></div>
<div><a href="http://msdn.microsoft.com/en-us/library/ff650316.aspx">http://msdn.microsoft.com/en-us/library/ff650316.aspx</a></div>
<div><a href="http://en.wikipedia.org/wiki/Singleton_pattern">http://en.wikipedia.org/wiki/Singleton_pattern</a></div>
<div></div>
<div><span style="color:#008000; font-size:medium">Implementation Ways:</span></div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Example&nbsp;1:&nbsp;</span>&nbsp;
<span class="cs__keyword">class</span>&nbsp;Emp&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;No&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Sal&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Private&nbsp;static&nbsp;object&nbsp;can&nbsp;access&nbsp;only&nbsp;inside&nbsp;the&nbsp;Emp&nbsp;class.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Emp&nbsp;emp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Private&nbsp;empty&nbsp;constructor&nbsp;to&nbsp;restrict&nbsp;end&nbsp;use&nbsp;to&nbsp;deny&nbsp;creating&nbsp;the&nbsp;object.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Emp()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;A&nbsp;public&nbsp;method&nbsp;to&nbsp;access&nbsp;outside&nbsp;of&nbsp;the&nbsp;class&nbsp;to&nbsp;create&nbsp;an&nbsp;object.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Emp&nbsp;CreateObject()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;the&nbsp;object&nbsp;is&nbsp;null&nbsp;for&nbsp;first&nbsp;time&nbsp;instantiate&nbsp;it&nbsp;once.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(emp&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Emp();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Return&nbsp;the&nbsp;emp&nbsp;object,&nbsp;when&nbsp;user&nbsp;request&nbsp;for&nbsp;create&nbsp;an&nbsp;instance.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;emp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">class</span>&nbsp;Program&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Emp&nbsp;emp1&nbsp;=&nbsp;Emp.CreateObject();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp1.No&nbsp;=&nbsp;<span class="cs__number">10</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp1.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sai&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp1.Sal&nbsp;=&nbsp;<span class="cs__string">&quot;10000&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Employee&nbsp;1&nbsp;Details:\n&nbsp;No:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp1.No&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&nbsp;Name:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp1.Name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&nbsp;Sal:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp1.Sal);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Emp&nbsp;emp2&nbsp;=&nbsp;Emp.CreateObject();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp2.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sri&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Employee&nbsp;2&nbsp;Details:\n&nbsp;No:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp2.No&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&nbsp;Name:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp2.Name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&nbsp;Sal:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp2.Sal);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Emp&nbsp;emp3&nbsp;=&nbsp;Emp.CreateObject();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp1.Sal&nbsp;=&nbsp;<span class="cs__string">&quot;5000&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Employee&nbsp;2&nbsp;Details:\n&nbsp;No:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp3.No&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&nbsp;Name:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp3.Name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&nbsp;Sal:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;emp3.Sal);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Example&nbsp;2:&nbsp;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Singleton&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Private&nbsp;static&nbsp;object&nbsp;can&nbsp;access&nbsp;only&nbsp;inside&nbsp;the&nbsp;Emp&nbsp;class.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Singleton&nbsp;instance;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Private&nbsp;empty&nbsp;constructor&nbsp;to&nbsp;restrict&nbsp;end&nbsp;use&nbsp;to&nbsp;deny&nbsp;creating&nbsp;the&nbsp;object.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Singleton()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;A&nbsp;public&nbsp;property&nbsp;to&nbsp;access&nbsp;outside&nbsp;of&nbsp;the&nbsp;class&nbsp;to&nbsp;create&nbsp;an&nbsp;object.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Singleton&nbsp;Instance&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(instance&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;instance&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Singleton();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;instance;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Example&nbsp;3:&nbsp;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SealedSingleton&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;SealedSingleton&nbsp;instance&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SealedSingleton();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;SealedSingleton()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;SealedSingleton&nbsp;Instance&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;instance;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="color:#008000; font-size:medium">// Example 4:</span></div>
</div>
<div><span style="color:#008000; font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">Thread-safe</span><span style="font-size:small">&nbsp;</span><span style="font-size:small">implementation for multi-threading use:</span></div>
<div></div>
<div><span style="font-size:small">A robust singleton implementation should work in any conditions.</span></div>
<div><span style="font-size:small">This is why we need to ensure it works when multiple threads</span><span style="font-size:small">&nbsp;</span><span style="font-size:small">uses it.</span></div>
<div><span style="font-size:small">Singletons can be used specifically in multi-threaded</span><br>
<span style="font-size:small">application to make sure the reads/writes are synchronized.</span></div>
<div></div>
<div><span style="font-size:small">Lazy</span><span style="font-size:small">&nbsp;</span><span style="font-size:small">instantiation using double locking mechanism:</span></div>
<div></div>
<div><span style="font-size:small">The standard implementation is a thread safe</span><span style="font-size:small">&nbsp;</span><span style="font-size:small">implementation, but it's not the best thread-safe implementation because</span><br>
<span style="font-size:small">synchronization is very expensive when we are talking about the performance.</span></div>
<div><span style="font-size:small">We can see that the synchronized method does</span><span style="font-size:small">&nbsp;</span><span style="font-size:small">not need to be checked for synchronization after the object is initialized.</span></div>
<div><span style="font-size:small">If we see that the singleton object is already</span><span style="font-size:small">&nbsp;</span><span style="font-size:small">created we just have to return it without using any synchronized block.</span></div>
<div><span style="font-size:small">This optimization consists in checking in an</span><span style="font-size:small">&nbsp;</span><span style="font-size:small">unsynchronized block if the object is null and if not to check again and create</span><br>
<span style="font-size:small">it in synchronized block. This is called&nbsp;<em>double locking mechanism</em>.</span></div>
<ul>
<li><span style="font-size:small">Static initialization is suitable&nbsp;</span><span style="font-size:small">for most situations.</span>
</li><li><span style="font-size:small">When your application must delay the&nbsp;</span><span style="font-size:small">instantiation, use a non-default constructor or perform other tasks before the&nbsp;</span><span style="font-size:small">instantiation, and work
 in a multithreaded environment, you need a different&nbsp;</span><span style="font-size:small">solution.</span>
</li><li><span style="font-size:small">Cases do exist, however, in which&nbsp;</span><span style="font-size:small">you cannot rely on the CLR to ensure thread safety, as in the Static&nbsp;</span><span style="font-size:small">Initialization example.</span>
</li><li><span style="font-size:small">In such cases, you must use specific&nbsp;</span><span style="font-size:small">language capabilities to ensure that only one instance of the object is created&nbsp;</span><span style="font-size:small">in the presence of multiple
 threads.</span> </li><li><span style="font-size:small">One of the more common solutions is&nbsp;</span><span style="font-size:small">to use the Double-Check Locking [Lea99] idiom to keep separate threads from&nbsp;</span><span style="font-size:small">creating new instances of the
 singleton at the same time.</span> </li><li><span style="font-size:small">Note: The CLR resolves issues&nbsp;</span><span style="font-size:small">related to using Double-Check Locking that are common in other environments.&nbsp;</span><span style="font-size:small">For more information about these&nbsp;</span><span style="font-size:small">issues,
 see &quot;The 'Double-Checked Locking Is Broken' Declaration,&quot; on&nbsp;</span><span style="font-size:small">the University of Maryland, Department of Computer Science Web site, at&nbsp;</span><a href="http://www.cs.umd.edu/~pugh/java/memoryModel/DoubleCheckedLocking.html" style="font-size:small">ttp://www.cs.umd.edu/~pugh/java/memoryModel/DoubleCheckedLocking.html</a>
</li><li><span style="font-size:small">The variable is declared to be&nbsp;</span><span style="font-size:small">volatile to ensure that assignment to the instance variable completes before&nbsp;</span><span style="font-size:small">the instance variable can be accessed.</span>
</li><li><span style="font-size:small">Lastly, this approach uses a&nbsp;</span><span style="font-size:small">syncRoot instance to lock on, rather than locking on the type itself, to avoid&nbsp;</span><span style="font-size:small">deadlocks.</span>
</li><li><span style="font-size:small">This double-check locking approach&nbsp;</span><span style="font-size:small">solves the thread concurrency problems while avoiding an exclusive lock in&nbsp;</span><span style="font-size:small">every call to the Instance property
 method.</span> </li><li><span style="font-size:small">It also allows you to delay&nbsp;</span><span style="font-size:small">instantiation until the object is first accessed.</span>
</li><li><span style="font-size:small">In practice, an application rarely&nbsp;</span><span style="font-size:small">requires this type of implementation. In most cases, the static initialization&nbsp;</span><span style="font-size:small">approach is sufficient.</span>
</li></ul>
<p><span style="font-size:small">The following implementation allows&nbsp;</span><span style="font-size:small">only a single thread to enter the critical area, which the lock block&nbsp;</span><span style="font-size:small">identifies, when no instance of Singleton
 has yet been created:</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MultiThreadSingleton&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">volatile</span>&nbsp;MultiThreadSingleton&nbsp;instance;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;syncRoot&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Object();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;MultiThreadSingleton()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;MultiThreadSingleton&nbsp;Instance&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(instance&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(syncRoot)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(instance&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;instance&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MultiThreadSingleton();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;instance;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"></div>
<p><span style="color:#000000; font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with
<span style="color:#3366ff"><img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">
<span style="color:#000000">star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Good).
</span></span></span></p>
<div class="endscriptcode"><span style="color:#3366ff">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Visit my all other articles here
<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Srigopal%20Chitrapu">
http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Srigopal%20Chitrapu</a></span></div>
<p></p>
