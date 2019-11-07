# File explorer / windows explorer  for different data sources
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- WPF
## Topics
- Asynchronous Programming
- WPF
- File Explorer
- Sorting
- Windows Explorer
- folder treeview
## Updated
- 03/27/2015
## Description

<h1>Introduction</h1>
<p>File explorer for different data sources , such as local PC, cloud, json,xml etc.</p>
<p>all the data loaded &nbsp;asynchonizely.</p>
<p>Current bottle neck is add search result to UI thread, because all the operation is invoked by async , and all the search threads will add data to ObservableCollection, so the UI thread will be blocked</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><em>VS2010 or above , Nuget for&nbsp;LitJson.0.7.0</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><em>IFile&nbsp;</em>.cs</em></p>
<p><em>using System;using System.Windows.Media;<br>
namespace FileExplorer.Model{&nbsp; &nbsp; public interface IFile : ICloneable&nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Full file path&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp;
 string FullPath { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// File name&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; string Name { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// File extension&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; string Extension { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// File title for display&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; string Title { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Type name&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; string TypeName { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Folder path for search&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; string FolderPath { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; DateTime LastModifyTime { get; }&nbsp; &nbsp; &nbsp; &nbsp; string LastModifyTimeString { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; long Size { get; }&nbsp; &nbsp; &nbsp; &nbsp; string SizeString { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; ImageSource Icon { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; bool IsEnabled { get; set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// IsFolder for sort ordering&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; bool IsFolder { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// IsFile for sort ordering&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; bool IsFile { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// True: full checked&nbsp; &nbsp; &nbsp; &nbsp; /// Null: half checked&nbsp; &nbsp; &nbsp; &nbsp; /// False: not checked&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp;
 &nbsp; &nbsp; bool? IsChecked { get; set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; void SetChecked(bool? isChecked);<br>
&nbsp; &nbsp; &nbsp; &nbsp; IFolder Parent { get; }&nbsp; &nbsp; }}<br>
</em></p>
<p><em>Ifolder.cs</em></p>
<p><em>&nbsp; &nbsp;using System;using System.Collections.Generic;using System.Collections.ObjectModel;<br>
namespace FileExplorer.Model{&nbsp; &nbsp; public interface IFolder : IFile, IDisposable&nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// is loading children&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp;
 &nbsp; &nbsp; bool IsLoading { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Is tree item &nbsp;expanded&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; bool IsExpanded { get; set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Is tree item &nbsp;selected&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; bool IsSelected { get; set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Is extracting canceled&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; bool IsCanceled { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Is tree item &nbsp;checkbox visible&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; bool IsCheckVisible { get; set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Folder in virtual folder has a virtual parent&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; IFolder VirtualParent { get; set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Sub folders&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; ObservableCollection&lt;IFolder&gt; Folders { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Sub files&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; ObservableCollection&lt;IFile&gt; Files { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Sub folders and files&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; ObservableCollection&lt;IFile&gt; Items { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Cancel current extracting&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; void Cancel();<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Get sub folders and files async&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;returns&gt;&lt;/returns&gt;&nbsp; &nbsp; &nbsp; &nbsp; void GetChildrenAsync(Action&lt;IEnumerable&lt;IFile&gt;&gt;
 callback);<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Get sub folders async&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;returns&gt;&lt;/returns&gt;&nbsp; &nbsp; &nbsp; &nbsp; void GetFoldersAsync(Action&lt;IEnumerable&lt;IFolder&gt;&gt;
 callback);<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Get sub &nbsp;files async&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;returns&gt;&lt;/returns&gt;&nbsp; &nbsp; &nbsp; &nbsp; void GetFilesAsync(Action&lt;IEnumerable&lt;IFile&gt;&gt;
 callback);<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &nbsp;Get sub foldr or file by path&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;param name=&quot;filePath&quot;&gt;&lt;/param&gt;&nbsp; &nbsp; &nbsp;
 &nbsp; /// &lt;param name=&quot;callback&quot;&gt;&lt;/param&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;param name=&quot;isRecursive&quot;&gt;&lt;/param&gt;&nbsp; &nbsp; &nbsp; &nbsp; void GetItemAsync(string filePath, Action&lt;IFile&gt; callback, bool isRecursive = true);<br>
&nbsp; &nbsp; }}</em></p>
<p>&nbsp;</p>
<p><em><em>IFileCheck.cs</em><br>
using System.Collections.Generic;<br>
namespace FileExplorer.Model{&nbsp; &nbsp; interface IFileCheck&nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Checked item not to do the recursive &nbsp;checked opertion&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp;
 &nbsp; &nbsp; &nbsp; /// &lt;param name=&quot;isChecked&quot;&gt;&lt;/param&gt;&nbsp; &nbsp; &nbsp; &nbsp; void SetChecked(bool? isChecked);<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Checked the all parent for current item&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;param name=&quot;item&quot;&gt;&lt;/param&gt;&nbsp; &nbsp; &nbsp;
 &nbsp; /// &lt;param name=&quot;isChecked&quot;&gt;&lt;/param&gt;&nbsp; &nbsp; &nbsp; &nbsp; void CheckParent(IFile item, bool? isChecked);<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Set checked by file path&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;returns&gt;&lt;/returns&gt;&nbsp; &nbsp; &nbsp; &nbsp; // void SetChecked(IList&lt;string&gt;
 path);&nbsp; &nbsp; }<br>
&nbsp; &nbsp; interface IFolderCheck : IFileCheck&nbsp; &nbsp; { &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Checked the all children for current item&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;param name=&quot;item&quot;&gt;&lt;/param&gt;&nbsp;
 &nbsp; &nbsp; &nbsp; /// &lt;param name=&quot;isChecked&quot;&gt;&lt;/param&gt;&nbsp; &nbsp; &nbsp; &nbsp; void CheckChildren(IFolder item, bool? isChecked);<br>
&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// Get all checked children for current item&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;&nbsp; &nbsp; &nbsp; &nbsp; /// &lt;returns&gt;&lt;/returns&gt;&nbsp; &nbsp; &nbsp; &nbsp;
 IEnumerable&lt;IFile&gt; GetCheckedItems(IFolder folder);&nbsp; &nbsp; }}<br>
</em></p>
<p>&nbsp;</p>
<p>ISearch.cs</p>
<p>using System;using System.Collections.Generic;using System.Linq;using System.Text;<br>
namespace FileExplorer.ViewModel{&nbsp; &nbsp; interface ISearch&nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; string SearchKeyword { get; }&nbsp; &nbsp; &nbsp; &nbsp; bool IsSearchEnabled { get; }&nbsp; &nbsp; &nbsp; &nbsp; string NotFoundHint { get; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; void Search(string keyword);&nbsp; &nbsp; &nbsp; &nbsp; void Cancel();&nbsp; &nbsp; }}</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>IFile #1 - file interface</em> </li><li><em><em>IFolder&nbsp;#2 - folder interface for getting sub items in async</em></em>
</li><li><em><em>IFileCheck #3 file &nbsp;and folder check interface to check subitems or parent<br>
</em></em></li><li><em><em>ISearch #4 search item for the specfic tree selected folder<br>
</em></em></li><li><em><em>ISortOrder #5 sort interface for content&nbsp;<br>
</em></em></li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
