
Namespace LightSwitchApplication

    Public Class CustomerDetail

        Private Sub Customer_Loaded(succeeded As Boolean)
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Customer)
        End Sub

        Private Sub Customer_Changed()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Customer)
        End Sub

        Private Sub CustomerDetail_Saved()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Customer)
        End Sub

        Private Sub NewAppointment_Execute()
            Application.ShowCreateNewAppointment(Me.CustomerId)
        End Sub
    End Class

End Namespace