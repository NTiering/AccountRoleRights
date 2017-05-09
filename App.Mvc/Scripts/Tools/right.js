/**
 * helper functions for right entities
 */
(function () {

    /** 
    * show self contained popup for listing Role Right (right) entities
    */
    radio('Right-RoleRight').subscribe(function (modelId) {
        
            var selected = [] ;
            $.get(document.endpoints.role.getRoleRight + "/" + modelId , function (html) {
            var id = new Date().getTime();

            // register a refresh function 
            radio("app-refresh-register").broadcast(function () {
            radio("app-refresh-unregister").broadcast(); // unsubscribe us 
            radio("close-modal-" + id).broadcast(); // close this modal                 
            radio('Right-RoleRight').broadcast(modelId); // re open it 
            })
            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-role'></i> Role Entities <small>Role Right for Right " + modelId + "</small><hr/><button class='btn btn-info btn-sm disableOnAjax' onclick='radio(\"Role-Add-RoleRight\").broadcast(" + modelId + ")'><i class='icon-role'></i> Add New Role</button> <button class='btn btn-success btn-sm disableOnAjax' onclick='radio(\"Role-Pick-RoleRight\").broadcast(" + modelId + ")' ><i class='icon-role'></i> Add Existing Role</button>",
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
                            url: "/role/UnLinkRoleRight",
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
    * show self contained popup for adding new right Role Right
    */
    radio('Right-Add-RoleRight').subscribe(function (modelId) {

        $.get(document.endpoints.right.addRoleRight + "/" + modelId, function (html) {
        var id = new Date().getTime();
            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-right'></i> Add New Right <small>Role Right for Role " + modelId + "</small>",
                content: html,
                saveText: "Save",
                onSave: function (data) {
                    radio("clear-modal-" + id).broadcast();
                    data.modelId = modelId
                    $.ajax({
                        type: 'Post',
                        data: data,
                        url: document.endpoints.right.saveRoleRight,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Right updated", message: "" })
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
    * show self contained popup for picking existing right Role Right  
    */
    radio('Right-Pick-RoleRight').subscribe(function (modelId) {
        var selected = [];
        $.get(document.endpoints.right.list, function (html) {
        var id = new Date().getTime();
            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-right'></i> Pick Existing Right <small>Role Right for Role " + modelId + "</small>",
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
                            url: "/role/LinkRoleRight",
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
    
    /**
    * show self contained popup for deleting right entity
    */
    radio('app-right-delete').subscribe(function (modelId) {

        $.get(document.endpoints.right.delete + "/" + modelId , function (html) {
            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-right'></i> Delete Right " + modelId,
                content: html,
                deleteText: "Delete",
                onDelete: function (data) {
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'Post',
                        url: document.endpoints.right.remove + "/" + modelId,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        console.log(e);
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Right deleted", message: "" })
                            radio("app-isDirty").broadcast(true);
                        } else {
                            radio("showError-modal-" + id).broadcast(e.Errors);
                        }
                    });
                },
            })
        })
    });



    /**
    * show self contained popup for editing right entity
    */
    radio('app-right-edit').subscribe(function (modelId) {
        
        $.get(document.endpoints.right.edit + "/" + modelId, function (html) {
            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-right'></i> Edit Right " + modelId,
                content: html,
                saveText : "Update" ,
                onSave: function (data) {
                    data.id = modelId;
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'POST',
                        url: document.endpoints.right.save,
                        data: data,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Right (" + e.Model.Id + ") updated", message: "<span onclick=\"radio('app-right-view').broadcast(" + e.Model.Id + ")\"><i class='icon-right'></i> View Right</span>" })
                            radio("app-isDirty").broadcast(true);
                        } else {
                            radio("showError-modal-" + id).broadcast(e.Errors);
                        }
                    });
                },
            })
        })
    });

    /**
    * show self contained popup for viewing right entity
    */
    radio('app-right-view').subscribe(function (modelId) {
        
        $.get(document.endpoints.right.view + "/" + modelId , function (html) {
            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-right'></i> View Right " + modelId,
                content: html
            })
        })
    });

    /**
    * show self contained popup for adding new right entity
    */
    radio("app-right-add").subscribe(function () {//1
        $.get(document.endpoints.right.create, function (html) {

            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-right'></i> Add New Right",
                content: html,
                saveText: "Save",
                onSave: function (data) {
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'POST',
                        url: document.endpoints.right.save,
                        data: data,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Right (" + e.Model.Id + ") created", message: "<span onclick=\"radio('app-right-view').broadcast(" + e.Model.Id + ")\"><i class='icon-right'></i> View Right</span>" })
                            radio("app-isDirty").broadcast(true);
                        }else{
                            radio("showError-modal-" + id).broadcast(e.Errors);                       
                        }
                    });
                },
            })
        })
    });
})();