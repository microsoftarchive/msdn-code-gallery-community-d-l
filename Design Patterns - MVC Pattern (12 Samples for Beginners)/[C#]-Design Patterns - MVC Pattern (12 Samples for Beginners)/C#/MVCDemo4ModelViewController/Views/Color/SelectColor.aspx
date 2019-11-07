<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MVCDemo4ModelViewController.ColorModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Display Colors by using Model
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Colors displayed by using Model</h2>
    
    <p>These are <%: Model.NumberOfColors %> Nice Colors, many people likes.</p>

    <ul>
        <% foreach (string genreName in Model.Colors) 
           { %>
			<li>
                <%: genreName %>
           </li>
        <% } %>
    </ul>
    <p>
    The SelectColor.aspx View page is inherits from MVCDemo4ModelViewController.ColorModel.
    <br />
    So that we will be able access ColorModel properties by using Model dot in View page.
    </p>
</asp:Content>