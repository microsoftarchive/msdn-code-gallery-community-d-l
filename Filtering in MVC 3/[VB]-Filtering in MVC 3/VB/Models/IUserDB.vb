Namespace Mvc3Filter.Models
	Public Interface IUserDB
        Property GetAllUsers() As List(Of User)
		Function UserExists(ByVal UserName As String) As Boolean
		Sub CreateNewUser(ByVal newUser As User)
		Function GetUser(ByVal uid As String) As User
		Sub Remove(ByVal usrName As String)
		Sub Update(ByVal userToUpdate As User)
	End Interface
End Namespace
