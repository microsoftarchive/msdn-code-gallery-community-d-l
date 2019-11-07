# Drag and Drop GridView Asp .Net con jquery
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- jQuery
- Javascript
- C# Language
- CSS3
## Topics
- ASP.NET
- jQuery
- Javascript
- Examples
## Updated
- 01/06/2015
## Description

<h1>Introduction</h1>
<p><em>Muchas veces necesitamos algo tan simple como arrastrar y soltar filas de un GridView a otro, como hacerlo es&nbsp;f&aacute;cil&nbsp;con la ayuda de jquery y un poco&nbsp;de javascript.</em></p>
<p><em>Con este peque&ntilde;o c&oacute;digo espero ayudar un poco en todos los proyectos que a diario requieren este tipo de soluciones, de igual manera puede darle un vistazo a otros fragmentos de c&oacute;digo como lo es un&nbsp;<a href="https://code.msdn.microsoft.com/Menu-JavaScript-Ajax-84a92d69">menu
 asincrono</a>&nbsp;o notificaciones utilizando&nbsp;<a href="https://code.msdn.microsoft.com/SiganIR-con-VB-Ejemplo-af9205e9">Signalr</a></em></p>
<p>&nbsp;</p>
<p><em><img id="132116" src="132116-drag%20and%20drop%20gridview.png" alt="" width="466" height="362" style="display:block; margin-left:auto; margin-right:auto"><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>La idea es arrastrar filas de un grid a otro, para ello necesitan crear un proyecto C# web en este caso vacio con cualquier versi&oacute;n express de visual studio, para descargarlo click&nbsp;<span style="color:#0000ee"><span style="text-decoration:underline">aqu&iacute;</span></span></em></p>
<p><em>Luego deben instalar el paquete nuget Jquer en sus Ultimas&nbsp;versiones&nbsp;preferiblemente&nbsp;versi&oacute;n&nbsp;2.x.x en adelante.</em></p>
<p><em>Para saber mas de este paquete puede ingresar&nbsp;<a href="https://www.nuget.org/packages/jquery">aqu&iacute;</a></em></p>
<p><em>Despu&eacute;s de crear el proyecto e instalar el paquete creamos un archivo .aspx en mi caso default. aspx con el siguiente contenido:</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>ASPX</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;%@ Page Language=&quot;C#&quot; AutoEventWireup=&quot;true&quot; CodeBehind=&quot;Default.aspx.cs&quot; Inherits=&quot;DragandDrop.Default&quot; %&gt; 
 
&lt;!DOCTYPE html&gt; 
 
&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt; 
&lt;head runat=&quot;server&quot;&gt; 
    &lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html; charset=utf-8&quot; /&gt; 
    &lt;title&gt;&lt;/title&gt; 
    &lt;link rel=&quot;stylesheet&quot; href=&quot;style.css&quot; /&gt; 
        &lt;script type=&quot;text/javascript&quot; src=&quot;Scripts/jquery-2.1.3.min.js&quot;&gt;&lt;/script&gt; 
        &lt;script type=&quot;text/javascript&quot; src=&quot;Scripts/jquery-ui-1.11.2.js&quot;&gt;&lt;/script&gt; 
 
&lt;/head&gt; 
&lt;body&gt; 
    &lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt; 
        &lt;div class=&quot;Table&quot;&gt; 
            &lt;div class=&quot;Title&quot;&gt; 
                &lt;p&gt;Drag and Drop Grid Asp&lt;/p&gt; 
            &lt;/div&gt; 
            &lt;div class=&quot;Heading&quot;&gt; 
                &lt;div class=&quot;Cell&quot;&gt; 
                    &lt;p&gt;Grid 1&lt;/p&gt; 
                &lt;/div&gt; 
                &lt;div class=&quot;Cell&quot;&gt; 
                    &lt;p&gt;Grid 2&lt;/p&gt; 
                &lt;/div&gt; 
            &lt;/div&gt; 
            &lt;div class=&quot;Row&quot;&gt; 
                &lt;div class=&quot;Cell&quot;&gt; 
                    &lt;asp:GridView ID=&quot;gvSource&quot; runat=&quot;server&quot; CssClass=&quot;drag_drop_grid GridSrc&quot; AutoGenerateColumns=&quot;false&quot;&gt; 
                        &lt;Columns&gt; 
                            &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; /&gt; 
                            &lt;asp:BoundField DataField=&quot;Value&quot; HeaderText=&quot;Value&quot; /&gt; 
                        &lt;/Columns&gt; 
                    &lt;/asp:GridView&gt; 
                &lt;/div&gt; 
                &lt;div class=&quot;Cell&quot;&gt; 
                    &lt;asp:GridView ID=&quot;gvDest&quot; runat=&quot;server&quot; CssClass=&quot;drag_drop_grid GridDest&quot; AutoGenerateColumns=&quot;false&quot;&gt; 
                        &lt;Columns&gt; 
                            &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; /&gt; 
                            &lt;asp:BoundField DataField=&quot;Value&quot; HeaderText=&quot;Value&quot; /&gt; 
                        &lt;/Columns&gt; 
                    &lt;/asp:GridView&gt; 
                &lt;/div&gt; 
            &lt;/div&gt; 
        &lt;/div&gt; 
 
        &lt;script type=&quot;text/javascript&quot; src=&quot;DragandDropGridAsp.js&quot;&gt;&lt;/script&gt; 
    &lt;/form&gt; 
