<%@ Page Language="VB"%>

<%--This ASPX script is used as a fallback for browsers that don't support 
reading files via the FileReader.
In that case, the browser sends a file to the script, and the script 
returns the same base-64 encoded as FileReader would have returned.--%>

<script  runat="server">
    Sub Page_Load()
        If Request.Files.Count = 1 Then
            Dim file = Request.Files(0)
            If file.ContentLength > 0 Then
                Dim inputStream = file.InputStream
                Dim base64Block As Byte() = New Byte(inputStream.Length - 1) {}
                inputStream.Read(base64Block, 0, base64Block.Length)
                
                ' Return the base 64 data in the same format as FileReader (an HTML 5 standard,
                '     but currently implemented only on select browsers) would return.
                '     This includes the preamble of "data:{mime-type};base64,".
                Response.Write("data:" & file.ContentType & ";base64," &
                               Convert.ToBase64String(base64Block))
            End If
        End If
    End Sub
</script>