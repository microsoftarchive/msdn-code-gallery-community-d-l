# How to use MVVM Pattern Using WPF in Visual Studio 2012
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
- Visual Studio 2012
## Topics
- MVVM using WPF
- mvvp pattern in visual studio 2012
- mvvm pattern in wpf
## Updated
- 05/07/2013
## Description

<h1>Introduction</h1>
<p><em><span>This article describes the basic use and functionality of the Model-View-View-Model (MVVM) pattern in WPF.</span><br>
<br>
<strong>MVVM</strong><span>: an architectural pattern used in software engineering that originated from Microsoft that is specialized in the Presentation Model design pattern. It is based on the Model-View-Controller pattern (MVC), and is targeted at modern
 UI development platforms (WPF and Silverlight) in which there is a UX developer who has different requirements than a more &quot;traditional&quot; developer. MVVM is a way of creating client applications that leverage core features of the WPF platform, allows for simple
 unit testing of application functionality, and helps developers and designers work together with less technical difficulties.</span><br>
<br>
<strong>VIEW:</strong><span>&nbsp;A View is defined in XAML and should not have any logic in the code-behind. It binds to the view-model by only using data binding.&nbsp;</span><br>
<br>
<strong>MODEL:</strong><span>&nbsp;A Model is responsible for exposing data in a way that is easily consumable by WPF. It must implement INotifyPropertyChanged and/or INotifyCollectionChanged as appropriate.&nbsp;</span><br>
<br>
<strong>VIEWMODEL:&nbsp;</strong><span>A ViewModel is a model for a view in the application or we can say as an abstraction of the view. It exposes data relevant to the view and exposes the behaviors for the views, usually with Commands.</span></em></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-family:'Segoe UI'; font-size:x-small">Getting Started:</span></p>
<ul>
<li><span style="font-family:'Segoe UI'; font-size:x-small">Creating a WPF Project. Open Visual Studio 2012.</span>
</li><li><span style="font-family:'Segoe UI'; font-size:x-small">Go to &quot;File&quot; -&gt; &quot;New&quot; -&gt; &quot;Project...&quot;</span>
</li><li><span style="font-family:'Segoe UI'; font-size:x-small">Select Window in installed templates</span>
</li><li><span style="font-family:'Segoe UI'; font-size:x-small">Select WPF Application</span>
</li><li><span style="font-family:'Segoe UI'; font-size:x-small">Enter the Name and choose the location.</span>
</li><li><span style="font-family:'Segoe UI'; font-size:x-small">Click OK</span> </li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span style="font-family:'Segoe UI'; font-size:x-small">Now create three folders in the root application. The Name should be Model, View, and View Model and now add a new class in the Model folder. My class name is User and adds this namespace:<br>
<br>
</span><span lang="EN-US">using</span><span><span lang="EN-US">&nbsp;</span></span><span lang="EN-US">System.ComponentModel;</span><span style="font-family:'Segoe UI'; font-size:x-small"><br>
<br>
<strong>User.cs<br>
</strong><br>
</span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.Collections.Generic;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.Linq;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.Text;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.ComponentModel;&nbsp;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">namespace</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;MVVMInWPF.Model<br>
{<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">class</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;:&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">INotifyPropertyChanged<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">int</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;userId;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;firstName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;lastName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;city;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;state;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;country;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">int</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;UserId<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;userId;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userId =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnPropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;UserId&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;FirstName<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;firstName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; firstName =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnPropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;FirstName&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;LastName<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;lastName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lastName =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnPropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;LastName&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;City<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;city;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; city =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnPropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;City&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;State<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;state;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; state =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnPropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;State&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Country<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;country;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; country =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnPropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Country&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&nbsp;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; #region</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;INotifyPropertyChanged Members<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">event</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">PropertyChangedEventHandler</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;PropertyChanged;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">void</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;OnPropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">string</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;propertyName)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">if</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;(PropertyChanged !=&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">null</span></span><span lang="EN-US"><span style="font-size:x-small">)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PropertyChanged(</span></span><span lang="EN-US"><span style="font-size:x-small">this</span></span><span lang="EN-US"><span style="font-size:x-small">,&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">PropertyChangedEventArgs</span></span><span lang="EN-US"><span style="font-size:x-small">(propertyName));<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;#endregion<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp; }&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
}<br>
</span></span><span style="font-family:'Segoe UI'; font-size:x-small"><br>
Now add a new class in ViewModel .<br>
<br>
<strong>UserViewModel.cs</strong><br>
<br>
</span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.Collections.Generic;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.Linq;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.Text;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.Windows.Input;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;System.ComponentModel;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">using</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;MVVMInWPF.Model;<br>
&nbsp;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">namespace</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;MVVMInWPF.ViewModel<br>
{<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">class</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">UserViewModel<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">IList</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;
 _UsersList;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;UserViewModel()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _UsersList =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">List</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId
 = 1,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Raj&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Beniwal&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Delhi&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;DEL&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;INDIA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">},<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId=2,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Mark&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;henry&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;New
 York&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;NY&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;USA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">},<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId=3,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Mahesh&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Chand&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Philadelphia&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,
 State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;PHL&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;USA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">},<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId=4,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Vikash&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Nanda&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Noida&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,
 State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;UP&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;INDIA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">},<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId=5,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Harsh&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Kumar&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Ghaziabad&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,
 State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;UP&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;INDIA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">},<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId=6,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Reetesh&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Tomar&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Mumbai&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,
 State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;MP&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;INDIA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">},<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId=7,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Deven&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Verma&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Palwal&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,
 State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;HP&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;INDIA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">},<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">{UserId=8,FirstName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Ravi&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,LastName=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Taneja&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,City=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;Delhi&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">,
 State=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;DEL&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">, Country=</span></span><span lang="EN-US"><span style="font-size:x-small">&quot;INDIA&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">IList</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">User</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;
 Users<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;{&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;_UsersList;
 }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;{ _UsersList =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;
 }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">ICommand</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;mUpdater;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">ICommand</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;UpdateCommand<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">get<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">if</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;(mUpdater ==&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">null</span></span><span lang="EN-US"><span style="font-size:x-small">)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mUpdater =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">new</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">Updater</span></span><span lang="EN-US"><span style="font-size:x-small">();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;mUpdater;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">set<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mUpdater =&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">value</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">private</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">class</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">Updater</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;:&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">ICommand<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; #region</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;ICommand Members<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">bool</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;CanExecute(</span></span><span lang="EN-US"><span style="font-size:x-small">object</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;parameter)<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">return</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">true</span></span><span lang="EN-US"><span style="font-size:x-small">;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">event</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">EventHandler</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;CanExecuteChanged;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">public</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">void</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Execute(</span></span><span lang="EN-US"><span style="font-size:x-small">object</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;parameter)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; #endregion<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp; }<br>
}<br>
</span></span><span style="font-family:'Segoe UI'; font-size:x-small"><br>
Now add a new view in the View folder.<br>
<br>
<strong>MainPage.xaml<br>
</strong><br>
</span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Window</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Class</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;MVVMInWPF.View.MainPage&quot;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;xmlns</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;<a href="http://schemas.microsoft.com/winfx/2006/xaml/presentation">http://schemas.microsoft.com/winfx/2006/xaml/presentation</a>&quot;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;xmlns</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">x</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;<a href="http://schemas.microsoft.com/winfx/2006/xaml">http://schemas.microsoft.com/winfx/2006/xaml</a>&quot;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Title</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;MainPage&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;485&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;525&quot;&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Grid</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;0,0,0,20&quot;&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Grid.RowDefinitions</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">RowDefinition</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Auto&quot;/&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">RowDefinition</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;*&quot;/&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">RowDefinition</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Auto&quot;/&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;/</span></span><span lang="EN-US"><span style="font-size:x-small">Grid.RowDefinitions</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">ListView</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;UserGrid&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;4,178,12,13&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;ItemsSource</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Users</span></span><span lang="EN-US"><span style="font-size:x-small">}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">ListView.View</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">GridView</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;grdTest&quot;&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">GridViewColumn</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Header</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;UserId&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;DisplayMemberBinding</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;UserId</span></span><span lang="EN-US"><span style="font-size:x-small">}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;50&quot;/&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">GridViewColumn</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Header</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;First
 Name&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;DisplayMemberBinding</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;FirstName</span></span><span lang="EN-US"><span style="font-size:x-small">}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">GridViewColumn</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Header</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Last
 Name&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;DisplayMemberBinding</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;LastName</span></span><span lang="EN-US"><span style="font-size:x-small">}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;100&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">GridViewColumn</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Header</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;City&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;DisplayMemberBinding</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;City</span></span><span lang="EN-US"><span style="font-size:x-small">}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">GridViewColumn</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Header</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;State&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;DisplayMemberBinding</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;State</span></span><span lang="EN-US"><span style="font-size:x-small">}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">GridViewColumn</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Header</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Country&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;DisplayMemberBinding</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Country</span></span><span lang="EN-US"><span style="font-size:x-small">}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;100&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;/</span></span><span lang="EN-US"><span style="font-size:x-small">GridView</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;/</span></span><span lang="EN-US"><span style="font-size:x-small">ListView.View</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;/</span></span><span lang="EN-US"><span style="font-size:x-small">ListView</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">TextBox</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;23&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80,7,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;txtUserId&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;178&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Text</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;ElementName</span></span><span lang="EN-US"><span style="font-size:x-small">=UserGrid,</span></span><span lang="EN-US"><span style="font-size:x-small">Path</span></span><span lang="EN-US"><span style="font-size:x-small">=SelectedItem.UserId}&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">TextBox</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;23&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80,35,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;txtFirstName&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;178&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Text</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><br>
