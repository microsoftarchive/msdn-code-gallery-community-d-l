@code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Conversion Delay with Html to Pdf Converter - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Conversion Delay with Html to Pdf Converter Sample for VB.NET ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "conversion delay, navigation timeout example, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "ConversionDelay", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Conversion Delay with Html to Pdf Converter - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how the html to pdf converter can be used to convert a web page to pdf using SelectPdf Pdf Library for .NET.
                <br />
                <br />
                For pages that use javascripts heavily, the conversion can be delayed a number of seconds using <i>converter.Options.MinPageLoadTime</i> property to allow the content to be fully rendered.
                <br />
                <br />
                In a similar way, if a page takes too much time to load, the converter can specify the amount of time in seconds when the page load will timeout using the property <i>converter.Options.MaxPageLoadTime</i>.
            </p>
            <p>
                Url:<br />
                <input type="text" value="http://selectpdf.com" name="TxtUrl" style="width:90%" />

            </p>
            <div class="col2">
                Delay conversion:<br />
                <input type="text" value="2" name="TxtDelay" style="width:50px" />
                seconds<br />
                <br />
            </div>
            <div class="col2">
                Page timeout:<br />
                <input type="text" value="20" name="TxtTimeout" style="width:50px" />
                seconds<br />
                <br />
            </div>
            <div class="col-clear"></div>
            <p>
                <input type="submit" name="BtnConvert" value="Create PDF" class="mybutton" />
            </p>
        </div>
        <!-- .entry-content -->
    </article>
End Using