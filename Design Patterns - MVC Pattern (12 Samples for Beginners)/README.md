# Design Patterns - MVC Pattern (12 Samples for Beginners)
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- AJAX
- JSON
- ASP.NET
- ASP.NET MVC
- .NET Framework
- ASP.NET MVC 3
- ASP.NET Web Forms
- .NET Framework 4.0
- HTML
- ASP.NET MVC 4
- MVC Examples
## Topics
- AJAX
- JSON
- Model View Controller (MVC)
- Architecture and Design
- ASP.NET MVC
- ASP.NET Web Forms
- ASP.NET MVC Basics
- Design Patterns
- MVC Pattern
- MVC Samples
- MVC Example
## Updated
- 04/30/2013
## Description

<div class="endscriptcode"><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">Work In Progress -&nbsp;I am still updating the content and samples in parellel. Feel free to download the samples and post your questions
 in Q/A tab. </span></span></div>
<div class="endscriptcode"><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">&nbsp;</span></span><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#008000; font-size:medium">Targeted Audience:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.NET Architects</span><br>
<span style="font-size:small">2.&nbsp;.NET Application Designers</span><br>
<span style="font-size:small">3.&nbsp;.NET Application Developers</span></div>
<div><span style="color:#008000; font-size:medium">
<div class="endscriptcode"><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">&nbsp;</span></span>&nbsp;</div>
<div class="endscriptcode"><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">As of now This article intented&nbsp;to MVC beginners and I will add as many samples as I can,&nbsp;so that beginners can be proficient in
 MVC.</span></span></div>
<div class="endscriptcode"><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">&nbsp;</span></span></div>
</span></div>
<div><span style="color:#008000; font-size:medium">Prerequisites:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.Net technologies.</span><br>
<span style="font-size:small">2.&nbsp;Basic understanding of ASP.NET Web Application.</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Softwae Requirements:</span></div>
<p>Download Visual Studio 2010 Ultimate and ASP.NET MVC3</p>
<p>VS2010:&nbsp; <a href="http://www.microsoft.com/en-us/download/details.aspx?id=12187">
http://www.microsoft.com/en-us/download/details.aspx?id=12187</a><br>
ASP.NET MVC3 : <a href="http://www.asp.net/mvc/mvc3">http://www.asp.net/mvc/mvc3</a></p>
<p><span style="color:#008000; font-size:medium">Introduction:</span></p>
<p><span style="color:#000000; font-size:small">As we all know many design patterns and using them in implementing business components and services in our applications but still we will be facing issues/challenges with our applications.&nbsp; Also day by day
 business needs and priorities will be changing. If we closely observe at number of issues, defects and challenges we are facing is in UI and presentation layers. Though some defects are related to business logic and business rules we may need to fix them in
 UI and presentation layers as we might tightly integrated business logic in UI and presentation tiers. The reason behind this is we haven&rsquo;t focused on implementing right design patters in our applications. Let us go through step by step and understand
 how to implement and use presentation pattern in our applications.</span></p>
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
<div><span style="font-size:small">
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
<div>3.&nbsp;UI Layer, UI Logic, Presentation Logic, Business Logic are tightly coupled.</div>
<div><span style="font-size:small">4.&nbsp;Presentation layer is taking care of integrating modules or use cases.</span></div>
&nbsp;</span></div>
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
<div><span style="color:#000000; font-size:small">Read more about MVP Pattern <a href="http://code.msdn.microsoft.com/Design-Patterns-MVp-Model-3b691ddc">
http://code.msdn.microsoft.com/Design-Patterns-MVp-Model-3b691ddc</a>&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">MVC</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;Best for ASP.NET with Simple UI</span><br>
<span style="font-size:small">2.&nbsp;Disconnected Model (View separation from all other layers)</span></div>
<div></div>
<div><span style="color:#ff0000; font-size:small">Note: Here I am not focusing on MVC VM (MVC ViewModel from MVC3) and ASP.NET MVVM with Dependency Injection.</span></div>
<div><span style="color:#ff0000; font-size:small">&nbsp;</span></div>
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
<div><span style="color:#008000; font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="color:#008000; font-size:medium"><span style="font-size:medium">ASP.NET Web Forms vs ASP.NET MVC:</span></span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="color:#808000; font-size:small">ASP.NET Web Forms</span><br>
<span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">&bull; RAD </span><br>
<span style="font-size:small">&bull; More easy development </span><br>
<span style="font-size:small">&bull; Rich controls ecosystem</span><br>
<span style="font-size:small">&bull; Familiar as the development approach to Windows Forms development</span></div>
<div><span style="font-size:small"><span style="font-size:small">&bull;&nbsp;No ViewState &amp;</span><span style="font-size:small">&nbsp;No postback support</span></span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="color:#808000; font-size:small">ASP.NET MVC</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">&bull; Clean Separation of Concern (SoC)</span><br>
<span style="font-size:small">&bull; Full markup control</span><br>
<span style="font-size:small">&bull; Enable TDD (Test Driven Development)</span><br>
<span style="font-size:small">&bull; Enable and makes easily REST</span><br>
<span style="font-size:small">&bull; More easy client-side integration (Javascript)</span><br>
<span style="font-size:small">&bull; Multi View Engine (this is really cool!)</span><br>
<span style="font-size:small">&bull;&nbsp;No ViewState &amp;</span><span style="font-size:small">&nbsp;No postback support</span><br>
<span style="font-size:small">&bull; Extensible and WEB 2.0 Enabled</span></div>
<div><span style="font-size:medium">
<div>
<div><span style="color:#808000; font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="font-size:small">
<p><span style="color:#808000">&bull;Model:</span> Model objects are the parts of the application that implement the logic for the application s data domain. Often, model objects retrieve and store model state in a database. For example, a Product object might
 retrieve information from a database, operate on it, and then write updated information back to a Products table in SQL Server.</p>
