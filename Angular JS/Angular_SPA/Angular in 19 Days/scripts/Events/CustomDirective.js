"use strict";
var directoryModule = angular.module("directoryModule",[]);

//@ or @attr
directoryModule.directive("attrCustomDirective", function () {


    var directive = {
        restrict: "E",
        scope: { talkname: "@talk" },
        template: "<div>The talk name is {{talkname}}</div>",
        replace: true,
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

//= or =attr

directoryModule.directive("equalCustomDirective", function () {
    var directive = {};
    directive.restrict = "E";
    directive.scope = { instance: "=data" };//it can be written as {instance:"="}
    directive.template = "<input type='textbox' ng-model='instance.talkname'/><br/><div> The Talk data is {{instance.talkname}} and {{instance.speaker}}";
    directive.controller = function ($scope) {
        setTimeout(function () {
            debugger;
        $scope.instance.talkname = "Within the directive talkname";
        $scope.instance.speaker = "Within the directive speaker";
        $scope.$apply();
        }, 5000);
    };
    return directive;
});


//& or &attr

directoryModule.directive("ampersandCustomDirective", function() {
    return{
        restrict: "E",
        scope: { method: "&expr", text: "@txt" }, //it can be written as {method:"&"}
        template: "The Original data is {{text}}. For updated data pls click on the button.<br/> " +
            "<input type='button' value='Click Here' ng-click='method()' class='btn btn-primary'/>",
};
});


//& or &attr with parameter

directoryModule.directive("ampersandParamDirective", function() {
    return{
        restrict: "E",
        scope: { method: "&", data: "@" },
        template: "The original data is {{data}}.For Parameterized data enter text on the textbox.<br/>" +
            "<input type='text' ng-keyup='method({updatedData:txtdata})' ng-model='txtdata'/><br/>Textbox data from directive:{{txtdata}}",
    };
});

//& or &attr with parameter using link-1
directoryModule.directive("ampersandParamLinkDirective", function () {
    debugger;
    return {
        restrict: "E",
        scope: { method: "&mthd", talkname:"@" },
        template: "<div>{{talkname}}</div> <input type='button' " +
                    "ng-click='method(updatedName)' value='Update Data'/> ",
        link: function (scope, element, attrs) {
            scope.method({ updatedName: "Updated topic name" });
        }
    };
});

//& or &attr with parameter using link-2
directoryModule.directive("ampersandParamLinkDirective2", function () {
    debugger;
    return {
        restrict: "E",
        scope: { method: "&mthd", talkname: "@" },
        template: "<div>{{talkname}}</div> <input type='button' " +
                    "ng-click='method({updatedName:NewTalk})' value='Update Data'/> ",
        link: function (scope, element, attrs) {
            debugger;
            scope.NewTalk = attrs.talknm;
        }
    };
});