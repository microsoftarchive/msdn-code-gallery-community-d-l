<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="PassingData._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Source Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<h1>Source Page</h1>
		Data to send: <asp:TextBox ID="DataToSendTextBox" runat="server" Text="Hello World!"></asp:TextBox><br /><br />
		<asp:Button ID="QueryStringButton" runat="server" Text="Use Query String" 
			onclick="QueryStringButton_Click"/><br /><br />
		<asp:Button ID="HttpPostButton" runat="server" Text="Use HttpPost" PostBackUrl="~/HttpPostPage.aspx"/><br /><br />
		<asp:Button ID="SessionStateButton" runat="server" Text="Use Session State" 
			onclick="SessionStateButton_Click" /><br /><br />
		<asp:Button ID="PublicPropertiesButton" runat="server" 
			Text="Use Public Properties" onclick="PublicPropertiesButton_Click" /><br /><br />
		<asp:Button ID="ControlInfoButton" runat="server" Text="Use Control Info" 
			onclick="ControlInfoButton_Click" />
	</div>
	</form>
</body>
</html>