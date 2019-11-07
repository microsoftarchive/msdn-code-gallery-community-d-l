var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;





//update Event
function updateEvent(event, element) {
    //alert(event.description);

    if ($(this).data("qtip")) $(this).qtip("destroy");

    $('#updatedialog').dialog('open');

    $("#eventName").val(event.title);
    $("#eventDesc").val(event.description);
    $("#eventId").val(event.id);
    $("#eventStart").text("" + event.start.toLocaleString());

    if (event.end === null) {
        $("#eventEnd").text("");
    }
    else {
        $("#eventEnd").text("" + event.end.toLocaleString());
    }

    currentUpdateEvent = event;
    alert(event.id);

    dialogfunction('now');
   

}



//Add Dialog for Update,New Forms 
function dialogfunction(targetElement) {
    var options = { html: targetElement, width: 400, height: 300 };
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

}




//Add Event
function selectDate(start, end, allDay) {
    alert(start);

    $("#addEventStartDate").text("" + start.toLocaleString());
    $("#addEventEndDate").text("" + end.toLocaleString());


    addStartDate = start;
    addEndDate = end;
    globalAllDay = allDay;
    alert(allDay);

}

///Update Event on Drop or Resize
function updateEventOnDropResize(event, allDay) {

    //alert("allday: " + allDay);
    var eventToUpdate = {
        id: event.id,
        start: event.start

    };

    if (allDay) {
        eventToUpdate.start.setHours(0, 0, 0);

    }

    if (event.end === null) {
        eventToUpdate.end = eventToUpdate.start;

    }
    else {
        eventToUpdate.end = event.end;
        if (allDay) {
            eventToUpdate.end.setHours(0, 0, 0);
        }
    }

    eventToUpdate.start = eventToUpdate.start.format("dd-MM-yyyy hh:mm:ss tt");
    eventToUpdate.end = eventToUpdate.end.format("dd-MM-yyyy hh:mm:ss tt");

   

}

function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event, allDay);



}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);

}








var hostweburl;
var appweburl;
var NewEvents = [];

// Load the required SharePoint libraries 
$(document).ready(function () {

    


    //Get the URI decoded URLs. 
    hostweburl =
        decodeURIComponent(
            getQueryStringParameter("SPHostUrl")
    );
    appweburl =
        decodeURIComponent(
            getQueryStringParameter("SPAppWebUrl")
    );

    // resources are in URLs in the form: 
    // web_url/_layouts/15/resource 
    var scriptbase = hostweburl + "/_layouts/15/";

    // Load the js files and continue to the successHandler 
    $.getScript(scriptbase + "SP.RequestExecutor.js", execCrossDomainRequest);
});

// Function to prepare and issue the request to get 
//  SharePoint data 
function execCrossDomainRequest() {

    // executor: The RequestExecutor object 
    // Initialize the RequestExecutor with the app web URL. 
    var executor = new SP.RequestExecutor(appweburl);

    // Issue the call against the app web. 
    // To get the title using REST we can hit the endpoint: 
    //      appweburl/_api/web/lists/getbytitle('listname')/items 
    // The response formats the data in the JSON format. 
    // The functions successHandler and errorHandler attend the 
    //      sucess and error events respectively. 
    executor.executeAsync(
        {
            url:



            appweburl + 
                "/_api/SP.AppContextSite(@target)/web/lists/getbytitle('Events')/items?@target='" + hostweburl + "'"

            ,
            method: "GET",
            headers: { "Accept": "application/json; odata=verbose" },
            success: successHandler,
            error: errorHandler
        }
    );
}

// Function to handle the success event. 
// Prints the data to the page. 
function successHandler(data) {
    
    var jsonObject = JSON.parse(data.body);
    var announcementsHTML = "";
    
    var events = jsonObject.d.results;
   


    //Converting ListItem to EventObject of Calcender More about Calcendar Event Object http://arshaw.com/fullcalendar/docs/event_data/Event_Object/
    for (var i = 0; i < events.length; i++) {

      //  alert(events[i].Title);
        NewEvents.push({
            ID : events[i].id,
            title: events[i].Title,
            start: events[i].EventDate,
            end: events[i].EndDate,
            description: events[i].Description,
            
            allDay: events[i].fAllDayEvent
        });
    }

    //Calender initialization
    IntFullCalendar();


}

// Function to handle the error event. 
// Prints the error message to the page. 
function errorHandler(data, errorCode, errorMessage) {
    alert(errorMessage+"E");
}

// Function to retrieve a query string value. 
// For production purposes you may want to use 
//  a library to handle the query string. 
function getQueryStringParameter(paramToRetrieve) {
    var params =
        document.URL.split("?")[1].split("&");
    var strParams = "";
    for (var i = 0; i < params.length; i = i + 1) {
        var singleParam = params[i].split("=");
        if (singleParam[0] == paramToRetrieve)
            return singleParam[1];
    }
}


//Calender initialization with All Setting and Parameters 
function IntFullCalendar()
{
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        editable: true,
        eventClick: updateEvent,
        select: selectDate,
        events: NewEvents,
        height: 650,
        eventDrop: eventDropped,
        eventResize: eventResized,
        selectable: true,
        selectHelper: true,
        editable: true
       
    });

    alert('add');
  

}