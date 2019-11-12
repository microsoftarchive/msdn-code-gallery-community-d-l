# Getting Started: Windows Workflow Foundation and ASP.NET
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Windows Workflow
- Workflow
- WF
- Windows Workflow Foundation
- WF4
- Windows Workflow 4
## Topics
- Workflow
- Getting Started
## Updated
- 02/01/2012
## Description

<h1>Introduction</h1>
<p>Windows Workflow Foundation is a great technology for creating workflows. It can be used in combination with different technologies, for example SharePoint, WCF, etc. In this article we will combine the Windows Workflow Foundation with ASP.NET.</p>
<p>This is the sample solution for the TechNet Wiki article <a href="http://social.technet.microsoft.com/wiki/contents/articles/5284.getting-started-windows-workflow-foundation-and-asp-net-en-us.aspx">
Gettings Started: Windows Workflow Foundation</a>. This article describes the easy combination of ASP.NET and Windows Workflow Foundation.</p>
<p>You will learn how to build a simple workflow with an input and an output and how to integrate this workflow in a simple ASP.NET application.</p>
<p>The download contains the code files of the sample ASP.NET website and Windows Workflow foundation workflow which are used in the greeting example of this article.</p>
<h1>The Scenario</h1>
<p>To hold things easy, we will create a very simple greeting application. The user will type in his name into a TextBox, clicks a button and a greeting with his name will appear. Sounds simple? It is!</p>
<h1>File - New - Project</h1>
<p>Start by creating an empty Visual Studio Solution:</p>
<p><img title="Create a blank solution" src="-createblanksolution.jpg" alt="Create a blank solution" style="border:0px solid currentColor"></p>
<p>Name it whatever you want. We will now add two projects to this solution - An <em>
ASP.NET Empty Web Application</em> (Workflow.Web) and an <em>Activitiy Library</em> (WorkflowLibrary).</p>
<p><img title="Create the ASP.NET Web Application" src="-createaspnetemptywebapp.jpg" alt="Create the ASP.NET Web Application"></p>
<div></div>
<p><img title="Create the Activity Library" src="-createactivitylibrary.jpg" alt="Create the Activity Library"></p>
<p>&nbsp;</p>
<h1>Set it up</h1>
<h2>On the side of our Workflow</h2>
<p>For now, just delete the Activity1.xaml file.</p>
<h2>On the side of our Website</h2>
<p>Create a new Web Form and name it Default.aspx:</p>
<p><img title="Add the Web Form" src="-createdefaultaspx.jpg" alt="Add the Web Form"></p>
<p>We need four controls on our site:</p>
<ul>
<li>A Label, which only shows &quot;Your name: &quot;; no more functionality </li><li>A TextBox, where the user can type in his name </li><li>A Button, which will be trigger the workflow </li><li>A Label, which displays the result of the workflow, our greeting </li></ul>
<p>The code is unspectacular; you only need a click event on the Button control:</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&nbsp;AutoEventWirkup=&quot;</span>true&quot;&nbsp;<span class="html__attr_name">CodeBhind</span>=<span class="html__attr_value">&quot;Default.aspx.cs&quot;</span>&nbsp;<span class="html__attr_name">Inherits</span>=<span class="html__attr_value">&quot;Workflow.Web.Default&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;
<span class="html__doctype">&lt;!DOCTYPE&nbsp;html&nbsp;PUBLIC&nbsp;&quot;-//W3C//DTD&nbsp;XHTML&nbsp;1.0&nbsp;Transitional//EN&quot;&nbsp;&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;html</span>&nbsp;<span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Label&nbsp;<span class="html__attr_name">Text</span>=<span class="html__attr_value">&quot;Your&nbsp;name:&nbsp;&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:TextBox&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;TextBoxName&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Button&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;ButtonCreateGreeting&quot;</span>&nbsp;<span class="html__attr_name">Text</span>=<span class="html__attr_value">&quot;Create&nbsp;greeting&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;ButtonCreateGreeting_Click&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Label&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;LabelGreeting&quot;</span>&nbsp;<span class="html__attr_name">Text</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<p>&nbsp;</p>
<h1>Create the Workflow</h1>
<p>At the beginning, create a new activity and name it Greeting.xaml. First we need an In argument and an Out argument. The In argument will take the name of our user. The Out argument will hold the greeting and will be assigned to the greeting label on our
 website.</p>
