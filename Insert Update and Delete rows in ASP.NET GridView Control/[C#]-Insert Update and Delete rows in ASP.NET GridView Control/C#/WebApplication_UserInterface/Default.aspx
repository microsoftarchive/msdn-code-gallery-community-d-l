<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication_UserInterface._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
 </h2>
 <br />
 <table>
 <tr>
    <td> 
 
  <asp:Label ID="Label1" runat="server" Text="Product Id" CssClass="bold" 
            ForeColor="#333333"></asp:Label>
  </td>
 <td>
 <asp:TextBox ID="txtProductId" runat="server"></asp:TextBox>
 </td>
 </tr>
     
   <tr>
   <td>  

  <asp:Label ID="Label2" runat="server" Text="Product Name" CssClass="bold" 
           ForeColor="#333333"></asp:Label>
   </td>
 <td>
 <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
 </td>
 </tr>
 <tr>
    
 <td>
  <asp:Label ID="Label3" runat="server" Text="Product Price" CssClass="bold" 
         ForeColor="#333333"></asp:Label>
   </td>
 <td>
  <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
 </td>


 </tr>
  <tr>
 <td>
 </td> 
 <td>
 <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add Row" />
 </td>
 </tr>
 </table>
        <br /> <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
            ForeColor="#333333"  AutoGenerateColumns="False" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField Visible="False">  
                                
                    <ItemTemplate>
                        <asp:Label ID="lblPk_id" runat="server"  Text='<%#Eval("pk_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Headertext="ProductId">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductId" runat="server"  Text='<%#Eval("ProductId")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtProductId" runat="server"  Text='<%#Eval("ProductId")%>'></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductId" runat="server"  Text='<%#Eval("ProductId")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProductName">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductName" runat="server" Text='<%#Eval("ProductName")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%#Eval("ProductName")%>'></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server"  Text='<%#Eval("ProductName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProductPrice">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductPrice" runat="server"  Text='<%#Eval("ProductPrice")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtProductPrice" runat="server"  Text='<%#Eval("ProductPrice")%>'></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductPrice" runat="server"    Text='<%#Eval("ProductPrice")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField>
                <FooterTemplate>

                <asp:Button ID="btnInsert" runat="Server" Text="Insert" CommandName="Insert" UseSubmitBehavior="False" />

                </FooterTemplate>
                </asp:TemplateField>

            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
       
   
    <p>
        <asp:Label ID="lblmsg" runat="server" CssClass="bold" ForeColor="#0033CC" 
            Text="Label"></asp:Label>
    </p>
    </asp:Content>
