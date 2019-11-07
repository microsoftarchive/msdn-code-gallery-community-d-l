Public Class ControlInfoPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim textbox = TryCast(PreviousPage.FindControl("DataToSendTextbox"), TextBox)
        If textbox IsNot Nothing Then
            DataReceivedLabel.Text = textbox.Text
        End If
    End Sub

End Class