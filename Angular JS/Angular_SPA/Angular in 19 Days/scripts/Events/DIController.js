/// <reference path="../angular.js" />
"use strict";
var dimodule = angular.module("DI Module");
dimodule.controller("DIController", function ($scope, NumberofItems, ApplicationHeader, Person, Time) {
    $scope.itemscount = NumberofItems;
    $scope.appHeader = ApplicationHeader;
    $scope.Person = Person;
    $scope.currentTime = Time;
});