$(function () {
    //---------------------------------------------------------
    // Using Queryable to page
    //---------------------------------------------------------
    $("#getCommentsQueryable").click(function () {
        viewModel.comments([]);

        var pageSize = $('#pageSize').val();
        var pageIndex = $('#pageIndex').val();

        var url = "/api/comments?$top=" + pageSize + '&$skip=' + (pageIndex * pageSize);

        $.getJSON(url, function (data) {
            // Update the Knockout model (and thus the UI) with the comments received back 
            // from the Web API call.
            viewModel.comments(data);
        });

        return false;
    });
});