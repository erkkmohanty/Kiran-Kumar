(function (app) {
"use strict";
    app.controller("rootCtrl", rootCtrl);
    rootCtrl.$inject = ["$scope"];
   function rootCtrl($scope) {
       $scope.userData = {};

       $scope.userData.displayUserInfo = displayUserInfo;
       $scope.logout = logout;


       function displayUserInfo() {

       }

       function logout() {

       }
   }
})(angular.module('homeCinema'));