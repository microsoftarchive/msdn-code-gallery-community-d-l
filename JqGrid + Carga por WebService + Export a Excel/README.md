# JqGrid + Carga por WebService + Export a Excel
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- jQuery
- Web Services
- Javascript
- Jquery Ajax
## Topics
- C#
- AJAX
- Javascript
## Updated
- 09/27/2013
## Description

<h1>Introducci&oacute;n</h1>
<p><em>Esta soluci&oacute;n prentende mostrar un ejemplo de uso del grid de javascript JqGrid, realizando la carga mediante una llamada Ajax a un WebService, asi como permitir la exportaci&oacute;n de los datos cargados en dicho grid a un fichero Excel.</em></p>
<p><em><em>&nbsp;</em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>El ejemplo &uacute;nicamente necesita Visual Studio 2012 para su ejecuci&oacute;n y no es necesario disponer de ninguna base de datos, pues los datos usados son generados automaticamente por la soluci&oacute;n para simplificar su funcionamiento.</em></p>
<p><em>Este ejemplo hace uso de Tirand JqGrid, asi como la versi&oacute;n 1.7.2 de JQuery y 1.8.21 de JQueryUI. Todos estos ficheros js ya estan incluidos en la propia soluci&oacute;n.</em></p>
<p><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></p>
<p><em>El ejemplo presentado Soluciona la necesidad de exportar a Excel los datos del Grid por medio de una p&aacute;gina aspx (Export2Excel.aspx), la cual se encarga de generar y retornar los datos en formato Excel.</em></p>
<p><em><img id="97144" src="http://i1.code.msdn.s-msft.com/jqgrid-carga-por-e3df6eaa/image/file/97144/1/jqgridtest1.png" alt="" width="600" height="328"><br>
</em></p>
<p><em>El M&eacute;tod que realiza la funcio&oacute;n de generar la respuesta Excel es la siguiente:</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ExportToExcel(<span class="cs__keyword">string</span>&nbsp;fileName,&nbsp;DataTable&nbsp;dt)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AddHeader(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;content-disposition&quot;</span>,&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;attachment;&nbsp;filename={0}&quot;</span>,&nbsp;fileName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;application/ms-excel&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;tab&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(DataColumn&nbsp;dc&nbsp;<span class="cs__keyword">in</span>&nbsp;dt.Columns)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Write(tab&nbsp;&#43;&nbsp;dc.ColumnName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab&nbsp;=&nbsp;<span class="cs__string">&quot;\t&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Write(<span class="cs__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(DataRow&nbsp;dr&nbsp;<span class="cs__keyword">in</span>&nbsp;dt.Rows)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;dt.Columns.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Write(tab&nbsp;&#43;&nbsp;dr[i].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab&nbsp;=&nbsp;<span class="cs__string">&quot;\t&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Write(<span class="cs__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.End();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>Mas Informaci&oacute;n</h1>
<p><em>Para mas informaci&oacute;n visitar el art&iacute;culo relacionado en mi blog donde se detallan los pasos realizados a la hora de generar el ejemplo de la soluci&oacute;n.</em></p>
<p><em><a href="http://jordi-developer.blogspot.com.es/2012/07/aspnet-jqgrid-exportacion-excel.html">http://jordi-developer.blogspot.com.es/2012/07/aspnet-jqgrid-exportacion-excel.html</a><br>
</em></p>
