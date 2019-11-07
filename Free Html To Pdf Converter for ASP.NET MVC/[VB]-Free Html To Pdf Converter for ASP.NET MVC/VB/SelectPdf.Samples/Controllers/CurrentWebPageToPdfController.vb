Imports System.IO
Imports SelectPdf

Namespace Controllers
    Public Class CurrentWebPageToPdfController
        Inherits Controller

        ' GET: /CurrentWebPageToPdf/
        Public Function Index() As ActionResult
            ViewData.Add("SampleText", "sample text")
            ViewData.Add("DropDownList1", "Value3")

            Dim DropDownList1 As New List(Of SelectListItem)()
            DropDownList1.Add(New SelectListItem() With {
                 .Text = "Value1",
                 .Value = "Value1",
                 .Selected = ViewData("DropDownList1") IsNot Nothing _
                 AndAlso ViewData("DropDownList1").ToString() = "Value1"
            })
            DropDownList1.Add(New SelectListItem() With {
                 .Text = "Value2",
                 .Value = "Value2",
                 .Selected = ViewData("DropDownList1") IsNot Nothing _
                 AndAlso ViewData("DropDownList1").ToString() = "Value2"
            })
            DropDownList1.Add(New SelectListItem() With {
                 .Text = "Value3",
                 .Value = "Value3",
                 .Selected = ViewData("DropDownList1") IsNot Nothing _
                 AndAlso ViewData("DropDownList1").ToString() = "Value3"
            })
            DropDownList1.Add(New SelectListItem() With {
                 .Text = "Value4",
                 .Value = "Value4",
                 .Selected = ViewData("DropDownList1") IsNot Nothing _
                 AndAlso ViewData("DropDownList1").ToString() = "Value4"
            })

            ViewData.Add("DropDownList1Items", DropDownList1)

            ViewData.Add("SampleCheckbox", "true")

            ViewData.Add("SampleText2", "1000")
            ViewData.Add("SampleText3", "800")

            Return View()
        End Function

        <HttpPost> _
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' set data for the view
            Dim MyViewData As ViewDataDictionary = GetViewData(collection)

            ' render view to get html
            Dim html As New StringWriter()

            Dim viewEngineResult As ViewEngineResult =
                ViewEngines.Engines.FindView(ControllerContext, "Index", Nothing)
            Dim viewContext As New ViewContext(ControllerContext,
                    viewEngineResult.View, MyViewData, New TempDataDictionary(), html)
            viewEngineResult.View.Render(viewContext, html)

            Dim htmlString As String = html.ToString()

            ' get base url
            Dim baseUrl As String = Me.ControllerContext.HttpContext.Request.
                Url.AbsoluteUri.Substring(0, Me.ControllerContext.HttpContext.Request.
                Url.AbsoluteUri.Length - "CurrentWebPageToPdf/Convert".Length)

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' create a new pdf document converting a html string
            Dim doc As PdfDocument = converter.ConvertHtmlString(htmlString, baseUrl)

            ' save pdf document
            Dim pdf As Byte() = doc.Save()

            ' close pdf document
            doc.Close()

            ' return resulted pdf document
            Dim fileResult As FileResult = New FileContentResult(pdf, "application/pdf")
            fileResult.FileDownloadName = "Document.pdf"
            Return fileResult
        End Function

        Private Function GetViewData(collection As FormCollection) As ViewDataDictionary
            Dim MyViewData As New ViewDataDictionary()

            MyViewData.Add("SampleText", collection("TxtSampleText"))
            MyViewData.Add("DropDownList1", collection("DropDownList1"))

            Dim DropDownList1 As New List(Of SelectListItem)()
            DropDownList1.Add(New SelectListItem() With {
                 .Text = "Value1",
                 .Value = "Value1",
                 .Selected = MyViewData("DropDownList1") IsNot Nothing _
                 AndAlso MyViewData("DropDownList1").ToString() = "Value1"
            })
            DropDownList1.Add(New SelectListItem() With {
                .Text = "Value2",
                .Value = "Value2",
                .Selected = MyViewData("DropDownList1") IsNot Nothing _
                AndAlso MyViewData("DropDownList1").ToString() = "Value2"
            })
            DropDownList1.Add(New SelectListItem() With {
                 .Text = "Value3",
                 .Value = "Value3",
                 .Selected = MyViewData("DropDownList1") IsNot Nothing _
                 AndAlso MyViewData("DropDownList1").ToString() = "Value3"
            })
            DropDownList1.Add(New SelectListItem() With {
                 .Text = "Value4",
                 .Value = "Value4",
                 .Selected = MyViewData("DropDownList1") IsNot Nothing _
                 AndAlso MyViewData("DropDownList1").ToString() = "Value4"
            })

            MyViewData.Add("DropDownList1Items", DropDownList1)

            MyViewData.Add("SampleCheckbox", collection("ChkSampleCheckbox") = "on")

            MyViewData.Add("SampleText2", collection("TxtSampleText2"))
            MyViewData.Add("SampleText3", collection("TxtSampleText3"))

            Return MyViewData

        End Function
    End Class
End Namespace