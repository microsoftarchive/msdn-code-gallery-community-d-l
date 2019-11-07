<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Error while processing request</h2>
    <h1>
        Error on page</h1>
    <b>
        <%=ViewData.Message %></b>
    <br />
    <p>
        The HandleError attribute (which appears on the default controllers in an MVC project)
        tells the framework that if an unhandled exception occurs in your controller that
        rather than showing the default Yellow Screen, it should instead serve up a view
        called Error.
        <br />
        The controller-specific View folder will be checked first (eg. Views/Home/Error.aspx)
        and if it’s not found, the Shared folder (Views/Home/Error.aspx) will be used.
    </p>
    <p>
        The OnException Method The System.Web.Mvc.Controller class contains a method called
        OnException() which is called whenever an exception occurs within an action.
        <br />
        This does not rely on the HandleError attribute being set.
        <br />
        Best way is to have our own base Controller class and we can override this method
        in one place to handle/log all errors for our site.
        <br />
        How Do we see our own Errors During Development?
        <customerrors mode="RemoteOnly" />
    <br />

    </p>
    
</asp:Content>