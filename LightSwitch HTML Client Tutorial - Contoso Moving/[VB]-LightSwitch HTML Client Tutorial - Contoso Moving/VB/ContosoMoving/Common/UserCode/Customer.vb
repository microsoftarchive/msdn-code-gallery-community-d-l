
Namespace LightSwitchApplication

    Public Class Customer

        Private Sub Summary_Compute(ByRef result As String)
            result = String.Format("{0} {1} - {2}", FirstName, LastName, Phone)
        End Sub

    End Class

End Namespace
