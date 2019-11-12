<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>      
        <br />
        <%= Html.ViewContext.TempData["TempDataObject"].ToString()%>
        <br />
        <%= Session["SampleSessionObject"].ToString() %>  
        <br />
        <%= Html.ActionLink("Create Person", "Create", "Person")%>
        
    <p>
        <%= Html.ActionLink("Throw An Exception", "ThrowException")%>
        (Default Error Page)
        <br />
        <br />
        <%= Html.ActionLink("Throw Not Implemented Exception", "ThrowNotImplemented")%>
        (Custom Error Page)
    </p>
</asp:Content>