<span lang="EN-US"><span style="font-size:x-small">ElementName</span></span><span lang="EN-US"><span style="font-size:x-small">=UserGrid,</span></span><span lang="EN-US"><span style="font-size:x-small">Path</span></span><span lang="EN-US"><span style="font-size:x-small">=SelectedItem.FirstName}&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">TextBox</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;23&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80,62,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;txtLastName&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;178&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Text</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><br>
<span lang="EN-US"><span style="font-size:x-small">ElementName</span></span><span lang="EN-US"><span style="font-size:x-small">=UserGrid,</span></span><span lang="EN-US"><span style="font-size:x-small">Path</span></span><span lang="EN-US"><span style="font-size:x-small">=SelectedItem.LastName}&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Label</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Content</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;UserId&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;12,12,0,274&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;label1&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Label</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Content</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Last
 Name&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;28&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;12,60,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;label2&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Label</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Content</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;First
 Name&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;28&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;12,35,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;label3&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Button</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Content</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Update&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;23&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;310,40,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;btnUpdate&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;141&quot;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Command</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Path</span></span><span lang="EN-US"><span style="font-size:x-small">=UpdateCommad}&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;/&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">TextBox</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;23&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80,143,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;txtCity&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;178&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Text</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;SelectedItem</span></span><span lang="EN-US"><span style="font-size:x-small">.City,</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;ElementName</span></span><span lang="EN-US"><span style="font-size:x-small">=UserGrid}&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Label</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Content</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Country&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;28&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;12,141,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;label2_Copy&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">TextBox</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;23&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80,88,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;txtCountry&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;178&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Text</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;SelectedItem</span></span><span lang="EN-US"><span style="font-size:x-small">.Country,</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;ElementName</span></span><span lang="EN-US"><span style="font-size:x-small">=UserGrid}&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Label</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Content</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;City&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;28&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;12,86,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;label2_Copy1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">TextBox</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;23&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;80,115,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;txtSTate&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Width</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;178&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Text</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;{</span></span><span lang="EN-US"><span style="font-size:x-small">Binding</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;SelectedItem</span></span><span lang="EN-US"><span style="font-size:x-small">.State,</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;ElementName</span></span><span lang="EN-US"><span style="font-size:x-small">=UserGrid}&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;</span></span><span lang="EN-US"><span style="font-size:x-small">Label</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Content</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;State&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Grid.Row</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;1&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Height</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;28&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;HorizontalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Left&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;Margin</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;12,113,0,0&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">x</span></span><span lang="EN-US"><span style="font-size:x-small">:</span></span><span lang="EN-US"><span style="font-size:x-small">Name</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;label2_Copy2&quot;</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;VerticalAlignment</span></span><span lang="EN-US"><span style="font-size:x-small">=&quot;Top&quot;
 /&gt;<br>
