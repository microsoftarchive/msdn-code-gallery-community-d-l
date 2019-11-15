# Design Patterns - MVVM Pattern-Part 1
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
- ASP.NET
- WPF
- ViewModel pattern (MVVM)
## Topics
- Architecture and Design
- ViewModel pattern (MVVM)
- MVVM
- Design Patterns
- Model View ViewModel
## Updated
- 09/24/2014
## Description

<div><span style="color:#008000; font-size:medium">Targeted Audience:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.NET Architects</span><br>
<span style="font-size:small">2.&nbsp;.NET Application Designers</span><br>
<span style="font-size:small">3.&nbsp;.NET Application Developers</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Prerequisites:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.Net technologies.</span><br>
<span style="font-size:small">2.&nbsp;Basic understanding of data binding in WPF, Silverlight.</span></div>
<div><span style="font-size:small">3. Observer Pattern (Optional) - <a href="http://code.msdn.microsoft.com/Dive-into-Observer-Pattern-00fa8573">
http://code.msdn.microsoft.com/Dive-into-Observer-Pattern-00fa8573</a></span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#000000; font-size:medium"><span style="font-size:small">
<div><span style="color:#008000; font-size:medium">
<div style="line-height:150%; text-indent:-0.25in; margin-left:0.25in"><span style="color:green; line-height:150%; font-family:calibri; font-size:14pt">Introduction:</span><span style="color:#000000; line-height:150%; font-family:calibri; font-size:small"><span style="font-family:calibri">&nbsp;</span></span>&nbsp;<span style="color:maroon; font-family:calibri; font-size:11pt">&nbsp;</span></div>
<div><span style="color:#000000"><span style="font-family:calibri; font-size:11pt">As we all know many design patterns and using them in implementing business components and services in our applications but still we will be facing issues/challenges with our
 applications.&nbsp; Also day by day business needs and priorities will be changing. If we closely observe at number of issues, defects and challenges we are facing is in UI and presentation layers. Though some defects are related to business logic and business
 rules we may need to fix them in UI and presentation layers as we might tightly integrated business logic in UI and presentation tiers. The reason behind this is we haven&rsquo;t focused on implementing right design patters in our applications. Let us go through
 step by step and understand how to implement and use presentation pattern in our applications.</span></span></div>
