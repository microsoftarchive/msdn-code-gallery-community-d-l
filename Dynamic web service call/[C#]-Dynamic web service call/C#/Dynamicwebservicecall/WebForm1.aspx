<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Dynamicwebservicecall.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>Click on contry name</div>
        <div style="width: 100%">
            <div style="width: 50%">
                <asp:GridView ID="grdcountry" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="grdcountry_PageIndexChanging" 
                    Width="100%" OnRowCommand="grdcountry_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Country Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnlcontryclick" runat="server" Text='<%# Bind("NAME") %>' CommandName="Loaddata" 
                                    CommandArgument='<%# Bind("NAME") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width: 50%">
                <asp:GridView ID="grdcountrydata" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
