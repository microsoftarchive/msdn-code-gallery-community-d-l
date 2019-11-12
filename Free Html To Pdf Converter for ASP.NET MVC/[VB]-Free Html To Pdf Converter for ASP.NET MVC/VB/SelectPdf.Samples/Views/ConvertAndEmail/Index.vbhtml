@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewBag.Title = "SelectPdf Free Html To Pdf Converter for .NET - Html to Pdf Converter - Convert and Email as Attachment - VB.NET / ASP.NET MVC"
    ViewBag.Description = "SelectPdf Free Html to Pdf Converter. Convert and Email as Attachment Sample for VB.NET ASP.NET MVC. Pdf Library for .NET with full sample code in C# and VB.NET."
    ViewBag.Keywords = "html to pdf converter, convert and email, email as attachment, pdf library, sample code, html to pdf, pdf converter"
End Code

@Using (Html.BeginForm("Index", "ConvertAndEmail", FormMethod.Post))
    @<article Class="post type-post status-publish format-standard hentry">
        <header Class="entry-header">
            <h1 Class="entry-title">SelectPdf Free Html To Pdf Converter - Convert And Email as Attachment - VB.NET / ASP.NET MVC Sample</h1>
        </header>
        <!-- .entry-header -->

        <div Class="entry-content">
            <p>
                This sample shows the simplest code that can be used To convert an url To pdf Using SelectPdf Pdf Library For .NET And Then email the generated PDF document As an attachment.
                <br />
                <br />
                IMPORTANT: Remember to set the SMTP server details in web.config.
            </p>
            <p>
                Url : <br />
                <input type = "text" value="http://selectpdf.com" name="TxtUrl" style="width:90%" />
                <br />
                <br />
                Email: <br />
                <input type = "text" value="your_email@your.domain.com" name="TxtEmail" style="width:50%" />
                <br />
                <br />
                <br />
                <input type = "submit" name="BtnConvert" value="Create PDF and Email" Class="mybutton" />
                &nbsp;&nbsp;
                <span style = "color: red" >@ViewData("Message")</span>
            </p>
        </div>
        <!-- .entry-content -->
    </article>
End Using


