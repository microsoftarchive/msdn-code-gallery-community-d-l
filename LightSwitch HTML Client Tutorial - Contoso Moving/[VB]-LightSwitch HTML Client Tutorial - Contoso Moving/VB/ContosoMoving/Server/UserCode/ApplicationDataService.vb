
Namespace LightSwitchApplication

    Public Class ApplicationDataService

        Private Sub UpcomingAppointments_PreprocessQuery(ByRef query As System.Linq.IQueryable(Of LightSwitchApplication.Appointment))
            query = (From appt In query Where appt.Employee.UserName = Application.User.Name AndAlso appt.StartDate >= Today).Take(15)
        End Sub

        Private Sub UpcomingAppointmentsForAllEmployees_PreprocessQuery(ByRef query As System.Linq.IQueryable(Of LightSwitchApplication.Appointment))
            query = (From appt In query Where appt.StartDate >= Today).Take(15)
        End Sub

        Private Sub AvailableEmployees_PreprocessQuery(StartTime As System.Nullable(Of Date), EndTime As System.Nullable(Of Date), ByRef query As System.Linq.IQueryable(Of LightSwitchApplication.Employee))
            Dim employeeIDs As New List(Of Integer)

            For Each employee As Employee In Employees
                Dim newAppt As Appointment = Nothing
                Dim isEmployeeAvailable = True
                Dim index As Integer = 0
                While (index < employee.Appointments.Count() And isEmployeeAvailable)
                    newAppt = employee.Appointments.ElementAt(index)
                    If ((newAppt.StartDate >= StartTime And newAppt.StartDate < EndTime) Or
                        (newAppt.EndDate > StartTime And newAppt.EndDate <= EndTime)) Then
                        isEmployeeAvailable = False
                    End If
                    index += 1
                End While
                If (isEmployeeAvailable) Then
                    employeeIDs.Add(employee.Id)
                End If
            Next
            ' Query results are sorted by the appointment count so the employees with the fewest appointments are most likely to be assigned
            ' a new appointment
            query = From emp As Employee In query Where employeeIDs.Contains(emp.Id) Select emp Order By emp.Appointments.Count() Ascending
        End Sub

    End Class

End Namespace
