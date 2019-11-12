Imports System.Data.SqlClient
Imports System.IO

Public Class SqlServerOperations
    Inherits BaseSqlServerConnection

    Public Property ExceptionMessage As String
    ''' <summary>
    ''' Copy template excel file to app folder
    ''' </summary>
    ''' <param name="pFileName"></param>
    ''' <returns></returns>
    Public Function CopyToApplicationFolder(pFileName As String) As Boolean

        Try
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                   $"Files\{Path.GetFileName(pFileName)}"),
                      Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFileName), True)

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' Copy template file to app folder with a different name
    ''' </summary>
    ''' <param name="pFileName"></param>
    ''' <param name="pTargetFile"></param>
    ''' <returns></returns>
    Public Function CopyToApplicationFolder(pFileName As String, pTargetFile As String) As Boolean

        Try
            File.Copy(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\{IO.Path.GetFileName(pFileName)}"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pTargetFile),
                True)

            Return True

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try

    End Function
    ''' <summary>
    ''' Create a list of countries that has names without spaces
    ''' </summary>
    ''' <returns></returns>
    Public Function CountryList() As List(Of CountryItem)
        Dim countrys As New List(Of CountryItem)
        countrys.Add(New CountryItem With {.Name = "Select"})

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT DISTINCT Country  FROM Customers"

                cn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader

                If reader.HasRows Then
                    While reader.Read
                        countrys.Add(New CountryItem With {.Name = reader.GetString(0)})
                    End While
                End If
            End Using

        End Using

        Return countrys

    End Function
    ''' <summary>
    ''' Get list of contact titles, not used
    ''' </summary>
    ''' <returns></returns>
    Public Function ContactTitleList() As List(Of String)
        Dim titleList As New List(Of String) From {
            "Select"
        }

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT DISTINCT ContactTitle  FROM Customers"

                cn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader

                If reader.HasRows Then
                    While reader.Read
                        titleList.Add(reader.GetString(0))
                    End While
                End If
            End Using

        End Using

        Return titleList

    End Function
    ''' <summary>
    ''' Read data from table, not used
    ''' </summary>
    ''' <returns></returns>
    Public Function GetCustomers() As DataTable
        Dim dt As New DataTable

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT id,FirstName,LastName,Address,City,State,ZipCode FROM Customer"

                cn.Open()

                dt.Load(cmd.ExecuteReader)

            End Using

        End Using

        Return dt

    End Function
    ''' <summary>
    ''' Export data to Excel
    ''' </summary>
    ''' <param name="pFileName"></param>
    ''' <param name="pRowsExported">If successful will have count of rows exported</param>
    ''' <returns></returns>
    Public Function ExportAllCustomersToExcel(pFileName As String, ByRef pRowsExported As Integer) As Boolean
        If Not File.Exists(pFileName) Then
            ExceptionMessage = $"Not found{Environment.NewLine}{pFileName}"
            Return False
        End If

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText = "INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0'," &
                                    $"'Excel 12.0;Database={pFileName}','SELECT * " &
                                    "FROM [Customers$]') SELECT CustomerIdentifier," &
                                    "CompanyName,ContactName,ContactTitle,[Address]," &
                                    "City,Region,PostalCode,Country,Phone FROM Customers"

                cn.Open()

                Try

                    pRowsExported = cmd.ExecuteNonQuery

                    Return pRowsExported > 0

                Catch ex As Exception

                    ExceptionMessage = ex.Message
                    Return False

                End Try
            End Using
        End Using
    End Function
    ''' <summary>
    ''' Export data to Excel
    ''' </summary>
    ''' <param name="pFileName"></param>
    ''' <param name="pCountry">Name of country for filter</param>
    ''' <param name="pRowsExported">If successful will have count of rows exported</param>
    ''' <returns></returns>
    Public Function ExportByCountryNameCustomersToExcel(pFileName As String, pCountry As String, ByRef pRowsExported As Integer) As Boolean
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText =
                    "INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0','Excel 12.0;" &
                    $"Database={pFileName}'," &
                    "'SELECT * FROM [Customers$]') SELECT CustomerIdentifier," &
                    "CompanyName,ContactName," &
                    "ContactTitle,[Address],City,Region,PostalCode,Country,Phone " &
                    "FROM Customers WHERE Country = @Country"

                cmd.Parameters.AddWithValue("@Country", pCountry)

                cn.Open()

                Try

                    pRowsExported = cmd.ExecuteNonQuery

                    Return pRowsExported > 0

                Catch ex As Exception
                    '
                    ' Possible causes if all is setup right in SQL-Server Management Studio
                    '   - invalid characters in file name, SQL-Server rejected them.
                    '   - Permissions on the folder or file
                    '
                    ExceptionMessage = $"Note: The following error may not appear as it is{Environment.NewLine}" & ex.Message
                    Return False
                End Try
            End Using
        End Using
    End Function
End Class