<p><span style="color:#808000">&bull;Views:</span> Views are the components that display the application s user interface (UI). Typically, this UI is created from the model data. An example would be an edit view of a Products table that displays text boxes,
 drop-down lists, and check boxes based on the current state of a Products object.</p>
<p><span style="color:#808000">&bull;Controller:</span> Controllers are the components that handle user interaction, work with the model, and ultimately select a view to render that displays UI. In an MVC application, the view only displays information; the
 controller handles and responds to user input and interaction. For example, the controller handles query-string values, and passes these values to the model, which in turn queries the database by using the values.</p>
</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="color:#008000">ASP.NET MVC&nbsp;High Level Page Life Cycle?</span></div>
</div>
</span>
<div></div>
<div></div>
<div><span style="color:#008000; font-size:medium"><span style="font-size:medium"><img id="68478" src="http://i1.code.msdn.s-msft.com/design-patterns-mvc-pattern-aa79900b/image/file/68478/1/mvcpagelifecycle.png" alt="" width="640" height="385"></span></span></div>
<div></div>
<div></div>
<div><span style="color:#008000; font-size:medium"><span style="font-size:medium"><span style="color:#008000; font-size:medium"><span style="font-size:medium">ASP.NET MVC&nbsp;Low Level Page Life Cycle?</span></span></span></span></div>
</div>
<div><span style="color:#008000; font-size:medium"><span style="font-size:medium"><img id="68479" src="http://i1.code.msdn.s-msft.com/design-patterns-mvc-pattern-aa79900b/image/file/68479/1/mvcpagelifecycledetail.png" alt="" width="612" height="1049"></span></span></div>
<div><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">
<p><span style="color:#008000; font-size:medium">MVC2.0 New Features:</span></p>
<p><span style="color:#000000">1. Templated Helpers:</span></p>
<p><span style="color:#000000">Templated Helpers helps us to automatically associate HTML elements for edit and display with data types.</span></p>
<p><span style="color:#000000">E.g when data of type <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.DateTime.aspx" target="_blank" title="Auto generated link to System.DateTime">System.DateTime</a> is displayed in a view, a date-picker UI element can be automatically rendered.
</span><br>
<span style="color:#000000">This is similar to how field templates work in ASP.NET Dynamic Data.</span><br>
&nbsp;<br>
<span style="color:#000000">2. Areas:</span></p>
<p><span style="color:#000000">Using areas We can organize a large project into multiple smaller sections in order to manage the complexity of a large Web application.</span><br>
<span style="color:#000000">Each section (&ldquo;area&rdquo;) typically represents a separate section of a large Web site and is used to group related sets of controllers and views.</span></p>
<p><span style="color:#000000">E.g.</span></p>
<p><span style="color:#000000">&nbsp;Areas</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp; Admin</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Controllers</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Models</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Views</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp; Iniala Claims</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Controllers</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Models</span><br>
<span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Views</span></p>
<p><span style="color:#000000">3. Support for Asynchronous Controllers :</span></p>
<p><span style="color:#000000">ASP.NET MVC2 allows controllers to process requests asynchronously.
</span><br>
<span style="color:#000000">This can lead to performance gains by allowing servers which frequently call blocking operations (like network</span></p>
<p><span style="color:#000000">requests) to call non-blocking counterparts instead.</span></p>
<p><span style="color:#000000">4. Support for DefaultValueAttribute in Action-Method Parameters :</span></p>
<p><span style="color:#000000">The <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.DefaultValueAttribute.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DefaultValueAttribute">System.ComponentModel.DefaultValueAttribute</a> class allows a default value to be supplied for the argument parameter to an action method.</span></p>
<p><span style="color:#000000">For example, assume that the following default route is defined: {controller}/{action}/{id}</span><br>
<span style="color:#000000">Also assume that the following controller and action method is defined:</span></p>
<p><span style="color:#0000ff">public class ArticleController </span><br>
<span style="color:#0000ff">{ </span><br>
<span style="color:#0000ff">&nbsp; public ActionResult View(int id, [DefaultValue(1)]int page)
</span><br>
<span style="color:#0000ff">&nbsp; { </span><br>
<span style="color:#0000ff">&nbsp; } </span><br>
<span style="color:#0000ff">}</span></p>
<p><span style="color:#000000">Any of the following request URLs will invoke the View action method that is defined in the preceding example.</span></p>
<p><span style="color:#000000">&bull;/Article/View/123</span><br>
<span style="color:#000000">&bull;/Article/View/123?page=1 (Effectively the same as the previous request)
</span><br>
<span style="color:#000000">&bull;/Article/View/123?page=2</span></p>
<p><span style="color:#000000">5. Support for binding Binary Data with Model Binders:</span></p>
<p><span style="color:#000000">There are two new overloads of the Html.Hidden helper that encode binary values as base-64-encoded strings:</span><br>
<span style="color:#000000">public static string Hidden(this HtmlHelper htmlHelper, string name, Binary value);&nbsp;
</span><br>
<span style="color:#000000">public static string Hidden(this HtmlHelper htmlHelper, string name, byte[] value);</span></p>
<p><span style="color:#000000">6. Support for DataAnnotations Attributes:</span></p>
<p><span style="color:#000000">Using the RangeAttribute, RequiredAttribute, StringLengthAttribute, and RegexAttribute validation attributes (defined in the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a> namespace) when we bind to a model in order to provide input validation.</span></p>
<p><span style="color:#0000ff">using <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;</span><br>
<span style="color:#0000ff">namespace MvcTmpHlprs </span><br>
<span style="color:#0000ff">{</span></p>
<p><span style="color:#0000ff">&nbsp;&nbsp;&nbsp; [MetadataType(typeof(ProductMD))]</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; public partial class Product&nbsp;
</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; {</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public class ProductMD
</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object SellStartDate { get; set; }</span></p>
<p><span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [UIHint(&quot;rbDate&quot;)]</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object SellEndDate { get; set; }</span></p>
<p><span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DataType(DataType.Date)]</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object DiscontinuedDate { get; set; }</span></p>
<p><span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [ScaffoldColumn(false)]</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object ModifiedDate { get; set; }</span></p>
<p><span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [ScaffoldColumn(false)]</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object rowguid { get; set; }</span></p>
<p><span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [ScaffoldColumn(false)]</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object ThumbnailPhotoFileName { get; set; }</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; }</span><br>
<span style="color:#0000ff">}</span></p>
<p><span style="color:#000000">7. Model-Validator Providers:</span></p>
<p><span style="color:#000000">The model-validation provider class represents an abstraction that provides validation logic for the model.</span><br>
<span style="color:#000000">ASP.NET MVC includes a default provider based on validation attributes that are included in the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a> namespace.</span></p>
<p><span style="color:#000000">8. Client-Side Validation:</span></p>
<p><span style="color:#000000">The model-validator provider class exposes validation metadata to the browser in the form of JSON-serialized data that can be consumed by a client-side validation library.</span></p>
<p><span style="color:#000000">ASP.NET MVC 2 includes a client validation library and adapter that supports the DataAnnotations namespace validation attributes noted earlier.</span></p>
<p><span style="color:#000000">9. New RequireHttpsAttribute Action Filter:</span></p>
<p><span style="color:#000000">ASP.NET MVC 2 includes a new RequireHttpsAttribute class that can be applied to action methods and controllers.</span><br>
<span style="color:#000000">By default, the filter redirects a non-SSL (HTTP) request to the SSL-enabled (HTTPS) equivalent.</span><br>
&nbsp;<br>
<span style="color:#000000">10. Overriding the HTTP Method Verb:</span></p>
<p><span style="color:#000000">When we build a Web site by using the REST architectural style, HTTP verbs are used to determine which action to perform for a resource.</span></p>
<p><span style="color:#000000">REST requires that applications support the full range of common HTTP verbs, including GET, PUT, POST, and DELETE.</span></p>
<p><span style="color:#000000">ASP.NET MVC 2 includes new attributes that we can apply to action methods and that feature compact syntax.
</span><br>
<span style="color:#000000">These attributes enable ASP.NET MVC to select an action method based on the HTTP verb.</span></p>
<p><span style="color:#000000">For example, a POST&nbsp; request will call the first action method and a PUT request will call the second action method.</span></p>
<p><span style="color:#0000ff">&nbsp;[HttpPost] </span><br>
<span style="color:#0000ff">&nbsp;public ActionResult Edit(int id) </span><br>
&nbsp;<br>
<span style="color:#0000ff">&nbsp;[HttpPut] </span><br>
<span style="color:#0000ff">&nbsp;public ActionResult Edit(int id, Tag tag)</span></p>
<p><span style="color:#000000">In earlier versions of ASP.NET MVC, these action methods required more verbose syntax, as shown in the following</span></p>
<p><span style="color:#000000">Example:</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [AcceptVerbs(HttpVerbs.Post)]&nbsp;
</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public ActionResult Edit(int id)&nbsp;
</span><br>
&nbsp;<br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [AcceptVerbs(HttpVerbs.Put)]&nbsp;
</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public ActionResult Edit(int id, Tag tag)&nbsp;</span></p>
<p><span style="color:#000000">Because browsers support only the GET and POST HTTP verbs, it is not possible to post to an action that requires a different verb. Thus it is not possible to natively support all RESTful requests.</span><br>
&nbsp;<br>
<span style="color:#000000">However, to support RESTful requests during POST operations, ASP.NET MVC 2 introduces a new HttpMethodOverride HTML helper method.
</span><br>
<span style="color:#000000">This method renders a hidden input element that causes the form to effectively emulate any HTTP method.</span><br>
<span style="color:#000000">For example, by using the HttpMethodOverride HTML helper method, we can have a form submission appear be a PUT or DELETE request.</span></p>
<p><span style="color:#000000">The behavior of HttpMethodOverride affects the following attributes:</span></p>
<p><span style="color:#000000">&nbsp;&bull;HttpPostAttribute</span><br>
<span style="color:#000000">&nbsp;&bull;HttpPutAttribute</span><br>
<span style="color:#000000">&nbsp;&bull;HttpGetAttribute</span><br>
<span style="color:#000000">&nbsp;&bull;HttpDeleteAttribute</span><br>
<span style="color:#000000">&nbsp;&bull;AcceptVerbsAttribute</span></p>
<p><span style="color:#000000">11. New HiddenInputAttribute Class for Templated Helpers:</span><br>
&nbsp;<br>
<span style="color:#000000">We can apply the new HiddenInputAttribute attribute to a model property to indicate whether a hidden input element should be rendered when displaying the model in an editor template.
</span><br>
<span style="color:#000000">(The attribute sets an implicit UIHint value of HiddenInput).</span></p>
<p><span style="color:#000000">The attribute&rsquo;s DisplayValue property lets we specify whether the value is displayed in editor and display modes.</span><br>
<span style="color:#000000">When DisplayValue is set to false, nothing is displayed, not even the HTML markup that normally surrounds a field.</span><br>
<span style="color:#000000">The default value for DisplayValue is true.</span><br>
<span style="color:#000000">We might use HiddenInputAttribute attribute in the following scenarios:</span></p>
<p><span style="color:#000000">&bull;When a view lets users edit the ID of an object and it is necessary to display the value as well as to provide a hidden input element that contains the old ID so that it can be passed back to the controller.
</span><br>
<span style="color:#000000">&bull;When a view lets users edit a binary property that should never be displayed, such as a timestamp property.
</span><br>
<span style="color:#000000">In that case, the value and surrounding HTML markup (such as the label and value) are not displayed.</span></p>
<p><span style="color:#000000">E.g:</span></p>
<p><span style="color:#0000ff">public class ProductViewModel </span><br>
<span style="color:#0000ff">{ </span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; [HiddenInput] // equivalent to [HiddenInput(DisplayValue=true)]
</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; public int Id { get; set; }&nbsp; </span>
<br>
&nbsp;<br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; public string Name { get; set; }&nbsp;
</span><br>
&nbsp;<br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; [HiddenInput(DisplayValue=false)]&nbsp;
</span><br>
<span style="color:#0000ff">&nbsp;&nbsp;&nbsp; public byte[] TimeStamp { get; set; }
</span><br>
<span style="color:#0000ff">}</span></p>
<p><span style="color:#000000">12. Html.ValidationSummary Helper Method Can Display Model-Level Errors:</span></p>
<p><span style="color:#000000">Instead of always displaying all validation errors, the Html.ValidationSummary helper method has a new option to display only model-level errors.
</span><br>
<span style="color:#000000">This enables model-level errors to be displayed in the validation summary and field-specific errors to be displayed next to each field.</span></p>
<p><span style="color:#000000">13. T4 Templates in Visual Studio Generate Code that is Specific to the Target Version of the .NET Framework:</span></p>
<p><span style="color:#000000">A new property is available to T4 files from the ASP.NET MVC T4 host that specifies the version of the .NET Framework that is used by the application.&nbsp;
</span><br>
<span style="color:#000000">This enables T4 templates to generate code and markup that is specific to a version of the .NET Framework.
</span><br>
<span style="color:#000000">In Visual Studio 2008, the value is always .NET 3.5. In Visual Studio 2010, the value is either .NET 3.5 or .NET4.</span><br>
&nbsp;<br>
<span style="color:#000000">14. API Improvements:</span><br>
&nbsp;<br>
<span style="color:#000000">Added a protected virtual CreateActionInvoker method in the Controller class.
</span><br>
<span style="color:#000000">This method is invoked by the ActionInvoker property of Controller and allows for lazy instantiation of the invoker if no invoker is already set.</span></p>
Work In Progress -&nbsp;I am still updating the content and samples in parallel. </span>
</span></div>
<div><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">Feel free to download the samples and post your questions in Q/A tab.</span></span></div>
<div><span style="color:#008000; font-size:medium"><span style="color:#ff0000; font-size:small">
<div class="endscriptcode"><span style="color:#000000; font-size:small">
<div class="endscriptcode"><span style="color:#808000; font-size:small">
<div class="endscriptcode"><span style="color:#000000; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#000000; font-size:small"><span style="color:#3366ff"><span style="color:#000000"><span style="color:#000000; font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give
 me your feedback with <span style="color:#3366ff"><img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">
<span style="color:#000000">star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Good).
</span></span></span>&nbsp;</span></span></span></div>
<div class="endscriptcode"><span style="color:#000000; font-size:small">&nbsp;</span>
<p><span style="color:#808000; font-size:small">Visit my all other articles here <a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Srigopal%20Chitrapu">
http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Srigopal%20Chitrapu</a></span></p>
</div>
</span></div>
</span></div>
</span></span></div>
