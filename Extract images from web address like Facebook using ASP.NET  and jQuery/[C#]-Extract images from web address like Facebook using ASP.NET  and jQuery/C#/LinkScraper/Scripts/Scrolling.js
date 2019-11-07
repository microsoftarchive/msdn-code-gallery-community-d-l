
        
        $(document).ready(function () {
            var Skip = 49; //Number of skipped row
            var Take = 14; //
            function Load(Skip, Take) {
                $('#divPostsLoader').html('<img src="ProgressBar/ajax-loader.gif">');

                //send a query to server side to present new content
                $.ajax({
                    type: "POST",
                    url: "Grid.aspx/LoadImages",
                    data: "{ Skip:" + Skip + ", Take:" + Take + " }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data != "") {
                            $('.thumb').append(data.d);
                        }
                        $('#divPostsLoader').empty();
                    }

                })
            };
            //Larger thumbnail preview 

            //When scroll down, the scroller is at the bottom with the function below and fire the lastPostFunc function
            $(window).scroll(function () {

                if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                    Load(Skip, Take);


                    Skip = Skip + 14;
                }
            });
        });
