(function (app) {
    "use strict";
    app.controller("t9Controller", t9Controller);
    function t9Controller() {
        var vm = this;
        vm.simple = "Click to enter whatever numers you want";

        var _selected;

        vm.getterSetter = function (newSelected) {
            debugger;
            if (angular.isUndefined(newSelected)) {
                return _selected;
            }

            if (newSelected < 100) {
                return (_selected = "100");
            }
            if (newSelected > 500) {
                return (_selected = "500");
            }
            return (_selected = newSelected);
        }
    }
})(angular.module("t9Module"));