# Il controllo DataGrid in WPF
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- .NET Framework
- .NET Framework 4.0
## Topics
- Controls
- Data Binding
- XAML
- GridView
## Updated
- 04/25/2012
## Description

<h1>Introduction</h1>
<div><em><span class="hps">In</span> <span class="hps">this example</span> <span class="hps">
we will</span> <span class="hps">use this control</span> <span class="hps">in WPF</span>
<span class="hps">DataGrid</span><span>,</span> <span class="hps">and</span> <span class="hps">
how to interact</span> <span class="hps">with a</span> <span class="hps">data</span>
<span class="hps">source</span> <span class="hps">through the use</span> <span class="hps">
of</span> <span class="hps">DataBinding</span><span>.</span></em></div>
<h1><span>Building the Sample</span></h1>
<div><em><em>Per poter testare sul proprio pc l'esempio e necessario che sia installato il Framework 4.0 ClientProfile , mentre per poter visualizzare il codice e necessaria la versione 2010 sp1 di VisualStudio.</em></em></div>
<div><span style="font-size:20px; font-weight:bold">&nbsp;</span>&nbsp;</div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div><em></em>&nbsp;</div>
<div><em><span class="hps">In</span> <span class="hps">most applications</span>
<span class="hps">in circulation</span><span>, and</span> <span class="hps">often</span>
<span class="hps">need to interact</span> <span class="hps">with</span> <span class="hps">
data sources</span> <span class="hps">that can be</span> <span class="hps">databases, XML files</span><span>,</span>
<span class="hps">Web applications</span> <span class="hps">and</span> <span class="hps">
altro.Per</span> <span class="hps">everything</span> <span class="hps">is available</span>
<span class="hps">in</span> <span class="hps">a</span> <span class="hps">wpf</span>
<span class="hps">markup</span> <span class="hps">extension that</span> <span class="hps">
performs</span> <span class="hps">the connection</span> <span class="hps">between the controls</span>
<span class="hps">and</span> <span class="hps">data source</span><span>:</span>
<span class="hps">the</span> <span class="hps">DataBinding</span><span>.</span>
<span class="hps">This</span> <span class="hps">markupextension</span> <span class="hps">
contained</span> <span class="hps">in</span> <span class="hps">XAML</span> <span class="hps">
allows us to</span> <span class="hps">display the</span> <span class="hps">data in a</span>
<span class="hps">table in</span> <span class="hps">a DataBase</span> <span class="hps">
all'internno</span><span>,</span> <span class="hps">is also useful</span> <span class="hps">
in</span> <span class="hps">case of</span> <span class="hps">an application</span>
<span class="hps">for the</span> <span class="hps">Master View</span> <span class="hps">
/ Details</span> <span class="hps">in the case of</span> <span class="hps">filters and</span>
<span class="hps">sorting of data</span> <span class="hps">collected using a</span>
<span class="hps">query</span> <span class="hps">from a</span> <span class="hps">
DataBase</span> <span class="hps">or even</span> <span class="hps">if</span> <span class="hps">
collection.In</span> <span class="hps">databinding</span> <span class="hps">and quite</span>
<span class="hps">complex and</span> <span class="hps">certainly not</span> <span class="hps">
just</span> <span class="hps">an article</span> <span class="hps">to describe</span>
<span class="hps">all the features,</span> <span class="hps">but on</span> <span class="hps">
Msdn</span> <span class="hps">Library are</span> <span class="hps">several</span>
<span class="hps">articles that speak</span> <span class="hps">in a clear</span>
<span class="hps">and comprehensive</span><span>,</span> <span class="hps">it</span>
<span class="hps">is</span> <span class="hps">an example</span> <span class="hps">
this<a href="http://msdn.microsoft.com/en-us/library/ms750612.aspx"><span style="color:#0000ff"><em><span style="text-decoration:underline">link .</span></em></span></a></span>
<span class="hps">Returning</span> <span class="hps">to the example</span><span>,</span>
<span class="hps">will perform the</span> <span class="hps">classic</span> <span class="hps">
queries</span> <span class="hps">used</span> <span class="hps">for the insertion</span><span>, deletion</span>
<span class="hps">and modification</span> <span class="hps">of data</span><span>, all</span>
<span class="hps">then displayed</span> <span class="hps">within a</span> <span class="hps">
DataGrid control</span><span>.</span><br>
<br>
<span class="hps">This</span> <span class="hps">is the</span> <span class="hps">
interesting</span> <span class="hps">part of</span> <span class="hps">XAML</span><span>, which</span>
<span class="hps">runs as</span> <span class="hps">mentioned previously, the</span>
<span class="hps">link between</span> <span class="hps">the DataGrid</span> <span class="hps">
and</span> <span class="hps">Data</span> <span class="hps">Source</span></em></div>
<div>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;DataGrid</span>.Columns<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTextColumn</span>&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ID}&quot;</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;ID&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTextColumn</span>&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;NOME}&quot;</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;NOME&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTextColumn</span>&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;COGNOME}&quot;</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;COGNOME&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTextColumn</span>&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;INDIRIZZO}&quot;</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;INDIRIZZO&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTextColumn</span>&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;TELEFONO}&quot;</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;TELEFONO&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTextColumn</span>&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;NAZIONALITA}&quot;</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;NAZIONALITA&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataGrid.Columns&gt;</pre>
</div>
</div>
</div>
<div><span><span id="result_box" lang="en"></span></span>&nbsp;</div>
<div><span><span lang="en"><span class="hps">With</span> <span class="hps">DataGid.Columns</span>
<span class="hps">we obtain the set</span> <span class="hps">of</span> <span class="hps">
columns</span> <span class="hps">of a</span> <span class="hps">DataGrid</span>
<span class="hps">control</span><span>,</span> <span class="hps">while</span>
<span class="hps">DataGridTextColumn</span> <span class="hps">represents a cell</span>
<span class="hps">in the</span> <span class="hps">DataGrid control that</span>
<span class="hps">contains</span> <span class="hps">text content</span><span>.</span>
<span class="hps">These</span> <span class="hps">cells</span> <span class="hps">
in turn</span> <span class="hps">set</span> <span class="hps">the</span> <span class="hps">
year</span> <span class="hps">Binding property</span><span>.</span> <span class="hps">
This</span> <span class="hps">property</span> <span class="hps">gets or</span>
<span class="hps">sets</span> <span class="hps">the binding that</span> <span class="hps">
maps the column</span> <span class="hps">to a property</span> <span class="hps">
in the data</span><span>.</span> <span class="hps">This</span> <span class="hps">
Education</span> <span class="hps">Code</span> <span class="hps x_atn">{</span><span>Binding</span>
<span class="hps">ID</span><span>} to</span> <span class="hps">associate</span>
<span class="hps">this</span> <span class="hps">instance</span> <span class="hps">
cellla</span> <span class="hps">the</span> <span class="hps">ID field</span> <span class="hps">
of a table and</span> <span class="hps">so on</span> <span class="hps">all</span>
<span class="hps">the others.</span> <span class="hps">Finally</span> <span class="hps">
Education</span> <span class="hps">Code</span> <span class="hps">Header =</span>
<span class="hps x_atn">&quot;</span><span>ID</span><span>&quot;</span> <span class="hps">
field</span> <span class="hps">of the table</span> <span class="hps">shows the user</span>
<span class="hps">which is currently</span> <span class="hps">showing</span> <span class="hps">
that</span> <span class="hps">the cell</span> <span class="hps">references</span><span>.</span>
<span class="hps">At the level</span> <span class="hps">of code</span> <span class="hps">
I showed</span> <span class="hps">the most interesting part</span><span>,</span>
<span class="hps">but in the example</span> <span class="hps">and is available all</span>
<span class="hps">the code</span> <span class="hps">for inserting</span><span>,</span>
<span class="hps">deleting and</span> <span class="hps">modifying data using</span>
<span class="hps">queries</span><span>,</span> <span class="hps">not</span> <span class="hps">
the</span> <span class="hps">XAML for</span> <span class="hps">the arrangement of</span>
<span class="hps">objects</span> <span class="hps">on</span> <span class="hps">
Form.L</span> <span class="hps x_atn">'</span><span class="hps">example, and</span>
<span class="hps">currently available in</span> <span class="hps">C</span> <span class="hps">
#</span><span>,</span> <span class="hps">it will soon be</span> <span class="hps">
available in</span> <span class="hps">VisualBasic</span><span>.</span></span> </span>
</div>
<div id="gt-res-tools">
<address id="gt-src-tools-l"><a id="gt-undo" style="">Annulla modifiche</a></address>
<div id="gt-res-tools-r">
<div class="trans-listen-button x_goog-toolbar-button" id="gt-res-listen"><span class="jfk-button-img">&nbsp;</span></div>
<div class="trans-roman-button x_goog-toolbar-button" id="gt-res-roman" style="">
<span class="jfk-button-img">&nbsp;</span></div>
<div id="gt-res-rate">
<div class="goog-inline-block x_goog-toolbar-menu-button">
<div class="goog-inline-block x_goog-toolbar-menu-button-outer-box">
<div class="goog-inline-block x_goog-toolbar-menu-button-inner-box">
<div class="goog-inline-block x_goog-toolbar-menu-button-caption"><span style="font-size:20px; font-weight:bold">More Information</span></div>
</div>
</div>
</div>
</div>
</div>
</div>
<div><em></em></div>
<div><em><span class="hps">For</span> <span class="hps">more information</span>
<span class="hps">please contact me at</span> <span class="hps">this</span>&nbsp;&nbsp;
<a href="http://community.visual-basic.it/carmelolamonica/default.aspx"><span style="color:#0000ff"><span style="font-style:normal">link</span></span></a></em></div>
