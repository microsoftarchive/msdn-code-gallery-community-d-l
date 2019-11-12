Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Threading

Public Class UploadFiles

    Private ArgList As SortedList(Of String, String) = New SortedList(Of String, String)(4)
    Private _webClient As WebClient

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="args"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal args() As String)

        Dim key As String = Nothing

        For Each arg In args
            If arg(0) = "-"c Then
                key = arg.ToLower
            ElseIf key IsNot Nothing Then
                If Not ArgList.ContainsKey(key) Then
                    ArgList.Add(key, arg)
                End If
            End If
        Next

        If (Not ArgList.ContainsKey("-source")) Or (Not ArgList.ContainsKey("-ftpdest")) Then
            Console.WriteLine("Usage: WebClientFtp -source <path-to-local-folder> -ftpdest <uri-ftp-directory>")
            Console.WriteLine("                  [ -user <userName> -pwd <password> ]")
            Console.WriteLine("       -source and -ftpdest are required arguments")
            Console.ReadKey(True)
            Environment.Exit(1)
        End If

        _webClient = New WebClient()
    End Sub

    ''' <summary>
    ''' Copy files in -source path to ftp directory specified by -ftpdest arg
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CopyFolderFiles()
        Dim sPath As String
        sPath = ArgList("-source")

        If Directory.Exists(sPath) Then
            'get all files in path
            Dim files() As String
            files = Directory.GetFiles(sPath, "*.*", SearchOption.TopDirectoryOnly)
            'if user and password exist, set credentials
            If (ArgList.ContainsKey("-user")) And (ArgList.ContainsKey("-pwd")) Then
                _webClient.Credentials = New NetworkCredential(ArgList("-user"), _
                                                               ArgList("-pwd"))
            End If

            Dim UploadCompleted As Boolean
            Dim wait As Integer = My.Settings.WaitInterval
            Dim ftpDest As String = ArgList("-ftpdest")

            'loop through files in folder and upload
            For Each file In files
                Do
                    UploadCompleted = ftpUpFile(file, ftpDest)
                    If Not UploadCompleted Then
                        Thread.Sleep(wait)
                        wait += 1000 'wait an extra second after each failed attempt
                    End If
                Loop Until UploadCompleted
            Next
        End If
    End Sub

    Private Function ftpUpFile(ByVal filePath As String, ByVal ftpUri As String) _
                     As Boolean
        Try
            Console.WriteLine("Uploading file: " + filePath + " To: " + ftpUri)

            'create full uri path
            Dim file As String = ftpUri + "/" + Path.GetFileName(filePath)

            'ftp the file to Uri path via the ftp STOR command
            '(ignoring the the Byte[] array return since it is always empty in this case)
            _webClient.UploadFile(file, filePath)
            Console.WriteLine("Upload complete.")
            Return True
        Catch ex As Exception
            'WebException is frequenty thrown for this condition: 
            '    "An error occurred while uploading the file"
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

End Class
