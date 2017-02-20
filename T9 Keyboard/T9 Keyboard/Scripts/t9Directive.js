(function (app) {
    'use strict';
   
    app.directive('numericKeyboard', numericKeyboard);

    function numericKeyboard(numericKeyboardService) {
        return {
            restrict: 'E',
            require: '',
            scope: {},
            templateUrl: "numericKeyboard.html",
            link: function (scope) {
                scope.numericService = numericKeyboardService;

                scope.append = function (key) {
                    scope.numericService.append(key);
                };

                scope.done = function () {
                    scope.numericService.done();
                };
                scope.clear = function () {
                    scope.numericService.clear();
                };
                scope.close = function () {
                    scope.numericService.done();
                    scope.isOpen = false;
                };
                scope.stopPropagation = function (event) {
                    event.stopPropagation();
                };


                scope.$watch('numericService.isOpened()', function () {
                    scope.isOpen = scope.numericService.isOpened();
                }, true);
            }
        };
    }
   

})(angular.module("t9Module"));

