Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim FilePath As String = ""
        FilePath = Server.MapPath("~/App_Data/" + FileUpload1.PostedFile.FileName)
        If FileUpload1.HasFile Then
            ImportDataFromExcel(FilePath)
        End If
    End Sub
    Public Sub ImportDataFromExcel(excelFilePath As String)
        'declare variables - edit these based on your particular situation
        Dim ssqltable As String = "Table1"
        ' make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different
        Dim myexceldataquery As String = "select student,rollno,course from [sheet1$]"
        Try
            'create our connection strings
            Dim sexcelconnectionstring As String = (Convert.ToString("provider=microsoft.jet.oledb.4.0;data source=") & excelFilePath) + ";extended properties=" + """excel 8.0;hdr=yes;"""
            Dim ssqlconnectionstring As String = "Data Source=SAYYED;Initial Catalog=SyncDB;Integrated Security=True"
            'execute a query to erase any previous data from our destination table
            Dim sclearsql As String = Convert.ToString("delete from ") & ssqltable
            Dim sqlconn As New SqlConnection(ssqlconnectionstring)
            Dim sqlcmd As New SqlCommand(sclearsql, sqlconn)
            sqlconn.Open()
            sqlcmd.ExecuteNonQuery()
            sqlconn.Close()
            'series of commands to bulk copy data from the excel file into our sql table
            Dim oledbconn As New OleDbConnection(sexcelconnectionstring)
            Dim oledbcmd As New OleDbCommand(myexceldataquery, oledbconn)
            oledbconn.Open()
            Dim dr As OleDbDataReader = oledbcmd.ExecuteReader()
            Dim bulkcopy As New SqlBulkCopy(ssqlconnectionstring)
            bulkcopy.DestinationTableName = ssqltable
            While dr.Read()
                bulkcopy.WriteToServer(dr)
            End While
            dr.Close()
            oledbconn.Close()
            Label1.Text = "File imported into sql server."
            'handle exception
        Catch ex As Exception
        End Try
    End Sub
End Class