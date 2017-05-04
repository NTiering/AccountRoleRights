/**
 * helper functions for navigtions
 */
(function () {
	/**
	* Show navigation popup
	*/
    radio('Navigation-Show').subscribe(function () {
		
			var selected = [] ;
			$.get(document.endpoints.navigation, function (html) {
		    var id = new Date().getTime();
            radio("show-modal").broadcast({
                id: id,
                title: "Sections",
                content: html,
                cancelText: "Done"
            })
		})		
	})	
})();