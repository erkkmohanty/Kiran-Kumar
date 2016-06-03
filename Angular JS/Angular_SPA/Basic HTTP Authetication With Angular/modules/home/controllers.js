"use strict";

angular.module("Home")
    .controller("HomeController",
    [
        "$scope", "AuthenticationService",
        function($scope, AuthenticationService) {
            $scope.LogOut = function() {
                AuthenticationService.ClearCredentials();
            };
        }
    ]);