<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridPageWithDataSource.aspx.cs" Inherits="Fermasmas.Labs.SPGridViewExample.Layouts.Fermasmas.Labs.SPGridViewExample.GridPageWithDataSource" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    SPGridView con SPDataSource
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Cómo enlazar las listas usando una fuente de datos de SharePoint.
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <SharePoint:SPGridView ID="_grid" runat="server" AutoGenerateColumns="false" DataSourceID="_source" >
        <Columns>
            <SharePoint:SPBoundField HeaderText="Nombre" DataField="Name" SortExpression="Name" />
            <SharePoint:SPBoundField HeaderText="Influencia" DataField="Influence" SortExpression="Influence" />
            <SharePoint:SPBoundField HeaderText="Género" DataField="Gender" SortExpression="Gender" />
            <asp:TemplateField HeaderText="Comentarios">
                <ItemTemplate>
                    <asp:LinkButton ID="_link" runat="server" 
                        OnClientClick='<%# "javascript:openCommentsDialog(\"" + SPEncode.HtmlEncode(Eval("Name") as string) + "\", \"" + SPEncode.HtmlEncode(Eval("Comments") as string) + "\"); return false;" %>' Text="Comentarios" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NextPreviousFirstLast" Visible="true" NextPageText="Siguiente |" PreviousPageText="Anterior |" FirstPageText="Inicio |" LastPageText="Fin" />
    </SharePoint:SPGridView>

    <SharePoint:SPDataSource ID="_source" runat="server" DataSourceMode="List" SelectCommand="<View></View>" UseInternalName="true">
        <SelectParameters>
            <asp:Parameter Name="WebUrl" DefaultValue="/asgard/" />
        <asp:Parameter Name="ListName" DefaultValue="Asgard List" />
        </SelectParameters>
    </SharePoint:SPDataSource>
</asp:Content>