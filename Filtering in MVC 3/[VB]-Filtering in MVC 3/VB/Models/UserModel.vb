Imports System.ComponentModel.DataAnnotations

Namespace Mvc3Filter.Models
	Public Class EditUserModel
		<Editable(False)>
		Public Overridable Property UserName() As String

		<Required, StringLength(18, MinimumLength := 3), Display(Name := "First Name")>
		Public Property FirstName() As String

		<Required, StringLength(9, MinimumLength := 2), Display(Name := "Last Name")>
		Public Property LastName() As String
		<Required()>
		Public Property City() As String
	End Class

	Public Class CreateUserModel
		Inherits EditUserModel
		<Required, StringLength(6, MinimumLength := 3), RegularExpression("(\S)+", ErrorMessage := "White space is not allowed"), Editable(True)>
		Public Overrides Property UserName() As String
	End Class

End Namespace
