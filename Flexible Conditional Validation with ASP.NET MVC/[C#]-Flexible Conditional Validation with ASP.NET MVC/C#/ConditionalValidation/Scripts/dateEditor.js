/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery-ui.js" />
$(document).ready(function () {
    function getDateYymmdd(value) {
        if (value == null)
            return null;
        return $.datepicker.parseDate("yy/mm/dd", value);
    }
    $('.date').each(function () {
        var minDate = getDateYymmdd($(this).data("val-rangedate-min"));
        var maxDate = getDateYymmdd($(this).data("val-rangedate-max"));
        $(this).datepicker({
            dateFormat: "dd/mm/yy",
            minDate: minDate,
            maxDate: maxDate
        });
    });
});