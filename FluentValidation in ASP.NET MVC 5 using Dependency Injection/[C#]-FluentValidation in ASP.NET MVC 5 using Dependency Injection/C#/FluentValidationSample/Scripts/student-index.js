$(function(){
    function StudentIndex(){
        var $this = this;

        function initializeModalForm(){
            $("#modal-add-edit-student").on('loaded.bs.modal', function (e) {
                var addEditStudetForm = $(this).find("form");
                $.validator.unobtrusive.parseDynamicContent(addEditStudetForm);
                addEditStudetForm.submit(function (e) {                   
                    if (addEditStudetForm.validate().valid()) {

                        $.ajax(addEditStudetForm.attr("action"), {
                            type: "POST",
                            data: addEditStudetForm.serializeArray(),
                            success: function (result) {
                                console.log('test');
                            },
                            error: function (jqXHR, status, error) {
                                if (onError !== null && onError !== undefined) {
                                    onError(jqXHR, status, error);
                                }
                            }, complete: function () {

                            }
                        });
                    }
                    e.preventDefault();
                });
            })
        }

        $this.init = function(){
            initializeModalForm();
        }
    }
    $(function(){
        var self = new StudentIndex();
        self.init();
    })
}(jQuery))