Namespace ClientSample

	#Region "DragItemData Class"

	''' <summary>
	''' Contains information for dragging items.
	''' </summary>
	Friend Class DragItemData
		Private ReadOnly _dragItems As List(Of ListViewItem) ' Draging items.
		Private ReadOnly _listView As DragAndDropListView ' Drag and Drop list view object.

		#Region "Public Properties"

		''' <summary>
		''' Gets the drag-drop enabled list view control.
		''' </summary>
		Public ReadOnly Property ListView() As DragAndDropListView
			Get
				Return _listView
			End Get
		End Property

		''' <summary>
		''' Gets a list of ListViewItem for drag and drop.
		''' </summary>
		Public ReadOnly Property DragItems() As List(Of ListViewItem)
			Get
				Return _dragItems
			End Get
		End Property

		#End Region

		#Region "Public Methods and Implementation"

		''' <summary>
		''' Initializes a new instance of the class.
		''' </summary>
		''' <param name="listView">The drag-drop enabled list view control.</param>
		Public Sub New(ByVal listView As DragAndDropListView)
			_listView = listView
			_dragItems = New List(Of ListViewItem)()
		End Sub

		#End Region
	End Class

	#End Region

	''' <summary>
	''' Represents a drag-drop enabled ListView control.
	''' </summary>
	Public Class DragAndDropListView
		Inherits ListView
		#Region "Properties"

		Private _allowDrag As Boolean = True

		''' <summary>
		''' Gets or set a boolean value indicating whether the Drag feature is enabled.
		''' </summary>
		Public Property AllowDrag() As Boolean
			Get
				Return _allowDrag
			End Get
			Set(ByVal value As Boolean)
				_allowDrag = value
			End Set
		End Property

		#End Region

		''' <summary>
		''' Gets data for drag and drop.
		''' </summary>
		''' <returns>The DragItemData object.</returns>
		Private Function GetDataForDragDrop() As DragItemData
			' create a drag item data object that will be used to pass along with the drag and drop
			Dim data As New DragItemData(Me)

			' go through each of the selected items and 
			' add them to the drag items collection
			' by creating a clone of the list item
			For Each item As ListViewItem In SelectedItems
				data.DragItems.Add(CType(item.Clone(), ListViewItem))
			Next item

			Return data
		End Function

		''' <summary>
		''' Handles the DragDrop event.
		''' </summary>
		''' <param name="lvevent">The event arguments.</param>
		Protected Overrides Sub OnDragDrop(ByVal lvevent As DragEventArgs)
			If Not lvevent.Data.GetDataPresent(GetType(DragItemData).ToString()) Then
				' the item(s) being dragged do not have any data associated
				lvevent.Effect = DragDropEffects.None
				Return
			End If

			MyBase.OnDragDrop(lvevent)
		End Sub

		''' <summary>
		''' Handles the ItemDrag event.
		''' </summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnItemDrag(ByVal e As ItemDragEventArgs)
			If Not _allowDrag Then
				MyBase.OnItemDrag(e)
				Return
			End If

			' call the DoDragDrop method
			DoDragDrop(GetDataForDragDrop(), DragDropEffects.Move)

			' call the base OnItemDrag event
			MyBase.OnItemDrag(e)
		End Sub

		''' <summary>
		''' Returns a boolean value indicating whether the provided event arguments contain a valid drag item.
		''' </summary>
		''' <param name="lvevent">The arguments for the Drag event.</param>
		''' <returns>true if valid; otherwise is false.</returns>
		Public Shared Function IsValidDragItem(ByVal lvevent As DragEventArgs) As Boolean
			Return lvevent.Data.GetDataPresent(GetType(DragItemData).ToString())
		End Function

		''' <summary>
		''' Handles the DragEnter event.
		''' </summary>
		''' <param name="lvevent">The event arguments.</param>
		Protected Overrides Sub OnDragEnter(ByVal lvevent As DragEventArgs)
			If Not IsValidDragItem(lvevent) Then
				' the item(s) being dragged do not have any data associated
				lvevent.Effect = DragDropEffects.None
				Return
			End If

			' everything is fine, allow the user to move the items
			lvevent.Effect = DragDropEffects.Move

			' call the base OnDragEnter event
			MyBase.OnDragEnter(lvevent)
		End Sub

		''' <summary>
		''' Handles the DragOver event.
		''' </summary>
		''' <param name="lvevent">The event arguments.</param>
		Protected Overrides Sub OnDragOver(ByVal lvevent As DragEventArgs)
			If Not IsValidDragItem(lvevent) Then
				' the item(s) being dragged do not have any data associated
				lvevent.Effect = DragDropEffects.None
				Return
			End If

			' everything is fine, allow the user to move the items
			lvevent.Effect = DragDropEffects.Move

			' call the base OnDragOver event
			MyBase.OnDragOver(lvevent)
		End Sub
	End Class
End Namespace