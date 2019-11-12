# Design Patterns - MVP - Model View Presenter Pattern-Part 1
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- SharePoint
- .NET Framework
- UI Design
- Design Patterns
## Topics
- C#
- ASP.NET
- Architecture and Design
- UI Design
- Design Patterns
- Model View Presenter
- Presentation Pattern
## Updated
- 04/30/2013
## Description

<div class="saveHistory"><span style="font-size:medium"><span style="color:#008000; font-size:medium">
<div>
<div class="endscriptcode">Targeted Audience:</div>
</div>
</span>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.NET Architects</span><br>
<span style="font-size:small">2.&nbsp;.NET Application Designers</span><br>
<span style="font-size:small">3.&nbsp;.NET Application Developers</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Prerequisites:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.Net technologies.</span><br>
<span style="font-size:small">2.&nbsp;Basic understanding of ASP.NET Web Application.</span></div>
<div><span style="font-size:small">3. Observer Pattern (Optional) - <a href="http://code.msdn.microsoft.com/Dive-into-Observer-Pattern-00fa8573">
http://code.msdn.microsoft.com/Dive-into-Observer-Pattern-00fa8573</a>&nbsp;</span>&nbsp;</div>
<div><span style="color:#008000; font-size:medium">Introduction:</span></div>
<div><span style="color:#000000; font-size:small">&nbsp;</span></div>
<div><span style="color:#000000; font-size:small">As we all know many design patterns and using them in implementing business components and services in our applications but still we will be facing issues/challenges with our applications.&nbsp; Also day by
 day business needs and priorities will be changing. If we closely observe at number of issues, defects and challenges we are facing is in UI and presentation layers. Though some defects are related to business logic and business rules we may need to fix them
 in UI and presentation layers as we might tightly integrated business logic in UI and presentation tiers. The reason behind this is we haven&rsquo;t focused on implementing right design patters in our applications. Let us go through step by step and understand
 how to implement and use presentation pattern in our applications.</span></div>
