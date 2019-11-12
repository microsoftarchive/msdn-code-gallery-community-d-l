Imports System.Activities
Imports WorkflowLibrary

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ButtonCreateGreeting_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCreateGreeting.Click
        Dim username As String = TextBoxName.Text

        Dim greeting As Greeting = New Greeting With {.ArgUserName = username}

        Dim results As IDictionary(Of String, Object) = WorkflowInvoker.Invoke(greeting)
        LabelGreeting.Text = results("Result").ToString()
    End Sub

End Class