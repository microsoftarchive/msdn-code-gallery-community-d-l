# How to excecute a c# Method (Code-Behind) with JavaScript
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- ASP.NET
- Javascript
- C# Language
## Topics
- ASP.NET
- Javascript
- Code-behind
- front end
## Updated
- 09/06/2013
## Description

<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>To run a method in c # from javascript code we are going to<br>
use the function provided by ASP.NET: __ doPostBack ().<br>
This function takes two arguments:<br>
<br>
1) EventTarget<br>
<br>
2) eventArgument<br>
<br>
<br>
1) EventTarget: contains the identifier of the control that makes the postback<br>
<br>
2) eventArgument: contains any additional data associated with the control.<br>
<br>
syntax: __doPostBack (EventTarget, eventArgument)<br>
<br>
Example:<br>
<br>
We create a button HTML, and ASP.NET Button control in ASP.NET code<br>
<br>
&nbsp; &lt;a id=&quot;Boton1&quot; href=&quot;javascript:__doPostBack('Button2_Click','')&quot;&gt; LinkButton &lt;/ a&gt;<br>
<br>
&lt;asp:Button runat=&quot;server&quot; Text=&quot;Button&quot; onclick=&quot;Button2_Click&quot; ID=&quot;Button2&quot;&nbsp; /&gt;</p>
<p>Both codes achieve the same effect, call the method: Button2_Click. One is from javascript and the other is from asp.net<br>
<br>
this button will call the javascript function __ doPostBack (). Then in the c# code we going to write<br>
&nbsp; the following code in the Page_Load event:<br>
<br>
&nbsp; ClientScript.GetPostBackEventReference (this, string.Empty) ;/ / This is important to make the method &quot;__doPostBack ()&quot; work properly<br>
if (Request.Form [&quot;__EVENTTARGET&quot;] == &quot;Button2_Click&quot;)<br>
{<br>
&nbsp;&nbsp;&nbsp;&nbsp; / / call the method we want to execute, in this case the onclick event of the button Button2<br>
&nbsp;&nbsp;&nbsp;&nbsp; Button2_Click (this, new EventArgs ());<br>
}<br>
<br>
In this case we call the method button2 onclick event, but we could any<br>
method we want.<br>
<em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace js_codebehind
{
    public partial class Dafault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);//This is important to make 
the &quot;__doPostBack()&quot; method, works properly

            if (Request.Form[&quot;__EVENTTARGET&quot;] == &quot;Button2_Click&quot;)
            {
                //call the method
                Button2_Click(this, new EventArgs());
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = &quot;Method called!!!&quot;;
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.UI;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.UI.WebControls;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;js_codebehind&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Dafault&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientScript.GetPostBackEventReference(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">string</span>.Empty);<span class="cs__com">//This&nbsp;is&nbsp;important&nbsp;to&nbsp;make&nbsp;</span>&nbsp;
the&nbsp;<span class="cs__string">&quot;__doPostBack()&quot;</span>&nbsp;method,&nbsp;works&nbsp;properly&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Request.Form[<span class="cs__string">&quot;__EVENTTARGET&quot;</span>]&nbsp;==&nbsp;<span class="cs__string">&quot;Button2_Click&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//call&nbsp;the&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Button2_Click(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;EventArgs());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Button2_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Method&nbsp;called!!!&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>default.aspx</em> </li><li><em><em>default.aspx.cs</em></em> </li></ul>
<p>&nbsp;</p>
