/**
* Controller for role
*/
app.controller('role', function ($scope) {
    // **********************
    // private properties
    // **********************
	var _dataTableId = "tbl-role";

    // **********************
    // public properties
    // **********************
    
    // **********************
    // private methods
    // **********************
    var _init = function () {
        //load data
        document.title = "Role";
        _loadData();
        $scope.$apply();
    }

	// load data into table
    var _loadData = function () {
        //todo go to server and load data
        $('#' + _dataTableId).DataTable();
    }
    // **********************
    // public methods
    // **********************
    
    // **********************
    // radio subscriptions
    // **********************
    radio("role-Init").subscribe(_init);
});