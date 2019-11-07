/// <reference path="jquery-1.4.4.js" />
$(document).ready(function () {
    $('*[data-confirmprompt]').click(function (event) {
        var promptText = $(this).data('confirmprompt');
        if (!confirm(promptText)) {
            event.preventDefault();
        } 
    });
});