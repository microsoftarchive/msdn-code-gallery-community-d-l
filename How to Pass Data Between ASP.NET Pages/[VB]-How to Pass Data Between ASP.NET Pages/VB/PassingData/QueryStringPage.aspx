<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QueryStringPage.aspx.vb" Inherits="PassingData.QueryStringPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Target Page - Query String</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<h1>Target Page - Query String</h1>
		The data received from the source page is: <%=Server.UrlDecode(Request.QueryString("Data"))%><br /><br />
		<asp:hyperlink ID="Hyperlink1" runat="server" NavigateUrl="~/Default.aspx">Return to Source Page</asp:hyperlink>
	</div>
	</form>
</body>
</html>