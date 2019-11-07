# Getting started with Angular5 and ASP.NET Core
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Angular
- ASP.NET Core
- Angular5
## Topics
- ASP.NET Core
- Angular5
## Updated
- 12/05/2017
## Description

<h1>Introduction</h1>
<p><em>We hope you all know that Angular 5 has been released. In this article, we will see how to start working with Angular 5 and ASP.NET Core using Angular5TemplateCore.</em></p>
<p><em><img id="182107" src="182107-7_1.png" alt="" width="550" height="180"><br>
</em></p>
<div><em>It&rsquo;s very simple and easy to develop an Angular 5 application for ASP.NET Core using the Angular5TemplateCore. Let's see this in detail.</em></div>
<p><span style="font-size:2em">Building the Sample</span></p>
<h2>Prerequisites</h2>
<p>&nbsp;Make sure you have installed all the prerequisites on your computer. If not, then download and install all, one by one.</p>
<ol>
<li>First, download and install Visual Studio 2017 from this&nbsp;<a href="https://www.visualstudio.com/" target="_blank">link</a>.
</li><li><a href="https://www.microsoft.com/net/download/windows" target="_blank">Download</a>&nbsp;and install .NET Core 2.0
</li><li>Download and install Node.js v9.0 or above. I have installed v9.1.0 (Download&nbsp;<a href="https://nodejs.org/en/" target="_blank">link</a>).
</li></ol>
<p><strong><span style="text-decoration:underline">Note</span></strong></p>
<div>Before starting the project, make sure that you have installed Visual Studio 2.0 and .NET Core version 2.0 or above on your computer. If not, kindly download and install from the above links.</div>
<h3><strong>Prerequisites Installation part</strong></h3>
<p><strong>Install Nod.js</strong></p>
<p>Install the Node.js version 9.0 or above on your computer.</p>
<p><img id="182108" src="182108-1.png" alt="" width="550" height="320"></p>
<p><span lang="EN-US"><span style="color:#000000; font-family:&quot;맑은 고딕&quot;; font-size:x-small">After downloading Node.js install it on your computer.</span></span></p>
<p><img id="182109" src="182109-2.png" alt="" width="350" height="210"></p>
<h3><strong>Installing Angular5TemplateCore</strong></h3>
<p>Let&rsquo;s see how to install the Angular5TemplateCore to your Visual Studio .NET Core template.</p>
<p>Open Visual Studio 2017 and go to File -&gt;&nbsp; New project. Select Online from the left menu, then select Visual C#. From the list, search for Angular5TemplateCore and click OK.</p>
<p><img id="182110" src="182110-3.png" alt="" width="550" height="310"></p>
<p>Close your Visual Studio and wait until Angular5TemplateCore installs. After the installation is completed, it's time for building your first Angular 5 application using ASP.NET Core Template. We will see this in detail in the code part.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Now, it&rsquo;s time to create our first Angular 5 and ASP.NET Core application.</p>
<h2><strong>Step 1 Create&nbsp;</strong><strong>Angular5TemplateCore</strong></h2>
<p><strong>&nbsp;</strong>After installing all the prerequisites listed above and Angular5TemplateCore, click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2017 &gt;&gt; Visual Studio 2017, on your desktop.</p>
<p>Click New &gt;&gt; Project. Select Visual C# &gt;&gt; Select Angular5Core2. Enter your project name and click OK.</p>
<p><img id="182111" src="182111-4.png" alt="" width="450" height="210"></p>
<p>Once our project is created, we can see it in the Solution Explorer with Angular5 sample components, HTML, and app in the ClientApp folder, along with ASP.NET Core Controllers and View folder.</p>
<p><img id="182112" src="182112-5.png" alt="" width="233" height="314"></p>
<p>Here, these files and folders are very similar to our ASP.NET Core Template Pack for Angular 2.</p>
<h3><strong>Package.json File</strong></h3>
<p>If we open the package.json file, we can see all the dependencies needed for Angular 5 and the Angular CLI has already been added by default.</p>
<h3><strong>Adding Webpack in Package.json</strong></h3>
<div>In order to run our Angular 5 application, we need to install the&nbsp;webpack in our application. If the webpack is by default not added to our package.json file, then we need to add it manually. Webpack is an open-source JavaScript module bundler. It
 takes modules with dependencies and generates static assets representing those modules. To know more about Webpack,&nbsp;<a href="https://webpack.github.io/docs/what-is-webpack.html" target="_blank">click here</a>.</div>
