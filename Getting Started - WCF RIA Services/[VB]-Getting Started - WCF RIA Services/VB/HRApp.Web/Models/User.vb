Imports System.Runtime.Serialization
Imports System.ServiceModel.DomainServices.Server.ApplicationServices
Namespace Web

    Partial Public Class User
        Inherits UserBase
        ' NOTE: Profile properties can be added for use in Silverlight application.
        ' To enable profiles, edit the appropriate section of web.config file.
        '
        ' public string MyProfileProperty { get; set; }

        Private _FriendlyName As String

        Public Property FriendlyName() As String
            Get
                Return _FriendlyName
            End Get
            Set(ByVal value As String)
                _FriendlyName = value
            End Set
        End Property
    End Class
End Namespace