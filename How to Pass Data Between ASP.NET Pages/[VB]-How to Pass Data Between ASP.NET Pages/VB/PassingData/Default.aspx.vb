Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub QueryStringButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("QueryStringPage.aspx?Data=" & Server.UrlEncode(DataToSendTextBox.Text))
    End Sub

    Protected Sub SessionStateButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session("Data") = DataToSendTextBox.Text
        Response.Redirect("SessionStatePage.aspx")
    End Sub

    Public ReadOnly Property DataToSend() As String
        Get
            Return DataToSendTextBox.Text
        End Get
    End Property

    Protected Sub PublicPropertiesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Server.Transfer("PublicPropertiesPage.aspx")
    End Sub

    Protected Sub ControlInfoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Server.Transfer("ControlInfoPage.aspx")
    End Sub

End Class