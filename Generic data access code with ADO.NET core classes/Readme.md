# Generic data access code with ADO.NET core classes.
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ADO.NET
- .NET Framework
## Topics
- Reflection
- Data Access
- Extension methods
## Updated
- 04/04/2013
## Description

<h1>Introduction</h1>
<p><em>The problem using ADO.NET provider classes is that your data access code might easily become copy-paste code, but this sample shows you one way to create more generic query code.
</em><em>This sample shows how to create easy to extend generic query executor that maps database records to object instances.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Created with Visual Studio 2012 and the sample contains the database script, database.sql, to create the database for the demo console application that demonstrates the usage. The data access code itself is build to class library.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample shows how to build easy to extend generic ADO.NET query executor that maps database records to object instances. The core of the sample is abstract DbExecutor class that provider specifid executor, in my sample there is one SqlDbExecutor
 for SQL server, needs to inherit and override only two methods. The other non-provider specific base class is CommandSettings that needs to be inherited for each provider specific DbExecutor class. The actual execution of the command is in the DbExecutor class
 as in following code where single record is read and converted to object from DbDataReader instance.</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public T GetSingleRecord&lt;T&gt;(CommandSettings settings, IEnumerable&lt;PropertyColumnMapping&gt; mappings) where T : class, new()
{
    using (var connection = GetConnection())
    using (var command = GetCommand(settings, connection))
    {
        Exception exception;

        if (connection.TryOpen(out exception))
        {
            using (var reader = command.ExecuteReader())
            {
                return reader.GetSingleRecord&lt;T&gt;(mappings);
            }
        }
        else
        {
            throw exception;
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;T&nbsp;GetSingleRecord&lt;T&gt;(CommandSettings&nbsp;settings,&nbsp;IEnumerable&lt;PropertyColumnMapping&gt;&nbsp;mappings)&nbsp;where&nbsp;T&nbsp;:&nbsp;<span class="cs__keyword">class</span>,&nbsp;<span class="cs__keyword">new</span>()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;connection&nbsp;=&nbsp;GetConnection())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;command&nbsp;=&nbsp;GetCommand(settings,&nbsp;connection))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exception&nbsp;exception;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(connection.TryOpen(<span class="cs__keyword">out</span>&nbsp;exception))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;reader&nbsp;=&nbsp;command.ExecuteReader())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;reader.GetSingleRecord&lt;T&gt;(mappings);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;exception;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</em>
<p></p>
<p><em>The other core class is the DbDataReaderExtensions that holds extension methods for the DbDataReader class and namely it has all the methods to read database record to object instance. GetSingleRecord is extension method for the DbDataReader that uses
 the private GetInstance method to actually read the reader and perform conversion from database column values to object property values.</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Gets single instance from single record in data reader. Expects that reader only has one record to read.
