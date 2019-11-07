# Getting Started - WCF RIA Services
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- Silverlight
- WCF RIA Services
## Topics
- WCF RIA Services sample
- HR application
## Updated
- 09/15/2011
## Description

<p>The sample provides a step by step guide to building your first RIA services application. The application we will be building here is an HR Application for an Enterprise.</p>
<p>&nbsp;</p>
<h1>Installation</h1>
<p>1.&nbsp; Manually uninstall the following via Add/Remove programs in Control Panel:</p>
<ol>
<li>Microsoft Silverlight (any version prior to Silverlight 3 RTW) </li><li>Microsoft Silverlight SDK </li><li>Microsoft Silverlight Tools for Visual Studio 2008 </li></ol>
<p>2.&nbsp; Install Visual Studio 2010 RC.</p>
<p>3.&nbsp; Install the following:</p>
<ol>
<li>Silverlight 4 RC </li><li>Silverlight 4 RC SDK </li></ol>
<p>4.&nbsp; Install WCF RIA Services RC.</p>
<div></div>
<div>
<div>
<p>&nbsp;</p>
<h1>Creating a new WCF RIA Services application</h1>
<p>1.&nbsp; Start Visual Studio</p>
<p>2.&nbsp; On the <strong>File</strong> menu, click <strong>New</strong><strong>&agrave;</strong><strong> Project</strong>. The
<strong>New Project</strong> dialog is displayed.</p>
<p>3.&nbsp; In the <strong>Project types</strong> pane, expand Visual Basic or C#, then select
<strong>Silverlight</strong>.</p>
<p>4.&nbsp; In the <strong>My</strong> <strong>Templates</strong> pane, select <strong>
Silverlight Business Application</strong>.</p>
<p>5.&nbsp; Change the project name to &lsquo;HRApp&rsquo;. Click <strong>OK</strong>.</p>
<p>&nbsp;</p>
<p><img src="19421-pic1.png" alt="" width="841" height="494"></p>
<p>&nbsp;</p>
<p>There are a couple of things to notice once the project is created:</p>
<ol>
<li>The solution created for you consists of two projects: a Silverlight client project called HRApp and an ASP.NET Web Application server project called HRApp.Web.
</li><li>The default application created for you has navigation, login/logout, new user registration enabled by default. Run the project and experiment with the default, out of the box application. When running the application for the first time, allow Visual Studio
 to <strong>Modify Web.config file</strong> to enable debugging. </li></ol>
