/// <reference path="../app.js" />
/// <reference path="../services/authService.js" />

"use strict";

app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {
        debugger;
        authService.login($scope.loginData).then(function (response) {
            $location.path("/orders");
        }, function (error) {
            $scope.message = err.error_description;
        });
    };
}]);