Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Module RouteConfig
    Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.EnableFriendlyUrls()
    End Sub
End Module
