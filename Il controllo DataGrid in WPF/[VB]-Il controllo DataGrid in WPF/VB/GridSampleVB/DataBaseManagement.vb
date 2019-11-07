Imports System.Data
Imports System.Data.SqlServerCe

Public Class DataBaseManagement
    Private ConString As String = "DataSource =" + My.Application.Info.DirectoryPath & "\Rubrica.sdf"
    Private CmdString As String = String.Empty

    Public Function LoadData() As DataTable
        Using con = New SqlCeConnection(ConString)
            CmdString = "SELECT ID, NOME, COGNOME, INDIRIZZO , TELEFONO , NAZIONALITA FROM DATIPERSONALI"
            Dim cmd As SqlCeCommand = New SqlCeCommand(CmdString, con)
            Dim sda As SqlCeDataAdapter = New SqlCeDataAdapter(cmd)
            Dim dt As DataTable = New DataTable("DATIPERSONALI")
            sda.Fill(dt)
            Return dt

        End Using
    End Function

    Public Sub InsertData(name As String, surname As String, address As String, telephone As String, nationality As String)
        Using con = New SqlCeConnection(ConString)
            CmdString = "INSERT INTO DATIPERSONALI (NOME,COGNOME,INDIRIZZO ,TELEFONO ,NAZIONALITA) VALUES (@NOME,@COGNOME,@INDIRIZZO,@TELEFONO,@NAZIONALITA)"
            Dim cmd As SqlCeCommand = New SqlCeCommand(CmdString, con)
            cmd.Parameters.AddWithValue("@NOME", name)
            cmd.Parameters.AddWithValue("@COGNOME", surname)
            cmd.Parameters.AddWithValue("@INDIRIZZO", address)
            cmd.Parameters.AddWithValue("@TELEFONO", telephone)
            cmd.Parameters.AddWithValue("@NAZIONALITA", nationality)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub

    Public Sub DeleteData(name As String, surname As String, address As String, telephone As String, nationality As String)
        Using con = New SqlCeConnection(ConString)
            CmdString = "DELETE FROM DATIPERSONALI WHERE NOME = @NOME AND COGNOME = @COGNOME"
            Dim cmd As SqlCeCommand = New SqlCeCommand(CmdString, con)
            cmd.Parameters.AddWithValue("@NOME", name)
            cmd.Parameters.AddWithValue("@COGNOME", surname)
            cmd.Parameters.AddWithValue("@INDIRIZZO", address)
            cmd.Parameters.AddWithValue("@TELEFONO", telephone)
            cmd.Parameters.AddWithValue("@NAZIONALITA", nationality)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub

    Public Sub UpdateData(name As String, surname As String, address As String, telephone As String, nationality As String, id As String)
        Using con = New SqlCeConnection(ConString)
            CmdString = "DELETE FROM DATIPERSONALI WHERE NOME = @NOME AND COGNOME = @COGNOME"
            Dim cmd As SqlCeCommand = New SqlCeCommand(CmdString, con)
            cmd.Parameters.AddWithValue("@ID", id)
            cmd.Parameters.AddWithValue("@NOME", name)
            cmd.Parameters.AddWithValue("@COGNOME", surname)
            cmd.Parameters.AddWithValue("@INDIRIZZO", address)
            cmd.Parameters.AddWithValue("@TELEFONO", telephone)
            cmd.Parameters.AddWithValue("@NAZIONALITA", nationality)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub

End Class
