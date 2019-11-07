# Dependency Injection in ASP.NET Core 2.0
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Dependency Injection
- ASP.NET Core 2.0
## Topics
- Dependency Injection
- ASP.NET Core 2.0
## Updated
- 02/19/2018
## Description

<h1>Introduction</h1>
<p><img id="188814" src="188814-1.png" alt="" width="1245" height="354"></p>
<p>In this article we will see in detail on how to use Dependency Injection in ASP.NET Core 2.0. Now its much easier to use Dependency Injection in our ASP.NET Core application and the fact is that its very simple and use the result to bind in our View page.
 Let&rsquo;s see in details on how to create our ASP.NET Core project to use Dependency Injection for binding the student details to our View page. Hope you might be know about what is Dependency Injection and if you are curious to learn more detail about Dependency
 Injection then start from here &nbsp;<a href="https://msdn.microsoft.com/en-us/library/hh323705%28v=vs.100%29.aspx?f=255&MSPPError=-2147217396" target="_blank">The Dependency Injection Design Pattern</a>&nbsp;,&nbsp;<a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection" target="_blank">Dependency
 injection in ASP.NET Core</a></p>
<p><span style="font-size:2em">Building the Sample</span></p>
<p>Make sure you have installed all the prerequisites in your computer. If not, then download and install all, one by one.</p>
<ol>
<li>First, download and install Visual Studio 2017 from this&nbsp;<a href="https://www.visualstudio.com/" target="_blank">link</a>.
</li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Now, it&rsquo;s time to create our first Angular5 and ASP.NET Core application.</p>
<h1><strong>Step 1- Create&nbsp;</strong><strong>ASP.NET Core Application</strong></h1>
<p><strong>&nbsp;</strong>After installing the prerequisites listed above, click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2017 &gt;&gt; Visual Studio 2017, on your desktop.</p>
<p>Click New &gt;&gt; Project. Select Visual C# &gt;&gt; Select Angular5Core2. Enter your project name and click OK.</p>
<p><img id="188815" src="188815-2.png" alt="" width="862" height="444"></p>
<p>Select ASP.NET Core 2.0 , select&nbsp; Web Application(Model-View-Controller) and click ok.</p>
<p><img id="188816" src="188816-3.png" alt="" width="788" height="517"></p>
<p>Our project will be created and its time for us to add a Class, Interface and Service for using Dependency Injection in ASP.NET Core application.</p>
<h1><strong>Step 2 &ndash; Creating Data Folder for Class</strong></h1>
<p>First, we will start with creating a class and for this from our project create a folder and name it as data as shown below.</p>
<p><img id="188817" src="188817-4.png" alt="" width="261" height="238"></p>
<p>Now we have created a folder named as Data in our project and next step will be to create a class named as &ldquo;StudentDetails&rdquo;. Right click the Data Folder and Add a new class named as &ldquo;StudentDetails&rdquo;</p>
<p><img id="188818" src="188818-5.png" alt="" width="813" height="443"></p>
<p>In Studentdetails class we create property as student name, Subjects and grade for each student like below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class StudentDetails 
    { 
        public string studentName { get; set; } 
        public string Subject1 { get;  set; } 
        public string Subject2 { get;  set; } 
        public string Subject3 { get;  set; } 
        public string Subject4 { get;  set; } 
        public string Subject5 { get;  set; } 
        public string Grade { get;  set; }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;StudentDetails&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;studentName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Subject1&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Subject2&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Subject3&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Subject4&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Subject5&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Grade&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>Now it&rsquo;s time for us to create an interface with method named as GetAllStudentDetails() and we will be implementing this interface in our Service. For creating the Interface as we seen before add a new class to your data folder and name the class as
 &ldquo;IStudentDetailService&rdquo;.We will change the class to interface as we are going to create a interface to implement in our service. Here in this interface we declare a method as GetAllStudentDetails() with return type as IEnumerable</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IStudentDetailService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;StudentDetails&gt;&nbsp;GetAllStudentDetails();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong style="font-size:2em">Step 3 &ndash; Creating Service</strong></p>
<p>First, we create a folder named as Services in project, right click your project and create a new folder as &ldquo;Services&rdquo;.</p>
<p><img id="188819" src="188819-6.png" alt="" width="267" height="206"></p>
<p>Now let&rsquo;s add a new class in this folder and named as &ldquo;StudentService&rdquo; and in this class we will be implementing our Interface IStudentDetailService. We know that as if we implement the interface then we should the interface method in our
 class.In this service we use the interface method and we return the list with student details. We will be directly Inject this in our View page.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">using&nbsp;ASPNETCOREDependencyInjection.Data;&nbsp;
&nbsp;
namespace&nbsp;ASPNETCOREDependencyInjection.Services&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentService:IStudentDetailService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;StudentDetails&gt;&nbsp;GetAllStudentDetails()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span><span class="js__operator">new</span>&nbsp;List&lt;StudentDetails&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__operator">new</span>&nbsp;&nbsp;StudentDetails&nbsp;<span class="js__brace">{</span>studentName&nbsp;=&nbsp;<span class="js__string">&quot;Afreen&quot;</span>,&nbsp;Subject1&nbsp;=&nbsp;<span class="js__string">&quot;.Net&nbsp;Programming&quot;</span>,Subject2=<span class="js__string">&quot;Operating&nbsp;System&quot;</span>,Subject3=<span class="js__string">&quot;Web&nbsp;Programming&quot;</span>,Subject4=<span class="js__string">&quot;Networks&quot;</span>,Subject5=<span class="js__string">&quot;C#&nbsp;&amp;&nbsp;OOP&quot;</span>,Grade=<span class="js__string">&quot;A&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;StudentDetails&nbsp;<span class="js__brace">{</span>studentName&nbsp;=&nbsp;<span class="js__string">&quot;kather&quot;</span>,&nbsp;Subject1&nbsp;=&nbsp;<span class="js__string">&quot;.Net&nbsp;Programming&quot;</span>,Subject2=<span class="js__string">&quot;Operating&nbsp;System&quot;</span>,Subject3=<span class="js__string">&quot;Web&nbsp;Programming&quot;</span>,Subject4=<span class="js__string">&quot;Networks&quot;</span>,Subject5=<span class="js__string">&quot;C#&nbsp;&amp;&nbsp;OOP&quot;</span>,Grade=<span class="js__string">&quot;A&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;StudentDetails&nbsp;<span class="js__brace">{</span>studentName&nbsp;=&nbsp;<span class="js__string">&quot;Asha&quot;</span>,&nbsp;Subject1&nbsp;=&nbsp;<span class="js__string">&quot;.Net&nbsp;Programming&quot;</span>,Subject2=<span class="js__string">&quot;Operating&nbsp;System&quot;</span>,Subject3=<span class="js__string">&quot;Web&nbsp;Programming&quot;</span>,Subject4=<span class="js__string">&quot;Networks&quot;</span>,Subject5=<span class="js__string">&quot;C#&nbsp;&amp;&nbsp;OOP&quot;</span>,Grade=<span class="js__string">&quot;A&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;&nbsp;StudentDetails&nbsp;<span class="js__brace">{</span>studentName&nbsp;=&nbsp;<span class="js__string">&quot;Afraz&quot;</span>,&nbsp;Subject1&nbsp;=&nbsp;<span class="js__string">&quot;.Net&nbsp;Programming&quot;</span>,Subject2=<span class="js__string">&quot;Operating&nbsp;System&quot;</span>,Subject3=<span class="js__string">&quot;Web&nbsp;Programming&quot;</span>,Subject4=<span class="js__string">&quot;Networks&quot;</span>,Subject5=<span class="js__string">&quot;C#&nbsp;&amp;&nbsp;OOP&quot;</span>,Grade=<span class="js__string">&quot;B&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;&nbsp;StudentDetails&nbsp;<span class="js__brace">{</span>studentName&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>,&nbsp;Subject1&nbsp;=&nbsp;<span class="js__string">&quot;.Net&nbsp;Programming&quot;</span>,Subject2=<span class="js__string">&quot;Operating&nbsp;System&quot;</span>,Subject3=<span class="js__string">&quot;Web&nbsp;Programming&quot;</span>,Subject4=<span class="js__string">&quot;Networks&quot;</span>,Subject5=<span class="js__string">&quot;C#&nbsp;&amp;&nbsp;OOP&quot;</span>,Grade=<span class="js__string">&quot;C&quot;</span><span class="js__brace">}</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong style="font-size:2em">Step 4 &ndash; Register the Service</strong></p>
<p>We need to register our created service to the container, Open the Startup.cs from your project to add our service to the container.</p>
<p><img id="188820" src="188820-7.png" alt="" width="331" height="344"></p>
<p>In the Startup.cs class find the method named as ConfigureServices and we add our service &ldquo;StudentService&rdquo; like below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;This&nbsp;method&nbsp;gets&nbsp;called&nbsp;by&nbsp;the&nbsp;runtime.&nbsp;Use&nbsp;this&nbsp;method&nbsp;to&nbsp;add&nbsp;services&nbsp;to&nbsp;the&nbsp;container.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddTransient&lt;StudentService,&nbsp;StudentService&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong>Step 5 &ndash; Inject the Service in View page</strong></p>
<p>Now it&rsquo;s much simple and easier as we can directly Inject the service in our View page and bind all the result to our view page. For injecting the Service in our View, here we will be using our existing view page from Home &gt;&gt; Index.cshtml</p>
<p><img id="188821" src="188821-8.png" alt="" width="338" height="328"></p>
<p>In the &ldquo;Index.cshtml&rdquo; we inject our StudentService and bind all the result inside the table.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">@inject&nbsp;ASPNETCOREDependencyInjection.Services.StudentService&nbsp;student&nbsp;
&nbsp;
@<span class="js__statement">if</span>&nbsp;(student.GetAllStudentDetails().Any())&nbsp;
<span class="js__brace">{</span>&nbsp;
&lt;table&nbsp;class=<span class="js__string">'table'</span>&nbsp;style=<span class="js__string">&quot;background-color:#FFFFFF;&nbsp;border:2px#6D7B8D;&nbsp;padding:5px;width:99%;table-layout:fixed;&quot;</span>&nbsp;cellpadding=<span class="js__string">&quot;2&quot;</span>&nbsp;cellspacing=<span class="js__string">&quot;2&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;style=<span class="js__string">&quot;height:&nbsp;30px;&nbsp;background-color:#336699&nbsp;;&nbsp;color:#FFFFFF&nbsp;;border:&nbsp;solid1px#659EC7;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Student&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subject&nbsp;<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;&nbsp;&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subject&nbsp;<span class="js__num">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subject&nbsp;<span class="js__num">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subject&nbsp;<span class="js__num">4</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subject&nbsp;<span class="js__num">5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;&nbsp;&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grade&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(<span class="js__statement">var</span>&nbsp;std&nbsp;<span class="js__operator">in</span>&nbsp;student.GetAllStudentDetails().OrderBy(x&nbsp;=&gt;&nbsp;x.studentName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid1px#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@std.studentName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid1px#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@std.Subject1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid1px#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@std.Subject2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid1px#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@std.Subject3&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid1px#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@std.Subject4&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid1px#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@std.Subject5&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid1px#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@std.Grade&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&lt;/table&gt;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong>Step 6 &ndash; Build and Run the project</strong></p>
<p><strong>&nbsp;</strong>Build and run the project as we can see all our student&rsquo;s details will be displayed in our home page.</p>
<p><img id="188814" src="188814-1.png" alt="" width="1245" height="354"></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>ASPNETCOREDependencyInjection&nbsp;<em>-Complete Source code attached for download</em>
</li></ul>
<h1>More Information</h1>
<p><em>We can see clearly as now ASP.NET Core make&rsquo;s our workload much simple and easy to use Dependency Injection &nbsp;to directly Inject in our View page and bind the results.</em></p>
