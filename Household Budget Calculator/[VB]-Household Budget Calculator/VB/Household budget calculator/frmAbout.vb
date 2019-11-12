Public Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Custom Software." & Environment.NewLine & "Made to order." & Environment.NewLine & "Enquiries:"
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim emailLink As String = "mailto:" & "paul@scproject.biz?subject=Software Enquiry" '&body=i know how to programmatically add an attachment to your email"
        Process.Start(emailLink)
    End Sub
End Class