# Getting Started with Angular 7 And ASP.NET Core 2.1
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET Core
- Angular 7
## Topics
- ASP.NET Core
- Angular 7
## Updated
- 02/08/2019
## Description

<h1>Introduction</h1>
<p>In this article let&rsquo;s see in detail about getting started with Angular 7 and ASP.Net Core 2.0 using Angular 7 Web Application (.NET Core) Template and ASP.NET Core MVC Application. We will also see in detail about how to work with Angular 7 new features
 of Virtual Scrolling and Drag and Drop Items.</p>
<p><img id="218940" src="218940-1.gif" alt="" width="375" height="674"></p>
<h1><span>Building the Sample</span></h1>
<h1 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Prerequisites</span></strong></h1>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Make sure you have installed all the prerequisites in your computer. If not, then download and install all, one
 by one.</span></p>
<p>&nbsp;</p>
<ol type="1">
<li class="MsoNormal" style="color:#212121; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">First, download and install Visual Studio 2017 from this&nbsp;</span><span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="https://www.visualstudio.com/" target="_blank"><span style="color:#1e88e5">link</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">.</span>
</li><li class="MsoNormal" style="color:#212121; line-height:normal"><span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="https://www.microsoft.com/net/core#windowscmd" target="_blank"><span style="color:#1e88e5">Download</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">&nbsp;and
 install .NET Core 2.0 or above version.</span> </li><li class="MsoNormal" style="color:#212121; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">Download and install Node.js latest version from this download&nbsp;</span><span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="https://nodejs.org/en/" target="_blank"><span style="color:#1e88e5">link</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">.</span>
</li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Now, it&rsquo;s time to create our first ASP.NET Core and Angular 7 application using the Template.</span></p>
<h1 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10pt; font-family:Arial,sans-serif">Angular 7 Web Application (.NET Core) using Template</span></strong></h1>
<h2 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Step 1- Create Angular 7 ASP.NET Core using Template</span></strong></h2>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">After installing all the prerequisites listed above, click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2017 &gt;&gt;
 Visual Studio 2017, on your desktop.</span></p>
<p class="MsoNormal" style="margin-bottom:0.0001pt; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Click New &gt;&gt; Project. Select Online &gt;&gt; Template &gt;&gt; Search for Angular 7 .NetCore 2 Template<img id="218941" src="218941-1.png" alt="" width="440" height="360"></span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Download and Install the Template.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><img id="218942" src="218942-2.png" alt="" width="928" height="641"><br>
</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">We can see as the new Angular 7 web Application(.Net Core) template has been added ,Select the template add your
 project name and click ok to create your Angular 7 application using ASP.NET Core.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><img id="218943" src="218943-3.png" alt="" width="885" height="447"><br>
</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">You can see as new Angular7 project has been created also we can see the Asp.Net Core Controller and Angular 7 Client
 App folder from the solution explorer.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><img id="218944" src="218944-5.png" alt="" width="264" height="316"></span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">If we Open the package.json file we can see the new Angular 7 package has been installed to our project</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><img id="218945" src="218945-6.png" alt="" width="624" height="331"></span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Note:</span></strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;
 we need to upgrade our Angular CLI to version 7. If you not yet install the Angular CLI then first install the Angular CLI and upgrade to Angular CLI version 7.</span><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">&nbsp;</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Now, let&rsquo;s start working with the Angular part.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">First, we need to install the Angular CLI to our project</span></p>
<h3 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Angular CLI</span></strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;</span></h3>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Angular CLI is a command line interface to scaffold and build Angular apps using node.js style (commonJS) modules.&nbsp;</span><span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="http://ngcli.github.io/" target="_blank"><span style="color:#1e88e5">for
 More details click here</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">To install the Angular CLI to your project, open the Visual Studio Command Prompt and &nbsp;&nbsp;run the below
 command.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="js">npm&nbsp;i&nbsp;-g&nbsp;@angular/cli</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;<strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Step 2 -
