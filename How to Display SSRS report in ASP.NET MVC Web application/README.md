# How to Display SSRS report in ASP.NET MVC Web application.
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- SSRS
- ASP.NET MVC 4
- .NET 4.5
- MVC4
## Topics
- Reports
- Reporting
- ASP.NET MVC 4
## Updated
- 10/10/2016
## Description

<h1>Background</h1>
<p>As most of you might be aware that it&rsquo;s easy to incorporate SSRS reports with ASP.NET web application, as there&rsquo;s a server control &ldquo;ReportViewer&rdquo; available in ASP.NET, but integrating SSRS reports with ASP.NET MVC web application
 it&rsquo;s slightly complicated. In this, article I will show how to integrate it easily in few steps.</p>
<h1>Introduction</h1>
<p>In this, article I will show how to display an SSRS report in ASP.NET MVC application. For this demo I am using Visual Studio 2012, ASP.NET MVC 4 - Empty Template, an existing SSRS report deployed on SSRS Server and a nuGet package. I will be using a nuGet
 package called ReportViewer for MVC.&nbsp;</p>
<p><strong><span>ReportViewer for MVC</span></strong>&nbsp;is a .NET project that makes possible to use an ASP.NET ReportViewer control into an MVC web application. It provides a set of HTML Helpers and a simple ASP.NET Web Form for displaying the ReportViewer
 within an auto-resized iframe tag.&nbsp;</p>
<p>This article is developers having experience working on ASP.NET MVC web application and some knowledge on SSRS.</p>
<h1>Getting Started</h1>
<p>For integrating the SSRS report in ASP.NET MVC web application, you need some information related to SSRS server handy. You need the following details</p>
<ul>
<li>SSRS Server URL </li><li>SSRS folder path </li><li>Report name &ndash; In demo the Report name is Performance.rdl </li></ul>
<p>I have created a demo ASP.NET MVC web application having 2 views.</p>
<ul>
<li>Home/Index View &ndash; displays the list of Reports, by clicking on the report link it will be directed to the Reports template for displaying the report.
</li><li>Report/ReportTemplate View &ndash; displays the requested report. </li></ul>
<p>Below is the structure of the ASPNETMVC_SSRS_Demo project. As you can see in the Solution explorer, Under Controller folder I have HomeComtroller and ReportController, and under the Views&nbsp;folder&nbsp;I have the Home folder with Index view and Report
 folder with ReportTemplate view.</p>
<p><img id="158733" src="158733-capture1.png" alt="" width="900" height="587"></p>
<p>Next step&nbsp;is Installing the reporting package - ReportViewer for MVC from nuGet. This is the most important step. You can install any nuGet package using any one of the following ways.</p>
<ol>
<li>Using the package manager console </li></ol>
<p>OR</p>
<ol>
<li>By right-clicking on the project in Solution explorer and selecting the option Manage NuGet package for solution
</li></ol>
<p>I am showing you steps for installing the ReportViewerForMvc using the package manager console.</p>
<p><strong>Using package manager console:</strong></p>
<p>Click on Tools -&gt; Nuget Package Manager.</p>
<p><img id="158734" src="158734-capture2.png" alt="" width="900" height="665"></p>
<p>The package manager console will open</p>
<p><img id="158706" src="158706-capture3.png" alt="" width="900" height="870"></p>
<p>&nbsp;</p>
<p>Next, type the below command at the prompt</p>
<p>PM&gt;&nbsp;<strong>Install-package ReportViewerForMvc&nbsp;</strong>&nbsp;and press enter. After few minutes the package will be installed</p>
<p><img id="158707" src="158707-capture4.png" alt="" width="900" height="800"></p>
<p>This installation will add to the project: 2 assemblies (<strong>Microsoft.ReportViewer.WebForms &amp; ReportViewerForMvc)</strong>to references an .aspx page (<strong>ReportViewerWebForm.aspx</strong>) and&nbsp;<strong>httphandlers&nbsp;</strong>settings
 in the web.config file.</p>
