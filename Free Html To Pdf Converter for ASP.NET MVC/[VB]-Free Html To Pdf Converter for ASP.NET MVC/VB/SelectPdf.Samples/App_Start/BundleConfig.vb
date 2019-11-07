Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        ' Set EnableOptimizations to false for debugging. For more information,
        ' visit http://go.microsoft.com/fwlink/?LinkId=301862
        BundleTable.EnableOptimizations = True
    End Sub
End Module

