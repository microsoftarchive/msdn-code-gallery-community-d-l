Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Net
Imports Microsoft.VisualBasic.ControlChars

''' <summary>
''' Controls when a stack trace should be displayed on the
''' Error Window
''' 
''' Defaults to <see cref="StackTracePolicy.OnlyWhenDebuggingOrRunningLocally"/>
''' </summary>
Public Enum StackTracePolicy
    ''' <summary>
    ''' Stack trace is showed only when running with a debugger attached
    ''' or when running the app on the local machine. Use this to get
    ''' additional debug information you don't want the end users to see
    ''' </summary>
    OnlyWhenDebuggingOrRunningLocally

    ''' <summary>
    ''' Always show the stack trace, even if debugging
    ''' </summary>
    Always

    ''' <summary>
    ''' Never show the stack trace, even when debugging
    ''' </summary>
    Never
End Enum

Partial Public Class ErrorWindow
    Inherits ChildWindow
    Protected Sub New(ByVal message As String, ByVal errorDetails As String)
        InitializeComponent()
        IntroductoryText.Text = message
        ErrorTextBox.Text = errorDetails
    End Sub

#Region "Factory Shortcut Methods"
    ''' <summary>
    ''' Creates a new Error Window given an error message.
    ''' Current stack trace will be displayed if app is running under
    ''' debug or on the local machine
    ''' </summary>
    Public Shared Sub CreateNew(ByVal message As String)
        CreateNew(message, StackTracePolicy.OnlyWhenDebuggingOrRunningLocally)
    End Sub

    ''' <summary>
    ''' Creates a new Error Window given an exception.
    ''' Current stack trace will be displayed if app is running under
    ''' debug or on the local machine
    ''' 
    ''' The exception is converted onto a message using
    ''' <see cref="ConvertExceptionToMessage"/>
    ''' </summary>
    Public Shared Sub CreateNew(ByVal exception As Exception)
        CreateNew(exception, StackTracePolicy.OnlyWhenDebuggingOrRunningLocally)
    End Sub

    ''' <summary>
    ''' Creates a new Error Window given an exception. The exception is converted onto a message using
    ''' <see cref="ConvertExceptionToMessage"/>
    ''' 
    ''' <param name="policy">When to display the stack trace, see <see cref="StackTracePolicy"/></param>
    ''' </summary>
    Public Shared Sub CreateNew(ByVal exception As Exception, ByVal policy As StackTracePolicy)
        If exception Is Nothing Then
            Throw New ArgumentNullException("exception")
        End If

        Dim fullStackTrace As String = exception.StackTrace

        ' Account for nested exceptions. Since this is for debugging purposes we don't care
        ' to use ConvertExceptionToMessage or AppendStackTraceToMessage which are concerned
        ' with providing something nicer to the user
        Dim innerException As Exception = exception.InnerException

        While innerException IsNot Nothing
            fullStackTrace += (CrLf & "Caused by: " & exception.Message & CrLf & CrLf) + exception.StackTrace
            innerException = innerException.InnerException
        End While

        CreateNew(ConvertExceptionToMessage(exception), fullStackTrace, policy)
    End Sub

    ''' <summary>
    ''' Creates a new Error Window given an error message.
    ''' 
    ''' <param name="policy">When to display the stack trace, see <see cref="StackTracePolicy"/></param>
    ''' </summary>
    Public Shared Sub CreateNew(ByVal message As String, ByVal policy As StackTracePolicy)
        CreateNew(message, New StackTrace().ToString(), policy)
    End Sub
#End Region

#Region "Factory Methods"
    ''' <summary>
    ''' All other factory methods will result in a call to this one
    ''' </summary>
    ''' 
    ''' <param name="message">Which message to display</param>
    ''' <param name="stackTrace">The associated stack trace</param>
    ''' <param name="policy">In which situations the stack trace should be appended to the message</param>
    Private Shared Sub CreateNew(ByVal message As String, ByVal stackTrace As String, ByVal policy As StackTracePolicy)
        Dim errorDetails As String = String.Empty

        If policy = StackTracePolicy.Always OrElse policy = StackTracePolicy.OnlyWhenDebuggingOrRunningLocally AndAlso IsRunningUnderDebugOrLocalhost Then
            errorDetails = If(stackTrace Is Nothing, String.Empty, stackTrace)
        End If

        Dim window As New ErrorWindow(message, errorDetails)
        window.Show()
    End Sub
#End Region

#Region "Factory Helpers"
    ''' <summary>
    ''' Returns whether running under a dev environment, i.e., with a debugger attached or
    ''' with the server hosted on localhost
    ''' </summary>
    Private Shared ReadOnly Property IsRunningUnderDebugOrLocalhost() As Boolean
        Get
            If Debugger.IsAttached Then
                Return True
            Else
                Dim hostUrl As String = Application.Current.Host.Source.Host
                Return hostUrl.Contains("::1") OrElse hostUrl.Contains("localhost") OrElse hostUrl.Contains("127.0.0.1")
            End If
        End Get
    End Property

    ''' <summary>
    ''' Creates a user friendly message given an Exception. Currently this simply
    ''' takes the Exception.Message value, optionally but you might want to change this to treat
    ''' some specific Exception classes differently
    ''' </summary>
    Private Shared Function ConvertExceptionToMessage(ByVal e As Exception) As String
        Return e.Message
    End Function
#End Region

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.DialogResult = True
    End Sub
End Class