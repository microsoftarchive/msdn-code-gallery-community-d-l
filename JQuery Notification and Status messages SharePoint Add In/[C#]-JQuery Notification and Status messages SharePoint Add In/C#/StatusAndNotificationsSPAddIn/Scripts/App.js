'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");

function initializePage() {

    //This function creates a new notification on your this Add-In
    $('#btnAddNotification').click(function () {
        //The message inside the notification.
        var strHtml = "<img width='15px' src=\"../Images/loading.gif\" /> Loading <b>please wait...</b>";
        //Specifies whether the notification stays on the page until removed.
        var bSticky = false;
        //Adds a notification to the page. By default, notifications appear for five seconds.
        SP.UI.Notify.addNotification(strHtml, bSticky);
    });
    //The ID of the status to update.
    var spstatus;
    //this function Adds a status message to the Add-in page.
    $('#btnAddStatus').click(function () {
        //The title of the status message.
        var strTitle = "SPTECHNET";
        //The contents of the status message.
        var strHtml = "New Status <b>massage</b>";
        //Specifies whether the status message will appear at the beginning of the list.
        var atBegining = true;
        spstatus = SP.UI.Status.addStatus(strTitle, strHtml, atBegining);
        //The color to set for the status message.
        SP.UI.Status.setStatusPriColor(spstatus, "green");
    });

    $('#btnModifyStatus').click(function () {
        //The new status message.
        var strHtml = "Modified Status <b>massage</b>";
        //Updates the specified status message.
        SP.UI.Status.updateStatus(spstatus, strHtml);
        //The color to set for the status message.
        SP.UI.Status.setStatusPriColor(spstatus, "blue");
    });

    $('#btnStatusColour').click(function () {
        var strColor = "red";
        //The color to set for the status message.
        SP.UI.Status.setStatusPriColor(spstatus, strColor);
    });

    $('#btnRemoveStatus').click(function () {
        //Removes all status messages from the page.
        SP.UI.Status.removeAllStatus(true);
    });

    $('#btnJQueryStatus').click(function () {
        //Show JQuery status messages from the page.
        $.notify("Access granted", "success");
        $.notify("Warning: Self-destruct in 3.. 2..", "warn");
        $('#txtName').notify("This field is required", "info");
        $.notify("BOOM!", {
            // whether to hide the notification on click
            clickToHide: true,
            // whether to auto-hide the notification
            autoHide: false,
            // if autoHide, hide after milliseconds
            autoHideDelay: 5000,
            // show the arrow pointing at the element
            arrowShow: true,
            // arrow size in pixels
            arrowSize: 5,
            // position defines the notification position though uses the defaults below
            position: 'top right',
            // default positions
            elementPosition: 'top right',
            globalPosition: 'top right',
            // default style
            style: 'bootstrap',
            // default class (string or [string])
            className: 'error',
            // show animation
            showAnimation: 'slideDown',
            // show animation duration
            showDuration: 400,
            // hide animation
            hideAnimation: 'slideUp',
            // hide animation duration
            hideDuration: 200,
            // padding between element and notification
            gap: 2
        });
    });
}
