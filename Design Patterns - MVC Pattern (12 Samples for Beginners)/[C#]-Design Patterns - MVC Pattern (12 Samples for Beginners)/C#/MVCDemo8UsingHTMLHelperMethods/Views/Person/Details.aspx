<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MVCDemo8UsingHTMLHelperMethods.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>Fields</legend>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %></p>
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            Age:
            <%= Html.Encode(Model.Age) %>
        </p>
        <p>
            Street:
            <%= Html.Encode(Model.Street) %>
        </p>
        <p>
            City:
            <%= Html.Encode(Model.City) %>
        </p>
        <p>
            State:
            <%= Html.Encode(Model.State) %>
        </p>
        <p>
            Zipcode:
            <%= Html.Encode(Model.Zipcode) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>
    <p>
        Notes need to update for the Redirect Methods:
        <br />
        Redirect()
        <br />
        RedirectPermanent()
        <br />
        RedirectResult()
        <br />
        RedirectToAction()
        <br />
        RedirectToActionPermanent()
        <br />
        RedirectToRoute()
        <br />
        RedirectToRoutePermanent()
        <br />
        RedirectToRouteResult()
        <br />
    </p>
</asp:Content>
