var eventModule = angular.module("eventModule");

function eventController($scope, EventService) {
    EventService.getTalks().then(function(talks) {
        debugger;
        $scope.talks = talks;
    }, function(error) {
        alert("Error while fetching talks from the server" + error);
    });
}

eventController.$inject = ["$scope", "EventService"];
eventModule.controller("eventController", eventController);