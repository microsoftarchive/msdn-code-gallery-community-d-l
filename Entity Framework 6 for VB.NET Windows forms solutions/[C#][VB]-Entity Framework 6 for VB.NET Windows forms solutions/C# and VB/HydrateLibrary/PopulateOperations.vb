Imports System.Data.Entity
Imports BackendOperations
''' <summary>
''' Used to move data to SQL-Server 
''' DO NOT RUN UNLESS YOU ARE AWARE OF THE RESULT
''' </summary>
Public Class PopulateOperations
    Public Sub InsertFirstNames()
        Dim TI As Globalization.TextInfo = New Globalization.CultureInfo("en-US", True).TextInfo
        Dim fileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FirstNames.txt")

        Dim Names = (From item In IO.File.ReadAllLines(fileName)
                     Select TI.ToTitleCase(item.ToLower)).Distinct.OrderBy(Function(item) item).Take(3000).ToList

        Using entity As New DataEntities
            For Each firstName As String In Names
                Dim Name As New FirstName With {.Name = firstName}
                entity.Entry(Name).State = EntityState.Added
            Next
            entity.SaveChanges()
            Console.WriteLine("Done")
        End Using
    End Sub
    Public Sub InsertLastNames()
        Dim TI As Globalization.TextInfo = New Globalization.CultureInfo("en-US", True).TextInfo
        Dim fileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LastNames.txt")

        Dim Names = (From item In IO.File.ReadAllLines(fileName)
                     Select TI.ToTitleCase(item.ToLower)).Distinct.OrderBy(Function(item) item).Take(20000)

        Using entity As New DataEntities
            For Each firstName As String In Names
                Dim Name As New LastName With {.Name = firstName}
                entity.Entry(Name).State = EntityState.Added
            Next
            entity.SaveChanges()
            Console.WriteLine("Done")
        End Using
    End Sub
End Class
