Imports System.Web.Mvc

Imports Mvc3Filter.Models
Imports Mvc3Filter.Filters
Imports Mvc3Filter.Helpers

Namespace Mvc3Filter.Controllers

	Public Class HomeController
		Inherits Controller
		Private _repository As IUserDB

#If InMemDB Then
		Public Sub New()
			Me.New(InMemoryDB.Instance)
		End Sub
#Else
		Public Sub New()
			Me.New(New EF_UserRepository())
		End Sub
#End If


		Public Sub New(ByVal repository As IUserDB)
			_repository = repository
		End Sub

		Public Function Index() As ViewResult
			Return View("Index", _repository.GetAllUsers)
		End Function

		Public Function Details(ByVal id As String) As ActionResult
			Dim user As User = _repository.GetUser(id)
			If user Is Nothing Then
				Return RedirectToAction("Index")
			End If

			Return View("Details", user)
		End Function

		Public Function Edit(ByVal id As String) As ActionResult
			Dim user As User = _repository.GetUser(id)
			If user Is Nothing Then
				Return RedirectToAction("Index")
			End If

			Dim model As New EditUserModel()
			ModelCopier.CopyModel(user, model)

			Return View(model)
		End Function

		<HttpPost>
		Public Function Edit(ByVal model As EditUserModel) As ActionResult
			Try
				Dim user As User = _repository.GetUser(model.UserName)
				ModelCopier.CopyModel(model, user)
				_repository.Update(user)

				Return RedirectToAction("Details", New With {Key .id = model.UserName})
			Catch e1 As Exception
				ModelState.AddModelError("", "Edit Failure, see inner exception.")
			End Try

			Return View(model)
		End Function

		Public Function About() As ActionResult
			Return View()
		End Function

		Public Function Create() As ViewResult
			Return View(New CreateUserModel())
		End Function

		<HttpPost>
		Public Function Create(ByVal model As CreateUserModel) As ActionResult
			Try
				If ModelState.IsValid Then
					Dim user As New User()
					ModelCopier.CopyModel(model, user)
					_repository.CreateNewUser(user)

					Return RedirectToAction("Details", New With {Key .id = user.UserName})
				End If
			Catch e1 As Exception
				ModelState.AddModelError("", "Create Failure, try another user name or" & " see inner exception.")
			End Try

			Return View("Create", model)
		End Function

		Public Function Delete(ByVal id As String) As ActionResult
			Dim user As User = _repository.GetUser(id)
			If user Is Nothing Then
				Return RedirectToAction("Index")
			End If

			Return View(user)
		End Function

		<HttpPost>
		Public Function Delete(ByVal id As String, ByVal collection As FormCollection) As RedirectToRouteResult
			_repository.Remove(id)
			Return RedirectToAction("Index")
		End Function



		Public Function TestStatus(ByVal id As Integer) As ActionResult

			Select Case id
				Case 410
					Return New HttpStatusCodeResult(410, "Please remove this link")


				Case 404
					Return New HttpStatusCodeResult(404)

				Case 40404
					Return HttpNotFound()

				Case 404404
					Return HttpNotFound("My Not Found Message")

				Case Else
					Return New HttpNotFoundResult("file not found")
			End Select
		End Function
	End Class
End Namespace