<p>Note: the .aspx page added does not have a .cs file.</p>
<p><img id="158708" src="158708-capture5.png" alt="" width="900" height="522"></p>
<p>&nbsp;</p>
<p><img id="158709" src="158709-capture6.png" alt="" width="900" height="521"></p>
<h1><img id="158710" src="158710-capture7.png" alt="" width="900" height="688" style="font-size:10px"></h1>
<p>You can now use this .aspx page and code everything in controller, but I am using a slightly different path for code reusability and consistency)</p>
<p>Add a new folder &lsquo;Reports&rdquo; to the project, and then add a new webform .aspx page (ReportTemplate.aspx to the Reports folder</p>
<p><img id="158711" src="158711-capture8.png" alt="" width="900" height="523"></p>
<pre>Copy the contents (as shown in fig) from ReportViewerWebForm.aspx and replace the content of ReportTemplate.aspx with this.</pre>
<pre>Note: Please do not copy @page directive, copy only the highlighted section.</pre>
<pre><img id="158712" src="158712-capture9.png" alt="" width="900" height="597"><br></pre>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;Microsoft.ReportViewer.WebForms,&nbsp;Version=11.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=89845dcd8080cc91&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.Reporting.WebForms&quot;</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;rsweb&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;&nbsp;
&lt;%--<span class="html__doctype">&lt;!DOCTYPE&nbsp;html&nbsp;PUBLIC&nbsp;&quot;-//W3C//DTD&nbsp;XHTML&nbsp;1.0&nbsp;Transitional//EN&quot;&nbsp;&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;</span>--%&gt;&nbsp;
<span class="html__doctype">&lt;!doctype&nbsp;html&gt;</span>&nbsp;
&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">http-equiv</span>=<span class="html__attr_value">&quot;X-UA-Compatible&quot;</span>&nbsp;<span class="html__attr_name">content</span>=<span class="html__attr_value">&quot;IE=EmulateIE11&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;
<span class="html__tag_start">&lt;html</span>&nbsp;<span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;Head1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ScriptManager&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;scriptManagerReport&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/asp:ScriptManager&gt;</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;rsweb</span>:ReportViewer&nbsp;&nbsp;<span class="html__attr_name">runat</span>&nbsp;=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">ShowPrintButton</span>=<span class="html__attr_value">&quot;false&quot;</span>&nbsp;&nbsp;<span class="html__attr_name">Width</span>=<span class="html__attr_value">&quot;99.9%&quot;</span>&nbsp;<span class="html__attr_name">Height</span>=<span class="html__attr_value">&quot;100%&quot;</span>&nbsp;<span class="html__attr_name">AsyncRendering</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">ZoomMode</span>=<span class="html__attr_value">&quot;Percent&quot;</span>&nbsp;<span class="html__attr_name">KeepSessionAlive</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;rvSiteMapping&quot;</span>&nbsp;<span class="html__attr_name">SizeToReportContent</span>=<span class="html__attr_value">&quot;false&quot;</span>&nbsp;<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/rsweb:ReportViewer&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<p>The ReportTemplate.aspx will change to this</p>
<p><img id="158713" src="158713-capture14.png" alt="" width="900" height="515"></p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;<span class="html__attr_name">AutoEventWireup</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">CodeBehind</span>=<span class="html__attr_value">&quot;ReportTemplate.aspx.cs&quot;</span>&nbsp;<span class="html__attr_name">Inherits</span>=<span class="html__attr_value">&quot;ASPNETMVC_SSRS_Demo.Reports.ReportTemplate&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;Microsoft.ReportViewer.WebForms,&nbsp;Version=11.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=89845dcd8080cc91&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.Reporting.WebForms&quot;</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;rsweb&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;&nbsp;
&lt;%--<span class="html__doctype">&lt;!DOCTYPE&nbsp;html&nbsp;PUBLIC&nbsp;&quot;-//W3C//DTD&nbsp;XHTML&nbsp;1.0&nbsp;Transitional//EN&quot;&nbsp;&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;</span>--%&gt;&nbsp;
<span class="html__doctype">&lt;!doctype&nbsp;html&gt;</span>&nbsp;
&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">http-equiv</span>=<span class="html__attr_value">&quot;X-UA-Compatible&quot;</span>&nbsp;<span class="html__attr_name">content</span>=<span class="html__attr_value">&quot;IE=EmulateIE11&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;
<span class="html__tag_start">&lt;html</span>&nbsp;<span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;Head1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ScriptManager&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;scriptManagerReport&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;Scripts</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ScriptReference&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;ReportViewerForMvc&quot;</span>&nbsp;<span class="html__attr_name">Name</span>=<span class="html__attr_value">&quot;ReportViewerForMvc.Scripts.PostMessage.js&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="html__tag_end">&lt;/Scripts&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/asp:ScriptManager&gt;</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;rsweb</span>:ReportViewer&nbsp;&nbsp;<span class="html__attr_name">runat</span>&nbsp;=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">ShowPrintButton</span>=<span class="html__attr_value">&quot;false&quot;</span>&nbsp;&nbsp;<span class="html__attr_name">Width</span>=<span class="html__attr_value">&quot;99.9%&quot;</span>&nbsp;<span class="html__attr_name">Height</span>=<span class="html__attr_value">&quot;100%&quot;</span>&nbsp;<span class="html__attr_name">AsyncRendering</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">ZoomMode</span>=<span class="html__attr_value">&quot;Percent&quot;</span>&nbsp;<span class="html__attr_name">KeepSessionAlive</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;rvSiteMapping&quot;</span>&nbsp;<span class="html__attr_name">SizeToReportContent</span>=<span class="html__attr_value">&quot;false&quot;</span>&nbsp;<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/rsweb:ReportViewer&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span></pre>
</div>
</div>
</div>
</h1>
<p>Next delete the below scripts tag from ReportTemplate.aspx page</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&lt;Scripts&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ScriptReference&nbsp;Assembly=<span class="js__string">&quot;ReportViewerForMvc&quot;</span>&nbsp;Name=<span class="js__string">&quot;ReportViewerForMvc.Scripts.PostMessage.js&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;/Scripts&gt;&nbsp;
</pre>
</div>
</div>
</div>
<p>Add additional attributes to the ReportViewercontrol as below</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;rsweb</span>:ReportViewer&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;rvSiteMapping&quot;</span><span class="html__attr_name">runat</span>&nbsp;=<span class="html__attr_value">&quot;server&quot;</span><span class="html__attr_name">ShowPrintButton</span>=<span class="html__attr_value">&quot;false&quot;</span><span class="html__attr_name">Width</span>=<span class="html__attr_value">&quot;99.9%&quot;</span><span class="html__attr_name">Height</span>=<span class="html__attr_value">&quot;100%&quot;</span><span class="html__attr_name">AsyncRendering</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__attr_name">ZoomMode</span>=<span class="html__attr_value">&quot;Percent&quot;</span><span class="html__attr_name">KeepSessionAlive</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__attr_name">SizeToReportContent</span>=<span class="html__attr_value">&quot;false&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/rsweb:ReportViewer&gt;</span></pre>
</div>
</div>
</div>
<p>Now open ReportTemplate.aspx.cs file and add below code to the Page_load event, you need to the SSRS Server URL and SSRS report Folder path.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.UI.aspx" target="_blank" title="Auto generated link to System.Web.UI">System.Web.UI</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.UI.WebControls.aspx" target="_blank" title="Auto generated link to System.Web.UI.WebControls">System.Web.UI.WebControls</a>;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ASPNETMVC_SSRS_Demo.Reports&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;ReportTemplate&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!IsPostBack)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;reportFolder&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[<span class="cs__string">&quot;SSRSReportsFolder&quot;</span>].ToString();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rvSiteMapping.Height&nbsp;=&nbsp;Unit.Pixel(Convert.ToInt32(Request[<span class="cs__string">&quot;Height&quot;</span>])&nbsp;-&nbsp;<span class="cs__number">58</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rvSiteMapping.ProcessingMode&nbsp;=&nbsp;Microsoft.Reporting.WebForms.ProcessingMode.Remote;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rvSiteMapping.ServerReport.ReportServerUrl&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;SSRS&nbsp;URL&quot;</span>);&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;the&nbsp;Reporting&nbsp;Server&nbsp;URL</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rvSiteMapping.ServerReport.ReportPath&nbsp;=&nbsp;String.Format(<span class="cs__string">&quot;/{0}/{1}&quot;</span>,&nbsp;reportFolder,&nbsp;Request[<span class="cs__string">&quot;ReportName&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rvSiteMapping.ServerReport.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><img id="158714" src="158714-capture11.png" alt="" width="900" height="637"></p>
<p>&nbsp;</p>
<p>Add the SSRSReportFolder path to the app settings in the web.config file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="html">&nbsp;&nbsp;<span class="html__tag_start">&lt;add</span>&nbsp;<span class="html__attr_name">key</span>=<span class="html__attr_value">&quot;SSRSReportsFolder&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;BIC_Reports&quot;</span><span class="html__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="158715" src="158715-capture12.png" alt="" width="900" height="567"></div>
<p>&nbsp;</p>
<p>Next, create an entity class ReportInfo.cs under Models folder</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ASPNETMVC_SSRS_Demo.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ReportInfo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;ReportId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ReportName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ReportDescription&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ReportURL&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Width&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Height&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ReportSummary&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="158716" src="158716-capture13.png" alt="" width="900" height="442"></div>
<p>&nbsp;</p>
<p>Next,&nbsp;we will add code to the Controller and the View Pages.&nbsp; There is no change to the HomeController.cs. Add the following code to Home/Index view page.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="html">@{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;&quot;Index&quot;;&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Reports&nbsp;List<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;ReportUrl_Performance&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;@Url.Action(&quot;</span>ReportTemplate&quot;,&nbsp;&quot;Report&quot;,&nbsp;new&nbsp;{&nbsp;<span class="html__attr_name">ReportName</span>&nbsp;=&nbsp;<span class="html__attr_value">&quot;Performance&quot;</span>,&nbsp;<span class="html__attr_name">ReportDescription</span>&nbsp;=&nbsp;<span class="html__attr_value">&quot;Performance&nbsp;Report&quot;</span>,&nbsp;Width&nbsp;=&nbsp;100,&nbsp;Height&nbsp;=&nbsp;650&nbsp;})&quot;<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;Performance&nbsp;Report<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="158718" src="158718-capture14.png" alt="" width="900" height="515"></div>
<p>&nbsp;</p>
<p>Next&nbsp;add ActionResult ReportTemplate to the Report Controller.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
using&nbsp;ASPNETMVC_SSRS_Demo.Models;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;ASPNETMVC_SSRS_Demo.Controllers&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ReportController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;/Report/</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;ReportTemplate(string&nbsp;ReportName,&nbsp;string&nbsp;ReportDescription,&nbsp;int&nbsp;Width,&nbsp;int&nbsp;Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;rptInfo&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ReportInfo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReportName&nbsp;=&nbsp;ReportName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReportDescription&nbsp;=&nbsp;ReportDescription,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReportURL&nbsp;=&nbsp;<span class="js__object">String</span>.Format(<span class="js__string">&quot;../../Reports/ReportTemplate.aspx?ReportName={0}&amp;Height={1}&quot;</span>,&nbsp;ReportName,&nbsp;Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Width&nbsp;=&nbsp;Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Height&nbsp;=&nbsp;Height&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(rptInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="158719" src="158719-capture15.png" alt="" width="900" height="627"></div>
<p>&nbsp;</p>
<p>Final Step is to open the ReportTemplate view page under Report and add the following code.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="html">@model&nbsp;ASPNETMVC_SSRS_Demo.Models.ReportInfo&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;H1</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;@Model.ReportDescription&nbsp;
<span class="html__tag_end">&lt;/H1&gt;</span>&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;iframe</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;frmReport&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;@Model.ReportURL&quot;</span>&nbsp;<span class="html__attr_name">frameborder</span>=<span class="html__attr_value">&quot;0&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;@String.Format(&quot;</span>width:{0}%;&nbsp;height:&nbsp;{1}px;&quot;,&nbsp;Model.Width,&nbsp;Model.Height)&quot;&nbsp;<span class="html__attr_name">scrolling</span>=<span class="html__attr_value">&quot;no&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;
<span class="html__tag_end">&lt;/iframe&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="158720" src="158720-capture16.png" alt="" width="900" height="492"></div>
<p>Press F6 to build the application and then build F5 to run the application. It will display the Home / index page.</p>
<p><img id="158723" src="158723-capture17.png" alt="" width="900" height="700"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Click on the Performance Report link and there you go the SSRS report is displayed. ( the data from this&nbsp;report&nbsp;has been hidden as it a live report from Dev support)</p>
<p>&nbsp;</p>
<p><img id="158724" src="158724-capture18.png" alt="" width="900" height="700"></p>
<p>This completes the steps for displaying SSRS report in ASP.NET MVC Web application. Hope you like it.</p>
<p>Request you to please rate this article and provide comments if any...</p>
<p>You can find other tutorials ASP.NET, C#, Javascript, jQuery, bootstrap, WCF, Raspberry Pi, on my website http://hussainpatel.com</p>
<p>Happy Learning</p>