<p>&nbsp;NOTE &ndash; The default User Registration implementation requires SQL Server Express be installed on the machine.</p>
<p>&nbsp;</p>
<p><img src="19428-pic2.png" alt="" width="260" height="590"></p>
<p>&nbsp;</p>
<h2>Setting up the application</h2>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>MainPage.xaml</strong>.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Notice that the default XAML code (shown below) gets the application name from a resource.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;TextBlock x:Name=&quot;ApplicationNameTextBlock&quot; <br>  Style=&quot;{StaticResource ApplicationNameStyle}&quot; <br>  Text=&quot;{Binding ApplicationStrings.ApplicationName, Source={StaticResource ResourceWrapper}}&quot;/&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span>&nbsp;<br>&nbsp;<br><span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ApplicationNameTextBlock&quot;</span>&nbsp;&nbsp;<br>&nbsp;&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;ApplicationNameStyle}&quot;</span>&nbsp;&nbsp;<br>&nbsp;&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ApplicationStrings.ApplicationName,&nbsp;Source={StaticResource&nbsp;ResourceWrapper}}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open the Assets folder, and in that folder open the Resources folder.</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open the ApplicationStrings.resx file, and change the ApplicationName resource to &ldquo;HR Application&rdquo;.</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Save and close the ApplicationStrings.resx file.</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In Solution Explorer, right click the <strong>
HRApp</strong> project, select <strong>Add, </strong>and<strong> </strong>then select<strong> New Item.
</strong>The<strong> Add New Item </strong>dialog box is displayed.</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>Categories</strong> pane, select
<strong>Silverlight</strong> and in <strong>Templates</strong> pane, select <strong>
Silverlight Page</strong>. Name the new item &lsquo;EmployeeList.xaml&rsquo; and click
<strong>Add.</strong></p>
<img src="19429-pic3.png" alt="" width="849" height="451"></div>
<div></div>
<div>
<p>8.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeList.xaml</strong> and add the following XAML code between the &lt;Grid&gt; tags</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;ScrollViewer BorderThickness=&quot;0&quot;  VerticalScrollBarVisibility=&quot;Auto&quot; Padding=&quot;12,0,12,0&quot; Margin=&quot;-12&quot;&gt;<br>    &lt;StackPanel Margin=&quot;0,12,0,12&quot; Orientation=&quot;Vertical&quot; &gt;<br>      &lt;TextBlock Text=&quot;Employee List&quot; Style=&quot;{StaticResource HeaderTextStyle}&quot;/&gt;<br><br>    &lt;/StackPanel&gt;<br>&lt;/ScrollViewer&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;ScrollViewer</span><span class="xaml__attr_name">BorderThickness</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__attr_name">VerticalScrollBarVisibility</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;12,0,12,0&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;-12&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,12,0,12&quot;</span><span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Vertical&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;TextBlock</span><span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Employee&nbsp;List&quot;</span><span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;HeaderTextStyle}&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/StackPanel&gt;</span><span class="xaml__tag_end">&lt;/ScrollViewer&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>9.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Save the EmployeeList.xaml file.</p>
<p>10.&nbsp;&nbsp;&nbsp;&nbsp; In Solution Explorer, click <strong>EmployeeList.xaml</strong> and drag it to the
<strong>Views</strong> folder.</p>
<p>11.&nbsp;&nbsp;&nbsp;&nbsp; If you are using Visual Basic, add the following Imports statement to
<strong>EmployeeList.xaml.vb</strong>.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Imports System.Windows.Controls</pre>
<div class="preview">
<pre id="codePreview" class="cplusplus">Imports&nbsp;System.Windows.Controls&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>12.&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>MainPage.xaml</strong> and add a new link button to top of the page by adding the XAML code between the two existing link buttons.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;HyperlinkButton x:Name=&quot;Link3&quot; Style=&quot;{StaticResource LinkStyle}&quot; NavigateUri=&quot;/EmployeeList&quot; TargetName=&quot;ContentFrame&quot; Content=&quot;Employee List&quot;/&gt; <br><br>&lt;Rectangle x:Name=&quot;Divider2&quot; Style=&quot;{StaticResource DividerStyle}&quot;/&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span>&nbsp;<br>&nbsp;<br><span class="xaml__tag_start">&lt;HyperlinkButton</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Link3&quot;</span>&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;LinkStyle}&quot;</span>&nbsp;<span class="xaml__attr_name">NavigateUri</span>=<span class="xaml__attr_value">&quot;/EmployeeList&quot;</span>&nbsp;<span class="xaml__attr_name">TargetName</span>=<span class="xaml__attr_value">&quot;ContentFrame&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Employee&nbsp;List&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;<br>&nbsp;<br><span class="xaml__tag_start">&lt;Rectangle</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Divider2&quot;</span>&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;DividerStyle}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>13.&nbsp;&nbsp;&nbsp;&nbsp; Run the application and you will notice a new link button (&lsquo;Employee List&rsquo;) has been added.</p>
<p><img src="19430-pic4.png" alt="" width="847" height="600"></p>
<p>&nbsp;</p>
<div>
<h1>Adding Business Logic to a .NET RIA Services application</h1>
<p>If you have the AdventureWorks database already installed feel free to use it; otherwise you can install one from CodePlex:
<a href="http://msftdbprodsamples.codeplex.com/releases/view/4004">http://msftdbprodsamples.codeplex.com/releases/view/4004</a></p>
<p>&nbsp;</p>
<h2>Add a Data Source</h2>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In Solution Explorer, right-click the <strong>
HRApp.Web</strong> project, select <strong>Add</strong>, and then select <strong>
New Item</strong>. The<strong> Add New Item </strong>dialog box is displayed.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>Categories</strong> pane, select
<strong>Data</strong>, and in the <strong>Templates</strong> pane, select <strong>
ADO.NET Entity Data Model</strong>. Name the data model &lsquo;AdventureWorks.edmx&rsquo; and click
<strong>Add</strong>.</p>
<p>&nbsp;</p>
<p><img src="19431-pic5.png" alt="" width="817" height="453"></p>
</div>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>Entity Data Model Wizard</strong>, choose to generate the Model from an existing database and click
<strong>Next</strong>.</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select the connection to the <strong>AdventureWorks</strong> database and then set the name of the entity connection settings to
<strong>AdventureWorks_DataEntities</strong>.</p>
<p><img src="19432-pic6.png" alt="" width="625" height="557"></p>
<p>&nbsp;</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Next.</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Expand the Tables node and choose the <strong>
Employee</strong> table to be used by the Entity Data model.&nbsp; Set the model namespace to &lsquo;AdventureWorks_DataModel&rsquo;.</p>
<p><img src="19433-pic7.png" alt="" width="624" height="554"></p>
<p>&nbsp;</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Click <strong>Finish</strong>. The entity data model appears in the designer.</p>
<p><img src="19434-pic8.png" alt="" width="258" height="548"></p>
<p>8.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On the <strong>Build</strong> menu, select
<strong>Build Solution</strong>.</p>
<h2>Add a Domain Service Object and Query for Data</h2>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In Solution Explorer, right-click the <strong>
HRApp.Web</strong> project, select <strong>Add</strong>, and then select <strong>
New Item</strong>. The <strong>Add New Item</strong> dialog box is displayed.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>Categories</strong> pane, select
<strong>Web</strong>, and in the <strong>Templates</strong> pane, select <strong>
Domain Service Class</strong>. Name the new item &lsquo;OrganizationService&rsquo;.</p>
<p><img src="19435-pic9.png" alt="" width="833" height="483"></p>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Click <strong>Add</strong></p>
<div>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>Add New Domain Service Class</strong> dialog, select
<strong>Employee</strong> from the Entities list, select <strong>Enable editing</strong>, and select
<strong>Generate associated classes for metadata</strong>. Also, ensure that the <strong>
Enable client access</strong> checkbox is checked.</div>
<div></div>
<div><img src="19436-pic10.png" alt="" width="448" height="548"></div>
<div></div>
<div>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Click <strong>OK</strong>.</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>OrganizationService.cs/vb</strong> file, you will see that a query method and the Create/Update/Delete (CUD) data methods have been added. The CUD data methods were added because
<strong>Enable editing</strong> was selected.</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Customize the select function by updating the
<strong>GetEmployees()</strong> method to return the data sorted by EmployeeID.</p>
<p>Replace this generated code:</p>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// C#
public IQueryable&lt;Employee&gt; GetEmployees()
{
return this.ObjectContext.Employees;
}
</pre>
<pre class="hidden">'VB
Public Function GetEmployees() As IQueryable(Of Employee)
Return Me.ObjectContext.Employees
End Function</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__com">//&nbsp;C#</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;IQueryable&lt;Employee&gt;&nbsp;GetEmployees()&nbsp;
{&nbsp;
<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.ObjectContext.Employees;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>With the following code:</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB<br><br>Public Function GetEmployees() As IQueryable(Of Employee)<br>    Return Me.ObjectContext.Employees.OrderBy(Function(e) e.EmployeeID)<br>End Function<br></pre>
<pre class="hidden">// C#<br><br>public IQueryable&lt;Employee&gt; GetEmployees()<br>{<br>    return this.ObjectContext.Employees.OrderBy(e =&gt; e.EmployeeID);<br>}<br></pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;<br>&nbsp;<br><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetEmployees()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IQueryable(<span class="visualBasic__keyword">Of</span>&nbsp;Employee)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.ObjectContext.Employees.OrderBy(<span class="visualBasic__keyword">Function</span>(e)&nbsp;e.EmployeeID)&nbsp;<br><span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>8.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On the <strong>Build</strong> menu, select
<strong>Build Solution</strong>. <br>
Building the solution generates the Domain Context and entities in the client project.</p>
<p>9.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>EmployeeList.xaml</strong>.</p>
<p>10.&nbsp;&nbsp;&nbsp;&nbsp; Open the <strong>Toolbox</strong>. The <strong>Toolbox</strong> is available from the
<strong>View</strong> menu.</p>
<p>11.&nbsp;&nbsp;&nbsp;&nbsp; Drag a <strong>DataGrid</strong> from the toolbox onto the XAML view for
<strong>EmployeeList.xaml</strong>. Add the DataGrid inside of the StackPanel, just after the TextBlock.<br>
Dragging a <strong>DataGrid</strong> into the XAML editor adds a reference to the
<code>System.Windows.Controls.Data</code> assembly and maps the System.Windows.Controls namespace to a prefix. The prefix can be any value. In this walkthrough, the examples are shown with the prefix set to
<code><strong>data</strong></code><code>.</code></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;data:DataGrid &gt;&lt;/data:DataGrid&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="csharp">&lt;!--&nbsp;XAML&nbsp;--&gt;&nbsp;<br>&nbsp;<br>&lt;data:DataGrid&nbsp;&gt;&lt;/data:DataGrid&gt;&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>The prefix is set in the Page element.</p>
<div>
<p class="Code">xmlns:data=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data&quot;</p>
<p class="Code">&nbsp;</p>
<p>12.&nbsp;&nbsp;&nbsp;&nbsp; Name the DataGrid&nbsp; &lsquo;dataGrid1&rsquo; , make it read-only, and set its minimum height by adding the following XAML..</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;data:DataGrid Name=&quot;dataGrid1&quot; MinHeight=&quot;100&quot; IsReadOnly=&quot;True&quot;&gt;&lt;/data:DataGrid&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;data</span>:DataGrid&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;dataGrid1&quot;</span><span class="xaml__attr_name">MinHeight</span>=<span class="xaml__attr_value">&quot;100&quot;</span><span class="xaml__attr_name">IsReadOnly</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/data:DataGrid&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>13.&nbsp;&nbsp;&nbsp;&nbsp; Save <strong>EmployeeList.xaml</strong> and build the solution.</p>
<p>14.&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeList.xaml.cs/vb</strong>.</p>
</div>
<div>15.&nbsp;&nbsp;&nbsp;&nbsp; Add the following <strong>using/Imports</strong> statements:</div>
</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB<br>Imports System.ServiceModel.DomainServices.Client<br></pre>
<pre class="hidden">// C#<br>using HRApp.Web;<br>using System.ServiceModel.DomainServices.Client;<br></pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;<br><span class="visualBasic__keyword">Imports</span>&nbsp;System.ServiceModel.DomainServices.Client&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>16.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the code generated for the client project, the
<strong>OrganizationContext</strong> is generated based on<strong> OrganizationService</strong>. Instantiate the
<strong>OrganizationContext</strong> class and load employee data by adding the following code (in bold) to
<strong>EmployeeList.xaml.cs/vb</strong>:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB<br>Imports System.Windows.Controls<br>Imports System.ServiceModel.DomainServices.Client<br><br>Partial Public Class EmployeeList<br>    Inherits Page<br><br>    Dim _OrganizationContext As New OrganizationContext<br>    Public Sub New()<br>        InitializeComponent()<br>        Me.dataGrid1.ItemsSource = _OrganizationContext.Employees<br>       _OrganizationContext.Load(_OrganizationContext.GetEmployeesQuery())<br>End Sub<br><br>    'Occurs when the user navigates to this page.<br>    Protected Overrides Sub OnNavigatedTo(ByVal e As       System.Windows.Navigation.NavigationEventArgs)<br><br>    End Sub<br>End Class<br></pre>
<pre class="hidden">// C#<br><br>namespace HRApp<br>{<br>    public partial class EmployeeList : Page<br>    {<br>      OrganizationContext _OrganizationContext = new OrganizationContext();<br>      public EmployeeList()<br>      {<br>         InitializeComponent();<br>  this.dataGrid1.ItemsSource = _OrganizationContext.Employees;<br>  _OrganizationContext.Load(_OrganizationContext.GetEmployeesQuery());<br><br>      }<br><br>        <br>        // Occurs when the user navigates to this page.<br>      protected override void OnNavigatedTo(NavigationEventArgs e)<br>      {<br>      }<br><br>    }<br>}<br></pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Imports</span>&nbsp;System.Windows.Controls&nbsp;<br><span class="visualBasic__keyword">Imports</span>&nbsp;System.ServiceModel.DomainServices.Client&nbsp;<br>&nbsp;<br><span class="visualBasic__keyword">Partial</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Class</span>&nbsp;EmployeeList&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Page&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;_OrganizationContext&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;OrganizationContext&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">New</span>()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.dataGrid1.ItemsSource&nbsp;=&nbsp;_OrganizationContext.Employees&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_OrganizationContext.Load(_OrganizationContext.GetEmployeesQuery())&nbsp;<br><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__com">'Occurs&nbsp;when&nbsp;the&nbsp;user&nbsp;navigates&nbsp;to&nbsp;this&nbsp;page.</span><span class="visualBasic__keyword">Protected</span><span class="visualBasic__keyword">Overrides</span><span class="visualBasic__keyword">Sub</span>&nbsp;OnNavigatedTo(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Navigation.NavigationEventArgs)&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>17.&nbsp;&nbsp;&nbsp;&nbsp; Run the application. Click the <strong>Employee List</strong> link when the application is loaded to see the
<strong>DataGrid</strong>.</p>
<p><img src="19437-pic11.png" alt="" width="830" height="528"></p>
</div>
</div>
</div>
<h3>Add a Custom Query</h3>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>HRApp.Web</strong> project, open &nbsp;<strong>OrganizationService</strong><strong>.cs/vb</strong>.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add a new method called <strong>GetSalariedEmployees</strong> by adding the following code to the body of the class.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB<br>Public Function GetSalariedEmployees() As IQueryable(Of Employee)<br>    Return Me.ObjectContext.Employees.Where(Function(e) e.SalariedFlag = True).OrderBy(Function(e) e.EmployeeID)<br>End Function<br></pre>
<pre class="hidden">// C#<br><br>public IQueryable&lt;Employee&gt; GetSalariedEmployees()<br>{<br>    return this.ObjectContext.Employees.Where(e =&gt; e.SalariedFlag == true).OrderBy(e =&gt; e.EmployeeID);<br>}<br></pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Function</span>&nbsp;GetSalariedEmployees()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IQueryable(<span class="visualBasic__keyword">Of</span>&nbsp;Employee)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span><span class="visualBasic__keyword">Me</span>.ObjectContext.Employees.Where(<span class="visualBasic__keyword">Function</span>(e)&nbsp;e.SalariedFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>).OrderBy(<span class="visualBasic__keyword">Function</span>(e)&nbsp;e.EmployeeID)&nbsp;<br><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On the <strong>Build</strong> menu, select
<strong>Build Solution</strong>.</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>EmployeeList.xaml.cs/vb.</strong> A new query function is available in IntelliSense called OrganizationContext.<strong>GetSalariedEmployeesQuery</strong>.</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the constructor, replace the call to
<strong>GetEmployeesQuery()</strong> with a call to <strong>GetSalariedEmployeesQuery()</strong> .</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB<br>_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeesQuery())<br></pre>
<pre class="hidden">// C#<br>_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeesQuery());<br></pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;<br>_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeesQuery())&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the <strong>
Employee List</strong> link. Notice that employees 1, 2, and 4 no longer appear in the list because they are not salaried.</p>
<p><img src="19438-pic12.png" alt="" width="782" height="497"></p>
<p>&nbsp;</p>
<h3>Add a Domain Data Source</h3>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>EmployeeList.xaml</strong>.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Drag the <strong>DomainDataSource</strong> from the toolbox onto
<strong>EmployeeList.xaml</strong>, just before the <strong>DataGrid</strong>.</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Change the namespace prefix for System.Windows.Controls from
<strong>my</strong> to <strong>riaControls</strong>.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">xmlns:riaControls=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.DomainServices&quot;</pre>
<div class="preview">
<pre id="codePreview" class="xaml">xmlns:riaControls=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.DomainServices&quot;&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For C# solutions, add the following namespace declaration to the XAML file:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!&mdash; XAML for C# solutions --&gt;<br><br>xmlns:ds=&quot;clr-namespace:HRApp.Web&quot;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml">&lt;!&mdash;&nbsp;XAML&nbsp;for&nbsp;C#&nbsp;solutions&nbsp;--&gt;&nbsp;<br>&nbsp;<br>xmlns:ds=&quot;clr-namespace:HRApp.Web&quot;&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>For VB solutions, add the following namespace declaration to the XAML file:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML for VB solutions--&gt;<br><br>xmlns:ds=&quot;clr-namespace:HRApp&quot;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;for&nbsp;VB&nbsp;solutions--&gt;</span>&nbsp;<br>&nbsp;<br>xmlns:ds=&quot;clr-namespace:HRApp&quot;&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name the DomainDataSource &lsquo;employeeDataSource&rsquo; &nbsp;and set the DomainContext , LoadSize, AutoLoad, and query method by adding the following XAML code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br>	<br>&lt;riaControls:DomainDataSource Name=&quot;employeeDataSource&quot; LoadSize=&quot;20&quot; QueryName=&quot;GetSalariedEmployees&quot; AutoLoad=&quot;True&quot;&gt;<br>&lt;/riaControls:DomainDataSource&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;employeeDataSource&quot;</span>&nbsp;<span class="xaml__attr_name">LoadSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">QueryName</span>=<span class="xaml__attr_value">&quot;GetSalariedEmployees&quot;</span>&nbsp;<span class="xaml__attr_name">AutoLoad</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource&gt;</span>&nbsp;<br>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set the DomainContext for the DomainDataSource with the following XAML code.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;riaControls:DomainDataSource Name=&quot;employeeDataSource&quot; LoadSize=&quot;20&quot; QueryName=&quot;GetSalariedEmployees&quot; AutoLoad=&quot;True&quot; &gt;<br>    &lt;riaControls:DomainDataSource.DomainContext&gt;<br>      &lt;ds:OrganizationContext/&gt; <br>    &lt;/riaControls:DomainDataSource.DomainContext&gt;<br>&lt;/riaControls:DomainDataSource&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;employeeDataSource&quot;</span><span class="xaml__attr_name">LoadSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span><span class="xaml__attr_name">QueryName</span>=<span class="xaml__attr_value">&quot;GetSalariedEmployees&quot;</span><span class="xaml__attr_name">AutoLoad</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource.DomainContext<span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;ds</span>:OrganizationContext<span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource.DomainContext&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Replace this DataGrid XAML:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;data:DataGrid Name=&quot;dataGrid1&quot; MinHeight=&quot;100&quot; IsReadOnly=&quot;True&quot;&gt;&lt;/data:DataGrid&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;data</span>:DataGrid&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;dataGrid1&quot;</span><span class="xaml__attr_name">MinHeight</span>=<span class="xaml__attr_value">&quot;100&quot;</span><span class="xaml__attr_name">IsReadOnly</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/data:DataGrid&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>with the following XAML<strong>:</strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;data:DataGrid Name=&quot;dataGrid1&quot; MinHeight=&quot;100&quot; IsReadOnly=&quot;True&quot; Height=&quot;Auto&quot; ItemsSource=&quot;{Binding Data, ElementName=employeeDataSource}&quot; /&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;data</span>:DataGrid&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;dataGrid1&quot;</span><span class="xaml__attr_name">MinHeight</span>=<span class="xaml__attr_value">&quot;100&quot;</span><span class="xaml__attr_name">IsReadOnly</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Data,&nbsp;ElementName=employeeDataSource}&quot;</span><span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>8.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeList.xaml.cs/vb</strong>.</p>
<p>9.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the constructor, remove or comment out the code to instantiate the
<strong>OrganizationContext</strong> instance, the call to <strong>GetSalariedEmployeesQuery()</strong>, and the code to set the DataGrid's
<strong>ItemsSource</strong>.</p>
<p>You no longer need to explicitly load data, since the <strong>DomainDataSource</strong> will do this automatically.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB<br>Partial Public Class EmployeeList<br>    Inherits Page<br><br>    'Dim _OrganizationContext As New OrganizationContext<br>    Public Sub New()<br>        InitializeComponent()<br>        	'_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeeQuery())<br>        'Me.dataGrid1.ItemsSource = _OrganizationContext.Employees<br>    End Sub<br></pre>
<pre class="hidden">// C#<br><br>//OrganizationContext _OrganizationContext = new OrganizationContext();<br>public EmployeeList()<br>        {<br>            InitializeComponent();<br>           <br>           // this.dataGrid1.ItemsSource= _OrganizationContext.Employees;<br>//_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeeQuery());<br>           <br>        }<br></pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Partial</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Class</span>&nbsp;EmployeeList&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Page&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Dim&nbsp;_OrganizationContext&nbsp;As&nbsp;New&nbsp;OrganizationContext</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">New</span>()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeeQuery())</span><span class="visualBasic__com">'Me.dataGrid1.ItemsSource&nbsp;=&nbsp;_OrganizationContext.Employees</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>10.&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the <strong>Employee List</strong> link. The application works as before.</p>
<p>&nbsp;</p>
<h3>Add Sorting/Filtering/Paging to the DataSource</h3>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Specify how data is sorted in the <strong>
DataGrid</strong> by adding <strong>SortDescriptors</strong> to the <strong>DomainDataSource</strong>. Add the following XAML (in bold) to the
<strong>DomainDataSource</strong> to sort the VacationHours column in Ascending order.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;riaControls:DomainDataSource Name=&quot;employeeDataSource&quot; LoadSize=&quot;20&quot; QueryName=&quot;GetSalariedEmployees&quot; AutoLoad=&quot;True&quot; &gt;<br>  &lt;riaControls:DomainDataSource.DomainContext&gt;<br>    &lt;ds:OrganizationContext/&gt; <br>  &lt;/riaControls:DomainDataSource.DomainContext&gt;<br>  &lt;riaControls:DomainDataSource.SortDescriptors&gt;<br>    &lt;riaControls:SortDescriptor PropertyPath=&quot;VacationHours&quot; Direction=&quot;Ascending&quot; /&gt;<br>  &lt;/riaControls:DomainDataSource.SortDescriptors&gt;<br><br>&lt;/riaControls:DomainDataSource&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;employeeDataSource&quot;</span><span class="xaml__attr_name">LoadSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span><span class="xaml__attr_name">QueryName</span>=<span class="xaml__attr_value">&quot;GetSalariedEmployees&quot;</span><span class="xaml__attr_name">AutoLoad</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource.DomainContext<span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;ds</span>:OrganizationContext<span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource.DomainContext&gt;</span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource.SortDescriptors<span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;riaControls</span>:SortDescriptor&nbsp;<span class="xaml__attr_name">PropertyPath</span>=<span class="xaml__attr_value">&quot;VacationHours&quot;</span><span class="xaml__attr_name">Direction</span>=<span class="xaml__attr_value">&quot;Ascending&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource.SortDescriptors&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the <strong>
Employee List</strong> link. The data will be sorted by Vacation Hours and you can change the sort direction by clicking on the column header.</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the XAML code <strong>in bold below</strong> to EmployeeList.xaml. That will add support for filtering.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;<br><br>&lt;navigation:Page x:Class=&quot;HRApp.EmployeeList&quot;<br>      xmlns:ds=&quot;clr-namespace:HRApp.Web&quot;<br>      xmlns:riaControls=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.DomainServices&quot; <br>      xmlns:data=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data&quot;   <br>      xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; <br>      xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot; <br>      xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;<br>      xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;<br>      mc:Ignorable=&quot;d&quot;<br>      xmlns:navigation=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation&quot;<br>      d:DesignWidth=&quot;640&quot; d:DesignHeight=&quot;480&quot;<br>      Title=&quot;EmployeeList Page&quot;&gt;<br>&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;White&quot;&gt;<br><br>&lt;ScrollViewer BorderThickness=&quot;0&quot;  VerticalScrollBarVisibility=&quot;Auto&quot; Padding=&quot;12,0,12,0&quot; Margin=&quot;-12&quot;&gt;<br>  &lt;StackPanel Margin=&quot;0,12,0,12&quot; Orientation=&quot;Vertical&quot; &gt;<br>    &lt;TextBlock Text=&quot;Employee List&quot; Style=&quot;{StaticResource HeaderTextStyle}&quot;/&gt;<br><br>      &lt;StackPanel Orientation=&quot;Horizontal&quot; <br>                  HorizontalAlignment=&quot;Right&quot; <br>                  Margin=&quot;0,-16,0,0&quot;&gt;<br>         &lt;TextBlock VerticalAlignment=&quot;Center&quot; <br>                    Text=&quot;Min Vacation Hours Filter&quot; /&gt;<br>         &lt;TextBox x:Name=&quot;vacationHoursText&quot; Width=&quot;75&quot; <br>                  FontSize=&quot;11&quot; Margin=&quot;4&quot; Text=&quot;0&quot;/&gt;<br>      &lt;/StackPanel&gt;<br>      &lt;riaControls:DomainDataSource <br>            Name=&quot;employeeDataSource&quot; <br>            LoadSize=&quot;20&quot; <br>            QueryName=&quot;GetSalariedEmployees&quot; <br>            AutoLoad=&quot;True&quot;&gt;<br>        &lt;riaControls:DomainDataSource.DomainContext&gt;<br>          &lt;ds:OrganizationContext/&gt; <br>        &lt;/riaControls:DomainDataSource.DomainContext&gt;<br>        &lt;riaControls:DomainDataSource.SortDescriptors&gt;<br>          &lt;riaControls:SortDescriptor PropertyPath=&quot;VacationHours&quot; <br>                                  Direction=&quot;Ascending&quot; /&gt;<br>        &lt;/riaControls:DomainDataSource.SortDescriptors&gt;<br><br>       &lt;riaControls:DomainDataSource.FilterDescriptors&gt;<br>         &lt;riaControls:FilterDescriptor <br>              PropertyPath=&quot;VacationHours&quot; <br>              Operator=&quot;IsGreaterThanOrEqualTo&quot;<br>              IgnoredValue=&quot;&quot;<br>              Value=&quot;{Binding ElementName=vacationHoursText, Path=Text}&quot;  &gt;<br>         &lt;/riaControls:FilterDescriptor&gt;<br>       &lt;/riaControls:DomainDataSource.FilterDescriptors&gt;<br><br>      &lt;/riaControls:DomainDataSource&gt;<br><br>      &lt;data:DataGrid MinHeight=&quot;100&quot; <br>               IsReadOnly=&quot;True&quot; <br>               ItemsSource=&quot;{Binding Data, ElementName=employeeDataSource}&quot;<br>               Name=&quot;dataGrid1&quot; /&gt;<br>  &lt;/StackPanel&gt;<br>&lt;/ScrollViewer&gt;<br>        <br>&lt;/Grid&gt;<br>&lt;/navigation:Page&gt;<br></pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;navigation</span>:Page&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;HRApp.EmployeeList&quot;</span><span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">ds</span>=<span class="xaml__attr_value">&quot;clr-namespace:HRApp.Web&quot;</span><span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">riaControls</span>=<span class="xaml__attr_value">&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.DomainServices&quot;</span><span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">data</span>=<span class="xaml__attr_value">&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data&quot;</span><span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span><span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span><span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">d</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/expression/blend/2008&quot;</span><span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">mc</span>=<span class="xaml__attr_value">&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mc:<span class="xaml__attr_name">Ignorable</span>=<span class="xaml__attr_value">&quot;d&quot;</span><span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">navigation</span>=<span class="xaml__attr_value">&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation&quot;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d:<span class="xaml__attr_name">DesignWidth</span>=<span class="xaml__attr_value">&quot;640&quot;</span>&nbsp;d:<span class="xaml__attr_name">DesignHeight</span>=<span class="xaml__attr_value">&quot;480&quot;</span><span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;EmployeeList&nbsp;Page&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span><span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;ScrollViewer</span><span class="xaml__attr_name">BorderThickness</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__attr_name">VerticalScrollBarVisibility</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;12,0,12,0&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;-12&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,12,0,12&quot;</span><span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Vertical&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;TextBlock</span><span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Employee&nbsp;List&quot;</span><span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;HeaderTextStyle}&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Right&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,-16,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;TextBlock</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span><span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Min&nbsp;Vacation&nbsp;Hours&nbsp;Filter&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;TextBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;vacationHoursText&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span><span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;11&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;4&quot;</span><span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/StackPanel&gt;</span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;employeeDataSource&quot;</span><span class="xaml__attr_name">LoadSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span><span class="xaml__attr_name">QueryName</span>=<span class="xaml__attr_value">&quot;GetSalariedEmployees&quot;</span><span class="xaml__attr_name">AutoLoad</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource.DomainContext<span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;ds</span>:OrganizationContext<span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource.DomainContext&gt;</span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource.SortDescriptors<span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;riaControls</span>:SortDescriptor&nbsp;<span class="xaml__attr_name">PropertyPath</span>=<span class="xaml__attr_value">&quot;VacationHours&quot;</span><span class="xaml__attr_name">Direction</span>=<span class="xaml__attr_value">&quot;Ascending&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource.SortDescriptors&gt;</span><span class="xaml__tag_start">&lt;riaControls</span>:DomainDataSource.FilterDescriptors<span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_start">&lt;riaControls</span>:FilterDescriptor&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">PropertyPath</span>=<span class="xaml__attr_value">&quot;VacationHours&quot;</span><span class="xaml__attr_name">Operator</span>=<span class="xaml__attr_value">&quot;IsGreaterThanOrEqualTo&quot;</span><span class="xaml__attr_name">IgnoredValue</span>=<span class="xaml__attr_value">&quot;&quot;</span><span class="xaml__attr_name">Value</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=vacationHoursText,&nbsp;Path=Text}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;<br></span><span class="xaml__tag_end">&lt;/riaControls:FilterDescriptor&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource.FilterDescriptors&gt;</span><span class="xaml__tag_end">&lt;/riaControls:DomainDataSource&gt;</span><span class="xaml__tag_start">&lt;data</span>:DataGrid&nbsp;<span class="xaml__attr_name">MinHeight</span>=<span class="xaml__attr_value">&quot;100&quot;</span><span class="xaml__attr_name">IsReadOnly</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Data,&nbsp;ElementName=employeeDataSource}&quot;</span><span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;dataGrid1&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/StackPanel&gt;</span><span class="xaml__tag_end">&lt;/ScrollViewer&gt;</span><span class="xaml__tag_end">&lt;/Grid&gt;</span><span class="xaml__tag_end">&lt;/navigation:Page&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the Application and filter the Employee List using the &ldquo;Min Vacation Hours Filter&rdquo; Text Box</p>
<p><img src="19439-pic13.png" alt="" width="740" height="470"></p>
<p>&nbsp;</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Drag a <strong>DataPager </strong>from the toolbox on to
<strong>EmployeeList.xaml</strong>. Add the <strong>DataPager</strong> just below the
<strong>DataGrid</strong>.</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set the page size to 5 and set the source by adding the following XAML to the
<strong>DataPager</strong>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;&lt;br&gt;&lt;br&gt;&lt;data:DataPager PageSize=&quot;5&quot; Source=&quot;{Binding Data, ElementName=employeeDataSource}&quot; Margin=&quot;0,-1,0,0&quot;&gt;&lt;/data:DataPager&gt;&lt;br&gt;</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;br</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_start">&lt;br</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_start">&lt;data</span>:DataPager&nbsp;<span class="xaml__attr_name">PageSize</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Data,&nbsp;ElementName=employeeDataSource}&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,-1,0,0&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/data:DataPager&gt;&lt;br&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the <strong>
employee list</strong> link. You will see only 5 rows of filtered data per page and pager controls below the
<strong>DataGrid</strong>.</p>
<p><img src="19440-pic14.png" alt="" width="795" height="516"></p>
<p>&nbsp;</p>
<div>
<h1>Master Detail</h1>
</div>
<h2>Adding a DataForm</h2>
<p>We will be using the DataForm Control from the SL 3 Toolkit for the Detail View. The Silverlight Business Application Project Template carries the System.Windows.Controls.Data.DataForm.Toolkit.dll binary in the &lsquo;Libs&rsquo; Folder, hence our Project
 already has access to the DataForm Control.</p>
