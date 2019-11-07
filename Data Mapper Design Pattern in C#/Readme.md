# Data Mapper Design Pattern in C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- .NET Framework
## Topics
- C#
- Reflection
- Design Patterns
- Type Conversions
## Updated
- 02/19/2013
## Description

<h1>Introduction</h1>
<p><em>This sample shows how to implement simple data mapper design pattern between source and destination object. At the same time it shows different type conversion options and reflection.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Sample is build with Visual Studio 2010 using .NET 4.0. It does not use any other assemblies than those in .NET Framework. Just extract the package and build.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample demonstrates how to build data mapper design pattern in C#. At the same time it shows you different type conversion methods and reflection to read and write object properties or methods. Mapper itselft is build for simple types in simple
 cases like mapping from domain object to simplified model object in MVC or MVVM design pattern application.</em></p>
<p><em>By default it maps public get properties to public set properties by name. So if class A has property Name with public getter and class B has property Name with public setter, then value of A.Name is mapped to B.Name. By altering the provided IMap instance
 that defines the mapping between objects its still possible to create more complex mappings like if A has property Color and B has public method SetColor(Color), you can map so that A.Color value is read and mapped to B.Color.</em></p>
<p>Sample contains the class library that implements the mapper and simple console application to demonstrate the usage.</p>
<p><em>Below is from console application.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
{
    //// source instance
    Person person = new Person()
    {
        Name = &quot;Mickey Mouse&quot;,
        Age = 85,
        EyeColor = &quot;Blue&quot;,
        Sex = &quot;Male&quot;,
        Company = new Company() 
        {
            Name = &quot;Disney&quot;
        }
    };

    //// destination instance
    User user;

    //// default map to map between properties with same name
    var map = DataMapper.Resolve&lt;Person, User&gt;();

    //// conversion
    user = DataMapper.Map&lt;Person, User&gt;(person);

    Compare(person, user);

    //// add mapping between properties with different name, but same meaning
    map.Add&lt;Person, User&gt;(p =&gt; p.Sex, u =&gt; u.Gender);

    //// conversion
    user = DataMapper.Map&lt;Person, User&gt;(person);

    Compare(person, user);

    //// map property to setter method
    map.Add&lt;Person, User&gt;(&quot;EyeColor&quot;, &quot;SetEyeColor&quot;);

    //// conversion
    user = DataMapper.Map&lt;Person, User&gt;(person);

    Compare(person, user);

    //// ignore mapping
    map.Ignore&lt;User&gt;(u =&gt; u.Age);

    //// conversion
    user = DataMapper.Map&lt;Person, User&gt;(person);

    Compare(person, user);

    //// unignore
    map.Unignore&lt;User&gt;(u =&gt; u.Age);

    user = DataMapper.Map&lt;Person, User&gt;(person);

    Compare(person, user);

    //// complex
    map.Complex&lt;Person, User&gt;(p =&gt; p.Company, u =&gt; u.Employer);

    user = DataMapper.Map&lt;Person, User&gt;(person);

    Compare(person, user);

    //// remove
    map.Remove(&quot;Company&quot;);

    user = DataMapper.Map&lt;Person, User&gt;(person);

    Compare(person, user);

    //// performance
    Performance(1000);

    Console.ReadKey();
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;source&nbsp;instance</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Mickey&nbsp;Mouse&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">85</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EyeColor&nbsp;=&nbsp;<span class="cs__string">&quot;Blue&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sex&nbsp;=&nbsp;<span class="cs__string">&quot;Male&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Company&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Company()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Disney&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;destination&nbsp;instance</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;User&nbsp;user;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;default&nbsp;map&nbsp;to&nbsp;map&nbsp;between&nbsp;properties&nbsp;with&nbsp;same&nbsp;name</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;map&nbsp;=&nbsp;DataMapper.Resolve&lt;Person,&nbsp;User&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;conversion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;DataMapper.Map&lt;Person,&nbsp;User&gt;(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compare(person,&nbsp;user);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;add&nbsp;mapping&nbsp;between&nbsp;properties&nbsp;with&nbsp;different&nbsp;name,&nbsp;but&nbsp;same&nbsp;meaning</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;map.Add&lt;Person,&nbsp;User&gt;(p&nbsp;=&gt;&nbsp;p.Sex,&nbsp;u&nbsp;=&gt;&nbsp;u.Gender);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;conversion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;DataMapper.Map&lt;Person,&nbsp;User&gt;(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compare(person,&nbsp;user);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;map&nbsp;property&nbsp;to&nbsp;setter&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;map.Add&lt;Person,&nbsp;User&gt;(<span class="cs__string">&quot;EyeColor&quot;</span>,&nbsp;<span class="cs__string">&quot;SetEyeColor&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;conversion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;DataMapper.Map&lt;Person,&nbsp;User&gt;(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compare(person,&nbsp;user);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;ignore&nbsp;mapping</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;map.Ignore&lt;User&gt;(u&nbsp;=&gt;&nbsp;u.Age);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;conversion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;DataMapper.Map&lt;Person,&nbsp;User&gt;(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compare(person,&nbsp;user);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;unignore</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;map.Unignore&lt;User&gt;(u&nbsp;=&gt;&nbsp;u.Age);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;DataMapper.Map&lt;Person,&nbsp;User&gt;(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compare(person,&nbsp;user);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;complex</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;map.Complex&lt;Person,&nbsp;User&gt;(p&nbsp;=&gt;&nbsp;p.Company,&nbsp;u&nbsp;=&gt;&nbsp;u.Employer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;DataMapper.Map&lt;Person,&nbsp;User&gt;(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compare(person,&nbsp;user);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;remove</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;map.Remove(<span class="cs__string">&quot;Company&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;DataMapper.Map&lt;Person,&nbsp;User&gt;(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compare(person,&nbsp;user);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">////&nbsp;performance</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Performance(<span class="cs__number">1000</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>DataMapper.cs - the public interface of the mapping functionality.<br>
</em></li><li><em><em>IMap.cs - the interface to modify the mappings between objects.</em></em>
</li><li><em>MapResolver.cs - the class the resolves the initial map.</em> </li><li><em>ValueConverter.cs - the class that performs value conversions.</em> </li><li><em>TypeConverterCache.cs - the class to cache TypeConverter instances.</em> </li><li><em>ConversionResolves.cs - the class to resolve conversion between types.</em>
</li></ul>
<p>&nbsp;</p>
