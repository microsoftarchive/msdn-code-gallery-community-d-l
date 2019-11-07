Imports System.Data.SqlClient
Imports System.IO

Public Enum Success
    ''' <summary>
    ''' Successfully completed
    ''' </summary>
    Okay
    ''' <summary>
    ''' Something went wrong
    ''' </summary>
    OhSnap
End Enum
Public Class DatabaseImageOperations
    ''' <summary>
    ''' This points to your database server
    ''' </summary>
    Private databaseServer As String = "KARENS-PC"
    ''' <summary>
    ''' Name of database containing required tables
    ''' </summary>
    Private defaultCatalog As String = "NORTHWND_NEW.MDF"
    Private Property ConnectionString As String = $"Data Source={databaseServer};Initial Catalog={defaultCatalog};Integrated Security=True"
    ''' <summary>
    ''' Indicates a method just executed throw an exception
    ''' </summary>
    ''' <returns></returns>
    Public Property HasError As Boolean
    ''' <summary>
    ''' Works in tangent with HasError
    ''' </summary>
    ''' <returns></returns>
    Public Property ErrorMessage As String
    Public Function HasRecords() As Boolean
        Dim result As Boolean = True
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "SELECT COUNT(ImageID) FROM ImageData"}
                cn.Open()
                result = CInt(cmd.ExecuteScalar) > 0
            End Using
        End Using
        Return result
    End Function
    ''' <summary>
    ''' Given a valid image converts it to a byte array.
    ''' Suitable for saving a file to disk
    ''' </summary>
    ''' <param name="img"></param>
    ''' <returns></returns>
    Public Function ImageToByte(ByVal img As Image) As Byte()
        Dim converter As New ImageConverter()
        Return CType(converter.ConvertTo(img, GetType(Byte())), Byte())
    End Function
    ''' <summary>
    ''' Save image to the sql-server database table
    ''' </summary>
    ''' <param name="Image">Valid image</param>
    ''' <param name="Description">Information to describe the image</param>
    ''' <param name="Identifier">New primary key</param>
    ''' <returns></returns>
    Public Function InsertImage(ByVal Image As Image, ByVal Description As String, ByRef Identifier As Integer) As Success

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "SaveImage", .CommandType = CommandType.StoredProcedure}
                cmd.Parameters.Add("@img", SqlDbType.Image).Value = ImageToByte(Image)
                cmd.Parameters.Add("@description", SqlDbType.Text).Value = Description

                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@new_identity", .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Output})
                Try
                    cn.Open()
                    Identifier = CInt(cmd.ExecuteScalar)
                    Return Success.Okay
                Catch ex As Exception
                    HasError = True
                    ErrorMessage = ex.Message
                    Return Success.OhSnap
                End Try
            End Using
        End Using
    End Function
    ''' <summary>
    ''' Insert image where ImageByes is a byte array from a valid image
    ''' </summary>
    ''' <param name="ImageBytes">Byte array </param>
    ''' <param name="Description">used to describe the image</param>
    ''' <param name="Identifier">New primary key</param>
    ''' <returns></returns>
    Public Function InsertImage(ByVal ImageBytes As Byte(), ByVal Description As String, ByRef Identifier As Integer) As Success

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "SaveImage", .CommandType = CommandType.StoredProcedure}
                cmd.Parameters.Add("@img", SqlDbType.Image).Value = ImageBytes
                cmd.Parameters.Add("@description", SqlDbType.Text).Value = If(String.IsNullOrWhiteSpace(Description), "None", Description)

                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@new_identity", .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Output})
                Try
                    cn.Open()
                    Identifier = CInt(cmd.ExecuteScalar)
                    Return Success.Okay
                Catch ex As Exception
                    HasError = True
                    ErrorMessage = ex.Message
                    Return Success.OhSnap
                End Try
            End Using
        End Using
    End Function
    ''' <summary>
    ''' Set image passed in parameter 2 to bytes returned from image field of Indentifier or
    ''' on error or key not found an error message is set and can be read back by the caller
    ''' </summary>
    ''' <param name="Identifier">primry key to locate</param>
    ''' <param name="inBoundImage">Image to set from returned bytes in database table of found record</param>
    ''' <returns>Success</returns>
    ''' <remarks>
    ''' An alternative is to return the image rather than success as done now
    ''' </remarks>
    Public Function GetImage(ByVal Identifier As Integer, ByRef inBoundImage As Image, ByRef Description As String) As Success
        Dim dtResults As New DataTable
        Dim SuccessType As Success

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "ReadImage", .CommandType = CommandType.StoredProcedure}

                cmd.Parameters.Add("@imgId", SqlDbType.Int).Value = Identifier

                Try

                    cn.Open()
                    dtResults.Load(cmd.ExecuteReader)

                    If dtResults.Rows.Count = 1 Then
                        Dim ms As New MemoryStream(CType(dtResults.Rows(0)("ImageData"), Byte()))
                        Description = CStr(dtResults.Rows(0)("Description"))
                        inBoundImage = Image.FromStream(ms)
                        SuccessType = Success.Okay
                    Else
                        HasError = True
                        ErrorMessage = $"{Identifier} not located"
                        SuccessType = Success.OhSnap
                    End If
                Catch ex As Exception
                    HasError = True
                    ErrorMessage = ex.Message
                    SuccessType = Success.OhSnap
                End Try
            End Using
        End Using

        Return SuccessType

    End Function
    ''' <summary>
    ''' Get an image in the database table by primary key
    ''' </summary>
    ''' <param name="Identifier"></param>
    ''' <param name="inBoundImage"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Not used, here for you if needed to get a single image, has been tested and works
    ''' </remarks>
    Public Function GetImage(ByVal Identifier As Integer, ByRef inBoundImage As Image) As Success
        Dim Description As String = ""
        Return GetImage(Identifier, inBoundImage, Description)
    End Function
    ''' <summary>
    ''' Return all records in our table
    ''' </summary>
    ''' <returns></returns>
    Public Function DataTable() As DataTable
        Dim dt As New DataTable
        Dim inCommingImage As Image = Nothing

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "ReadAllRecords", .CommandType = CommandType.StoredProcedure}
                cn.Open()
                dt.Load(cmd.ExecuteReader)
            End Using
        End Using

        Return dt

    End Function

End Class
