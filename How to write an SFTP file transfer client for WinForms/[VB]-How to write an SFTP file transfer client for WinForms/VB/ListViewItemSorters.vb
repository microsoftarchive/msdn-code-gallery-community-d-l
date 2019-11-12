Imports System.Collections
Imports ComponentPro.Net
Imports ComponentPro.IO

Namespace ClientSample
	''' <summary>
	''' Base comparer class for comparing two list view items.
	''' </summary>
	Public MustInherit Class ListViewItemComparerBase
		Implements IComparer
		Private ReadOnly _folderImageIndex As Integer
		Private ReadOnly _folderLinkImageIndex As Integer
		Protected _sortOrder As SortOrder

		''' <summary>
		''' Initializes a new instance of the ListViewItemComparerBase.
		''' </summary>
		''' <param name="sortOrder">The sort order.</param>
		''' <param name="folderImageIndex">The defined folder image index.</param>
		''' <param name="folderLinkImageIndex">The defined folder link image index.</param>
		Protected Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer, ByVal folderLinkImageIndex As Integer)
			_sortOrder = sortOrder

			_folderImageIndex = folderImageIndex
			_folderLinkImageIndex = folderLinkImageIndex
		End Sub

		Public Function Compare(ByVal xobject As Object, ByVal yobject As Object) As Integer Implements IComparer.Compare
			Dim x As ListViewItem = CType(xobject, ListViewItem)
			Dim y As ListViewItem = CType(yobject, ListViewItem)

			' Compare file to file or folder to folder only.
			Dim xIsFolder As Integer
			If x.ImageIndex = _folderImageIndex OrElse x.ImageIndex = _folderLinkImageIndex Then
				xIsFolder = 1
			Else
				xIsFolder = 0
			End If
			Dim yIsFolder As Integer
			If y.ImageIndex = _folderImageIndex OrElse y.ImageIndex = _folderLinkImageIndex Then
				yIsFolder = 1
			Else
				yIsFolder = 0
			End If

			If xIsFolder <> yIsFolder Then
				If _sortOrder = SortOrder.Ascending Then
					Return yIsFolder - xIsFolder
				Else
					Return (xIsFolder - yIsFolder)
				End If
			End If
			If _sortOrder = SortOrder.Ascending Then
				Return OnCompare(CType(x.Tag, ListItemInfo), CType(y.Tag, ListItemInfo), x.Text, y.Text)
			Else
				Return OnCompare(CType(y.Tag, ListItemInfo), CType(x.Tag, ListItemInfo), y.Text, x.Text)
			End If
		End Function

		Public MustOverride Function OnCompare(ByVal x As ListItemInfo, ByVal y As ListItemInfo, ByVal xtext As String, ByVal ytext As String) As Integer
	End Class

	''' <summary>
	''' Date time comparer.
	''' </summary>
	Public Class ListViewItemDateComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer, ByVal folderLinkImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex, folderLinkImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As ListItemInfo, ByVal y As ListItemInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return Date.Compare(x.FileInfo.LastWriteTime, y.FileInfo.LastWriteTime)
		End Function
	End Class

	''' <summary>
	''' File permissions comparer.
	''' </summary>
	Public Class ListViewItemPermissionsComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer, ByVal folderLinkImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex, folderLinkImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As ListItemInfo, ByVal y As ListItemInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return String.Compare(x.Permissions, x.Permissions)
		End Function
	End Class

	''' <summary>
	''' Name comparer.
	''' </summary>
	Public Class ListViewItemNameComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer, ByVal folderLinkImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex, folderLinkImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As ListItemInfo, ByVal y As ListItemInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return String.Compare(xtext, ytext, True)
		End Function
	End Class

	''' <summary>
	''' Size comparer.
	''' </summary>
	Public Class ListViewItemSizeComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer, ByVal folderLinkImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex, folderLinkImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As ListItemInfo, ByVal y As ListItemInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			If x.FileInfo.Length = y.FileInfo.Length Then
				Return 0
			End If
			If x.FileInfo.Length > y.FileInfo.Length Then
				Return 1
			Else
				Return -1
			End If
		End Function
	End Class
End Namespace
