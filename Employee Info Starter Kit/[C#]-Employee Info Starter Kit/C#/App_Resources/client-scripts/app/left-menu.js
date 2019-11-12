/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

function BindMenuItems() {

    $('#menu ul').hide();
    LoadSelectedMenuItemOrNode();

    $('#menu li a').click(
    function () {
        var href = $(this).attr('href'); /*parent navigation support*/
        //if (href == window.location.pathname) return false;
        
        //if a MenuItem with a hyperlink is clicked, re-direct to that location
        if (IsRedirectionUrl(href))/*parent navigation support*/
            window.location = href; /*parent navigation support*/

        var clickedMenuItem = $(this).next();
        //if the clicked MenuItem nodes are already visible, no need to take any action
        if ((clickedMenuItem.is('ul')) && (clickedMenuItem.is(':visible'))) {
            return false;
        }
        
        //if the clicked MenuItem nodes are not visible, then hide the previous MenuItem nodes and make the clicked MenuItem nodes visible
        if ((clickedMenuItem.is('ul')) && (!clickedMenuItem.is(':visible'))) {
            $('#menu ul:visible').slideUp('normal');

            if (!IsRedirectionUrl(href))/*parent navigation support*/
                clickedMenuItem.slideDown('normal'); /*parent navigation support*/

            return false;
        }
    }
    );

    $('#menu').mouseleave(
    function () {

        var path = location.pathname;
        var currentVisibleMenuItem = $('#menu ul:visible');
        var item = $(currentVisibleMenuItem).find("a[href='" + path + "']")[0];

        //if sub-menu item is selected currently & in visible area
        if (item) {
            return false;
        }

        //else if menu item is selected currently & in visible area
        else if (currentVisibleMenuItem.parents('li').find("a[href='" + path + "']")[0]) {/*parent navigation support*/
            return false; /*parent navigation support*/
        } /*parent navigation support*/

        //otherwise we've made a menu visible that is not selected (i.e. in current page location) 
        else {
            LoadSelectedMenuItemOrNode();
        }
    }
    );
}

function LoadSelectedMenuItemOrNode() {
    //get the current location
    var path = location.pathname;
    //get the target sub-menu
    var item = $("#menu").find("a[href='" + path + "']");
    //hide existing visible menu item
    $('#menu ul:visible').slideUp('normal');
    //expand target menu
    var menuItem;
    menuItem = $(item).parents('li').children('ul');/*parent navigation support*/
    if (!menuItem)/*parent navigation support*/
        menuItem = $(item).parents('ul');
    menuItem.slideDown('normal');
    //apply 'selected' style to target sub-menu
    item.addClass('SelectedNode');

};

function IsRedirectionUrl(url) {
    
    if ( (url == '#') || (url.endsWith('?')) )
        return false;

    return true;
}

String.prototype.endsWith = function (pattern) {
    var d = this.length - pattern.length;
    return d >= 0 && this.lastIndexOf(pattern) === d;
};

$(document).ready(function () { BindMenuItems(); });