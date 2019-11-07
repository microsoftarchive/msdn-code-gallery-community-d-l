(function ($) {
    // The validator function    
    $.validator.addMethod('rangeDate', function (value, element, param) {
        if (!value) {
            return true; // not testing 'is required' here!        
        }
        try {
            var dateValue = $.datepicker.parseDate("dd/mm/yy", value);
        }
        catch (e) {
            return false;
        }
        return param.min <= dateValue && dateValue <= param.max;
    });
    // The adapter to support ASP.NET MVC unobtrusive validation  
    $.validator.unobtrusive.adapters.add('rangedate', ['min', 'max'], function (options) {
        var params = {
            min: $.datepicker.parseDate("yy/mm/dd", options.params.min),
            max: $.datepicker.parseDate("yy/mm/dd", options.params.max)
        };
        options.rules['rangeDate'] = params;
        if (options.message) {
            options.messages['rangeDate'] = options.message;
        }
    });
} (jQuery));