Imports System.IO

Friend Class FileNode
    Inherits DirectoryTreeNode

    Private m_file As FileInfo
    Private Shared ImageKeyValueLookupTable As Dictionary(Of String, String)

    Public Sub New(ByVal file As FileInfo)
        MyBase.New(FileSystemNodeType.File, file.Name)
        Me.m_file = file
        SetImageKeys()
        Me.ToolTipText = Me.m_file.FullName
    End Sub

    Shared Sub New()
        ImageKeyValueLookupTable = New Dictionary(Of String, String)
        ImageKeyValueLookupTable.Add("jpg;jpeg;gif;tif;tiff;png;bmp", "file_image.png")
        ImageKeyValueLookupTable.Add("mp3;wma", "file_music.png")
        ImageKeyValueLookupTable.Add("doc;docx", "file_word.png")
        ImageKeyValueLookupTable.Add("xls;xlsx", "file_excel.png")
        ImageKeyValueLookupTable.Add("zip;rar", "file_archive.png")
        ImageKeyValueLookupTable.Add("ppt;pptx", "file_powerpoint.png")
        ImageKeyValueLookupTable.Add("ini;config;bat;cmd", "file_setting.png")
        ImageKeyValueLookupTable.Add("txt;xml;log", "file_text.png")
    End Sub

    Public ReadOnly Property File As FileInfo
        Get
            Return Me.m_file
        End Get
    End Property

    Private Sub SetImageKeys()
        Dim key As String = GetImageKey(Path.GetExtension(File.FullName))
        Me.ImageKey = key
        Me.SelectedImageKey = key
    End Sub

    Private Shared Function GetImageKey(ByVal extension As String) As String
        extension = extension.Replace(".", "")
        For Each key As String In ImageKeyValueLookupTable.Keys
            Dim extensions() As String = key.Split(";")
            If (extensions.Contains(extension)) Then
                Return ImageKeyValueLookupTable.Item(key)
            End If
        Next
        Return "file.png"
    End Function

    Public Overrides ReadOnly Property FullName As String
        Get
            Return m_file.FullName
        End Get
    End Property

End Class
