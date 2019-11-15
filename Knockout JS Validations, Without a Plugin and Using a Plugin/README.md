# Knockout JS Validations, Without a Plugin and Using a Plugin
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- knockout.js
- HTML5/JavaScript
- jQuery Unobtrusive Validation
## Topics
- HTML5/JavaScript
- knockout
- ViewModel pattern (MVVM) Knockout
- Validations in Knockout
- Knockout JS Plugin
## Updated
- 03/03/2017
## Description

<p>Here we are going to see how we can implement some basic validations using&nbsp;<a href="http://sibeeshpassion.com/category/client-side-technologies/knockout-js/" target="_blank">Knockout JS</a>. As we mentioned in the headline, we are going to create validation
 demo in two manner.</p>
<li>Without using any plugin, our own custom way </li><li>With using an existing plugin, easy way
<p>If you are totally new to Knockout JS, I stringly recommend you to read my previous post&nbsp;<a href="http://sibeeshpassion.com/mvc-crud-actions-using-knockout-js/" target="_blank">here</a>, where I have shared some basics of Knockout JS. We will be using&nbsp;<a href="http://sibeeshpassion.com/category/Visual-Studio/" target="_blank">Visual
 Studio</a>&nbsp;for our development. I hope you will like this. Now let&rsquo;s begin.</p>
<p><strong>Background</strong></p>
<p>As I have been working in a project where we use Knockout JS, it was my duty to do some validation for an existing page. This article shows the ways I have tried to implement the same. Like I said above, using a plugin and without using a plugin. Now let&rsquo;s
 go and implement the same in your application too. Shall we?</p>
