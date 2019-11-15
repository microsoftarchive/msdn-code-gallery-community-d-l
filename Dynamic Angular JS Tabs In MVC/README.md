# Dynamic Angular JS Tabs In MVC
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET MVC
- AngularJS
## Topics
- Development
## Updated
- 02/09/2016
## Description

<p><span style="font-size:medium">In this post we will see how we can create&nbsp;<a href="http://sibeeshpassion.com/category/angularjs/" target="_blank">Angular JS&nbsp;</a>dynamics tabs in&nbsp;<a href="http://sibeeshpassion.com/category/mvc/" target="_blank">MVC&nbsp;</a>application.
 As you all are aware of that we have a tab control in Angular JS, here we are going to see how those tabs can be created dynamically with some dynamic data, these dynamic data can be fetched from database. Here I am creating some dynamic data accordingly for
 making this article easy to understand. We will be creating Angular JS app, controller, service to fetch the data from our MVC controller. Once that is done, we will format the data and assign it to the tab control. Sounds good?. I hope you will like this
 article.</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><strong><span style="font-size:medium">Background</span></strong></p>
<p><span style="font-size:medium">Recently I have got a requirement to create a tab control in one of my Angular JS application. Then I thought of creating the same dynamically according to the user needs. This article is a demo of the same.</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><strong><span style="font-size:medium">Using the code</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<p><span style="font-size:medium">First, we will start with creating an MVC application. Open your visual studio, then click File-&gt;New-&gt;Project. Name your project.</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><span style="font-size:medium">Now our application is launched, please go ahead and install Angular JS in your project from NuGet packages. You can see some new CSS files and scripts has been added to our project. So the set up has been done. Now what we
 need to do is to move on the coding part.</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><strong><span style="font-size:medium">Create a controller</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<p><span style="font-size:medium">Now we can create a new controller, in my case I created a controller &lsquo;HomeController&rsquo;. In my controller I am going to call a model action which will return some dynamic data. See the code below.</span></p>