<div><span style="color:#000000; font-size:small">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Problem Statement:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
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
<span style="color:#000000; font-size:small">Yes</span><br>
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
<div><span style="font-size:small">1.&nbsp;Binding via a datacontext is not possible</span><br>
<span style="font-size:small">2.&nbsp;Complex UI Design</span></div>
<div><span style="font-size:small">3. Best for Windows Forms, ASP.NET Web Forms &amp; Sharepoint Applications</span></div>
<div><strong><span style="color:#808000; font-size:small">&nbsp;</span></strong></div>
<div><span style="color:#808000; font-size:small">MVC</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Best for ASP.NET with Simple UI</span><br>
<span style="font-size:small">2.&nbsp;Disconnected Model (View separation from all other layers)</span></div>
<div></div>
<div><span style="color:#ff0000; font-size:small">Note: Here I am not focusing on MVC VM (MVC ViewModel from MVC3) and ASP.NET MVVM with Dependency Injection.</span></div>
<div><span style="color:#ff0000; font-size:small">Read more about <span>ASP.NET MVVM&nbsp;</span><a href="http://aspnetmvvm.codeplex.com/">http://aspnetmvvm.codeplex.com/</a></span></div>
<div><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/vs2010trainingcourse_aspnetmvc3fundamentals_topic7.aspx"><span>MVC ViewModel&nbsp;</span>http://msdn.microsoft.com/en-us/vs2010trainingcourse_aspnetmvc3fundamentals_topic7.aspx</a></span></div>
<div>&nbsp;</div>
<div><span style="color:#808000; font-size:small">MVVM</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Binding via a datacontext is possible</span><br>
<span style="font-size:small">2.&nbsp;Connected Model</span></div>
<div><span style="font-size:small">3. Best for WPF and Silverlight applications </span>
</div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">Read more about MVVM at <a href="http://code.msdn.microsoft.com/Design-Patterns-MVVM-Model-d4b512f0">
http://code.msdn.microsoft.com/Design-Patterns-MVVM-Model-d4b512f0</a></span><span style="color:#008000; font-size:small">&nbsp;</span></div>
</span>&nbsp;</div>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium">How to Implement MVP?</span></span></p>
<p><span style="font-size:small"><span style="color:#808000">1. The View class (the Web page or user control)</span>&nbsp;manages the controls on the page and it forwards user events to a presenter class and expose properties that
<span style="font-size:small">allow the presenter to manipulate the view&rsquo;s state.
</span></span></p>
<p class="saveHistory"><span style="font-size:small"><span style="color:#808000">2. The Presenter contains
</span>the logic to handle and respond to the events, update the model (business logic and data of the application) and, in turn, manipulate the state of the view.</span></p>
<div class="saveHistory"><span style="font-size:small"><span style="color:#808000">3. The View Interface,
<span style="color:#000000">t</span></span><span style="color:#000000">o</span> facilitate testing the presenter,&nbsp;the presenter will have a reference to the<span style="color:#000000"> view interface
</span>instead of to the concrete implementation of the view. View interface expose the view&rsquo;s state elements.&nbsp;By doing this,&nbsp;we can easily replace the real view with a mock implementation to run tests</span>.</div>
<div class="saveHistory">&nbsp;</div>
<div class="saveHistory"><img id="67753" src="67753-2.png" alt="" width="562" height="327"></div>
<p><span style="color:#008000; font-size:medium">One of my client's application architecture:</span></p>
<p><span style="color:#000000; font-size:x-small">I will explain soon, how we implented and what components we have used.
</span></p>
<p><span style="color:#008000; font-size:medium"><img id="67924" src="67924-image007.gif" alt="" width="272" height="399"></span></p>
<p><span style="color:#008000; font-size:medium"><img id="67925" src="67925-image005.gif" alt="" width="333" height="323"></span></p>
<p><span style="color:#008000; font-size:medium">Implementing a View Class:</span></p>
<p><span style="font-size:small">The view (a web page, a user control, or a master page) contains user interface elements.
</span><br>
<span style="font-size:small">The view should forward user events to the presenter and expose properties or methods for the presenter to manipulate the view&rsquo;s state.</span></p>
<p><span style="color:#808000; font-size:small">How View Updates?</span></p>
<div class="saveHistory">
<p><span style="font-size:small">When the model is updated, the view also has to be updated to reflect the changes. View updates can be handled in several ways.
</span><span style="font-size:small">The Model-View-Presenter variants, Passive View and Supervising Controller, specify different approaches to implementing view updates.</span></p>
<p><span style="font-size:small"><span style="color:#808000">In Passive View,</span>&nbsp;the interaction with the model is handled exclusively by the presenter; the view is not aware of changes in the model. The presenter updates the view to reflect changes
 in the model.</span></p>
