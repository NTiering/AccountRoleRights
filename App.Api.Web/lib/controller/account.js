/**
* Controller for account
*/
app.controller('account', function ($scope) {
    // **********************
    // private properties
    // **********************
	var _dataTableId = "tbl-account";

    // **********************
    // public properties
    // **********************
    
    // **********************
    // private methods
    // **********************
    var _init = function () {
        //load data
        document.title = "Account";
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
    radio("account-Init").subscribe(_init);
});