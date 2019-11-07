Namespace Mvc3Filter.Models
	Public Class InMemoryDB
		Implements Mvc3Filter.Models.IUserDB
		Private Shared _instance As InMemoryDB

		Public Sub New()
			GetAllUsers = New List(Of User) From {
				New User With {.UserName = "BenM", .FirstName = "Ben", .LastName = "Miller", .City = "Seattle"},
				New User With {.UserName = "AnnB", .FirstName = "Ann", .LastName = "Beebe", .City = "Boston"}}
		End Sub

		Public Shared ReadOnly Property Instance() As InMemoryDB
			Get
				If _instance Is Nothing Then
					_instance = New InMemoryDB()
				End If
				Return _instance
			End Get
		End Property

		Private privateGetAllUsers As List(Of User)
		Public Property GetAllUsers() As List(Of User) Implements Mvc3Filter.Models.IUserDB.GetAllUsers
			Get
				Return privateGetAllUsers
			End Get
			Private Set(ByVal value As List(Of User))
				privateGetAllUsers = value
			End Set
		End Property

		Public Function UserExists(ByVal UserName As String) As Boolean Implements Mvc3Filter.Models.IUserDB.UserExists
			For Each usr As User In GetAllUsers
				If String.Equals(usr.UserName, UserName, StringComparison.OrdinalIgnoreCase) Then
					Return True
				End If
			Next usr
			Return False
		End Function


		Public Function GetUser(ByVal uid As String) As User Implements Mvc3Filter.Models.IUserDB.GetUser

			For Each u As User In GetAllUsers
				If u.UserName = uid Then
					Return u
				End If
			Next u

			Return Nothing
		End Function

		Public Sub Update(ByVal userToUpdate As User) Implements Mvc3Filter.Models.IUserDB.Update

			For Each usr As User In GetAllUsers
				If usr.UserName = userToUpdate.UserName Then
					GetAllUsers.Remove(usr)
					GetAllUsers.Add(userToUpdate)
					Exit For
				End If
			Next usr
		End Sub

		Public Sub CreateNewUser(ByVal newUser As User) Implements Mvc3Filter.Models.IUserDB.CreateNewUser
			For Each usr As User In GetAllUsers
				If usr.UserName.ToLowerInvariant() = newUser.UserName.Trim().ToLowerInvariant() Then
					Throw New InvalidOperationException("Duplicate username: " & usr.UserName)
				End If
			Next usr
			GetAllUsers.Add(newUser)
		End Sub

		Public Sub Remove(ByVal usrName As String) Implements Mvc3Filter.Models.IUserDB.Remove

			For Each usr As User In GetAllUsers
				If usr.UserName = usrName Then
					GetAllUsers.Remove(usr)
					Exit For
				End If
			Next usr
		End Sub

	End Class
End Namespace ' namespace