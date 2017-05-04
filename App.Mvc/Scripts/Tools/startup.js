/**
 * Anon function ran on start up , or any new page section loaded
 */
(function () {

    /**
     * set up refresh stack
     */
    document.refreshFunctions = [];
    radio("app-refresh-register").subscribe(function (fn) {
        document.refreshFunctions.push(fn);
    })
    radio("app-refresh-unregister").subscribe(function () {
        document.refreshFunctions.pop();
    })
    radio("app-refresh-do").subscribe(function () {
        var fn = document.refreshFunctions[document.refreshFunctions.length - 1];
        fn();
    })
    // register base refresh
    radio("app-refresh-register").broadcast(function () {
        radio("notify-warning").broadcast({ title: "Page out of date !!!!", message: "<span onclick='window.location.reload();'><i class='fa fa-refresh'></i> Click to refresh</span>" });
    })

    /**
     * set up is dirty flag  
     */
    radio("app-isDirty").subscribe(function (flag) {
        if (flag) {
            $(".isDirty").show();
            radio("app-refresh-do").broadcast();
            //radio("notify-warning").broadcast({ title: "Page out of date", message: "<span onclick='window.location.reload();'><i class='fa fa-refresh'></i> Click to refresh</span>" })
        } else {
            $(".isDirty").hide();
        }
    })

    /**
     *  set up read only elements
     */
    radio("app-startup").subscribe(function () {        
        $(".readonly").attr("readonly", "readonly");
    })

    /**
     *  setup date time picker  
     */
    radio("app-startup").subscribe(function () {
        $('.data-DateTime').not('.readonly').datepicker({
            format: "dd/mm/yyyy",
            todayBtn: "linked",
            autoclose: true
        });
    });
    
    /**
     * setup key press inhibitors
     */
    radio("app-startup").subscribe(function () {
        $(".type-int").keydown(function (event) {
            var filter = "0123456789";
            var key = event.keyCode;

            if (key == 8) return; // del
            if (key == 37) return; // left arrow
            if (key == 39) return; // right arrow
            if (key == 9) return; // tab
            if (key == 13) return; // return
            if (key == 189) return; // minus
            if (key == 187) return; // plus

            for (var i in filter) {
                var allowed = filter[i].charCodeAt(0);
                if (key == allowed) return;
            }

            event.preventDefault();
        });

        $(".type-money").keydown(function (event) {
            var filter = "0123456789";
            var key = event.keyCode;

            if (key == 8) return; // del
            if (key == 37) return; // left arrow
            if (key == 39) return; // right arrow
            if (key == 9) return; // tab
            if (key == 190) return; // dot
            if (key == 13) return; // return
            if (key == 189) return; // minus
            if (key == 187) return; // plus


            for (var i in filter) {
                var allowed = filter[i].charCodeAt(0);
                if (key == allowed) return;
            }

            event.preventDefault();
        });


        $(".type-moneypositive").keydown(function (event) {
            var filter = "0123456789";
            var key = event.keyCode;

            if (key == 8) return; // del
            if (key == 37) return; // left arrow
            if (key == 39) return; // right arrow
            if (key == 9) return; // tab
            if (key == 190) return; // dot
            if (key == 13) return; // return

            for (var i in filter) {
                var allowed = filter[i].charCodeAt(0);
                if (key == allowed) return;
            }

            event.preventDefault();
        });


        $(".type-moneynegative").keydown(function (event) {
            var filter = "0123456789";
            var key = event.keyCode;

            if (key == 8) return; // del
            if (key == 37) return; // left arrow
            if (key == 39) return; // right arrow
            if (key == 9) return; // tab
            if (key == 190) return; // dot
            if (key == 13) return; // return
            if (key == 189) return; // minus

            for (var i in filter) {
                var allowed = filter[i].charCodeAt(0);
                if (key == allowed) return;
            }

            event.preventDefault();
        });
    });

    /**
     * Set up data tables
     */
    radio("app-startup").subscribe(function () {
        $(".dataTable").DataTable();
        $(".dataTable").removeClass("dataTable");
    });

    /**
     * set up is dirty flag 
     */
    radio("app-startup").subscribe(function () {
        radio("app-isDirty").broadcast(false);
    });

    /**
     * swap picker classes and values
     */
    radio("app-startup").subscribe(function () {
        $("[data-pickable]").unbind("click");
        $("[data-pickable]").click(function (e) {
            var source = e.target;
            $(source)
                .toggleClass("fa-check")
                .toggleClass("fa-times")
                .toggleClass("btn-info")
                .toggleClass("btn-danger");
            var current = $(source).attr("data-pick-value");
            $(source).attr("data-pick-value", current == 1 ? 0 : 1);
        });        
    });

    /**
    * setup picker classes and values
    */
    radio("app-startup").subscribe(function () {
        $("[data-pickable]").each(function (i, e) {
            var source = $(e) ; 
            var val = source.attr("data-pick-value");
            if (val == 1) {
                $(source)
                   .toggleClass("fa-check")
                   .toggleClass("fa-times")
                   .toggleClass("btn-info")
                   .toggleClass("btn-danger");
            }
        })
    })

    /**
     * global set up for ajax event
     */
    radio("app-startup").subscribe(function (flag) {       
            $(document).ajaxStart(function () {
                $(".showOnAjax").show();
                $(".hideOnAjax").hide();
                $(".disableOnAjax").attr("disabled","disabled");
            })

            $(document).ajaxStop(function () {
                $(".showOnAjax").hide();
                $(".hideOnAjax").show();
                $(".disableOnAjax").removeAttr("disabled");
            })

            $(document).ajaxError(function () {
                $(".showOnAjax").hide();
                $(".hideOnAjax").show();
                $(".disableOnAjax").removeAttr("disabled");
                radio("notify-error").broadcast({ title: "Server Error", message :"The server refused a request"});
            })        
    })

    /**
     * Set up password fill popup
     */
    radio("password-fill").subscribe(function (fnCallback) {

        $.get(document.endpoints.password.form, function (html) {
            var id = new Date().getTime();
            radio("show-modal").broadcast({
                id: id,
                title: "<i class='fa fa-key icon-password ' /> Enter value for " + fnCallback.name,
                content: html  ,
                saveText: "Save",
                cache : false,
                onSave: function (d) {
                    radio("clear-modal-" + id).broadcast();
                    if (d.password1 == "") {
                        radio("showError-modal-" + id).broadcast([{ Property: "password1", ErrorMessage: "passord_match_missing" }]);
                    } else if (d.password1 != d.password2) {
                        radio("showError-modal-" + id).broadcast([{ Property: "password1", ErrorMessage: "passord_match_mismatch" }]);
                    } else {
                        fnCallback.onSave(d.password1);
                        radio("close-modal-" + id).broadcast();
                    }                   
                }
            })

        })
        
    })


})();

