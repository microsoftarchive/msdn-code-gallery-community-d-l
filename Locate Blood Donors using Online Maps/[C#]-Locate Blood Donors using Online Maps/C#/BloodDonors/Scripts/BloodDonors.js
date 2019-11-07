function BloodDonors() { }

BloodDonors.dragShape = null;
BloodDonors.dragPixel = null;
BloodDonors.MapDivId = 'theMap';
BloodDonors._map = null;
BloodDonors._points = [];
BloodDonors._shapes = [];
BloodDonors.ipInfoDbKey = '';

BloodDonors.LoadMap = function (latitude, longitude, onMapLoaded) {
    BloodDonors._map = new VEMap(BloodDonors.MapDivId);

    var options = new VEMapOptions();

    options.EnableBirdseye = false

    this._map.SetDashboardSize(VEDashboardSize.Small);

    if (onMapLoaded != null)
        BloodDonors._map.onLoadMap = onMapLoaded;

    if (latitude != null && longitude != null) {
        var center = new VELatLong(latitude, longitude);
    }

    BloodDonors._map.LoadMap(center, null, null, null, null, null, null, options);
}

BloodDonors.EnableMapMouseClickCallback = function () {
    BloodDonors._map.AttachEvent("onmousedown", BloodDonors.onMouseDown);
    BloodDonors._map.AttachEvent("onmouseup", BloodDonors.onMouseUp);
    BloodDonors._map.AttachEvent("onmousemove", BloodDonors.onMouseMove);
}

BloodDonors.onMouseDown = function (e) {
    if (e.elementID != null) {
        BloodDonors.dragShape = BloodDonors._map.GetShapeByID(e.elementID);
        return true;
    }
}

BloodDonors.onMouseUp = function (e) {
    if (BloodDonors.dragShape != null) {
        var x = e.mapX;
        var y = e.mapY;
        BloodDonors.dragPixel = new VEPixel(x, y);
        var LatLong = BloodDonors._map.PixelToLatLong(BloodDonors.dragPixel);
        $("#Latitude").val(LatLong.Latitude.toString());
        $("#Longitude").val(LatLong.Longitude.toString());
        BloodDonors.dragShape = null;

        BloodDonors._map.FindLocations(LatLong, BloodDonors.getLocationResults);
    }
}

BloodDonors.onMouseMove = function (e) {
    if (BloodDonors.dragShape != null) {
        var x = e.mapX;
        var y = e.mapY;
        BloodDonors.dragPixel = new VEPixel(x, y);
        var LatLong = BloodDonors._map.PixelToLatLong(BloodDonors.dragPixel);
        BloodDonors.dragShape.SetPoints(LatLong);
        return true;
    }
}

BloodDonors.ClearMap = function () {
    if (BloodDonors._map != null) {
        BloodDonors._map.Clear();
    }
    BloodDonors._points = [];
    BloodDonors._shapes = [];
}

BloodDonors.LoadPin = function (LL, name, description, draggable) {
    if (LL.Latitude == 0 || LL.Longitude == 0) {
        return;
    }

    var shape = new VEShape(VEShapeType.Pushpin, LL);

    if (draggable == true) {
        shape.Draggable = true;
        shape.onenddrag = BloodDonors.onEndDrag;
    }

    //Make a Pushpin with a title and description
    shape.SetTitle("<span class=\"pinTitle\"> " + escape(name) + "</span>");

    if (description !== undefined) {
        shape.SetDescription("<p class=\"pinDetails\">" + escape(description) + "</p>");
    }

    BloodDonors._map.AddShape(shape);
    BloodDonors._points.push(LL);
    BloodDonors._shapes.push(shape);
}

BloodDonors.FindAddressOnMap = function (where) {
    var numberOfResults = 1;
    var setBestMapView = true;
    var showResults = true;
    var defaultDisambiguation = true;

    BloodDonors._map.Find("", where, null, null, null,
                         numberOfResults, showResults, true, defaultDisambiguation,
                         setBestMapView, BloodDonors._callbackForLocation);
}

BloodDonors._callbackForLocation = function (layer, resultsArray, places, hasMore, VEErrorMessage) {
    BloodDonors.ClearMap();

    if (places == null) {
        BloodDonors._map.ShowMessage(VEErrorMessage);
        return;
    }

    //Make a pushpin for each place we find
    $.each(places, function (i, item) {
        var description = "";
        if (item.Description !== undefined) {
            description = item.Description;
        }
        var LL = new VELatLong(item.LatLong.Latitude,
                        item.LatLong.Longitude);

        BloodDonors.LoadPin(LL, item.Name, description, true);
    });

    //Make sure all pushpins are visible
    if (BloodDonors._points.length > 1) {
        BloodDonors._map.SetMapView(BloodDonors._points);
    }

    //If we've found exactly one place, that's our address.
    //lat/long precision was getting lost here with toLocaleString, changed to toString
    if (BloodDonors._points.length === 1) {
        $("#Latitude").val(BloodDonors._points[0].Latitude.toString());
        $("#Longitude").val(BloodDonors._points[0].Longitude.toString());
    }
}

BloodDonors._callbackUpdateMapDonors = function (layer, resultsArray, places, hasMore, VEErrorMessage) {
    var center = BloodDonors._map.GetCenter();

    $.post("/Search/SearchByLocation",
           { latitude: center.Latitude, longitude: center.Longitude },
           BloodDonors._renderDonors,
           "json");
}

BloodDonors._renderDonors = function (Donors) {
    $("#DonorsList").empty();

    BloodDonors.ClearMap();

    $.each(Donors, function (i, Donors) {

        var LL = new VELatLong(Donors.Latitude, Donors.Longitude, 0, null);

        // Add Pin to Map
        BloodDonors.LoadPin(LL, _getDonorsLinkHTML(Donors), _getDonorsDescriptionHTML(Donors), false);

        //Add a Donors to the <ul> DonorsList on the right
        $('#DonorsList').append($('<li/>')
                        .attr("class", "DonorsItem")
                        .append(_getDonorsLinkHTML(Donors))
                        .append($('<br/>'))
                        .append(_getDonorsDate(Donors, "mmm d"))
                        .append(" with " + _getRSVPMessage(Donors.RSVPCount)));
    });

    // Adjust zoom to display all the pins.
    if (BloodDonors._points.length > 1) {
        BloodDonors._map.SetMapView(BloodDonors._points);
    }

    // Display the event's pin-bubble on hover.
    $(".DonorsItem").each(function (i, Donors) {
        $(Donors).hover(
            function () { BloodDonors._map.ShowInfoBox(BloodDonors._shapes[i]); },
            function () { BloodDonors._map.HideInfoBox(BloodDonors._shapes[i]); }
        );
    });

}

BloodDonors.onEndDrag = function (e) {
    $("#Latitude").val(e.LatLong.Latitude.toString());
    $("#Longitude").val(e.LatLong.Longitude.toString());
}



