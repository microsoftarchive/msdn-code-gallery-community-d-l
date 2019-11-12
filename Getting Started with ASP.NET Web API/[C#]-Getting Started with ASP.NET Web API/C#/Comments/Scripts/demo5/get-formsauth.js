$(function () {
    $("#getCommentsFormsAuth").click(function () {
        viewModel.comments([]);
        $.ajax({ url: "/api/comments",
            accepts: "application/json",
            cache: false,
            statusCode: {
                200: function(data) {
                    viewModel.comments(data);
                },
                401: function(jqXHR, textStatus, errorThrown) {
                    self.location = '/Account/Login/';
                }
            }
        });
    });
});