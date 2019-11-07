<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataBinding.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem Value="0">C#</asp:ListItem>
            <asp:ListItem Value="1">SQL Server</asp:ListItem>
            <asp:ListItem Value="2">ASP.NET</asp:ListItem>
            <asp:ListItem Value="3">WPF</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Show Selected" />
        <br />
        <br />
        <asp:Label ID="lblRes" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