</span></span><span lang="EN-US"><span style="font-size:x-small">&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span lang="EN-US"><span style="font-size:x-small">&lt;/</span></span><span lang="EN-US"><span style="font-size:x-small">Grid</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
&lt;/</span></span><span lang="EN-US"><span style="font-size:x-small">Window</span></span><span lang="EN-US"><span style="font-size:x-small">&gt;<br>
</span></span><span style="font-family:'Segoe UI'; font-size:x-small"><br>
Now let's run the application to see the output.<br>
<br>
<img src="-img2.jpg" border="0" alt="img2.jpg" width="522" height="479"><br>
Image 2.<br>
<br>
Now select any row in the grid and click the &quot;Update&quot; button.<br>
<br>
<img src="-img3.jpg" border="0" alt="img3.jpg" width="520" height="478"><br>
Image 3.<br>
<br>
<img src="-img4.jpg" border="0" alt="img4.jpg" width="521" height="476"><br>
Image 4.<br>
<br>
For more information, download the attached sample.</span>&nbsp; &nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; 
namespace MVVMInWPF.Model
{
    public class User : INotifyPropertyChanged
    {
        private int userId;
        private string firstName;
        private string lastName;
        private string city;
        private string state;
        private string country; 
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged(&quot;UserId&quot;);
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(&quot;FirstName&quot;);
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(&quot;LastName&quot;);
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged(&quot;City&quot;);
            }
        }
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged(&quot;State&quot;);
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged(&quot;Country&quot;);
            }
        } 
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }             
}

