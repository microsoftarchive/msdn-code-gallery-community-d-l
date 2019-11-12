Imports System.Windows.Controls
Imports System.Windows.Navigation

Partial Public Class Home
    Inherits Page
    Public Sub New()
        InitializeComponent()

        Me.Title = ApplicationStrings.HomePageTitle
    End Sub

    ''' <summary>
    '''     Executes when the user navigates to this page.
    ''' </summary>
    Protected Overloads Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
    End Sub
End Class