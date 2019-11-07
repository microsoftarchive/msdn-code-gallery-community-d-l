# Flexible Conditional Validation with ASP.NET MVC
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC
- ASP.NET MVC 3
## Topics
- Data Validation
## Updated
- 09/11/2012
## Description

<h1>Introduction</h1>
<div><em>This is the source code to accompany the blog post &quot;Flexible Conditional Validation with ASP.NET MVC &ndash; adding client-side support&quot;. (<a href="http://blogs.msdn.com/b/stuartleeks/archive/2012/09/07/flexible-conditional-validation-with-asp-net-mvc-adding-client-side-support.aspx">http://blogs.msdn.com/b/stuartleeks/archive/2012/09/07/flexible-conditional-validation-with-asp-net-mvc-adding-client-side-support.aspx</a>)</em></div>
<h1><span>Building the Sample</span></h1>
<div><em><em>The sample code is in C# and requires Visual Studio 2010 and ASP.NET MVC 3</em></em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div>&nbsp;</div>
<div><em>
<div>The associated blog post covers how to create a RequiredIf validation attribute that performs Required validation subject to a condition. I.e. the property is only required if the condition is true. The posts show creating the attribute and then adding
 client-side validation support by converting the C# expression describing the condition into JavaScript.</div>
</em>
<div><em>&nbsp;</em></div>
</div>
<div>&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<ul>
</ul>
<div>The key files in the project are:</div>
<ul>
<li><em>Scripts\requiredIf.js</em> - this is the client-side code to apply the RequiredIf behaviour in the browser
</li><li>Infrastructure\RequiredIfAttribute.cs - this is the server-side code for the RequiredIfAttribute class
</li><li>Infrastructure\JavaScriptExpressionVisitor.cs - this is the helper class that is used to convert the C# expression to a JavaScript expression
</li><li>Models\Home\PendingRequestModel.cs - this is the part of the view model for the edit view (EditModel), and demonstrates the usage of RequiredIf
</li></ul>
<div>&nbsp;</div>
<div><strong>NOTE: This code is not fully featured or production-ready. There is only sufficient implementation of the JavaScriptExpressionVisitor for the purposes of the blog post, there are areas that are known to be a perf hit (and probably unknown areas
 too), and there has been no real testing. &#61514;</strong></div>
