# How to use SQLite with CSharp
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQLite
## Topics
- Architecture and Design
## Updated
- 03/18/2017
## Description

<p>SQLite is open source file system database. Unlike SQL Server, this doesn&rsquo;t require any service to interact with database. But the real problem happens when we try to interact with SQLite DB in C#. There is no proper entity framework support available
 as of now. So, we, somewhat, become compelled to use inline queries. After working on Linq and Entity framework-like ORM, it feels quite irritating to write inline queries for CRUD operation in SQLite DB. So, can we use quasi-lambda codes to interact with
 such file system DB? Can we avoid hardcoded table/column names from our C# code? If you ask me these questions, I would say &ldquo;Absolutely&rdquo;.</p>
<p>In the below article, I will show you &ndash;</p>
<p>&nbsp;</p>
<ul>
<li>How to architect a SQLite &#43;C# client application without any ORM. </li><li>How to use reflection and generic to create your custom and extensible ORM to interact with SQLite database.
</li><li>Also, how to optimize code and its maintainability. </li></ul>
<p>Let&rsquo;s get started&hellip;.</p>
<p>&nbsp;</p>
<p>First of all let&rsquo;s create a SQLite database using any SQLite manager. In our case, say, we have only one table inside the database &ndash; Employee.</p>
<p>Database name: SQLiteDemo.db and table name and schema as follows.</p>
<p><img id="171159" src="171159-1_create%20sqlite%20db.png" alt="" width="661" height="641"></p>
<p>Now, we have to create our solution and tiers. In my case, I will create a solution as give below.</p>
<p><img id="171160" src="171160-arch.png" alt="" width="362" height="550"></p>
<p><strong>SQLiteWithCSharp</strong> : It is the host. It can be windows form application of WPF application or any other.</p>
<p><strong>SQLiteWithCSharp.Common</strong> : As the name says, it can be used by all the projects under this solution.</p>
<p><strong>SQLiteWithCSharp.Models </strong>: This class library will contain all the model classes. The model class name will be exactly same as the table name (&ldquo;Employee&rdquo;). And properties will be same as column names. These model classes will
 be exactly similar to entity classes in case of entity framework with SQL Server. Another point I must mention at this moment is, each property will be decorated with a custom attribute called DbColumn which denotes it to be a table column in database. I will
 explain this custom attribute little later.</p>
