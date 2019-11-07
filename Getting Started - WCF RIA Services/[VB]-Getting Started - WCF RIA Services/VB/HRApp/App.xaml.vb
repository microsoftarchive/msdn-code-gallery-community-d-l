Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports System.Windows
Imports System.Windows.Controls

Partial Public Class App
    Inherits Application

    Dim _progressIndicator As Activity

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Application_Startup(ByVal sender As Object, ByVal e As StartupEventArgs) Handles Me.Startup
        ' This will enable you to bind controls in XAML files to WebContext.Current
        ' properties
        Me.Resources.Add("WebContext", WebContext.Current)

        ' This will automatically authenticate a user when using windows authentication
        ' or when the user chose "Keep me signed in" on a previous login attempt
        WebContext.Current.Authentication.LoadUser(AddressOf Me.Application_UserLoaded, Nothing)

        ' Show some UI to the user while LoadUser is in progress
        Me.InitializeRootVisual()
    End Sub

    ''' <summary>
    '''     Invoked when the <see cref="LoadUserOperation"/> completes. Use this
    '''     event handler to switch from the "loading UI" you created in
    '''     <see cref="InitializeRootVisual"/> to the "application UI"
    ''' </summary>
    Private Sub Application_UserLoaded(ByVal operation As LoadUserOperation)
        Me._progressIndicator.IsActive = False
    End Sub

    ''' <summary>
    '''     Initializes the <see cref="Application.RootVisual"/> property. The
    '''     initial UI will be displayed before the LoadUser operation has completed
    '''     (The LoadUser operation will cause user to be logged automatically if
    '''     using windows authentication or if the user had selected the "keep
    '''     me signed in" option on a previous login).
    ''' </summary>
    Protected Overridable Sub InitializeRootVisual()
        Me._progressIndicator = New Activity()
        Me._progressIndicator.Content = New MainPage()
        'Me._progressIndicator.IsActive = True
        Me._progressIndicator.HorizontalContentAlignment = HorizontalAlignment.Stretch
        Me._progressIndicator.VerticalContentAlignment = VerticalAlignment.Stretch


        ' Let the user now we're trying to authenticate him
        Me._progressIndicator.ActiveContent = ApplicationStrings.ActivityLoadingUser

        Me.RootVisual = Me._progressIndicator
    End Sub

    Private Sub Application_UnhandledException(ByVal sender As Object, ByVal e As ApplicationUnhandledExceptionEventArgs) Handles Me.UnhandledException
        ' If the app is running outside of the debugger then report the exception using
        ' a ChildWindow control.
        If Not System.Diagnostics.Debugger.IsAttached Then
            ' NOTE: This will allow the application to continue running after an exception has been thrown
            ' but not handled. 
            ' For production applications this error handling should be replaced with something that will 
            ' report the error to the website and stop the application.
            e.Handled = True
            ErrorWindow.CreateNew(e.ExceptionObject)
        End If
    End Sub
End Class