Imports System.Configuration
Imports System.IO
Public Class ConnectionProtection
    Public Property FileName As String
    Public Sub New(ByVal ExecutableFileName As String)
        If Not File.Exists(String.Concat(ExecutableFileName, ".config")) Then
            Throw New FileNotFoundException(String.Concat(ExecutableFileName, ".config"))
        End If
        FileName = ExecutableFileName
    End Sub
    Private Function EncryptConnectionString(ByVal encrypt As Boolean, ByVal fileName As String) As Boolean
        Dim success As Boolean = True
        Dim configuration As Configuration = Nothing

        Try

            configuration = ConfigurationManager.OpenExeConfiguration(fileName)
            Dim configSection As ConnectionStringsSection =
                TryCast(configuration.GetSection("connectionStrings"), ConnectionStringsSection)

            If (Not (configSection.ElementInformation.IsLocked)) AndAlso (Not (configSection.SectionInformation.IsLocked)) Then
                If encrypt AndAlso (Not configSection.SectionInformation.IsProtected) Then
                    ' encrypt the file
                    configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
                End If

                If (Not encrypt) AndAlso configSection.SectionInformation.IsProtected Then 'encrypt is true so encrypt
                    ' decrypt the file. 
                    configSection.SectionInformation.UnprotectSection()
                End If

                configSection.SectionInformation.ForceSave = True
                configuration.Save()

                success = True

            End If
        Catch ex As Exception
            success = False
        End Try

        Return success

    End Function
    Public Function IsProtected() As Boolean
        Dim configuration As Configuration = ConfigurationManager.OpenExeConfiguration(FileName)
        Dim configSection As ConnectionStringsSection =
            TryCast(configuration.GetSection("connectionStrings"), ConnectionStringsSection)
        Return configSection.SectionInformation.IsProtected
    End Function
    Public Function EncryptFile() As Boolean
        If File.Exists(FileName) Then
            Return EncryptConnectionString(True, FileName)
        Else
            Return False
        End If
    End Function
    Public Function DecryptFile() As Boolean
        If File.Exists(FileName) Then

            Return EncryptConnectionString(False, FileName)

        Else
            Return False
        End If
    End Function

End Class
