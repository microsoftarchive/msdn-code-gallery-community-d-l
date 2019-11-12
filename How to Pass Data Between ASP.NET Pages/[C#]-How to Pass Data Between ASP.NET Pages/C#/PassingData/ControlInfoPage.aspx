<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlInfoPage.aspx.cs" Inherits="PassingData.ControlInfoPage" %>
<%@ PreviousPageType VirtualPath="~/Default.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Target Page - Control Info</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Target Page - Control Info</h1>
        The data received from the source page is: 
        <asp:Label ID="DataReceivedLabel" runat="server" Text="Label"></asp:Label><br /><br />
        <asp:hyperlink ID="Hyperlink1" runat="server" NavigateUrl="~/Default.aspx">Return to Source Page</asp:hyperlink>
    </div>
    </form>
</body>
</html>

