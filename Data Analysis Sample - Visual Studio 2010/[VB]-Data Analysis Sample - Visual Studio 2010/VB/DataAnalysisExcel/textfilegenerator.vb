' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System.Text
Imports System.Data
Imports System.IO
 
''' <summary>
''' This class constructs a tab-delimited Unicode text file
''' containing data from the Sales data table. First, a random named 
''' folder is created under the current user's temp folder. 
''' Next, a file named data.txt is created in that folder. Another file,
''' named schema.ini is created in that folder with settings for PivotTable
''' creation. This file is discovered automatically by the PivotTable by virtue
''' of sharing the data file's folder.
''' </summary>
Class TextFileGenerator
    Implements IDisposable
    ' Implement IDisposable.
    ' Do not make this method virtual.
    ' A derived class should not be able to override this method.
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        InternalDispose()
        ' This object will be cleaned up by the Dispose method.
        ' Therefore, you should call GC.SupressFinalize to
        ' take this object off the finalization queue 
        ' and prevent finalization code for this object
        ' from executing a second time.
        GC.SuppressFinalize(Me)
    End Sub

    ' Dispose(ByVal disposing As Boolean) executes in two distinct scenarios.
    ' If disposing equals True, the method has been called directly
    ' or indirectly by a user's code. Managed and unmanaged resources
    ' can be disposed.
    ' If disposing equals False, the method has been called by the 
    ' runtime from inside the finalizer and you should not reference 
    ' other objects. Only unmanaged resources can be disposed.
    Private Sub InternalDispose()
        ' Check to see if Dispose has already been called.
        If Not Me.disposed Then
            ' Call the appropriate methods to clean up 
            ' unmanaged resources here.
            ' If disposing is false, 
            ' only the following code is executed.
            DeleteCreatedFiles()
        End If
        disposed = True
    End Sub

    ' This finalizer will run only if the Dispose method 
    ' does not get called.
    ' Do not provide finalize methods in types derived from this class.
    Protected Overrides Sub Finalize()
        InternalDispose()
    End Sub

    ''' <summary>
    ''' Full path to the created temp file.
    ''' </summary>
    Private fullPathField As String

    ''' <summary>
    ''' Full path to the created toplevel folder.
    ''' </summary>
    Private rootPathField As String

    ''' <summary>
    ''' Field to indicate that all files and directories created by this
    ''' object have been deleted, e.g. DeleteCreatedFiles() has been called.
    ''' </summary>
    Private disposed As Boolean


    ''' <summary>
    ''' The full path to the data.txt file.
    ''' </summary>
    ''' <value>The full path to the data.txt file.</value>
    Public ReadOnly Property FullPath() As String
        Get
            Return fullPathField
        End Get
    End Property

    ''' <summary>
    ''' Creates a schema.ini file for PivotTable configuration.
    ''' </summary>
    Private Sub CreateSchemaIni()
        Dim contentsFormat As String = "[{0}]" & vbCrLf & _
            "ColNameHeader = True" & vbCrLf & _
            "Format = TabDelimited" & vbCrLf & _
            "MaxScanRows=0" & vbCrLf & _
            "CharacterSet=Unicode" & vbCrLf & _
            "Col1=Date Char Width 255" & vbCrLf & _
            "Col2=Flavor Char Width 255" & vbCrLf & _
            "Col3=Inventory Integer" & vbCrLf & _
            "Col4=Sold Integer" & vbCrLf & _
            "Col5=Estimated Float" & vbCrLf & _
            "Col6=Recommendation Char Width 255" & vbCrLf & _
            "Col7=Profit Float" & vbCrLf

        Dim fileName As String = Path.Combine(Path.GetDirectoryName(Me.fullPath), "schema.ini")

        Dim writer As New StreamWriter(fileName, False, Encoding.Default, contentsFormat.Length + Me.fullPath.Length)

        Try
            writer.Write(contentsFormat, Path.GetFileName(Me.fullPath))
        Finally
            writer.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Constructor. Creates the temporary folder, data.txt and schema.ini files.
    ''' </summary>
    ''' <param name="dt">The Sales table.</param>
    Public Sub New(ByVal dt As DataTable)

        Dim directoryName As String = Nothing
        Dim rootName As String = Nothing

        GenerateSecureTempFolder(directoryName, rootName)

        Me.rootPathField = rootName
        Me.fullPathField = Path.Combine(directoryName, "data.txt")

        Dim textEncoding As Encoding

        textEncoding = Encoding.Unicode

        System.IO.Directory.CreateDirectory(directoryName)
        Dim writer As New StreamWriter(Me.FullPath, False, textEncoding, 512)
        Try
            Dim remaining As Integer = dt.Columns.Count

            For Each column As DataColumn In dt.Columns
                writer.Write(QuoteString(column.ColumnName))
                If remaining <> 1 Then
                    writer.Write(vbTab)
                    remaining -= 1
                End If
            Next
            writer.Write(vbCrLf)

            Dim row As DataRow
            For Each row In dt.Rows
                Dim remainingItems As Integer = row.ItemArray.Length

                For Each item As Object In row.ItemArray()
                    writer.Write(QuoteString(item.ToString()))

                    If remainingItems <> 1 Then
                        writer.Write(vbTab)
                        remainingItems -= 1
                    End If
                Next
                writer.Write(vbCrLf)
            Next
        Finally
            writer.Close()
        End Try

        CreateSchemaIni()
    End Sub

    ''' <summary>
    ''' Deletes the created folder and its contents.
    ''' </summary>
    Private Sub DeleteCreatedFiles()
        If Me.rootPathField IsNot Nothing Then
            Directory.Delete(rootPathField, True)
            Me.rootPathField = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Helper method for generating a secure directory structure
    ''' file names.
    ''' </summary>
    ''' <param name="createdFolder">
    ''' A random, secure path.
    ''' </param>
    ''' <param name="createdRoot">
    ''' The toplevel path created. 
    ''' </param>
    Private Shared Sub GenerateSecureTempFolder(ByRef createdFolder As String, ByRef createdRoot As String)

        Dim directoryName As String = Path.Combine(Path.GetTempPath(), GenerateRandomName())
        createdRoot = directoryName
        directoryName = Path.Combine(directoryName, GenerateRandomName())
        createdFolder = directoryName
    End Sub


    ''' <summary>
    ''' This function will generate a random file name for use as a temporary
    ''' file. The file name will be in the 8.3 format, where both the 8 character
    ''' file name and the 3 character extension will be random.
    ''' This is done for security purposes, to limit the possibility
    ''' that someone may gain access to this file by guessing its name.
    ''' NOTE: The 8.3 format is used because anything longer can be 
    ''' accessed using the short name format, which reduces the security.
    ''' </summary>
    ''' <returns>
    ''' A secure file or directory name for temporary storage.
    ''' </returns>
    ''' <remarks></remarks>
    Private Shared Function GenerateRandomName() As String

        Dim data(8) As Byte
        Dim randomString As StringBuilder
        Dim randomNumberGenerator As _
        New System.Security.Cryptography.RNGCryptoServiceProvider

        ' Retrieve some random bytes.
        randomNumberGenerator.GetBytes(data)

        ' Convert bytes to a string. This will generate an 12 character string.
        randomString = New StringBuilder(System.Convert.ToBase64String(data))

        ' Convert to an 8.3 file name format
        randomString(8) = "."c

        ' Replace any illegal file name characters.
        randomString = randomString.Replace("/", "-")
        randomString = randomString.Replace("+", "_")

        ' Return the string.
        Return randomString.ToString
    End Function

    ''' <summary>
    ''' Puts a string inside quotes ("). Any quotes inside the string are doubled.
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    Private Shared Function QuoteString(ByVal s As String) As String
        Dim sb As StringBuilder = New StringBuilder("""", s.Length + 2)

        sb.Append(s.Replace("""", """"""))
        sb.Append(""""c)
        Return sb.ToString()
    End Function
End Class
