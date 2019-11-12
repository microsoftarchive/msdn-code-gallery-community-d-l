Imports System.Data.Entity

Public Class MovieInitializer
    Inherits DropCreateDatabaseAlways(Of MovieDBContext)

    Protected Overrides Sub Seed(context As MovieDBContext)
        Dim movies = New List(Of Movie)() From { _
         New Movie() With { _
          .Title = "When Harry Met Sally", _
          .ReleaseDate = DateTime.Parse("1989-1-11"), _
          .Genre = "Romantic Comedy", _
          .Rating = "R", _
          .Price = 7.99D _
         }, _
         New Movie() With { _
          .Title = "Ghostbusters ", _
          .ReleaseDate = DateTime.Parse("1984-3-13"), _
          .Genre = "Comedy", _
          .Rating = "R", _
          .Price = 8.99D _
         }, _
         New Movie() With { _
          .Title = "Ghostbusters 2", _
          .ReleaseDate = DateTime.Parse("1986-2-23"), _
          .Genre = "Comedy", _
          .Rating = "R", _
          .Price = 9.99D _
         }, _
         New Movie() With { _
          .Title = "Rio Bravo", _
          .ReleaseDate = DateTime.Parse("1959-4-15"), _
          .Genre = "Western", _
          .Rating = "R", _
          .Price = 3.99D _
         } _
        }
        movies.ForEach(Function(d) context.Movies.Add(d))
    End Sub

End Class