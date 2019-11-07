$(function () {
    $.validator.addMethod("failure", function () { return false; });
    $.validator.unobtrusive.adapters.addBool("failure");
    $.validator.unobtrusive.revalidate = function (form, validationResult) {
        $.removeData(form[0], 'validator');
        var serverValidationErrors = [];
        for (var property in validationResult) {
            var elementId = property.toLowerCase();
            elementId = elementId.substr(elementId.indexOf('.') + 1);
            var item = form.find('#' + elementId);
            serverValidationErrors.push(item);
            item.attr('data-val-failure', validationResult[property][0]);
            jQuery.validator.unobtrusive.parseElement(item[0]);
        }
        form.valid();
        $.removeData(form[0], 'validator');
        $.each(serverValidationErrors, function () {
            this.removeAttr('data-val-failure');
            jQuery.validator.unobtrusive.parseElement(this[0]);
        });
    }

    var form = $('#newCommentForm');
    form.submit(function () {
        var form = $(this);
        if (!form.valid()) {
            return false;
        }

        var comment = { ID: 0, Text: $('#text').val(), Author: $('#author').val(), Email: $('#email').val(), GravatarUrl: '' };
        var json = JSON.stringify(comment);

        $.ajax({
            url: '/api/comments',
            cache: false,
            type: 'POST',
            data: json,
            contentType: 'application/json; charset=utf-8',
            statusCode: {
                201 /*Created*/: function (data) {
                    viewModel.comments.push(data);
                },
                400 /* BadRequest */: function (jqxhr) {
                    var validationResult = $.parseJSON(jqxhr.responseText);
                    $.validator.unobtrusive.revalidate(form, validationResult.ModelState);
                }
            }
        });

        return false;
    });
});