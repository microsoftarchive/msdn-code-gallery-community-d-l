@code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Convert from Url to Pdf - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Convert from Url to Pdf Sample for VB.NET ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "convert from url to pdf, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "ConvertUrlToPdf", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Convert from Html to Pdf - MVC Razor - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how to use SelectPdf html to pdf converter to convert an url to pdf, also setting a few properties.
            </p>
            <p>
                Url:<br />
                <input type="text" value="http://selectpdf.com" name="TxtUrl" style="width: 90%;" />
            </p>
            <div class="col2">
                Pdf Page Size:<br />
                <select name="DdlPageSize">
                    <option value="A1">A1</option>
                    <option value="A2">A2</option>
                    <option value="A3">A3</option>
                    <option value="A4" selected>A4</option>
                    <option value="A5">A5</option>
                    <option value="Letter">Letter</option>
                    <option value="HalfLetter">HalfLetter</option>
                    <option value="Ledger">Ledger</option>
                    <option value="Legal">Legal</option>
                </select><br />
                <br />
                Pdf Page Orientation:<br />
                <select name="DdlPageOrientation">
                    <option value="Portrait" selected>Portrait</option>
                    <option value="Landscape">Landscape</option>
                </select><br />
                <br />
            </div>
            <div class="col2">
                Web Page Width:<br />
                <input name="TxtWidth" type="text" value="1024" style="width: 50px;" /> px<br />
                <br />
                Web Page Height:<br />
                <input name="TxtHeight" type="text" value="" style="width: 50px;" /> px<br />
                (leave empty to auto detect)<br />
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
