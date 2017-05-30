/**
 * helper functions for right entities
 */
(function () {


		/** 
		* show self contained popup for listing Role Right entities
		*/
		radio('Right-RoleRight').subscribe(function(modelId){
			var id = new Date().getTime();
			$.get(document.endpoints.right.getRoleRight + "/" + modelId , function (html) {
            var id = new Date().getTime();
            var selected = [] ;
            radio("show-modal").broadcast({ 
                id: id,
                title: "<i class='icon-right'></i> Right Entities <small>Role Right for Role " + modelId + "</small>",
                content: html})
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