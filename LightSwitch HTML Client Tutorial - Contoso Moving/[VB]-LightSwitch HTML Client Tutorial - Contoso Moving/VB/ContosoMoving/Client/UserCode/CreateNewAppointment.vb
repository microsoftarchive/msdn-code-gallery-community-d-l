
Namespace LightSwitchApplication

    Public Class CreateNewAppointment

        Private Sub CreateNewAppointment_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            Me.AppointmentProperty = New Appointment()
            If (CustomerID.HasValue) Then
                Me.AppointmentProperty.Customer = (From c In DataWorkspace.ApplicationData.Customers Where c.Id = CustomerID).SingleOrDefault()
            End If
        End Sub

        Private Sub CreateNewAppointment_Saved()
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.AppointmentProperty)
        End Sub

    End Class

End Namespace