<p>Employee model class looks like this.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class Employee
    {
        [DbColumn(IsIdentity =true, IsPrimary =true)]
        public long EmployeeId { get; set; }
        [DbColumn]
        public string Name { get; set; }
        [DbColumn]
        public string JobDescription { get; set; }
        [DbColumn]
        public string Technology { get; set; }
        [DbColumn]
        public string Email { get; set; }

        public long Age { get; set; }

    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DbColumn(IsIdentity&nbsp;=<span class="cs__keyword">true</span>,&nbsp;IsPrimary&nbsp;=<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">long</span>&nbsp;EmployeeId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DbColumn]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DbColumn]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;JobDescription&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DbColumn]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Technology&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DbColumn]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">long</span>&nbsp;Age&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>SQLiteWithCSharp.Services</strong>: This library contains all the CRUD operation methods and business logics. You can also go one step ahead and split into multiple libraries for your own convenience.</p>
<p><strong>SQLiteWithCSharp.Utility</strong>: This is the heart of the CRUD operation. It contains all the operations but in very usable and generic form.</p>
<p>&nbsp;</p>
<p>From my attached solution, you can figure out how these projects are referencing each other.</p>
<p>Now, let&rsquo;s go over the Utility library.</p>
<p>&nbsp;</p>
<p>This custom attribute is used for decorating a property in model class.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class DbColumnAttribute : Attribute
{
        /// &lt;summary&gt;
        /// Set true if implicit conversion is required.
        /// &lt;/summary&gt;
        public bool Convert { get; set; }
        /// &lt;summary&gt;
        /// Set true if the property is primary key in the table
        /// &lt;/summary&gt;
        public bool IsPrimary { get; set; }
        /// &lt;summary&gt;
        /// denotes if the field is an identity type or not.
        /// &lt;/summary&gt;
        public bool IsIdentity { get; set; }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DbColumnAttribute&nbsp;:&nbsp;Attribute&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Set&nbsp;true&nbsp;if&nbsp;implicit&nbsp;conversion&nbsp;is&nbsp;required.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;Convert&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Set&nbsp;true&nbsp;if&nbsp;the&nbsp;property&nbsp;is&nbsp;primary&nbsp;key&nbsp;in&nbsp;the&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsPrimary&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;denotes&nbsp;if&nbsp;the&nbsp;field&nbsp;is&nbsp;an&nbsp;identity&nbsp;type&nbsp;or&nbsp;not.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsIdentity&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This interface basically is implemented by a custom class called Filter which provides you the capability to use member expression to get filtered records in optimized way.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public interface IFilter&lt;T&gt; where T : class, new()
    {
        string EntityName { get; }
        string Query { get; }

        void Add(Expression&lt;Func&lt;T, object&gt;&gt; memberExpression, object memberValue);
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IFilter&lt;T&gt;&nbsp;where&nbsp;T&nbsp;:&nbsp;<span class="cs__keyword">class</span>,&nbsp;<span class="cs__keyword">new</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;EntityName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;Query&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Add(Expression&lt;Func&lt;T,&nbsp;<span class="cs__keyword">object</span>&gt;&gt;&nbsp;memberExpression,&nbsp;<span class="cs__keyword">object</span>&nbsp;memberValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class Filter&lt;T&gt; : IFilter&lt;T&gt; where T : class, new()
    {

        public Filter()
        {
            _Query = new StringBuilder();
            EntityName = typeof(T).Name;
        }

        public void Add(Expression&lt;Func&lt;T, object&gt;&gt; memberExpression, object memberValue)
        {

            if (_Query.ToString() != string.Empty)
                _Query.Append(&quot; AND &quot;);

            _Query.Append(string.Format(&quot; [{0}] = {1}&quot;, NameOf(memberExpression), memberValue == null ? &quot;NULL&quot; : string.Format(&quot;'{0}'&quot;, memberValue)));
        }

        public string EntityName { get; private set; }

        private readonly StringBuilder _Query;

        public string Query
        {
            get
            {
                return string.Format(&quot;SELECT * FROM [{0}] {1} {2};&quot;
                    , EntityName
                    , _Query.ToString() == string.Empty ? string.Empty : &quot;WHERE&quot;
                    , _Query.ToString());
            }
        }

        private string NameOf(Expression&lt;Func&lt;T, object&gt;&gt; exp)
        {
            MemberExpression body = exp.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Filter&lt;T&gt;&nbsp;:&nbsp;IFilter&lt;T&gt;&nbsp;where&nbsp;T&nbsp;:&nbsp;<span class="cs__keyword">class</span>,&nbsp;<span class="cs__keyword">new</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Filter()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Query&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EntityName&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(T).Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Add(Expression&lt;Func&lt;T,&nbsp;<span class="cs__keyword">object</span>&gt;&gt;&nbsp;memberExpression,&nbsp;<span class="cs__keyword">object</span>&nbsp;memberValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_Query.ToString()&nbsp;!=&nbsp;<span class="cs__keyword">string</span>.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Query.Append(<span class="cs__string">&quot;&nbsp;AND&nbsp;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Query.Append(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;&nbsp;[{0}]&nbsp;=&nbsp;{1}&quot;</span>,&nbsp;NameOf(memberExpression),&nbsp;memberValue&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__string">&quot;NULL&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;'{0}'&quot;</span>,&nbsp;memberValue)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;EntityName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;StringBuilder&nbsp;_Query;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Query&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;[{0}]&nbsp;{1}&nbsp;{2};&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;EntityName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;_Query.ToString()&nbsp;==&nbsp;<span class="cs__keyword">string</span>.Empty&nbsp;?&nbsp;<span class="cs__keyword">string</span>.Empty&nbsp;:&nbsp;<span class="cs__string">&quot;WHERE&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;_Query.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;NameOf(Expression&lt;Func&lt;T,&nbsp;<span class="cs__keyword">object</span>&gt;&gt;&nbsp;exp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MemberExpression&nbsp;body&nbsp;=&nbsp;exp.Body&nbsp;<span class="cs__keyword">as</span>&nbsp;MemberExpression;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(body&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UnaryExpression&nbsp;ubody&nbsp;=&nbsp;(UnaryExpression)exp.Body;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body&nbsp;=&nbsp;ubody.Operand&nbsp;<span class="cs__keyword">as</span>&nbsp;MemberExpression;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;body.Member.Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Now we have a class called EntityMapper which actually reads the SQLite db reader and fills in the property values.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class EntityMapper
    {
        // Complete
        public IList&lt;T&gt; Map&lt;T&gt;(SQLiteDataReader reader)
            where T : class, new()
        {
            IList&lt;T&gt; collection = new List&lt;T&gt;();
            while (reader.Read())
            {
                T obj = new T();
                foreach (PropertyInfo i in obj.GetType().GetProperties()
                    .Where(p =&gt; p.CustomAttributes.FirstOrDefault(x =&gt; x.AttributeType == typeof(DbColumnAttribute)) != null).ToList())
                {

                    try
                    {
                        var ca = i.GetCustomAttribute(typeof(DbColumnAttribute));

                        if (ca != null)
                        {
                            if (((DbColumnAttribute)ca).Convert == true)
                            {
                                if (reader[i.Name] != DBNull.Value)
                                    i.SetValue(obj, Convert.ChangeType(reader[i.Name], i.PropertyType));
                            }
                            else
                            {
                                if (reader[i.Name] != DBNull.Value)
                                    i.SetValue(obj, reader[i.Name]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
#endif

#if !DEBUG
                        throw ex;
#endif
                    }
                }

                collection.Add(obj);
            }

            return collection;
        }

    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EntityMapper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Complete</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IList&lt;T&gt;&nbsp;Map&lt;T&gt;(SQLiteDataReader&nbsp;reader)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;T&nbsp;:&nbsp;<span class="cs__keyword">class</span>,&nbsp;<span class="cs__keyword">new</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IList&lt;T&gt;&nbsp;collection&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;T&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(reader.Read())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T&nbsp;obj&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;T();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(PropertyInfo&nbsp;i&nbsp;<span class="cs__keyword">in</span>&nbsp;obj.GetType().GetProperties()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(p&nbsp;=&gt;&nbsp;p.CustomAttributes.FirstOrDefault(x&nbsp;=&gt;&nbsp;x.AttributeType&nbsp;==&nbsp;<span class="cs__keyword">typeof</span>(DbColumnAttribute))&nbsp;!=&nbsp;<span class="cs__keyword">null</span>).ToList())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ca&nbsp;=&nbsp;i.GetCustomAttribute(<span class="cs__keyword">typeof</span>(DbColumnAttribute));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ca&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(((DbColumnAttribute)ca).Convert&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader[i.Name]&nbsp;!=&nbsp;DBNull.Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.SetValue(obj,&nbsp;Convert.ChangeType(reader[i.Name],&nbsp;i.PropertyType));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader[i.Name]&nbsp;!=&nbsp;DBNull.Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.SetValue(obj,&nbsp;reader[i.Name]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__preproc">&nbsp;
#if&nbsp;DEBUG</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(ex.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();<span class="cs__preproc">&nbsp;
#endif</span><span class="cs__preproc">&nbsp;
&nbsp;
#if&nbsp;!DEBUG</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;ex;<span class="cs__preproc">&nbsp;
#endif</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;collection.Add(obj);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;collection;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>The below class is called BaseService which is inherited by all the service classes (example: EmployeeService). It provies basic CRUD operations to all the service classes. The above-montioned claases, attributes, interfaces are used and the BaseService
 methods are prepared. The methods are given below. Since the code is bit lengthy, you can get the complete working code from the attachment. Here I will explain only the methods inside BaseService and how to use them.</p>
</div>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public long Add(T entity) // to insert single entity.
public void AddRange(IList&lt;T&gt; entities) // to bulk-insert multiple entities
public void Update(T entity) // to update one entity
public void UpdateRange(IList&lt;T&gt; entities) // to update multiple entities
public T GetById(object id) // get single entity by its Id
public IList&lt;T&gt; Find(IEnumerable&lt;object&gt; ids) // get multiple entities by ids
public IList&lt;T&gt; Find(IFilter&lt;T&gt; filter) // find entities by filter criteria
public IList&lt;T&gt; GetAll() // to get all entities
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">long</span>&nbsp;Add(T&nbsp;entity)&nbsp;<span class="cs__com">//&nbsp;to&nbsp;insert&nbsp;single&nbsp;entity.</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;AddRange(IList&lt;T&gt;&nbsp;entities)&nbsp;<span class="cs__com">//&nbsp;to&nbsp;bulk-insert&nbsp;multiple&nbsp;entities</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;Update(T&nbsp;entity)&nbsp;<span class="cs__com">//&nbsp;to&nbsp;update&nbsp;one&nbsp;entity</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;UpdateRange(IList&lt;T&gt;&nbsp;entities)&nbsp;<span class="cs__com">//&nbsp;to&nbsp;update&nbsp;multiple&nbsp;entities</span><span class="cs__keyword">public</span>&nbsp;T&nbsp;GetById(<span class="cs__keyword">object</span>&nbsp;id)&nbsp;<span class="cs__com">//&nbsp;get&nbsp;single&nbsp;entity&nbsp;by&nbsp;its&nbsp;Id</span><span class="cs__keyword">public</span>&nbsp;IList&lt;T&gt;&nbsp;Find(IEnumerable&lt;<span class="cs__keyword">object</span>&gt;&nbsp;ids)&nbsp;<span class="cs__com">//&nbsp;get&nbsp;multiple&nbsp;entities&nbsp;by&nbsp;ids</span><span class="cs__keyword">public</span>&nbsp;IList&lt;T&gt;&nbsp;Find(IFilter&lt;T&gt;&nbsp;filter)&nbsp;<span class="cs__com">//&nbsp;find&nbsp;entities&nbsp;by&nbsp;filter&nbsp;criteria</span><span class="cs__keyword">public</span>&nbsp;IList&lt;T&gt;&nbsp;GetAll()&nbsp;<span class="cs__com">//&nbsp;to&nbsp;get&nbsp;all&nbsp;entities</span></pre>
</div>
</div>
</div>
<p></p>
<p>In the solution, you will get all other methods that provide you controls over database through model classes only. You can also write or extend more.</p>
<p>&nbsp;Now, to insert one employee in database and to get the newly inserted employeeId (identity) in one single transaction, we need to write only few lines of code as gove below.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//Create employee object and fill the properties.
            Employee e = new Employee();
            e.Name = &quot;Swaraj&quot;;
            e.Email = &quot;swaraj.ece.jgec@gmail.com&quot;;
            e.JobDescription = &quot;Software Developer&quot;;
            e.Technology = &quot;DotNet&quot;;
            e.Age = 27;

           long generatedEmployeeId = InsertEmployee(e);
            textBox1.Text = string.Format(&quot;{0}&quot;, generatedEmployeeId);
            // Similarly call other methods
public  long InsertEmployee(Employee newEmployee)
        {
//Call the add method in employee service.
           return new EmployeeService().Add(newEmployee);
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//Create&nbsp;employee&nbsp;object&nbsp;and&nbsp;fill&nbsp;the&nbsp;properties.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;e&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Employee();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Swaraj&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Email&nbsp;=&nbsp;<span class="cs__string">&quot;swaraj.ece.jgec@gmail.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.JobDescription&nbsp;=&nbsp;<span class="cs__string">&quot;Software&nbsp;Developer&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Technology&nbsp;=&nbsp;<span class="cs__string">&quot;DotNet&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Age&nbsp;=&nbsp;<span class="cs__number">27</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;generatedEmployeeId&nbsp;=&nbsp;InsertEmployee(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}&quot;</span>,&nbsp;generatedEmployeeId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Similarly&nbsp;call&nbsp;other&nbsp;methods</span><span class="cs__keyword">public</span><span class="cs__keyword">long</span>&nbsp;InsertEmployee(Employee&nbsp;newEmployee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
<span class="cs__com">//Call&nbsp;the&nbsp;add&nbsp;method&nbsp;in&nbsp;employee&nbsp;service.</span><span class="cs__keyword">return</span><span class="cs__keyword">new</span>&nbsp;EmployeeService().Add(newEmployee);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>The EmployeeService class looks very clean and simple. Please notice, the employee class has been passed to BaseService as an entity.</p>
<p><img id="171162" src="171162-xx.png" alt="" width="529" height="279"></p>
<p>Similarly, you can update, search employees as given in the below sample methods.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void UpdateEmployee(Employee existingEmployee)
        {
            new EmployeeService().Update(existingEmployee);
        }

        public Employee GetEmployee(long id)
        {
            return new EmployeeService().GetById(id);
        }

        public List&lt;Employee&gt; GetEmployeesByTechnology(string technology)
        {

            var employeeFilter = new Filter&lt;Employee&gt;();
            employeeFilter.Add(x =&gt; x.Technology, technology);
            // You can add more filters

            EmployeeService svc = new EmployeeService();
            return svc.Find(employeeFilter).ToList();
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;UpdateEmployee(Employee&nbsp;existingEmployee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;EmployeeService().Update(existingEmployee);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Employee&nbsp;GetEmployee(<span class="cs__keyword">long</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">new</span>&nbsp;EmployeeService().GetById(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;Employee&gt;&nbsp;GetEmployeesByTechnology(<span class="cs__keyword">string</span>&nbsp;technology)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;employeeFilter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Filter&lt;Employee&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employeeFilter.Add(x&nbsp;=&gt;&nbsp;x.Technology,&nbsp;technology);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;can&nbsp;add&nbsp;more&nbsp;filters</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EmployeeService&nbsp;svc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EmployeeService();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;svc.Find(employeeFilter).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><strong>Conclusion:-</strong></p>
<p>Thus, you can write much cleaner code while working&nbsp; with SQLite and C#.&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
