# Google reCAPTCHA in ASP.NET MVC 5
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- ASP.NET MVC 5
## Topics
- Google reCAPTCHA
## Updated
- 05/26/2016
## Description

<h1>Introduction</h1>
<p>Here, I will explain about how to use Google reCAPTCHA in ASP.NET MVC. What is reCAPTCHA?</p>
<p>reCAPTCHA protects the websites you love from spam and abuse. Google has updated their reCAPTCHA API to 2.0 . Now, users can attest they are human without having to solve a CAPTCHA. Instead with just a single click, they&rsquo;ll confirm they are not a robot
 and it is called as &ldquo;<strong>No CAPTCHA reCAPTCHA</strong>&ldquo;. This is how new reCAPTCHA looks:</p>
<p><img id="153323" src="153323-recaptcha1.png" alt="" width="435" height="118"></p>
<p><span style="font-size:2em">Building the Sample</span></p>
<p>Now let's create an API key pair for your site at&nbsp;<a title="https://www.google.com/recaptcha/intro/index.html" href="https://www.google.com/recaptcha/intro/index.html" target="_blank">https://www.google.com/recaptcha/intro/index.html</a>&nbsp;and click
 on&nbsp;<strong>Get reCAPTCHA</strong>&nbsp;at the top of the page and follow the below steps to create an application.</p>
<p><img id="153324" src="153324-capture.png" alt="" width="657" height="394"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Once you are done with registration, the following keys will be generated:</p>
<p><a href="http://venkatbaggu.com/wp-content/uploads/2014/12/reCAPTCHA-keys.png"><img class="wp-image-466" src="-recaptcha-keys-1024x166.png" alt="reCAPTCHA  keys"></a></p>
<div class="Caption">reCAPTCHA keys</div>
<p><strong>Site key</strong>: is used to display the widget in your page or code.</p>
<p><strong>Secret key</strong>: can be used as communication between your site and Google to verify the user response whether the reCAPTCHA is valid or not.</p>
<p>Now the next is display the reCAPTCHA widget in your site.</p>
<h2 class="subhead"><span>Step-1: Create a Controller.</span></h2>
<p><span>Go to Solution Explorer &gt; Right Click on Controllers folder form Solution Explorer &gt; Add &gt; Controller &gt; Enter Controller name &gt; Select Templete &quot;empty MVC Controller&quot;&gt; Add.</span><br>
<br>
<span>Here I have created a controller &quot;HomeController&quot;</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifier&nbsp;le&nbsp;script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Recaptcha.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormSubmit()
        {
           
            var response = Request[&quot;g-recaptcha-response&quot;];
            string secretKey = &quot;your secret key here&quot;;
            var client = new WebClient();
            var result = client.DownloadString(string.Format(&quot;https://www.google.com/recaptcha/api/siteverify?secret={0}&amp;response={1}&quot;, secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken(&quot;success&quot;);
            ViewBag.Message = status ? &quot;Google reCaptcha validation success&quot; : &quot;Google reCaptcha validation failed&quot;;

            return View(&quot;Index&quot;);
        }

    }
}
******************************************
Step-2: Add view for the action (here &quot;Index&quot;) &amp; design.
******************************************
@{
    ViewBag.Title = &quot;Index&quot;;
}
&lt;h2&gt;Index&lt;/h2&gt;
&lt;div&gt;
    @using (Html.BeginForm(&quot;FormSubmit&quot;, &quot;Home&quot;, FormMethod.Post))
    {
    &lt;div class=&quot;g-recaptcha&quot; data-sitekey=&quot;6Lf9_CATAAAAAFwQl6G-_e3Onx_ZrTkNHJ-mBgvS&quot;&gt;&lt;/div&gt;
        &lt;input type=&quot;submit&quot; value=&quot;Submit&quot; /&gt;
    }
&lt;/div&gt;
&lt;span style=&quot;display:inline-block; font-size:20px;margin:20px 0;padding:20px;border:1px solid #D3D3D3&quot;&gt;
    @ViewBag.Message
&lt;/span&gt;
&lt;script src='https://www.google.com/recaptcha/api.js' type=&quot;text/javascript&quot;&gt;&lt;/script&gt;

</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Mvc;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json.Linq;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Recaptcha.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;FormSubmit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;Request[<span class="cs__string">&quot;g-recaptcha-response&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;secretKey&nbsp;=&nbsp;<span class="cs__string">&quot;your&nbsp;secret&nbsp;key&nbsp;here&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;client.DownloadString(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;https://www.google.com/recaptcha/api/siteverify?secret={0}&amp;response={1}&quot;</span>,&nbsp;secretKey,&nbsp;response));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;obj&nbsp;=&nbsp;JObject.Parse(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;status&nbsp;=&nbsp;(<span class="cs__keyword">bool</span>)obj.SelectToken(<span class="cs__string">&quot;success&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Message&nbsp;=&nbsp;status&nbsp;?&nbsp;<span class="cs__string">&quot;Google&nbsp;reCaptcha&nbsp;validation&nbsp;success&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;Google&nbsp;reCaptcha&nbsp;validation&nbsp;failed&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
******************************************&nbsp;
Step<span class="cs__number">-2</span>:&nbsp;Add&nbsp;view&nbsp;<span class="cs__keyword">for</span>&nbsp;the&nbsp;action&nbsp;(here&nbsp;<span class="cs__string">&quot;Index&quot;</span>)&nbsp;&amp;&nbsp;design.&nbsp;
******************************************&nbsp;
@{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="cs__string">&quot;Index&quot;</span>;&nbsp;
}&nbsp;
&lt;h2&gt;Index&lt;/h2&gt;&nbsp;
&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@<span class="cs__keyword">using</span>&nbsp;(Html.BeginForm(<span class="cs__string">&quot;FormSubmit&quot;</span>,&nbsp;<span class="cs__string">&quot;Home&quot;</span>,&nbsp;FormMethod.Post))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;g-recaptcha&quot;</span>&nbsp;data-sitekey=<span class="cs__string">&quot;6Lf9_CATAAAAAFwQl6G-_e3Onx_ZrTkNHJ-mBgvS&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="cs__string">&quot;submit&quot;</span>&nbsp;<span class="cs__keyword">value</span>=<span class="cs__string">&quot;Submit&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&lt;/div&gt;&nbsp;
&lt;span&nbsp;style=<span class="cs__string">&quot;display:inline-block;&nbsp;font-size:20px;margin:20px&nbsp;0;padding:20px;border:1px&nbsp;solid&nbsp;#D3D3D3&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@ViewBag.Message&nbsp;
&lt;/span&gt;&nbsp;
&lt;script&nbsp;src=<span class="cs__string">'https://www.google.com/recaptcha/api.js'</span>&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<h2 class="subhead"><span>Step3: Run Application (before run, make sure you have added your site key &amp; secret key)</span></h2>
<h1>Closing Notes</h1>
<p><em>I hope you enjoyed this article. I tried to make this as simple as I can. If you like this article, please rate it and share it to share the knowledge.</em></p>
<p><em><br>
</em></p>
