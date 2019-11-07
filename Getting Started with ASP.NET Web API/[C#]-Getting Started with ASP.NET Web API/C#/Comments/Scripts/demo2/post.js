$(function () {
    var form = $('#newCommentForm');
    form.submit(function () {
        var form = $(this);
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
                }
            }
        });

        return false;
    });
});