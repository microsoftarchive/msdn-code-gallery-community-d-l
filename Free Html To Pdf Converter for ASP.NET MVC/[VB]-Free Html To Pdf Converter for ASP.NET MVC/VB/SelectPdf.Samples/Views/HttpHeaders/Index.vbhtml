@code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Sending HTTP Headers with Html to Pdf Converter - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Sending HTTP Headers with Html to Pdf Converter Sample for VB.NET/ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "http headers, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "HttpHeaders", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Sending HTTP Headers with Html to Pdf Converter - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how to send HTTP headers to the page that will be converted using the html to pdf converter from SelectPdf Pdf Library for .NET.
                <br />
                <br />
                Below, there is a link to a test page that will display the HTTP headers sent to it. Converting this page will display the headers sent by the html to pdf converter.
                <br />
                <br />
                <a  name="LnkTest"  href="@ViewData("ViewTxtUrl")" Target="_blank">Test Page</a>
            </p>
            <p>
                Url:<br />
                <input type="text" value="@ViewData("ViewTxtUrl")" name="TxtUrl" style="width: 90%" />
                <br />
                <br />
                HTTP Headers:<br />
                <br />
                Name: <input type="text" name="TxtName1" value="Name1" style="width: 40%" /> 
                Value: <input type="text" name="TxtValue1" value="Value1" style="width: 40%" />  
                <br />
                Name: <input type="text" name="TxtName2" value="Name2" style="width: 40%" />
                Value: <input type="text" name="TxtValue2" value="Value2" style="width: 40%" />  
                <br />
                Name: <input type="text" name="TxtName3" value="Name3" style="width: 40%" />
                Value: <input type="text" name="TxtValue3" value="Value3" style="width: 40%" />  
                <br />
                Name: <input type="text" name="TxtName4" value="Name4" style="width: 40%" />
                Value: <input type="text" name="TxtValue4" value="Value4" style="width: 40%" />  
                <br />
                <br />
                <input type="submit" name="BtnConvert" value="Create PDF" class="mybutton" />
            </p>
        </div>
        <!-- .entry-content -->
    </article>
End Using
    