<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication_UserInterface._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        Welcome to ASP.NET!
    </h2>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://code.msdn.microsoft.com/Insert-Update-Delete-rows-b0a2d4e2">More Samples from Sathiyamoorthy S in MSDN </asp:HyperLink>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Product Id" CssClass="bold" ForeColor="#333333"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductId" runat="server" MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Product Name" CssClass="bold" ForeColor="#333333"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Product Location" CssClass="bold" ForeColor="#333333"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductLoc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Product Quantity" CssClass="bold" ForeColor="#333333"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProductQty" runat="server" MaxLength="5"></asp:TextBox>
                </td>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Product Price" CssClass="bold" ForeColor="#333333"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductPrice" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Row" />
                    </td>
                </tr>
    </table>
    <br />
    <asp:Label ID="lblmsg" runat="server" CssClass="bold" ForeColor="#0033CC" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ListView ID="ListView1" runat="server" OnPagePropertiesChanging="ListView1_PagePropertiesChanging"
                OnItemEditing="ListView1_ItemEditing" OnItemCanceling="ListView1_ItemCanceling"
                OnItemUpdating="ListView1_ItemUpdating"              
                onitemdeleting="ListView1_ItemDeleting">
                <EmptyDataTemplate>
                    <p>No Records Found..</p>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table runat="server" style="background-color: #FC31DB; color: White;">
                        <tr runat="server" style="background-color: #FC31DB;">
                            <td>
                            </td>
                            <td id="Td2" runat="server">
                            <b>PkId</b>
                            </td>
                            <td runat="server">
                                <b>Product Id</b>
                            </td>
                            <td id="Td5" runat="server">
                                <b>Product Name</b>
                            </td>
                            <td id="Td1" runat="server">
                                <b>Product Location</b>
                            </td>
                            <td id="Td7" runat="server">
                                <b>Product Quantity</b>
                            </td>
                            <td id="Td8" runat="server">
                                <b>Product Price</b>
                            </td>
                        </tr>
                        <tr id="ItemPlaceholder" runat="server">
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr id="Tr1" runat="server" style="background-color: #FD6EC4;">
                        <td>
                            <asp:Button ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" />
                             <asp:Button ID="Button1" Text="Delete" runat="server" CommandName="Delete" />
                        </td>
                        <td>
                            <asp:Label ID="lblDelPkId" runat="server" Text='<%# Eval("pk_id") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lable2" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lable3" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lable4" runat="server" Text='<%# Eval("ProductLocation") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lable5" runat="server" Text='<%# Eval("ProductQuantity") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lable7" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr id="Tr1" runat="server" style="background-color: #FD6EC4;">
                        <td>
                            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel" />
                            <asp:Button ID="btnUpdate" Text="Update" runat="server" CommandName="Update" />
                        </td>
                        <td>
                            <asp:Label ID="lblPkId" runat="server" Text='<%# Eval("pk_id") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtpdtId" Width="50px" runat="server" Text='<%# Eval("ProductId") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPdtName" Width="50px" runat="server" Text='<%# Eval("ProductName") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPdtLoc" Width="50px" runat="server" Text='<%# Eval("ProductLocation") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPdtQty" Width="50px" runat="server" Text='<%# Eval("ProductQuantity") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPDtPrce" Width="50px" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:TextBox>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:DataPager ID="lvDataPager1" runat="server" PagedControlID="ListView1" PageSize="5">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Link" />
        </Fields>
    </asp:DataPager>
</asp:Content>
