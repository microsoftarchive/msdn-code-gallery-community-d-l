' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
Imports CompuSight.Metro.Samples.Logging.VB.Log

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Public Sub New()
        MetroEventSource.Log.Debug("Initializing the MainPage")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        MetroEventSource.Log.Info("On Navigated to the main page")
    End Sub

    Private Sub VerboseMessage_Click_1(sender As Object, e As RoutedEventArgs)
        MetroEventSource.Log.Debug("Here is the verbose message")
    End Sub

    Private Sub InfoMessage_Click_1(sender As Object, e As RoutedEventArgs)
        MetroEventSource.Log.Info("Here is the info message")
    End Sub

    Private Sub ErrorMessage_Click_1(sender As Object, e As RoutedEventArgs)
        Task.Run(Sub()
                     MetroEventSource.Log.Err("Here is the error message")
                 End Sub)
    End Sub

    Private Sub CriticalMessage_Click_1(sender As Object, e As RoutedEventArgs)
        MetroEventSource.Log.Critical("Here is the critical message")
    End Sub

End Class
