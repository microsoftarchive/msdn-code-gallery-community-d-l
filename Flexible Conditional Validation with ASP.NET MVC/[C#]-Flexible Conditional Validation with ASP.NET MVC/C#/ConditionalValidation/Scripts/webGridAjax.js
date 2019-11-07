/// <reference path="jquery-1.4.4-vsdoc.js" />
$(document).ready(function () {

    function ajaxGridLink(e) {
        var id = $(this).parents('.ajaxGrid').attr('id');
        var url = $(this).attr('href');
        $('#' + id).load(url + ' #' + id);
        e.preventDefault();
    };
    $('.ajaxGrid table thead tr a').live('click', ajaxGridLink); // hook up ajax refresh for sorting links
    $('.ajaxGrid table tfoot tr a').live('click', ajaxGridLink); // hook up ajax refresh for paging links (note: this doesn't handle the separate Pager() call!)
});