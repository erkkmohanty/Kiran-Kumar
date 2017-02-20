(function (app) {
    "use strict";
    app.directive("sideBar", sideBarDirective);

    function sideBarDirective() {
        var sideBar = {};
        sideBar.restrict = "E";
        sideBar.scope = {};
        sideBar.templateUrl = "SPA/Directives/side-bar.html";
        sideBar.replace = true;
        return sideBar;
    }
})(angular.module("directiveModule"));