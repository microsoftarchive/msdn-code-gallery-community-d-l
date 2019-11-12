# Learn Simple MVVM and Command Bindings
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- WPF
- ViewModel pattern (MVVM)
- MVVM
- Visual C#
## Topics
- WPF
- ViewModel pattern (MVVM)
- MVVM
- Visual C#
## Updated
- 04/20/2015
## Description

<h1>Description :</h1>
<p>As we know that the most powerful WPF&rsquo;s framework (SL as well) can be built with the most optimal architectural pattern the MVVM. The MVVM is collaborative of Model, View and View Model. And the MVVM is special introduce to simplify the event driven
 programming of user interface. The MVVM and Presentation Model both derived from Model View Controller.</p>
<p>&nbsp;</p>
<p><strong>MVVM pattern component</strong></p>
<p><strong>Model</strong>: It&rsquo;s a domain model that represent the real time entity or an object as a data access layer</p>
<p><strong>View</strong>: It&rsquo;s a User interface probably a front end design</p>
<p><strong>&nbsp;View Model</strong>: It&rsquo;s a simply a data representation of Model through with public properties and commands</p>
<p><strong>Binder</strong>: It&rsquo;s a data and command binding between View and View Model for Model</p>
<p>through binder, view model, and any business layers features to validate incoming data. The result is that the model and framework drive as much of the operations as possible, customize application logic which directly &nbsp;controling the view</p>
<p><strong>Structure of MVVM</strong></p>
<p><img id="136675" src="136675-mvvm.png" alt="" width="727" height="608"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Model</strong></p>
<p>Here i have used a person as model that contains name and age of the person</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;MVVM&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Person&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Age&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><strong><em>View</em></strong></p>
<p>It is a User inderface design. Here i used to list out the persons in List view</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;MVVM.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:MVVM&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;MainWindow&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;350&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;525&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ListViewPerson&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Name}&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/TextBlock&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Age}&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/TextBlock&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListView&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><strong><em>View Model</em></strong></p>
<p>View model consist a collection of data that binded with UI i.e., View</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;MVVM&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Person&gt;&nbsp;People;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ViewModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;Person&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name=<span class="cs__string">&quot;Thiruveesan&quot;</span>,&nbsp;Age=<span class="cs__number">20</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Marutheesan&quot;</span>,&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">21</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sharveshan&quot;</span>,&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">22</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Kailash&quot;</span>,&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">23</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><strong>Add Data Context</strong></p>
<p>&nbsp;</p>
<p><strong>&nbsp;</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;ViewModel&nbsp;vm&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ViewModel();&nbsp;
&nbsp;MainWindow&nbsp;mw&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MainWindow();&nbsp;
&nbsp;mw.DataContext&nbsp;=&nbsp;vm;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong>
<p></p>
<p>&nbsp;</p>
<p><strong>Binder:</strong></p>
<p>Here we are using command binding to perfrom an operion while button click</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;MVVM&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Person&gt;&nbsp;People;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ViewModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;Person&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name=<span class="cs__string">&quot;Thiruveesan&quot;</span>,&nbsp;Age=<span class="cs__number">20</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Marutheesan&quot;</span>,&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">21</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sharveshan&quot;</span>,&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">22</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Kailash&quot;</span>,&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">23</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;ICommand&nbsp;_clickCommand;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;ClickCommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_clickCommand&nbsp;??&nbsp;(_clickCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CommandHandler(()&nbsp;=&gt;&nbsp;MyAction(),&nbsp;<span class="cs__keyword">true</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MyAction()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Magesh&quot;</span>,&nbsp;Age&nbsp;=&nbsp;<span class="cs__number">24</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;People.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CommandHandler&nbsp;:&nbsp;ICommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Action&nbsp;_action;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;_canExecute;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CommandHandler(Action&nbsp;action,&nbsp;<span class="cs__keyword">bool</span>&nbsp;canExecute)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_action&nbsp;=&nbsp;action;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_canExecute&nbsp;=&nbsp;canExecute;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;CanExecute(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_canExecute;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;EventHandler&nbsp;CanExecuteChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Execute(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_action();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Bottom&quot;</span>&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ClickCommand}&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/Button&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><img id="136680" src="136680-mvvm1.png" alt="" width="463" height="699"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong><br>
</strong></p>
