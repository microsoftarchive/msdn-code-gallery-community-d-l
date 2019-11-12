﻿@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Automatic Bookmarks with Html to Pdf Converter - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html To Pdf Converter Automatic Bookmarks with Html to Pdf Converter Sample for VB.NET/ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "bookmarks, pdf library, sample code, html to pdf, pdf converter"
End code

@Using (Html.BeginForm("SubmitAction", "AutomaticBookmarks", FormMethod.Post))

    @<article class="post type-post status-publish format-standard hentry">
        <header class="entry-header">
            <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Automatic Bookmarks with Html to Pdf Converter - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div class="entry-content">
            <p>
                This sample shows how the html to pdf converter can automatically generate pdf bookmarks based on some elements selection using SelectPdf Pdf Library for .NET.
                <br />
                <br />
                The elements that will be bookmarked are defined using CSS selectors.
                For example, the selector for all the H1 elements is "H1", the selector for all the elements with the CSS class name 'myclass' is "*.myclass" and
                the selector for the elements with the id 'myid' is "*#myid". Read more about CSS selectors <a href="http://www.w3schools.com/cssref/css_selectors.asp" target="_blank">here</a>.
                <br />
                <br />
                <a name="LnkTest" href="@ViewData("viewtxturl")" target="_blank">Test document</a>
            </p>
            <p>
                Url:<br />
                
                <input type="text" value="http://selectpdf.com" name="TxtUrl" style="width: 90%;" />
                <br />
                <br />
                Bookmark the following elements:<br />
                
                <input type="text" value="h1, h2" name="TxtElements" style="width: 90%;" />
                <br />
                <br />
                
                <input type="submit" name="BtnConvert" value="Create PDF" class="mybutton" />
            </p>
        </div>
        <!-- .entry-content -->
    </article>
End Using  
