# FluentValidation in ASP.NET MVC 5 using Dependency Injection
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- AJAX
- ASP.NET MVC
- Bootstrap
- Ninject
- ASP.NET MVC 5
- Fluent validation framework
## Topics
- Validation
- ASP.NET MVC
- Dependancy Injection
- jQuery Unobtrusive Validation
- FluentValidation in MVC
## Updated
- 08/27/2016
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This project shows that how to implement fluent validation in ASP.NET MVC 5 using dependency injection with Ninject IoC.</span></p>
<p><span style="font-size:small">The code illustrates the following topics</span></p>
<ul>
<li><span style="font-size:small">Fluent Validation using Dependency Injection with Ninject IoC.<br>
</span></li><li><span style="font-size:small">Fluent Validation on dynamic load bootstrap modal popup.<br>
</span></li><li><span style="font-size:small">jquery.validate.unobtrusive validation on dynamic load bootstrap modal popup.<br>
</span></li><li><span style="font-size:small">Bootstrap Modal Popup using Ajax request.<br>
</span></li><li><span style="font-size:x-small"><span style="font-size:small">Separate example for both static form and dynamic load form.</span><br>
</span></li></ul>
<h1>Getting Started</h1>
<p><span style="font-size:small">To build and run this sample as-is, you must have Visual Studio 2013/2015 installed. In most cases you can run the application by following these steps:</span></p>
<ol>
<li><span style="font-size:small">Download and extract the .zip file.<br>
</span></li><li><span style="font-size:small">Open the solution file in Visual Studio 2013/2015.<br>
</span></li><li><span style="font-size:small">Build the solution, which automatically installs the missing NuGet packages.<br>
</span></li><li><span style="font-size:small">Run the application.<br>
</span></li><li><span style="font-size:small">You will see customer add form and click on submit button then it validates form.&nbsp;<br>
</span></li><li><span style="font-size:x-small"><span style="font-size:small">Now access another form using &ldquo;Student&rdquo; Menu. After that click on &ldquo;Add&rdquo; button on student screen which opens add student form in modal popup and it loads dynamically using
 Ajax request and clicks on submit button and form validates.&nbsp;</span><br>
</span></li></ol>
<p><img id="158663" src="158663-01.png" alt="" width="727" height="334"></p>
<p><span style="font-size:small">Figure 1: Add Customer Form</span></p>
<p><span style="font-size:small"><img id="158664" src="158664-02.png" alt="" width="806" height="332"></span></p>
<p><span style="font-size:small">Figure 2: Add Student Form in Modal Popup</span></p>
<h1><span style="font-size:small">Source Code Overview</span></h1>
<p><span style="font-size:small">Most of folders and files are used as per ASP.NET MVC conventions.</span></p>
<ul>
<li><span style="font-size:small"><em>Validation</em>: This folder has validation classes which used to validate view models.<br>
</span></li><li><span style="font-size:small"><em>ValidatorFactory.cs</em>: This class is used for dependecy injection where validation classes object inject in IValidator.<br>
</span></li><li><span style="font-size:small"><em>NinjectWebCommon.cs</em>: This class is used to register validation DI with IoC Ninject.
<br>
</span></li><li><span style="font-size:x-small"><span><span style="font-size:small"><em>jQuery.customValidate.js</em>: It&rsquo;s custome validator which enables jquery.validate.unobtrusive on dynamic load bootstrap modal popup.&nbsp;</span><br>
</span></span></li></ul>
