# Leer valores enviados por los metodos Get y Post, guardarlos en un archivo de te
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- File System
## Topics
- C#
## Updated
- 06/11/2012
## Description

<h1>Description</h1>
<h3 class="post-title x_entry-title">Leer valores enviados por los metodos Get y Post, guardarlos en un archivo de texto, configurado en el web.config</h3>
<p><em><br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Web.UI.aspx" target="_blank" title="Auto generated link to System.Web.UI">System.Web.UI</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Web.UI.WebControls.aspx" target="_blank" title="Auto generated link to System.Web.UI.WebControls">System.Web.UI.WebControls</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Configuration.aspx" target="_blank" title="Auto generated link to System.Configuration">System.Configuration</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;getPostGetMethods&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;_Default&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamWriter&nbsp;sw&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamWriter(ConfigurationManager.AppSettings[<span class="cs__string">&quot;path&quot;</span>],&nbsp;<span class="cs__keyword">true</span>);<span class="cs__com">//en&nbsp;esta&nbsp;linea&nbsp;tomamos&nbsp;el&nbsp;path&nbsp;donde&nbsp;queremos&nbsp;que&nbsp;se&nbsp;guarde&nbsp;el&nbsp;archivo&nbsp;*.txt,&nbsp;del&nbsp;web.config.&nbsp;El&nbsp;parametro&nbsp;true&nbsp;habilita&nbsp;el&nbsp;append</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Request.QueryString.Count&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)<span class="cs__com">//comprobamos&nbsp;que&nbsp;se&nbsp;hayan&nbsp;enviado&nbsp;variables&nbsp;por&nbsp;el&nbsp;metodo&nbsp;Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;vars&nbsp;sent&nbsp;&quot;</span>&nbsp;&#43;&nbsp;DateTime.Now&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Get&nbsp;Method&quot;</span>);<span class="cs__com">//poemos&nbsp;una&nbsp;cabecera&nbsp;para&nbsp;saber&nbsp;las&nbsp;variables&nbsp;enviadas,&nbsp;con&nbsp;fecha&nbsp;y&nbsp;hora</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;Request.QueryString.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;Index:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Request.QueryString.GetKey(i)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Values:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Request.QueryString[i]);<span class="cs__com">//escribimos&nbsp;todos&nbsp;los&nbsp;indices&nbsp;y&nbsp;valores&nbsp;de&nbsp;todas&nbsp;las&nbsp;variables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Request.Form.Count&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)<span class="cs__com">//lo&nbsp;mismo&nbsp;que&nbsp;lo&nbsp;anterior&nbsp;pero&nbsp;para&nbsp;el&nbsp;metodo&nbsp;post</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;vars&nbsp;sent&nbsp;&quot;</span>&nbsp;&#43;&nbsp;DateTime.Now&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Post&nbsp;Method&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;Request.Form.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;Index:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Request.Form.GetKey(i)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Values:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Request.Form[i]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.Close();<span class="cs__com">//cerramos&nbsp;el&nbsp;archivo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>*****************************************</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<p>&nbsp;</p>
