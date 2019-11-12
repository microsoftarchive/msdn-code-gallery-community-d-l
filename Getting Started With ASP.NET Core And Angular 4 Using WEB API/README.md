# Getting Started With ASP.NET Core And Angular 4 Using WEB API
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET Core
- Angular 4
## Topics
- ASP.NET Core
- Angular 4
## Updated
- 09/21/2017
## Description

<h1>Introduction</h1>
<p><img id="178911" src="178911-image001.jpg" alt="" width="602" height="252"></p>
<p><span lang="EN-US">In this article, let&rsquo;s see on how to getting started with ASP.NET Core and using Web API.</span></p>
<h1><span>Building the Sample</span></h1>
<p><strong>Prerequisites</strong></p>
<p><br>
Make sure, you have installed all the prerequisites in your computer. If not, then download and install all, one by one.</p>
<ol>
<li>First, download and install Visual Studio 2017 from this&nbsp;<a href="https://www.visualstudio.com/" target="_blank">link</a>.
</li><li><a href="https://www.microsoft.com/net/core#windowscmd" target="_blank">Download</a>&nbsp;and install .NET Core 1.0.1&nbsp;
</li><li>Download and install Node.js v4.0 or above. I have installed V6.11.2 (Download&nbsp;<a href="https://nodejs.org/en/" target="_blank">link</a>).
</li></ol>
<p>First Download and Install the Visual Studio 2017</p>
<p><img id="178912" src="178912-1.png" alt="" width="555" height="360"></p>
<p>Select depend on your need and install the Visual Studio 2017 on your computer. If you have already installed Visual Studio 2017 then skip this part.<img id="178913" src="178913-2.png" alt="" width="550" height="409"></p>
<p>Once Install you can open the Visual Studio 2017 to create your first ASP.NET Core and Angular4 application</p>
<p><img id="178914" src="178914-3.png" alt="" width="557" height="400"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong>Now it&rsquo;s&nbsp;</strong>time to create our first ASP.NET Core and Angular4 application.<strong>&nbsp;</strong></p>
<h1><strong>Step 1- Create ASP.NET Core Empty project</strong></h1>
<p><strong>&nbsp;</strong>After installing all the prerequisites listed above, click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2017 &gt;&gt; Visual Studio 2017, on your desktop. Click New &gt;&gt; Project. Select Web &gt;&gt; ASP.NET Core Angular 2 Starter.
 Enter your project name and click OK.</p>