Now add a new class in ViewModel .

UserViewModel.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using MVVMInWPF.Model;
 
namespace MVVMInWPF.ViewModel
{
    class UserViewModel
    {
        private IList&lt;User&gt; _UsersList;
        public UserViewModel()
        {
            _UsersList = new List&lt;User&gt;
            {
                new User{UserId = 1,FirstName=&quot;Raj&quot;,LastName=&quot;Beniwal&quot;,City=&quot;Delhi&quot;,State=&quot;DEL&quot;,Country=&quot;INDIA&quot;},
                new User{UserId=2,FirstName=&quot;Mark&quot;,LastName=&quot;henry&quot;,City=&quot;New York&quot;, State=&quot;NY&quot;, Country=&quot;USA&quot;},
                new User{UserId=3,FirstName=&quot;Mahesh&quot;,LastName=&quot;Chand&quot;,City=&quot;Philadelphia&quot;, State=&quot;PHL&quot;, Country=&quot;USA&quot;},
                new User{UserId=4,FirstName=&quot;Vikash&quot;,LastName=&quot;Nanda&quot;,City=&quot;Noida&quot;, State=&quot;UP&quot;, Country=&quot;INDIA&quot;},
                new User{UserId=5,FirstName=&quot;Harsh&quot;,LastName=&quot;Kumar&quot;,City=&quot;Ghaziabad&quot;, State=&quot;UP&quot;, Country=&quot;INDIA&quot;},
                new User{UserId=6,FirstName=&quot;Reetesh&quot;,LastName=&quot;Tomar&quot;,City=&quot;Mumbai&quot;, State=&quot;MP&quot;, Country=&quot;INDIA&quot;},
                new User{UserId=7,FirstName=&quot;Deven&quot;,LastName=&quot;Verma&quot;,City=&quot;Palwal&quot;, State=&quot;HP&quot;, Country=&quot;INDIA&quot;},
                new User{UserId=8,FirstName=&quot;Ravi&quot;,LastName=&quot;Taneja&quot;,City=&quot;Delhi&quot;, State=&quot;DEL&quot;, Country=&quot;INDIA&quot;}            
            };
        }
        public IList&lt;User&gt; Users
        {
            get { return _UsersList; }
            set { _UsersList = value; }
        }
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater : ICommand
        {
            #region ICommand Members
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
            }
            #endregion
        }
    }
}

Now add a new view in the View folder.

MainPage.xaml