&lt;/body&gt; 
&lt;/html&gt; </pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;<span class="html__attr_name">AutoEventWireup</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">CodeBehind</span>=<span class="html__attr_value">&quot;Default.aspx.cs&quot;</span>&nbsp;<span class="html__attr_name">Inherits</span>=<span class="html__attr_value">&quot;DragandDrop.Default&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="html__doctype">&lt;!DOCTYPE&nbsp;html&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;html</span>&nbsp;<span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
<span class="html__tag_start">&lt;head</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">http-equiv</span>=<span class="html__attr_value">&quot;Content-Type&quot;</span>&nbsp;<span class="html__attr_name">content</span>=<span class="html__attr_value">&quot;text/html;&nbsp;charset=utf-8&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/title&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;style.css&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;Scripts/jquery-2.1.3.min.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;Scripts/jquery-ui-1.11.2.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Table&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Title&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Drag&nbsp;and&nbsp;Drop&nbsp;Grid&nbsp;Asp<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Heading&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Cell&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Grid&nbsp;1<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Cell&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Grid&nbsp;2<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Row&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Cell&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:GridView&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;gvSource&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">CssClass</span>=<span class="html__attr_value">&quot;drag_drop_grid&nbsp;GridSrc&quot;</span>&nbsp;<span class="html__attr_name">AutoGenerateColumns</span>=<span class="html__attr_value">&quot;false&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;Columns</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;Id&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;Id&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;Value&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;Value&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/Columns&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/asp:GridView&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Cell&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:GridView&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;gvDest&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">CssClass</span>=<span class="html__attr_value">&quot;drag_drop_grid&nbsp;GridDest&quot;</span>&nbsp;<span class="html__attr_name">AutoGenerateColumns</span>=<span class="html__attr_value">&quot;false&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;Columns</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;Id&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;Id&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;Value&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;Value&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/Columns&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/asp:GridView&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;DragandDropGridAsp.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em>Este tiene un poco de c&oacute;digo C# para cargar o inicial-izar datos en la pantalla:</em></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><em><span><br>
</span></em></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Web; 
using System.Web.UI; 
using System.Web.UI.WebControls; 
 
namespace DragandDrop 
{ 
    public partial class Default : System.Web.UI.Page 
    { 
        protected void Page_Load(object sender, EventArgs e) 
        { 
            if (!Page.IsPostBack) 
            { 
                DataTable dt = new DataTable(); 
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn(&quot;Id&quot;), new DataColumn(&quot;Value&quot;) }); 
                dt.Rows.Add(1, 450); 
                dt.Rows.Add(2, 3200); 
                dt.Rows.Add(3, 1900); 
                dt.Rows.Add(4, 185); 
                dt.Rows.Add(5, 100); 
                dt.Rows.Add(6, 120); 
                dt.Rows.Add(7, 290); 
                dt.Rows.Add(8, 150); 
                dt.Rows.Add(9, 1900); 
                dt.Rows.Add(10, 1585); 
                dt.Rows.Add(11, 1060); 
                dt.Rows.Add(12, 1220); 
                gvSource.UseAccessibleHeader = true; 
                gvSource.DataSource = dt; 
                gvSource.DataBind(); 
 
