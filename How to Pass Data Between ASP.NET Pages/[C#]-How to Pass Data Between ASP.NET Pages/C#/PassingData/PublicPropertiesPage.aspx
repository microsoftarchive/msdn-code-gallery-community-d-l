<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicPropertiesPage.aspx.cs" Inherits="PassingData.PublicPropertiesPage" %>
<%@ PreviousPageType VirtualPath="~/Default.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Target Page - Public Properties</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Target Page - Public Properties</h1>
        The data received from the source page is: <%=PreviousPage.DataToSend %><br /><br />
        <asp:hyperlink ID="Hyperlink1" runat="server" NavigateUrl="~/Default.aspx">Return to Source Page</asp:hyperlink>
    </div>
    </form>
</body>
</html>