&lt;Window x:Class=&quot;MVVMInWPF.View.MainPage&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        Title=&quot;MainPage&quot; Height=&quot;485&quot; Width=&quot;525&quot;&gt;
    &lt;Grid Margin=&quot;0,0,0,20&quot;&gt;
        &lt;Grid.RowDefinitions&gt;
            &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
            &lt;RowDefinition Height=&quot;*&quot;/&gt;
            &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
        &lt;/Grid.RowDefinitions&gt;
        &lt;ListView Name=&quot;UserGrid&quot; Grid.Row=&quot;1&quot; Margin=&quot;4,178,12,13&quot;  ItemsSource=&quot;{Binding Users}&quot;  &gt;
            &lt;ListView.View&gt;
                &lt;GridView x:Name=&quot;grdTest&quot;&gt;
                    &lt;GridViewColumn Header=&quot;UserId&quot; DisplayMemberBinding=&quot;{Binding UserId}&quot;  Width=&quot;50&quot;/&gt;
                    &lt;GridViewColumn Header=&quot;First Name&quot; DisplayMemberBinding=&quot;{Binding FirstName}&quot;  Width=&quot;80&quot; /&gt;
                    &lt;GridViewColumn Header=&quot;Last Name&quot; DisplayMemberBinding=&quot;{Binding LastName}&quot; Width=&quot;100&quot; /&gt;
                    &lt;GridViewColumn Header=&quot;City&quot; DisplayMemberBinding=&quot;{Binding City}&quot; Width=&quot;80&quot; /&gt;
                    &lt;GridViewColumn Header=&quot;State&quot; DisplayMemberBinding=&quot;{Binding State}&quot; Width=&quot;80&quot; /&gt;
                    &lt;GridViewColumn Header=&quot;Country&quot; DisplayMemberBinding=&quot;{Binding Country}&quot; Width=&quot;100&quot; /&gt;
                &lt;/GridView&gt;
            &lt;/ListView.View&gt;
        &lt;/ListView&gt;
        &lt;TextBox Grid.Row=&quot;1&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;80,7,0,0&quot; Name=&quot;txtUserId&quot;VerticalAlignment=&quot;Top&quot; Width=&quot;178&quot; Text=&quot;{Binding ElementName=UserGrid,Path=SelectedItem.UserId}&quot; /&gt;
        &lt;TextBox Grid.Row=&quot;1&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;80,35,0,0&quot; Name=&quot;txtFirstName&quot;VerticalAlignment=&quot;Top&quot; Width=&quot;178&quot; Text=&quot;{Binding
ElementName=UserGrid,Path=SelectedItem.FirstName}&quot; /&gt;
        &lt;TextBox Grid.Row=&quot;1&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;80,62,0,0&quot; Name=&quot;txtLastName&quot;VerticalAlignment=&quot;Top&quot; Width=&quot;178&quot; Text=&quot;{Binding
ElementName=UserGrid,Path=SelectedItem.LastName}&quot; /&gt;
        &lt;Label Content=&quot;UserId&quot; Grid.Row=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;12,12,0,274&quot; Name=&quot;label1&quot; /&gt;
        &lt;Label Content=&quot;Last Name&quot; Grid.Row=&quot;1&quot; Height=&quot;28&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;12,60,0,0&quot;Name=&quot;label2&quot; VerticalAlignment=&quot;Top&quot; /&gt;
        &lt;Label Content=&quot;First Name&quot; Grid.Row=&quot;1&quot; Height=&quot;28&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;12,35,0,0&quot;Name=&quot;label3&quot; VerticalAlignment=&quot;Top&quot; /&gt;
        &lt;Button Content=&quot;Update&quot; Grid.Row=&quot;1&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;310,40,0,0&quot;Name=&quot;btnUpdate&quot; 
                VerticalAlignment=&quot;Top&quot; Width=&quot;141&quot;
                Command=&quot;{Binding Path=UpdateCommad}&quot;  /&gt;
        &lt;TextBox Grid.Row=&quot;1&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;80,143,0,0&quot; x:Name=&quot;txtCity&quot;VerticalAlignment=&quot;Top&quot; Width=&quot;178&quot; Text=&quot;{Binding SelectedItem.City, ElementName=UserGrid}&quot; /&gt;
        &lt;Label Content=&quot;Country&quot; Grid.Row=&quot;1&quot; Height=&quot;28&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;12,141,0,0&quot;x:Name=&quot;label2_Copy&quot; VerticalAlignment=&quot;Top&quot; /&gt;
        &lt;TextBox Grid.Row=&quot;1&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;80,88,0,0&quot; x:Name=&quot;txtCountry&quot;VerticalAlignment=&quot;Top&quot; Width=&quot;178&quot; Text=&quot;{Binding SelectedItem.Country, ElementName=UserGrid}&quot; /&gt;
        &lt;Label Content=&quot;City&quot; Grid.Row=&quot;1&quot; Height=&quot;28&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;12,86,0,0&quot;x:Name=&quot;label2_Copy1&quot; VerticalAlignment=&quot;Top&quot; /&gt;
        &lt;TextBox Grid.Row=&quot;1&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;80,115,0,0&quot; x:Name=&quot;txtSTate&quot;VerticalAlignment=&quot;Top&quot; Width=&quot;178&quot; Text=&quot;{Binding SelectedItem.State, ElementName=UserGrid}&quot; /&gt;
        &lt;Label Content=&quot;State&quot; Grid.Row=&quot;1&quot; Height=&quot;28&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;12,113,0,0&quot;x:Name=&quot;label2_Copy2&quot; VerticalAlignment=&quot;Top&quot; /&gt;
    &lt;/Grid&gt;
