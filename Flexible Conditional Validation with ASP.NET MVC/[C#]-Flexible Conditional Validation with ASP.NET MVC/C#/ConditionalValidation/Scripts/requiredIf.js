/// <reference path="jquery-1.4.4-vsdoc.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

(function ($) {
    // The following functions are taken from jquery.validate.unobtrusive: getModelPrefix, appendModelPrefix
    function getModelPrefix(fieldName) {
        return fieldName.substr(0, fieldName.lastIndexOf(".") + 1);
    }
    function appendModelPrefix(value, prefix) {
        if (value.indexOf("*.") === 0) {
            value = value.replace("*.", prefix);
        }
        return value;
    }

    function getPropertyValue(propertyName, dataType, prefix) {
        var name = appendModelPrefix(propertyName, prefix);

        // get the actual value of the target control
        // note - this probably needs to cater for more 
        // control types, e.g. radios
        var control = $('*[name=\'' + name + '\']');
        var controlType = control.attr('type');
        var actualValue =
                controlType === 'checkbox' ?
                control.attr('checked') :
                control.val();
        
        // test for date format and handle (via jQuery UI)
        var dateFormat = control.data('dateformat');
        if (dateFormat != undefined) {
            actualValue = $.datepicker.parseDate(dateFormat, actualValue); // consider testing for parseDate and throwing a helpful message :-)
        }
        return actualValue;
    }

    $.validator.addMethod('requiredif',
        function (value, element, parameters) {
            var validatorFunc = parameters.validatorFunc;
            var result = validatorFunc();
            if (result) {
                // if the condition is true, reuse the existing 
                // required field validator functionality
                return $.validator.methods.required.call(this, value, element, parameters);
            }
            return true;
        }
    );

    $.validator.unobtrusive.adapters.add('requiredif',
        ['expression'], // what attributes do we want
        function (options) {
            var prefix = getModelPrefix(options.element.name);
            var expression = options.params['expression'];
            var gv = function(propertyName, dataType) { return getPropertyValue(propertyName, dataType, prefix); };
            eval('function theValidator(gv) { return ' + expression + ';}');
            options.rules['requiredif'] = {
                validatorFunc: function () {
                    return theValidator(gv);
                }
            };
            options.messages['requiredif'] = options.message;
        }
    );

})(jQuery);
