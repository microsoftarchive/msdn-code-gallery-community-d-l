Namespace Controllers
    Public Class ViewHttpPostDataController
        Inherits Controller

        ' GET: ViewHttpPostData
        Function Index() As ActionResult
            Dim output As New StringBuilder()
            output.Append("<br/>Request method: " +
                          Request.HttpMethod + "<br/>")

            ' Load POST form fields collection.
            Dim form As NameValueCollection = Request.Form

            ' Put the names of all keys into a string array.
            Dim keys As [String]() = form.AllKeys
            For i As Integer = 0 To keys.Length - 1
                output.Append("Name: " + keys(i) + "<br/>")

                ' Get all values under this key.
                Dim values As [String]() = form.GetValues(keys(i))
                For j As Integer = 0 To values.Length - 1
                    output.Append("Value: " + values(j) + "<br/>")
                Next
                output.Append("<br/>")
            Next

            ViewData.Add("PostDataValue", output.ToString())

            Return View()
        End Function
    End Class
End Namespace