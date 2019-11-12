<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MVCDemo5ViewBag.ColorModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse Color
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Here we are using ActionLink to send the selected color to controller, so that controller
        can decide what to do next.</p>
    <ul>
        <% foreach (string ColorName in Model.Colors)
           { %>
        <li>
            <%: Html.ActionLink(ColorName, "DisplayColor", new { SelectedColor = ColorName }, null)%>
            <% if (ViewBag.Starred.Contains(ColorName))
               {  %>
            *
            <% } %>
        </li>
        <% } %>
    </ul>
    <br />
    <p>
        * Colors I like, which Controller sent through the ViewBag.
        <br />
        <br />
        <b>ViewState:</b> in Web Forms was serializing form data into a hidden, encrypted
        field in the form, so data could be re-bound on the postback.
        <br />
        Viewstate is posted back along with the content of a form to the server and thus
        values in it are available on post back.
        <br />
        So you can use ViewState to hold state between calls but you can not do the same
        with a ViewBag.
        <br />
        <br />
        <b>ViewBag/ViewData:</b> is a dictionary where you can "stuff" data into.
        <br />
        ViewData is a derivative of the ViewDataDictionary class, so you can access by the
        familiar "key/value" syntax.
        <br />
        • ViewData is a dictionary object that you put data into, which then becomes available
        to the view. • ViewBag object is a wrapper around the ViewData object that allows
        you to create dynamic properties for the ViewBag.
        <br />
        For example, you might add to it in your Controller, then access it in your View.
        The data is dynamic which makes it difficult to work with the data.
        <br />
        ViewBag doesn't get sent to the client, it's part of the MVC (server pipeline).
        And its purely something to use transitioning from the controller to the View (
        which is before its sent back to the client).
        <br />
        A viewbag only holds the values in it until the page is served then the ViewBag
        is removed from memory.
        <br />
        In MVC, If you get a postback from that page, then you wont recover your "state",
        like Viewstate does, the only state you have is whatever you send to the browser,
        and whatever you send back.
        <br />
        <b>TempData</b>
        <br />
        TempData can be troublesome when used in this manner.
        <br />
        TempData is meant to be a very short-lived instance, and you should only use it
        during the current and the subsequent requests only!
        <br />
        Since TempData works this way, you need to know for sure what the next request will
        be, and redirecting to another view is the only time you can guarantee this.
        <br />
        Therefore, the only scenario where using TempData will reliably work is when you
        are redirecting.
        <br />
        This is because a redirect kills the current request (and sends HTTP status code
        302 Object Moved to the client), then creates a new request on the server to serve
        the redirected view.
        <br />
        The customary Session object is the backing store for the TempData object, and it
        is destroyed more quickly than a regular session, i.e., immediately after the subsequent
        request. Because of its short lived scope, it's great for passing error messages
        to an error page.
        <br />
        <b>View Model Objects</b> This is not similar to ViewModel in MVVM pattern.
        <br />
        You need to represent the following types of data, which do not fit in well when
        using ViewBag, ViewData, or TempData objects.
        <br />
        The MVC 3 framework contains ViewModel objects for when you need more than ViewData.
        The type of data that suits ViewModels well is as follows: • Master-detail data
        • Larger sets of data • Complex relational data • Reporting and aggregate data •
        Dashboards • Data from disparate sources
    </p>
    <pre>
    <b>When should I use a ViewBag vs. ViewData vs. TempData objects?" </b>

    ViewData and ViewBag objects work well in the following scenarios:

    • Incorporating dropdown lists of lookup data into an entity 
    • Components like a shopping cart 
    • Widgets like a user profile widget 
    • Small amounts of aggregate data
 
    While the TempData object works well in one basic scenario:

    • Passing data between the current and next HTTP requests
 
    If you need to work with larger amounts of data, reporting data, create dashboards, or work with multiple disparate sources of data, you can use the more heavy duty ViewModel object. 
    Both the ViewData and ViewBag objects are great for accessing extra data (i.e., outside the data model), between the controller and view. 
    Since views already expect a specific object as their model, this type of data access to extra data, MVC implements it as a property of both views and controllers, making usage and access to these objects easy.  
    </pre>
    <br />
    This page inherits from MVCDemo5ViewBag.ColorModel, and accessing the Starred property
    from ViewBag.
    <br />
    Invoking Controller with Parameter Values: We are using Html.ActionLink helper method
    to call the Controller's action by passing the SelectedColor parameter.
    <br />
    Read More here http://rachelappel.com/when-to-use-viewbag-viewdata-or-tempdata-in-asp.net-mvc-3-applications
</asp:Content>