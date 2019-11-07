// Global variable configuration:
var map = null;
var searchResultsArray;
var searchResultsPage;
var heatmapLocations;
var heatmapLayer;
var xhrPromise = null;


// public datasource configuration:
// TODO: Consider enabling management of data sources, storing them in application data store
var publicdatasources = new Array();
publicdatasources[publicdatasources.length] = {
    name: "FourthCoffeeSample",
    entityname: "FourthCoffeeShops",
    accessid: "20181f26d9e94c81acdf9496133d4f23"
};
publicdatasources[publicdatasources.length] = {
    name: "NavteqNA",
    entityname: "NavteqPOIs",
    accessid: "f22876ec257b474b82fe2ffcb8393150"
};
publicdatasources[publicdatasources.length] = {
    name: "NavteqEU",
    entityname: "NavteqPOIs",
    accessid: "c2ae584bbccc4916a0acf75d1e6947b4"
};
publicdatasources[publicdatasources.length] = {
    name: "TrafficIncidents",
    entityname: "TrafficIncident",
    accessid: "8F77935E46704C718E45F52D0D5550A6"
};

// For ease of access to Bing Maps objects:
var MM = Microsoft.Maps;

// Called once app is loaded or map is reloaded, instantiating the map and initiating the loading of data:
function loadMap() {
    
    // Default view:
    var startZoom = 12;
    var startCenter = new MM.Location(47.600941, -122.340385);
    var startMaptype = MM.MapTypeId.aerial;

    // If map exists, dispose of it before re-generating:
    if (map) {
        startZoom = map.getZoom();
        startCenter = map.getCenter();
        startMaptype = map.getMapTypeId();
        map.dispose();
    }

    // Load the map:
    map = new MM.Map(document.getElementById("mapDiv"),
                       {
                           credentials: document.getElementById("txtQueryKey").value,
                           mapTypeId: startMaptype,
                           zoom: startZoom,
                           center: startCenter
                       });

    // Add Event to search for entities when map moved:
    Microsoft.Maps.Events.addThrottledHandler(map, 'viewchangeend', NavEndHandler, 2000);

    // Add Event to check whether to cancel the retrieval of entity data if the map is moved before data is returned:
    Microsoft.Maps.Events.addHandler(map, 'viewchangestart', CheckSearch);

    // Load the Client Side HeatMap Module
    Microsoft.Maps.loadModule("HeatMapModule", {
        callback: function () {
        }
    });

}

// Populate select with data source options
function loadDataSourceOptions(dsArray) {
    var selDS = document.getElementById("selDatasource");
    for (var j = 0; j < dsArray.length; j++) {
        var option = document.createElement("option");
        option.text = dsArray[j].name;
        option.value = j;
        selDS.add(option, null);
    }

}

function CheckSearch() {
    // Cancel promise, if it exists:
    if (xhrPromise) { xhrPromise.cancel(); }
}

function NavEndHandler() {
    // Reload data, unless user has checked otherwise:
    if (document.getElementById("chkUpdate").checked) { InitiateSearch(); }
}

function InitiateSearch() {

    // remove heatmap, if present:
    if (heatmapLayer) { removeHeatmapLayer() };

    // reset search results array, and pagination global variables:
    searchResultsArray = new Array();
    searchResultsPage = 0;
    document.getElementById("spanZoomWarning").style.display = "none";
    document.getElementById("spanNumEntities").innerHTML = "...";

    // update progress bar:
    var progressBar = document.getElementById("determinateProgressBar");
    progressBar.value = 0;

    // retrieve map credentials, and use them to execute a search against the data source
    map.getCredentials(ExecuteSearch);
}

