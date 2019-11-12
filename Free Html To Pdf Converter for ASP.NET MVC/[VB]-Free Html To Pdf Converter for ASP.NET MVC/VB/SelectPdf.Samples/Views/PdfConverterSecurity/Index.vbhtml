@code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Pdf Security Settings with Html To Pdf Converter - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Pdf Security Settings with Html To Pdf Converter Sample for VB.NET ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "pdf security, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "PdfConverterSecurity", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Pdf Security Settings with Html To Pdf Converter - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how to convert from html to pdf using SelectPdf, how to set a password to be able to view or
                modify the document and also specify user permissions for the pdf document (if the user can print, copy content, fill forms, modify, etc).
            </p>
            <p>
                Url:<br />
                <input type="text" id="TxtUrl" name="TxtUrl" style="width:90%" value="http://selectpdf.com" />
            </p>
            <div class="col2">
                User Password:<br />
                <input type="text" id="TxtUserPassword" name="TxtUserPassword" /><br />
                <br />
                Owner Password:<br />
                <input type="text" id="TxtOwnerPassword" name="TxtOwnerPassword" /><br />
                <br />
            </div>
            <div class="col2">
                <input type="checkbox" id="ChkCanAssembleDocument" name="ChkCanAssembleDocument" checked /> Allow Assemble Document<br />
                <input type="checkbox" id="ChkCanCopyContent" name="ChkCanCopyContent" checked /> Allow Copy Content<br />
                <input type="checkbox" id="ChkCanEditAnnotations" name="ChkCanEditAnnotations" checked /> Allow Edit Annotations<br />
                <input type="checkbox" id="ChkCanEditContent" name="ChkCanEditContent" checked /> Allow Edit Content<br />
                <input type="checkbox" id="ChkCanFillFormFields" name="ChkCanFillFormFields" checked />  Fill Form Fields<br />
                <input type="checkbox" id="ChkCanPrint" name="ChkCanPrint" checked /> Allow Print<br />
                <br />
            </div>
            <div class="col-clear"></div>
            <p>
                <input type="submit" id="BtnCreatePdf" value="Create PDF" class="mybutton" />
            </p>
        </div>
        <!-- .entry-content -->
    </article>
       
End Using
    