# Entity Framework : Deleting an Item from a Collection
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Visual C#
## Topics
- Entity Framework
## Updated
- 01/05/2017
## Description

<div align="justify">In this example let's see how we can remove/delete an item from a collection in terms of Entity Framework.<br>
<br>
It's always better to go with an example, consider the following scenario.</div>
<div align="justify"></div>
<div align="justify"></div>
<div align="justify">I have an entity, <strong>Department</strong> which has <strong>
Contacts</strong>.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> Department</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">int</span> Id { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">string</span> Name { get; set; }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">virtual</span> ICollection&lt;Contact&gt; Contacts { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> Contact</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">int</span> Id { get; set; }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">string</span> Name { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">virtual</span> Department Department { get; set; }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
&lt;!--CRLF--&gt;</div>
</div>
<div align="justify">I have my DbContext as follows.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:200px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> MyDbContext : DbContext</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> DbSet&lt;Department&gt; Departments { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
&lt;!--CRLF--&gt;</div>
</div>
<div align="justify">Here you can see that I have exposed only <strong>Departments</strong> as a
<strong>DbSet</strong>, because I will only be accessing <strong>Contacts</strong> through their
<strong>Department</strong>.<br>
<br>
</div>
<div align="justify">Now I have my DbContext initializer which seeds some data. Please note that I am inheriting from
<strong>DropCreateDatabaseAlways</strong>.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> MyDbContextInitializer : DropCreateDatabaseAlways&lt;MyDbContext&gt;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Seed(MyDbContext context)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        context.Departments.AddOrUpdate(d =&gt; d.Name, <span style="color:blue">new</span> Department()</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">            Name = <span style="color:#006080">&quot;Microsoft Visual Studio&quot;</span>,</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">            Contacts = <span style="color:blue">new</span> List&lt;Contact&gt;()</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">                {</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">                    <span style="color:blue">new</span> Contact() { Name = <span style="color:#006080">&quot;Jaliya Udagedara&quot;</span> },</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">                    <span style="color:blue">new</span> Contact() { Name = <span style="color:#006080">&quot;John Smith&quot;</span> }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">                }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        });</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        context.SaveChanges();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        Department department = context.Departments.FirstOrDefault();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        Contact contact = department.Contacts.FirstOrDefault();</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        department.Contacts.Remove(contact);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        context.SaveChanges();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
&lt;!--CRLF--&gt;</div>
</div>
<div align="justify">Here you can see that after adding a <strong>Department</strong> with some set of
<strong>Contacts</strong>, I am removing a <strong>Contact</strong>.<br>
<br>
</div>
<div align="justify">Now from the Main method, let's try to see who are the <strong>
Contacts</strong> for my <strong>Department</strong> (here please note that I am not following best practices (null handling etc.), as this is only for demonstration purposes).</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">static</span> <span style="color:blue">void</span> Main(<span style="color:blue">string</span>[] args)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    Database.SetInitializer(<span style="color:blue">new</span> MyDbContextInitializer());</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">using</span> (MyDbContext context = <span style="color:blue">new</span> MyDbContext())</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        <span style="color:blue">foreach</span> (Contact contact <span style="color:blue">in</span> context.Departments.FirstOrDefault().Contacts)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">            Console.WriteLine(contact.Name);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
&lt;!--CRLF--&gt;</div>
</div>
<div align="justify">Output would be as follows.</div>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="https://lh3.googleusercontent.com/-H3mrB9R2yd4/V76qZRpHkbI/AAAAAAAAEME/sSrD2R7hw4s/s1600-h/image%25255B10%25255D.png" style="margin-left:auto; margin-right:auto"><img title="image" src=":-image_thumb%25255b6%25255d.png?imgmax=800" border="0" alt="image" width="450" height="86" style="border-width:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Contacts of Department</td>
</tr>
</tbody>
</table>
<div align="justify">It&rsquo;s just like we expected, initially I have added two
<strong>Contacts</strong> and later I have removed one. So now there is only one <strong>
Contact</strong> in the <strong>Department</strong>.<br>
<br>
</div>
<div align="justify">Out of curiosity, let&rsquo;s check the <strong>Contacts</strong> table in the Database to see whether the
<strong>Contact</strong> is deleted from the back end as well.</div>
<div align="justify">
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="https://lh3.googleusercontent.com/-lSFaZTaCAjc/V76qaq1-CgI/AAAAAAAAEMM/6IecmuqPxNI/s1600-h/image%25255B9%25255D.png" style="margin-left:auto; margin-right:auto"><img title="image" src=":-image_thumb%25255b5%25255d.png?imgmax=800" border="0" alt="image" width="450" height="107" style="border-width:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Contacts in the table</td>
</tr>
</tbody>
</table>
</div>
<div align="justify">Here you can see that the <strong>Contact</strong> is still there, only the relationship has been deleted. So this approach will cause orphan records.<br>
<br>
</div>
<div align="justify">And this was even possible because the <strong>Department_Id</strong> foreign key allowed null. Now let&rsquo;s modify the code so that the
<strong>Contact</strong> should always belong to a <strong>Department</strong> (actually that&rsquo;s why I initially exposed only
<strong>Departments</strong> as a <strong>DbSet</strong> in <strong>MyDbContext</strong>).<br>
<br>
</div>
<div align="justify">I can easily do that change by modifying the <strong>Contact</strong> class as follows.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> Contact</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">int</span> Id { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">string</span> Name { get; set; }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">int</span> Department_Id { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    [ForeignKey(<span style="color:#006080">&quot;Department_Id&quot;</span>)]</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">virtual</span> Department Department { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
&lt;!--CRLF--&gt;</div>
</div>
<p>Now let&rsquo;s run the application.<br>
<br>
This time I am thrown with an error.</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="https://lh3.googleusercontent.com/-StopYgAjLqE/V76qcU_uFEI/AAAAAAAAEMU/6IhlxvB5AWs/s1600-h/image%25255B15%25255D.png" style="margin-left:auto; margin-right:auto"><img title="image" src=":-image_thumb%25255b9%25255d.png?imgmax=800" border="0" alt="image" width="590" height="322" style="border-width:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Error</td>
</tr>
</tbody>
</table>
<div align="justify">The error is, <span style="background-color:white; color:red">
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.InvalidOperationException.aspx" target="_blank" title="Auto generated link to System.InvalidOperationException">System.InvalidOperationException</a>: The operation failed: The relationship could not be changed because one or more of the foreign-key properties is non-nullable. When a change is made to a relationship, the related foreign-key property is set to a null value.
 If the foreign-key does not support null values, a new relationship must be defined, the foreign-key property must be assigned another non-null value, or the unrelated object must be deleted</span><span style="background-color:white">.</span><br>
<span style="background-color:white"><br>
</span></div>
<div align="justify">This is a very obvious error. That is because when we are removing a&nbsp;<strong>Contact</strong> from the
<strong>Department</strong>, as you just saw, only the relationship is getting deleted which causes
<strong>Department_Id</strong> of <strong>Contact</strong> to be null. And we are no longer allowing nulls there.<br>
<br>
</div>
<div align="justify">Now let&rsquo;s see how we can get this fixed. That is deleting both the relationship and the
<strong>Contact</strong>.<br>
<br>
</div>
<div align="justify">We have two options.</div>
<div align="justify">1. Update the state of the entity we want to remove to <strong>
Deleted</strong></div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">Department department = context.Departments.FirstOrDefault();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">Contact contact = department.Contacts.FirstOrDefault();</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:green">// Marking entity state as deleted</span></pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">context.Entry(contact).State = EntityState.Deleted;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">context.SaveChanges();</pre>
&lt;!--CRLF--&gt;</div>
</div>
<div align="justify">Here we don't want to remove the <strong>Contact</strong> from the
<strong>Department</strong>, we can directly update the state of the entity to <strong>
Deleted</strong>. So upon <strong>context.SaveChanges()</strong>, <strong>Contact</strong> will get deleted.<br>
<br>
</div>
<div align="justify"><strong>2. ObjectContext.DeleteObject</strong></div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">Department department = context.Departments.FirstOrDefault();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">Contact contact = department.Contacts.FirstOrDefault();</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:green">// ObjectContext.DeleteObject</span></pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">((IObjectContextAdapter)context).ObjectContext.DeleteObject(contact);<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:&quot;courier new&quot; ,&quot;courier&quot; ,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">context.SaveChanges();</pre>
&lt;!--CRLF--&gt;</div>
</div>
<div align="justify">Here also we can skip <strong>department.Contacts.Remove(contact)</strong>, we can directly call
<strong>DeleteObject()</strong>. Again upon <strong>context.SaveChanges()</strong>,
<strong>Contact</strong> will get deleted.<br>
<br>
</div>
<div align="justify">Using any of these approaches, we can remove/delete a&nbsp;<strong>Contact</strong> from the
<strong>Department</strong>. And most importantly that's without exposing <strong>
Contacts</strong> as <strong>DbSet</strong>&nbsp;in <strong>MyDbContext</strong>.</div>
<div align="justify">
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="https://lh3.googleusercontent.com/-NrPa0TVC9wA/V76qeDTHlGI/AAAAAAAAEMc/Rx8hn-IHKVw/s1600-h/image%25255B20%25255D.png" style="margin-left:auto; margin-right:auto"><img title="image" src=":-image_thumb%25255b12%25255d.png?imgmax=800" border="0" alt="image" width="400" height="77" style="border:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Contacts of Department</td>
</tr>
</tbody>
</table>
</div>
<div align="justify">
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="https://lh3.googleusercontent.com/-lpx1bTi7Th4/V76qfJ2FFAI/AAAAAAAAEMk/mFam9JtdeBU/s1600-h/image%25255B25%25255D.png" style="margin-left:auto; margin-right:auto"><img title="image" src=":-image_thumb%25255b15%25255d.png?imgmax=800" border="0" alt="image" width="400" height="73" style="border:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Contacts in the table</td>
</tr>
</tbody>
</table>
</div>
<div align="justify">I am uploading the full sample code to OneDrive.</div>
<p><br>
Hope this helps.<br>
<br>
Happy Coding.<br>
<br>
Regards,<br>
Jaliya</p>
