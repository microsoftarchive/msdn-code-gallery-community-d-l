# Implement SQLite Local Storage Using Windows 10 UWP Apps
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- UWP Sqlite C#
## Topics
- local storage
- Universal app application  local storage
## Updated
- 09/16/2015
## Description

<h1>Introduction</h1>
<p>The Windows 10 Universal app with &nbsp;local storage using SQLite database. just follow below Step-by-step implementation.</p>
<p>&nbsp;It&nbsp;is really easy even in this preview phase. Even though Entity Framework 7 support for Windows 10 Universal apps is almost here</p>
<h1><span>Building the Sample</span></h1>
<p><em>Sqlite Implemetation in UWP app</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong>&nbsp;Step 1:</strong></p>
<p>Create new universal project or &nbsp;library using VS2015 RTM Version</p>
<p><strong>Step 2:</strong></p>
<p>Install &ldquo;sqlite-uap-3081101.VSIX &ldquo;from <strong>Extensions and Updates</strong></p>
<p>VS 2015 -&gt; Tools -&gt; Extensions and update -&gt; search sqlite-uap -&gt; Click Install -&gt; Restart VS 2015</p>
<p>&nbsp;<img id="142636" src="142636-sqlite1.jpg" alt="" width="938" height="455"></p>
<p><strong>Step 3:</strong></p>
<p>The next step is to add the SQLite.Net-PCL library to your project</p>
<p>&nbsp;</p>
<p><img id="142637" src="142637-sqlite2.png" alt="" width="765" height="541"></p>
<p>&nbsp;</p>
<p><strong>Step 4:</strong></p>
<p>Now, remember the sqlite-uap (Visual Studio extension) installed earlier. It installs SQLite extensions that you need to reference by right-clicking on Project References and choosing &quot;Add Reference...&quot; and then finding the right reference under Windows
 Universal &egrave; Extensions.</p>
<p>&nbsp;</p>
<p><img id="142638" src="142638-sqlite3.png" alt="" width="818" height="546"></p>
<p><strong>Step 5:</strong></p>
<p><strong>Coding:</strong></p>
<table border="1" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td width="365" valign="top">
<p><strong>class LocalDatabase</strong></p>
<p>&nbsp;&nbsp;&nbsp; <strong>{</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>public static void CreateDatabase()</strong></p>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, &quot;Contactdb.sqlite&quot;);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; conn.CreateTable&lt;Contact&gt;();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</strong></p>
<p><strong>&nbsp;&nbsp;&nbsp; }</strong></p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<table border="1" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td width="623" valign="top">
<p>&nbsp;&nbsp;&nbsp; <strong>public class Contact</strong></p>
<p><strong>&nbsp;&nbsp;&nbsp; {</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int Id { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string Name { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string Address { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string Mobile { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class LocalDatabase
    {
        public static void CreateDatabase()
        {
         var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, &quot;Contactdb.sqlite&quot;);
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                conn.CreateTable&lt;Contact&gt;();
            }
        }
    }
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;LocalDatabase&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateDatabase()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;sqlpath&nbsp;=&nbsp;System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,&nbsp;<span class="cs__string">&quot;Contactdb.sqlite&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SQLite.Net.SQLiteConnection&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SQLite.Net.SQLiteConnection(<span class="cs__keyword">new</span>&nbsp;SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),&nbsp;sqlpath))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.CreateTable&lt;Contact&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Contact&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Address&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Mobile&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p><em>http://www.devenvexe.com Email :jssuthahar@gmail.com</em></p>
<p><em><br>
</em></p>
