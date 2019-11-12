@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Sending Parameters with HTTP POST with Html to Pdf Converter - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter HTTP POST requests with Html to Pdf Converter Sample for VB.NET / ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "http post, post parameters, pdf library, sample code, html to pdf, pdf converter"
End Code

@Using (Html.BeginForm("SubmitAction", "HttpPostRequest", FormMethod.Post))
    @<article Class="post type-post status-publish format-standard hentry">
        <header Class="entry-header">
            <h1 Class="entry-title">SelectPdf Free Html To Pdf Converter - Sending parameters with a HTTP POST request using the Html to Pdf Converter - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div Class="entry-content">
            <p>
                This sample shows how To send parameters Using a HTTP POST request To the page that will be converted using the html to pdf converter from SelectPdf Pdf Library For .NET.
                <br />
                <br />
                Below, there Is a link to a test page that will display the HTTP POST data sent to it. Converting this page will display the data POSTED to the page by the html to pdf converter.
                <br />
                <br />
                <a name = "LnkTest" href="@ViewData("ViewTxtUrl")" Target="_blank">Test page</a>
            </p>
            <p>
                Url : <br />
                <input type = "text" value="@ViewData("ViewTxtUrl")" name="TxtUrl" style="width: 90%" />
                <br />
                <br />
                HTTP POST Parameters:<br />
                <br />
                Name: <input type = "text" name="TxtName1" value="Name1" style="width: 40%" />
                Value: <input type = "text" name="TxtValue1" value="Value1" style="width: 40%" />
                <br />
                Name: <input type = "text" name="TxtName2" value="Name2" style="width: 40%" />
                Value: <input type = "text" name="TxtValue2" value="Value2" style="width: 40%" />
                <br />
                Name: <input type = "text" name="TxtName3" value="Name3" style="width: 40%" />
                Value: <input type = "text" name="TxtValue3" value="Value3" style="width: 40%" />
                <br />
                Name: <input type = "text" name="TxtName4" value="Name4" style="width: 40%" />
                Value: <input type = "text" name="TxtValue4" value="Value4" style="width: 40%" />
                <br />
                <br />
                <input type = "submit" name="BtnConvert" value="Create PDF" Class="mybutton" />
            </p>
        </div>
        <!-- .entry-content -->
    </article>
End Using
