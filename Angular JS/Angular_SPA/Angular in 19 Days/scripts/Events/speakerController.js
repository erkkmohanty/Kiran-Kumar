var eventModule = angular.module("eventModule");

function speakerController($scope, EventService) {
    EventService.getSpeakers().then(function (response) {
        debugger;
        $scope.speakers = response;
    }, function(error) {
        alert("error while retrieving speakers" + error);
    });
}



speakerController.$inject = ["$scope", "EventService"];

eventModule.controller("speakerCtrl", speakerController);