<div>
<div>Open your package.json file and add the below line under scripts.</div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">&quot;postinstall&quot;: &quot;webpack --config webpack.config.vendor.js&quot;</pre>
<div class="preview">
<pre class="js"><span class="js__string">&quot;postinstall&quot;</span>:&nbsp;<span class="js__string">&quot;webpack&nbsp;--config&nbsp;webpack.config.vendor.js&quot;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>Build and run your project</strong></h2>
<div>Now, our Angular 5 and ASP.NET Core application are ready. We can run and see the output in the browser. First, build the application. After the build is created successfully, run the application.</div>
<p><img id="182113" src="182113-7.png" alt="" width="550" height="350"></p>
<p>When we run the Angular 5 ASP.NET Core application, we can see the default home page with left side menu and Counter and Fetch data. Yes, in Angular5Core2Template, when we create a&nbsp;new project, by default, 3 components and an HTML file are added to
 Angular 5 demo - Home, Counter, and Fetch data.</p>
<p><img id="182116" src="182116-7_0.png" alt="" width="441" height="386"></p>
<div>In the component file, we can change the Angular 5 class to produce the output as per our need or we can add our own folder to display the output, with components and HTML files.</div>
<div>
<p><strong>Changing Home Component and HTML file</strong></p>
<p>Now, let&rsquo;s try to change the home component class and HTML file to display the output with our name on the homepage.</p>
<p>For this, first, we edit the&nbsp;<a href="http://home.components.ts/" target="_blank">home.components.ts</a>&nbsp;file. Here, in Home Component class, We have created a public variable to display my name as &ldquo;myname&rdquo;.</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">import { Component } from &lt;a href=&quot;mailto:'@angular/core'&quot;&gt;'@angular/core'&lt;/a&gt;;

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public myname = &quot;Shanu&quot;;
}</pre>
<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;Component&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;&lt;a&nbsp;href=<span class="js__string">&quot;mailto:'@angular/core'&quot;</span>&gt;<span class="js__string">'@angular/core'</span>&lt;/a&gt;;&nbsp;
&nbsp;
@Component(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selector:&nbsp;<span class="js__string">'home'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;templateUrl:&nbsp;<span class="js__string">'./home.component.html'</span>&nbsp;
<span class="js__brace">}</span>)&nbsp;
export&nbsp;class&nbsp;HomeComponent&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;myname&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="color:#000000">In home.html file we have changed the html design to bind and display the Angular5 component variable.</span></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">&lt;h1&gt;
    Welcome to &lt;strong&gt;{{ myname }}&lt;/strong&gt; Angular5 and ASP.NET Core world
&lt;/h1&gt;</pre>
<div class="preview">
<pre class="js">&lt;h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Welcome&nbsp;to&nbsp;&lt;strong&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;myname&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/strong&gt;&nbsp;Angular5&nbsp;and&nbsp;ASP.NET&nbsp;Core&nbsp;world&nbsp;
&lt;/h1&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:&quot;맑은 고딕&quot;; font-size:x-small">Refresh the home page we can see my name will be displayed in html page from Angular5 Component along with welcome message.</span></div>
<p>&nbsp;</p>
<p><em><img id="182107" src="182107-7_1.png" alt="" width="550" height="180"></em></p>
<p><span lang="EN-US"><span style="color:#000000; font-family:&quot;맑은 고딕&quot;; font-size:x-small">Same like this we can also found default Counter and Fetch data from API sample component and html file has been added by default if we want we can change that to our
 requirement or we can create our own component and html files.</span></span></p>
<p><img id="182117" src="182117-11.png" alt="" width="550" height="220"></p>
<div>
<p><strong>Left Menu</strong></p>
</div>
<div>In the application, we can see the menu on the left side. The menu has been displayed using the navmenu.component.ts and navmenu.components.html. If you want to remove or add a menu, we can change the HTML and Angular 5 TypeScript file.</div>
<p><img id="182118" src="182118-12.png" alt="" width="299" height="351"></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Angular5Core2.zip - Version 1.0 </li></ul>
<h1>More Information</h1>
<p><em>If you have already worked with ASP.NET Core Template pack for Angular 2, then this will be more simple and easy for you to work with Angular 5 because it follows the similar steps. Angular 5 is mostly similar to Angular 4 with same features but with
 some advanced level. In our next article, we will see in a deeper manner and in detail with some real-time example to working with Angular 5 and ASP.NET Core.</em></p>
