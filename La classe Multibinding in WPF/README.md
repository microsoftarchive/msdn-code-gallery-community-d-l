# La classe Multibinding in WPF
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- VB.Net
- C# Language
- ObservableCollection
- MultiBinding
## Topics
- C#
- WPF
- XAML
- VB.Net
- XAML MultiBinding
- ObservableCollections
## Updated
- 07/20/2013
## Description

<h1>Introduction</h1>
<p><em><span class="hps">This example</span> <span class="hps">is</span> <span class="hps">
how to</span> <span class="hps">use the</span> <span class="hps">MultiBinding</span>
<span class="hps">in a</span> <span class="hps">wpf</span> <span class="hps">
application</span>.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><span class="hps">This example</span> <span class="hps">was</span> <span class="hps">
created with</span> <span class="hps">VisualStudio</span> <span class="hps">2012</span>
<span class="hps">Professional</span> <span class="hps">updated</span> <span class="hps">
the Update</span> <span class="hps">3 and</span> <span class="hps">framemork</span>
<span class="hps">4.5.</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span class="hps">In this simple example</span><span>&nbsp;</span><span class="hps">we will see how</span><span>&nbsp;</span><span class="hps">to use MultiBinding</span><span>.</span><span>&nbsp;</span><span class="hps">MultiBinding allows</span><span>&nbsp;</span><span class="hps">you
 to bind a</span><span>&nbsp;</span><span class="hps">target property</span><span>&nbsp;</span><span class="hps">to a list</span><span>&nbsp;</span><span class="hps">of source properties</span><span>&nbsp;</span><span class="hps">and</span><span>&nbsp;</span><span class="hps">then
 apply logic</span><span>&nbsp;</span><span class="hps">to produce a value</span><span>&nbsp;</span><span class="hps">with</span><span class="hps">the given inputs</span><span>.</span><span>&nbsp;</span><span class="hps">This</span><span>&nbsp;</span><span class="hps">example
 shows how to</span><span>&nbsp;</span><span class="hps">use MultiBinding</span><span>&nbsp;</span><span class="hps">to view</span><span>&nbsp;</span><span class="hps">more properties</span><span>&nbsp;</span><span class="hps">of the</span><span>&nbsp;</span><span class="hps">Customer</span><span>&nbsp;</span><span class="hps">class</span><span>&nbsp;</span><span class="hps">in
 a single</span><span>&nbsp;</span><span class="hps">row in</span><span>&nbsp;</span><span class="hps">a ListBox control.</span><br>
<br>
<span class="hps">We use</span><span>&nbsp;</span><span class="hps">an</span><span>&nbsp;</span><span class="hps">ObservableCollection</span><span>, which</span><span>&nbsp;</span><span class="hps">represents a</span><span>&nbsp;</span><span class="hps">dynamic</span><span>&nbsp;</span><span class="hps">data
 collection</span><span>&nbsp;</span><span class="hps">that provides notifications</span><span>&nbsp;</span><span class="hps">when items are</span><span>&nbsp;</span><span class="hps">added, removed</span><span>,</span><span>&nbsp;</span><span class="hps">or</span><span>&nbsp;</span><span class="hps">if
 the list</span><span>&nbsp;</span><span class="hps">of all is</span><span>&nbsp;</span><span class="hps">updated</span><span>.</span><br>
