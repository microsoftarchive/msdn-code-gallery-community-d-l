# Implement radio button selection in JQWidgets JQXGrid using checkbox
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- XML
- jQuery
- Javascript
- jQWidgets
## Topics
- Visual Studio
- jQWidgets
- Third Party Libraries
## Updated
- 06/28/2016
## Description

<p><span style="font-size:small">In this post we will see how we can implement radio button selection feature to&nbsp;<a href="http://sibeeshpassion.com/category/products/jqwidgets/" target="_blank">jQWidgets&nbsp;</a><a href="http://sibeeshpassion.com/category/products/jqwidgets/jqx-grid/" target="_blank">jQXGrid</a>.
 As of now in JQXGrid, we don&rsquo;t have this functionality yet, but still we can do it our self by using check box selection which is already available. We will load the grid with sample data and implement the radio button selection. If you are new to JQX
 Grid, you can see some tips&nbsp;<em><a href="http://sibeeshpassion.com/tag/jqx-grid/" target="_blank">here</a></em>. I hope you will like this.</span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">I am using JQXGrid in one of my project, where I wanted to implement the radio button selection, when I talked with JQXGrid development team, I was said that the functionality is not yet available. But they have given an option
 as&nbsp;<em>selectionmode: &lsquo;checkbox&rsquo;</em>&nbsp;with the help of that property we can implement the requirement. As you know, to load a jQWidget JQX Grid, there you need the following things as mandatory.</span></p>
