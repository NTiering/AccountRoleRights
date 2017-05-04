/**
 * App helper functions
 */
(function () {
    /**
     *  Add tool bar item
     */
    radio("app-addToolbar").subscribe(function (buttonHtml) {
        $(".navbar-right").append("<li><a href='#'>" + buttonHtml + "</a></li>");
    });


})();