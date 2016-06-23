var eventModule = angular.module("eventModule");

function talkController($scope, EventService, $location) {
    $scope.add = function (talk) {
        debugger;
        EventService.addTalk(talk).then(function (response) {
            alert("Talk added successfully");
            $location.url("/Talks");
        },function(error) {
            alert("error while adding data::" + error);
        });
    };
}

talkController.$inject = ["$scope", "EventService","$location"];

eventModule.controller("talkController", talkController);

