<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MVCDemo10Validations.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend>Add Person</legend>
        <p>
            <label for="Id">
                Id:</label>
            <%: Html.EditorFor(model => model.Id)%>
            <%= Html.ValidationMessage("Id", "*") %>
        </p>
        <p>
            <%: Html.LabelFor(model => model.Name)%>
            <%: Html.TextBoxFor(model => model.Name)%>
            <%= Html.ValidationMessageFor(model => model.Name,"Name field is required")%>
        </p>
        <p>
            <label for="Age">
                Age:</label>
            <%: Html.EditorFor(model => model.Age)%>
            <%= Html.ValidationMessage("Age", "*") %>
        </p>
        <p>
            <label for="Street">
                Street:</label>
            <%: Html.EditorFor(model => model.Street)%>
            <%= Html.ValidationMessage("Street", "*") %>
        </p>
        <p>
            <label for="City">
                City:</label>
            <%: Html.EditorFor(model => model.City)%>
            <%= Html.ValidationMessage("City", "*") %>
        </p>
        <p>
            <label for="State">
                State:</label>
            <%: Html.EditorFor(model => model.State)%>
            <%= Html.ValidationMessage("State", "*") %>
        </p>
        <p>
            <label for="ZipCode">
                Zipcode:</label>
            <%: Html.EditorFor(model => model.Zipcode)%>
            <%= Html.ValidationMessage("ZipCode", "*") %>
        </p>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to List", "Index","Person") %>
        <%=Html.ActionLink("Details", "Details","Person") %>
        <%: Html.ActionLink("Edit", "Edit", new { id= 123 }) %>
    </div>
    <p>
        Verify Models/Person.cs and CustomValidations/AgeValidationAttribute.cs to see How
        to implement validations and custom validations
        <br />
</asp:Content>