<p><strong>Create a HTML page</strong></p>
<p>To work with Knockout JS, we need a page right. Let&rsquo;s create it first. Before we do that, please do not forget to install Knockout JS and jQuery from NuGet.</p>
<div class="wp-caption x_alignnone" id="attachment_12074"><a href="http://sibeeshpassion.com/wp-content/uploads/2017/03/Installing_KnockOut_JS_from_NuGet.png"><img class="size-large x_wp-image-12074" src="http://sibeeshpassion.com/wp-content/uploads/2017/03/Installing_KnockOut_JS_from_NuGet-1024x537.png" alt="Installing_KnockOut_JS_from_NuGet" width="634" height="332"></a>
<p class="wp-caption-text">Installing_KnockOut_JS_from_NuGet</p>
</div>
<div></div>
<p><strong>Let&rsquo;s begin our tutorial &ndash; Knockout JS validation without using a plugin</strong></p>
<p>Open your JS file (Validations-Without-Plugin.js), this is where we are going to write our scripts. As a first step, we need to create our view model and bind it using&nbsp;<em>applyBindings&nbsp;</em>function. Am I right?</p>
<p>So far everything is good, now it is time to update our view model and create some extenders.</p>
<blockquote>
<p>Knockout JS extenders are the easy way to give some additional functionalities to your observables. It can be anything, in this case we are going to create some validations for our observables or our controls.</p>
</blockquote>
<p>We can create the extenders and update the view as preceding.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_234751">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ko.extenders.isRequired&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(elm,&nbsp;customMessage)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//add&nbsp;some&nbsp;sub-observables&nbsp;to&nbsp;our&nbsp;observable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.hasError&nbsp;=&nbsp;ko.observable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.message&nbsp;=&nbsp;ko.observable();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//This&nbsp;is&nbsp;the&nbsp;function&nbsp;to&nbsp;validate&nbsp;the&nbsp;value&nbsp;entered&nbsp;in&nbsp;the&nbsp;text&nbsp;boxes</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;validateValueEntered(valEntered)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.hasError(valEntered&nbsp;?&nbsp;false&nbsp;:&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//If&nbsp;the&nbsp;custom&nbsp;message&nbsp;is&nbsp;not&nbsp;given,&nbsp;the&nbsp;default&nbsp;one&nbsp;is&nbsp;taken</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.message(valEntered&nbsp;?&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;:&nbsp;customMessage&nbsp;||&nbsp;<span class="js__string">&quot;I&nbsp;am&nbsp;required&nbsp;&lt;img&nbsp;draggable=&quot;</span>false<span class="js__string">&quot;&nbsp;class=&quot;</span>emoji<span class="js__string">&quot;&nbsp;alt=&quot;</span><span class="js__string">&quot;&nbsp;src=&quot;</span>https:<span class="js__sl_comment">//s.w.org/images/core/emoji/2.2.1/svg/1f641.svg&quot;&gt;&nbsp;&quot;);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Call&nbsp;the&nbsp;validation&nbsp;function&nbsp;for&nbsp;the&nbsp;initial&nbsp;validation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validateValueEntered(elm());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Validate&nbsp;the&nbsp;value&nbsp;whenever&nbsp;there&nbsp;is&nbsp;a&nbsp;change&nbsp;in&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.subscribe(validateValueEntered);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;elm;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ko.extenders.isEmail&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(elm,&nbsp;customMessage)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//add&nbsp;some&nbsp;sub-observables&nbsp;to&nbsp;our&nbsp;observable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.hasError&nbsp;=&nbsp;ko.observable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.message&nbsp;=&nbsp;ko.observable();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//This&nbsp;is&nbsp;the&nbsp;function&nbsp;to&nbsp;validate&nbsp;the&nbsp;value&nbsp;entered&nbsp;in&nbsp;the&nbsp;text&nbsp;boxes</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;validateEmail(valEntered)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;emailPattern&nbsp;=&nbsp;<span class="js__reg_exp">/^(([^&lt;&gt;()\[\]\\.,;:\s@&quot;]&#43;(\.[^&lt;&gt;()\[\]\\.,;:\s@&quot;]&#43;)*)|(&quot;.&#43;&quot;))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]&#43;\.)&#43;[a-zA-Z]{2,}))$/</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//If&nbsp;the&nbsp;value&nbsp;entered&nbsp;is&nbsp;a&nbsp;valid&nbsp;mail&nbsp;id,&nbsp;return&nbsp;fals&nbsp;or&nbsp;return&nbsp;true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.hasError((emailPattern.test(valEntered)&nbsp;===&nbsp;false)&nbsp;?&nbsp;true&nbsp;:&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//If&nbsp;not&nbsp;a&nbsp;valid&nbsp;mail&nbsp;id,&nbsp;return&nbsp;custom&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.message((emailPattern.test(valEntered)&nbsp;===&nbsp;true)&nbsp;?&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;:&nbsp;customMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Call&nbsp;the&nbsp;validation&nbsp;function&nbsp;for&nbsp;the&nbsp;initial&nbsp;validation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validateEmail(elm());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Validate&nbsp;the&nbsp;value&nbsp;whenever&nbsp;there&nbsp;is&nbsp;a&nbsp;change&nbsp;in&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elm.subscribe(validateEmail);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;elm;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;myViewModel(firstName,&nbsp;lastName,&nbsp;email)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.txtFirstName&nbsp;=&nbsp;ko.observable(firstName).extend(<span class="js__brace">{</span>&nbsp;isRequired:&nbsp;<span class="js__string">&quot;You&nbsp;missed&nbsp;First&nbsp;Name&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.txtLastName&nbsp;=&nbsp;ko.observable(lastName).extend(<span class="js__brace">{</span>&nbsp;isRequired:&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.txtEmail&nbsp;=&nbsp;ko.observable(email).extend(<span class="js__brace">{</span>&nbsp;isEmail:&nbsp;<span class="js__string">&quot;Not&nbsp;a&nbsp;valid&nbsp;mail&nbsp;id&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ko.applyBindings(<span class="js__operator">new</span>&nbsp;myViewModel(<span class="js__string">&quot;Sibeesh&quot;</span>,&nbsp;<span class="js__string">&quot;Venu&quot;</span>,&nbsp;<span class="js__string">&quot;sibikv4u@gmail.com&quot;</span>));&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Here&nbsp;<em>.extend({ isRequired: &ldquo;You missed First Name&rdquo; });</em>&nbsp;is used for calling the extenders we are just created. The first parameter is the extender name you are creating, and the second one is just a custom message. I had explained
 the codes with comments, if you get any issues or doubt, please feel free to ask your queries. Now it is time to update our view.</div>