                dt.Rows.Clear(); 
                dt.Rows.Add(); 
                gvDest.DataSource = dt; 
                gvDest.DataBind(); 
            } 
        } 
    } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.UI;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.UI.WebControls;&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DragandDrop&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Default&nbsp;:&nbsp;System.Web.UI.Page&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!Page.IsPostBack)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;dt&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.AddRange(<span class="cs__keyword">new</span>&nbsp;DataColumn[<span class="cs__number">2</span>]&nbsp;{&nbsp;<span class="cs__keyword">new</span>&nbsp;DataColumn(<span class="cs__string">&quot;Id&quot;</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;DataColumn(<span class="cs__string">&quot;Value&quot;</span>)&nbsp;});&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">450</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3200</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">3</span>,&nbsp;<span class="cs__number">1900</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">4</span>,&nbsp;<span class="cs__number">185</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">5</span>,&nbsp;<span class="cs__number">100</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">6</span>,&nbsp;<span class="cs__number">120</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">7</span>,&nbsp;<span class="cs__number">290</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">8</span>,&nbsp;<span class="cs__number">150</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">9</span>,&nbsp;<span class="cs__number">1900</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">10</span>,&nbsp;<span class="cs__number">1585</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">11</span>,&nbsp;<span class="cs__number">1060</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__number">12</span>,&nbsp;<span class="cs__number">1220</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvSource.UseAccessibleHeader&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvSource.DataSource&nbsp;=&nbsp;dt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvSource.DataBind();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Clear();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvDest.DataSource&nbsp;=&nbsp;dt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvDest.DataBind();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em>Si observamos el c&oacute;digo del .aspx tenemos 2 dependencias, una hoja de estilos y un archivo javascritp.</em></div>
<p>&nbsp;</p>
<p><span>style.css</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">css</span>
<pre class="hidden">.Table { 
    display: table; 
} 
 
.Title { 
    display: table-caption; 
    text-align: center; 
    font-weight: bold; 
    font-size: larger; 
    min-width: 450px; 
} 
 
.Heading { 
    display: table-row; 
    font-weight: bold; 
    text-align: center; 
} 
 
.Row { 
    display: table-row; 
    min-width: 200px; 
} 
 
.Cell { 
    display: table-cell; 
    border: solid; 
    border-width: thin; 
    padding-left: 5px; 
    padding-right: 5px; 
} 
 
.GridSrc td 
    { 
        background-color: #bce8f3; 
        color: black; 
        font-size: 10pt; 
        font-family:Arial; 
        line-height: 200%; 
        cursor: pointer; 
        width:100px 
    } 
    .GridSrc th 
    { 
        background-color: #506165; 
        color: White; 
        font-family:Arial; 
        font-size: 10pt; 
        line-height: 200%; 
        width:100px; 
    } 
    .GridDest td 
    { 
        background-color: #eee !important; 
        color: black; 
        font-family:Arial; 
        font-size: 10pt; 
        line-height: 200%; 
        cursor: pointer; 
        width:100px 
    } 
    .GridDest th 
    { 
        background-color: #6C6C6C !important; 
        color: White; 
        font-family:Arial; 
        font-size: 10pt; 
        line-height: 200%; 
        width:100px 
    }</pre>
<div class="preview">
<pre class="css"><span class="css__class">.Table</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">display:</span>&nbsp;table;&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="css__class">.Title</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">display:</span>&nbsp;<span class="css__value">table-caption</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">text-align:</span>&nbsp;<span class="css__value">center</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-weight:</span>&nbsp;<span class="css__value">bold</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-size:</span>&nbsp;<span class="css__value">larger</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">min-width:</span>&nbsp;<span class="css__number">450px</span>;&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="css__class">.Heading</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">display:</span>&nbsp;<span class="css__value">table-row</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-weight:</span>&nbsp;<span class="css__value">bold</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">text-align:</span>&nbsp;<span class="css__value">center</span>;&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="css__class">.Row</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">display:</span>&nbsp;<span class="css__value">table-row</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">min-width:</span>&nbsp;<span class="css__number">200px</span>;&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="css__class">.Cell</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">display:</span>&nbsp;<span class="css__value">table-cell</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border:</span>&nbsp;<span class="css__value">solid</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border-width:</span>&nbsp;<span class="css__value">thin</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">padding-left:</span>&nbsp;<span class="css__number">5px</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">padding-right:</span>&nbsp;<span class="css__number">5px</span>;&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="css__class">.GridSrc</span>&nbsp;<span class="css__element">td</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background-color:</span>&nbsp;<span class="css__color">#bce8f3</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">color:</span>&nbsp;<span class="css__color">black</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-size:</span>&nbsp;<span class="css__number">10pt</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-family:</span>Arial;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">line-height:</span>&nbsp;<span class="css__number">200%</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">cursor:</span>&nbsp;<span class="css__value">pointer</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">width:</span><span class="css__number">100px</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__class">.GridSrc</span>&nbsp;<span class="css__element">th</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background-color:</span>&nbsp;<span class="css__color">#506165</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">color:</span>&nbsp;<span class="css__color">White</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-family:</span>Arial;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-size:</span>&nbsp;<span class="css__number">10pt</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">line-height:</span>&nbsp;<span class="css__number">200%</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">width:</span><span class="css__number">100px</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__class">.GridDest</span>&nbsp;<span class="css__element">td</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background-color:</span>&nbsp;<span class="css__color">#eee</span>&nbsp;!important;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">color:</span>&nbsp;<span class="css__color">black</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-family:</span>Arial;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-size:</span>&nbsp;<span class="css__number">10pt</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">line-height:</span>&nbsp;<span class="css__number">200%</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">cursor:</span>&nbsp;<span class="css__value">pointer</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">width:</span><span class="css__number">100px</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__class">.GridDest</span>&nbsp;<span class="css__element">th</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background-color:</span>&nbsp;<span class="css__color">#6C6C6C</span>&nbsp;!important;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">color:</span>&nbsp;<span class="css__color">White</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-family:</span>Arial;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-size:</span>&nbsp;<span class="css__number">10pt</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">line-height:</span>&nbsp;<span class="css__number">200%</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">width:</span><span class="css__number">100px</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em>DragandDropGridAsp.js</em></div>
<p>&nbsp;</p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">$(function () { 
    $(&quot;.drag_drop_grid&quot;).sortable({ 
        items: 'tr:not(tr:first-child)', 
        cursor: 'crosshair', 
        connectWith: '.drag_drop_grid', 
        axis: 'x,y', 
        dropOnEmpty: true, 
        receive: function (e, ui) { 
            $(this).find(&quot;tbody&quot;).append(ui.item); 
            //Aqui puede actualizar la informacion de dataset o base de datos  
            //mediante web metodos o una WebApi 
            // var objeto = {}; 
            //objeto.Id = $(&quot;[id*=gvDest] tr:last&quot;).find(&quot;td:nth-child(1)&quot;).html(); 
            //objeto.Value = $(&quot;[id*=gvDest] tr:last&quot;).find(&quot;td:nth-child(2)&quot;).html(); 
            //$.ajax({ 
            //    type: &quot;POST&quot;, 
            //    url: &quot;url Web Metodo o WebApi&quot;, 
            //    data: '{objeto: ' &#43; JSON.stringify(objeto) &#43; '}', 
            //    contentType: &quot;application/json; charset=utf-8&quot;, 
            //    dataType: &quot;json&quot;, 
            //    success: function (response) { 
            //        alert(&quot;Accion realizada correctamente&quot;); 
            //    } 
            //}); 
            return false; 
        } 
    }); 
    $(&quot;[id*=gvDest] tr:not(tr:first-child)&quot;).remove(); 
});</pre>
<div class="preview">
<pre class="js">$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;.drag_drop_grid&quot;</span>).sortable(<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items:&nbsp;<span class="js__string">'tr:not(tr:first-child)'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cursor:&nbsp;<span class="js__string">'crosshair'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connectWith:&nbsp;<span class="js__string">'.drag_drop_grid'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;axis:&nbsp;<span class="js__string">'x,y'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dropOnEmpty:&nbsp;true,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receive:&nbsp;<span class="js__operator">function</span>&nbsp;(e,&nbsp;ui)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).find(<span class="js__string">&quot;tbody&quot;</span>).append(ui.item);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Aqui&nbsp;puede&nbsp;actualizar&nbsp;la&nbsp;informacion&nbsp;de&nbsp;dataset&nbsp;o&nbsp;base&nbsp;de&nbsp;datos&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//mediante&nbsp;web&nbsp;metodos&nbsp;o&nbsp;una&nbsp;WebApi&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;var&nbsp;objeto&nbsp;=&nbsp;{};&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//objeto.Id&nbsp;=&nbsp;$(&quot;[id*=gvDest]&nbsp;tr:last&quot;).find(&quot;td:nth-child(1)&quot;).html();&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//objeto.Value&nbsp;=&nbsp;$(&quot;[id*=gvDest]&nbsp;tr:last&quot;).find(&quot;td:nth-child(2)&quot;).html();&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//$.ajax({&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;&quot;POST&quot;,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;&quot;url&nbsp;Web&nbsp;Metodo&nbsp;o&nbsp;WebApi&quot;,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;'{objeto:&nbsp;'&nbsp;&#43;&nbsp;JSON.stringify(objeto)&nbsp;&#43;&nbsp;'}',&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;&quot;application/json;&nbsp;charset=utf-8&quot;,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;dataType:&nbsp;&quot;json&quot;,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;function&nbsp;(response)&nbsp;{&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(&quot;Accion&nbsp;realizada&nbsp;correctamente&quot;);&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//});&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;[id*=gvDest]&nbsp;tr:not(tr:first-child)&quot;</span>).remove();&nbsp;&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>DragandDrop.zip</em> </li></ul>
<h1>More Information</h1>
<p><em>Para mas Informacion no olviden visitar mi sitio web <a href="http://juanrendon.net">
juanrendon.net</a></em></p>
