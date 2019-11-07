Public Class Exporgt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
        End If

    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        Dim strDownloadFileName As String = DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"

        ' Your Function for Retrieving Data
        Dim dtA As DataTable = RetrieveData()

        Response.Clear()
        Response.ContentType = "text/plain"
        Response.AppendHeader("content-disposition", "attachment; filename=" + strDownloadFileName) ' myData - file name (also can be bring from DB)

        'MyData - your data ...
        Dim myData As Byte() = csvBytesWriter(dtA)

        Response.BinaryWrite(myData)  ' Binary data - see myData -  
        Response.End()

    End Sub

    Function RetrieveData() As DataTable
        Dim dt As New DataTable
        ' Here you LOGIC for Retrieving Data Table...

        'Below just for test purpose ...
        dt.TableName = "TEST"
        dt.Columns.Add("TestA")
        dt.Columns.Add("TestB")
        dt.Columns.Add("TestC")
        dt.Columns.Add("TestD,E")

        Dim dr As DataRow = dt.NewRow
        dr("TestA") = "A' "
        dr("TestB") = "B"" "
        dr("TestC") = "C<> "
        dr("TestD,E") = ",C, "

        dt.Rows.Add(dr)
        Return dt
    End Function

    Function csvBytesWriter(ByRef dTable As DataTable) As Byte()

        '--------Columns Name---------------------------------------------------------------------------

        Dim sb As StringBuilder = New StringBuilder()
        Dim intClmn As Integer = dTable.Columns.Count

        Dim i As Integer = 0
        For i = 0 To intClmn - 1 Step i + 1
            sb.Append("""" + dTable.Columns(i).ColumnName.ToString() + """")
            If i = intClmn - 1 Then
                sb.Append(" ")
            Else
                sb.Append(",")
            End If
        Next
        sb.Append(vbNewLine)

        '--------Data By  Columns---------------------------------------------------------------------------

        Dim row As DataRow
        For Each row In dTable.Rows

            Dim ir As Integer = 0
            For ir = 0 To intClmn - 1 Step ir + 1
                sb.Append("""" + row(ir).ToString().Replace("""", """""") + """")
                If ir = intClmn - 1 Then
                    sb.Append(" ")
                Else
                    sb.Append(",")
                End If

            Next
            sb.Append(vbNewLine)
        Next

        Return System.Text.Encoding.UTF8.GetBytes(sb.ToString)

    End Function


End Class