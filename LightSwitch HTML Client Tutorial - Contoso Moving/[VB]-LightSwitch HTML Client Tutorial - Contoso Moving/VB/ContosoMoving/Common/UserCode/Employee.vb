
Namespace LightSwitchApplication

    Public Class Employee

        Private Sub Summary_Compute(ByRef result As String)
            result = String.Format("{0} {1} ({2})", FirstName, LastName, UserName)
        End Sub

    End Class

End Namespace