&lt;/Window&gt; snippet.</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVVMInWPF.Model&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;User&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;userId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;firstName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;lastName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;city;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;state;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;country;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;UserId&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;userId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;userId&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(<span class="cs__string">&quot;UserId&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FirstName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;firstName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;firstName&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(<span class="cs__string">&quot;FirstName&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;LastName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lastName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lastName&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(<span class="cs__string">&quot;LastName&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;City&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;city;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;city&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(<span class="cs__string">&quot;City&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;State&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;state;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;state&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(<span class="cs__string">&quot;State&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Country&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;country;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;country&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(<span class="cs__string">&quot;Country&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;INotifyPropertyChanged&nbsp;Members</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnPropertyChanged(<span class="cs__keyword">string</span>&nbsp;propertyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(PropertyChanged&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyChanged(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyChangedEventArgs(propertyName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
&nbsp;
Now&nbsp;add&nbsp;a&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;<span class="cs__keyword">in</span>&nbsp;ViewModel&nbsp;.&nbsp;
&nbsp;
UserViewModel.cs&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Input;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVVMInWPF.Model;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVVMInWPF.ViewModel&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;UserViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;IList&lt;User&gt;&nbsp;_UsersList;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;UserViewModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_UsersList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;User&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId&nbsp;=&nbsp;<span class="cs__number">1</span>,FirstName=<span class="cs__string">&quot;Raj&quot;</span>,LastName=<span class="cs__string">&quot;Beniwal&quot;</span>,City=<span class="cs__string">&quot;Delhi&quot;</span>,State=<span class="cs__string">&quot;DEL&quot;</span>,Country=<span class="cs__string">&quot;INDIA&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId=<span class="cs__number">2</span>,FirstName=<span class="cs__string">&quot;Mark&quot;</span>,LastName=<span class="cs__string">&quot;henry&quot;</span>,City=<span class="cs__string">&quot;New&nbsp;York&quot;</span>,&nbsp;State=<span class="cs__string">&quot;NY&quot;</span>,&nbsp;Country=<span class="cs__string">&quot;USA&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId=<span class="cs__number">3</span>,FirstName=<span class="cs__string">&quot;Mahesh&quot;</span>,LastName=<span class="cs__string">&quot;Chand&quot;</span>,City=<span class="cs__string">&quot;Philadelphia&quot;</span>,&nbsp;State=<span class="cs__string">&quot;PHL&quot;</span>,&nbsp;Country=<span class="cs__string">&quot;USA&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId=<span class="cs__number">4</span>,FirstName=<span class="cs__string">&quot;Vikash&quot;</span>,LastName=<span class="cs__string">&quot;Nanda&quot;</span>,City=<span class="cs__string">&quot;Noida&quot;</span>,&nbsp;State=<span class="cs__string">&quot;UP&quot;</span>,&nbsp;Country=<span class="cs__string">&quot;INDIA&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId=<span class="cs__number">5</span>,FirstName=<span class="cs__string">&quot;Harsh&quot;</span>,LastName=<span class="cs__string">&quot;Kumar&quot;</span>,City=<span class="cs__string">&quot;Ghaziabad&quot;</span>,&nbsp;State=<span class="cs__string">&quot;UP&quot;</span>,&nbsp;Country=<span class="cs__string">&quot;INDIA&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId=<span class="cs__number">6</span>,FirstName=<span class="cs__string">&quot;Reetesh&quot;</span>,LastName=<span class="cs__string">&quot;Tomar&quot;</span>,City=<span class="cs__string">&quot;Mumbai&quot;</span>,&nbsp;State=<span class="cs__string">&quot;MP&quot;</span>,&nbsp;Country=<span class="cs__string">&quot;INDIA&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId=<span class="cs__number">7</span>,FirstName=<span class="cs__string">&quot;Deven&quot;</span>,LastName=<span class="cs__string">&quot;Verma&quot;</span>,City=<span class="cs__string">&quot;Palwal&quot;</span>,&nbsp;State=<span class="cs__string">&quot;HP&quot;</span>,&nbsp;Country=<span class="cs__string">&quot;INDIA&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;User{UserId=<span class="cs__number">8</span>,FirstName=<span class="cs__string">&quot;Ravi&quot;</span>,LastName=<span class="cs__string">&quot;Taneja&quot;</span>,City=<span class="cs__string">&quot;Delhi&quot;</span>,&nbsp;State=<span class="cs__string">&quot;DEL&quot;</span>,&nbsp;Country=<span class="cs__string">&quot;INDIA&quot;</span>}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IList&lt;User&gt;&nbsp;Users&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_UsersList;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_UsersList&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;ICommand&nbsp;mUpdater;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;UpdateCommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(mUpdater&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mUpdater&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Updater();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;mUpdater;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mUpdater&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Updater&nbsp;:&nbsp;ICommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;ICommand&nbsp;Members</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;CanExecute(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;EventHandler&nbsp;CanExecuteChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Execute(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
Now&nbsp;add&nbsp;a&nbsp;<span class="cs__keyword">new</span>&nbsp;view&nbsp;<span class="cs__keyword">in</span>&nbsp;the&nbsp;View&nbsp;folder.&nbsp;
&nbsp;
MainPage.xaml&nbsp;
&nbsp;
&lt;Window&nbsp;x:Class=<span class="cs__string">&quot;MVVMInWPF.View.MainPage&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="cs__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="cs__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="cs__string">&quot;MainPage&quot;</span>&nbsp;Height=<span class="cs__string">&quot;485&quot;</span>&nbsp;Width=<span class="cs__string">&quot;525&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Margin=<span class="cs__string">&quot;0,0,0,20&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="cs__string">&quot;Auto&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="cs__string">&quot;*&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="cs__string">&quot;Auto&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ListView&nbsp;Name=<span class="cs__string">&quot;UserGrid&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;4,178,12,13&quot;</span>&nbsp;&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;Users}&quot;</span>&nbsp;&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ListView.View&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GridView&nbsp;x:Name=<span class="cs__string">&quot;grdTest&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GridViewColumn&nbsp;Header=<span class="cs__string">&quot;UserId&quot;</span>&nbsp;DisplayMemberBinding=<span class="cs__string">&quot;{Binding&nbsp;UserId}&quot;</span>&nbsp;&nbsp;Width=<span class="cs__string">&quot;50&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GridViewColumn&nbsp;Header=<span class="cs__string">&quot;First&nbsp;Name&quot;</span>&nbsp;DisplayMemberBinding=<span class="cs__string">&quot;{Binding&nbsp;FirstName}&quot;</span>&nbsp;&nbsp;Width=<span class="cs__string">&quot;80&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GridViewColumn&nbsp;Header=<span class="cs__string">&quot;Last&nbsp;Name&quot;</span>&nbsp;DisplayMemberBinding=<span class="cs__string">&quot;{Binding&nbsp;LastName}&quot;</span>&nbsp;Width=<span class="cs__string">&quot;100&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GridViewColumn&nbsp;Header=<span class="cs__string">&quot;City&quot;</span>&nbsp;DisplayMemberBinding=<span class="cs__string">&quot;{Binding&nbsp;City}&quot;</span>&nbsp;Width=<span class="cs__string">&quot;80&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GridViewColumn&nbsp;Header=<span class="cs__string">&quot;State&quot;</span>&nbsp;DisplayMemberBinding=<span class="cs__string">&quot;{Binding&nbsp;State}&quot;</span>&nbsp;Width=<span class="cs__string">&quot;80&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GridViewColumn&nbsp;Header=<span class="cs__string">&quot;Country&quot;</span>&nbsp;DisplayMemberBinding=<span class="cs__string">&quot;{Binding&nbsp;Country}&quot;</span>&nbsp;Width=<span class="cs__string">&quot;100&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GridView&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.View&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;80,7,0,0&quot;</span>&nbsp;Name=<span class="cs__string">&quot;txtUserId&quot;</span>VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;178&quot;</span>&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;ElementName=UserGrid,Path=SelectedItem.UserId}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;80,35,0,0&quot;</span>&nbsp;Name=<span class="cs__string">&quot;txtFirstName&quot;</span>VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;178&quot;</span>&nbsp;Text=&quot;{Binding&nbsp;
ElementName=UserGrid,Path=SelectedItem.FirstName}&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;80,62,0,0&quot;</span>&nbsp;Name=<span class="cs__string">&quot;txtLastName&quot;</span>VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;178&quot;</span>&nbsp;Text=&quot;{Binding&nbsp;
ElementName=UserGrid,Path=SelectedItem.LastName}&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Content=<span class="cs__string">&quot;UserId&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;12,12,0,274&quot;</span>&nbsp;Name=<span class="cs__string">&quot;label1&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Content=<span class="cs__string">&quot;Last&nbsp;Name&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;28&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;12,60,0,0&quot;</span>Name=<span class="cs__string">&quot;label2&quot;</span>&nbsp;VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Content=<span class="cs__string">&quot;First&nbsp;Name&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;28&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;12,35,0,0&quot;</span>Name=<span class="cs__string">&quot;label3&quot;</span>&nbsp;VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Button&nbsp;Content=<span class="cs__string">&quot;Update&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;310,40,0,0&quot;</span>Name=<span class="cs__string">&quot;btnUpdate&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;141&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Command=<span class="cs__string">&quot;{Binding&nbsp;Path=UpdateCommad}&quot;</span>&nbsp;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;80,143,0,0&quot;</span>&nbsp;x:Name=<span class="cs__string">&quot;txtCity&quot;</span>VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;178&quot;</span>&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;SelectedItem.City,&nbsp;ElementName=UserGrid}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Content=<span class="cs__string">&quot;Country&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;28&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;12,141,0,0&quot;</span>x:Name=<span class="cs__string">&quot;label2_Copy&quot;</span>&nbsp;VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;80,88,0,0&quot;</span>&nbsp;x:Name=<span class="cs__string">&quot;txtCountry&quot;</span>VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;178&quot;</span>&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;SelectedItem.Country,&nbsp;ElementName=UserGrid}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Content=<span class="cs__string">&quot;City&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;28&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;12,86,0,0&quot;</span>x:Name=<span class="cs__string">&quot;label2_Copy1&quot;</span>&nbsp;VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;80,115,0,0&quot;</span>&nbsp;x:Name=<span class="cs__string">&quot;txtSTate&quot;</span>VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;178&quot;</span>&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;SelectedItem.State,&nbsp;ElementName=UserGrid}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Content=<span class="cs__string">&quot;State&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;Height=<span class="cs__string">&quot;28&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;12,113,0,0&quot;</span>x:Name=<span class="cs__string">&quot;label2_Copy2&quot;</span>&nbsp;VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&lt;/Window&gt;&nbsp;snippet.</pre>
</div>
</div>
</div>
