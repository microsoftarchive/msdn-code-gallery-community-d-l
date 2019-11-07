<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MVCDemo13JSONAjaxRequestResponse.Models.PersonModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/json.js"></script>
    <script type="text/javascript">

        $(function () {
            $("#SubmitData").click(function () {

                var name = $("#Name").val();
                var age = $("#Age").val();

                var person = { Name: name, Age: age };

                if (person == null) {
                    alert("Specify a name please!");
                    return;
                }

                var json = $.toJSON(person);

                $.ajax({
                    url: '/home/save',
                    type: 'POST',
                    dataType: 'json',
                    data: json,
                    contentType: 'application/json; charset=utf-8',

                    success: function (data) {

                        var message = data.Message;
                        //$("#ResultMessage").html(message);
                        alert(message);
                    }
                });
            });
        });

        function handleUpdateMethod(context) {
            alert('handleUpdateMethod');
            // Load and deserialize the returned JSON data
            //alert(context);
            var json = context.get_data();
            var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

            var JsonObject = context.get_response().get_object();
            //alert(JsonObject);

            $('#ResultMessage').html(JsonObject.Message);

            //ResultTextBox.value = data.Message;
            //alert(data.Message);
            //ResultTextBox.value = data.Message;
            // Update the page elements
            //$('#update-message').text(data.Message);
        }
    </script>
    <div>
        <span id="ResultMessage"></span>
    </div>
    <%=Html.EditorForModel() %>
    <p>
        <input type="submit" value="Save" id="SubmitData" />
    </p>
    <%: Ajax.ActionLink("JSON Request", "SayHelloMessage", new { id = 123 }, new AjaxOptions { HttpMethod = "Get", OnSuccess = "handleUpdateMethod" })%>
</asp:Content>