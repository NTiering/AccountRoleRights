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
	
})();