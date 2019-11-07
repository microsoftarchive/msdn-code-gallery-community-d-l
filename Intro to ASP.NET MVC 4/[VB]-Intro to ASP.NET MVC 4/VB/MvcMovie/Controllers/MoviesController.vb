Imports System.Data.Entity

Namespace MvcMovie
    Public Class MoviesController
        Inherits System.Web.Mvc.Controller

        Private db As New MovieDBContext

        '
        ' GET: /Movies/

        Function Index() As ActionResult
            Return View(db.Movies.ToList())
        End Function

        '
        ' GET: /Movies/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim movie As Movie = db.Movies.Find(id)
            If IsNothing(movie) Then
                Return HttpNotFound()
            End If
            Return View(movie)
        End Function

        '
        ' GET: /Movies/Create

        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Movies/Create

        <HttpPost()> _
        Function Create(ByVal movie As Movie) As ActionResult
            If ModelState.IsValid Then
                db.Movies.Add(movie)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(movie)
        End Function

        '
        ' GET: /Movies/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim movie As Movie = db.Movies.Find(id)
            If IsNothing(movie) Then
                Return HttpNotFound()
            End If
            Return View(movie)
        End Function

        '
        ' POST: /Movies/Edit/5

        <HttpPost()> _
        Function Edit(ByVal movie As Movie) As ActionResult
            If ModelState.IsValid Then
                db.Entry(movie).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(movie)
        End Function

        '
        ' GET: /Movies/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim movie As Movie = db.Movies.Find(id)
            If IsNothing(movie) Then
                Return HttpNotFound()
            End If
            Return View(movie)
        End Function

        '
        ' POST: /Movies/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim movie As Movie = db.Movies.Find(id)
            db.Movies.Remove(movie)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

        Function SearchIndex(ByVal movieGenre As String, ByVal searchString As String) As ActionResult

            Dim genreList As New List(Of String)

            Dim genreQuery = From d In db.Movies Order By d.Genre Select d.Genre

            genreList.AddRange(genreQuery.Distinct)
            ViewData("MovieGenre") = New SelectList(genreList)

            Dim movies = From m In db.Movies Select m

            If String.IsNullOrEmpty(searchString) = False Then
                movies = movies.Where(Function(s) s.Title.Contains(searchString))
            End If

            If String.IsNullOrEmpty(movieGenre) Then
                Return View(movies)
            Else
                Return View(movies.Where(Function(x) x.Genre = movieGenre))
            End If

        End Function

    End Class
End Namespace