<p>&nbsp;</p>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>EmployeeList.xaml</strong>.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the following namespace declaration to
<strong>EmployeeList.xaml</strong>.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;

xmlns:dataForm=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data.DataForm.Toolkit&quot;
</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span>&nbsp;
&nbsp;
xmlns:dataForm=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data.DataForm.Toolkit&quot;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; After the DataPager control, add the XAML code below. The code adds the DataForm to the EmployeeList Page and sets the DataForm attributes and specifies the columns to be displayed.</p>
<p>&nbsp;</p>
<p>&lt;dataForm:DataForm x:Name=&quot;dataForm1&quot; Header=&quot;Employee Information&quot; &nbsp;AutoGenerateFields=&quot;False&quot; AutoEdit=&quot;False&quot; AutoCommit=&quot;False&quot; CurrentItem=&quot;{Binding SelectedItem, ElementName=dataGrid1}&quot; Margin=&quot;0,12,0,0&quot;&gt;</p>
<p>&lt;dataForm:DataForm.EditTemplate&gt;</p>
<p>&nbsp; &lt;DataTemplate&gt;</p>
<p>&lt;StackPanel&gt;</p>
<p>&lt;dataForm:DataField Label=&quot;Employee ID&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;TextBox IsReadOnly=&quot;True&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Text=&quot;{Binding EmployeeID, Mode=OneWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Login ID&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding LoginID, Mode=TwoWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Hire Date&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding HireDate, Mode=TwoWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Marital Status&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding MaritalStatus, Mode=TwoWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Gender&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding Gender, Mode=TwoWay,NotifyOnValidationError=True, &nbsp;ValidatesOnExceptions=True
 }&quot; &nbsp;/&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Vacation Hours&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding VacationHours, Mode=TwoWay,NotifyOnValidationError=True, &nbsp;ValidatesOnExceptions=True
 }&quot; &nbsp;/&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Sick Leave Hours&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding SickLeaveHours, Mode=TwoWay,NotifyOnValidationError=True, &nbsp;ValidatesOnExceptions=True
 }&quot; &nbsp;/&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Active&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;CheckBox IsChecked=&quot;{Binding CurrentFlag, Mode=TwoWay,NotifyOnValidationError=True, &nbsp;ValidatesOnExceptions=True
 }&quot; &nbsp;/&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &lt;/DataTemplate&gt;</p>
