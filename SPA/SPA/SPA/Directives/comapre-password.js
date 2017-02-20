(function (app) {
    "use strict";
   

    var compareTo = function () {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {
                ngModel.$validators.compareTo = function (modelValue) {
                    debugger;
                    return modelValue === undefined ? true : modelValue === scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function (modelValue) {
                    debugger;
                    ngModel.$validate();
                });
            }
        };
    };

    function ngModelDirective() {
        return {
            require: 'ngModel',
            link: function (scope, elem, attr, ngModel) {
                debugger;
                elem.on('blur', function () {
                    ngModel.$dirty = true;
                    scope.$apply();
                });

                ngModel.$viewChangeListeners.push(function () {
                    ngModel.$dirty = false;
                });

                scope.$on('$destroy', function () {
                    elem.off('blur');
                });
            }
        }
    }


    app.directive("compareTo", compareTo);
    app.directive("ngModel", ngModelDirective);
})(angular.module("directiveModule"));