# Export To CSV
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- XAML
- MVVM
- Windows 8
- Windows RT
- Windows 8 Store Apps
- Windows Store app
## Topics
- C#
- Data Binding
- ViewModel pattern (MVVM)
- MVVM
- How to
- Files
- Windows Store app
- Export Data
## Updated
- 01/13/2013
## Description

<h1>Introduction</h1>
<p><em>In this sample i will show a sample for&nbsp; export data, that is showed in ListView, to a csv file.
<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You only need Visual Studio 2012 and Windows 8, both the RTM version.</em><strong>
</strong></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample could be called &quot;Export to Excel&quot;, but it is not supported, the only way is to write the data in a CSV file that can be opened in Excel.</em></p>
<p>&nbsp;</p>
<p>Here is the class diagram:</p>
<p><img id="73832" src="73832-classdiagram1.png" alt="" width="641" height="167"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2><strong>Here is the class that is used to convert the data into a CSV file:</strong></h2>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CsvExport&lt;T&gt;&nbsp;where&nbsp;T&nbsp;:&nbsp;<span class="cs__keyword">class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IList&lt;T&gt;&nbsp;Objects;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CsvExport(IList&lt;T&gt;&nbsp;objects)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Objects&nbsp;=&nbsp;objects;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Export()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Export(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Export(<span class="cs__keyword">bool</span>&nbsp;includeHeaderLine)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;sb&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;properties&nbsp;using&nbsp;reflection.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;propertyInfos&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(T).GetTypeInfo();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(includeHeaderLine)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//add&nbsp;header&nbsp;line.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;propertyInfo&nbsp;<span class="cs__keyword">in</span>&nbsp;propertyInfos.DeclaredProperties)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(propertyInfo.Name).Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Remove(sb.Length&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>).AppendLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//add&nbsp;value&nbsp;for&nbsp;each&nbsp;property.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(T&nbsp;obj&nbsp;<span class="cs__keyword">in</span>&nbsp;Objects)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;propertyInfo&nbsp;<span class="cs__keyword">in</span>&nbsp;propertyInfos.DeclaredProperties)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj,&nbsp;<span class="cs__keyword">null</span>))).Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Remove(sb.Length&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>).AppendLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;sb.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//export&nbsp;to&nbsp;a&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;ExportToFile(<span class="cs__keyword">string</span>&nbsp;path)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;storageFolder&nbsp;=&nbsp;KnownFolders.DocumentsLibrary;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;file&nbsp;=&nbsp;await&nbsp;storageFolder.CreateFileAsync(path,&nbsp;CreationCollisionOption.ReplaceExisting);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;FileIO.WriteTextAsync(file,&nbsp;Export());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//export&nbsp;as&nbsp;binary&nbsp;data.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;ExportToBytes()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Encoding.UTF8.GetBytes(Export());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//get&nbsp;the&nbsp;csv&nbsp;value&nbsp;for&nbsp;field.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MakeValueCsvFriendly(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;<span class="cs__keyword">is</span>&nbsp;DateTime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(((DateTime)<span class="cs__keyword">value</span>).TimeOfDay.TotalSeconds&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;((DateTime)<span class="cs__keyword">value</span>).ToString(<span class="cs__string">&quot;yyyy-MM-dd&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;((DateTime)<span class="cs__keyword">value</span>).ToString(<span class="cs__string">&quot;yyyy-MM-dd&nbsp;HH:mm:ss&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;output&nbsp;=&nbsp;<span class="cs__keyword">value</span>.ToString();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(output.Contains(<span class="cs__string">&quot;,&quot;</span>)&nbsp;||&nbsp;output.Contains(<span class="cs__string">&quot;\&quot;&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;output&nbsp;=&nbsp;<span class="cs__string">'&quot;'</span>&nbsp;&#43;&nbsp;output.Replace(<span class="cs__string">&quot;\&quot;&quot;</span>,&nbsp;<span class="cs__string">&quot;\&quot;\&quot;&quot;</span>)&nbsp;&#43;&nbsp;<span class="cs__string">'&quot;'</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;output;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>There is an important point in that class:</p>
<p>The ListSeparator that you have defined in</p>
<p><img id="74525" src="74525-listseparator.png" alt="" width="546" height="339"></p>
<p>can be found programatticaly using System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator</p>
<p>But is dependes the list of languages preferences:</p>
<p><img id="74526" src="74526-language.png" alt="" width="443" height="301"></p>
<p>&nbsp;</p>
<p>If i choose English the ListSeparator is , and for my excel is ; because is that i have in my regional settings</p>
<p>If i choose Portugues the LisSeparator is ; and for my excel is ; too and it works well.</p>
<h1></h1>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>BoardItem is my item that has Name, Value and Count properties<br>
</em></li><li>ConvertingToCSVFileViewModel: is my view model to connect data with the view (i use binding)
</li><li>CsvExport is the class that convert the data into csv file. </li></ul>
<h1>Result</h1>
<p><strong>In the Windows 8 App:</strong></p>
<p><img id="73835" src="73835-wind8appresult.png" alt="" width="609" height="338"></p>
<p>&nbsp;</p>
<p><strong>The myexportresult.csv file opened in Excel:</strong></p>
<p><strong><img id="73836" src="73836-excelresult.png" alt="" width="591" height="318"><br>
</strong></p>
<p><strong><br>
</strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h3><span style="font-size:medium">Build the Sample<br>
</span></h3>
<ol>
<li>Start Visual Studio Express&nbsp;2012 for Windows&nbsp;8 and select <strong>File</strong> &gt;
<strong>Open</strong> &gt; <strong>Project/Solution</strong>. </li><li>Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio Express&nbsp;2012 for Windows&nbsp;8 Solution (.sln) file.
</li><li>Press F7 or use <strong>Build</strong> &gt; <strong>Build Solution</strong> to build the sample.
</li></ol>
<p>&nbsp;</p>
<h3><span style="font-size:medium">&nbsp;Run the sample</span></h3>
<p>To debug the app and then run it, press F5 or use <strong>Debug</strong> &gt; <strong>
Start Debugging</strong>. To run the app without&nbsp;&nbsp; debugging, press Ctrl&#43;F5 or use
<strong>Debug</strong> &gt; <strong>Start Without Debugging</strong>.</p>
<p>&nbsp;</p>
<h1>More Information</h1>
<div><em>Ask me on twitter @saramgsilva</em></div>
