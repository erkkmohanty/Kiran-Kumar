var directoryModule = angular.module("directoryModule",[]);

//@ or @attr
directoryModule.directive("attrCustomDirective", function() {
    var directive = {
        restrict:"E",
        scope: { talkname: "@talk" },
        template: "<div>The talk name is {{talkname}}</div>",
        controller:function($scope) {
            setTimeout(function () {
                debugger;
                $scope.talkname = "I have changed the talk value dynamically within the directive";
                $scope.$apply();
            }, 10000);
        }
    };
    return directive;
});