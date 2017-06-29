/**
 * helper functions for account entities
 */
(function () {



    /** 
    * show self contained popup for listing Account Role (account) entities
    */
    radio('Account-AccountRole').subscribe(function (modelId) {
        
            var selected = [] ;
            $.get(document.endpoints.role.getAccountRole + "/" + modelId , function (html) {
            var id = new Date().getTime();

            // register a refresh function 
            radio("app-refresh-register").broadcast(function () {
            radio("app-refresh-unregister").broadcast(); // unsubscribe us 
            radio("close-modal-" + id).broadcast(); // close this modal                 
            radio('Account-AccountRole').broadcast(modelId); // re open it 
            })
            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-role'></i> Role Entities <small>Account Role for Account " + modelId + "</small><hr/><button class='btn btn-success btn-sm disableOnAjax' onclick='radio(\"Role-Pick-AccountRole\").broadcast(" + modelId + ")' ><i class='icon-role'></i> Add Role</button>",
                content: html  ,
                pickText: "Update",
                onPick: function (e) {
                    if (e.state == 0) {
                        if (selected.indexOf(e.id) == -1) {
                            selected.push(e.id);
                        }
                    }
                    if (e.state == 1) {
                        selected = _.reject(selected, function (x) { return x == e.id });
                    }
                    if (e.state == -1) {
                         $.ajax({
                            type: 'POST',
                            url: "/role/UnLinkAccountRole",
                            data: { modelId: modelId, items: selected },
                            dataType: "json",
                            cache: false
                        }).done(function (e) {
                            if (e.Success) {
                                radio("close-modal-" + id).broadcast();
                                radio("app-refresh-unregister").broadcast(); // unsubscribe us 
                                radio("notify-success").broadcast({ title: "Role (" + modelId + ") updated", message: "<span onclick=\"radio('app-role-view').broadcast(" + modelId + ")\"><i class='icon-role'></i> View Role</span>" })
                                radio("app-isDirty").broadcast(true);
                            } else {
                                radio("showError-modal-" + id).broadcast(e.Errors);
                            }
                        });
                    }
                }      
            })
        })        
    })    

    /**
    * show self contained popup for adding new account Account Role
    */
    radio('Account-Add-AccountRole').subscribe(function (modelId) {

        $.get(document.endpoints.account.addAccountRole + "/" + modelId, function (html) {
        var id = new Date().getTime();
            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-account'></i> Add New Account <small>Account Role for Role " + modelId + "</small>",
                content: html,
                saveText: "Save",
                onSave: function (data) {
                    radio("clear-modal-" + id).broadcast();
                    data.modelId = modelId
                    $.ajax({
                        type: 'Post',
                        data: data,
                        url: document.endpoints.account.saveAccountRole,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Account updated", message: "" })
                            radio("app-isDirty").broadcast(true);
                        } else {
                            radio("showError-modal-" + id).broadcast(e.Errors);
                        }
                    });
                },
            })
        })
    })

    /**
    * show self contained popup for picking existing account Account Role  
    */
    radio('Account-Pick-AccountRole').subscribe(function (modelId) {
        var selected = [];
        $.get(document.endpoints.account.list, function (html) {
        var id = new Date().getTime();
            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-account'></i> Pick Existing Account <small>Account Role for Role " + modelId + "</small>",
                content: html,
                pickText: "Pick",
                onPick: function (e) {
                    if (e.state == 1) {
                        if (selected.indexOf(e.id) == -1) {
                            selected.push(e.id);
                        }
                    }
                    if (e.state == 0) {
                        selected = _.reject(selected, function (x) { return x == e.id });
                    }
                    if (e.state == -1) {
                        $.ajax({
                            type: 'POST',
                            url: "/role/LinkAccountRole",
                            data: { modelId: modelId, items: selected },
                            dataType: "json",
                            cache: false
                        }).done(function (e) {
                            if (e.Success) {
                                radio("close-modal-" + id).broadcast();
                                radio("notify-success").broadcast({ title: "Role (" + modelId + ") updated", message: "<span onclick=\"radio('app-role-view').broadcast(" + modelId + ")\"><i class='icon-role'></i> View Role</span>" })
                                radio("app-isDirty").broadcast(true);
                            } else {
                                radio("showError-modal-" + id).broadcast(e.Errors);
                            }
                        });
                    }
                }
            })
        })
    })    
    })();