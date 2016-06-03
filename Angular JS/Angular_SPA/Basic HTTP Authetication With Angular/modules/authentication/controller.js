"use strict";

angular.module("Authentication")
    .controller("LoginController",
    [
        "$scope", "$rootScope", "$location", "AuthenticationService",
        function($scope, $rootScope, $location, AuthenticationService) {
            //reset login status
            debugger;
            if (!$rootScope.globals.currentUser)
                AuthenticationService.ClearCredentials();
            $scope.login = function() {
                debugger;
                $scope.dataLoading = true;
                AuthenticationService.Login($scope.username, $scope.password, function(response) {
                    if (response.success) {
                        AuthenticationService.SetCredentials($scope.username, $scope.password);
                        $location.path("/home");
                    } else {
                        $scope.error = response.message;
                        $scope.dataLoading = false;
                    }
                });
            };
        }
    ]);