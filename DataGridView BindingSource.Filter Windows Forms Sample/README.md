# DataGridView BindingSource.Filter Windows Forms Sample
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- XML
- DataGridView
- Filter expression
## Topics
- Windows Forms
## Updated
- 06/18/2012
## Description

<h1>Indroduction</h1>
<p>My sample demonstates how You can use BindigSource.Filter expressions in a bound DataGridView control (DataTable &gt; BindingSource &gt; DataGridView)</p>
<p>also demonstates</p>
<ul>
<li>Loading XML into DataTable </li><li>Select items from DataGridView </li><li>DataGridView cell Formating </li></ul>
<p><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.bindingsource.filter(v=vs.80).aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.bindingsource.filter(v=vs.80).aspx</a></p>
<h1><br>
Building the Sample</h1>
<p><br>
There no special requirements or instructions for building the sample necessary.</p>
<h1><br>
Description of the UI</h1>
<p>Start the sample. The Datagridview will be filled by testData.xml file in the execution path.</p>
<p>&nbsp;</p>
<p><img id="59429" src="59429-src1.jpg" alt="" width="794" height="415"></p>
<p>&nbsp;</p>
<p>Textbox: enter Your expression string here</p>
<p>Button &quot;execute filter&quot; : Start expression filter<br>
Button &quot;clear filter&quot; : no filterung data</p>
<p>Left mouse button click on datagridview: show items<br>
right mouse button click on datagridview: contextmenue</p>
<p>clear filter<br>
clicked item is filter</p>
<h1>Used datatypes in my sample</h1>
<p>&lt;xs:element name=&quot;PLACE&quot; msprop:OraDbType=&quot;126&quot; msprop:BaseColumn=&quot;PLACE&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;<br>
&lt;xs:element name=&quot;PID&quot; msprop:OraDbType=&quot;126&quot; msprop:BaseColumn=&quot;PID&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;<br>
&lt;xs:element name=&quot;TESTTIME&quot; msprop:OraDbType=&quot;106&quot; msprop:BaseColumn=&quot;TESTTIME&quot; type=&quot;xs:dateTime&quot; minOccurs=&quot;0&quot; /&gt;<br>
&lt;xs:element name=&quot;RESULT&quot; msprop:OraDbType=&quot;111&quot; msprop:BaseColumn=&quot;RESULT&quot; type=&quot;xs:short&quot; minOccurs=&quot;0&quot; /&gt;<br>
&lt;xs:element name=&quot;STATIONNR&quot; msprop:OraDbType=&quot;112&quot; msprop:BaseColumn=&quot;STATIONNR&quot; type=&quot;xs:int&quot; minOccurs=&quot;0&quot; /&gt;<br>
&lt;xs:element name=&quot;TYPE&quot; msprop:OraDbType=&quot;126&quot; msprop:BaseColumn=&quot;TYPE&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;<br>
&nbsp;</p>
<h1>Expression Syntax</h1>
<p><strong>Keywords</strong></p>
<p>Allowed keywords are</p>
<p>And<br>
Between<br>
Child<br>
False<br>
In<br>
Is<br>
Like<br>
Not<br>
Null<br>
Or<br>
Parent<br>
True</p>
<p><br>
<strong>Operators</strong></p>
<p>Concatenation is allowed using Boolean AND, OR, and NOT operators. You can use parentheses to group clauses and force precedence. The AND operator has precedence over other operators. For example:
<br>
(PLACE = 'L14' OR TYPE = '7EB1') AND RESULT = '0' <br>
When you create comparison expressions, the following operations are allowed: <br>
&lt; <br>
&gt; <br>
&lt;= <br>
&gt;= <br>
&lt;&gt; <br>
= <br>
IN <br>
LIKE <br>
The following arithmetic operators are also supported in expressions: <br>
&#43; (addition) <br>
- (subtraction) <br>
* (multiplication) <br>
/ (division) <br>
% (modulus)</p>
<h1><br>
Topic links</h1>
<p>For more information</p>
<p><a href="http://msdn.microsoft.com/de-de/library/system.data.datacolumn.expression.aspx">http://msdn.microsoft.com/de-de/library/system.data.datacolumn.expression.aspx</a></p>
<p>msdn sample: Building a Drop-Down Filter List for a DataGridView Column Header Cell</p>
<p><a href="http://msdn.microsoft.com/en-us/library/aa480727.aspx">http://msdn.microsoft.com/en-us/library/aa480727.aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
