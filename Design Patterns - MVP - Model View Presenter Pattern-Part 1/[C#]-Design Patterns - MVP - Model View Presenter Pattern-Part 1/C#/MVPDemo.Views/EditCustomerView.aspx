<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCustomerView.aspx.cs"
    Inherits="EditCustomerView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Customer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Use this form to update the customer's information.<br />
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
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_OnClick" Text="Update" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" Text="Cancel"
                        CausesValidation="false" />
                </td>
            </tr>
        </table>
        <hr />
    </div>
    </form>
</body>
</html>
