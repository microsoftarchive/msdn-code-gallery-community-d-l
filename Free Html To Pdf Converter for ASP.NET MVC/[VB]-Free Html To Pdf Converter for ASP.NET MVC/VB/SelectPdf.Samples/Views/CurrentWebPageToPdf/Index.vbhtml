@code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Convert Current Asp.Net Page to Pdf - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Convert Current Asp.Net Page to Pdfr Sample for VB.NET ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "convert current asp.net page to pdf, hide element, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "CurrentWebPageToPdf", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Convert Current Web Page to Pdf - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how to use SelectPdf Html to Pdf Converter to convert the current web page to pdf,
                preserving the values entered in the page controls before hitting the 'Convert' button.
            </p>
            <p>
                Sample text field:<br />
                @Html.TextBox("TxtSampleText", If(ViewData("SampleText") <> Nothing, ViewData("SampleText").ToString(), String.Empty), New With {Key .[style] = "width: 90%"})
            </p>
            <div class="col2">
                Sample drop down:<br />
                @Html.DropDownList("DropDownList1", DirectCast(ViewData("DropDownList1Items"), List(Of SelectListItem)))
                <br />
                <br />
                Sample check box:<br />
                @Html.CheckBox("ChkSampleCheckbox", ViewData("SampleCheckbox") <> Nothing And ViewData("SampleCheckbox").ToString() <> "false")
                <br />
                <br />
            </div>
            <div class="col2">
                Sample text field:<br />
                @Html.TextBox("TxtSampleText2", If(ViewData("SampleText2") <> Nothing, ViewData("SampleText2").ToString(), String.Empty), New With {Key .[style] = "width: 50px"}) px<br />
                <br />
                Sample text field:<br />
                @Html.TextBox("TxtSampleText3", If(ViewData("SampleText3") <> Nothing, ViewData("SampleText3").ToString(), String.Empty), New With {Key .[style] = "width: 50px"}) px<br />
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
    