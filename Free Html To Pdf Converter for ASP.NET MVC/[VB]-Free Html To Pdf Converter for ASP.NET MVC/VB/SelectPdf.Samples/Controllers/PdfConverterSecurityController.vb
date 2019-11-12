Imports SelectPdf

Namespace Controllers
    Public Class PdfConverterSecurityController
        Inherits Controller

        ' GET: PdfConverterSecurity
        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(fields As FormCollection) As ActionResult
            ' read parameters from the webpage
            Dim url As String = fields("TxtUrl")

            Dim userPassword As String = fields("TxtUserPassword")
            Dim ownerPassword As String = fields("TxtOwnerPassword")

            Dim canAssembleDocument As Boolean = fields("ChkCanAssembleDocument") = "on"
            Dim canCopyContent As Boolean = fields("ChkCanCopyContent") = "on"
            Dim canEditAnnotations As Boolean = fields("ChkCanEditAnnotations") = "on"
            Dim canEditContent As Boolean = fields("ChkCanEditContent") = "on"
            Dim canFillFormFields As Boolean = fields("ChkCanFillFormFields") = "on"
            Dim canPrint As Boolean = fields("ChkCanPrint") = "on"

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set document passwords
            If Not String.IsNullOrEmpty(userPassword) Then
                converter.Options.SecurityOptions.UserPassword = userPassword
            End If
            If Not String.IsNullOrEmpty(ownerPassword) Then
                converter.Options.SecurityOptions.OwnerPassword = ownerPassword
            End If

            'set document permissions
            converter.Options.SecurityOptions.CanAssembleDocument = canAssembleDocument
            converter.Options.SecurityOptions.CanCopyContent = canCopyContent
            converter.Options.SecurityOptions.CanEditAnnotations = canEditAnnotations
            converter.Options.SecurityOptions.CanEditContent = canEditContent
            converter.Options.SecurityOptions.CanFillFormFields = canFillFormFields
            converter.Options.SecurityOptions.CanPrint = canPrint

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(url)

            ' save pdf document
            Dim pdf As Byte() = doc.Save()

            ' close pdf document
            doc.Close()

            ' return resulted pdf document
            Dim fileResult As FileResult = New FileContentResult(pdf, "application/pdf")
            fileResult.FileDownloadName = "Document.pdf"
            Return fileResult
        End Function
    End Class
End Namespace