<br>
<span class="hps">The</span><span>&nbsp;</span><span class="hps">codebheind</span><span>&nbsp;</span><span class="hps">will implement</span><span>&nbsp;</span><span class="hps">by</span><span>&nbsp;</span><span class="hps">going to</span><span>&nbsp;</span><span class="hps">implement</span><span>&nbsp;</span><span class="hps">a
 class called</span><span>&nbsp;</span><span class="hps">Customer</span><span>,</span><span>&nbsp;</span><span class="hps">in turn composed of</span><span>&nbsp;</span><span class="hps">from 5</span><span>&nbsp;</span><span class="hps">properties</span><span>,</span><span>&nbsp;</span><span class="hps">but
 we see the</span><span>&nbsp;VB NET</span><span class="hps">&nbsp;code</span><span>.</span>&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections.ObjectModel&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="visualBasic__keyword">Class</span>&nbsp;MainWindow&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ButtonClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Creiamo&nbsp;una&nbsp;ObservableCollection&nbsp;di&nbsp;tipo&nbsp;Customer&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;andanDo&nbsp;a&nbsp;valorizzare&nbsp;le&nbsp;sue&nbsp;propriet&agrave;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;customerList&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ObservableCollection(<span class="visualBasic__keyword">Of</span>&nbsp;Customer)()&nbsp;From&nbsp;{&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Customer()&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Carmelo&quot;</span>,&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Surname&nbsp;=&nbsp;<span class="visualBasic__string">&quot;La&nbsp;Monica&quot;</span>,&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Address&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Indirizzo&quot;</span>,&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Email&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Email&quot;</span>,&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.PhoneNumber&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Telefono&quot;</span>&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;_&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegnamo&nbsp;alla&nbsp;propriet&agrave;&nbsp;ItemSource&nbsp;del&nbsp;controllo&nbsp;ListBox&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'il&nbsp;contenuto&nbsp;di&nbsp;customerlist&nbsp;</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listbox1.ItemsSource&nbsp;=&nbsp;customerList&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;La&nbsp;classe&nbsp;Customer&nbsp;con&nbsp;le&nbsp;quattro&nbsp;propriet&agrave;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Customer&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Name()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_mName&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mName&nbsp;=&nbsp;value&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_mName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Surname()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_mSurname&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mSurname&nbsp;=&nbsp;value&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_mSurname&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;PhoneNumber()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_mPhoneNumber&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mPhoneNumber&nbsp;=&nbsp;value&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_mPhoneNumber&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Address()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_mAddress&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mAddress&nbsp;=&nbsp;value&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_mAddress&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Email()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_mEmail&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mEmail&nbsp;=&nbsp;value&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_mEmail&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<p><em><span class="hps">The goal</span>&nbsp;<span class="hps">as stated</span>&nbsp;<span class="hps">and</span>&nbsp;<span class="hps">go to display</span>&nbsp;<span class="hps">in a</span>&nbsp;<span class="hps">ListBox control</span>&nbsp;<span class="hps">the
 name and</span>&nbsp;<span class="hps">surname of a person</span>&nbsp;<span class="hps">for each row</span>,&nbsp;<span class="hps">since the</span>&nbsp;<span class="hps">DisplayMemberPath property</span>&nbsp;<span class="hps">allows us to</span>&nbsp;<span class="hps">display
 only</span>&nbsp;<span class="hps">one property</span><span class="hps">at a time</span>, not two, here&nbsp;<span class="hps">we are</span>&nbsp;<span class="hps">aid</span>&nbsp;<span class="hps">in</span>&nbsp;<span class="hps">the</span>&nbsp;<span class="hps">MultiBinding</span>,&nbsp;<span class="hps">but
 let's see</span>&nbsp;<span class="hps">how to implement it</span>&nbsp;<span class="hps">in the</span>&nbsp;<span class="hps">declarative</span>&nbsp;<span class="hps">XAML</span>&nbsp;<span class="hps">code</span>.</em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml">Window&nbsp;x:Class=&quot;WpfApplication1.MainWindow&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=&quot;MainWindow&quot;&nbsp;Height=&quot;350&quot;&nbsp;Width=&quot;525&quot;&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;ListBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;listbox1&quot;</span><span class="xaml__attr_name">IsSynchronizedWithCurrentItem</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=&nbsp;<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;100&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;63,49,0,0&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;213&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;ListBox</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;TextBlock</span><span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;TextBlock</span>.Text<span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;MultiBinding</span><span class="xaml__attr_name">StringFormat</span>=<span class="xaml__attr_value">&quot;{}{0}&nbsp;{1}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;Binding</span><span class="xaml__attr_name">Path</span>=<span class="xaml__attr_value">&quot;Name&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;Binding</span><span class="xaml__attr_name">Path</span>=<span class="xaml__attr_value">&quot;Surname&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/MultiBinding&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TextBlock.Text&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/TextBlock&gt;</span><span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListBox.ItemTemplate&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListBox&gt;</span><span class="xaml__tag_start">&lt;Button</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Button&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;63,178,0,0&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span><span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;ButtonClick&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/Grid&gt;</span><span class="xaml__tag_end">&lt;/Window&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><em><span class="hps">We define</span>&nbsp;<span class="hps">a ListBox</span>&nbsp;<span class="hps">and create a</span>&nbsp;<span class="hps">ItemTemplate</span>,&nbsp;<span class="hps">on the inside as</span>&nbsp;<span class="hps">you can</span>&nbsp;<span class="hps">see
 we have</span>&nbsp;<span class="hps">added</span>&nbsp;<span class="hps">a</span>&nbsp;<span class="hps">control</span>&nbsp;<span class="hps">TextBock</span>, the latter&nbsp;<span class="hps">implements the</span>&nbsp;<span class="hps">MultiBinding</span>&nbsp;<span class="hps">so
 that we can</span>&nbsp;<span class="hps">then</span>&nbsp;<span class="hps">define</span>&nbsp;<span class="hps">which properties</span>&nbsp;<span class="hps">we want to</span><span class="hps">see</span>, it also performs&nbsp;<span class="hps">display
 formatting</span>&nbsp;<span class="hps">StringFormat</span>&nbsp;<span class="hps x_atn">= &quot;{</span>}&nbsp;<span class="hps x_atn">{0} {</span><span class="atn">1} &quot;</span>to display&nbsp;<span class="hps">on the</span>&nbsp;<span class="hps">same
 line as</span>&nbsp;<span class="hps">the Name and</span>&nbsp;<span class="hps">Surname</span>&nbsp;<span class="hps">of the</span>&nbsp;<span class="hps">Customer</span>&nbsp;<span class="hps">class</span>.<br>
<span class="hps">At runtime</span>&nbsp;<span class="hps">by executing</span>&nbsp;<span class="hps">this code</span>&nbsp;<span class="hps">when you press the</span>&nbsp;<span class="hps">button</span>&nbsp;<span class="hps">Button1</span>&nbsp;<span class="hps">will</span>&nbsp;<span class="hps">this
 situation.</span></em></p>
<p><span><br>
<span>&nbsp;<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/7624.Nuova-immagine-bitmap.bmp"><img src="-7624.nuova-immagine-bitmap.bmp" alt=" "></a></span><span><br>
<br>
</span><em><span class="hps">Here's how it</span>&nbsp;<span class="hps">will appear</span>&nbsp;<span class="hps">in the</span>&nbsp;<span class="hps">ListBox</span>&nbsp;<span class="hps">value</span>&nbsp;<span class="hps">consists of</span>&nbsp;<span class="hps">two
 properties of the</span>&nbsp;<span class="hps">Customer</span>&nbsp;<span class="hps">class</span>,&nbsp;<span class="hps">without the</span>&nbsp;<span class="hps">MultiBinding</span>&nbsp;<span class="hps">we</span>&nbsp;<span class="hps">had
 to</span>&nbsp;<span class="hps">resort to other means</span>,&nbsp;<span class="hps">such as</span>&nbsp;<span class="hps">FirstnameLastname</span>&nbsp;<span class="hps">define a property</span>&nbsp;<span class="hps">in the</span><span class="hps">Customer
 class</span>&nbsp;<span class="hps">and going</span>&nbsp;<span class="hps">to appreciate it</span>&nbsp;<span class="hps">with</span>&nbsp;<span class="hps">the</span>&nbsp;<span class="hps">name,</span>&nbsp;<span class="hps">then</span>&nbsp;<span class="hps">assign</span>&nbsp;<span class="hps">or</span>&nbsp;<span class="hps">binding</span>&nbsp;<span class="hps">to
 the ListBox control</span>&nbsp;<span class="hps">in</span>&nbsp;<span class="hps">XAML</span>,&nbsp;<span class="hps">or</span>&nbsp;<span class="hps">enhance it</span>&nbsp;<span class="hps">by</span>&nbsp;<span class="hps">using the</span>&nbsp;<span class="hps">codebheind</span>&nbsp;<span class="hps">DisplayMemberPath
 property</span>.</em></span></p>
<ul>
</ul>
<h1>More Information</h1>
<p>For any clarification you can contact these references</p>
<p><em>Piero Sbressa<br>
<a href="mailto:pierosbressa@crystalweb.it">pierosbressa@crystalweb.it</a><br>
<a href="http://www.crystalweb.it/">www.crystalweb.it</a><br>
&nbsp;<br>
&nbsp;<br>
Carmelo La Monica<br>
<a href="http://community.visual-basic.it/carmelolamonica/default.aspx">http://community.visual-basic.it/carmelolamonica/default.aspx</a></em></p>