<p><span style="font-size:medium">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;/Home/</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;JsonResult&nbsp;TabData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Test&nbsp;t&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Test();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;myList&nbsp;=&nbsp;t.GetData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Json(myList,&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_51222">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
</div>
<div class="syntaxhighlighter csharp" id="highlighter_51222"><span style="font-size:medium">Here we have one ActionResult and one JsonResult which we are going to call as Angular JS service. As you can see I am creating an instance of my model Test, now
 we will create our model class. Shall we?</span></div>
<div class="syntaxhighlighter csharp"><span style="font-size:medium"><br>
</span></div>
</div>
<p><strong><span style="font-size:medium">Create Model</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<p><span style="font-size:medium">I have create a model class with the name Test. Here I am creating some data dynamically using a for loop and assign those values to a list. Please see the codes below.</span></p>
<p><span style="font-size:medium">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">namespace&nbsp;AsyncActions.Models&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Test&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;List&lt;Customer&gt;&nbsp;GetData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Customer&gt;&nbsp;cst&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;Customer&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="js__num">15</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customer&nbsp;c&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Customer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.CustomerID&nbsp;=&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.CustomerCode&nbsp;=&nbsp;<span class="js__string">&quot;CST&quot;</span>&nbsp;&#43;&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cst.Add(c);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;cst;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;<span class="js__operator">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;CustomerID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;CustomerCode&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span style="font-size:medium">As you can see I am creating a list of type Customer. Is that fine? Now what is pending? Yes, a view.</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><strong><span style="font-size:medium">Create a view</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<p><span style="font-size:medium">Right click on your controller and click add view, that will give you a new view in your view folder. Hope you get that.</span></p>
<p><span style="font-size:medium">So our view is ready, now we can do some codes in our view to populate our tab. Are you ready?</span></p>
<p><span style="font-size:medium">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">ng-controller</span>=<span class="html__attr_value">&quot;tabController&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;sample&nbsp;tabsdemoDynamicTabs&quot;</span>&nbsp;<span class="html__attr_name">layout</span>=<span class="html__attr_value">&quot;column&quot;</span>&nbsp;<span class="html__attr_name">ng-cloak</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__attr_name">ng-app</span>=<span class="html__attr_value">&quot;tab&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;md</span>-content&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;md-padding&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;md</span>-tabs&nbsp;<span class="html__attr_name">md-selected</span>=<span class="html__attr_value">&quot;selectedIndex&quot;</span>&nbsp;<span class="html__attr_name">md-border-bottom</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__attr_name">md-autoselect</span>=<span class="html__attr_value">&quot;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;md</span>-tab&nbsp;<span class="html__attr_name">ng-repeat</span>=<span class="html__attr_value">&quot;tab&nbsp;in&nbsp;tabs&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;tab.disabled&quot;</span>&nbsp;<span class="html__attr_name">label</span>=<span class="html__attr_value">&quot;{{tab.title}}&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;demo-tab&nbsp;tab{{$index}}&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;padding:&nbsp;25px;&nbsp;text-align:&nbsp;center;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">ng-bind</span>=<span class="html__attr_value">&quot;tab.content&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;md</span>-button&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;md-primary&nbsp;md-raised&quot;</span>&nbsp;<span class="html__attr_name">ng-click</span>=<span class="html__attr_value">&quot;removeTab(&nbsp;tab&nbsp;)&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;tabs.length&nbsp;&lt;=&nbsp;1&quot;</span><span class="html__tag_start">&gt;</span>Remove&nbsp;Tab&lt;/md-button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/md-tab&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/md-tabs&gt;&nbsp;
&nbsp;&nbsp;&lt;/md-content&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">ng-submit</span>=<span class="html__attr_value">&quot;addTab(tTitle,tContent)&quot;</span>&nbsp;<span class="html__attr_name">layout</span>=<span class="html__attr_value">&quot;column&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;md-padding&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;padding-top:&nbsp;0;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">layout</span>=<span class="html__attr_value">&quot;row&quot;</span>&nbsp;<span class="html__attr_name">layout-sm</span>=<span class="html__attr_value">&quot;column&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">flex</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;position:&nbsp;relative;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;md-subhead&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;position:&nbsp;absolute;&nbsp;bottom:&nbsp;0;&nbsp;left:&nbsp;0;&nbsp;margin:&nbsp;0;&nbsp;font-weight:&nbsp;500;&nbsp;text-transform:&nbsp;uppercase;&nbsp;line-height:&nbsp;35px;&nbsp;white-space:&nbsp;nowrap;&quot;</span><span class="html__tag_start">&gt;</span>Add&nbsp;a&nbsp;new&nbsp;Tab:<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;md</span>-input-container<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;label&quot;</span><span class="html__tag_start">&gt;</span>Label<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;label&quot;</span>&nbsp;<span class="html__attr_name">ng-model</span>=<span class="html__attr_value">&quot;tTitle&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/md-input-container&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;md</span>-input-container<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;content&quot;</span><span class="html__tag_start">&gt;</span>Content<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;content&quot;</span>&nbsp;<span class="html__attr_name">ng-model</span>=<span class="html__attr_value">&quot;tContent&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/md-input-container&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;md</span>-button&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;add-tab&nbsp;md-primary&nbsp;md-raised&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;!tTitle&nbsp;||&nbsp;!tContent&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;margin-right:&nbsp;0;&quot;</span><span class="html__tag_start">&gt;</span>Add&nbsp;Tab&lt;/md-button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_857315"><span style="font-size:medium">As you can see we are declaring our angular js controller and app name as follows.</span></div>
<div class="syntaxhighlighter xml"><span style="font-size:medium"><br>
</span></div>
</div>
<div>
<div class="syntaxhighlighter xml" id="highlighter_24625">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">ng-controller=<span class="js__string">&quot;tabController&quot;</span>&nbsp;class=<span class="js__string">&quot;sample&nbsp;tabsdemoDynamicTabs&quot;</span>&nbsp;layout=<span class="js__string">&quot;column&quot;</span>&nbsp;ng-cloak=<span class="js__string">&quot;&quot;</span>&nbsp;ng-app=<span class="js__string">&quot;tab&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:medium">Now we will add the needed reference to our view.</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><strong><span style="font-size:medium">Add the style sheet references</span></strong></p>
<p><strong><span style="font-size:medium">&nbsp;</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong><span>HTML</span></strong></div>
<div class="pluginLinkHolder"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></div>
<strong><span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;link&nbsp;href=<span class="js__string">&quot;~/CSS/angular-material.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&lt;link&nbsp;href=<span class="js__string">&quot;~/CSS/docs.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
</pre>
</div>
</strong></div>
</div>
<div class="endscriptcode"><strong>&nbsp;</strong></div>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_997916"><strong><span style="font-size:medium">Add styles for tabs</span></strong></div>
<div class="syntaxhighlighter xml"><strong><span style="font-size:medium"><br>
</span></strong></div>
</div>
<div>
<div class="syntaxhighlighter css" id="highlighter_294055">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">css</span>

<div class="preview">
<pre class="js"><style><!--mce:1--></style></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong><span style="font-size:medium">Add the JS references</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_328001">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/angular.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/angular-animate.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/angular-route.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/angular-aria.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/angular-messages.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/svg-assets-cache.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/angular-material.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/Module.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:medium">Here Module.js is the file where we are creating our A</span><span style="font-size:medium">ngular JS controller, Service, App. So can we go ahead and create those?</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><strong><span style="font-size:medium">Create an app, controller, service in Angular JS</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<p><span style="font-size:medium">To add an app, controller, servicer in Angular JS, you need to add the codes as below.</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_495553">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'use&nbsp;strict'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;app;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//create&nbsp;app</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app&nbsp;=&nbsp;angular.module(<span class="js__string">&quot;tab&quot;</span>,&nbsp;[<span class="js__string">'ngMaterial'</span>,&nbsp;<span class="js__string">'ngMessages'</span>,&nbsp;<span class="js__string">'material.svgAssetsCache'</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//create&nbsp;controller</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.controller(<span class="js__string">'tabController'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($scope,&nbsp;tabService)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;serv&nbsp;=&nbsp;tabService.getAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serv.then(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabController(d.data,&nbsp;$scope);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">'Something&nbsp;went&nbsp;wrong,&nbsp;please&nbsp;check&nbsp;after&nbsp;a&nbsp;while'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//create&nbsp;service</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.service(<span class="js__string">'tabService'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($http)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.getAll&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">&quot;/Home/TabData&quot;</span>,&nbsp;<span class="js__sl_comment">//Here&nbsp;we&nbsp;are&nbsp;calling&nbsp;our&nbsp;controller&nbsp;JSON&nbsp;action</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;method:&nbsp;<span class="js__string">&quot;GET&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)();&nbsp;
<span class="js__brace">}</span>)();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:medium">As you can see once we get the data from the Angular JS service (tabService) to the controller (tabController), we are passing the data to a function named tabController. Below is the code for that function.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;tabController(data,&nbsp;$scope)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tabsArray&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;data.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabsArray.push(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'title'</span>:<span class="js__string">&quot;Customer&nbsp;ID:&nbsp;&quot;</span>&#43;&nbsp;data[i].CustomerID,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'content'</span>:&nbsp;data[i].CustomerCode&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;The&nbsp;data&nbsp;you&nbsp;are&nbsp;seeing&nbsp;here&nbsp;is&nbsp;for&nbsp;the&nbsp;customer&nbsp;with&nbsp;the&nbsp;Custome&nbsp;rCode&nbsp;&quot;</span>&nbsp;&#43;&nbsp;data[i].CustomerCode&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tabs&nbsp;=&nbsp;tabsArray,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selected&nbsp;=&nbsp;null,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;previous&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.tabs&nbsp;=&nbsp;tabs;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.$watch(<span class="js__string">'selectedIndex'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(current,&nbsp;old)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;previous&nbsp;=&nbsp;selected;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selected&nbsp;=&nbsp;tabs[current];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.addTab&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(title,&nbsp;view)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;view&nbsp;=&nbsp;view&nbsp;||&nbsp;title&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;Content&nbsp;View&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabs.push(<span class="js__brace">{</span>&nbsp;title:&nbsp;title,&nbsp;content:&nbsp;view,&nbsp;disabled:&nbsp;false&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.removeTab&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(tab)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;index&nbsp;=&nbsp;tabs.indexOf(tab);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabs.splice(index,&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_700155">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:medium">That&rsquo;s all we have created the Angular JS tabs dynamically. Shall we see the output now?</span></p>
<p><span style="font-size:medium"><br>
</span></p>
<p><strong><span style="font-size:medium">Output</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_11215"><span style="font-size:medium"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/02/Dynamic-Angular-JS-Tabs-In-MVC-Figure-1.png"><img class="size-large x_x_x_wp-image-11215" src="http://sibeeshpassion.com/wp-content/uploads/2016/02/Dynamic-Angular-JS-Tabs-In-MVC-Figure-1-1024x232.png" alt="Dynamic Angular JS Tabs In MVC Figure 1" width="634" height="144"></a>
</span>
<p class="wp-caption-text"><span style="font-size:medium">Dynamic Angular JS Tabs In MVC Figure 1</span></p>
</div>
<div class="wp-caption x_x_x_alignnone" id="attachment_11216"><span style="font-size:medium"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/02/Dynamic-Angular-JS-Tabs-In-MVC-Figure-2.png"><img class="size-large x_x_x_wp-image-11216" src="http://sibeeshpassion.com/wp-content/uploads/2016/02/Dynamic-Angular-JS-Tabs-In-MVC-Figure-2-1024x249.png" alt="Dynamic Angular JS Tabs In MVC Figure 2" width="634" height="154"></a>
</span>
<p class="wp-caption-text"><span style="font-size:medium">Dynamic Angular JS Tabs In MVC Figure 2</span></p>
</div>
<p>&nbsp;</p>
<p><strong><span style="font-size:medium">References</span></strong></p>
<p><strong><span style="font-size:medium"><br>
</span></strong></p>
<p><span style="font-size:medium"><a href="https://material.angularjs.org/latest/demo/tabs" target="_blank">Angular JS Tabs</a></span></p>
