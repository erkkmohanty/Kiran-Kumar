/// <reference path="header.html" />
(function (app) {
    "use strict";
    app.directive("headerBar", headerDirective);
    function headerDirective() {
        var header = {};
        header.restrict = "E";
        header.scope = {};
        header.templateUrl = "SPA/Directives/header.html";
        header.replace = true;
        return header;
    }
})(angular.module("directiveModule"));