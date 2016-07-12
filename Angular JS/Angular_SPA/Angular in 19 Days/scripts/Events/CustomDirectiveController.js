var eventModule = angular.module("eventModule");
function CustomDirectiveController($scope) {
    $scope.tname = "Angular JS and Node JS";
    setTimeout(function () {
        debugger;
        $scope.tname = "I have changed the talk value dynamically within the controller";
        $scope.$apply();
    }, 7000);

    $scope.talkobj = {};
    $scope.talkobj.talkname = "MEAN Stack";
    $scope.talkobj.speaker = "KIRAN KUMAR";
    $scope.speaker = "KK";
    $scope.UpdateData = function() {
        $scope.speaker = "Kiran Kumar Mohanty";
    };
    $scope.olddata = "Old Data from controller";
    $scope.UpdateParamData = function(modifieddata) {
        $scope.olddata = "Modified Data from controller::" + modifieddata;
    };

    $scope.olddata2 = "Old data2 from controller";
    $scope.UpdateParamData2 = function (modifieddata) {
        $scope.olddata2 = "Modified Data from controller::" + modifieddata;
    };

    $scope.olddata3 = "Old data3 from controller";
    $scope.UpdateParamData3 = function (modifieddata) {
        $scope.olddata3 = "Modified Data from controller::" + modifieddata;
    };
}

CustomDirectiveController.$inject = ["$scope"];

eventModule.controller("CustomDirectiveController", CustomDirectiveController);

