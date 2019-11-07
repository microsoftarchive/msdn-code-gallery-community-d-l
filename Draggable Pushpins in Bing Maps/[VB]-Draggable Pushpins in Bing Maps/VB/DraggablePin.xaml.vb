Imports Bing.Maps

Public NotInheritable Class DraggablePin
    Inherits UserControl

#Region "Private Properties"

    Private _map As Map
    Private isDragging As Boolean = False
    Private _center As Location

#End Region

#Region "Constructor"

    Public Sub New(map As Map)
        Me.InitializeComponent()

        _map = map
    End Sub

#End Region

#Region "Public Properties"

    '''<summary>
    ''' A boolean indicating whether the pushpin can be dragged.
    '''</summary>
    Public Property Draggable() As Boolean
        Get
            Return m_Draggable
        End Get
        Set(value As Boolean)
            m_Draggable = Value
        End Set
    End Property
    Private m_Draggable As Boolean

#End Region

#Region "Public Events"

    ''' <summary>
    ''' Occurs when the pushpin is being dragged.
    ''' </summary>
    Public Drag As Action(Of Location)

    ''' <summary>
    ''' Occurs when the pushpin starts being dragged.
    ''' </summary>
    Public DragStart As Action(Of Location)

    ''' <summary>
    ''' Occurs when the pushpin stops being dragged.
    ''' </summary>
    Public DragEnd As Action(Of Location)

#End Region

#Region "Private Methods"

    Protected Overrides Sub OnPointerPressed(e As PointerRoutedEventArgs)
        MyBase.OnPointerPressed(e)

        If Draggable Then
            If _map IsNot Nothing Then
                'Store the center of the map
                _center = _map.Center

                'Attach events to the map to track touch and movement events
                AddHandler _map.ViewChanged, AddressOf Map_ViewChanged
                AddHandler _map.PointerReleasedOverride, AddressOf Map_PointerReleased
                AddHandler _map.PointerMovedOverride, AddressOf Map_PointerMoved
            End If

            Dim pointerPosition = e.GetCurrentPoint(_map)

            Dim location As Location = Nothing

            'Convert the point pixel to a Location coordinate
            If _map.TryPixelToLocation(pointerPosition.Position, location) Then
                MapLayer.SetPosition(Me, location)
            End If

            If DragStart IsNot Nothing Then
                DragStart(location)
            End If

            'Enable Dragging
            Me.isDragging = True
        End If
    End Sub

    Private Sub Map_PointerMoved(sender As Object, e As PointerRoutedEventArgs)
        'Check if the user is currently dragging the Pushpin
        If Me.isDragging Then
            'If so, move the Pushpin to where the pointer is.
            Dim pointerPosition = e.GetCurrentPoint(_map)

            Dim location As Location = Nothing

            'Convert the point pixel to a Location coordinate
            If _map.TryPixelToLocation(pointerPosition.Position, location) Then
                MapLayer.SetPosition(Me, location)
            End If

            If Drag IsNot Nothing Then
                Drag(location)
            End If
        End If
    End Sub

    Private Sub Map_PointerReleased(sender As Object, e As PointerRoutedEventArgs)
        'Pushpin released, remove dragging events
        If _map IsNot Nothing Then
            RemoveHandler _map.ViewChanged, AddressOf Map_ViewChanged
            RemoveHandler _map.PointerReleasedOverride, AddressOf Map_PointerReleased
            RemoveHandler _map.PointerMovedOverride, AddressOf Map_PointerMoved
        End If

        Dim pointerPosition = e.GetCurrentPoint(_map)

        Dim location As Location = Nothing

        'Convert the point pixel to a Location coordinate
        If _map.TryPixelToLocation(pointerPosition.Position, location) Then
            MapLayer.SetPosition(Me, location)
        End If

        If DragEnd IsNot Nothing Then
            DragEnd(location)
        End If

        Me.isDragging = False
    End Sub

    Private Sub Map_ViewChanged(sender As Object, e As ViewChangedEventArgs)
        If isDragging Then
            'Reset the map center to the stored center value.
            'This prevents the map from panning when we drag across it.
            _map.Center = _center
        End If
    End Sub

#End Region

End Class
