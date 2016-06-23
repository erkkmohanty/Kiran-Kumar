var eventModule = angular.module("eventModule");
function CustomDirectiveController($scope) {
    $scope.tname = "Angular JS and Node JS";
    setTimeout(function () {
        debugger;
        $scope.tname = "I have changed the talk value dynamically within the controller";
        $scope.$apply();
    }, 7000);
}

CustomDirectiveController.$inject = ["$scope"];

eventModule.controller("CustomDirectiveController", CustomDirectiveController);

