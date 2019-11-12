$(function() {
    $("a.delete").live('click', function () {
        var id = $(this).data('comment-id');

        $.ajax({
            url: "/api/comments/" + id,
            type: 'DELETE',
            cache: false,
            statusCode: {
                200: function(data) {
                    viewModel.comments.remove(
                        function(comment) { 
                            return comment.ID == data.ID; 
                        }
                    );
                }
            }
        });

        return false;
    });
});