<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HttpPostPage.aspx.cs" Inherits="PassingData.HttpPostPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Target Page - HttpPost</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Target Page - HttpPost</h1>
        The data received from the source page is: <%=Request.Form["DataToSendTextBox"] %><br /><br />
        <fieldset>
        <legend>All form data from the sending page</legend>
            <asp:Label ID="ReceivedDataLabel" runat="server" Text="Label"></asp:Label>
        </fieldset>
        <br />
        <asp:hyperlink runat="server" NavigateUrl="~/Default.aspx">Return to Source Page</asp:hyperlink>
    </div>
    </form>
</body>
</html>

