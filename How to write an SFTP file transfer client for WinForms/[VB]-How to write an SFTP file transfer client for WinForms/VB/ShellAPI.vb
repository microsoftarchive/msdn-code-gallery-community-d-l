Imports System.Runtime.InteropServices
Imports System.Text

Namespace ClientSample
	Public Class ShellAPI
		Private Const MAX_PATH As Integer = 260
		Private Const SHGFI_DISPLAYNAME As Integer = &H200
		Private Const SHGFI_EXETYPE As Integer = &H2000
		Private Const SHGFI_SYSICONINDEX As Integer = &H4000
		Private Const SHGFI_LARGEICON As Integer = &H0
		Private Const SHGFI_SMALLICON As Integer = &H1
		Private Const SHGFI_SHELLICONSIZE As Integer = &H4
		Private Const SHGFI_TYPENAME As Integer = &H400
		Private Const ILD_TRANSPARENT As Integer = &H1
		Private Const BASIC_SHGFI_FLAGS As Integer = SHGFI_TYPENAME + SHGFI_SHELLICONSIZE + SHGFI_SYSICONINDEX + SHGFI_DISPLAYNAME + SHGFI_EXETYPE

		<StructLayout(LayoutKind.Sequential)> _
		Private Class SHFileInfo
			Public IconHandle As Integer = 0
			Public IconSysIndex As Integer = 0
			Public Attributes As Integer = 0
			<MarshalAs(UnmanagedType.ByValTStr, SizeConst := MAX_PATH)> _
			Public DisplayName As String = ""
			<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 80)> _
			Public TypeName As String = ""
		End Class

		<DllImport("shell32", SetLastError := True)> _
		Private Shared Function SHGetFileInfoA(ByVal pszPath As String, ByVal dwFileAttributes As Integer, <InAttribute, OutAttribute> ByVal psfi As SHFileInfo, ByVal cbSizeFileInfo As Integer, ByVal uFlags As Integer) As Integer
		End Function

		<DllImport("comctl32", SetLastError := True)> _
		Private Shared Function ImageList_Draw(ByVal hIml As Integer, ByVal i As Integer, ByVal hdcDest As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal flags As Integer) As Integer
		End Function

		<StructLayout(LayoutKind.Sequential)> _
		Private Structure ShellExecuteInfo
			Public cbSize As Integer
			Public fMask As Integer
			Public hWnd As Integer
			<MarshalAs(UnmanagedType.LPStr)> _
			Public lpVerb As String
			<MarshalAs(UnmanagedType.LPStr)> _
			Public lpFile As String
			<MarshalAs(UnmanagedType.LPStr)> _
			Public lpParameters As String
			<MarshalAs(UnmanagedType.LPStr)> _
			Public lpDirectory As String
			Public nShow As Integer
			Public hInstApp As Integer
			Public lpIDList As Integer
			<MarshalAs(UnmanagedType.LPStr)> _
			Public lpClass As String
			Public hkeyClass As Integer
			Public dwHotKey As Integer
			Public hIcon As Integer
			Public hProcess As Integer
		End Structure

		<DllImport("shell32", SetLastError := True)> _
		Private Shared Function ShellExecuteExA(ByRef lpExecInfo As ShellExecuteInfo) As Boolean
		End Function

		Private Const SEE_MASK_INVOKEIDLIST As Integer = &HC
		Private Const SEE_MASK_NOCLOSEPROCESS As Integer = &H40
		Private Const SEE_MASK_FLAG_NO_UI As Integer = &H400

		<StructLayout(LayoutKind.Sequential)> _
		Private Structure ShBrowseInfo
			Public hOwner As Integer
			Public pidlRoot As Integer
			<MarshalAs(UnmanagedType.LPStr)> _
			Public pszDisplayName As String
			<MarshalAs(UnmanagedType.LPStr)> _
			Public lpszTitle As String
			Public ulFlags As Integer
			Public lpfn As Integer
			Public lParam As Integer
			Public iImage As Integer
		End Structure

		Private Const BIF_RETURNONLYFSDIRS As Integer = &H1
		'private const int BIF_DONTGOBELOWDOMAIN = 0x2;
		'private const int BIF_STATUSTEXT = 0x4;
		'private const int BIF_RETURNFSANCESTORS = 0x8;
		'private const int BIF_BROWSEFORCOMPUTER = 0x1000;
		'private const int BIF_BROWSEFORPRINTER = 0x2000;

		<DllImport("shell32", SetLastError := True)> _
		Private Shared Function SHBrowseForFolderA(ByRef lpBrowseInfo As ShBrowseInfo) As Integer
		End Function

		<DllImport("shell32", SetLastError := True, CharSet := CharSet.Ansi)> _
		Private Shared Function SHGetPathFromIDListA(ByVal pidl As Integer, ByVal pszPath As StringBuilder) As Integer
		End Function

		<DllImport("ole32", SetLastError := True)> _
		Private Shared Sub CoTaskMemFree(ByVal pv As Integer)
		End Sub

		Public Shared Function GetFileDescription(ByVal fileName As String) As String
			Dim l_Description As String
			Try
				Dim shinfo As New SHFileInfo()
				SHGetFileInfoA(fileName, 0, shinfo, Marshal.SizeOf(shinfo), BASIC_SHGFI_FLAGS)
				l_Description = shinfo.TypeName
			Catch
				l_Description = ""
			End Try
			Try
				If l_Description.Length = 0 Then
					l_Description = System.IO.Path.GetExtension(fileName).ToUpper().Substring(1) & " File"
				End If
			Catch
				l_Description = ""
			End Try
			Return l_Description
		End Function

		Public Shared Sub ShowFileProperties(ByVal filePath As String, ByVal ownerHwnd As IntPtr)
			Dim sei As New ShellExecuteInfo()
			sei.cbSize = Marshal.SizeOf(sei)
			sei.fMask = SEE_MASK_NOCLOSEPROCESS Or SEE_MASK_INVOKEIDLIST Or SEE_MASK_FLAG_NO_UI
			sei.hWnd = ownerHwnd.ToInt32()
			sei.lpVerb = "properties"
			sei.lpFile = filePath
			ShellExecuteExA(sei)
		End Sub

		''' <summary>
		''' Gets the system icon for the specified file name.
		''' </summary>
		''' <param name="filePath">The file name.</param>
		''' <param name="getLargeIcon">A boolean value indicates whether to get large icon or small icon.</param>
		''' <returns>The Image object.</returns>
		Public Shared Function ExtractIcon(ByVal filePath As String, ByVal getLargeIcon As Boolean) As Image
			Dim shinfo As New SHFileInfo()
			Dim FileIcon As Image = Nothing

			Try
				Dim hImg As Integer
				Dim iPixels As Short
				If getLargeIcon Then
					iPixels = 32
					hImg = SHGetFileInfoA(filePath, 0, shinfo, Marshal.SizeOf(shinfo), BASIC_SHGFI_FLAGS Or SHGFI_LARGEICON)
				Else
					iPixels = 16
					hImg = SHGetFileInfoA(filePath, 0, shinfo, Marshal.SizeOf(shinfo), BASIC_SHGFI_FLAGS Or SHGFI_SMALLICON)
				End If

				If shinfo.IconSysIndex <> 0 Then
					FileIcon = New Bitmap(iPixels, iPixels)
					Dim ImgGraphics As Graphics = Graphics.FromImage(FileIcon)
					Dim hDC As IntPtr = ImgGraphics.GetHdc()
					ImageList_Draw(hImg, shinfo.IconSysIndex, hDC.ToInt32(), 0, 0, ILD_TRANSPARENT)
					ImgGraphics.ReleaseHdc(hDC)
				End If
			Catch ' If we fail to get the icon, return null
			End Try

			Return FileIcon
		End Function

		Public Shared Function BrowseForFolder(ByVal title As String, ByVal owner As System.Windows.Forms.Form) As String
			Dim bi As New ShBrowseInfo()
			Dim buffer As New StringBuilder(MAX_PATH)

			bi.hOwner = owner.Handle.ToInt32()
			bi.pidlRoot = 0
			bi.lpszTitle = title
			bi.ulFlags = BIF_RETURNONLYFSDIRS

			Dim pidl As Integer = SHBrowseForFolderA(bi)
			SHGetPathFromIDListA(pidl, buffer)
			CoTaskMemFree(pidl)

			Return buffer.ToString()
		End Function
	End Class
End Namespace
