<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CsvWebC.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <asp:Button ID="btnExport" runat="server" Text="Export To CSV" OnClick="btnExport_Click" />
    </div>
    </form>
</body>
</html>