</div>
<div>
<div class="syntaxhighlighter xml" id="highlighter_120362">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;KnockOut&nbsp;JS&nbsp;Validations&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/jquery-3.1.1.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/knockout-3.4.1.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/Validations-Without-Plugin.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<style> 
        .error <span class="js__brace">{</span> 
            color: #D8000C; 
            background-color: #FFBABA; 
            font-family: cursive; 
        <span class="js__brace">}</span> 
        table <span class="js__brace">{</span> 
            border: 1px solid #c71585; 
            padding: 20px; 
        <span class="js__brace">}</span> 
        td <span class="js__brace">{</span> 
            border: 1px solid #ccc; 
            padding: 20px; 
        <span class="js__brace">}</span> 
    </style>&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;caption&gt;Knockout&nbsp;JS&nbsp;Validation&lt;/caption&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;First&nbsp;Name:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;txtFirstName&quot;</span>&nbsp;name=<span class="js__string">&quot;txtFirstName&quot;</span>&nbsp;data-bind=<span class="js__string">'value:&nbsp;txtFirstName,&nbsp;valueUpdate:&nbsp;&quot;afterkeydown&quot;'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;error&quot;</span>&nbsp;data-bind=<span class="js__string">'visible:&nbsp;txtFirstName.hasError,&nbsp;text:&nbsp;txtFirstName.message'</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Last&nbsp;Name:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;txtLastName&quot;</span>&nbsp;name=<span class="js__string">&quot;txtLastName&quot;</span>&nbsp;data-bind=<span class="js__string">'value:&nbsp;txtLastName,&nbsp;valueUpdate:&nbsp;&quot;afterkeydown&quot;'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;error&quot;</span>&nbsp;data-bind=<span class="js__string">'visible:&nbsp;txtLastName.hasError,&nbsp;text:&nbsp;txtLastName.message'</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;txtEmail&quot;</span>&nbsp;name=<span class="js__string">&quot;txtEmail&quot;</span>&nbsp;data-bind=<span class="js__string">'value:&nbsp;txtEmail,&nbsp;valueUpdate:&nbsp;&quot;afterkeydown&quot;'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;error&quot;</span>&nbsp;data-bind=<span class="js__string">'visible:&nbsp;txtEmail.hasError,&nbsp;text:&nbsp;txtEmail.message'</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;value=<span class="js__string">&quot;Submit&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Every observables will be having their own hasError and message properties. And have you noticed that we are usig&nbsp;<em>valueUpdate: &ldquo;afterkeydown&rdquo;</em>&nbsp;in each data-bind event of our control. This is for initiating validation. Now let&rsquo;s
 run our application and see whether it is working fine or not.</div>
