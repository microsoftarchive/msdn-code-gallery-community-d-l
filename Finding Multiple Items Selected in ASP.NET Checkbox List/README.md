# Finding Multiple Items Selected in ASP.NET Checkbox List
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
## Topics
- Controls
## Updated
- 12/27/2011
## Description

<h1>Goal: Finding Multiple Selected Items from Checkbox List</h1>
<p><strong><span style="font-size:medium">Lets say there is a Checkbox list which shows Subjects to Selection, we need to display what items are identify selected items, then this example can be refered.&nbsp;</span></strong></p>
<p>&nbsp;</p>
<p>About SkilledRES (http://www.SkilledRES.com)</p>
<p>SkilledRES (Skilled Resource) is a JOB Oriented Training and Placement Organization.<br>
Motive &ndash; The one and only passion for SkilledRES is to build a platform for filling the gap between Student/Individual Knowledge and Industry Requirement. We closely work with organizations to understand their requirement in micro level and work with
 New Graduates to get them trained both theoretically and hands on to become a Professional.</p>
<p><br>
Our Primary Activities are Training and Placement<br>
Training &ndash; With almost 12&#43; years of experience in delivering and conducting Training Sessions across various levels, we invented Ground Breaking Methodologies in training, for instance our .NET JOB Oriented Training Program for Fresher is such a success
 that an absolute fresher will be converted in to a Eligible Jr. Programmer with in couple of months.&nbsp;<br>
<br>
Placement &ndash; We do have a dedicated Placement Cell and in very strong relation with Companies, Consultancies and HRs for placement activity. The students who undergo JOB Oriented Training with us will be offered an Internship based on their performance
 and these interns will be shown placement from the Clients we are working with. See the list of companies with which our Ex-Students are working with on right side of this page.&nbsp;<br>
<br>
</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;<span class="html__attr_name">AutoEventWireup</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">CodeBehind</span>=<span class="html__attr_value">&quot;Default.aspx.cs&quot;</span>&nbsp;<span class="html__attr_name">Inherits</span>=<span class="html__attr_value">&quot;DataBinding.WebForm2&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
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
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:CheckBoxList&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;CheckBoxList1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ListItem&nbsp;<span class="html__attr_name">Value</span>=<span class="html__attr_value">&quot;0&quot;</span><span class="html__tag_start">&gt;</span>C#<span class="html__tag_end">&lt;/asp:ListItem&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ListItem&nbsp;<span class="html__attr_name">Value</span>=<span class="html__attr_value">&quot;1&quot;</span><span class="html__tag_start">&gt;</span>SQL&nbsp;Server<span class="html__tag_end">&lt;/asp:ListItem&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ListItem&nbsp;<span class="html__attr_name">Value</span>=<span class="html__attr_value">&quot;2&quot;</span><span class="html__tag_start">&gt;</span>ASP.NET<span class="html__tag_end">&lt;/asp:ListItem&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ListItem&nbsp;<span class="html__attr_name">Value</span>=<span class="html__attr_value">&quot;3&quot;</span><span class="html__tag_start">&gt;</span>WPF<span class="html__tag_end">&lt;/asp:ListItem&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/asp:CheckBoxList&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Button&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;Button1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;Button1_Click&quot;</span>&nbsp;<span class="html__attr_name">Text</span>=<span class="html__attr_value">&quot;Show&nbsp;Selected&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Label&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;lblRes&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">Text</span>=<span class="html__attr_value">&quot;&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/asp:Label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
