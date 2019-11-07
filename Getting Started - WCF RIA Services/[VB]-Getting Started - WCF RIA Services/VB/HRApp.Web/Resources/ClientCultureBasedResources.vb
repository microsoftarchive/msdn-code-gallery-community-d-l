Imports System
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Web
Namespace Web

    Friend Class ClientCultureBasedResources
        Private Sub New()

        End Sub

        ''' <summary>
        '''    Returns the CultureInfo that represents the culture for looking up
        '''    resources.
        '''    
        '''    The default implementation will try to load the culture from the
        '''    'HRApp-culture' cookie (which gets set by the Siverlight ASPX
        '''    wrapper, see HRAppTestPage.aspx). If there is no such
        '''    cookie, this will use the preferred language as sent by the browser, although
        '''    be aware that IE does not send this information.
        ''' 
        '''    Change this if you want to change or enhance this logic (for example,
        '''    if your app lets the user change the display language and store that
        '''    as a profile setting, you should change this method so it queries for
        '''    that profile setting if the user is logged on)
        ''' </summary>
        Private Shared ReadOnly Property CurrentCulture() As CultureInfo
            Get
                Dim clientCulture As String = HttpContext.Current.Request.Cookies("HRApp-culture").Value
                If (clientCulture IsNot Nothing) Then
                    Return CultureInfo.GetCultureInfo(clientCulture)
                Else
                    ' Not guaranteed to have the correct value
                    Return Thread.CurrentThread.CurrentCulture
                End If
            End Get
        End Property

        ''' <summary>
        '''     Ensures any resource strings accessed by <paramref name="resourceGrabber" /> will
        '''     be returned in the culture the silverlight app is expecting.
        ''' </summary>
        <MethodImpl(MethodImplOptions.Synchronized)> _
        Friend Shared Function GetResource(ByVal resourceGrabber As Func(Of String)) As String
            Thread.CurrentThread.CurrentUICulture = CurrentCulture
            Return resourceGrabber()
        End Function
    End Class
End Namespace