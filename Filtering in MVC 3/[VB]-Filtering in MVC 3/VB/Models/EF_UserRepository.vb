Namespace Mvc3Filter.Models
	Public Class EF_UserRepository
		Implements Mvc3Filter.Models.IUserDB

		Private _db As New UserDatabaseEntities()

		#Region "IUserDB Members"

		Public Function UserExists(ByVal UserName As String) As Boolean Implements Mvc3Filter.Models.IUserDB.UserExists
			Dim usr = _db.Users.FirstOrDefault(Function(d) d.UserName = UserName)
			Return (usr IsNot Nothing)
		End Function

        Public Property GetAllUsers() As List(Of User) Implements Mvc3Filter.Models.IUserDB.GetAllUsers
            Get
                Return _db.Users.ToList()
            End Get
            Set(ByVal value As List(Of User))

            End Set
        End Property

		Public Sub CreateNewUser(ByVal newUser As User) Implements Mvc3Filter.Models.IUserDB.CreateNewUser
			_db.AddToUsers(newUser)
			_db.SaveChanges()
		End Sub

		Public Function GetUser(ByVal uid As String) As User Implements Mvc3Filter.Models.IUserDB.GetUser
			Return _db.Users.FirstOrDefault(Function(d) d.UserName = uid)
		End Function

		Public Sub Remove(ByVal usrName As String) Implements Mvc3Filter.Models.IUserDB.Remove
			Dim userToRemove = GetUser(usrName)
			_db.Users.DeleteObject(userToRemove)
			_db.SaveChanges()
		End Sub

		Public Sub Update(ByVal userToUpdate As User) Implements Mvc3Filter.Models.IUserDB.Update
			_db.SaveChanges()
		End Sub

		#End Region
	End Class
End Namespace