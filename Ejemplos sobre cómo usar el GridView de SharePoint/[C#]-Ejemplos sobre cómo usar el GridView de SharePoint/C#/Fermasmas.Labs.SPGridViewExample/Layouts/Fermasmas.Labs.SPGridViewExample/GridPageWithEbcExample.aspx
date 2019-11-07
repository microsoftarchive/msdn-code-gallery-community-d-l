<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridPageWithEbcExample.aspx.cs" Inherits="Fermasmas.Labs.SPGridViewExample.Layouts.Fermasmas.Labs.SPGridViewExample.GridPageWithEbcExample" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Ejemplo SPGridView
</asp:Content>

<asp:Content ID="AdditionalPageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" language="javascript">
        function openCommentsDialog(name, comments) {
            var options = SP.UI.$create_DialogOptions();
            options.url = "ViewComments.aspx?name=" + name + "&comments=" + comments;
            options.height = 600;
            options.width = 800;

            SP.UI.ModalDialog.showModalDialog(options);
        }
    </script>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    C&oacute;mo usar SPGridView de manera declarativa.
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <SharePoint:MenuTemplate ID="_menu" runat="server" >
        <SharePoint:MenuItemTemplate ID="_commentsMenu" runat="server" Text="Ir a comentarios" ClientOnClickNavigateUrl="ViewComments.aspx?Name=%NAME%&Comments=%COMMENTS%" />
        <SharePoint:MenuItemTemplate ID="_goToListMenu" runat="server" Text="Ir a lista" ClientOnClickNavigateUrl="../../Lists/AsgardList/AllItems.aspx" />
        <SharePoint:MenuItemTemplate ID="_seeItemMenu" runat="server" Text="Propiedades" ClientOnClickNavigateUrl="../../Lists/AsgardList/DispForm.aspx?ID=%EDIT%" />
        <SharePoint:MenuItemTemplate ID="_editMenu" runat="server" Text="Editar" ClientOnClickNavigateUrl="../../Lists/AsgardList/EditForm.aspx?ID=%EDIT%" />
    </SharePoint:MenuTemplate>
    <SharePoint:SPGridView ID="_grid" runat="server" AutoGenerateColumns="false" DataSourceID="_mainSource" AllowGrouping="true" GroupField="Gender" GroupFieldDisplayName="Género" AllowGroupCollapse="true">
        <Columns>
            <SharePoint:SPMenuField HeaderText="Nombre" TextFields="Name" MenuTemplateId="_menu"
                NavigateUrlFields="ID,Name,Comments"
                NavigateUrlFormat="do.aspx?ID={0}&Name={1}&Comments={2}"
                TokenNameAndValueFields="EDIT=ID,NAME=Name,COMMENTS=Comments"
             />
            <SharePoint:SPBoundField HeaderText="Influencia" DataField="Influence" />
            <SharePoint:SPBoundField HeaderText="Género" DataField="Gender" />
            <asp:TemplateField HeaderText="Comentarios">
                <ItemTemplate>
                    <asp:LinkButton ID="_link" runat="server" 
                        OnClientClick='<%# "javascript:openCommentsDialog(\"" + SPEncode.HtmlEncode(Eval("Name") as string) + "\", \"" + SPEncode.HtmlEncode(Eval("Comments") as string) + "\"); return false;" %>' Text="Comentarios" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </SharePoint:SPGridView>
    <asp:ObjectDataSource ID="_mainSource" runat="server" 
                          TypeName="Fermasmas.Labs.SPGridViewExample.Model.AsgardSource, $SharePoint.Project.AssemblyFullName$"
                          SelectMethod="SelectAll">
    </asp:ObjectDataSource>
</asp:Content>
