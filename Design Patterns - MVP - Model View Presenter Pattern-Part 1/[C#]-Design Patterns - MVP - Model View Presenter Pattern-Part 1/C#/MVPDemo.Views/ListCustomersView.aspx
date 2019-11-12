<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListCustomersView.aspx.cs"
    Inherits="ListCustomersView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Customers</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" />
        <asp:LinkButton Text="Click here" ID="btnAddCustomer" OnClick="btnAddCustomer_OnClick"
            runat="server" />
        to add a new customer.<br />
        <br />
        <!--
        The following GridView includes a hard-coded anchor tag to "EditCustomer.aspx."  
        For purposes of reuse, you may not want the User Control-as-View to know anything about page flow.  
        If this is needed, you could have the ASPX inject a redirect string to the view using setter injection.
        -->
        <asp:GridView ID="grdEmployees" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <a href="EditCustomerView.aspx?CustomerFirstName=<%# Eval("FirstName") %>">
                            <%# Eval("FirstName")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LastNAme" HeaderText="Last Name" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
