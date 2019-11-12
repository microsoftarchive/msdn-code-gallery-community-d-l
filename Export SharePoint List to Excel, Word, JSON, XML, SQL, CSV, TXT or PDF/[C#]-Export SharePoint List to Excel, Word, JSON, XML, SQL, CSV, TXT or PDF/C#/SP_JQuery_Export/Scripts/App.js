'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");

function initializePage() {
    var context = SP.ClientContext.get_current();
    var user = context.get_web().get_currentUser();
    var hostweburl;
    var appweburl;
    var appContextSite;
    var list;
    var listItems;
    var web;


    // This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
    $(document).ready(function () {
        getUrl();
    });

    // This function get the URL informations
    function getUrl() {
        hostweburl = getQueryStringParameter("SPHostUrl");
        appweburl = getQueryStringParameter("SPAppWebUrl");
        hostweburl = decodeURIComponent(hostweburl);
        appweburl = decodeURIComponent(appweburl).toString().replace("#","");
        var scriptbase = hostweburl + "/_layouts/15/";
        $.getScript(scriptbase + "SP.RequestExecutor.js", execOperation);
    }

    // This function get list data from SharePoint
    function execOperation() {
        var factory = new SP.ProxyWebRequestExecutorFactory(appweburl);
        context.set_webRequestExecutorFactory(factory);
        appContextSite = new SP.AppContextSite(context, hostweburl);
        web = appContextSite.get_web();
        context.load(web);
        var camlQuery = new SP.CamlQuery();
        list = web.get_lists().getByTitle("Documents");
        listItems = list.getItems(camlQuery);
        context.load(list);
        context.load(listItems);
        context.executeQueryAsync(onGetSPListSuccess, onGetSPListFail);
    }


    // This function is executed if the above call is successful
    function onGetSPListSuccess() {
        $("#DivSPGrid").empty();
        var listInfo = '';
        var listEnumerator = listItems.getEnumerator();
        listInfo += "<table id='SPTable' class='display'><thead><tr>" +
            "<th>Id</th>" +
            "<th>Title</th>" +
            "<th>Colour</th>" +
            "<th>Modified By</th>" +
            "<th>Modified date</th>" +
            "</tr></thead><tbody>";
        while (listEnumerator.moveNext()) {
            var listItem = listEnumerator.get_current();
            listInfo += '<tr><td>' + listItem.get_item('ID') + '</td>'
            + '<td>' + listItem.get_item('FileLeafRef') + '</td>'
            + '<td>' + listItem.get_item('Colour') + '</td>'
            + '<td>' + listItem.get_item('Editor').get_lookupValue() + '</td>'
            + '<td>' + listItem.get_item('Modified').format('dd MMM yyyy, hh:ss') + '</td>'
            + '</tr>';
        }
        listInfo += '</tbody></table>';
        $("#DivSPGrid").html(listInfo);
        $('#SPTable').dataTable();
    }

    // This function is executed if the above call fails
    function onGetSPListFail(sender, args) {
        alert('Failed to get list data. Error:' + args.get_message());
    }

    //This function split the url and trim the App and Host web URLs
    function getQueryStringParameter(paramToRetrieve) {
        var params =
        document.URL.split("?")[1].split("&");
        for (var i = 0; i < params.length; i = i + 1) {
            var singleParam = params[i].split("=");
            if (singleParam[0] == paramToRetrieve)
                return singleParam[1];
        }
    }
}