</div>
<div class="wp-caption x_alignnone" id="attachment_12075"><a href="http://sibeeshpassion.com/wp-content/uploads/2017/03/Knockout-JS-validation-without-a-plugin-demo.gif"><img class="size-full x_wp-image-12075" src="http://sibeeshpassion.com/wp-content/uploads/2017/03/Knockout-JS-validation-without-a-plugin-demo.gif" alt="Knockout JS validation without a plugin demo" width="680" height="494"></a>
<p class="wp-caption-text">Knockout JS validation without a plugin demo</p>
</div>
<p><strong>Knockout JS validation using a plugin &ndash; easy way</strong></p>
<p>As we are going to use a plugn, we need to install it from the NuGet first. You can always get the plugin from&nbsp;<a href="https://github.com/Knockout-Contrib/Knockout-Validation" target="_blank">here</a></p>
<div class="wp-caption x_alignnone" id="attachment_12076"><a href="http://sibeeshpassion.com/wp-content/uploads/2017/03/Knockout_Validation_JS_from_NuGet.png"><img class="size-large x_wp-image-12076" src="http://sibeeshpassion.com/wp-content/uploads/2017/03/Knockout_Validation_JS_from_NuGet-1024x514.png" alt="Knockout_Validation_JS_from_NuGet" width="634" height="318"></a>
<p class="wp-caption-text">Knockout_Validation_JS_from_NuGet</p>
</div>
<p>Can we create our view model now?</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_965485">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;myViewModel(firstName,&nbsp;lastName,&nbsp;email)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.txtFirstName&nbsp;=&nbsp;ko.observable(firstName).extend(<span class="js__brace">{</span>&nbsp;required:&nbsp;true&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.txtLastName&nbsp;=&nbsp;ko.observable(lastName).extend(<span class="js__brace">{</span>&nbsp;required:&nbsp;false&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.txtEmail&nbsp;=&nbsp;ko.observable(email).extend(<span class="js__brace">{</span>&nbsp;email:&nbsp;true&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ko.applyBindings(<span class="js__operator">new</span>&nbsp;myViewModel(<span class="js__string">&quot;Sibeesh&quot;</span>,&nbsp;<span class="js__string">&quot;Venu&quot;</span>,&nbsp;<span class="js__string">&quot;sibikv4u@gmail.com&quot;</span>));&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
You can see that, there is only few lines of codes when it compared to the old one we created. Now we can create our view.</div>
</div>
<div>
<div class="syntaxhighlighter xml" id="highlighter_816710">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;KnockOut&nbsp;JS&nbsp;Validations&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/jquery-3.1.1.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/knockout-3.4.1.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/knockout.validation.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/Validations-Plugin.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<style> 
        table <span class="js__brace">{</span> 
            border: 1px solid #c71585; 
            padding: 20px; 
        <span class="js__brace">}</span> 
        td <span class="js__brace">{</span> 
            border: 1px solid #ccc; 
            padding: 20px; 
        <span class="js__brace">}</span> 
    </style>&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;caption&gt;Knockout&nbsp;JS&nbsp;Validation&lt;/caption&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;First&nbsp;Name:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;txtFirstName&quot;</span>&nbsp;name=<span class="js__string">&quot;txtFirstName&quot;</span>&nbsp;data-bind=<span class="js__string">'value:&nbsp;txtFirstName'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Last&nbsp;Name:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;txtLastName&quot;</span>&nbsp;name=<span class="js__string">&quot;txtLastName&quot;</span>&nbsp;data-bind=<span class="js__string">'value:&nbsp;txtLastName'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;txtEmail&quot;</span>&nbsp;name=<span class="js__string">&quot;txtEmail&quot;</span>&nbsp;data-bind=<span class="js__string">'value:&nbsp;txtEmail'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;value=<span class="js__string">&quot;Submit&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p>Please don&rsquo;t forget to include the&nbsp;<em>knockout.validation.js</em>&nbsp;in your page. If everything is ready, run your application and see the output.</p>
<div class="wp-caption x_alignnone" id="attachment_12077"><a href="http://sibeeshpassion.com/wp-content/uploads/2017/03/Knockout-JS-validation-with-plugin-demo.gif"><img class="size-full x_wp-image-12077" src="http://sibeeshpassion.com/wp-content/uploads/2017/03/Knockout-JS-validation-with-plugin-demo.gif" alt="Knockout JS validation with plugin demo" width="646" height="483"></a>
<p class="wp-caption-text">Knockout JS validation with plugin demo</p>
</div>
<p>That&rsquo;s all for today. You can always download the source code attached to see the complete code and application. Happy coding!.</p>
</li>