<div><span style="color:#000000"><span style="font-family:calibri; font-size:11pt">&nbsp;</span></span></div>
<div>Problem Statement:</div>
</span>
<div><span style="font-size:small">&nbsp;</span></div>
</div>
<div><span style="font-size:small">1.&nbsp;Already using different patterns in application but still maintaining application is difficult.</span><br>
<span style="font-size:small">2.&nbsp;Using VS Test, NUnit, MBUnit etc to test business logic layer, but still some defects are exists in the application as business logic involved in presentation layer.</span><br>
<span style="font-size:small">3.&nbsp;Used Presentation Layer, Business Logic Layer, Data Access Layer in the application but still some times need to write redundant code in presentation layer to consume or call other modules or other use cases.</span><br>
<span style="font-size:small">4.&nbsp;Integration defects are getting injected when we make some changes in integrated modules.</span><br>
<span style="font-size:small">5.&nbsp;Defect fixing and enhancements are taking more time to analyze the presentation tier logic and its integration dependencies and causing for opening new defects.</span></div>
<div><span style="font-size:small">6.&nbsp;ASP.NET MVC cannot be chosen as UI is complex to build.&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Root Cause of the Problem:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<span style="font-size:small"><span style="color:#008000; font-size:medium">
<div><span style="color:#000000; font-size:small">In Presentation layer,&nbsp;</span></div>
<div><span style="color:#000000; font-size:small">1. A page or form contains controls that display application domain data.
</span><br>
<span style="color:#000000; font-size:small">&nbsp;&nbsp;&nbsp;A user can modify the data and submit the changes.
</span><br>
<span style="color:#000000; font-size:small">&nbsp;&nbsp;&nbsp;The page retrieves the domain data, handles user events, alters other controls on the page in response to the events, and submits the changed domain data.
</span><br>
<span style="color:#000000; font-size:small">&nbsp;&nbsp;&nbsp; Including the code that performs these functions in the Web page makes the class complex, difficult to maintain, and hard to test.
</span></div>
<div><span style="color:#000000; font-size:small">2. In addition, it is difficult to share code between Web pages that require the same behavior.</span></div>
</span>
<div>3.&nbsp;UI Layer, UI Logic, Presentation Logic, Business Logic are tightly coupled.</div>
</span>
<div><span style="font-size:small">4.&nbsp;Presentation layer is taking care of integrating modules or use cases.</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Solution:</span><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Chose a best Presentation Layer Pattern to separate the UI Layer, UI Logic and Presentation Logic and Business Logic as separate layers to make the code easier to understand and maintain.</span><br>
<span style="font-size:small">2.&nbsp;Enable loose coupling while developing modules or any use cases.</span></div>
<div><span style="font-size:small">3.&nbsp;Maximize the code that can be tested with automation. (Views are hard to test.)
<br>
4. Share code between pages that require the same behavior. <br>
5</span><span style="font-size:small">. Separate the responsibilities for the visual display and the event handling behavior into different classes named, respectively, the view and the presenter or controller or ViewModel.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Benefits of using Presentation Pattern:</span><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Modularity</span><br>
<span style="font-size:small">2.&nbsp;Test driven approach - maximize the code that can be tested with automation</span></div>
<div><span style="color:#000000; font-size:medium"><span style="font-size:small">3.&nbsp;Separation of concerns</span></span></div>
<div><span style="color:#000000; font-size:medium"><span style="font-size:small">4. Code sharing between pages and forms</span></span></div>
<div><span style="color:#000000; font-size:medium"><span style="font-size:small">5. Easy to maintain</span></span></div>
</span></span></div>
<div>&nbsp;</div>
<div><span style="color:#008000; font-size:medium">What are the presentation layer patterns available?</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">MVC (Model View Controller)</span><br>
<span style="font-size:small">MVP (Model View Presenter) or (Model Passive View, Supervisor Controller)</span><br>
<span style="font-size:small">MVVM (Model View ViewModel)</span></div>
<div>&nbsp;</div>
<div><span style="color:#008000; font-size:medium">MVC vs MVP vs MVVM:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Model and View represents same in all the above 3 patterns?</span><br>
<span style="font-size:small">Yes</span><br>
<span style="font-size:small">2.&nbsp;Controller, Presenter, and ViewModel purpose is same in all the above 3 patterns?</span><br>
<span style="font-size:small">Yes</span><br>
<span style="font-size:small">3.&nbsp;Communication and flow of Model, View with Controller, Presenter, and ViewModel is same?</span><br>
<span style="font-size:small">No, that is the reason these 3 patterns exists.</span><br>
<span style="font-size:small">4.&nbsp;Are these patterns replacement of PL (Presentation Layer), BLL (Business Logic Layer) and DAL (Data Access Layer)</span><br>
<span style="font-size:small">No, these patterns are for separating the UI and UI Logic from Presentation Logic
</span><br>
<span style="font-size:small">and enables the loose coupling.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Choose the best Presentation Layer Pattern:&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">MVP </span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Binding via a datacontext is not possible. (Windows Forms)</span><br>
<span style="font-size:small">2.&nbsp;Complex UI Design (ASP.NET Web Forms) </span>
</div>
<div><span style="font-size:small">Read more about MVP Patter here <a href="http://code.msdn.microsoft.com/Design-Patterns-MVp-Model-3b691ddc">
http://code.msdn.microsoft.com/Design-Patterns-MVp-Model-3b691ddc</a></span></div>
<div><strong><span style="color:#808000; font-size:small">&nbsp;</span></strong></div>
<div><span style="color:#808000; font-size:small">MVC</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Simple UI (ASP.NET MVC, Sharepoint)</span><br>
<span style="font-size:small">2.&nbsp;Disconnected Model (View separation from all other layers)</span></div>
<div></div>
<div><span style="color:#ff0000; font-size:small">Note: Here I am not focusing on MVC VM ( MVC ViewModel from MVC3) and ASP.NET MVVM with Dependency Injection.</span></div>
<div><span style="color:#ff0000; font-size:small">Read more about <span>ASP.NET MVVM&nbsp;</span><a href="http://aspnetmvvm.codeplex.com/">http://aspnetmvvm.codeplex.com/</a></span></div>
<div><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/vs2010trainingcourse_aspnetmvc3fundamentals_topic7.aspx"><span>MVC ViewModel&nbsp;</span>http://msdn.microsoft.com/en-us/vs2010trainingcourse_aspnetmvc3fundamentals_topic7.aspx</a></span></div>
<div></div>
<div></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">MVVM</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Binding via a datacontext is possible.</span><br>
<span style="font-size:small">2.&nbsp;Connected Model</span></div>
<div><span style="font-size:small">The term MVVM was first mentioned by the WPF Architect, John Gossman, on his blog in 2005. It was then described in depths by Josh Smith in his MSDN article &ldquo;WPF Apps with the Model-View-ViewModel Design Pattern&rdquo;.</span></div>
<div><br>
<span style="font-size:small">3. Separation of concerns, follows Single Responsibility Principle from OOPS SOLID Principles
</span><span style="font-size:small">(In some exceptions it can violate SRP) </span>
<br>
<div><span style="color:#008000; font-size:small"><span style="color:#0000ff">Read more about OOPS SOLID Principles here</span>
<a href="http://gallery.technet.microsoft.com/OOPS-Principles-SOLID-017627d2/view/Reviews">
http://gallery.technet.microsoft.com/OOPS-Principles-SOLID-017627d2/view/Reviews</a></span></div>
<div><span style="font-size:small">4. Testable. </span></div>
<div><span style="font-size:small">5. MVVM for Web Applications <span style="color:#808000; font-size:small">
<a href="http://knockoutjs.com/">http://knockoutjs.com/</a></span></span></div>
</div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span>&nbsp;</div>
<div><span style="color:#008000; font-size:medium">How MVVM Pattern Works?</span></div>
<div>&nbsp;</div>
<div><img id="65130" src="http://i1.gallery.technet.s-msft.com/mvvm-a18c737f/image/file/65130/1/mvvm.png" alt="" width="600" height="176"></div>
<div><span style="color:#008000; font-size:small">&nbsp;</span></div>
<div><span style="color:#008000; font-size:small">Look at&nbsp;the above flow diagram and communications between each component.&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small"><span style="color:#008000; font-size:medium">Components of MVVM Pattern:</span></span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">Model:</span><span style="font-size:small"><span style="font-size:small">&nbsp;</span></span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1. Represents the Data.</span><br>
<span style="font-size:small">2. The Entity.</span><br>
<span style="font-size:small">3. Model classes are non-visual classes that encapsulate the application's data and business logic.
</span><br>
<span style="font-size:small">4. They are responsible for managing the application's data and for ensuring its consistency and validity by encapsulating the required business rules and data validation logic.</span><br>
<span style="font-size:small">5. The model classes do not directly reference the view or view model classes and have no dependency on how they are implemented.</span><br>
<span style="font-size:small">6&nbsp;The model classes typically provide property and collection change notification events through the INotifyPropertyChanged and INotifyCollectionChanged interfaces.
</span><br>
<span style="font-size:small">7. This allows them to be easily data bound in the view.
</span></div>
<div><span style="font-size:small">8. Model classes that represent collections of objects typically derive from the ObservableCollection&lt;T&gt; class.</span><br>
<span style="font-size:small">9. The model classes typically provide data validation and error reporting through either the IDataErrorInfo or INotifyDataErrorInfo interfaces.</span><br>
<span style="font-size:small">10. The model classes are typically used in conjunction with a service or repository that encapsulates data access and caching.</span></div>
<div><span style="font-size:small"><span style="font-size:small">11. Not required to know where it gets its data from i.e f</span><span style="font-size:small">rom a WCF service. WCF RIA Services, etc.</span><br>
<span style="font-size:small">12.&nbsp;May contain validation.</span></span><br>
<span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">View:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="color:#000000; font-size:small">1. The view is a visual element, such as a window, page, user control, or data template.
<br>
2. The view defines the controls contained in the view and their look and feel, visual layout and styling.<br>
3. The view references the view model through its DataContext property. <br>
4. The controls in the view are data bound to the properties and commands exposed by the ViewModel.<br>
5. The view may customize the data binding behavior between the view and the view model.&nbsp;<br>
For e.g, the view may use value converters to format the data to be displayed in the UI, or it may use validation rules to provide additional input data validation to the user.<br>
6. The view defines and handles UI visual behavior, such as animations or transitions that may be triggered from a state change in the view model or via the user's interaction with the UI.<br>
7. The view's code-behind may define UI logic to implement visual behavior that is difficult to express in XAML or that requires direct references to the specific UI controls defined in the view.&nbsp;</span></div>
<div><span style="color:#000000; font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="color:#808000; font-size:small">ViewModel:</span></div>
<div><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">1. The ViewModel is a non-visual class and does not derive from any WPF or Silverlight base class.
<br>
2. It encapsulates the presentation logic required to support a use case or user task in the application.
<br>
3. The ViewModel is testable independently of the view and the model.<br>
4. The ViewModel typically does not directly reference the view. <span style="font-size:small">
<span style="font-size:small">It will have UI Friendly Entities, UI State, Actions and
</span><span style="font-size:small">Public properties that are bound to a View</span>.</span><br>
5. It implements properties and commands to which the view can data bind. <br>
6. It notifies the view of any state changes via change notification events via the INotifyPropertyChanged and INotifyCollectionChanged interfaces.<br>
7. Interacts with View with various Commands. </span></div>
<div><span style="font-size:small">(Covered in MVVM Part 2 <a href="http://code.msdn.microsoft.com/Design-Patterns-MVVM-Model-f1d7c05c">
http://code.msdn.microsoft.com/Design-Patterns-MVVM-Model-f1d7c05c</a>)</span></div>
<div><span style="font-size:small">8. The view model coordinates the view's interaction with the model.
<br>
9. It may convert or manipulate data so that it can be easily consumed by the view and may implement additional properties that may not be present on the model.
<br>
10. It may also implement data validation via the IDataErrorInfo or INotifyDataErrorInfo interfaces.<br>
11. The view model may define logical states that the view can represent visually to the user.
</span></div>
<div></div>
<div><span style="font-size:small">12. Invokes services to communicate outside the MVVM triad.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">MVVM Principles:</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;The Simplicity Principle:&nbsp; </span>
<br>
<span style="font-size:small">&nbsp; &nbsp;Each View should have a single ViewModel and a ViewModel should only service a single View</span><br>
<span style="font-size:small">2.&nbsp;The Blendability Principle: </span><br>
<span style="font-size:small">&nbsp; &nbsp;The ViewModel should support Expression Blend.</span><br>
<span style="font-size:small">3.&nbsp;The Designability Principle: </span><br>
<span style="font-size:small">&nbsp; &nbsp;The ViewModel should supply Design Time Data.</span><br>
<span style="font-size:small">4.&nbsp;The Testability Principle:&nbsp;</span><br>
<span style="font-size:small">&nbsp; &nbsp;The ViewModel and Models should be testable.</span><br>
<span style="font-size:small">For more details <a href="http://practicalmvvm.com/Manifesto/">
http://practicalmvvm.com/Manifesto/</a></span></div>
<div></div>
<div><span style="color:#808000; font-size:small">Some other protocols MVVM follows:</span></div>
<div><span style="font-size:small">5.&nbsp;View must be paired with a ViewModel somehow.</span><br>
<span style="font-size:small">6. ViewModel is declared as a Static Resource in the View&rsquo;s XAML.</span><br>
<span style="font-size:small">7. Should Works well in Expression Blend.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium"><span>Benifits of MVVM:</span></span></div>
<div><span style="color:#008000; font-size:medium"><span>&nbsp;</span></span></div>
<div><span style="font-size:small">1. Seperation of Concerns (View, ViewModel, Model)</span></div>
<div><span style="font-size:small">2. Clean testable and manageable code. Can include presentation tier logic in unit testing.</span></div>
<div><span style="font-size:small">3. No code behind code, so the presentation layer and the logic is loosely coupled.</span></div>
<div><span style="font-size:small">4. Better way of databinding.</span></div>
<div><span style="font-size:small">5. With Silverlight 4.0 we have new ICommand Support (earlier this was only present in the PRISM framework). I will cover this in next article Part 2.</span></div>
<div></div>
<div><span style="color:#008000; font-size:medium">Disadvantages? &nbsp;</span></div>
<div><span style="font-size:small"><br>
1. Few people say For simple UI, M-V-VM can be overkill. &nbsp;</span></div>
<div><span style="font-size:small">2. Debugging would be bit difficult when we have complex databindings.</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Steps to Implement MVVM:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1. Create a Simple Model (CustomerModel.cs) with required properties and implement PropertyChanged property of INotifyPropertyChanged.</span></div>
<div><span style="font-size:small">
<div class="scriptcode">
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;Customer&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;firstName;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;lastName;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FirstName&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;firstName;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(firstName&nbsp;!=&nbsp;<span class="cs__keyword">value</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;firstName&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaisePropertyChanged(<span class="cs__string">&quot;FirstName&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaisePropertyChanged(<span class="cs__string">&quot;FullName&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;LastName&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;lastName;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(lastName&nbsp;!=&nbsp;<span class="cs__keyword">value</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lastName&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaisePropertyChanged(<span class="cs__string">&quot;LastName&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaisePropertyChanged(<span class="cs__string">&quot;FullName&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FullName&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;firstName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;lastName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RaisePropertyChanged(<span class="cs__keyword">string</span>&nbsp;property)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(PropertyChanged&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyChanged(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyChangedEventArgs(property));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
</div>
</div>
</span>
<div class="endscriptcode"><span style="font-size:small">2. Create a ViewModel (CustomerViewModel.cs) with required logic to bind Model to ViewModel.</span></div>
</div>
<div><span style="font-size:small">
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;CustomerViewModel&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Customer&gt;&nbsp;Customers&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;LoadCustomers()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObservableCollection&lt;Customer&gt;&nbsp;customers&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;Customer&gt;();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customers.Add(<span class="cs__keyword">new</span>&nbsp;Customer&nbsp;{&nbsp;FirstName&nbsp;=&nbsp;<span class="cs__string">&quot;Sai&quot;</span>,&nbsp;LastName&nbsp;=&nbsp;<span class="cs__string">&quot;Sri&quot;</span>&nbsp;});&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customers.Add(<span class="cs__keyword">new</span>&nbsp;Customer&nbsp;{&nbsp;FirstName&nbsp;=&nbsp;<span class="cs__string">&quot;Srigopal&quot;</span>,&nbsp;LastName&nbsp;=&nbsp;<span class="cs__string">&quot;Chitrapu&quot;</span>&nbsp;});&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customers.Add(<span class="cs__keyword">new</span>&nbsp;Customer&nbsp;{&nbsp;FirstName&nbsp;=&nbsp;<span class="cs__string">&quot;Sri&quot;</span>,&nbsp;LastName&nbsp;=&nbsp;<span class="cs__string">&quot;Mahi&quot;</span>});&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customers&nbsp;=&nbsp;customers;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
</span>
<div class="endscriptcode"><span style="font-size:small">3. Create a View (CustomerView.xaml) and bind the data with ViewModel.</span>&nbsp;</div>
</div>
<div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;UserControl&nbsp;x:Class=<span class="cs__string">&quot;MVVMDemo.Views.CustomerView&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="cs__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="cs__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&gt;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackPanel&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemsControl&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;Path=Customers}&quot;</span>&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemsControl.ItemTemplate&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataTemplate&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackPanel&nbsp;Orientation=<span class="cs__string">&quot;Horizontal&quot;</span>&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;Path=FirstName,&nbsp;Mode=TwoWay}&quot;</span>/&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;Path=LastName,&nbsp;Mode=TwoWay}&quot;</span>/&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;Path=FullName,&nbsp;Mode=OneWay}&quot;</span>/&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackPanel&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemsControl.ItemTemplate&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemsControl&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackPanel&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;&nbsp;
&lt;/UserControl&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small"><span style="color:#000000">4. Create an object to ViewModel and bind to View in MainWindow.xaml.cs.</span></span></div>
</div>
<div><span style="color:#000000; font-size:medium">&nbsp;</span>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainWindow&nbsp;:&nbsp;Window&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainWindow()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Window_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MVVMDemo.ViewModels.CustomerViewModel&nbsp;CustomerViewModelObect&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MVVMDemo.ViewModels.CustomerViewModel();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerViewModelObect.LoadCustomers();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;View&nbsp;created&nbsp;in&nbsp;XMAL&nbsp;CustomerHeaderView&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerViewControl.DataContext&nbsp;=&nbsp;CustomerViewModelObect;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><span style="color:#008080; font-size:small">Continue MVVM Part 2 here.
<a href="http://code.msdn.microsoft.com/Design-Patterns-MVVM-Model-f1d7c05c">http://code.msdn.microsoft.com/Design-Patterns-MVVM-Model-f1d7c05c</a></span></div>
<div class="endscriptcode"><span style="color:#008080; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#000000; font-size:small">
<div class="endscriptcode"><span style="color:#808000; font-size:small">
<div class="endscriptcode"></div>
<span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with
<span style="color:#3366ff"><img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">
<span style="color:#000000">star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Nice).
</span></span></span>
<div class="endscriptcode"><span style="color:#3366ff">&nbsp;</span></div>
</span>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Visit my all other articles here
<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Srigopal%20Chitrapu">
http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Srigopal%20Chitrapu</a></span></div>
</span></div>
</span><span style="color:#0000ff; font-size:small">&nbsp;</span> &nbsp;</div>
</div>
</div>
