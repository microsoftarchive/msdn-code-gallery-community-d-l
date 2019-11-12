<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>      
        <br />
        <%= Html.ViewContext.TempData["TempDataObject"].ToString()%>
        <br />
        <%= Session["SampleSessionObject"].ToString() %>  
        <br />
        <%= Html.ActionLink("Select Color", "SelectColor", "Color")%>        
   
</asp:Content>