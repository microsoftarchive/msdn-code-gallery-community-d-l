﻿@code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Setting Document Properties with Html to Pdf Converter - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Setting Document Properties with Html to Pdf Converter Sample for VB.NET ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "document properties, html to pdf converter, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "PdfConverterProperties", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Setting Document Properties with Html to Pdf Converter - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how to convert a web page to pdf using SelectPdf and set the basic pdf document information (title, subject, keywords) with the values taken from the webpage.
            </p>
            <p>
                Url:<br />
                <input type="text" id="TxtUrl" name="TxtUrl" style="width:90%" value="http://selectpdf.com" />
                <br />
                <br />
                <input type="submit" id="BtnCreatePdf" value="Create PDF" class="mybutton" />
            </p>
        </div>
        <!-- .entry-content -->
    </article>
       
End Using
    