<p>&nbsp; &nbsp;&lt;/dataForm:DataForm.EditTemplate&gt;</p>
<p>&lt;/dataForm:DataForm&gt;</p>
<p>&nbsp;</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the <strong>
employee list</strong> link. The <strong>DataForm</strong> displays details of the item selected in the
<strong>DataGrid</strong>.</p>
<p><img src="19441-pic15.png" alt="" width="777" height="538"></p>
<p>&nbsp;</p>
<div>
<h1>Updating the Database</h1>
</div>
<h2>Updating a record</h2>
<p>Checking the <strong>Enable editing</strong> option in the <strong>New Domain Service Class</strong> wizard caused CUD methods to be generated automatically in the domain service layer (<strong>OrganizationService</strong> class). In order to use these methods
 to update the database, you will add editing buttons to the user interface of the employee list.</p>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>EmployeeList.xaml</strong>.</p>
<p>Add a &lsquo;Submit&rsquo; button just after the <strong>DataForm</strong> tags by adding the following XAML code.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;

&lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot; Margin=&quot;0,12,0,0&quot;&gt;
  &lt;Button x:Name=&quot;submitButton&quot; Width=&quot;75&quot; Height=&quot;23&quot;  
          Content=&quot;Submit&quot; Margin=&quot;4,0,0,0&quot; Click=&quot;submitButton_Click&quot;/&gt;
                