function ExecuteSearch(credentials) {

    // get map bounds for filtering:
    var bounds = map.getBounds();
    var south = bounds.getSouth();
    var north = bounds.getNorth();
    var east = bounds.getEast();
    var west = bounds.getWest();

    // Construct query URL:
    var searchRequest = "http://spatial.virtualearth.net/REST/v1/data/" + document.getElementById("txtDSID").value + "/" + document.getElementById("txtDSName").value + "/" + document.getElementById("txtEntityName").value;

    // Add filter clauses, if appropriate:
    var searchFilter = (document.getElementById("txtFilter").value != "") ? "$filter=" + document.getElementById("txtFilter").value + "&" : "";
    searchRequest += "?spatialFilter=bbox(" + south + "," + west + "," + north + "," + east + ")&" + searchFilter + "$inlinecount=allpages&$select=Latitude,Longitude&$format=JSON&key=" + credentials;
    searchRequest += "&$top=250&$skip=" + (searchResultsPage * 250).toString();

    // Use WinJS to execute request:
    // TODO: Consider more efficient ways to retrieve entity data, rather than a series of round trip requests:
    xhrPromise = WinJS.xhr({ url: searchRequest }).then(SearchCallback, ErrorCallback);
    searchResultsPage++;
}

function ErrorCallback(result) {
    xhrPromise = null;
    if (result.name == "Canceled") {
        // do nothing, as the user has navigated and results are no longer relevant
    }
    else {
        // show error details:
        ShowMessage("Request Status: " + result.statusText, "Error occurred during entity retrieval");
    }
}

function SearchCallback(result) {
    xhrPromise = null;
    // Parse results:
    result = JSON.parse(result.responseText);
    if (result &&
               result.d &&
               result.d.results &&
               result.d.results.length > 0) {

        if (result.d.__count > document.getElementById("txtLimit").value) {

            // Show warning:
            document.getElementById("spanZoomWarning").style.display = "block";

            // Update span to show total entities:
            document.getElementById("spanNumEntities").innerHTML = result.d.__count.toString();
            return;
        }

        // grab search results from response
        searchResultsArray = searchResultsArray.concat(result.d.results);

        // Update span to show total entities:
        document.getElementById("spanNumEntities").innerHTML = result.d.__count.toString();

        // Update progress bar:
        var progressBar = document.getElementById("determinateProgressBar");
        progressBar.max = result.d.__count;
        progressBar.value = searchResultsArray.length;

        // check to see if we need to retrieve more results:
        if (result.d.__count > (searchResultsPage * 250)) {
            map.getCredentials(ExecuteSearch);
        } else {
            // Process results:
            // grab search results from response
            var locations = result.d.results;

            // Array to use for heatmap:
            heatmapLocations = new Array();

            for (var j = 0; j < searchResultsArray.length; j++) {
                var location = new MM.Location(searchResultsArray[j].Latitude, searchResultsArray[j].Longitude);
                heatmapLocations.push(location);
            }

            drawHeatmap();
        }


    } else {
        // update entities count:
        document.getElementById("spanNumEntities").innerHTML = "0";
    }
}

// redraw the heatmap:
function drawHeatmap() {
    // remove heatmap, if present:
    if (heatmapLayer) { removeHeatmapLayer() };

    // Construct heatmap layer, using heatmapping JS module:
    heatmapLayer = new HeatMapLayer(
        map,
        [],
        {
            intensity: document.getElementById("txtIntensity").value,
            radius: document.getElementById("txtRadius").value,
            colourgradient: {
                0.0: 'blue',
                0.25: 'green',
                0.5: 'yellow',
                0.75: 'orange',
                1.0: 'red'
            }
        });
        heatmapLayer.SetPoints(heatmapLocations);
}

// remove heatmap layer, and set to null:
function removeHeatmapLayer() {
    heatmapLayer.Remove();
    heatmapLayer = null;
}

// populate new datasource details:
function populateDSValues() {
    var selectedDS = document.getElementById("selDatasource").selectedIndex;
    document.getElementById("txtDSID").value = publicdatasources[selectedDS].accessid;
    document.getElementById("txtDSName").value = publicdatasources[selectedDS].name;
    document.getElementById("txtEntityName").value = publicdatasources[selectedDS].entityname;

}


// Show message to user
function ShowMessage(title, msg) {
    var m = new Windows.UI.Popups.MessageDialog(title, msg);
    m.showAsync();
}

//Initialization logic for populating data source options and loading the map control
(function () {
    function initialize() {
        loadDataSourceOptions(publicdatasources);
        Microsoft.Maps.loadModule('Microsoft.Maps.Map', { callback: loadMap });
    }

    document.addEventListener("DOMContentLoaded", initialize, false);
})();