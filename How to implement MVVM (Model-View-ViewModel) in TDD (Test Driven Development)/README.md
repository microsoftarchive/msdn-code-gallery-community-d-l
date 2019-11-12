# How to implement MVVM (Model-View-ViewModel) in TDD (Test Driven Development)
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
- User Interface
- WPF
- ViewModel pattern (MVVM)
- TEST
- MVVM
- TDD
## Topics
- ViewModel pattern (MVVM)
- Unit Testing
- MVVM
- TDD
## Updated
- 06/29/2011
## Description

<h1>What is MVVM</h1>
<p>The Model View ViewModel (MVVM) is an architectural pattern used in software engineering that originated from Microsoft as a specialization of the Presentation Model design pattern introduced by Martin Fowler.<br>
<br>
Largely based on the Model-view-controller pattern (MVC), MVVM is targeted at modern UI development platforms (Windows Presentation Foundation, or WPF, and Silverlight).<br>
<br>
MVVM was designed to make use of specific functions in WPF to better facilitate the separation of View layer development from the rest of the pattern by removing virtually all &ldquo;code-behind&rdquo; from the View layer.<br>
<br>
Instead of requiring Interactive Designers to write View code, they can use the native WPF markup language XAML and create bindings to the ViewModel, which is written and maintained by application developers. This separation of roles allows Interactive Designers
 to focus on UX needs rather than programming or business logic, allowing for the layers of an application to be developed in multiple work streams.</p>
<p><span style="font-size:20px; font-weight:bold">A sample ViewModel here</span></p>
<p>You can use the CustomerViewModel in the test to verify that a Command is executed or an ObservableCollection is changed. You can also use the IDialogService interface to verify that a Message is show to the user. All without launch the application, only
 by tests.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomerViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;ViewModelBase&lt;CustomerViewModel&gt;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;IDialogService&nbsp;dialogService;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Customer&nbsp;currentCustomer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;i;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CustomerViewModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;Customer&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddNewCustomer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RelayCommand(PerformAddNewCustomer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CustomerViewModel(IDialogService&nbsp;dialogService)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="cs__keyword">this</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.dialogService&nbsp;=&nbsp;dialogService;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Customer&nbsp;CurrentCustomer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;currentCustomer;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetProperty(<span class="cs__keyword">ref</span>&nbsp;currentCustomer,&nbsp;<span class="cs__keyword">value</span>,&nbsp;x&nbsp;=&gt;&nbsp;x.CurrentCustomer);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Customer&gt;&nbsp;CustomerList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;AddNewCustomer&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PerformAddNewCustomer()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerList.Add(<span class="cs__keyword">new</span>&nbsp;Customer&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Name&quot;</span>&nbsp;&#43;&nbsp;i&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i&#43;&#43;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dialogService&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dialogService.Show(<span class="cs__string">&quot;Customed&nbsp;added&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
