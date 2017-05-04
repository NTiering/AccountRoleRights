/**
 * helper functions for role entities
 */
(function () {

	/** //1
	* show self contained popup for listing Account Role (role) entities
	*/
	radio('Role-AccountRole').subscribe(function (modelId) {
	
			$.get(document.endpoints.account.getAccountRole + "/" + modelId + "?selected=true", function (html) {
			var id = new Date().getTime();
			var selected = [] ;
			radio("show-modal").broadcast({ 
				id: id,
				title: "<i class='icon-account'></i> Account Entities <small>Account Role for Role " + modelId + "</small><hr/><button class='btn btn-info btn-sm disableOnAjax' onclick='radio(\"Account-Add-AccountRole\").broadcast(" + modelId + ")'><i class='icon-account'></i> Add New Account</button> <button class='btn btn-success btn-sm disableOnAjax' onclick='radio(\"Account-Pick-AccountRole\").broadcast(" + modelId + ")' ><i class='icon-account'></i> Add Existing Account</button>",
				content: html,
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
	* show self contained popup for adding new role Account Role
	*/
	radio('Role-Add-AccountRole').subscribe(function (modelId) {

	    $.get(document.endpoints.role.addAccountRole , function (html) {
			var id = new Date().getTime();
			radio("show-modal").broadcast({
				id: id,
				title: "<i class='icon-role'></i> Add New Role <small>Account Role for Account " + modelId + "</small>",
				content: html,
				saveText : "Save",
				onSave: function (data) {
                    data.modelId = modelId;
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'POST',
                        url: document.endpoints.role.saveAccountRole,
                        data: data,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Role (" + e.Model.Id + ") updated", message: "<span onclick=\"radio('app-role-view').broadcast(" + e.Model.Id + ")\"><i class='icon-role'></i> View Role</span>" })
                            radio("app-isDirty").broadcast(true);
                        } else {
                            radio("showError-modal-" + id).broadcast(e.Errors);
                        }
                    });
				}
			})
	    })
	})

    /**
	* show self contained popup for adding new role Account Role  
	*/
	radio('Role-Pick-AccountRole').subscribe(function (modelId) {
		
		var selected = [] ;
		// register a refresh function 
		radio("app-refresh-register").broadcast(function () {
			radio("app-refresh-unregister").broadcast(); // unsubscribe us 
			radio("close-modal-" + id).broadcast(); // close this modal 	            
			radio('Role-AccountRole').broadcast(modelId); // re open it 
		})
	    $.get(document.endpoints.role.list, function (html) {
			var id = new Date().getTime();
			radio("show-modal").broadcast({
				id: id,
				title: "<i class='icon-role'></i> Pick Existing Role <small>Account Role for Account " + modelId + "</small>",
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
								radio("close-modal-" + id).broadcast(); // close this modal 	
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
	
	/** //1
	* show self contained popup for listing Role Right (role) entities
	*/
	radio('Role-RoleRight').subscribe(function (modelId) {
	
			$.get(document.endpoints.right.getRoleRight + "/" + modelId + "?selected=true", function (html) {
			var id = new Date().getTime();
			var selected = [] ;
			radio("show-modal").broadcast({ 
				id: id,
				title: "<i class='icon-right'></i> Right Entities <small>Role Right for Role " + modelId + "</small><hr/><button class='btn btn-info btn-sm disableOnAjax' onclick='radio(\"Right-Add-RoleRight\").broadcast(" + modelId + ")'><i class='icon-right'></i> Add New Right</button> <button class='btn btn-success btn-sm disableOnAjax' onclick='radio(\"Right-Pick-RoleRight\").broadcast(" + modelId + ")' ><i class='icon-right'></i> Add Existing Right</button>",
				content: html,
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
	* show self contained popup for adding new role Role Right
	*/
	radio('Role-Add-RoleRight').subscribe(function (modelId) {

	    $.get(document.endpoints.role.addRoleRight , function (html) {
			var id = new Date().getTime();
			radio("show-modal").broadcast({
				id: id,
				title: "<i class='icon-role'></i> Add New Role <small>Role Right for Right " + modelId + "</small>",
				content: html,
				saveText : "Save",
				onSave: function (data) {
                    data.modelId = modelId;
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'POST',
                        url: document.endpoints.role.saveRoleRight,
                        data: data,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Role (" + e.Model.Id + ") updated", message: "<span onclick=\"radio('app-role-view').broadcast(" + e.Model.Id + ")\"><i class='icon-role'></i> View Role</span>" })
                            radio("app-isDirty").broadcast(true);
                        } else {
                            radio("showError-modal-" + id).broadcast(e.Errors);
                        }
                    });
				}
			})
	    })
	})

    /**
	* show self contained popup for adding new role Role Right  
	*/
	radio('Role-Pick-RoleRight').subscribe(function (modelId) {
		
		var selected = [] ;
		// register a refresh function 
		radio("app-refresh-register").broadcast(function () {
			radio("app-refresh-unregister").broadcast(); // unsubscribe us 
			radio("close-modal-" + id).broadcast(); // close this modal 	            
			radio('Role-RoleRight').broadcast(modelId); // re open it 
		})
	    $.get(document.endpoints.role.list, function (html) {
			var id = new Date().getTime();
			radio("show-modal").broadcast({
				id: id,
				title: "<i class='icon-role'></i> Pick Existing Role <small>Role Right for Right " + modelId + "</small>",
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
								radio("close-modal-" + id).broadcast(); // close this modal 	
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
	* show self contained popup for deleting role entity
	*/
    radio('app-role-delete').subscribe(function (modelId) {

        $.get(document.endpoints.role.delete + "/" + modelId , function (html) {
            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-role'></i> Delete Role " + modelId,
                content: html,
                deleteText: "Delete",
                onDelete: function (data) {
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'Post',
                        url: document.endpoints.role.remove + "/" + modelId,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        console.log(e);
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Role deleted", message: "" })
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
    * show self contained popup for editing role entity
    */
	radio('app-role-edit').subscribe(function (modelId) {
        
        $.get(document.endpoints.role.edit + "/" + modelId, function (html) {
            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-role'></i> Edit Role " + modelId,
                content: html,
                saveText : "Update" ,
                onSave: function (data) {
                    data.id = modelId;
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'POST',
                        url: document.endpoints.role.save,
                        data: data,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
                            radio("notify-success").broadcast({ title: "Role (" + e.Model.Id + ") updated", message: "<span onclick=\"radio('app-role-view').broadcast(" + e.Model.Id + ")\"><i class='icon-role'></i> View Role</span>" })
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
    * show self contained popup for viewing role entity
    */
	radio('app-role-view').subscribe(function (modelId) {
        
        $.get(document.endpoints.role.view + "/" + modelId , function (html) {
            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-role'></i> View Role " + modelId,
                content: html
            })
        })
    });

    /**
    * show self contained popup for adding new role entity
    */
    radio("app-role-add").subscribe(function () {//1
        $.get(document.endpoints.role.create, function (html) {

            var id = new Date().getTime();

            radio("show-modal").broadcast({
                id: id,
                title: "<i class='icon-role'></i> Add New Role",
                content: html,
				saveText: "Save",
                onSave: function (data) {
                    radio("clear-modal-" + id).broadcast();
                    $.ajax({
                        type: 'POST',
                        url: document.endpoints.role.save,
                        data: data,
                        dataType: "json",
                        cache: false
                    }).done(function (e) {
                        if (e.Success) {
                            radio("close-modal-" + id).broadcast();
							radio("notify-success").broadcast({ title: "Role (" + e.Model.Id + ") created", message: "<span onclick=\"radio('app-role-view').broadcast(" + e.Model.Id + ")\"><i class='icon-role'></i> View Role</span>" })
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