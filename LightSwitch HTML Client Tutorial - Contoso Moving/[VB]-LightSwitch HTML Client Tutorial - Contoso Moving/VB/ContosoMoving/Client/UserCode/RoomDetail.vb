
Namespace LightSwitchApplication

    Public Class RoomDetail

        Private Sub Room_Loaded(succeeded As Boolean)
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Room)
        End Sub

        Private Sub Room_Changed()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Room)
        End Sub

        Private Sub RoomDetail_Saved()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Room)
        End Sub

    End Class

End Namespace