<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hello World
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        This is our first ASP.NET MVC View Page</h2>
    <fieldset>
        <p>
            In Controller class generally every public method will have return type ActionResult.
            <br />
            Usage 1:
            <br />
            <%= Html.Partial("~/Views/Shared/DateTimeUserControl.ascx")%>
            <br />
            Usage 2:
            <br />
            <% Html.RenderPartial("~/Views/Shared/DateTimeUserControl.ascx"); %>
            <br />
            <%: Html.ActionLink("Say Partial Hello", "SayPartialHello", "HelloWorld", null, "")%>
            <br />
        </p>
    </fieldset>
</asp:Content>