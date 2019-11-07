<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hello World
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        This is our first ASP.NET MVC View Page</h2>
    <%:Html.PrefexHello("Sai")%>
    <br />
    <p>
        We add System.Web.Helpers.dll reference. And added namespace in web.config under
        pages/namespaces/add namespace="MVCDemo8HTMLHelper.Helpers"
        <br />
        So that we are able to use the PrefexHello extension method by using Html helper
    </p>
</asp:Content>