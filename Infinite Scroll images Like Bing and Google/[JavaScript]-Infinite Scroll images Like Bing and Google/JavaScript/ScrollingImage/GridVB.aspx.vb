Imports System.Web.Services
Imports System.IO

Partial Class GridVB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Fill_List(49)
    End Sub
    Private Sub Fill_List(Rows As Integer)
        Dim Imagespath As String = HttpContext.Current.Server.MapPath("~/Images/")
        Dim SitePath As String = HttpContext.Current.Server.MapPath("~")
        Dim Files = (From file In Directory.GetFiles(Imagespath) Select New With {Key .image = file.Replace(SitePath, "~")}).Take(Rows)
        ImageGrid.DataSource = Files.ToList()
        ImageGrid.DataBind()
    End Sub
    <WebMethod()> _
    Public Shared Function LoadImages(Skip As Integer, Take As Integer) As String
        System.Threading.Thread.Sleep(2000)
        Dim GetImages As New StringBuilder()
        Dim Imagespath As String = HttpContext.Current.Server.MapPath("~/Images/")
        Dim SitePath As String = HttpContext.Current.Server.MapPath("~")
        Dim Files = (From file In Directory.GetFiles(Imagespath) Select New With { _
  Key .image = file.Replace(SitePath, "") _
 }).Skip(Skip).Take(Take)
        For Each file As Object In Files

            Dim imageSrc = file.image.Replace("\", "/").Substring(1) 'Remove First '/' from image path
            GetImages.AppendFormat("<a>")
            GetImages.AppendFormat("<li>")
            GetImages.AppendFormat(String.Format("<img src='{0}'/>", imageSrc))
            GetImages.AppendFormat("</li>")
            GetImages.AppendFormat("</a>")
        Next
        Return GetImages.ToString()
    End Function

End Class
