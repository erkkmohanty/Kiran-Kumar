/// <reference path="../angular.js" />
//Filter in Controller
"use strict";

var eventModule = angular.module("eventModule");

function CustomFilterController($scope,$filter) {
    $scope.number = 1234567890;
    var textValues = ['ab$h#cde&fg@', 'ba$h#dcj&fe@k#', 'ab$hm*hdp&ef@',
'ab$h#cdj&hg$ed@'];
    $scope.filteredvalueuppercase = $filter('uppercase')('kiran');
    $scope.filteredvaluelowercase = $filter('lowercase')('mohanty');
    $scope.filteredvaluecurrency = $filter('currency')('90000000000000');
    $scope.filteredvaluephone = $filter('ConvertPhone')('1234567890');
    $scope.filteredvaluetext = $filter('RemoveSpecialCharacters')(textValues);
}

CustomFilterController.$inject = ["$scope", "$filter"];

eventModule.controller("CustomFilterController", CustomFilterController);