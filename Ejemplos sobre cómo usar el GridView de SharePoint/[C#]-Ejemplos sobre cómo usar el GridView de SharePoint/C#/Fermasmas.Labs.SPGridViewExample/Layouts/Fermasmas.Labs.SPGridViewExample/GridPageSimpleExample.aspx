<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridPageSimpleExample.aspx.cs" Inherits="Fermasmas.Labs.SPGridViewExample.Layouts.Fermasmas.Labs.SPGridViewExample.GridPageSimpleExample" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Ejemplo SPGridView
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    C&oacute;mo usar SPGridView de manera declarativa.
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <SharePoint:SPGridView ID="_grid" runat="server" AutoGenerateColumns="false" DataSourceID="_mainSource">
        <Columns>
            <asp:CommandField ButtonType="Image" ShowEditButton="true" EditImageUrl="/_layouts/images/edit.gif" UpdateImageUrl="/_layouts/images/save.gif" CancelImageUrl="/_layouts/images/delete.gif" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HiddenField ID="_idHiddenField" runat="server" Value='<%# Bind("ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label ID="_nameLabel" runat="server" Text='<%# Bind("Name") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="_nameText" runat="server" Width="100%" Text='<%# Bind("Name") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Influencia">
                <ItemTemplate>
                    <asp:Label ID="_influenceLabel" runat="server" Text='<%# Bind("Influence") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="_influenceText" runat="server" Width="100%" Text='<%# Bind("Influence") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Género">
                <ItemTemplate>
                    <asp:Label ID="_genderLabel" runat="server" Text='<%# Bind("Gender") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="_genderList" runat="server" Width="100%" SelectedValue='<%# Bind("Gender") %>' >
                        <asp:ListItem Text="Æsir" Value="Æsir" />
                        <asp:ListItem Text="Ásynjur" Value="Ásynjur" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios">
                <ItemTemplate>
                    <asp:Label ID="_commentLabel" runat="server" Text='<%# Bind("Comments") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="_commentText" runat="server" Width="100%" Text='<%# Bind("Comments") %>' TextMode="MultiLine" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </SharePoint:SPGridView>
    <asp:ObjectDataSource ID="_mainSource" runat="server" 
                          TypeName="Fermasmas.Labs.SPGridViewExample.Model.AsgardSource, $SharePoint.Project.AssemblyFullName$"
                          SelectMethod="SelectAll" UpdateMethod="UpdateItem">
        <UpdateParameters>
            <asp:Parameter Type="Int32" Name="id" />
            <asp:Parameter Type="String" Name="name" />
            <asp:Parameter Type="String" Name="influence" />
            <asp:Parameter Type="String" Name="gender" />
            <asp:Parameter Type="String" Name="comments" />
        </UpdateParameters>                            
    </asp:ObjectDataSource>
</asp:Content>