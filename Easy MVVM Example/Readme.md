# Easy MVVM Example
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- Data Binding
- events
- MVVM
- POCO
- INotifyPropertyChanged
- Attached Properties
- WPF Binding
- DataTemplates
- Dependency Properties
- DataContext
- DependencyObject
- Business Objects
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<p>This project will give&nbsp;you crash course on WPF MVVM that you can do in your lunch break! Everything you need to know about binding, INotifyPropertyChanged, Dependency Objects &amp; Properites, POCO objects, Business Objects, Attached Properties and
 much more!</p>
<p>&nbsp;</p>
<p>For a full discussion and detailed breakdown of this project, please read below</p>
<p><span style="font-size:small"><strong><a href="http://social.technet.microsoft.com/wiki/contents/articles/13536.easy-mvvm-examples.aspx">http://social.technet.microsoft.com/wiki/contents/articles/13536.easy-mvvm-examples.aspx</a></strong></span></p>
<h1><span>&nbsp;</span></h1>
<h1><span>Building the Sample</span></h1>
<p>Just download, unzip, open and run!</p>
<p>&nbsp;</p>
<h1><span style="font-size:20px">Description</span></h1>
<p>This project consists of five windows, with practicly no code behind.</p>
<p>All application&nbsp;functionality and navigation is done by the ViewModels</p>
<p>&nbsp;</p>
<h2><strong>MainWindow - Classic INotifyPropertyChanged</strong></h2>
<p><img id="66203" src="66203-mvvm1.png" alt="" width="456" height="395"></p>
<p>This is the classic MVVM configuration,&nbsp;implementing INotifyPropertyChanged in a base class (ViewModelBase)</p>
<p>The ViewModel is attached by the View itself, in XAML. This&nbsp;is fine&nbsp;if the ViewModel constructor has no parameters.</p>
<p>It has a ListBox, DataGrid and ComboBox all with ItemsSource to the same collection, and the same SeletedItem.</p>
<p>As you change selected Person, you will see all three controls change together.</p>
<p>A TextBox and TextBlock share the same&nbsp;property, and changes in the TextBox reflect in the TextBlock.</p>
<p>Click the button to add a user, it shows in all three controls.</p>
<p>Closing the Window is just a nasty code behind hack, the simplest and worst of the examples.</p>
<p>&nbsp;</p>
<h2><strong>Window1</strong></h2>
<p><img id="66204" src="66204-mvvm2.png" alt="" width="345" height="304"></p>
<p>This window simply shows how you can attach the ViewModel to the DataContext in code, done by MainWindow.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var win = new Window1 { DataContext = new ViewModelWindow1(tb1.Text) };</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;win&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Window1&nbsp;<span class="js__brace">{</span>&nbsp;DataContext&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ViewModelWindow1(tb1.Text)&nbsp;<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>This ViewModel is derived from&nbsp;ViewModelMain, with an extra public property and command to pull from the base class and update the new property and UI.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Button Content=&quot;Change Text&quot; Command=&quot;{Binding ChangeTextCommand}&quot; CommandParameter=&quot;{Binding SelectedItem, ElementName=dg1}&quot;/&gt;</pre>
<div class="preview">
<pre class="js">&lt;Button&nbsp;Content=<span class="js__string">&quot;Change&nbsp;Text&quot;</span>&nbsp;Command=<span class="js__string">&quot;{Binding&nbsp;ChangeTextCommand}&quot;</span>&nbsp;CommandParameter=<span class="js__string">&quot;{Binding&nbsp;SelectedItem,&nbsp;ElementName=dg1}&quot;</span>/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">void ChangeText(object selectedItem)
{
    //Setting the PUBLIC property 'TestText', so PropertyChanged event is fired
    if (selectedItem == null)
        TestText = &quot;Please select a person&quot;; 
    else
    {
        var person = selectedItem as Person;
        TestText = person.FirstName &#43; &quot; &quot; &#43; person.LastName;
    }
}</pre>
<div class="preview">
<pre class="js"><span class="js__operator">void</span>&nbsp;ChangeText(object&nbsp;selectedItem)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Setting&nbsp;the&nbsp;PUBLIC&nbsp;property&nbsp;'TestText',&nbsp;so&nbsp;PropertyChanged&nbsp;event&nbsp;is&nbsp;fired</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(selectedItem&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TestText&nbsp;=&nbsp;<span class="js__string">&quot;Please&nbsp;select&nbsp;a&nbsp;person&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;person&nbsp;=&nbsp;selectedItem&nbsp;as&nbsp;Person;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TestText&nbsp;=&nbsp;person.FirstName&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;person.LastName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>You can see I'm having to check for null here, &quot;boiler plating&quot; we could do without, as shown in CanExecute below.</p>
<p>&nbsp;</p>
<p>Closing this Window uses the nicest way to do it, using an Attached&nbsp;Behaviour (Property)&nbsp;with a binding to a flag in the ViewModelBase. In our ViewModel we simply call CloseWindow()</p>
<p>&nbsp;</p>
<h2><strong>Window 2</strong></h2>
<p><img id="66205" src="66205-mvvm3.png" alt="" width="316" height="295"></p>
<p>This example shows the alternative to INotifyPropertyChanged - DependencyObject and Dependency Properties.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public Person SelectedPerson
{
    get { return (Person)GetValue(SelectedPersonProperty); }
    set { SetValue(SelectedPersonProperty, value); }
}

// Using a DependencyProperty as the backing store for SelectedPerson.  This enables animation, styling, binding, etc...
public static readonly DependencyProperty SelectedPersonProperty =
    DependencyProperty.Register(&quot;SelectedPerson&quot;, typeof(Person), typeof(ViewModelWindow2), new UIPropertyMetadata(null));</pre>
<div class="preview">
<pre class="js">public&nbsp;Person&nbsp;SelectedPerson&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;(Person)GetValue(SelectedPersonProperty);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;<span class="js__brace">{</span>&nbsp;SetValue(SelectedPersonProperty,&nbsp;value);&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Using&nbsp;a&nbsp;DependencyProperty&nbsp;as&nbsp;the&nbsp;backing&nbsp;store&nbsp;for&nbsp;SelectedPerson.&nbsp;&nbsp;This&nbsp;enables&nbsp;animation,&nbsp;styling,&nbsp;binding,&nbsp;etc...</span>&nbsp;
public&nbsp;static&nbsp;readonly&nbsp;DependencyProperty&nbsp;SelectedPersonProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="js__string">&quot;SelectedPerson&quot;</span>,&nbsp;<span class="js__operator">typeof</span>(Person),&nbsp;<span class="js__operator">typeof</span>(ViewModelWindow2),&nbsp;<span class="js__operator">new</span>&nbsp;UIPropertyMetadata(null));</pre>
</div>
</div>
</div>
<div class="endscriptcode">Dependency Properties also fire PropertyChanged events, and also have callback and coerce delegates.</div>
<p>&nbsp;</p>
<p>The only drawback to Dependency Properties for general MVVM use is they need to be handled on the UI layer.</p>
<p>This example also shows how a command can also control if a button is enabled, through it's CanExecute delegate.</p>
<p>As we are not using the parameter, but relyng on the ViewModel selected item, if there is none,&nbsp;the CanExecute method returns false, which disables the button. All done by behaviour, no messy code or boiler plating.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public ViewModelWindow2()
{
    People = FakeDatabaseLayer.GetPeopleFromDatabase();
    NextExampleCommand = new RelayCommand(NextExample, NextExample_CanExecute);
}

bool NextExample_CanExecute(object parameter)
{
    return SelectedPerson != null;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;ViewModelWindow2()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;People&nbsp;=&nbsp;FakeDatabaseLayer.GetPeopleFromDatabase();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;NextExampleCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RelayCommand(NextExample,&nbsp;NextExample_CanExecute);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">bool</span>&nbsp;NextExample_CanExecute(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;SelectedPerson&nbsp;!=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">In this example, we still use the Attached Property in the Window XAML, to close the Window, but the property is another Dependency Property in the ViewModel.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode"><strong>Window 3</strong></h2>
<div class="endscriptcode"><img id="66206" src="66206-mvvm4.png" alt="" width="437" height="363"></div>
<div class="endscriptcode">A POCO class in WPF/MVVM terms is one that does not provide any PropertyChanged events. This would usually be legacy code modules, or&nbsp;converting from WinForms.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">If a POCO class is used in the classic INPC setup, things start to go wrong.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">At first, everything seems fine. Selected item&nbsp;is&nbsp;updated in all, you can change&nbsp;properties of existing people, and add new people through the DataGrid.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">However, the textbox should actually be showing a timestamp, as set by the code behind Dispatcher Timer.</div>
<div class="endscriptcode">Also, clicking the button to add a new person does not seem to work, until you try to add a user in the DataGrid.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode"><strong>Window 4</strong></h2>
<div class="endscriptcode"><img id="66207" src="66207-mvvm5.png" alt="" width="437" height="386"></div>
<div class="endscriptcode">This example is simply an extension to the previous example, where I have added the ViewModelBase and PropertyChanged event on the timer property. Now you can see the time updating.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode"><strong>Window 5</strong></h2>
<div class="endscriptcode"><img id="66208" src="66208-mvvm6.png" alt="" width="537" height="379"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">What if you have a business object that handles all the work, like a database layer or web service?</div>
<div class="endscriptcode">This&nbsp;may therefore be&nbsp;a closed object that you cannot enrich with INPC on it's properties.</div>
<div class="endscriptcode">In this case you have to fall back on wrappers and polling.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">This example shows a complete and virtually codeless master/detail, edit &amp; add control.</div>
<p>&nbsp;</p>
<p>For a full discussion and detailed breakdown of this project, please read below:</p>
<p><span style="font-size:small"><strong><a href="http://social.technet.microsoft.com/wiki/contents/articles/13536.easy-mvvm-examples.aspx">http://social.technet.microsoft.com/wiki/contents/articles/13536.easy-mvvm-examples.aspx</a></strong></span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
