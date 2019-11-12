Imports Windows.UI.Xaml.Controls


Public NotInheritable Class MainPage
    Inherits Page

    Public Sub New()
        InitializeComponent()

        AddHandler MyMap.Loaded, AddressOf MyMap_Loaded
    End Sub

    Private Sub MyMap_Loaded(sender As Object, e As Windows.UI.Xaml.RoutedEventArgs)
        Dim pin As New DraggablePin(MyMap)

        'Set the location of the pin to the center of the map.
        Bing.Maps.MapLayer.SetPosition(pin, MyMap.Center)

        'Set the pin as draggable.
        pin.Draggable = True

        'Attach to the drag action of the pin.
        pin.Drag = AddressOf Pin_Dragged

        'Add the pin to the map.
        MyMap.Children.Add(pin)
    End Sub

    Private Sub Pin_Dragged(location As Bing.Maps.Location)
        CoordinatesTbx.Text = String.Format("{0:N5},{1:N5}", location.Latitude, location.Longitude)
    End Sub
End Class
