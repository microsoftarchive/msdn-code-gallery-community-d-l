<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" 
                    SortExpression="Name" />
                <asp:BoundField DataField="Color" HeaderText="Color" ReadOnly="True" 
                    SortExpression="Color" />
                <asp:BoundField DataField="ListPrice" HeaderText="ListPrice" ReadOnly="True" 
                    SortExpression="ListPrice" />
                <asp:BoundField DataField="Weight" HeaderText="Weight" ReadOnly="True" 
                    SortExpression="Weight" />
                <asp:BoundField DataField="Size" HeaderText="Size" ReadOnly="True" 
                    SortExpression="Size" />
            </Columns>

        </asp:GridView>

    </div>
    </form>
</body>
</html>