<p><span style="font-size:small"><span style="color:#808000">In Supervising Controller</span>, the view interacts directly with the model to perform simple data-binding that can be defined declaratively, without presenter intervention.
</span><br>
<span style="font-size:small">The presenter updates the model; it manipulates the state of the view only in cases where complex UI logic that cannot be specified declaratively is required.
</span></p>
<p><span style="font-size:small">Examples of complex UI logic might include changing the color of a control or dynamically hiding/showing controls.</span></p>
</div>
<p><span style="color:#808000; font-size:small">When to use Passive View or Supervising Controller</span></p>
<p><span style="font-size:small">If testability is a primary concern in our application, Passive View might be more suitable because we can test all the UI logic by testing the presenter.</span></p>
<p><span style="font-size:small">If we prefer code simplicity over full testability, Supervising Controller might be a better option because, for simple UI changes, we do not have to include code in the presenter that updates the view.</span></p>
<p><span style="font-size:small">Passive View usually provides a larger testing surface than Supervising Controller because all the view update logic is placed in the presenter.
</span><br>
<span style="font-size:small">Supervising Controller typically requires less code than Passive View because the presenter does not perform simple view updates.</span></p>
<p><span style="font-size:small">If we are using the Supervising Controller variant, the view should also perform direct data binding to the model (for example, using
</span><span style="font-size:small">the ASP.NET built-in ObjectDataSource control).
</span><br>
<span style="font-size:small">In cases where the presenter exclusively handles the interaction with the model, the ObjectContainerDataSource Control will help&nbsp;in implementing data binding through the presenter.
</span><br>
<span style="font-size:small">The ObjectContainerDataSource control was designed to facilitate data binding in a Model-View-Presenter scenario, where the view does not have direct interaction with the model.</span></p>
<p><span style="color:#008080; font-size:small">View Interaction with the Presenter</span></p>
<p><span style="font-size:small">There are several ways that the view&nbsp;can forward user gestures to the presenter.
</span><br>
<span style="font-size:small">1. <span style="color:#808000">The view directly invokes the presenter&rsquo;s methods.
</span></span><br>
<span style="font-size:small">This approach requires, implement additional methods in the presenter and couples the view with a particular presenter.
</span><br>
<span style="font-size:small">2. <span style="color:#808000">Having the view raise events when user actions occur.
</span></span><br>
<span style="font-size:small">This approach requires code in the view to raise events and code in the presenter to subscribe to the view events.</span></p>
<p><span style="font-size:small">The benefit to the second approach is that there is less coupling between the view and the presenter than with the first approach.
</span></p>
<p><span style="color:#008080; font-size:small">View Interaction with the Model</span></p>
<p><span style="font-size:small">We can implement the interaction with the model in several ways.
</span><br>
<span style="font-size:small">For e.g, we can implement the Observer pattern. I.e. the presenter receives events from the model and updates the view as required.
</span><br>
<span style="font-size:small">Another approach is to use an application controller to update the model.
</span></p>
<p><span style="font-size:small">Read more about Observer Pattern and its implementation here
<a href="http://code.msdn.microsoft.com/Dive-into-Observer-Pattern-00fa8573">http://code.msdn.microsoft.com/Dive-into-Observer-Pattern-00fa8573</a></span></p>
<p><span style="font-size:small"><span style="color:#008000; font-size:medium">Implementing a Presenter Class:</span></span></p>
<p><span style="font-size:small">The presenter should handle user events, update the model, and manipulate the state of the view.
</span><br>
<span style="font-size:small">Usually, the presenter is implemented using Test Driven Development (TDD).
</span><br>
<span style="font-size:small">Implementing the presenter first allows us to focus on the business logic and application functionality independently from the user
</span><span style="font-size:small">interface implementation.</span><br>
<span style="font-size:small">When implementing the presenter, we also need to create simple view and model objects to express the interaction between the view, the
</span><span style="font-size:small">model, and the presenter. </span><br>
<span style="font-size:small">In order to test the presenter in isolation, make the presenter reference the view interface instead of the view concrete implementation.</span></p>
<p><span style="font-size:small">By doing this, we can easily replace the view with a mock implementation when writing and running tests.</span></p>
<p><span style="color:#008080; font-size:small">Presenter Interaction with the View:</span></p>
<p><span style="font-size:small">The communication with the view is usually accomplished by setting and querying properties in the view to set and get the view&rsquo;s state,
</span><span style="font-size:small">respectively and invoking methods on the view.</span><br>
<span style="font-size:small">For e.g, </span><br>
<span style="font-size:small">1. A view could expose a Customer property that allows the presenter to set the customer that the view should display.
</span><br>
<span style="font-size:small">2. The presenter could invoke a method named ShowCustomer(Customer) that indicates to the view that it has to display the customer passed by parameter.</span></p>
<p><span style="color:#008000; font-size:medium">Implementing a View Interface:</span></p>
<p><span style="font-size:small">The view interface should expose the view&rsquo;s state.
</span><br>
<span style="font-size:small">Typically, a view interface contains properties for the presenter to set and query the view&rsquo;s state.
</span><br>
<span style="font-size:small">Exposing properties over methods in the view usually keeps the presenter simpler because it does not need to know about view
</span><span style="font-size:small">implementation details, such as when data is to be bound to user interface controls.</span><br>
<span style="font-size:small">Depending on how the view interacts with the presenter, the view interface might also have additional elements.
</span><br>
<span style="font-size:small">If the view interacts with the presenter by raising events, the view interface will include event declarations.</span></p>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium">Steps to Implement:</span></span></span></p>
<p><span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small">Let us go through the few code snippets from the attached sample.</span></span></span></p>
<p><span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small">Create a solution and add the projects with specified names as shown below.</span></span></span></p>
<p><img id="67909" src="67909-11.png" alt="" width="277" height="397"></p>
<p><span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small">Step 1: Create a simple Model - CustomerModel.cs</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;MVPDemo.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomerModel&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;firstName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;lastName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FirstName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;firstName;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;firstName&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;LastName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;lastName;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lastName&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FullName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;firstName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;lastName;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CustomerModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CustomerModel(<span class="cs__keyword">string</span>&nbsp;firstName,&nbsp;<span class="cs__keyword">string</span>&nbsp;lastName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.FirstName&nbsp;=&nbsp;firstName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.LastName&nbsp;=&nbsp;lastName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="color:#000000; font-size:small">Step 2: Create a View&nbsp;Class UI&nbsp; (AddCustomer.aspx.cs)
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Label&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;lblMessage&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span><span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;table</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;First&nbsp;Name:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:TextBox&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;txtFirstName&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">MaxLength</span>=<span class="html__attr_value">&quot;5&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:RequiredFieldValidator&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;RequiredFieldValidator3&quot;</span>&nbsp;<span class="html__attr_name">ControlToValidate</span>=<span class="html__attr_value">&quot;txtFirstName&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">ErrorMessage</span>=<span class="html__attr_value">&quot;Customer&nbsp;First&nbsp;Name&nbsp;must&nbsp;be&nbsp;provided&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Last&nbsp;Name:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:TextBox&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;txtLastName&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">MaxLength</span>=<span class="html__attr_value">&quot;40&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:RequiredFieldValidator&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;RequiredFieldValidator1&quot;</span>&nbsp;<span class="html__attr_name">ControlToValidate</span>=<span class="html__attr_value">&quot;txtLastName&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">ErrorMessage</span>=<span class="html__attr_value">&quot;Customer&nbsp;Last&nbsp;Name&nbsp;must&nbsp;be&nbsp;provided&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;center&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Button&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;btnAdd&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">OnClick</span>=<span class="html__attr_value">&quot;btnAdd_OnClick&quot;</span>&nbsp;<span class="html__attr_name">Text</span>=<span class="html__attr_value">&quot;Add&nbsp;Customer&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Button&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;btnCancel&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">OnClick</span>=<span class="html__attr_value">&quot;btnCancel_OnClick&quot;</span>&nbsp;<span class="html__attr_name">Text</span>=<span class="html__attr_value">&quot;Cancel&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">CausesValidation</span>=<span class="html__attr_value">&quot;false&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/form&gt;</span></pre>
</div>
</div>
</div>
</span></div>
<p><span style="color:#000000; font-size:small">Step 3: Create a View Interface (IAddCustomerView.cs)</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">interface</span>&nbsp;IAddCustomerView&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;Message&nbsp;{&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;AttachPresenter(CustomerPresenter&nbsp;presenter);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;No&nbsp;need&nbsp;to&nbsp;have&nbsp;a&nbsp;setter&nbsp;since&nbsp;we're&nbsp;only&nbsp;interested&nbsp;in&nbsp;getting&nbsp;the&nbsp;new&nbsp;</span><span class="cs__com">///&nbsp;&lt;see&nbsp;cref=&quot;Customer&quot;&nbsp;/&gt;&nbsp;to&nbsp;be&nbsp;added.</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerModel&nbsp;CustomerToAdd&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;<span style="color:#000000; font-size:small">Step 4: Create a Presenter (CustomerPresenter.cs)</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVPDemo.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVPDemo.Presenters.ViewInterfaces;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVPDemo.Presenters&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomerPresenter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;IAddCustomerView&nbsp;AddCustomerViewObject;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CustomerModel&nbsp;CustomerModelObject;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CustomerPresenter(IAddCustomerView&nbsp;CustomerViewObject,&nbsp;CustomerModel&nbsp;CustomerModelObject)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CustomerViewObject&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;CustomerViewObject&nbsp;may&nbsp;not&nbsp;be&nbsp;null&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CustomerModelObject&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;CustomerModelObject&nbsp;may&nbsp;not&nbsp;be&nbsp;null&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.AddCustomerViewObject&nbsp;=&nbsp;CustomerViewObject;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.CustomerModelObject&nbsp;=&nbsp;CustomerModelObject;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;EventHandler&nbsp;CancelAddEvent;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;EventHandler&nbsp;AddCustomerEvent;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;EventHandler&nbsp;AddCustomerCompleteEvent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddInitView()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddCustomerViewObject.Message&nbsp;=&nbsp;<span class="cs__string">&quot;Use&nbsp;this&nbsp;form&nbsp;to&nbsp;add&nbsp;a&nbsp;new&nbsp;customer.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddCustomer()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddCustomerEvent(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddCustomer(<span class="cs__keyword">bool</span>&nbsp;isPageValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Be&nbsp;sure&nbsp;to&nbsp;check&nbsp;isPageValid&nbsp;before&nbsp;anything&nbsp;else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!isPageValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddCustomerViewObject.Message&nbsp;=&nbsp;<span class="cs__string">&quot;There&nbsp;was&nbsp;a&nbsp;problem&nbsp;with&nbsp;your&nbsp;inputs.&nbsp;&nbsp;Make&nbsp;sure&nbsp;you&nbsp;supplied&nbsp;everything&nbsp;and&nbsp;try&nbsp;again&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;filled&nbsp;object&nbsp;from&nbsp;the&nbsp;Customer&nbsp;view.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerModelObject&nbsp;=&nbsp;AddCustomerViewObject.CustomerToAdd;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Session[<span class="cs__string">&quot;CustomerModelObject&quot;</span>]&nbsp;=&nbsp;CustomerModelObject;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;could&nbsp;certainly&nbsp;pass&nbsp;in&nbsp;more&nbsp;than&nbsp;just&nbsp;null&nbsp;for&nbsp;the&nbsp;event&nbsp;args</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddCustomerCompleteEvent(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;By&nbsp;passing&nbsp;HTML&nbsp;tags&nbsp;from&nbsp;the&nbsp;presenter&nbsp;to&nbsp;the&nbsp;view,&nbsp;we've&nbsp;essentially&nbsp;bound&nbsp;the&nbsp;presenter&nbsp;to&nbsp;an&nbsp;HTML&nbsp;context.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;want&nbsp;to&nbsp;consider&nbsp;alternatives&nbsp;to&nbsp;keep&nbsp;the&nbsp;presentation&nbsp;layer&nbsp;web/windows&nbsp;agnostic.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddCustomerViewObject.Message&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;span&nbsp;style=\&quot;color:red\&quot;&gt;The&nbsp;Customer&nbsp;added&nbsp;to&nbsp;database&nbsp;successfully.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CancelAdd()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CancelAddEvent(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="color:#000000; font-size:small">Step 5: Associate View Class with Presenter by using View Interface (AddCustomer.aspx.cs) we can create seperate presenters for each CRUD operation. Here&nbsp;I have created only presenter for all CRUD operations.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;CustomerPresenter&nbsp;presenter;&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Message&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMessage.Text&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AttachPresenter(CustomerPresenter&nbsp;presenter)&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.presenter&nbsp;=&nbsp;presenter;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;CustomerModel&nbsp;CustomerToAdd&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerModel&nbsp;customer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CustomerModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customer.FirstName&nbsp;=&nbsp;txtFirstName.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customer.LastName&nbsp;=&nbsp;txtLastName.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;customer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnAdd_OnClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;presenter.AddCustomer(Page.IsValid);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnCancel_OnClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;presenter.CancelAdd();&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//Base&nbsp;page&nbsp;overload&nbsp;method</span>&nbsp;
<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PageLoad()&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;DaoFactory&nbsp;is&nbsp;inherited&nbsp;from&nbsp;BasePage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CustomerModel&nbsp;CustomerModelObject&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CustomerModel();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CustomerPresenter&nbsp;presenter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CustomerPresenter(<span class="cs__keyword">this</span>,&nbsp;CustomerModelObject);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.AttachPresenter(presenter);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;presenter.AddCustomerCompleteEvent&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler(HandleAddCustomerCompleteEvent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;presenter.CancelAddEvent&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler(HandleCancelAddEvent);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;presenter.AddInitView();&nbsp;
}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;HandleAddCustomerCompleteEvent(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Response.Redirect(<span class="cs__string">&quot;ListCustomersView.aspx?action=added&quot;</span>);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;HandleCancelAddEvent(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Response.Redirect(<span class="cs__string">&quot;ListCustomersView.aspx&quot;</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium">Additional Reference Links:</span></span></span></p>
<p><span style="font-size:small">Composite Blocks with MVP <a href="http://webclientguidance.codeplex.com/">
http://webclientguidance.codeplex.com/</a></span></p>
<p><span style="font-size:small">MVP with Web Forms <a href="http://webformsmvp.codeplex.com/">
http://webformsmvp.codeplex.com/</a></span></p>
<p><span style="font-size:small">NuGet Framework for MVP <a href="http://www.nuget.org/packages/WebFormsMVP">
http://www.nuget.org/packages/WebFormsMVP</a></span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small"><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium">Output:
<span style="color:#333300; font-size:small">AddCustomer.aspx</span></span></span></span></span></p>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><img id="67910" src="67910-12.png" alt="" width="463" height="271"></span></span></span></p>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><span style="color:#333300; font-size:small">ListCustomer.aspx</span></span></span></span></p>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><span style="color:#333300; font-size:small"><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><span style="color:#333300; font-size:small"><img id="67911" src="67911-13.png" alt="" width="559" height="206"></span></span></span></span></span></span></span></span></p>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><span style="color:#333300; font-size:small"><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><span style="color:#333300; font-size:small">EditCustomer.aspx</span></span></span></span></span></span></span></span></p>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><span style="color:#333300; font-size:small"><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium"><span style="color:#333300; font-size:small"><img id="67912" src="67912-14.png" alt="" width="588" height="241"></span></span></span></span></span></span></span></span></p>
<p><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="font-size:medium">Few Disadvantage of MVP:</span></span></span></p>
<p><span style="font-size:small"><span style="font-size:small"><span style="font-size:small">1. There are more solution elements to manage.
<br>
2. We need a way to create and connect views and presenters. <br>
3. The model is not aware of the presenter. Therefore, if the model is changed by any component other than the presenter, the presenter
</span><span style="font-size:small">must be notified. Typically, notification is implemented with events.
</span></span></span></p>
<p><span style="color:#808000; font-size:small"><span style="color:#000000; font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with
<span style="color:#3366ff"><img id="67168" src="67168-ratings.png" alt="" width="74" height="15">
<span style="color:#000000">star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Good).
</span></span></span></p>
<div class="endscriptcode"><span style="color:#3366ff">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Visit my all other articles here
<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Srigopal%20Chitrapu">
http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Srigopal%20Chitrapu</a></span></div>
</span>
<p></p>
