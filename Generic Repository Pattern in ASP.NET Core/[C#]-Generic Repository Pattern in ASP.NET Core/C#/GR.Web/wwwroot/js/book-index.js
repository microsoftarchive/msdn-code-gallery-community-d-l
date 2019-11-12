(function ($) {
    function Book() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-book").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Book();
        self.init();
    })
}(jQuery))