&lt;/StackPanel&gt;
</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Right&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,12,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;submitButton&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Submit&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;4,0,0,0&quot;</span><span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;submitButton_Click&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/StackPanel&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Handle the button click event in <strong>
EmployeeList.xaml.cs/vb</strong> by adding the following code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Private Sub submitButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    employeeDataSource.SubmitChanges()
End Sub
</pre>
<pre class="hidden">// C#

private void submitButton_Click(object sender, RoutedEventArgs e)
{
    employeeDataSource.SubmitChanges();
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;submitButton_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employeeDataSource.SubmitChanges()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the
<strong>Employee List</strong> link. You can now modify any editable field by clicking on the pencil icon on the DataForm to put the form in edit mode. Make changes to the Employee data and click
<strong>OK</strong> when done with the edits. Click the <strong>Submit</strong> button to save the data.
<strong>Changes are saved to the database on the server only when you click the &lsquo;Submit&rsquo; button</strong>.</p>
<p>&nbsp;</p>
<h2>Adding Custom Methods to a Domain Service</h2>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the HRApp.Web server project, open <strong>
OrganizationService.cs/vb</strong> and add a custom method called &lsquo;ApproveSabbatical&rsquo;.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
    Public Sub ApproveSabbatical(ByVal current As Employee)
        Me.ObjectContext.Employees.AttachAsModified(current)
        current.CurrentFlag = False
    End Sub
</pre>
<pre class="hidden">// C#
        public void ApproveSabbatical(Employee current)
        {
 	     	// Start custom workflow here
            this.ObjectContext.Employees.AttachAsModified(current);
            current.CurrentFlag = false;        
        }
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span>&nbsp;ApproveSabbatical(<span class="visualBasic__keyword">ByVal</span>&nbsp;current&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.ObjectContext.Employees.AttachAsModified(current)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current.CurrentFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On the <strong>Build</strong> menu, select
<strong>Build Solution</strong>.</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>EmployeeList.xaml</strong>.</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add an &lsquo;Approve Sabbatical&rsquo; button by adding the following XAML code (in bold):</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;

&lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot; Margin=&quot;0,12,0,0&quot;&gt;
                &lt;Button x:Name=&quot;submitButton&quot; Width=&quot;75&quot; Height=&quot;23&quot;  Content=&quot;Save&quot;  Margin=&quot;4,0,0,0&quot; Click=&quot;submitButton_Click&quot;/&gt;
                &lt;Button x:Name=&quot;approveSabbatical&quot; Width=&quot;115&quot; Height=&quot;23&quot;  Content=&quot;Approve Sabbatical&quot;  Margin=&quot;4,0,0,0&quot; Click=&quot;approveSabbatical_Click&quot;/&gt;
            &lt;/StackPanel&gt;
</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Right&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,12,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;submitButton&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Save&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;4,0,0,0&quot;</span><span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;submitButton_Click&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;approveSabbatical&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;115&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Approve&nbsp;Sabbatical&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;4,0,0,0&quot;</span><span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;approveSabbatical_Click&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/StackPanel&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeList.xaml.cs/vb</strong>.</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Handle the button click event &nbsp;and call the
<strong>ApproveSabbatical </strong>method by adding the following code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Private Sub approveSabbatical_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    Dim luckyEmployee As Employee
    luckyEmployee = dataGrid1.SelectedItem
    luckyEmployee.ApproveSabbatical()
    employeeDataSource.SubmitChanges()
End Sub
</pre>
<pre class="hidden">// C#

private void approveSabbatical_Click(object sender, RoutedEventArgs e)
{
    Employee luckyEmployee = (Employee)(dataGrid1.SelectedItem);
    luckyEmployee.ApproveSabbatical();
    employeeDataSource.SubmitChanges();
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;approveSabbatical_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;luckyEmployee&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;luckyEmployee&nbsp;=&nbsp;dataGrid1.SelectedItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;luckyEmployee.ApproveSabbatical()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employeeDataSource.SubmitChanges()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the
<strong>employee list</strong> link. Click the <strong>ApproveSabbatical</strong> button and note that the
<strong>CurrentFlag</strong> for the selected employee clears.</p>
<p>&nbsp;</p>
<div>
<h1>Validation</h1>
</div>
<h2>Basic Validation</h2>
<p>The <strong>DataForm</strong> control has the ability to show validation errors that come from the Data Access Layer (DAL). For example, enter a non-integer value in the Vacation Hours field in the detail view and a validation error is displayed.</p>
<p><img src="19442-pic16.png" alt="" width="822" height="512"></p>
<p>&nbsp;</p>
<p>Checking the <strong>Generate associated classes for metadata</strong> option in the
<strong>New Domain Service Class</strong> wizard caused a file named <strong>OrganizationService.metadata.cs/vb</strong> to be generated automatically in the
<strong>HRApp.Web</strong> project. You will add validation attributes to this file that will be enforced across application tiers.</p>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>HRApp.web</strong> project, open
<strong>OrganizationService.metadata.cs/vb</strong>.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the following attributes to <strong>
Gender</strong> and <strong>Vacation Hours</strong>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
&lt;Required()&gt; _
Public Gender As String

&lt;Range(0, 70)&gt; _
Public VacationHours As Short
</pre>
<pre class="hidden">// C#

[Required]
public string Gender { get; set; }

[Range(0, 70)]
public short VacationHours { get; set; }
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;
&lt;Required()&gt;&nbsp;_&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;Gender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;
&lt;Range(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">70</span>)&gt;&nbsp;_&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;VacationHours&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Short</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On the <strong>Build</strong> menu, select <strong>
Build Solution</strong>.</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application.</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Click on the <strong>Employee List</strong> link. Select an employee and click the pencil icon in the upper right hand corner of the data form to enable editing. Enter a value into the Vacation Hours field that is not within
 the valid range (0-70). You will see a validation error. Also note that the Gender field is required and cannot be left empty.</p>
<p><img src="19443-pic17.png" alt="" width="791" height="494"></p>
<h2>Custom Validation</h2>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In Solution Explorer, right-click the <strong>
HRApp.Web</strong> project, select <strong>Add</strong>, and then select <strong>
New Item</strong>. The <strong>Add New Item</strong> dialog box is displayed.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>Categories</strong> pane, select
<strong>Code</strong>, and in the <strong>Templates</strong> pane, select <strong>
Code File</strong>. Name the new item &lsquo;OrganizationService.shared.cs&rsquo; or &lsquo;OrganizationService.shared.vb&rsquo; and click
<strong>Add</strong>.</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the following block of code to the file:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Imports System
Imports System.ComponentModel.DataAnnotations

Public Module GenderValidator
    Public Function IsGenderValid(ByVal gender As String, ByVal context As ValidationContext) As ValidationResult
        If gender = &quot;M&quot; OrElse gender = &quot;m&quot; OrElse gender = &quot;F&quot; OrElse gender = &quot;f&quot; Then
            Return ValidationResult.Success
        Else
            Return New ValidationResult(&quot;The Gender field only has two valid values 'M'/'F'&quot;, New String() {&quot;Gender&quot;})
        End If
    End Function
End Module
</pre>
<pre class="hidden">// C#
using System;
using System.ComponentModel.DataAnnotations;

namespace HRApp.Web
{
    public static class GenderValidator
    {
        public static ValidationResult IsGenderValid(string gender, ValidationContext context)
        {
            if (gender == &quot;M&quot; || gender == &quot;m&quot; || gender == &quot;F&quot; || gender == &quot;f&quot;)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(&quot;The Gender field only has two valid values 'M'/'F'&quot;, new string[] {&quot;Gender&quot;});            
		}
        }
    }
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.ComponentModel.DataAnnotations&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Module</span>&nbsp;GenderValidator&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Function</span>&nbsp;IsGenderValid(<span class="visualBasic__keyword">ByVal</span>&nbsp;gender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;context&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ValidationContext)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ValidationResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;gender&nbsp;=&nbsp;<span class="visualBasic__string">&quot;M&quot;</span><span class="visualBasic__keyword">OrElse</span>&nbsp;gender&nbsp;=&nbsp;<span class="visualBasic__string">&quot;m&quot;</span><span class="visualBasic__keyword">OrElse</span>&nbsp;gender&nbsp;=&nbsp;<span class="visualBasic__string">&quot;F&quot;</span><span class="visualBasic__keyword">OrElse</span>&nbsp;gender&nbsp;=&nbsp;<span class="visualBasic__string">&quot;f&quot;</span><span class="visualBasic__keyword">Then</span><span class="visualBasic__keyword">Return</span>&nbsp;ValidationResult.Success&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span><span class="visualBasic__keyword">Return</span><span class="visualBasic__keyword">New</span>&nbsp;ValidationResult(<span class="visualBasic__string">&quot;The&nbsp;Gender&nbsp;field&nbsp;only&nbsp;has&nbsp;two&nbsp;valid&nbsp;values&nbsp;'M'/'F'&quot;</span>,&nbsp;<span class="visualBasic__keyword">New</span><span class="visualBasic__keyword">String</span>()&nbsp;{<span class="visualBasic__string">&quot;Gender&quot;</span>})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Function</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Module</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Note:</strong> Since the file ends with &lsquo;.shared.cs/vb&rsquo;, the same code will be available to be consumed on the client as well as the server. We will be using this to run the same validation rule at both locations. (After you rebuild the
 solution, look in the hidden Generated_Code folder on the client, and you will see the OrganizationService.shared.cs/vb file present there as well and being compiled as part of the server project.)</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>OrganizationService.metadata.cs/vb</strong>.</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add a new custom validation attribute to the gender property by adding the following code (in bold).</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
&lt;Required()&gt; _
&lt;CustomValidation(GetType(GenderValidator), &quot;IsGenderValid&quot;)&gt; _
Public Gender As String
</pre>
<pre class="hidden">// C#
[CustomValidation(typeof(HRApp.Web.GenderValidator), &quot;IsGenderValid&quot;)]
[Required]
public string Gender { get; set; }
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;
&lt;Required()&gt;&nbsp;_&nbsp;
&lt;CustomValidation(<span class="visualBasic__keyword">GetType</span>(GenderValidator),&nbsp;<span class="visualBasic__string">&quot;IsGenderValid&quot;</span>)&gt;&nbsp;_&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;Gender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On the <strong>Build</strong> menu, select
<strong>Build Solution</strong>.</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application.</p>
<p>8.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Click on the <strong>Employee List</strong> link. Enter a value for the
<strong>Gender</strong> field that is not &rsquo;M&rsquo; or &rsquo;F&rsquo;.</p>
<p><img src="19444-pic18.png" alt="" width="726" height="484"></p>
<p>&nbsp;</p>
<h2>Add a new record</h2>
<p>You will now create a user interface to allow the addition of new employee records to the database. The validation rules that you added in the previous sections will automatically be applied in the new user interface.</p>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In Solution Explorer, right-click the <strong>
HRApp </strong>project, select<strong> Add</strong>, and then select <strong>New Item</strong>. The
<strong>Add New Item</strong> dialog box is displayed.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>Categories</strong> pane, select
<strong>Silverlight</strong>, and in the <strong>Templates </strong>pane, select <strong>
Silverlight Child Window</strong>. Name the new item &lsquo;EmployeeRegistrationWindow.xaml&rsquo; and click
<strong>Add</strong>.</p>
<p><img src="19445-pic19.png" alt="" width="781" height="424"></p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeRegistrationWindow.xaml.cs/vb</strong> and add the following using/Imports statement:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Imports System.Windows.Controls
Imports System.Windows
</pre>
<pre class="hidden">// C#
using HRApp.Web;
</pre>
<div class="preview">
<pre id="codePreview" class="js">'VB&nbsp;
Imports&nbsp;System.Windows.Controls&nbsp;
Imports&nbsp;System.Windows&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the following property in the code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Public Property NewEmployee As Employee
</pre>
<pre class="hidden">// C#
public Employee NewEmployee { get; set; }
</pre>
<div class="preview">
<pre id="codePreview" class="js">'VB&nbsp;
Public&nbsp;Property&nbsp;NewEmployee&nbsp;As&nbsp;Employee&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeRegistrationWindow.xaml</strong>.</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hide the ChildWindow Close button by adding the XAML in bold below.</p>
<p>&lt;controls:ChildWindow x:Class=&quot;HRApp.EmployeeRegistrationWindow&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&hellip;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Width=&quot;400&quot; Height=&quot;300&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Title=&quot;EmployeeRegistrationWindow&quot;
<strong>HasCloseButton</strong><strong>=&quot;False&quot;</strong>&gt;</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; As we did for the Details view, here too we will be using the DataForm Control from the SL 3 Toolkit. The Silverlight Business Application Project Template carries the System.Windows.Controls.Data.DataForm.Toolkit binary
 in the &lsquo;Libs&rsquo; Folder, hence our Project already has access to the DataForm Control.</p>
<p>Add the following namespace declaration to <strong>EmployeeRegistrationWindow.xaml</strong>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;

xmlns:dataForm=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data.DataForm.Toolkit&quot;
</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span>&nbsp;
&nbsp;
xmlns:dataForm=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data.DataForm.Toolkit&quot;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>8.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the <strong>DataForm</strong> from to the
<strong>EmployeeRegistrationWindow.xaml</strong> just above the &lsquo;Cancel&rsquo; button using the XAML Code below.</p>
<p>&nbsp;</p>
<p>&lt;dataForm:DataForm x:Name=&quot;addEmployeeDataForm&quot;&nbsp; &nbsp;AutoGenerateFields=&quot;False&quot; AutoCommit=&quot;True&quot; AutoEdit=&quot;True&quot; CommandButtonsVisibility=&quot;None&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataForm.EditTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DataTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Login ID&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding LoginID, Mode=TwoWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;National ID&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding NationalIDNumber, Mode=TwoWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Title&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding Title, Mode=TwoWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Marital Status&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox Text=&quot;{Binding MaritalStatus, Mode=TwoWay}&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Gender&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox Text=&quot;{Binding Gender, Mode=TwoWay,NotifyOnValidationError=True, &nbsp;ValidatesOnExceptions=True
 }&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Salaried&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;CheckBox IsChecked=&quot;{Binding SalariedFlag, Mode=TwoWay,NotifyOnValidationError=True, &nbsp;ValidatesOnExceptions=True
 }&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;dataForm:DataField Label=&quot;Active&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;CheckBox IsChecked=&quot;{Binding CurrentFlag, Mode=TwoWay,NotifyOnValidationError=True, &nbsp;ValidatesOnExceptions=True
 }&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DataTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataForm.EditTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/dataForm:DataForm&gt;</p>
<p>&nbsp;</p>
<p>9.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeRegistrationWindow.xaml.cs/vb
</strong>and add the following code (in bold):</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Partial Public Class EmployeeRegistrationWindow
    Inherits ChildWindow

    Public Sub New()
        InitializeComponent()
        NewEmployee = New Employee
        addEmployeeDataForm.CurrentItem = NewEmployee
        addEmployeeDataForm.BeginEdit()
    End Sub

    Public Property NewEmployee As Employee

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles OKButton.Click
        Me.addEmployeeDataForm.CommitEdit()
        Me.DialogResult = True
    End Sub

    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles CancelButton.Click
        NewEmployee = Nothing
        addEmployeeDataForm.CancelEdit()
        Me.DialogResult = False
    End Sub

End Class
</pre>
<pre class="hidden">// C#

public partial class EmployeeRegistrationWindow : ChildWindow
    {
        public Employee NewEmployee { get; set; }

        public EmployeeRegistrationWindow()
        {
            InitializeComponent();
            NewEmployee = new Employee();
           addEmployeeDataForm.CurrentItem = NewEmployee;
           addEmployeeDataForm.BeginEdit();    
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            addEmployeeDataForm.CommitEdit();	
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewEmployee = null;
           addEmployeeDataForm.CancelEdit();
            this.DialogResult = false;
        }
    }
</pre>
<div class="preview">
<pre id="codePreview" class="js">'VB&nbsp;
Partial&nbsp;Public&nbsp;Class&nbsp;EmployeeRegistrationWindow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Inherits&nbsp;ChildWindow&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;New()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewEmployee&nbsp;=&nbsp;New&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;addEmployeeDataForm.CurrentItem&nbsp;=&nbsp;NewEmployee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;addEmployeeDataForm.BeginEdit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Property&nbsp;NewEmployee&nbsp;As&nbsp;Employee&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;OKButton_Click(ByVal&nbsp;sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;RoutedEventArgs)&nbsp;Handles&nbsp;OKButton.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.addEmployeeDataForm.CommitEdit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.DialogResult&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;CancelButton_Click(ByVal&nbsp;sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;RoutedEventArgs)&nbsp;Handles&nbsp;CancelButton.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewEmployee&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;addEmployeeDataForm.CancelEdit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.DialogResult&nbsp;=&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
End&nbsp;Class&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>10.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeList.xaml</strong>.</p>
<p>11.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Add a button called &lsquo;addNewEmployee&rsquo; between the
<strong>DataPager</strong> and the <strong>DataForm</strong> by adding the following XAML code.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- XAML --&gt;

&lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot; Margin=&quot;0,12,0,0&quot;&gt;
    &lt;Button x:Name=&quot;addNewEmployee&quot; Width=&quot;90&quot; Height=&quot;23&quot;  Content=&quot;Add Employee&quot;  Margin=&quot;4,0,0,0&quot; Click=&quot;addNewEmployee_Click&quot;/&gt;
&lt;/StackPanel&gt;
</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__comment">&lt;!--&nbsp;XAML&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Right&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,12,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;addNewEmployee&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;90&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Add&nbsp;Employee&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;4,0,0,0&quot;</span><span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;addNewEmployee_Click&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/StackPanel&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>12.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>EmployeeList.xaml.cs/vb</strong>.</p>
<p>13.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Handle the button click event to show the
<strong>EmployeeRegistrationWindow</strong> by adding the following code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Private Sub addNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    Dim addEmp As New EmployeeRegistrationWindow()
    AddHandler addEmp.Closed, AddressOf addEmp_Closed
    addEmp.Show()
End Sub
</pre>
<pre class="hidden">// C#

private void addNewEmployee_Click(object sender, RoutedEventArgs e)
{
    EmployeeRegistrationWindow addEmp = new EmployeeRegistrationWindow();
    addEmp.Closed &#43;= new EventHandler(addEmp_Closed);
    addEmp.Show();
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;addNewEmployee_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;addEmp&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;EmployeeRegistrationWindow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">AddHandler</span>&nbsp;addEmp.Closed,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;addEmp_Closed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;addEmp.Show()&nbsp;
<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>14.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the following method to handle the
<strong>closed</strong> event for the <strong>EmployeeRegistrationWindow</strong>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Private Sub addEmp_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim emp As EmployeeRegistrationWindow = sender
    If Not emp.NewEmployee Is Nothing Then
        Dim _OrganizationContext As OrganizationContext = employeeDataSource.DomainContext
        _OrganizationContext.Employees.Add(emp.NewEmployee)
        employeeDataSource.SubmitChanges()
    End If
End Sub
</pre>
<pre class="hidden">// C#

void addEmp_Closed(object sender, EventArgs e)
{
    EmployeeRegistrationWindow emp = (EmployeeRegistrationWindow)sender;
    if (emp.NewEmployee != null)
    {
        OrganizationContext _OrganizationContext = (OrganizationContext)(employeeDataSource.DomainContext);
        _OrganizationContext.Employees.Add(emp.NewEmployee);
 employeeDataSource.SubmitChanges();
    }
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;addEmp_Closed(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;emp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EmployeeRegistrationWindow&nbsp;=&nbsp;sender&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">Not</span>&nbsp;emp.NewEmployee&nbsp;<span class="visualBasic__keyword">Is</span><span class="visualBasic__keyword">Nothing</span><span class="visualBasic__keyword">Then</span><span class="visualBasic__keyword">Dim</span>&nbsp;_OrganizationContext&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;OrganizationContext&nbsp;=&nbsp;employeeDataSource.DomainContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_OrganizationContext.Employees.Add(emp.NewEmployee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employeeDataSource.SubmitChanges()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>15.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the <strong>HRApp.web</strong> project, open
<strong>OrganizationService.cs/vb</strong>.</p>
<p>16.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the following code (in bold) to the
<strong>InsertEmployee</strong> method:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
Public Sub InsertEmployee(ByVal employee As Employee)
    'Modify the employee data to meet the database constraints.
    employee.HireDate = DateTime.Now
    employee.ModifiedDate = DateTime.Now
    employee.VacationHours = 0
    employee.SickLeaveHours = 0
    employee.rowguid = Guid.NewGuid()
    employee.ContactID = 1001
    employee.BirthDate = New DateTime(1967, 3, 18)

    If ((employee.EntityState = EntityState.Detached) = False) Then
        Me.ObjectContext.ObjectStateManager.ChangeObjectState(employee, EntityState.Added)
    Else
        Me.ObjectContext.Employees.AddObject(employee)
    End If

End Sub
</pre>
<pre class="hidden">// C#

      public void InsertEmployee(Employee employee)
        {
     // Modify the employee data to meet the database constraints.
            employee.HireDate = DateTime.Now;
            employee.ModifiedDate = DateTime.Now;
            employee.VacationHours = 0;
            employee.SickLeaveHours = 0;
            employee.rowguid = Guid.NewGuid();
            employee.ContactID = 1001;
            employee.BirthDate = new DateTime(1967, 3, 18);

             if ((employee.EntityState != EntityState.Detached))
             {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(employee, EntityState.Added);
             }
             else
             {
                this.ObjectContext.Employees.AddObject(employee);
             }
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span>&nbsp;InsertEmployee(<span class="visualBasic__keyword">ByVal</span>&nbsp;employee&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Modify&nbsp;the&nbsp;employee&nbsp;data&nbsp;to&nbsp;meet&nbsp;the&nbsp;database&nbsp;constraints.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employee.HireDate&nbsp;=&nbsp;DateTime.Now&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employee.ModifiedDate&nbsp;=&nbsp;DateTime.Now&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employee.VacationHours&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employee.SickLeaveHours&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employee.rowguid&nbsp;=&nbsp;Guid.NewGuid()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employee.ContactID&nbsp;=&nbsp;<span class="visualBasic__number">1001</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;employee.BirthDate&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DateTime(<span class="visualBasic__number">1967</span>,&nbsp;<span class="visualBasic__number">3</span>,&nbsp;<span class="visualBasic__number">18</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;((employee.EntityState&nbsp;=&nbsp;EntityState.Detached)&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>)&nbsp;<span class="visualBasic__keyword">Then</span><span class="visualBasic__keyword">Me</span>.ObjectContext.ObjectStateManager.ChangeObjectState(employee,&nbsp;EntityState.Added)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span><span class="visualBasic__keyword">Me</span>.ObjectContext.Employees.AddObject(employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>17.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application.</p>
<p>18.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Click the <strong>employee list</strong> link. You can now add new employees to the database by clicking the &lsquo;Add Employee&rsquo; button. To ensure that the new employee appears in the list, mark the employee
 as Salaried. Earlier you modified the application to only load salaried employees.</p>
<p><img src="19446-pic20.png" alt="" width="815" height="543"></p>
<p>&nbsp;</p>
<div>
<h1>Authentication</h1>
</div>
<h2>Authentication</h2>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Open <strong>OrganizationService.cs</strong>/vb</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the <strong>RequiresAuthentication</strong> attribute on the
<strong>ApproveSabbatical</strong> method by adding the following code (in bold).</p>
<p>This ensures that only authenticated users can now call the <strong>ApproveSabbatical</strong> method on the server. If an anonymous user clicks on the
<strong>ApproveSabbatical</strong> button, the <strong>CurrentFlag</strong> for the selected employee will not be cleared.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
&lt;RequiresAuthentication()&gt; _
Public Sub ApproveSabbatical(ByVal current As Employee)
    Me.ObjectContext.Employees.AttachAsModified(current)
    current.CurrentFlag = False
End Sub
</pre>
<pre class="hidden">// C#
[RequiresAuthentication()]
public void ApproveSabbatical(Employee current)
{
    // Start custom workflow here
    this.ObjectContext.Employees.AttachAsModified(current);
    current.CurrentFlag = false;
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span>&nbsp;
&lt;RequiresAuthentication()&gt;&nbsp;_&nbsp;
<span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span>&nbsp;ApproveSabbatical(<span class="visualBasic__keyword">ByVal</span>&nbsp;current&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.ObjectContext.Employees.AttachAsModified(current)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;current.CurrentFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the client project, open <strong>EmployeeList.xaml.cs/vb</strong>.</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add the following using/Imports statements:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB 
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
</pre>
<pre class="hidden">// C#
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using HRApp.LoginUI;
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB&nbsp;</span><span class="visualBasic__keyword">Imports</span>&nbsp;System.ServiceModel.DomainServices.Client.ApplicationServices&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Modify the <strong>approveSabbatical_Click</strong> method with the following code: This will allow anonymous users to get authenticated and then approve a sabbatical. If the users do not have an existing user account
 they can create one using the Registration Dialog.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'VB
    Private Sub approveSabbatical_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        If WebContext.Current.User IsNot Nothing AndAlso WebContext.Current.User.IsAuthenticated Then
            Dim luckyEmployee As Employee = dataGrid1.SelectedItem
            luckyEmployee.ApproveSabbatical()
            employeeDataSource.SubmitChanges()
        Else
            AddHandler WebContext.Current.Authentication.LoggedIn, AddressOf Current_LoginCompleted
            Dim newWindow As New LoginRegistrationWindow
            newWindow.Show()
        End If
    End Sub

    Private Sub Current_LoginCompleted(ByVal sender As Object, ByVal e As AuthenticationEventArgs)
        Dim luckyEmployee As Employee = dataGrid1.SelectedItem
        luckyEmployee.ApproveSabbatical()
        employeeDataSource.SubmitChanges()
        RemoveHandler WebContext.Current.Authentication.LoggedIn, AddressOf Current_LoginCompleted
    End Sub
</pre>
<pre class="hidden">//C#
private void approveSabbatical_Click(object sender, RoutedEventArgs e)   
{
    if (WebContext.Current.User.IsAuthenticated)
    {
        Employee luckyEmployee = (Employee)(dataGrid1.SelectedItem);
        luckyEmployee.ApproveSabbatical();
        employeeDataSource.SubmitChanges();
    }
    else
    {
        WebContext.Current.Authentication.LoggedIn &#43;= Authentication_LoggedIn;
        new LoginRegistrationWindow().Show();
    }
}

private void Authentication_LoggedIn(object sender, AuthenticationEventArgs e)
{
    Employee luckyEmployee = (Employee)(dataGrid1.SelectedItem);
    luckyEmployee.ApproveSabbatical();
    employeeDataSource.SubmitChanges();
    
    WebContext.Current.Authentication.LoggedIn -= Authentication_LoggedIn;
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'VB</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;approveSabbatical_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;WebContext.Current.User&nbsp;<span class="visualBasic__keyword">IsNot</span><span class="visualBasic__keyword">Nothing</span><span class="visualBasic__keyword">AndAlso</span>&nbsp;WebContext.Current.User.IsAuthenticated&nbsp;<span class="visualBasic__keyword">Then</span><span class="visualBasic__keyword">Dim</span>&nbsp;luckyEmployee&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee&nbsp;=&nbsp;dataGrid1.SelectedItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;luckyEmployee.ApproveSabbatical()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employeeDataSource.SubmitChanges()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span><span class="visualBasic__keyword">AddHandler</span>&nbsp;WebContext.Current.Authentication.LoggedIn,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;Current_LoginCompleted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;newWindow&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;LoginRegistrationWindow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newWindow.Show()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Current_LoginCompleted(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;AuthenticationEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;luckyEmployee&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee&nbsp;=&nbsp;dataGrid1.SelectedItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;luckyEmployee.ApproveSabbatical()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employeeDataSource.SubmitChanges()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">RemoveHandler</span>&nbsp;WebContext.Current.Authentication.LoggedIn,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;Current_LoginCompleted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Run the application and click the <strong>
employee list</strong> link.</p>
<p>7.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select an employee record and click the &lsquo;Approve Sabbatical&rsquo; button. You are redirected to the login page.</p>
<p>8.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter your credentials to login, or click
<strong>register</strong>.</p>
<p>After login is completed, you are redirected to the Employee List page and the employee&rsquo;s sabbatical is approved.</p>
<p><img src="19447-pic21.png" alt="" width="731" height="487"></p>
<p>&nbsp;</p>
<div>
<h1>Completed Projects</h1>
</div>
<p>The completed projects for both VB and C# can be found at:-</p>
<p><a href="http://go.microsoft.com/fwlink/?LinkId=145481">http://go.microsoft.com/fwlink/?LinkId=145481</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>WCF RIA Services</h1>
<p>Microsoft WCF RIA Services simplifies the traditional n-tier application pattern by bringing together the ASP.NET and Silverlight platforms using WCF. The RIA Services provides a prescriptive pattern to write application logic that runs on the mid-tier and
 controls access to data for queries, changes and custom operations. It also provides end-to-end support for common tasks such as data validation, authentication and roles by integrating with Silverlight components on the client and ASP.NET on the mid-tier.
 It includes rich tooling for integrating client and mid-tier projects and for building rich UI through the simplicity of drag-drop support.&nbsp;</p>
<p>&nbsp;</p>
<p>For the latest information please click&nbsp;<a href="http://silverlight.net/riaservices">here</a>&nbsp;.</p>
<p>&nbsp;</p>
<p>RIA Services Home Page with links to the download site, MSDN docs, talks ... can be found&nbsp;<a href="http://silverlight.net/RIAServices">here</a>.</p>
<p>&nbsp;</p>
<p>For help porting applications to the latest bits -&nbsp;<a href="http://archive.msdn.microsoft.com/RiaServices/Release/ProjectReleases.aspx?ReleaseId=3570">Breaking Changes from Beta(PDC 09) to RTW</a></p>
<p>&nbsp;</p>
<p>The document above also insludes guidance on updating VS 2008/.NET 3.5 RIA Services applications to VS 2010/.NET 4</p>
<p>Please use the&nbsp;<a href="http://silverlight.net/forums/53.aspx">forums</a>&nbsp;to provide feedback or post questions.</p>
<p>&nbsp;</p>
<h2>Sample download instructions</h2>
<p>Please note that once you have downloaded a Sample.zip from below to your machine, you need to right click on the .zip, go to the Property Page and explicitly UnBlock the content. Only then should you extract the .zip file.</p>
