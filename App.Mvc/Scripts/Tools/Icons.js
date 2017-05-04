/*
 * Sets up icons for general UI
 **/
(function () {

    radio("app-startup").subscribe(function () {

        $(".icon-cancel").addClass("fa fa-times").attr("title", "Cancel");
        $(".icon-edit").addClass("fa fa-pencil").attr("title", "Edit");
        $(".icon-save").addClass("fa fa-floppy-o").attr("title", "Save");
        $(".icon-pick").addClass("fa fa-check").attr("title", "Pick");      
        $(".icon-edit").addClass("fa fa-pencil").attr("title", "Edit");
        $(".icon-refresh").addClass("fa fa-refresh").attr("title", "Refresh");
        $(".icon-search").addClass("fa fa-search").attr("title", "Edit");
        $(".icon-home").addClass("fa fa-home").attr("title", "Home");
        $(".icon-view").addClass("fa fa-search").attr("title", "View");
        $(".icon-new").addClass("fa fa-plus-square").attr("title", "New");
        $(".icon-delete").addClass("fa fa-minus-circle").attr("title", "Delete");
        $(".icon-help").addClass("fa fa-question-circle");
        $(".icon-error").addClass("fa fa-exclamation-triangle");
        $(".icon-relationship").addClass("fa fa-list-alt");

        $(".icon-account").addClass("fa fa-bicycle");        

        $(".icon-role").addClass("fa fa-bath");        

        $(".icon-right").addClass("fa fa-bolt");        
    })

})();