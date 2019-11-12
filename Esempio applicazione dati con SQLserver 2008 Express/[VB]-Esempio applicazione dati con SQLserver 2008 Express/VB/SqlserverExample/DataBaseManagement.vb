'dll .netFramework
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports System.Windows.Forms
Imports System.Data


' Classe DataBaseManagement
Public Class DatabaseManagement
    ' Metodo getConnectionString
    Private Function getConnectionString() As String
        ' Dichiaro una nuova istanza della Classe SqlConnectionStringBuilder
        Dim builder As New SqlConnectionStringBuilder()

        ' Assegno il nome del Server alla quale connettersi
        builder.DataSource = ".\SQLEXPRESS"
        ' Assegno il nome e il percorso del DataBase alla quale collegarsi
        builder.AttachDBFilename = "E:\Example.mdf"
        ' Gestisco le credenziali di accesso Windows corrente
        builder.IntegratedSecurity = True
        ' Imposto tempo di attesa per connessione a DataBase Example1
        builder.ConnectTimeout = 30
        builder.UserInstance = True
        ' Restituisco la stringa di Connessione al DataBase
        Return builder.ConnectionString
    End Function

    ' Metodo insertData , richiede tre parametri , il nome , il cognome , l'età per l'inserimento all'interno del DataBase
    Public Sub insertData(name As String, surName As String, age As String)
        ' Dichiaro una nuova istanza della Classe SqlConnection
        Dim connection As New SqlConnection(getConnectionString())
        ' Dichiaro una TRANSLAT.SQL di inserimnto dati all'interno della Tabella1
        Dim cmd As New SqlCommand("INSERT INTO TABELLA1 (NOME,COGNOME,AGE) VALUES (@NOME,@COGNOME,@AGE)", connection)

        ' Prova
        Try
            ' Eseguo L'inserimento del valore della variabile name all'interno del campo NOME della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@NOME", name.ToUpper())
            ' Eseguo L'inserimento del valore della variabile name all'interno del campo COGNOME della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@COGNOME", surName.ToUpper())
            ' Eseguo L'inserimento del valore della variabile name all'interno del campo AGE della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@AGE", age.ToUpper())
            ' Apro la connessione con il DataBase Example.mdf
            connection.Open()
            ' Eseguo l'istruzione TRANSLAT.SQL
            cmd.ExecuteNonQuery()
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()

            ' In caso di eccezzione a runtime
        Catch ex As Exception
            ' Visualizzo messaggio errore a ytente
            MessageBox.Show(ex.Message.ToString())
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()
        Finally
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()
        End Try
    End Sub

    ' Metodo deleteData , richiede tre parametri , il nome , il cognome , l'età per l'inserimento all'interno del DataBase
    Public Sub deleteData(name As String, surName As String, age As String)
        ' Dichiaro una nuova istanza della Classe SqlConnection
        Dim connection As New SqlConnection(getConnectionString())
        ' Dichiaro una TRANSLAT.SQL di eliminazione dati all'interno della Tabella1
        Dim cmd As New SqlCommand("DELETE FROM TABELLA1 WHERE NOME = @NOME AND COGNOME = @COGNOME AND AGE = @AGE", connection)

        ' Prova
        Try
            ' Eseguo L'eliminazione del valore della variabile name all'interno del campo NOME della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@NOME", name.ToUpper())
            ' Eseguo L'eliminazione del valore della variabile name all'interno del campo COGNOME della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@COGNOME", surName.ToUpper())
            ' Eseguo L'eliminazione del valore della variabile name all'interno del campo AGE della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@AGE", age.ToUpper())
            ' Apro la connessione con il DataBase Example.mdf
            connection.Open()
            ' Eseguo l'istruzione TRANSLAT.SQL
            cmd.ExecuteNonQuery()
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()

            ' In caso di eccezzione a runtime
        Catch ex As Exception
            ' Visualizzo messaggio errore a ytente
            MessageBox.Show(ex.Message.ToString())
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()
        Finally
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()
        End Try
    End Sub

    ' Metodo updateData , richiede tre parametri , il nome , il cognome , l'età per l'inserimento all'interno del DataBase
    Public Sub updateData(name As String, surName As String, age As String)
        ' Dichiaro una nuova istanza della Classe SqlConnection
        Dim connection As New SqlConnection(getConnectionString())
        ' Dichiaro una TRANSLAT.SQL di aggiornamento dati all'interno della Tabella1
        Dim cmd As New SqlCommand("UPDATE TABELLA1 SET NOME = @NOME,COGNOME = @COGNOME,AGE = @AGE WHERE NOME = @NOME", connection)

        ' Prova
        Try
            ' Eseguo L'aggiornamento del valore della variabile name all'interno del campo NOME della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@NOME", name.ToUpper())
            ' Eseguo L'aggiornamento del valore della variabile name all'interno del campo COGNOME della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@COGNOME", surName.ToUpper())
            ' Eseguo L'aggiornamento del valore della variabile name all'interno del campo AGE della Tabella1 su DataBase Example.mdf
            cmd.Parameters.AddWithValue("@AGE", age.ToUpper())
            ' Apro la connessione con il DataBase Example.mdf
            connection.Open()
            ' Eseguo l'istruzione TRANSLAT.SQL
            cmd.ExecuteNonQuery()
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()

            ' In caso di eccezzione a runtime
        Catch ex As Exception
            ' Visualizzo messaggio errore a ytente
            MessageBox.Show(ex.Message.ToString())
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()
        Finally
            ' Chiudo la connessione con il DataBase Example.mdf
            connection.Close()
            ' Libero tutte le risorse associate alla connessione al DataBase Example.mdf
            connection.Dispose()
        End Try
    End Sub
End Class