/// &lt;/summary&gt;
/// &lt;typeparam name=&quot;T&quot;&gt;Type of an object read.&lt;/typeparam&gt;
/// &lt;param name=&quot;reader&quot;&gt;The source &lt;see cref=&quot;DbDataReader&quot;/&gt; instance.&lt;/param&gt;
/// &lt;param name=&quot;mappings&quot;&gt;The mappings between properties and columns.&lt;/param&gt;
/// &lt;returns&gt;A single &lt;typeparamref name=&quot;T&quot;/&gt; instance or default &lt;typeparamref name=&quot;T&quot;/&gt;.&lt;/returns&gt;
public static T GetSingleRecord&lt;T&gt;(this DbDataReader reader, IEnumerable&lt;PropertyColumnMapping&gt; mappings) where T : class, new()
{
    if (reader == null)
        throw new ArgumentNullException(&quot;reader&quot;);

    if (mappings == null)
        throw new ArgumentNullException(&quot;mappings&quot;);

    return GetInstance&lt;T&gt;(reader, mappings, false);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Gets&nbsp;single&nbsp;instance&nbsp;from&nbsp;single&nbsp;record&nbsp;in&nbsp;data&nbsp;reader.&nbsp;Expects&nbsp;that&nbsp;reader&nbsp;only&nbsp;has&nbsp;one&nbsp;record&nbsp;to&nbsp;read.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;typeparam&nbsp;name=&quot;T&quot;&gt;Type&nbsp;of&nbsp;an&nbsp;object&nbsp;read.&lt;/typeparam&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;reader&quot;&gt;The&nbsp;source&nbsp;&lt;see&nbsp;cref=&quot;DbDataReader&quot;/&gt;&nbsp;instance.&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;mappings&quot;&gt;The&nbsp;mappings&nbsp;between&nbsp;properties&nbsp;and&nbsp;columns.&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;returns&gt;A&nbsp;single&nbsp;&lt;typeparamref&nbsp;name=&quot;T&quot;/&gt;&nbsp;instance&nbsp;or&nbsp;default&nbsp;&lt;typeparamref&nbsp;name=&quot;T&quot;/&gt;.&lt;/returns&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;T&nbsp;GetSingleRecord&lt;T&gt;(<span class="cs__keyword">this</span>&nbsp;DbDataReader&nbsp;reader,&nbsp;IEnumerable&lt;PropertyColumnMapping&gt;&nbsp;mappings)&nbsp;where&nbsp;T&nbsp;:&nbsp;<span class="cs__keyword">class</span>,&nbsp;<span class="cs__keyword">new</span>()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;reader&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(mappings&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;mappings&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GetInstance&lt;T&gt;(reader,&nbsp;mappings,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</em>
<p></p>
<p><em>The usage is demonstrated in simple console application, but using the DbExecutor is very simple as shown in following method.<br>
</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Executes query that expects only 1 record to be returned.
/// &lt;/summary&gt;
static Person GetSinglePerson(IEnumerable&lt;PropertyColumnMapping&gt; mappings)
{
    string sql = &quot;SELECT * FROM Person WHERE PersonID = @id;&quot;;
            
    var settings = new SqlCommandSettings(sql, CommandType.Text);
    settings.AddParameter(new SqlParameter(&quot;@id&quot;, 3));

    var executor = new SqlExecutor(cs);

    var person = executor.GetSingleRecord&lt;Person&gt;(settings, mappings);

    return person;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Executes&nbsp;query&nbsp;that&nbsp;expects&nbsp;only&nbsp;1&nbsp;record&nbsp;to&nbsp;be&nbsp;returned.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">static</span>&nbsp;Person&nbsp;GetSinglePerson(IEnumerable&lt;PropertyColumnMapping&gt;&nbsp;mappings)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;sql&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Person&nbsp;WHERE&nbsp;PersonID&nbsp;=&nbsp;@id;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;settings&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommandSettings(sql,&nbsp;CommandType.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;settings.AddParameter(<span class="cs__keyword">new</span>&nbsp;SqlParameter(<span class="cs__string">&quot;@id&quot;</span>,&nbsp;<span class="cs__number">3</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;executor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlExecutor(cs);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;person&nbsp;=&nbsp;executor.GetSingleRecord&lt;Person&gt;(settings,&nbsp;mappings);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;person;&nbsp;
}</pre>
</div>
</div>
</div>
</em>
<p></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>DbExecutor.cs - base class for the ADO.NET provider specific query executor class.</em>
</li><li><em>SqlExecutor.cs - SQL server specific query executor class.</em> </li><li><em><em>CommandSettings.cs - base class for the ADO.NET provider specific command settings.</em></em>
</li><li><em>SqlCommandSettings.cs - command settings for the SqlCommand class.</em> </li><li>DbDataReaderExtensions.cs - extension methods for the DbDataReader class. </li><li>PropertyColumnMapping.cs - class that defines mapping between database column and object property.
</li><li>ColumnConstructorParameterMapping.cs - class that defines mapping between database column and constructor parameter.
</li></ul>
<h1>More Information</h1>
<p><em>This sample only demonstrates the querying synchronously, but is it easy to add asynchronous methods with Tasks or extend the DbExecutor so that it will also execute non-queries that read object property values to insert or update command parameters.<br>
</em></p>
