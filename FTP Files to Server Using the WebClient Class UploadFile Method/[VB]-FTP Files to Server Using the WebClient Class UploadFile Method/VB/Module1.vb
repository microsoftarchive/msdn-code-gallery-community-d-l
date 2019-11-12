Module Module1

    Sub Main(ByVal args() As String)

        Try
            Dim uploadFls As UploadFiles = New UploadFiles(args)
            uploadFls.CopyFolderFiles()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

End Module
