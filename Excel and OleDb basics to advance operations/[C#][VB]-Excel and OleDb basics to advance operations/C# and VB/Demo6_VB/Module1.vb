Imports System.IO

Module Module1
    Public Sub CopyFileToDebugFolder()

        Try
            File.Copy(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\File1.xlsx"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx"),
                True
            )

        Catch ex As Exception
            '
            ' Drop here if the file is open via Excel or code. We could create a loop and 
            ' keep retrying which I have done but here let's keep it simple.
            '
            If ex.Message.Contains("cannot access") Then

                MessageBox.Show(
                    "I believe someone has the file open because I can not open" &
                    Environment.NewLine &
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx"))

            Else
                MessageBox.Show(ex.Message)
            End If

        End Try

    End Sub
End Module
