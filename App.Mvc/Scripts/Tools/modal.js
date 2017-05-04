// Anon function that listens for requests to mak modals and returns the html
$(function () {
    (function () {
        var makeModal = function (id, title, content, cancelText, saveText, deleteText, pickText, callback) {
            
            if (cancelText == undefined) {
                cancelText = "Cancel"; 
            }

            var rtn = "";
            rtn += "<div id='modal-" + id + "' class='modal modal-lg fade' role='dialog'>";
            rtn += "<div class='modal-dialog '>  ";
            rtn += "<div class='modal-content'>";
            rtn += "<div class='modal-header'>";
            rtn += "<button type='button' class='close' data-dismiss='modal'>&times;</button>";
            rtn += "<h4 class='modal-title'><i class='fa fa-circle-o-notch fa-spin fa-fw showOnAjax'></i>" + title + "</h4></div>";
            rtn += "<div class='modal-body' id='modal-body-" + id + "'><form id='modal-form-" + id + "'>";
            rtn += "<div id='modal-info-" + id + "' class='alert alert-danger' ></div>";
            rtn += content;
            rtn += "</footer><div class='modal-footer'>"
            if (cancelText) {
                rtn += "<button id='cancel-btn' type='button' class='btn btn-default'><i class='icon icon-cancel'></i> " + cancelText + "</button>";
            }
            if (saveText) {
                rtn += "<button id='save-btn' type='button' class='btn btn-info disableOnAjax'><i class='fa fa-circle-o-notch fa-spin fa-fw showOnAjax'></i><i class='icon icon-save'></i> " + saveText + "</button>";
            }
            if (deleteText) {
                rtn += "<button id='delete-btn' type='button' class='btn btn-danger disableOnAjax'><i class='fa fa-circle-o-notch fa-spin fa-fw showOnAjax'></i><i class='icon icon-delete'></i> " + deleteText + "</button>";
            }
            if (pickText) {
                rtn += "<button id='pick-btn' type='button' class='btn btn-info pick-btn disableOnAjax' data-pick-value='-1'><i class='fa fa-circle-o-notch fa-spin fa-fw showOnAjax'></i><i class='icon icon-pick' title='Pick'></i> " + pickText + "</button>";
            }
            rtn += "</div>";
            rtn += "</div>";
            rtn += "</div>";
            rtn += "</div>";
            callback(rtn);
        }

        radio("make-modal").subscribe(makeModal)

        function showModal(settings) {

            /**
            * close the modal
            */
            var close = function () {
                $("#modal-" + settings.id + " [data-dismiss=modal]").trigger({ type: "click" });
                radio("close-modal-" + settings.id).unsubscribe(close);
                radio("clear-modal-" + settings.id).unsubscribe(clearInfo);
                radio("showInfo-modal-" + settings.id).unsubscribe(showInfo);
            };


            /**
            * hide all the info displays (errors etc)
            */
            var clearInfo = function () {
                $("#modal-info-" + settings.id).html("");
                $("#modal-info-" + settings.id).hide();
                $(".error-icon").hide();
                $(".error-icon-for-all").hide();
            }

            /**
            * show all the info displays (errors etc)
            */
            var showInfo = function (msg) {
                $.each(msg, function (e, i) {
                    $("#modal-info-" + settings.id).append(i + "<br/>");
                })
                $("#modal-info-" + settings.id).show();
            }

            /**
            * filter error meesages out and show them 
            */
            var showError = function (err) {
                $("#modal-info-" + settings.id).html("");
                _.map(err, function (n) {
                    var msg = document.translate(n.ErrorMessage);
                    $("#modal-info-" + settings.id).append(msg + "<br/>");
                    $("#error-icon-for-" + n.Property).show();
                    $(".error-icon-for-all").show();
                })
                $("#modal-info-" + settings.id).show();
            }


            /**
            * build a model
            */
            radio("make-modal").broadcast(settings.id, settings.title, settings.content, settings.cancelText, settings.saveText, settings.deleteText,settings.pickText, function (html) {
                $("body").append(html);
                $("#modal-" + settings.id).modal();

                $("#modal-" + settings.id).on('hidden.bs.modal', function () {
                    close();
                    if (settings.onClose) {
                        settings.onClose();
                    }                    
                });

                /**
                 * on cancel clicked
                 */
                $("#modal-" + settings.id + " #cancel-btn ").unbind("click");
                $("#modal-" + settings.id + " #cancel-btn ").click(function () {
                    close();
                    if (settings.onCancel) {
                        settings.onCancel();
                    }
                });

                /**
                 * on delete clicked
                 */
                $("#modal-" + settings.id + " #delete-btn ").unbind("click");
                $("#modal-" + settings.id + " #delete-btn ").click(function () {
                    close();
                    if (settings.onDelete) {
                        settings.onDelete();
                    }
                });

                /**
                 * on save clicked
                 */
                $("#modal-" + settings.id + " #save-btn ").unbind("click");
                $("#modal-" + settings.id + " #save-btn ").click(function () {
                    var indexed_array = {};
                    $.map($("#modal-form-" + settings.id).serializeArray(), function (n, i) {
                        var e = $(n);
                        indexed_array[e.attr("name")] = e.attr("value");
                    });
                    if (settings.onSave) {
                        settings.onSave(indexed_array);
                    }
                });

                /**
                 * on pick clicked
                 */
                $("#modal-" + settings.id + " .pick-btn ").click(function (e) {
                    if (settings.onPick) {
                        var element = $(e.currentTarget);
                        var id = element.attr("data-pick-elementId");
                        var state = element.attr("data-pick-value");
                        settings.onPick({ state: state, id: id });
                    }
                    
                });

                clearInfo();
            });

            /**
             * Radio subscriptions
             */
            radio("close-modal-" + settings.id).subscribe(close);
            radio("clear-modal-" + settings.id).subscribe(clearInfo);
            radio("showInfo-modal-" + settings.id).subscribe(showInfo);           
            radio("showError-modal-" + settings.id).subscribe(showError);
        }


        radio("show-modal").subscribe(showModal)

    })();

})
