@code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Pdf Internal and External Links - Html to Pdf Converter - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Pdf Internal and External Links - Html to Pdf Converter Sample for VB.NET ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "internal link, external link, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "HtmlToPdfConverterLinks", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Pdf Internal and External Links - Html to Pdf Converter - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how the html to pdf converter can handle internal and external links from the web page when converted to pdf using SelectPdf Pdf Library for .NET.
                <br />
                <br />
                SelectPdf Library can convert internal html links to internal pdf links and keep external html links (hyperlinks to other pages) the same in pdf (external links).
                These links can be disabled in pdf if needed.
                <br />
                <br />
                <a href="@ViewData("ViewTxtUrl")" target="_blank" name="LnkTest">Test document</a>                
            </p>
            <p>
                Url:<br />
                
                <input type="text" value="@ViewData("ViewTxtUrl")" name="TxtUrl" style="width: 90%;" />
                <br />
                <br />
                <input type="checkbox" name="ChkInternalLinks" checked="checked">Convert with internal links
                <br />
                <input type="checkbox" name="ChkExternalLinks" checked="checked">Convert with external links
                <br />
                <br />
                <br />
                <input type="submit" name="BtnConvert" value="Create PDF" class="mybutton" />
            </p>
        </div>
        <!-- .entry-content -->
    </article>

End Using
    