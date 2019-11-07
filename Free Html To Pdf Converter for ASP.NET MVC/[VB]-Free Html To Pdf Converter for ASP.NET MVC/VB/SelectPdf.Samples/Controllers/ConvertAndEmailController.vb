Imports SelectPdf
Imports System.IO
Imports System.Net.Mail

Namespace Controllers
    Public Class ConvertAndEmailController
        Inherits Controller

        ' GET: ConvertAndEmail
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function Index(fields As FormCollection) As ActionResult
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            Try
                ' create a new pdf document converting an url
                Dim doc As PdfDocument = converter.ConvertUrl(fields("TxtUrl"))

                ' create memory stream to save PDF
                Dim pdfStream As New MemoryStream()

                ' save pdf document into a MemoryStream
                doc.Save(pdfStream)

                ' reset stream position
                pdfStream.Position = 0

                ' create email message
                Dim message As New MailMessage()
                message.From = New MailAddress("support@selectpdf.com")
                message.[To].Add(New MailAddress(fields("TxtEmail")))
                message.Subject = "SelectPdf Sample - Convert and Email as Attachment"
                message.Body = "This email should have attached the PDF document " +
                    "resulted from the conversion of the following url to pdf: " +
                    fields("TxtUrl")
                message.Attachments.Add(New Attachment(pdfStream, "Document.pdf"))

                ' send email
                Dim smtp = New SmtpClient()
                smtp.Send(message)

                ' close pdf document
                doc.Close()

                ViewData("Message") = "Email sent"
            Catch ex As Exception
                ViewData("Message") = "An error occurred: " + ex.Message
            End Try

            Return View()
        End Function
    End Class
End Namespace