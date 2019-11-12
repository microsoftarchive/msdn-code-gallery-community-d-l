<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hello World
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        This is our first ASP.NET MVC View Page</h2>
    <br />
    <script language="javascript" type="text/javascript">

        //        $.ajax(
        //      {
        //          type: "GET",
        //          contentType: "application/json; charset=utf-8",
        //          url: "SayHelloMessage/" + 456,
        //          data: "{}",
        //          dataType: "json",
        //          error: function (xhr, err) {
        //              alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
        //              alert("responseText: " + xhr.responseText);
        //          }
        //      });

        function handleUpdateMethod(context) {
            //alert('handleUpdateMethod');
            // Load and deserialize the returned JSON data
            //alert(context);
            //var json = context.get_data();
            //var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

            var JsonObject = context.get_response().get_object();
            alert(JsonObject);

            $('#update-message').text(JsonObject.Message);

            //ResultTextBox.value = data.Message;
            //alert(data.Message);
            //ResultTextBox.value = data.Message;
            // Update the page elements
            //$('#update-message').text(data.Message);
        }

        function GetJsonCall(val) {

            var Domain = '';

            if (document.domain == 'localhost') {
                Domain = "/HelloWorld/MakeJsonCall/";
            }
            else {
                Domain = "../HelloWorld/MakeJsonCall/";
            }
            alert(Domain + val);
            $.getJSON(Domain, val, function (data) {

                alert(data[0]);
                ResultTextBox.value = data.name;
                ResultTextBox.value += data.Email;
            });

            //alert('Request complete');
        }


        var previousColor = '';

        // using JQuery to attach the events!
        $("#ResultTextBox").focus(function () {
            $(this).addClass('highlight');
        }).blur(function () {
            $(this).removeClass('highlight');
        });

        function highlight(control, color) {
            if (control.style) {
                // move the previous color to a variable
                previousColor = control.style.backgroundColor;
                control.style.backgroundColor = color;
            }
        }

        function removeHighlight(control) {
            if (control.style) {
                control.style.backgroundColor = previousColor;
            }
        }
   

    </script>
    <br />
    <%: Ajax.ActionLink("JSON Request", "SayHelloMessage", new { id = 123 }, new AjaxOptions { Confirm = "Get?" , HttpMethod = "Get", OnSuccess = "handleUpdateMethod" })%>
    <br />
    <%: Ajax.ActionLink("AJAX Request", "ShowAJAXDemoView", "HelloWorld", new AjaxOptions() { HttpMethod = "Get", UpdateTargetId = "Result" })%>
    <div id="update-message">
    </div>
    <p>
        <input type="text" id="ResultTextBox" name="ResultTextBox" />
        <select name="Class" id="Class" onchange="GetJsonCall(this.value)">
            <option value="">Pls select</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
        </select>
        <br />
        Enabled Client side validations in web.config appsettings section
        <br />
        add key="ClientValidationEnabled" value="true"
        <br />
        add key="UnobtrusiveJavaScriptEnabled" value="true"
        <br />
    </p>
</asp:Content>
