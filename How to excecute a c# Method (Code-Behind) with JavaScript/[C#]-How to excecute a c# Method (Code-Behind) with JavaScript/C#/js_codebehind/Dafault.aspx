<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dafault.aspx.cs" Inherits="js_codebehind.Dafault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <a id="Boton1" href="javascript:__doPostBack('Button2_Click','')">LinkButton</a>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button2_Click" />
    </div>
    </form>
</body>
</html>
