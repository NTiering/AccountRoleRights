/**
* Controller for right
*/
app.controller('right', function ($scope) {
    // **********************
    // private properties
    // **********************
    var _dataTableId = "tbl-right";

    // **********************
    // public properties
    // **********************
    
    // **********************
    // private methods
    // **********************
    var _init = function () {
        //load data
        document.title = "Right";
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
    radio("right-Init").subscribe(_init);
});