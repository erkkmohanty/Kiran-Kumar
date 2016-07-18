(function(app) {
    "use strict";
    app.directive("sideBar", sideBar);

    function sideBar() {
        var sidebarDirective = {};
        sidebarDirective.restrict = "E";
        sidebarDirective.replace = true;
        sidebarDirective.templateUrl = "/scripts/spa/layout/sideBar.html";
        return sidebarDirective;
    }
})(angular.module("common.ui"));