<p><img id="178915" src="178915-1.png" alt="" width="478" height="249"></p>
<p>Select Empty Project and click ok, If you have installed ASP.ENT Core 2.0 then you can then chose ASP.NET Core 2.0.</p>
<p><img id="178916" src="178916-2.png" alt="" width="398" height="260"></p>
<p>After creating ASP.NET Core Angular 2 application, wait for a few seconds. You can see the empty project was created successfully.</p>
<h1><strong>Step 2 &ndash; Enabling MVC and StaticFiles</strong></h1>
<p><strong>&nbsp;</strong>Since we have created as the empty project now we need to enable our project to work with WEB API and also to run the html files for displaying the Angular result we need to enable the StaticFiles.</p>
<p>For this right click on your project and click edit your project.csproj.</p>
<p><img id="178917" src="178917-4.png" alt="" width="430" height="221"></p>
<p>We can see our csproj file will be opened for edit.</p>
<p><img id="178918" src="178918-5.png" alt="" width="735" height="320"></p>
<p>Now add this 2 below code part for enabling the MVC and StaticFile Packages to our project.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">&lt;PackageReference&nbsp;Include=<span class="js__string">&quot;Microsoft.AspNetCore.Mvc&quot;</span>&nbsp;Version=<span class="js__string">&quot;1.1.2&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;PackageReference&nbsp;Include=<span class="js__string">&quot;Microsoft.AspNetCore.StaticFiles&quot;</span>&nbsp;Version=<span class="js__string">&quot;1.1.1&quot;</span>&nbsp;/&gt;&nbsp;
</pre>
</div>
</div>
</div>
<p>Now your code part will be look like below</p>
<p><img id="178919" src="178919-6.png" alt="" width="558" height="251"></p>
<p>Save the csproj file. After saving all the dependency will be installed to our project for working with WEB API.<strong>&nbsp;</strong></p>
<h1><strong>Step &ndash; 3 Editing Startup.cs file</strong></h1>
<h2><strong>Open the Startup.cs file</strong></h2>
<p><img id="178920" src="178920-7.png" alt="" width="808" height="394"></p>
<p>Now in Startup.cs file we need add the MVC Service and also to set the default open html page like below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">public&nbsp;<span class="js__operator">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;This&nbsp;method&nbsp;gets&nbsp;called&nbsp;by&nbsp;the&nbsp;runtime.&nbsp;Use&nbsp;this&nbsp;method&nbsp;to&nbsp;configure&nbsp;the&nbsp;HTTP&nbsp;request&nbsp;pipeline.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Configure(IApplicationBuilder&nbsp;app,&nbsp;IHostingEnvironment&nbsp;env,&nbsp;ILoggerFactory&nbsp;loggerFactory)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.Use(async&nbsp;(context,&nbsp;next)&nbsp;=&gt;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;next();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(context.Response.StatusCode&nbsp;==&nbsp;<span class="js__num">404</span>&nbsp;&amp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;!Path.HasExtension(context.Request.Path.Value)&nbsp;&amp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;!context.Request.Path.Value.StartsWith(<span class="js__string">&quot;/api/&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Request.Path&nbsp;=&nbsp;<span class="js__string">&quot;./src/index.html&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;next();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseMvcWithDefaultRoute();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseDefaultFiles();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseStaticFiles();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong>Step &ndash; 4 Creating Web API</strong></p>
<p>To create our WEB API Controller, right click project folder. Click Add and click New Item.</p>
<p><img id="178921" src="178921-8.png" alt="" width="459" height="280"></p>
<p>Select ASP.NET Core &gt;Select Web API Controller Class and click Add</p>
<p><img id="178922" src="178922-9.png" alt="" width="531" height="248"></p>
<p>As we all know Web API is a simple and easy way to build HTTP Services for Browsers and Mobiles.<br>
<br>
Web API has the following four methods as&nbsp;<strong>Get/Post/Put and Delete</strong>.</p>
<ul>
<li><strong>Get</strong>&nbsp;is to request for the data. (Select) </li><li><strong>Post</strong>&nbsp;is to create a data. (Insert) </li><li><strong>Put</strong>&nbsp;is to update the data. </li><li><strong>Delete</strong>&nbsp;is to delete data. </li></ul>
<p>Here in this demo we are using only the Get method so we can delete all other methods of PUT/POST and Delete from the controller class and in Get Method we return the string values like below.</p>
<p>Our edited Web API Controller class will be look like this</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="csharp">[Route(<span class="cs__string">&quot;api/[controller]&quot;</span>)]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ValuesController&nbsp;:&nbsp;Controller&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__com">//&nbsp;GET:&nbsp;api/values&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Get()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{returnnew&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{<span class="cs__string">&quot;Afraz&quot;</span>,&nbsp;<span class="cs__string">&quot;Afreen&quot;</span>,&nbsp;<span class="cs__string">&quot;ASHA&quot;</span>,&nbsp;<span class="cs__string">&quot;KATHER&quot;</span>,&nbsp;<span class="cs__string">&quot;Shanu&quot;</span>};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}}}</pre>
</div>
</div>
</div>
<p>To test Get Method ,we can run our project and copy the get method api path, here we can see our API path for get is api/values</p>
<p>Run the program and paste the above API path to test our output.</p>
<p><img id="178923" src="178923-10.png" alt="" width="357" height="111"></p>
<h1><strong>Step &ndash; 5 Working with Angular</strong></h1>
<p>Now let&rsquo;s start working with Angular part.</p>
<p>First, we need to install the Angular CLI to our project</p>
<h2><strong>Angular CLI:</strong></h2>
<p>Angular cli is a command line interface to scaffold and build angular apps using nodejs style (commonJs) modules.&nbsp;<a href="http://ngcli.github.io/">Ref link</a></p>
<p>To install the Angular CLI to our project open the Visual Studio Command Prompt and move the project folder path.</p>
<p>Now we need to move to our project folder path. If you not sure about your project path then click on the Project and see the properties to check the project path.</p>
<p>Copy the Project Folder path. Here we can see as my project is in G: drive so first change to G: drive and change to our project folder</p>
<p><img id="178924" src="178924-012_1.png" alt="" width="602" height="385"></p>
<p>Now install the Angular CLI to your project. To Install it write the below command and run it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">npm&nbsp;install&nbsp;@angular/cli&nbsp;&ndash;global</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="178925" src="178925-13.png" alt="" width="667" height="425"></div>
<p>&nbsp;Wait for few seconds to Angular CLI install on your project</p>
<p>Now its time to scaffold a Angular application in our project run the below command and wait for few second and you can see all the Angular files will be added in our project.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">ng&nbsp;<span class="js__operator">new</span>&nbsp;ASPNETCOREDEMO&nbsp;--skip-install</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;note that you need to add your project name after the new keyword from above command. Here my project name is ASPNETCOREDEMO. Runt he above command and Wait for few second and we can see the success message like below.&nbsp;</div>
<p><img id="178926" src="178926-14.png" alt="" width="664" height="433"></p>
<p>In our project, we can see a new folder with our same project name has been created.</p>
<p><img id="178927" src="178927-15.png" alt="" width="252" height="187"></p>
<p>Open the folder and we can see all the Angular files has been created inside the folder.</p>
<p><img id="178929" src="178929-16.png" alt="" width="266" height="609"></p>
<p>Move all the files to the main project .</p>
<p>After moving all the files to the main project delete the empty folder.</p>
<h1><strong>Step &ndash; 6 Working with Angular Files</strong></h1>
<h2>&nbsp;<strong>Working with Angular Module&nbsp;</strong></h2>
<p>Since we need to display the Web API result in our Angular application, we need to import the HTTPmodul in app.module file.</p>
<p>Open the app.module file</p>
<p><img id="178930" src="178930-17.png" alt="" width="253" height="255"></p>
<p>Change with the below code</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;BrowserModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/platform-browser'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;NgModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/core'</span>;&nbsp;
&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;AppComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./app.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;FormsModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/forms'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;HttpModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/http'</span>;&nbsp;
@NgModule(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;declarations:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppComponent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imports:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BrowserModule,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FormsModule,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpModule&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;providers:&nbsp;[],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bootstrap:&nbsp;[AppComponent]&nbsp;
<span class="js__brace">}</span>)&nbsp;
export&nbsp;class&nbsp;AppModule&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong>Working with Angular Component</strong></p>
<p>Now we need to work with our Angular Component to link with our Web API and get the JSOn result to bind in our html file.</p>
<p>Open the Angular Component file and add the below code.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;Component,&nbsp;OnInit&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/core'</span>;&nbsp;
&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;Http&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/http'</span>;&nbsp;
@Component(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selector:&nbsp;<span class="js__string">'app-root'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;templateUrl:&nbsp;<span class="js__string">'./app.component.html'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;styleUrls:&nbsp;[<span class="js__string">'./app.component.css'</span>]&nbsp;
<span class="js__brace">}</span>)&nbsp;
export&nbsp;class&nbsp;AppComponent&nbsp;implements&nbsp;OnInit&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;constructor(private&nbsp;_httpService:&nbsp;Http)&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;string&nbsp;=&nbsp;<span class="js__string">&quot;SHANU&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;apiValues:&nbsp;string[]&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ngOnInit()&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>._httpService.get(<span class="js__string">'/api/values'</span>).subscribe(values&nbsp;=&gt;&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.apiValues&nbsp;=&nbsp;values.json()&nbsp;as&nbsp;string[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong>Working with HTML FILE</strong></p>
<p>Now we are in the final stage of the coding part, Design our html and bind the result from Angular to your app.component.html file.</p>
<p>Edit the html file and change with this below code.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">&lt;h1&gt;&lt;span&nbsp;style=<span class="js__string">&quot;color:#285783&quot;</span>&gt;Welcome&nbsp;to&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>title<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;Angular&nbsp;and&nbsp;ASP.NET&nbsp;Core&nbsp;&nbsp;Demo&nbsp;&lt;<span class="js__reg_exp">/span&gt;&lt;/</span>h1&gt;&nbsp;
&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;table&nbsp;class=<span class="js__string">'table'</span>&nbsp;style=<span class="js__string">&quot;background-color:#FFFFFF;&nbsp;border:2px&nbsp;#6D7B8D;&nbsp;padding:5px;width:99%;table-layout:fixed;&quot;</span>&nbsp;cellpadding=<span class="js__string">&quot;2&quot;</span>&nbsp;cellspacing=<span class="js__string">&quot;2&quot;</span>&nbsp;*ngIf=<span class="js__string">&quot;apiValues&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;180&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&lt;strong&gt;Names&lt;<span class="js__reg_exp">/strong&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&lt;tbody&nbsp;*ngFor=<span class="js__string">&quot;let&nbsp;value&nbsp;of&nbsp;apiValues&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>value<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&lt;/tbody&gt;&nbsp;
&lt;/table&gt;&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>Step &ndash; 6 Build and Run</strong></p>
<p>First, we need to install all the Angular dependency to our application. To install enter the below command and run in the command prompot.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">npm&nbsp;install</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="178931" src="178931-18.png" alt="" width="666" height="433"></div>
<p>Wait till the npm install complete</p>
<p><img id="178932" src="178932-19.png" alt="" width="662" height="305"></p>
<h2><strong>Build the Application</strong></h2>
<p>Enter the below command to build the application</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">ng&nbsp;build</pre>
</div>
</div>
</div>
<p>Wait for few second till the build complete.</p>
<p><img id="178933" src="178933-20.png" alt="" width="671" height="253"></p>
<p><strong>Runt the application</strong></p>
<p>Enter the below command and press enter to run the application.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="js">dotnet&nbsp;run&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>We can see the localhost address to run our application. Enter the address in browser to see our Angular Application running with the result displayed.<img id="178934" src="178934-21.png" alt="" width="605" height="344"></p>
<p><span style="font-size:2em">Source Code Files</span></p>
<ul>
<li><em><a class="text-blue-600 x_x_x_x_bold" title="ASPNETCOREDEMO.zip">ASPNETCOREDEMO.zip</a>.</em><em>.</em>
</li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>Donwload the Source code and install all the dependency ,build and run the application.</em></p>
