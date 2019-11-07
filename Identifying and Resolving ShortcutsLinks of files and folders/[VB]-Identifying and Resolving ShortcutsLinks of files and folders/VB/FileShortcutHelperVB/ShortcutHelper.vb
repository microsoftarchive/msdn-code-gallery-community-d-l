'
'   Copyright 2014 Christoph Gattnar
'
'   Licensed under the Apache License, Version 2.0 (the "License");
'   you may not use this file except in compliance with the License.
'   You may obtain a copy of the License at
'
'	   http://www.apache.org/licenses/LICENSE-2.0
'
'   Unless required by applicable law or agreed to in writing, software
'   distributed under the License is distributed on an "AS IS" BASIS,
'   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'   See the License for the specific language governing permissions and
'   limitations under the License.
'

Imports System.IO

Public Module ShortcutHelper
	Public Function IsShortcut(strPath As String) As Boolean
		If Not File.Exists(strPath) Then
			Return False
		End If

		Dim directory As String = Path.GetDirectoryName(strPath)
		Dim strFile As String = Path.GetFileName(strPath)

		Dim shell As Shell32.Shell = New Shell32.Shell()
		Dim folder As Shell32.Folder = shell.NameSpace(directory)
		Dim folderItem As Shell32.FolderItem = folder.ParseName(strFile)

		If folderItem IsNot Nothing Then
			Return folderItem.IsLink
		End If

		Return False
	End Function

	Public Function ResolveShortcut(strPath As String) As String
		If IsShortcut(strPath) Then
			Dim directory As String = Path.GetDirectoryName(strPath)
			Dim strFile As String = Path.GetFileName(strPath)

			Dim shell As Shell32.Shell = New Shell32.Shell()
			Dim folder As Shell32.Folder = shell.NameSpace(directory)
			Dim folderItem As Shell32.FolderItem = folder.ParseName(strFile)

			Dim link As Shell32.ShellLinkObject = folderItem.GetLink

			Return link.Path
		End If

		Return String.Empty
	End Function
End Module