<li><span style="font-size:small">datafields</span> </li><li><span style="font-size:small">columns</span> </li><li><span style="font-size:small">localdata or server side data</span>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">First of all, load the needed references. You can download the needed files from&nbsp;<a href="http://www.jqwidgets.com/download/" target="_blank">here</a>.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_799982">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;link&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;href=<span class="js__string">&quot;jqwidgets/styles/jqx.base.css&quot;</span>&nbsp;type=<span class="js__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;jquery-2.2.3.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxcore.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxdata.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxbuttons.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxscrollbar.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxmenu.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxgrid.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxgrid.edit.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxgrid.selection.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxgrid.pager.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxlistbox.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxdropdownlist.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxgrid.sort.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxcheckbox.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&nbsp;src=<span class="js__string">&quot;jqwidgets/jqxgrid.columnsresize.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Now, we are going to set our data source, this time we will use a XML file as data source.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_852196">
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
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">&lt;?xml&nbsp;version=<span class="js__string">&quot;1.0&quot;</span>&nbsp;encoding=<span class="js__string">&quot;iso-8859-1&quot;</span>&nbsp;standalone=<span class="js__string">&quot;yes&quot;</span>?&gt;&nbsp;
&lt;feed&nbsp;xml:base=<span class="js__string">&quot;http://services.odata.org/Northwind/Northwind.svc/&quot;</span>&nbsp;xmlns:d=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices&quot;</span>&nbsp;xmlns:m=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/metadata&quot;</span>&nbsp;xmlns=<span class="js__string">&quot;http://www.w3.org/2005/Atom&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;title&nbsp;type=<span class="js__string">&quot;text&quot;</span>&gt;Orders&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&lt;id&gt;http:<span class="js__sl_comment">//services.odata.org/Northwind/Northwind.svc/Orders&lt;/id&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;updated&gt;<span class="js__num">2011</span><span class="js__num">-12</span>-01T11:<span class="js__num">55</span>:06Z&lt;/updated&gt;&nbsp;
&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;self&quot;</span>&nbsp;title=<span class="js__string">&quot;Orders&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;entry&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;id&gt;http:<span class="js__sl_comment">//services.odata.org/Northwind/Northwind.svc/Orders(10248)&lt;/id&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&nbsp;type=<span class="js__string">&quot;text&quot;</span>&gt;&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;updated&gt;<span class="js__num">2011</span><span class="js__num">-12</span>-01T11:<span class="js__num">55</span>:06Z&lt;/updated&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;author&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;name&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/author&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;edit&quot;</span>&nbsp;title=<span class="js__string">&quot;Order&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10248)&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Customer&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=entry&quot;</span>&nbsp;title=<span class="js__string">&quot;Customer&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10248)/Customer&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Employee&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=entry&quot;</span>&nbsp;title=<span class="js__string">&quot;Employee&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10248)/Employee&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Order_Details&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=feed&quot;</span>&nbsp;title=<span class="js__string">&quot;Order_Details&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10248)/Order_Details&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Shipper&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=entry&quot;</span>&nbsp;title=<span class="js__string">&quot;Shipper&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10248)/Shipper&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;category&nbsp;term=<span class="js__string">&quot;NorthwindModel.Order&quot;</span>&nbsp;scheme=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/scheme&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;content&nbsp;type=<span class="js__string">&quot;application/xml&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;m:properties&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:OrderID&nbsp;m:type=<span class="js__string">&quot;Edm.Int32&quot;</span>&gt;<span class="js__num">10248</span>&lt;/d:OrderID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:CustomerID&gt;VINET&lt;/d:CustomerID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:EmployeeID&nbsp;m:type=<span class="js__string">&quot;Edm.Int32&quot;</span>&gt;<span class="js__num">5</span>&lt;/d:EmployeeID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:OrderDate&nbsp;m:type=<span class="js__string">&quot;Edm.DateTime&quot;</span>&gt;<span class="js__num">1996</span><span class="js__num">-07</span>-04T00:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/d:OrderDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:RequiredDate&nbsp;m:type=<span class="js__string">&quot;Edm.DateTime&quot;</span>&gt;<span class="js__num">1996</span><span class="js__num">-08</span>-01T00:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/d:RequiredDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShippedDate&nbsp;m:type=<span class="js__string">&quot;Edm.DateTime&quot;</span>&gt;<span class="js__num">1996</span><span class="js__num">-07</span>-16T00:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/d:ShippedDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipVia&nbsp;m:type=<span class="js__string">&quot;Edm.Int32&quot;</span>&gt;<span class="js__num">3</span>&lt;/d:ShipVia&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:Freight&nbsp;m:type=<span class="js__string">&quot;Edm.Decimal&quot;</span>&gt;<span class="js__num">32.3800</span>&lt;/d:Freight&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipName&gt;Vins&nbsp;et&nbsp;alcools&nbsp;Chevalier&lt;/d:ShipName&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipAddress&gt;<span class="js__num">59</span>&nbsp;rue&nbsp;de&nbsp;l'Abbaye&lt;/d:ShipAddress&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipCity&gt;Reims&lt;/d:ShipCity&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipRegion&nbsp;m:null=<span class="js__string">&quot;true&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipPostalCode&gt;<span class="js__num">51100</span>&lt;/d:ShipPostalCode&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipCountry&gt;France&lt;/d:ShipCountry&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/m:properties&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/content&gt;&nbsp;
&nbsp;&nbsp;&lt;/entry&gt;&nbsp;
&nbsp;&nbsp;&lt;entry&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;id&gt;http:<span class="js__sl_comment">//services.odata.org/Northwind/Northwind.svc/Orders(10249)&lt;/id&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&nbsp;type=<span class="js__string">&quot;text&quot;</span>&gt;&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;updated&gt;<span class="js__num">2011</span><span class="js__num">-12</span>-01T11:<span class="js__num">55</span>:06Z&lt;/updated&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;author&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;name&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/author&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;edit&quot;</span>&nbsp;title=<span class="js__string">&quot;Order&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10249)&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Customer&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=entry&quot;</span>&nbsp;title=<span class="js__string">&quot;Customer&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10249)/Customer&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Employee&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=entry&quot;</span>&nbsp;title=<span class="js__string">&quot;Employee&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10249)/Employee&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Order_Details&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=feed&quot;</span>&nbsp;title=<span class="js__string">&quot;Order_Details&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10249)/Order_Details&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/related/Shipper&quot;</span>&nbsp;type=<span class="js__string">&quot;application/atom&#43;xml;type=entry&quot;</span>&nbsp;title=<span class="js__string">&quot;Shipper&quot;</span>&nbsp;href=<span class="js__string">&quot;Orders(10249)/Shipper&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;category&nbsp;term=<span class="js__string">&quot;NorthwindModel.Order&quot;</span>&nbsp;scheme=<span class="js__string">&quot;http://schemas.microsoft.com/ado/2007/08/dataservices/scheme&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;content&nbsp;type=<span class="js__string">&quot;application/xml&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;m:properties&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:OrderID&nbsp;m:type=<span class="js__string">&quot;Edm.Int32&quot;</span>&gt;<span class="js__num">10249</span>&lt;/d:OrderID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:CustomerID&gt;TOMSP&lt;/d:CustomerID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:EmployeeID&nbsp;m:type=<span class="js__string">&quot;Edm.Int32&quot;</span>&gt;<span class="js__num">6</span>&lt;/d:EmployeeID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:OrderDate&nbsp;m:type=<span class="js__string">&quot;Edm.DateTime&quot;</span>&gt;<span class="js__num">1996</span><span class="js__num">-07</span>-05T00:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/d:OrderDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:RequiredDate&nbsp;m:type=<span class="js__string">&quot;Edm.DateTime&quot;</span>&gt;<span class="js__num">1996</span><span class="js__num">-08</span>-16T00:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/d:RequiredDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShippedDate&nbsp;m:type=<span class="js__string">&quot;Edm.DateTime&quot;</span>&gt;<span class="js__num">1996</span><span class="js__num">-07</span>-10T00:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/d:ShippedDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipVia&nbsp;m:type=<span class="js__string">&quot;Edm.Int32&quot;</span>&gt;<span class="js__num">1</span>&lt;/d:ShipVia&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:Freight&nbsp;m:type=<span class="js__string">&quot;Edm.Decimal&quot;</span>&gt;<span class="js__num">11.6100</span>&lt;/d:Freight&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipName&gt;Toms&nbsp;Spezialit&auml;ten&lt;/d:ShipName&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipAddress&gt;Luisenstr.&nbsp;<span class="js__num">48</span>&lt;/d:ShipAddress&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipCity&gt;M&uuml;nster&lt;/d:ShipCity&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipRegion&nbsp;m:null=<span class="js__string">&quot;true&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipPostalCode&gt;<span class="js__num">44087</span>&lt;/d:ShipPostalCode&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;d:ShipCountry&gt;Germany&lt;/d:ShipCountry&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/m:properties&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/content&gt;&nbsp;
&nbsp;&nbsp;&lt;/entry&gt;&nbsp;
&nbsp;&nbsp;&lt;link&nbsp;rel=<span class="js__string">&quot;next&quot;</span>&nbsp;href=<span class="js__string">&quot;http://services.odata.org/Northwind/Northwind.svc/Orders?$skiptoken=10447&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/feed&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">You can get the full data from the file&nbsp;<em>orders.xml</em>&nbsp;from the solution attached.</span></p>
<p><span style="font-size:small">Now create a div element where we can bind the grid.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_649519">
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
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;id=<span class="js__string">'jqxWidget'</span>&nbsp;style=<span class="js__string">&quot;font-size:&nbsp;13px;&nbsp;font-family:&nbsp;Verdana;&nbsp;float:&nbsp;left;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="js__string">&quot;jqxgrid&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;/div&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Now we will define our grid as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_333703">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__string">&quot;#jqxgrid&quot;</span>).jqxGrid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width:&nbsp;<span class="js__num">850</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;height:&nbsp;<span class="js__num">450</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source:&nbsp;dataAdapter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable:&nbsp;true,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selectionmode:&nbsp;<span class="js__string">'checkbox'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;altrows:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ready:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#columntablejqxgrid&nbsp;.jqx-checkbox-default'</span>).hide();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;<span class="js__string">'Ship&nbsp;Name'</span>,&nbsp;datafield:&nbsp;<span class="js__string">'ShipName'</span>,&nbsp;width:&nbsp;<span class="js__num">250</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;<span class="js__string">'Shipped&nbsp;Date'</span>,&nbsp;datafield:&nbsp;<span class="js__string">'ShippedDate'</span>,&nbsp;width:&nbsp;<span class="js__num">100</span>,&nbsp;cellsformat:&nbsp;<span class="js__string">'yyyy-MM-dd'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;<span class="js__string">'Freight'</span>,&nbsp;datafield:&nbsp;<span class="js__string">'Freight'</span>,&nbsp;width:&nbsp;<span class="js__num">150</span>,&nbsp;cellsformat:&nbsp;<span class="js__string">'F2'</span>,&nbsp;cellsalign:&nbsp;<span class="js__string">'right'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;<span class="js__string">'Ship&nbsp;City'</span>,&nbsp;datafield:&nbsp;<span class="js__string">'ShipCity'</span>,&nbsp;width:&nbsp;<span class="js__num">150</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;<span class="js__string">'Ship&nbsp;Country'</span>,&nbsp;datafield:&nbsp;<span class="js__string">'ShipCountry'</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
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
<p><span style="font-size:small">As you can see we have applied&nbsp;<em>dataAdapter</em>&nbsp;as the source, below is the definition for your data adapter.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_115166">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"><br>
<br>
</div>
</td>
<td class="code"><br>
</td>
</tr>
</tbody>
</table>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;dataAdapter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;$.jqx.dataAdapter(source);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Now we will create the source object as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_136134">
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
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;source&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datatype:&nbsp;<span class="js__string">&quot;xml&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datafields:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'ShippedDate'</span>,&nbsp;map:&nbsp;<span class="js__string">'m\\:properties&gt;d\\:ShippedDate'</span>,&nbsp;type:&nbsp;<span class="js__string">'date'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'Freight'</span>,&nbsp;map:&nbsp;<span class="js__string">'m\\:properties&gt;d\\:Freight'</span>,&nbsp;type:&nbsp;<span class="js__string">'float'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'ShipName'</span>,&nbsp;map:&nbsp;<span class="js__string">'m\\:properties&gt;d\\:ShipName'</span>,&nbsp;type:&nbsp;<span class="js__string">'string'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'ShipAddress'</span>,&nbsp;map:&nbsp;<span class="js__string">'m\\:properties&gt;d\\:ShipAddress'</span>,&nbsp;type:&nbsp;<span class="js__string">'string'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'ShipCity'</span>,&nbsp;map:&nbsp;<span class="js__string">'m\\:properties&gt;d\\:ShipCity'</span>,&nbsp;type:&nbsp;<span class="js__string">'string'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'ShipCountry'</span>,&nbsp;map:&nbsp;<span class="js__string">'m\\:properties&gt;d\\:ShipCountry'</span>,&nbsp;type:&nbsp;<span class="js__string">'string'</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;root:&nbsp;<span class="js__string">&quot;entry&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;record:&nbsp;<span class="js__string">&quot;content&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;id:&nbsp;<span class="js__string">'m\\:properties&gt;d\\:OrderID'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;url&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">As the grid definition is over,it is time to run our application and check whether the grid is loading fine or not.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11721"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/06/Grid-with-check-box-selection-e1467177190846.png"><img class="size-full x_x_wp-image-11721" src="-grid-with-check-box-selection-e1467177190846.png" alt="Grid with check box selection" width="650" height="357"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Grid with check box selection</span></p>
</div>
<p><span style="font-size:small">what do you see? You are able to do multiple selection right? But what do we needed? A radio button selection, isn&rsquo;t it? So we are suppose to able to select only one row right?. This is why, we haven&rsquo;t done the needed
 implementation yet. Let us add some script then.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_647828">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__string">'#jqxgrid'</span>).on(<span class="js__string">'rowselect'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(event)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;event&nbsp;arguments.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;args&nbsp;=&nbsp;event.args;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;row's&nbsp;bound&nbsp;index.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;rowBoundIndex&nbsp;=&nbsp;args.rowindex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;selectedIndexes&nbsp;=&nbsp;$(<span class="js__string">'#jqxgrid'</span>).jqxGrid(<span class="js__string">'selectedrowindexes'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;selectedIndexes.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(rowBoundIndex&nbsp;!==&nbsp;selectedIndexes[i])&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#jqxgrid'</span>).jqxGrid(<span class="js__string">'unselectrow'</span>,&nbsp;selectedIndexes[i]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
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
<p><span style="font-size:small">We are just deleting the other row selection in the event&nbsp;<em>rowselect</em>. Now run your application again, I am sure you will be able to select only one row at a time.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11722"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/06/Grid-with-radio-button-selection-e1467177640220.png"><img class="size-full x_x_wp-image-11722" src="-grid-with-radio-button-selection-e1467177640220.png" alt="Grid with radio button selection" width="650" height="351"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Grid with radio button selection</span></p>
</div>
</li>