<p>Open the Arguments tab at the bottom of the designer. The first argument has the name
<em>ArgUserName</em>, the direction <em>In</em> and the Argument type <em>String</em>. The second argument takes the name
<em>Result</em>, the direction <em>Out</em> and the Argument type <em>String</em>, too.</p>
<p>In both cases you can leave the cell for the Default value empty. The Result will look like this:</p>
<p><img title="Creating the In and Out arguments" src="-argumentstab.jpg" alt="Creating the In and Out arguments" style="border:0px solid currentColor"></p>
<p>Add a <strong>Sequence Activity</strong> to it. The <strong>Sequence Activity</strong> ensures that the child activities runs according to a single defined ordering.</p>
<p><img title="Adding a Sequence Activity" src="-addsequence.jpg" alt="Adding a Sequence Activity" width="522" height="640" style="width:522px; height:640px"></p>
<p>Inside the <strong>Sequence Activity</strong> add an <strong>Assign Activity</strong>. This activity will assign the greeting to our earlier created
<em>Result</em> argument.</p>
<p>The <em>To</em> property will be our Result argument. The <em>Value</em> property can be created with the Expression Editor. The next picture shows the expression.</p>
<p><img title="Assign the greeting to the Out argument" src="-expressioneditor.jpg" alt="Assign the greeting to the Out argument"></p>
<p>Please note, every expression in the Workflow Designer must be a Visual Basic expression.</p>
<p>The result should look as follows:</p>
<p><img title="The finished workflow" src="-workflowend.jpg" alt="The finished workflow" width="503" height="600" style="width:503px; height:600px"></p>
<p>&nbsp;</p>
<h1>Combine it</h1>
<p>To complete our application, add a reference to the <em>WorkflowLibrary</em> in our web application. We also need the
<em>WorkflowInvoker</em> class, so add a reference to <em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Activities.aspx" target="_blank" title="Auto generated link to System.Activities">System.Activities</a></em> to our web application.</p>
<p>In the click method of our button add the following code:</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Activities&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;WorkflowLibrary&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;_Default&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;System.Web.UI.Page&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Page_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ButtonCreateGreeting_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;ButtonCreateGreeting.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;username&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;TextBoxName.Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;greeting&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Greeting&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Greeting&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{&nbsp;.ArgUserName&nbsp;=&nbsp;username&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;results&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;=&nbsp;WorkflowInvoker.Invoke(greeting)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LabelGreeting.Text&nbsp;=&nbsp;results(<span class="visualBasic__string">&quot;Result&quot;</span>).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
</div>
<p>Does it looks light magic? Not really.</p>
<p>First we retrieve the entered name from the TextBox. Next we need an instance of our workflow and pass in the username as the
<em>In</em> argument. To invoke our Workflow we call the <em>Invoke</em>-method with our workflow instance. It retrieves the
<em>Out</em> arguments as an <em>Dictionary</em>, where the key will be a <em>string</em> and the value an
<em>object</em>. As the last thing we just have to get our <em>Result</em> argument out of the
<em>Dictionary</em> and assign it to our greeting Label.</p>
<p>That's it! Run the project! The result should look like this:</p>
<p><img title="The result" src="-resultsite.jpg" alt="The result"></p>
<p>&nbsp;</p>
<h1>Lessons Learned</h1>
<p>We have seen how to create a simple workflow with <em>In</em> and <em>Out</em> arguments and how values could be assigned. We have also seen how to invoke a workflow, how to pass in arguments and how to retrieve arguments from the workflow. At the UI side
 was nothing special and you can work similar in other technologies, such as Silverlight.</p>
<div></div>
<div></div>
