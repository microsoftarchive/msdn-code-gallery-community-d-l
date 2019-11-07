<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCustomerView.aspx.cs" Inherits="AddCustomerView"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Add Customer</title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" /><br />
        <br />
        <table>
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="5" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtFirstName"
                        runat="server" ErrorMessage="Customer First Name must be provided" />
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="40" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastName"
                        runat="server" ErrorMessage="Customer Last Name must be provided" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_OnClick" Text="Add Customer" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" Text="Cancel"
                        CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