</span></strong><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Build and Run the Application</span></strong></h2>
<p><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">Now our application is ready to build and Run to see the sample Angular 7 page. Once we run the application, we can see a sample Angular 7-page like below.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><img id="218947" src="218947-7.png" alt="" width="205" height="330"></span></p>
<h3 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">ClientApp folder:</span></strong></h3>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">Our Angular files will be under the ClientApp folder. If we want to work with component or html then we open the app
 folder under ClientApp and we can see the app.Component.ts and app.Component.html.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><img id="218948" src="218948-8.png" alt="" width="291" height="289"></span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Now we can change the Title from our component file and display the new sub title with date time in our app html
 page.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;</span><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">In our app.Component.ts
 file we changed the default title and also added a new variable to get the current date and time to display in our html page.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">title&nbsp;=&nbsp;<span class="js__string">'Welcome&nbsp;to&nbsp;Shanu&nbsp;Angular&nbsp;7&nbsp;Web&nbsp;page'</span>;&nbsp;
subtitle&nbsp;=&nbsp;<span class="js__string">'.NET&nbsp;Core&nbsp;&#43;&nbsp;Angular&nbsp;CLI&nbsp;v7&nbsp;&#43;&nbsp;Bootstrap&nbsp;&amp;&nbsp;FontAwesome&nbsp;&#43;&nbsp;Swagger&nbsp;Template'</span>;&nbsp;&nbsp;&nbsp;&nbsp;datetime&nbsp;=&nbsp;<span class="js__object">Date</span>.now();&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="218949" src="218949-9.png" alt="" width="624" height="209"></div>
<p class="MsoNormal" style="line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">In our html page we bind the newly declared variable datetime with below code.</span><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&lt;h1&gt;<span class="js__brace">{</span><span class="js__brace">{</span>title<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h3&gt;<span class="js__brace">{</span><span class="js__brace">{</span>subtitle<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/h3&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h4&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Current&nbsp;<span class="js__object">Date</span>&nbsp;and&nbsp;Time:&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>datetime&nbsp;|&nbsp;date:<span class="js__string">'yyyy-MM-dd&nbsp;hh:mm'</span><span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/h4&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="color:#000000; font-family:Verdana,Arial,Helvetica,sans-serif; font-size:10px">When we run the application, we can see as the title has been updated and displaying todays date and time like below image.</span></div>
<p>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<p><img id="218950" src="218950-10.png" alt="" width="563" height="347"></p>
<h1 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:12pt; font-family:Arial,sans-serif">Using Asp.NET Core Web Application</span></strong></h1>
<h2 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Step 1- Create ASP.NET Core Web Application</span></strong></h2>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2017 &gt;&gt; Visual Studio 2017, on your desktop.</span></p>
<p><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">Click New &gt;&gt; Project. Select Web &gt;&gt; ASP.NET Core Web Application. Enter your project name and click OK.</span></p>
<p class="MsoNormal" style="margin-bottom:0.0001pt; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><img id="218951" src="218951-11.png" alt="" width="881" height="447"><br>
</span></p>
<p class="MsoNormal"><span style="font-size:10.5pt; line-height:107%; font-family:Arial,sans-serif; color:#212121">Select Angular Project and click OK. &nbsp;</span></p>
<p class="MsoNormal"><span style="font-size:10.5pt; line-height:107%; font-family:Arial,sans-serif; color:#212121"><img id="218952" src="218952-12.png" alt="" width="792" height="558"><br>
</span></p>
<h2 class="MsoNormal"><strong><span style="font-size:10.5pt; line-height:107%; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Step 2 &ndash; Upgrade to Angular 7</span></strong></h2>
<p class="MsoNormal">By default, we can see the Angular 5 version has been installed in our project. We can check this from our Package.json file</p>
<p class="MsoNormal"><img id="218954" src="218954-13.png" alt="" width="889" height="640"></p>
<p class="MsoNormal">For upgrading to Angular 7 first we delete the ClientApp folder from project and create nee ClientApp from the Command prompt.</p>
<p class="MsoNormal">First, we delete the ClientApp folder from our project.</p>
<p class="MsoNormal"><img id="218955" src="218955-14.png" alt="" width="496" height="474"></p>
<p class="MsoNormal">To install and create a new ClientApp with Angular7 packages, open a command prompt and go to our project folder, Enter the below command and run to install the Angular 7 Packages and create new ClientApp folder for working with Angular
 7.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="js">ng&nbsp;<span class="js__operator">new</span>&nbsp;ClientApp&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="218956" src="218956-15.png" alt="" width="742" height="86"></div>
<p>It will take few seconds to install all the Angular 7 Packages and we can see the installing package details and confirmation from our command window.</p>
<p class="MsoNormal"><img id="218957" src="218957-16.png" alt="" width="1318" height="906"></p>
<p class="MsoNormal">We can see new ClientApp folder has been created in our project and when we open the Package.json file the Angular 7 Version has been installed to ours project.</p>
<p class="MsoNormal"><img id="218958" src="218958-20.png" alt="" width="304" height="177"></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Note:</span></strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;
 we need to upgrade our Angular CLI to version 7. If you not yet install the Angular CLI then first install the Angular CLI and upgrade to Angular CLI version 7.</span><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">&nbsp;</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Now, let&rsquo;s start working with the Angular part.</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">First, we need to install the Angular CLI to our project</span></p>
<h3 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Angular CLI</span></strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;</span></h3>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Angular CLI is a command line interface to scaffold and build Angular apps using node.js style (commonJS) modules.&nbsp;</span><span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="http://ngcli.github.io/" target="_blank"><span style="color:#1e88e5">for
 More details click here</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">&nbsp;</span></p>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">To install the Angular CLI to your project, open the Visual Studio Command Prompt and &nbsp;&nbsp;run the below
 command.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="js">npm&nbsp;i&nbsp;-g&nbsp;@angular/cli</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;&nbsp;<strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Step 3 -
</span></strong><strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Build and Run the Application</span></strong></h2>
<p><span style="color:#212121; font-family:Arial,sans-serif; font-size:10.5pt">Now our application is ready to build and Run to see the sample Angular 7 page. Once we run the application, we can see a sample Angular 7-page like below.</span></p>
<p><img id="218959" src="218959-7.png" alt="" width="205" height="330"></p>
<h1 class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><strong><span style="font-size:14.0pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">What&rsquo;s new in Angular 7</span></strong></h1>
<p class="MsoNormal">Virtual Scrolling and Drag and Drop are major features added in the Angular 7 CDK. If we have a large no of item in the list and want a fast performance scrolling to load and display all the items then we can use the new Angular 7 Virtual
 Scrolling to scroll the items in the List. Using the Angular 7 Drag and Drop now we can Drag and drop the item to the same list or to another list. We will be seeing in detail on how to work with Angular 7 Virtual Scrolling and Drag and Drop with example below.</p>
<h2 class="MsoNormal"><strong>Installing Angular CDK</strong></h2>
<p class="MsoNormal">For working with Virstual Scrolling and Drag and Drop we need to install the Angular CDK package to our project to add this we open the command prompt and go to our project ClientApp Folder path and enter the below code and run the command.</p>
<p class="MsoNormal"><img id="218960" src="218960-18.png" alt="" width="796" height="77">We can see the confirmation message in command prompt as the Angular CDK packages has been added to our project.</p>
<p class="MsoNormal">&nbsp;</p>
<p><img id="218961" src="218961-19.png" alt="" width="797" height="309"></p>
<h2 class="MsoNormal"><strong><span style="font-size:14.0pt; line-height:107%">Virtual Scrolling</span></strong></h2>
<h3 class="MsoNormal"><strong>App Module - Importing the Scrolling Module to our App</strong></h3>
<p class="MsoNormal">In order to work with Virtual scrolling after adding the CDK project we need to import the ScrollingModule to our Modules app.</p>
<p>Open our Module.ts file here we will be working with our default app.module.ts to import the ScrollingModule to create our Virtual Scrolling in our application.</p>
<p class="MsoNormal"><img id="218962" src="218962-20.png" alt="" width="304" height="177"></p>
<p class="MsoNormal">Add the below code in import section of your module to import the ScrollingModule.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;ScrollingModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/cdk/scrolling'</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Also we need to add the import section add the ScrollingModule to work with Virtual Scrolling.</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;imports:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BrowserModule,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AppRoutingModule,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ScrollingModule&nbsp;
],</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="text-indent:10.5pt">Our Code will be look like below image.</span></div>
<div class="endscriptcode"><span style="text-indent:10.5pt"><img id="218963" src="218963-21.png" alt="" width="415" height="359"></span></div>
<h4><strong>App Component</strong></h4>
<div class="endscriptcode">
<p class="MsoNormal">For adding item to the list, we need an Item, for creating the Item in our app component we create a new Array and add items to the array in the constructor. By this when the page loads the new array item will be created with new values.Open
 the app.component.ts file and add the below code in your component export class.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">incrementValue:&nbsp;number[]&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;constructor()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(let&nbsp;index&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;index&nbsp;&lt;=&nbsp;<span class="js__num">200</span>;&nbsp;index&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.incrementValue.push(index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The complete code will be look like this.</div>
</div>
<p><img id="218964" src="218964-22.png" alt="" width="687" height="374"></p>
<h4 class="MsoNormal"><strong>Adding the CSS</strong></h4>
<p class="MsoNormal">For our List scrolling we will be adding the below CSS to design our list with c rounded corner and adding colors. Add the below css code to your app.component.css file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">ul&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;max-width:&nbsp;800px;&nbsp;
&nbsp;&nbsp;color:&nbsp;#cc4871;&nbsp;
&nbsp;&nbsp;margin:&nbsp;20px&nbsp;auto;&nbsp;
&nbsp;&nbsp;padding:&nbsp;2px;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
.list&nbsp;li&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;padding:&nbsp;20px;&nbsp;
&nbsp;&nbsp;background:&nbsp;#f8d8f2;&nbsp;
&nbsp;&nbsp;border-radius:&nbsp;12px;&nbsp;
&nbsp;&nbsp;margin-bottom:&nbsp;12px;&nbsp;
&nbsp;&nbsp;text-align:&nbsp;center;&nbsp;
&nbsp;&nbsp;font-size:&nbsp;12px;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h4 class="endscriptcode">&nbsp;<strong>Design your HTML page to display the List with CDK Virtual Scrolling</strong></h4>
<p>Now its time to design our html page to add the Virtual Scrolling function to the List for scrolling the item from the list. Open app.component.html and add the below code to display the item in list with Virtual Scrolling features added.</p>
<p class="MsoNormal">Inside the list we use the <span style="font-size:9.5pt; line-height:107%; font-family:Consolas; color:maroon">
cdk-virtual-scroll-viewport </span><span style="font-size:9.5pt; line-height:107%; font-family:Consolas">to add the virtual scrolling to our list and here we set the width and height of the List with the Itemsize per each scroll.</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; line-height:107%; font-family:Consolas">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">css</span>

<div class="preview">
<pre class="js">&lt;h2&gt;Angular&nbsp;<span class="js__num">7</span>&nbsp;Virtual&nbsp;Scrolling&nbsp;&lt;/h2&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;ul&nbsp;class=<span class="js__string">&quot;list&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;cdk-virtual-scroll-viewport&nbsp;style=<span class="js__string">&quot;width:200px;height:&nbsp;300px&quot;</span>&nbsp;itemSize=<span class="js__string">&quot;5&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ng-container&nbsp;*cdkVirtualFor=<span class="js__string">&quot;let&nbsp;incValue&nbsp;of&nbsp;incrementValue&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;&nbsp;Loop&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>incValue<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;&nbsp;&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ng-container&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/cdk-virtual-scroll-viewport&gt;&nbsp;
&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
</pre>
</div>
</div>
</div>
<h3 class="endscriptcode">&nbsp;<strong style="font-family:Verdana,Arial,Helvetica,sans-serif; font-size:10px">Run the Application</strong></h3>
<p>&nbsp;</p>
<p class="MsoNormal"><strong>&nbsp;</strong></p>
<p><img id="218965" src="218965-23.gif" alt="" width="448" height="597"></p>
<h2 class="MsoNormal"><strong><span style="font-size:14.0pt; line-height:107%">Drag and Drop</span></strong></h2>
<h3 class="MsoNormal"><strong>App Module - Importing the DragDrop Module to our App</strong></h3>
<p class="MsoNormal">In order to work with Drag and Drop after adding the CDK project we need to import the DragDrop Module to our Modules app.</p>
<p class="MsoNormal">Open our app.Module.ts file here we will be working with our default app.module.ts to import the DragDrop Module to create our Drag and Drop items in our application.</p>
<p class="MsoNormal"><img id="218966" src="218966-24.png" alt="" width="588" height="454"></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Add the below code in import section of your module to import the Drag and Drop.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;DragDropModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/cdk/drag-drop'</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Also we need to add the import section add the ScrollingModule to work with Virtual Scrolling.</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">imports:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BrowserModule,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AppRoutingModule,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ScrollingModule&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DragDropModule&nbsp;
],</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="text-indent:10.5pt; font-family:Verdana,Arial,Helvetica,sans-serif; font-size:10px">Our Coed will be look like below image.</span></div>
<p><img id="218967" src="218967-24.png" alt="" width="588" height="454"></p>
<h4 class="MsoNormal"><strong>App Component</strong></h4>
<p class="MsoNormal">For adding item to the list, we need an Item, for creating the Item in our app component we create a new Array and add items to the array in the constructor. By this when the page loads the new array item will be created with new values.
 Open the app.component.ts file and add the below code in your component export class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">incrementValue:&nbsp;number[]&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;decrementValue:&nbsp;number[]&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;constructor()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(let&nbsp;index&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;index&nbsp;&lt;=&nbsp;<span class="js__num">200</span>;&nbsp;index&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.incrementValue.push(index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(let&nbsp;int1&nbsp;=&nbsp;<span class="js__num">400</span>;&nbsp;int1&nbsp;&gt;=&nbsp;<span class="js__num">201</span>;&nbsp;int1--)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.decrementValue.push(int1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="text-indent:10.5pt">Here we have used the Increment Array we use for the Virtual Scrolling and Decrement array item we use for the Drag and Drop.</span><span style="text-indent:10.5pt">&nbsp;</span></div>
<p class="MsoNormal" style="text-indent:10.5pt">Now we need to Import the CdkDragDrop with MoveItemInArray to create the Drop event for adding the dragged item during drop at the selected position in the list.&nbsp;&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;CdkDragDrop,&nbsp;moveItemInArray&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/cdk/drag-drop'</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="text-indent:10.5pt">Then we add the drop event method inside our app component class for adding the selected item array to the selected current index.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">drop(event:&nbsp;CdkDragDrop&lt;string[]&gt;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;moveItemInArray(<span class="js__operator">this</span>.decrementValue,&nbsp;event.previousIndex,&nbsp;event.currentIndex);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="text-indent:10.5pt">The complete code will be look like this.</span></div>
<div class="endscriptcode"><span style="text-indent:10.5pt"><img id="218968" src="218968-25.png" alt="" width="633" height="502"><br>
</span></div>
<h4 class="MsoNormal" style="text-indent:10.5pt"><strong>Adding the CSS</strong></h4>
<p>For our List Drag Drop we will be adding the below CSS to design our list .Add the below CSS code to your app.component.css file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">.divClasslist&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;width:&nbsp;200px;&nbsp;
&nbsp;&nbsp;border:&nbsp;solid&nbsp;1px&nbsp;#<span class="js__num">234365</span>;&nbsp;
&nbsp;&nbsp;min-height:&nbsp;60px;&nbsp;
&nbsp;&nbsp;display:&nbsp;block;&nbsp;
&nbsp;&nbsp;background:&nbsp;#cc4871;&nbsp;
&nbsp;&nbsp;border-radius:&nbsp;12px;&nbsp;
&nbsp;&nbsp;margin-bottom:&nbsp;12px;&nbsp;
&nbsp;&nbsp;overflow:&nbsp;hidden;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
.divClass&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;padding:&nbsp;20px&nbsp;10px;&nbsp;
&nbsp;&nbsp;border-bottom:&nbsp;solid&nbsp;1px&nbsp;#ccc;&nbsp;
&nbsp;&nbsp;color:&nbsp;rgba(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0.87</span>);&nbsp;
&nbsp;&nbsp;display:&nbsp;flex;&nbsp;
&nbsp;&nbsp;flex-direction:&nbsp;row;&nbsp;
&nbsp;&nbsp;align-items:&nbsp;center;&nbsp;
&nbsp;&nbsp;justify-content:&nbsp;space-between;&nbsp;
&nbsp;&nbsp;box-sizing:&nbsp;border-box;&nbsp;
&nbsp;&nbsp;cursor:&nbsp;move;&nbsp;
&nbsp;&nbsp;background:&nbsp;#f8d8f2;&nbsp;
&nbsp;&nbsp;font-size:&nbsp;14px;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;.divClass:active&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;background-color:&nbsp;#cc4871;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h4 class="endscriptcode">&nbsp;<strong>Design your HTML page to display the List with CDK Virtual Scrolling</strong></h4>
<p>Now it&rsquo;s time to design our html page to add the Drag and Drop function to the List &nbsp;. Open app.component.html and add the below code to display the item in list with Drag and Drop features added.</p>
<p class="MsoNormal">Here we create the cdkDropList div element with Drop event using cdkDropListDropped.We add one more div elevement inside the cdkDroplist for adding the item with cdkDrag features for dragging the item inside the selected div element.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;h2&gt;Angular&nbsp;<span class="js__num">7</span>&nbsp;Drag&nbsp;and&nbsp;Drop&nbsp;&lt;/h2&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;div&nbsp;cdkDropList&nbsp;class=<span class="js__string">&quot;divClasslist&quot;</span>&nbsp;(cdkDropListDropped)=<span class="js__string">&quot;drop($event)&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;divClass&quot;</span>&nbsp;&nbsp;*ngFor=<span class="js__string">&quot;let&nbsp;decValue&nbsp;of&nbsp;decrementValue&quot;</span>&nbsp;cdkDrag&gt;<span class="js__brace">{</span><span class="js__brace">{</span>decValue<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/div&gt;&nbsp;
&lt;/div&gt;&nbsp;
</pre>
</div>
</div>
</div>
<h3 class="endscriptcode">&nbsp;<strong>Run the Application</strong></h3>
<p>&nbsp;</p>
<p class="MsoNormal"><strong>&nbsp;</strong></p>
<p class="MsoNormal"><img id="218969" src="218969-26.gif" alt="" width="448" height="732"></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><em>ASPNETCoreAngular7.zip - 2019-01-15.</em></em> </li></ul>
<h1>More Information</h1>
<p class="MsoNormal" style="margin:12pt 0cm; line-height:normal"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">hope you liked this article. In our next post, we will see in detail on how to perform CRUD operation using Angular
 7 and Asp.NET Core with and Web API.</span></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:545.455px; width:1px; height:1px; overflow:hidden">
<p class="MsoNormal" style="margin-top:12.0pt; margin-right:0cm; margin-bottom:12.0pt; margin-left:0cm; line-height:normal; background:white">
<strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121">Prerequisites<br>
</span></strong><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#212121"><br>
Make sure you have installed all the prerequisites in your computer. If not, then download and install all, one by one.</span></p>
<ol type="1">
<li class="MsoNormal" style="color:#212121; line-height:normal; background:white">
<span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">First, download and install Visual Studio 2017 from this&nbsp;</span><span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="https://www.visualstudio.com/" target="_blank"><span style="color:#1e88e5">link</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">.</span>
</li><li class="MsoNormal" style="color:#212121; line-height:normal; background:white">
<span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="https://www.microsoft.com/net/core#windowscmd" target="_blank"><span style="color:#1e88e5">Download</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">&nbsp;and
 install .NET Core 2.0 or above version.</span> </li><li class="MsoNormal" style="color:#212121; line-height:normal; background:white">
<span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">Download and install Node.js latest version from this download&nbsp;</span><span style="text-decoration:underline"><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif; color:#1e88e5"><a href="https://nodejs.org/en/" target="_blank"><span style="color:#1e88e5">link</span></a></span></span><span style="font-size:10.5pt; font-family:&quot;Arial&quot;,sans-serif">.</span>
</li></ol>
</div>
