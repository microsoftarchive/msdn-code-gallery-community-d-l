# Invoke Method to update UI from secondary threads
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Visual Basic .NET
## Topics
- File System
- UI Automation
- Task Parallelism
- Task
## Updated
- 01/24/2016
## Description

<h1>Introduction</h1>
<p>As many developers well knows, it's not possible - using .NET Framework - to realize a direct interaction between processes which run on threads different from the one on which the UI resides (tipically, the main thread of the program). We are in a situation
 from which we can exploit the many advantages of multi-threading programming to execute parallel operations, but if those tasks must return an immediate graphical result, we won't be able to access the user controls from those processes.</p>
<p>In this brief article, we'll see how can be possibile, through&nbsp;<a href="https://msdn.microsoft.com/it-it/library/zyzhdc6b%28v=vs.110%29.aspx" target="_blank">Invoke&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src="-10_5f00_external.png" border="0" alt="">&nbsp;</a>&nbsp;method,
 which is available to all controls through the&nbsp;<a href="https://msdn.microsoft.com/it-it/library/system.windows.forms(v=vs.110).aspx" target="_blank">System.Windows.Form&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src="-10_5f00_external.png" border="0" alt="">&nbsp;</a>&nbsp;namespace,
 to realize such functionality, in order to execute a graphic refresh and update through delegates.</p>
<p>&nbsp;</p>
<hr>
<h1><a name="Delegati"></a>Delegates</h1>
<p>The MSDN documentation states delegates are construct which could be compared to the pointer of functions in languages like C or C&#43;&#43;. Delegates incapsulate a method inside an object. The delegate object could then be passed to code which will execute the
 referenced method, o method that could be unknown during the compilation phase of the program itself. Delegates could be&nbsp;<a href="https://msdn.microsoft.com/it-it/library/system.eventhandler(v=vs.110).aspx" target="_blank">EventHandler&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src="-10_5f00_external.png" border="0" alt="">&nbsp;</a>&nbsp;instances,&nbsp;<a href="https://msdn.microsoft.com/it-it/library/system.windows.forms.methodinvoker(v=vs.110).aspx" target="_blank">MethodInvoker&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src="-10_5f00_external.png" border="0" alt="">&nbsp;</a>-type
 objects, or any other form of object which ask for a void list of parameters.</p>
<p>Here follows a pretty trivial, though effective, example of their use</p>
<p>&nbsp;</p>
<hr>
<h1><a name="Esempio"></a>Basic example</h1>
<p>Let's consider a WinForm on which will reside a Label, Label2. That label must be use to show an increasing numeric counter. Since we desire to execute the value increase on a separated thread, we will incur into the named problem. Let's see why. First of
 all, we will write the code that will execute the increment of our numerical value on a secondary task from the main one, trying to update Label2, to observe the result of the operation.</p>
<div class="reCodeBlock">
<div><span><code>Private</code>&nbsp;<code>Sub</code>&nbsp;<code>Form1_Load(sender&nbsp;</code><code>As</code>&nbsp;<code>Object</code><code>, e&nbsp;</code><code>As</code>&nbsp;<code>EventArgs)&nbsp;</code><code>Handles</code>&nbsp;<code>MyBase</code><code>.Load</code></span></div>
<div><span><code>&nbsp;</code>&nbsp;<code>Dim</code>&nbsp;<code>n&nbsp;</code><code>As</code>&nbsp;<code>Integer</code>&nbsp;<code>= 0</code></span></div>
<div><span>&nbsp;</span></div>
<div><span><code>&nbsp;</code>&nbsp;<code>Dim</code>&nbsp;<code>t&nbsp;</code><code>As</code>&nbsp;<code>New</code>&nbsp;<code>Task(</code><code>New</code>&nbsp;<code>Action(</code><code>Sub</code><code>()</code></span></div>
<div><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><code>n &#43;= 1</code></span></div>
<div><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><code>Label2.Text = n.ToString</code></span></div>
<div><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><code>End</code>&nbsp;<code>Sub</code><code>))</code></span></div>
<div><span><code>&nbsp;</code><code>t.Start()</code></span></div>
<div><span><code>End</code>&nbsp;<code>Sub</code></span></div>
</div>
<p>At runtime, the raised exception will attest what we saw up to here: it's not possible to modify an object properties (in reality, some of them), if the object itself is managed from a different thread other than the main one.</p>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/2134.error.png"><img src="-2134.error.png" alt=" "></a></p>
<p>Continue Reading here:&nbsp;<a href="http://social.technet.microsoft.com/wiki/contents/articles/33280.invoke-method-to-update-ui-from-secondary-threads-in-vb-net.aspx" target="_blank">http://social.technet.microsoft.com/wiki/contents/articles/33280.invoke-method-to-update-ui-from-secondary-threads-in-vb-net.aspx</a></p>
