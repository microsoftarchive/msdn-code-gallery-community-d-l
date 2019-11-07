
Namespace LightSwitchApplication

    Public Class CreateSampleData

        Private Sub AddAll_Execute()
            InsertStates()
            InsertEmployees()
            Save()
            InsertCustomers()
            CreateSampleAppointments()
            Save()
            AddSampleUsers()
        End Sub

        Private Sub AddCustomers_Execute()
            InsertCustomers()
        End Sub

        Private Sub AddCustomers_CanExecute(ByRef result As Boolean)
            ' Make sure states have been added before trying to add customers
            result = States.Count >= 50
        End Sub

        Private Sub AddEmployees_Execute()
            InsertEmployees()
        End Sub

        Private Sub AddStates_Execute()
            InsertStates()
        End Sub

        Private Sub AddUsers_Execute()
            AddSampleUsers()
        End Sub

        Private Sub AddUsers_CanExecute(ByRef result As Boolean)
            result = Application.User.HasPermission(Permissions.SecurityAdministration)
        End Sub

        Private Sub CreateAppointments_Execute()
            Me.CreateSampleAppointments()
        End Sub

        Private Sub CreateAppointments_CanExecute(ByRef result As Boolean)
            result = Me.Customers.Count > 0
        End Sub

        Private Sub CreateSampleAppointments()
            FindControl("AppointmentsGroup").Show()
            Dim count As Integer = 0
            Dim rand As New Random()
            For Each cust As Customer In Customers
                Dim newAppt As New Appointment()
                With newAppt
                    Select Case count Mod 5
                        Case 2
                            .MoveType = MoveTypeValues.Business
                        Case 3, 4
                            .MoveType = MoveTypeValues.Apartment
                        Case Else
                            .MoveType = MoveTypeValues.Residential
                    End Select
                    ' Choose a random time during the day that's within working hours
                    .StartDate = Today.AddHours(rand.Next(8) + 8)
                    ' Schedule appointments up to 30 days out
                    .StartDate = .StartDate.AddDays(rand.Next(30))

                    .Street = cust.Street
                    .StreetLine2 = cust.StreetLine2
                    .City = cust.City
                    .State = cust.State
                    .PostalCode = cust.PostalCode

                    Me.StartTime = .StartDate
                    Me.EndTime = .EndDate
                    .Employee = AvailableEmployees.FirstOrDefault()
                End With
                cust.Appointments.Add(newAppt)
                ' We need to save the new appointment now so we don't introduce conflicts in the employee assignment
                Me.Save()
                count += 1
            Next
        End Sub

        Private Sub InsertStates()
            FindControl("StatesGroup").Show()
            Dim stateListing = AllStates.Split(";")
            For Each stateString As String In stateListing
                Dim stateToken = stateString.Split(":")
                Dim name = stateToken(0).Trim()
                Dim abbrv = stateToken(1).Trim()

                Dim existingState = (From s In DataWorkspace.ApplicationData.States Where s.Name = name Or s.Abbreviation = abbrv).SingleOrDefault()
                If (existingState Is Nothing) Then
                    Dim newState = Me.States.AddNew()
                    newState.Abbreviation = abbrv
                    newState.Name = name
                End If
            Next
        End Sub

        Private Sub InsertEmployees()
            FindControl("EmployeesGroup").Show()
            For Each emp In AllEmployees.Split(";")
                Dim empToken = emp.Split(",")
                If (empToken.Length >= 5) Then
                    Dim existingEmployee = (From e In DataWorkspace.ApplicationData.Employees Where e.UserName = empToken(2)).SingleOrDefault()
                    If (existingEmployee Is Nothing) Then
                        Dim newEmployee = Employees.AddNew()
                        With newEmployee
                            .FirstName = empToken(0)
                            .LastName = empToken(1)
                            .UserName = empToken(2)
                            .Email = empToken(3)
                            .Phone = empToken(4)
                        End With
                    End If
                End If
            Next
        End Sub

        Private Sub InsertCustomers()
            FindControl("CustomersGroup").Show()
            Dim customerListing = AllCustomers.Split(";")
            For Each cust In customerListing
                Dim custToken = cust.Split(",")
                If (custToken.Length >= 9) Then
                    Dim existingCustomer = (From c In DataWorkspace.ApplicationData.Customers Where c.FirstName = custToken(0) And c.LastName = custToken(1)).SingleOrDefault()
                    If (existingCustomer Is Nothing) Then
                        Dim newCustomer = Customers.AddNew()
                        With newCustomer
                            .FirstName = custToken(0)
                            .LastName = custToken(1)
                            .Email = custToken(2)
                            .Phone = custToken(3)
                            .Street = custToken(4)
                            .StreetLine2 = custToken(5)
                            .City = custToken(6)
                            .PostalCode = custToken(7)
                            .State = (From s In DataWorkspace.ApplicationData.States Where s.Abbreviation = custToken(8)).SingleOrDefault()
                        End With
                    End If
                End If
            Next
        End Sub

        Private Sub AddSampleUsers()
            If (Application.User.HasPermission(SecurityAdministration)) Then
                For Each e In Employees
                    Dim existingUser = (From u In DataWorkspace.SecurityData.UserRegistrations Where u.UserName = e.UserName).SingleOrDefault()
                    If (existingUser Is Nothing) Then
                        Dim newUser = DataWorkspace.SecurityData.UserRegistrations.AddNew()
                        newUser.UserName = e.UserName
                        newUser.Password = "pass@word1"
                        newUser.FullName = e.FirstName + " " + e.LastName
                    End If
                Next
                DataWorkspace.SecurityData.SaveChanges()
            End If
        End Sub

        Private Const AllStates As String = "Alabama: AL;Alaska: AK;Arizona: AZ;Arkansas: AR;California: CA;Colorado: CO;Connecticut: CT;Delaware: DE;Florida: FL;Georgia: GA;Hawaii: HI;Idaho: ID;Illinois: IL;Indiana: IN;Iowa: IA;Kansas: KS;Kentucky: KY;Louisiana: LA;Maine: ME;Maryland: MD;Massachusetts: MA;Michigan: MI;Minnesota: MN;Mississippi: MS;Missouri: MO;Montana: MT;Nebraska: NE;Nevada: NV;New Hampshire: NH;New Jersey: NJ;New Mexico: NM;New York: NY;North Carolina: NC;North Dakota: ND;Ohio: OH;Oklahoma: OK;Oregon: OR;Pennsylvania: PA;Rhode Island: RI;South Carolina: SC;South Dakota: SD;Tennessee: TN;Texas: TX;Utah: UT;Vermont: VT;Virginia: VA;Washington: WA;West Virginia: WV;Wisconsin: WI;Wyoming: WY"
        Private Const AllEmployees As String = "Terry,Adams,TAdams,terry1@adventure-works.com,944-555-0148;Peter,Bankov,PBankov,peter0@adventure-works.com,279-555-0130;Test,User,TestUser,testuser@adventure-works.com,127-555-0124"
        Private Const AllCustomers As String = "Gustavo,Achong,gustavo0@adventure-works.com,398-555-0132,1970 Napa Ct.,,Bothell,98011,WA;Kim,Akers,kim0@adventure-works.com,747-555-0171,9833 Mt. Dias Blv.,,Bothell,98011,WA;Josh,Bailey,josh2@adventure-works.com,334-555-0137,7484 Roundtree Drive,,Bothell,98011,WA;Rob,Cason,rob0@adventure-works.com,599-555-0127,9539 Glenside Dr,,Bothell,98011,WA;Jan,Dryml,jan1@adventure-works.com,500 555-0132,1226 Shoe St.,,Bothell,98011,WA;Daniel,Escapa,daniel0@adventure-works.com,991-555-0183,1399 Firestone Drive,,Bothell,98011,WA;William,Flash,william0@adventure-works.com,959-555-0151,5672 Hale Dr.,,Bothell,98011,WA;David,Galvin,david0@adventure-works.com,107-555-0138,6387 Scenic Avenue,,Bothell,98011,WA;Sidney,Higa,sidney1@adventure-works.com,158-555-0142,8713 Yosemite Ct.,,Bothell,98011,WA;Julia,Ilyina,julia0@adventure-works.com,453-555-0165,250 Race Court,,Bothell,98011,WA;Darcy,Jayne,darcy0@adventure-works.com,554-555-0110,1318 Lasalle Street,,Bothell,98011,WA;Russell,King,russell2@adventure-works.com,1 500 555-0198,5415 San Gabriel Dr.,,Bothell,98011,WA;Karin,Lamb,karin1@adventure-works.com,678-555-0175,9265 La Paz,,Bothell,98011,WA;Bill,Malone,bill1@adventure-works.com,571-555-0128,8157 W. Book,,Bothell,98011,WA;Mike,Nash,mike3@adventure-works.com,440-555-0166,4912 La Vuelta,,Bothell,98011,WA;Tad,Orman,tad0@adventure-works.com,1 500 555-0150,40 Ellis St.,,Bothell,98011,WA;Lori,Penor,lori1@adventure-works.com,727-555-0115,6696 Anchor Drive,,Bothell,98011,WA;Privthi,Raj,privthi0@adventure-works.com,197-555-0143,1873 Lion Circle,,Bothell,98011,WA;Naoki,Sato,naoki0@adventure-works.com,492-555-0189,3148 Rose Street,,Bothell,98011,WA;Karen,Toh,karen2@adventure-works.com,331-555-0162,6872 Thornwood Dr.,,Bothell,98011,WA;Sunil,Uppal,sunil0@adventure-works.com,968-555-0153,5747 Shirley Drive,,Bothell,98011,WA;Olya,Veselova,olya0@adventure-works.com,845-555-0187,636 Vine Hill Way,,Portland,97205,OR;Tony,Wang,tony0@adventure-works.com,115-555-0175,6657 Sand Pointe Lane,,Seattle,98104,WA;Joanna,Yuan,joanna1@adventure-works.com,226-555-0146,1902 Santa Cruz,,Bothell,98011,WA;Jason,Zander,jason6@adventure-works.com,149-555-0113,793 Crawford Street,,Kenmore,98028,WA;Jim,Glynn,jim3@adventure-works.com,556-555-0145,463 H Stagecoach Rd.,,Kenmore,98028,WA;Jane,Dow,jane0@adventure-works.com,129-555-0110,5203 Virginia Lane,,Kenmore,98028,WA;Steve,Luper,steve7@adventure-works.com,1 500 555-0139,4095 Cooper Dr.,,Kenmore,98028,WA;Paulo,Neves,paulo2@adventure-works.com,665-555-0198,6697 Ridge Park Drive,,Kenmore,98028,WA;Stig,Panduro,stig1@adventure-works.com,818-555-0171,5669 Ironwood Way,,Kenmore,98028,WA;Kelly,Rollin,kelly0@adventure-works.com,1 500 555-0187,8192 Seagull Court,,Kenmore,98028,WA;Ben,Smith,ben0@adventure-works.com,221-555-0167,5553 Cash Avenue,,Kenmore,98028,WA;Linda,Timm,linda0@adventure-works.com,121-555-0157,7048 Laurel,,Kenmore,98028,WA;Colin,Wilcox,colin3@adventure-works.com,234-555-0112,25 95th Ave NE,,Kenmore,98028,WA"

    End Class

End Namespace
